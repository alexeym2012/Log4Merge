using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Log4Merge.Domain.Models;
using Log4Merge.Domain.Settings;

namespace Log4Merge.Domain.Services
{
    public class LogParser : ILogParser
    {
        private readonly ILogParserSettings _settings;

        public LogParser(ILogParserSettings settings)
        {
            _settings = settings;
        }

        public List<LogEntry> ParseLogFile(string logFileName)
        {
            var logLines = ReadAllLinesWithEncodingFallback(logFileName);
            var entries = ParseLogLines(logFileName, logLines);
            // If UTF-8 read produced no entries but file had lines, retry with system encoding (e.g. Windows-1252)
            if (entries.Count == 0 && logLines.Length > 0)
            {
                try
                {
                    var fallbackLines = File.ReadAllLines(logFileName, Encoding.Default);
                    entries = ParseLogLines(logFileName, fallbackLines);
                }
                catch (IOException) { /* use existing empty result */ }
            }
            return entries;
        }

        public List<LogEntry> ParseLogFileFromPosition(string logFileName, long startPosition, out long newPosition)
        {
            var entries = new List<LogEntry>();
            newPosition = startPosition;

            // Try FileShare.ReadWrite first; fall back to FileShare.Read if denied
            FileStream fs;
            try
            {
                fs = new FileStream(logFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            }
            catch (IOException)
            {
                fs = new FileStream(logFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            }

            using (fs)
            {
                if (fs.Length <= startPosition)
                    return entries;

                fs.Seek(startPosition, SeekOrigin.Begin);
                var bytesToRead = (int)(fs.Length - startPosition);
                var bytes = new byte[bytesToRead];
                int bytesRead = fs.Read(bytes, 0, bytesToRead);
                newPosition = startPosition + bytesRead;

                var text = Encoding.UTF8.GetString(bytes, 0, bytesRead);
                var lines = text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                var format = _settings?.TimeStampFormat;
                if (string.IsNullOrEmpty(format)) format = LogEntry.DefaultTimeStampFormat;
                var formatLen = format.Length;

                LogEntry lastEntry = null;
                foreach (var logLine in lines)
                {
                    if (logLine.Length < formatLen)
                    {
                        lastEntry?.AppendMessage(logLine);
                        continue;
                    }
                    var timeString = logLine.Substring(0, formatLen);
                    var message = logLine.Substring(formatLen);
                    if (DateTime.TryParseExact(timeString, format,
                            CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var timeStamp))
                    {
                        var entry = new LogEntry(logFileName, 0, timeStamp.ToUniversalTime(), message);
                        entries.Add(entry);
                        lastEntry = entry;
                    }
                    else
                    {
                        lastEntry?.AppendMessage(logLine);
                    }
                }
            }

            return entries;
        }

        private List<LogEntry> ParseLogLines(string logFileName, string[] logLines)
        {
            var entries = new List<LogEntry>();
            LogEntry lastEntry = null;
            var format = _settings?.TimeStampFormat;
            if (string.IsNullOrEmpty(format)) format = LogEntry.DefaultTimeStampFormat;
            var formatLen = format.Length;

            for (var i = 0; i < logLines.Length; i++)
            {
                var logLine = logLines[i];
                if (logLine.Length < formatLen)
                {
                    lastEntry?.AppendMessage(logLine);
                }
                else
                {
                    var timeString = logLine.Substring(0, formatLen);
                    var message = logLine.Substring(formatLen);

                    if (DateTime.TryParseExact(timeString, format, CultureInfo.InvariantCulture,
                            DateTimeStyles.AssumeUniversal, out var timeStamp))
                    {
                        var entry = new LogEntry(logFileName, i + 1, timeStamp.ToUniversalTime(), message);
                        entries.Add(entry);
                        lastEntry = entry;
                    }
                    else
                    {
                        lastEntry?.AppendMessage(logLine);
                    }
                }
            }

            return entries;
        }

        private static string[] ReadAllLinesWithEncodingFallback(string logFileName)
        {
            Stream stream;
            try
            {
                stream = new FileStream(logFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            }
            catch (IOException)
            {
                stream = new FileStream(logFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            }
            try
            {
                using (var reader = new StreamReader(stream, Encoding.UTF8, detectEncodingFromByteOrderMarks: true))
                {
                    var lines = new List<string>();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                        lines.Add(line);
                    return lines.ToArray();
                }
            }
            catch (DecoderFallbackException)
            {
                stream?.Dispose();
                return File.ReadAllLines(logFileName, Encoding.Default);
            }
        }
    }
}

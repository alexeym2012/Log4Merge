using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Log4Merge.Domain
{
    internal class LogEntry
    {
        internal static readonly string DefaultLevelRegexPattern = @"^\s*-\s*(ERROR|FATAL|WARN(?:ING)?|INFO|DEBUG|TRACE)\b";
        internal static readonly string DefaultTimeStampFormat = @"yyyy-MM-dd HH:mm:ss,fff";

        private static string s_cachedPattern;
        private static Regex s_cachedRegex;

        private static Regex GetLevelRegex()
        {
            var pattern = Log4Merge.Properties.Settings.Default.LevelRegexPattern;
            if (string.IsNullOrEmpty(pattern))
                pattern = DefaultLevelRegexPattern;

            if (s_cachedPattern == pattern && s_cachedRegex != null)
                return s_cachedRegex;

            try
            {
                s_cachedRegex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
                s_cachedPattern = pattern;
                return s_cachedRegex;
            }
            catch (ArgumentException)
            {
                s_cachedRegex = new Regex(DefaultLevelRegexPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
                s_cachedPattern = DefaultLevelRegexPattern;
                return s_cachedRegex;
            }
        }

        public string SourceFileName { get; }
        public long LineNumber { get; }
        public DateTime TimeStamp { get; }
        public string Message { get; private set; }
        public string ShortMessage { get; set; }
        public string LogLevel { get; }

        public string TimeStampAsText
        {
            get
            {
                var format = Log4Merge.Properties.Settings.Default.TimeStampFormat;
                if (string.IsNullOrEmpty(format))
                    format = DefaultTimeStampFormat;
                try
                {
                    return TimeStamp.ToString(format);
                }
                catch (FormatException)
                {
                    return TimeStamp.ToString(DefaultTimeStampFormat);
                }
            }
        }

        public LogEntry(
            string sourceFileName,
            long lineNumber,
            DateTime timeStamp,
            string message
            )
        {
            SourceFileName = sourceFileName;
            LineNumber = lineNumber;
            TimeStamp = timeStamp;
            Message = message;

            var m = GetLevelRegex().Match(message);
            LogLevel = m.Success
                ? (m.Groups[1].Value.ToUpper() == "WARNING" ? "WARN" : m.Groups[1].Value.ToUpper())
                : "";

            ShortMessage = Message;

            if (Message.Length > 100)
            {
                ShortMessage = Message.Substring(0, 100);
            }

        }

        public void AppendMessage(string message)
        {
            this.Message += $"\n{message}";
        }
    }
}

using System.Collections.Generic;
using Log4Merge.Domain.Models;

namespace Log4Merge.Domain.Services
{
    public interface ILogParser
    {
        List<LogEntry> ParseLogFile(string logFileName);
        List<LogEntry> ParseLogFileFromPosition(string logFileName, long startPosition, out long newPosition);
    }
}

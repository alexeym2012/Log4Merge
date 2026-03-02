using System.Collections.Generic;
using System.Linq;
using Log4Merge.Domain.Models;

namespace Log4Merge.Domain.Services
{
    public static class LogFilter
    {
        private static readonly HashSet<string> KnownLevels =
            new HashSet<string> { "ERROR", "FATAL", "WARN", "INFO", "DEBUG", "TRACE" };

        public static bool IsMatch(LogEntry entry, FilterCriteria criteria)
        {
            if (criteria == null) return true;

            bool textMatch = true;
            if (!string.IsNullOrEmpty(criteria.FilterText))
            {
                var patterns = criteria.FilterText.Split('|')
                    .Select(p => p.Trim().ToLower())
                    .Where(p => p.Length > 0)
                    .ToArray();
                textMatch = patterns.Length == 0 || patterns.Any(p => entry.Message.ToLower().Contains(p));
            }

            bool levelMatch = true;
            if (criteria.EnabledLevels != null)
            {
                // Known levels match by name; unknown/empty levels match the "" sentinel ("other")
                bool isKnown = KnownLevels.Contains(entry.LogLevel);
                levelMatch = isKnown
                    ? criteria.EnabledLevels.Contains(entry.LogLevel)
                    : criteria.EnabledLevels.Contains("");
            }

            bool timeInRange =
                (!criteria.FromUtc.HasValue || entry.TimeStamp >= criteria.FromUtc.Value) &&
                (!criteria.ToUtc.HasValue   || entry.TimeStamp <= criteria.ToUtc.Value);

            return textMatch && levelMatch && timeInRange;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Log4Merge.Domain.Models;

namespace Log4Merge.Domain.Services
{
    public class LogRepository
    {
        public BindingList<LogEntry> Entries { get; private set; } = new BindingList<LogEntry>();

        public void Clear()
        {
            Entries.Clear();
        }

        public void AddRange(IEnumerable<LogEntry> entries)
        {
            foreach (var entry in entries)
                Entries.Add(entry);
        }

        public void DeduplicateAndSort()
        {
            Entries = new BindingList<LogEntry>(
                Entries.Distinct().OrderBy(l => l.TimeStamp).ToList());
        }

        public void AppendAndSort(IEnumerable<LogEntry> newEntries)
        {
            foreach (var entry in newEntries.OrderBy(e => e.TimeStamp))
                Entries.Add(entry);
            Entries = new BindingList<LogEntry>(Entries.OrderBy(l => l.TimeStamp).ToList());
        }

        public void RemoveHighlighted(IEnumerable<HighlightEntry> rules)
        {
            var ruleList = rules.ToList();
            var keep = Entries.Where(e => !ruleList.Any(r => r.IsMatch(e.Message))).ToList();
            Entries = new BindingList<LogEntry>(keep);
        }

        public void KeepHighlighted(IEnumerable<HighlightEntry> rules)
        {
            var ruleList = rules.ToList();
            var keep = Entries.Where(e => ruleList.Any(r => r.IsMatch(e.Message))).ToList();
            Entries = new BindingList<LogEntry>(keep.Distinct().ToList());
        }

        public void RemoveByText(IEnumerable<string> patterns)
        {
            var patternList = patterns.Select(p => p.ToLower()).ToList();
            var keep = Entries
                .Where(e => !patternList.Any(p => e.Message.ToLower().Contains(p)))
                .ToList();
            Entries = new BindingList<LogEntry>(keep);
        }

        public void RemoveBefore(DateTime timestamp)
        {
            var keep = Entries.Where(e => e.TimeStamp >= timestamp)
                .Distinct().OrderBy(e => e.TimeStamp).ToList();
            Entries = new BindingList<LogEntry>(keep);
        }

        public void RemoveAfter(DateTime timestamp)
        {
            var keep = Entries.Where(e => e.TimeStamp <= timestamp)
                .Distinct().OrderBy(e => e.TimeStamp).ToList();
            Entries = new BindingList<LogEntry>(keep);
        }

        public void KeepEntries(IEnumerable<LogEntry> entriesToKeep)
        {
            var keepSet = new HashSet<LogEntry>(entriesToKeep);
            Entries = new BindingList<LogEntry>(Entries.Where(e => keepSet.Contains(e)).ToList());
        }

        public void RemoveEntries(IEnumerable<LogEntry> entriesToRemove)
        {
            var removeSet = new HashSet<LogEntry>(entriesToRemove);
            Entries = new BindingList<LogEntry>(Entries.Where(e => !removeSet.Contains(e)).ToList());
        }

        public void UpdateShortMessages(int visibleLen)
        {
            if (visibleLen <= 0) visibleLen = 100;
            foreach (var entry in Entries)
                entry.ShortMessage = entry.Message.Length > visibleLen
                    ? entry.Message.Substring(0, visibleLen)
                    : entry.Message;
        }
    }
}

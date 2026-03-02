using System;
using System.Collections.Generic;
using System.IO;
using Log4Merge.Domain.Models;
using Newtonsoft.Json;

namespace Log4Merge.Domain.Services
{
    public class HighlightProfileService : IHighlightProfileService
    {
        private static string GetHighlightProfilePath()
        {
            var dir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Log4Merge");
            Directory.CreateDirectory(dir);
            return Path.Combine(dir, "highlights.json");
        }

        public List<HighlightEntry> Load()
        {
            var path = GetHighlightProfilePath();
            if (!File.Exists(path)) return new List<HighlightEntry>();
            try
            {
                var list = JsonConvert.DeserializeObject<List<HighlightEntry>>(File.ReadAllText(path));
                return list ?? new List<HighlightEntry>();
            }
            catch { return new List<HighlightEntry>(); /* corrupt file — ignore */ }
        }

        public void Save(IEnumerable<HighlightEntry> entries)
        {
            try
            {
                File.WriteAllText(GetHighlightProfilePath(),
                    JsonConvert.SerializeObject(entries, Formatting.Indented));
            }
            catch { /* best-effort save */ }
        }
    }
}

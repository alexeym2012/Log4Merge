using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Log4Merge.Domain.Services
{
    public class SessionService : ISessionService
    {
        private static string GetSessionPath()
        {
            var dir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Log4Merge");
            Directory.CreateDirectory(dir);
            return Path.Combine(dir, "session.json");
        }

        public string[] Load()
        {
            var path = GetSessionPath();
            if (!File.Exists(path)) return null;
            try
            {
                return JsonConvert.DeserializeObject<string[]>(File.ReadAllText(path));
            }
            catch { return null; }
        }

        public void Save(IEnumerable<string> filePaths)
        {
            try
            {
                File.WriteAllText(GetSessionPath(),
                    JsonConvert.SerializeObject(new List<string>(filePaths).ToArray(), Formatting.Indented));
            }
            catch { /* best-effort */ }
        }
    }
}

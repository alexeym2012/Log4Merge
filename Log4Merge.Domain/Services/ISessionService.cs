using System.Collections.Generic;

namespace Log4Merge.Domain.Services
{
    public interface ISessionService
    {
        /// <summary>Returns saved file paths, or null/empty if none.</summary>
        string[] Load();

        void Save(IEnumerable<string> filePaths);
    }
}

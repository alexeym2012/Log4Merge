using System.Collections.Generic;
using Log4Merge.Domain.Models;

namespace Log4Merge.Domain.Services
{
    public interface IHighlightProfileService
    {
        /// <summary>Loads highlight entries from persistent storage. Returns empty list if none saved.</summary>
        List<HighlightEntry> Load();

        void Save(IEnumerable<HighlightEntry> entries);
    }
}

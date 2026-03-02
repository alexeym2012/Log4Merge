using System;
using System.Collections.Generic;

namespace Log4Merge.Domain.Models
{
    public class FilterCriteria
    {
        public string FilterText { get; set; }

        /// <summary>Null means all levels are enabled. Empty string in the set represents "other" (unrecognised level).</summary>
        public HashSet<string> EnabledLevels { get; set; }

        public DateTime? FromUtc { get; set; }
        public DateTime? ToUtc { get; set; }
    }
}

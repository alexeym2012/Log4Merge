using Newtonsoft.Json;
using System.Drawing;

namespace Log4Merge.Domain
{
    public class HighlightEntry
    {
        public string Pattern { get; set; }

        [JsonConverter(typeof(ColorJsonConverter))]
        public Color BackColor { get; set; }

        [JsonConverter(typeof(ColorJsonConverter))]
        public Color ForeColor { get; set; }

        public HighlightEntry(
            string pattern,
            Color backColor,
            Color foreColor
        )
        {
            Pattern = pattern;
            BackColor = backColor;
            ForeColor = foreColor;
        }
    }
}
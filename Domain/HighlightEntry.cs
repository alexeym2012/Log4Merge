using Newtonsoft.Json;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Log4Merge.Domain
{
    public class HighlightEntry
    {
        public string Pattern { get; set; }

        [JsonConverter(typeof(ColorJsonConverter))]
        public Color BackColor { get; set; }

        [JsonConverter(typeof(ColorJsonConverter))]
        public Color ForeColor { get; set; }

        public bool IsMatch(string text)
        {
            return string.IsNullOrWhiteSpace(text) == false &&
                   new Regex(Pattern, RegexOptions.IgnoreCase).IsMatch(text);
        }

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
using System.Drawing;

namespace Log4Merge.Domain
{
    public class HighlightEntry
    {
        public string Pattern { get; }
        public Color BackColor { get; }
        public Color ForeColor { get; }

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
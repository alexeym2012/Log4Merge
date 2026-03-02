using Log4Merge.Domain.Settings;

namespace Log4Merge
{
    internal sealed class AppLogParserSettings : ILogParserSettings
    {
        public string TimeStampFormat => Properties.Settings.Default.TimeStampFormat;
        public string LevelRegexPattern => Properties.Settings.Default.LevelRegexPattern;
        public int GridVisibleLineLength => Properties.Settings.Default.GridVisibleLineLength;
    }
}

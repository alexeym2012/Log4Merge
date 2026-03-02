namespace Log4Merge.Domain.Settings
{
    public interface ILogParserSettings
    {
        string TimeStampFormat { get; }
        string LevelRegexPattern { get; }
        int GridVisibleLineLength { get; }
    }
}

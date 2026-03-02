namespace Log4Merge.Domain.Models
{
    public class LoadProgress
    {
        public int CurrentFileIndex { get; set; }
        public int TotalFiles { get; set; }
        public string CurrentFileName { get; set; }
    }
}

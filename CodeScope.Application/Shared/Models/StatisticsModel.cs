namespace CodeScope.Application.Shared.Models
{
    public class StatisticsModel
    {
        public int CodeLines { get; set; }
        public int TotalLines { get; init; }
        public int BlankLines { get; init; }
        public int TotalChars { get; init; }
        public int CommentLines { get; init; }
    }
}
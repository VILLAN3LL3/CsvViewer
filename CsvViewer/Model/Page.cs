namespace CsvViewer.Model
{
    public record Page
    {
        public Page(int startIndex, int endIndex, int pageNumber, int totalPagesCount) =>
            (StartIndex, EndIndex, PageNumber, TotalPagesCount) = (startIndex, endIndex, pageNumber, totalPagesCount);

        public int StartIndex { get; }
        public int EndIndex { get; }
        public int PageNumber { get; }
        public int TotalPagesCount { get; }
    }
}

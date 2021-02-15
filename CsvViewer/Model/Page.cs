namespace CsvViewer.Model
{
    public record Page
    {
        public Page(int startIndex, int endIndex) => (StartIndex, EndIndex) = (startIndex, endIndex);

        public int StartIndex { get; }
        public int EndIndex { get; }
    }
}

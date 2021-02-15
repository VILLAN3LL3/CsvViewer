namespace CsvViewer.Model
{
    public record CommandLineArg
    {
        public CommandLineArg(string path, int pageSize) => (Path, PageSize) = (path, pageSize);

        public string Path { get; }
        public int PageSize { get; }
    }
}

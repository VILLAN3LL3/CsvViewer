namespace CsvViewer.Model
{
    public class CommandLineArg
    {
        public CommandLineArg(string path, int pageSize)
        {
            Path = path;
            PageSize = pageSize;
        }

        public string Path { get; }
        public int PageSize { get; }
    }
}

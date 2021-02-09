using System.IO;

namespace CsvViewer
{
    public class CsvReader
    {
        public string[] ReadCsv(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}

using System.Collections.Generic;

namespace CsvViewer
{
    public class CsvInteractor
    {
        public IList<string> Interact(string path)
        {
            var reader = new CsvReader();
            var csvContent = reader.ReadCsv(path);

            var parser = new CsvParser();
            var csvTable = parser.ParseCsv(csvContent);

            var renderer = new CsvRenderer();
            return renderer.RenderCsv(csvTable);
        }
    }
}

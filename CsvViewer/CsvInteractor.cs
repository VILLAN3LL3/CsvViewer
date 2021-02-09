using System.Collections.Generic;

namespace CsvViewer
{
    public class CsvInteractor
    {
        public IList<string> GetRenderedCsvTableByPath(string path)
        {
            var reader = new CsvReader();
            IList<string[]> csvContent = reader.ReadCsv(path);

            var parser = new CsvParser();
            CsvTable csvTable = parser.ParseCsv(csvContent);

            var renderer = new CsvRenderer();
            return renderer.RenderCsv(csvTable);
        }
    }
}

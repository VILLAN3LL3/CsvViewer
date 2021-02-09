using System.Collections.Generic;

namespace CsvViewer
{
    public class CsvInteractor
    {
        public IList<string> GetRenderedCsvTableByPath(string path)
        {
            var reader = new CsvReader();
            string[] csvContent = reader.ReadCsv(path);

            var creator = new CsvTableCreator();
            CsvTable csvTable = creator.CreateCsvTable(csvContent);

            var renderer = new CsvRenderer();
            return renderer.RenderCsv(csvTable);
        }
    }
}

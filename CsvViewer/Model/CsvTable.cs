using System.Collections.Generic;
using System.Linq;
using CsvViewer.Model;

namespace CsvViewer
{
    public class CsvTable
    {
        public IList<CsvColumn> Columns { get; set; } = new List<CsvColumn>();

        public int TableWidth => Columns.Max(c => c.Width);

        public int DataLinesCount => Columns.FirstOrDefault()?.DataLines.Count ?? 0;
    }
}

using System.Collections.Generic;
using System.Linq;
using CsvViewer.Model;

namespace CsvViewer
{
    public record CsvTable
    {
        public IList<CsvColumn> Columns { get; } = new List<CsvColumn>();

        public int TableWidth => Columns.Max(c => c.Width);

        public int DataLinesCount => Columns.FirstOrDefault()?.DataLines.Count ?? 0;
    }
}

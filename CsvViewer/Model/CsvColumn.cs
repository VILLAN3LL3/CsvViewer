using System;
using System.Collections.Generic;
using System.Linq;

namespace CsvViewer.Model
{
    public record CsvColumn
    {
        public string Header { get; init; }
        public IList<string> DataLines { get; } = new List<string>();

        public int Width => Math.Max(DataLines.Max(l => l.Length), Header.Length);
    }
}

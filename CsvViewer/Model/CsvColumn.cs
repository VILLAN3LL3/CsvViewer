using System;
using System.Collections.Generic;
using System.Linq;

namespace CsvViewer.Model
{
    public class CsvColumn
    {
        public string Header { get; set; }
        public IList<string> DataLines { get; set; } = new List<string>();

        public int Width => Math.Max(DataLines.Max(l => l.Length), Header.Length);
    }
}

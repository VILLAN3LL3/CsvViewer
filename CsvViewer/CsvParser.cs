using System.Collections.Generic;
using System.Linq;
using CsvViewer.Model;

namespace CsvViewer
{
    public class CsvParser
    {
        public CsvTable ParseCsv(IList<string[]> csvContent)
        {
            if (csvContent == null)
            {
                throw new System.ArgumentNullException(nameof(csvContent));
            }

            string[] headerData = csvContent[0];

            var csvTable = new CsvTable();

            for (int i = 0; i < headerData.Length; i++)
            {
                var column = new CsvColumn()
                {
                    Header = csvContent[0][i]
                };

                foreach (string[] item in csvContent.Skip(1))
                {
                    column.DataLines.Add(item[i]);
                }

                csvTable.Columns.Add(column);
            }
            return csvTable;
        }
    }
}

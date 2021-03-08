using System.Collections.Generic;
using System.Linq;
using CsvViewer.Model;

namespace CsvViewer
{
    public class CsvTableCreator
    {
        public CsvTable CreateCsvTable(string[] csvContent)
        {
            IList<string[]> lineList = SplitCsvLines(csvContent);

            var csvTable = new CsvTable();

            for (int i = 0; i < lineList[0].Length; i++)
            {
                CreateColumn(lineList, csvTable, i);
            }
            return csvTable;
        }

        private static void CreateColumn(IList<string[]> lineList, CsvTable csvTable, int i)
        {
            var column = new CsvColumn()
            {
                Header = lineList[0][i]
            };

            foreach (string[] item in lineList.Skip(1))
            {
                column.DataLines.Add(item[i]);
            }

            csvTable.Columns.Add(column);
        }

        private static IList<string[]> SplitCsvLines(string[] csvContent)
        {
            var lineList = new List<string[]>();

            for (int i = 0; i < csvContent.Length; i++)
            {
                string increment = i == 0 ? "No." : $"{i}.";
                lineList.Add(new[] { increment }.Concat(csvContent[i].Split(';')).ToArray());
            }

            return lineList;
        }
    }
}

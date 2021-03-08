using System;
using System.Collections.Generic;
using System.Text;
using CsvViewer.Model;

namespace CsvViewer
{
    public class CsvTableRenderer
    {
        private readonly CsvTable _csvTable;

        public CsvTableRenderer(CsvTable csvTable)
        {
            if (csvTable is null)
            {
                throw new ArgumentNullException(nameof(csvTable), "There is no table available to render");
            }
            _csvTable = csvTable;
        }

        public IList<string> RenderCsv(Page page)
        {
            var renderedList = new List<string>
            {
                RenderEmptyLine(_csvTable),
                RenderHeaderLine(_csvTable)
            };

            for (int i = page.StartIndex; i < page.EndIndex; i++)
            {
                renderedList.Add(RenderEmptyLine(_csvTable));
                renderedList.Add(RenderDataLine(_csvTable, i));
            }

            renderedList.Add(RenderEmptyLine(_csvTable));
            renderedList.Add($"Page {page.PageNumber} of {page.TotalPagesCount}");
            return renderedList;
        }

        private string RenderDataLine(CsvTable csvTable, int i) => RenderLine(csvTable, col => col.DataLines[i].PadRight(col.Width), '|');

        private static string RenderHeaderLine(CsvTable csvTable) => RenderLine(csvTable, col => col.Header.PadRight(col.Width), '|');

        private static string RenderEmptyLine(CsvTable csvTable) => RenderLine(csvTable, col => new string('-', col.Width), '+');

        private static string RenderLine(CsvTable csvTable, Func<CsvColumn, string> valueGenerator, char separator)
        {
            var lineBuilder = new StringBuilder();
            lineBuilder.Append(separator);

            foreach (CsvColumn column in csvTable.Columns)
            {
                lineBuilder.Append(valueGenerator.Invoke(column));
                lineBuilder.Append(separator);
            }

            return lineBuilder.ToString();
        }
    }
}

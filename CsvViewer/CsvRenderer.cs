using System.Collections.Generic;
using System.Text;
using CsvViewer.Model;

namespace CsvViewer
{
    public class CsvRenderer
    {
        public IList<string> RenderCsv(CsvTable csvTable)
        {
            var renderedList = new List<string>
            {
                RenderEmptyLine(csvTable),
                RenderHeaderLine(csvTable)
            };

            for (int i = 0; i < csvTable.DataLinesCount; i++)
            {
                renderedList.Add(RenderEmptyLine(csvTable));
                renderedList.Add(RenderDataLine(csvTable, i));
            }

            renderedList.Add(RenderEmptyLine(csvTable));
            return renderedList;
        }

        private string RenderDataLine(CsvTable csvTable, int i)
        {
            var dataLineBuilder = new StringBuilder();
            dataLineBuilder.Append('|');

            foreach (CsvColumn column in csvTable.Columns)
            {
                dataLineBuilder.Append(column.DataLines[i].PadRight(column.Width));
                dataLineBuilder.Append('|');
            }

            return dataLineBuilder.ToString();
        }

        private static string RenderHeaderLine(CsvTable csvTable)
        {
            var headerLineBuilder = new StringBuilder();
            headerLineBuilder.Append('|');

            foreach (CsvColumn column in csvTable.Columns)
            {
                headerLineBuilder.Append(column.Header.PadRight(column.Width));
                headerLineBuilder.Append('|');
            }

            return headerLineBuilder.ToString();
        }

        private static string RenderEmptyLine(CsvTable csvTable)
        {
            var emptyLineBuilder = new StringBuilder();
            emptyLineBuilder.Append('+');

            foreach (CsvColumn column in csvTable.Columns)
            {
                emptyLineBuilder.Append(GetPlaceholder(column.Width));
                emptyLineBuilder.Append('+');
            }
            return emptyLineBuilder.ToString();
        }

        private static string GetPlaceholder(int length)
        {
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                stringBuilder.Append('-');
            }
            return stringBuilder.ToString();
        }
    }
}

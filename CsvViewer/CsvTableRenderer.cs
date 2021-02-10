using System;
using System.Collections.Generic;
using System.Text;
using CsvViewer.Model;

namespace CsvViewer
{
    public class CsvTableRenderer
    {
        private readonly CsvTable _csvTable;
        public const int PAGE_SIZE = 5;
        private int _offset;

        public CsvTableRenderer(CsvTable csvTable)
        {
            if (csvTable is null)
            {
                throw new ArgumentNullException(nameof(csvTable), "There is no table available to render");
            }
            _csvTable = csvTable;
        }

        public IList<string> RenderFirstPage()
        {
            _offset = 0;
            return RenderCsv();
        }

        public IList<string> RenderLastPage()
        {
            int modulus = _csvTable.DataLinesCount % PAGE_SIZE;
            int offset = ( _csvTable.DataLinesCount / PAGE_SIZE ) * PAGE_SIZE;
            _offset = modulus == 0 ? offset - PAGE_SIZE : offset;
            return RenderCsv();
        }

        public IList<string> RenderNextPage()
        {
            _offset += PAGE_SIZE;
            return RenderCsv();
        }

        public IList<string> RenderPreviousPage()
        {
            _offset = Math.Max(0, _offset - PAGE_SIZE);
            return RenderCsv();
        }

        public IList<string> RenderCsv()
        {
            var renderedList = new List<string>
            {
                RenderEmptyLine(_csvTable),
                RenderHeaderLine(_csvTable)
            };

            for (int i = _offset; i < Math.Min(_offset + PAGE_SIZE, _csvTable.DataLinesCount); i++)
            {
                renderedList.Add(RenderEmptyLine(_csvTable));
                renderedList.Add(RenderDataLine(_csvTable, i));
            }

            renderedList.Add(RenderEmptyLine(_csvTable));
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
                emptyLineBuilder.Append(new string('-', column.Width));
                emptyLineBuilder.Append('+');
            }
            return emptyLineBuilder.ToString();
        }
    }
}

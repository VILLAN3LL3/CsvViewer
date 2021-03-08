using System.Collections.Generic;
using CsvViewer.Model;

namespace CsvViewer
{
    public class CsvInteractor
    {
        private readonly CsvReader _reader = new CsvReader();
        private readonly CsvTableCreator _creator = new CsvTableCreator();
        private readonly CsvTableRenderer _renderer;
        private readonly PageCalculator _calculator;

        public CsvInteractor(CommandLineArg arguments)
        {
            string[] csvContent = _reader.ReadCsv(arguments.Path);
            CsvTable csvTable = _creator.CreateCsvTable(csvContent);
            _renderer = new CsvTableRenderer(csvTable);
            _calculator = new PageCalculator(csvTable.DataLinesCount, arguments.PageSize);
        }

        public IList<string> GotToFirstPage() => _renderer.RenderCsv(_calculator.CalculateFirstPage());

        public IList<string> GoToLastPage() => _renderer.RenderCsv(_calculator.CalculateLastPage());

        public IList<string> GoToNextPage() => _renderer.RenderCsv(_calculator.CalculateNextPage());

        public IList<string> GoToPreviousPage() => _renderer.RenderCsv(_calculator.CalculatePreviousPage());

        public IList<string> JumpToPage(int pageNumber) => _renderer.RenderCsv(_calculator.CalculatePage(pageNumber));
    }
}

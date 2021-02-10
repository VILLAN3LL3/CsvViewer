using System;
using System.Collections.Generic;

namespace CsvViewer
{
    public class CsvInteractor
    {
        private CsvReader _reader = new CsvReader();
        private CsvTableCreator _creator = new CsvTableCreator();
        private CsvTableRenderer _renderer;

        public CsvInteractor(string path)
        {
            string[] csvContent = _reader.ReadCsv(path);
            var csvTable = _creator.CreateCsvTable(csvContent);
            _renderer = new CsvTableRenderer(csvTable);
        }

        public IList<string> GotToFirstPage() => _renderer.RenderFirstPage();

        public IList<string> GoToLastPage() => _renderer.RenderLastPage();

        public IList<string> GoToNextPage() => _renderer.RenderNextPage();

        public IList<string> GoToPreviousPage() => _renderer.RenderPreviousPage();

        public IList<string> Exit()
        {
            Environment.Exit(0);
            return null;
        }
    }
}

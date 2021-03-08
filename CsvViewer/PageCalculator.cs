using System;
using CsvViewer.Model;

namespace CsvViewer
{
    public class PageCalculator
    {
        private readonly int _linesCount;
        private int _offset;
        private readonly int _pageSize;
        private int _totalPageCount => (int)Math.Ceiling(_linesCount / (decimal)_pageSize);

        public PageCalculator(int linesCount, int pageSize, int initialOffset = 0)
        {
            _linesCount = linesCount;
            _offset = initialOffset;
            _pageSize = Math.Min(pageSize, linesCount);
        }

        public int CurrentOffset => _offset;

        public Page CalculateFirstPage()
        {
            _offset = 0;
            return CreatePageFromCurrentOffset();
        }

        public Page CalculateLastPage()
        {
            int modulus = _linesCount % _pageSize;
            int offset = ( _linesCount / _pageSize ) * _pageSize;
            _offset = modulus == 0 ? offset - _pageSize : offset;
            return CreatePageFromCurrentOffset();
        }

        public Page CalculateNextPage()
        {
            _offset += _pageSize;
            return _offset > _linesCount ? CalculateFirstPage() : CreatePageFromCurrentOffset();
        }

        public Page CalculatePreviousPage()
        {
            _offset -= _pageSize;
            return _offset < 0 ? CalculateLastPage() : CreatePageFromCurrentOffset();
        }

        public Page CalculatePage(int pageNumber)
        {
            _offset = ( _pageSize * pageNumber ) - _pageSize;
            if (_offset < 0)
            {
                return CalculateFirstPage();
            }
            if (_offset > _linesCount - 1)
            {
                return CalculateLastPage();
            }
            return CreatePageFromCurrentOffset();
        }

        private Page CreatePageFromCurrentOffset()
        {
            int endIndex = Math.Min(_offset + _pageSize, _linesCount);
            int pageNumber = (int)Math.Ceiling(endIndex / (decimal)_pageSize);
            return new Page(_offset, endIndex, pageNumber, _totalPageCount);
        }
    }
}

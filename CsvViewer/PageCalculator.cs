using System;
using CsvViewer.Model;

namespace CsvViewer
{
    public class PageCalculator
    {
        private readonly int _linesCount;
        private int _offset;
        private readonly int _pageSize;

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

        private Page CreatePageFromCurrentOffset()
        {
            return new Page(_offset, Math.Min(_offset + _pageSize, _linesCount));
        }
    }
}

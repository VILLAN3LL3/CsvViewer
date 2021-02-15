using System;
using CsvViewer.Model;

namespace CsvViewer
{
    public class PageCalculator
    {
        public const int PAGE_SIZE = 5;
        private readonly int _linesCount;
        private int _offset;

        public PageCalculator(int linesCount, int initialOffset = 0)
        {
            _linesCount = linesCount;
            _offset = initialOffset;
        }

        public int CurrentOffset => _offset;

        public Page CalculateFirstPage()
        {
            _offset = 0;
            return CreatePageFromCurrentOffset();
        }

        public Page CalculateLastPage()
        {
            int modulus = _linesCount % PAGE_SIZE;
            int offset = ( _linesCount / PAGE_SIZE ) * PAGE_SIZE;
            _offset = modulus == 0 ? offset - PAGE_SIZE : offset;
            return CreatePageFromCurrentOffset();
        }

        public Page CalculateNextPage()
        {
            _offset += PAGE_SIZE;
            return _offset > _linesCount ? CalculateFirstPage() : CreatePageFromCurrentOffset();
        }

        public Page CalculatePreviousPage()
        {
            _offset -= PAGE_SIZE;
            return _offset < 0 ? CalculateLastPage() : CreatePageFromCurrentOffset();
        }

        private Page CreatePageFromCurrentOffset()
        {
            return new Page(_offset, Math.Min(_offset + PAGE_SIZE, _linesCount));
        }
    }
}

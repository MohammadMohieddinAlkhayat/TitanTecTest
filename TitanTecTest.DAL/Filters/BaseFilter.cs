using System;

namespace TitanTecTest.DAL.Filters
{
    public enum SortDirection
    {
        
        Ascending = 0,
        Descending = 1
    }


    public class BaseFilter
    {
        
        public int Page { get; set; } = 0;

        public int RequestedPage
        {
            get
            {
                return Page > 0 ? Page : 0;
            }
        }

        private int _pageLength;

        public int PageLength
        {
            get => _pageLength <= 0 ? 10 : _pageLength;
            set => _pageLength = value <= 0 ? 10 : value;
        }

        public string OrderBy { get; set; }

        public SortDirection SortDirection { get; set; }

        public string SearchQuery { get; set; }

        public int ElementsToBeSkipedCount
        {
            get
            {
                return this.RequestedPage * PageLength;
            }
        }

        public static int[] PageLengthOptions = new int[] { 1, 4, 8, 12, 24, 36 };

        public DateTime? MinCreateDate { get; set; }
        public DateTime? MaxCreateDate { get; set; }

        public DateTime? MinLastUpdateDate { get; set; }
        public DateTime? MaxLastUpdateDate { get; set; }


    }
}

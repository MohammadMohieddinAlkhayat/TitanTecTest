using TitanTecTest.DAL.Filters;

namespace TitanTecTest.BL.Helpers
{
    public class BasePageResultDto
    {
        public int Page { get; set; }
        public int PageLength{get ;set ;}
        public string SearchQuery { get; set; }
        public string OrderBy { get; set; }
        public SortDirection SortDirection { get; set; }
        public int ElementsToBeSkipedCount { get; set; }

    }
}

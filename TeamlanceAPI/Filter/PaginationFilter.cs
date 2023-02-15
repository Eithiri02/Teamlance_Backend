namespace TeamlanceAPI.Filter
{
    public class PaginationFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set;  }
        public PaginationFilter()
        {
            this.PageNumber = 1;
            this.PageSize = 10;

        }
        public PaginationFilter (int pageNumber,int pageSize)
        {
            PageNumber = pageNumber ;
            PageSize = pageSize ;
        }
    }
}

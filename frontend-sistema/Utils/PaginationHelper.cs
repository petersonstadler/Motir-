namespace frontend_sistema.Utils
{
    public class PaginationHelper
    {
        
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public int TotalPagesCount { get; set; } = 0;
        public string PagesActionLink { get; set; } = string.Empty;

        public PaginationHelper(int pageIndex, int pageSize , int totalItemsCount, string pagesActionLink) 
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            PagesActionLink = pagesActionLink;
            TotalPagesCount = (int) Math.Ceiling( (decimal)totalItemsCount / pageSize);
        }

        public IQueryable<Object> PaginarColsulta(IQueryable<Object> consulta)
        {
            return consulta = consulta
                                    .Skip((this.PageIndex - 1) * PageSize)
                                    .Take(PageSize);
        }
    }
}
using frontend_sistema.Models;

namespace frontend_sistema.Utils
{
    public class PaginationHelper
    {
        
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public int TotalPagesCount { get; set; } = 0;
        public string PagesActionLink { get; set; } = string.Empty;

        public PaginationHelper(int pageIndex, int pageSize , int totalPagesCount, string pagesActionLink) 
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.TotalPagesCount = totalPagesCount;
            this.PagesActionLink = pagesActionLink;
        }

        public IQueryable<Object> PaginarColsulta(IQueryable<Object> consulta)
        {
            return consulta = consulta
                                    .Skip((this.PageIndex - 1) * PageSize)
                                    .Take(PageSize);
        }
    }
}
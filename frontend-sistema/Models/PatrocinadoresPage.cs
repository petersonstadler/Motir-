using frontend_sistema.Utils;

namespace frontend_sistema.Models
{
    public class PatrocinadoresPage
    {
        public IEnumerable<Patrocinador>? Patrocinadores { get; set; } = null;
        public PaginationHelper? Pagination { get; set; } = null;
    }
}
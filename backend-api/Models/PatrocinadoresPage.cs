using frontend_sistema.Utils;

namespace backend_api.Models
{
    public class PatrocinadoresPage
    {
        public IEnumerable<Patrocinador>? Patrocinadores { get; set; } = null;
        public PaginationHelper? Pagination { get; set; } = null;
    }
}
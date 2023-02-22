using frontend_sistema.Models;

namespace frontend_sistema.Repositories
{
    public interface IPatrocinadorRepository
    {
        // public Task<Patrocinador> GetById(int id);
        public Task<IEnumerable<Patrocinador>> GetAll();
        // public Task<IEnumerable<Patrocinador>> GetListByResponsavel(string responsavelName);
        // public Task<IEnumerable<Patrocinador>> GetAllOkStatus();
    }
}
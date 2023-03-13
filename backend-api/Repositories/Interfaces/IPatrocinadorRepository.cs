using backend_api.Models;

namespace backend_api.Repositories.Interfaces
{
    public interface IPatrocinadorRepository
    {
        Task<IEnumerable<Patrocinador>> GetAll();
        Task<IEnumerable<Patrocinador>> GetByResponsavel(string responsavel);
        Task<Patrocinador> GetById(int id);
        Task<bool> Novo(Patrocinador patrocinador);
        Task<bool> Atualizar(int id, Patrocinador newPatrocinador);
        Task<bool> Deletar(int id);
    }
}
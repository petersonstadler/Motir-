using frontend_sistema.Models;

namespace frontend_sistema.Repositories
{
    public interface IPatrocinadorRepository
    {
        public Task<IEnumerable<Patrocinador>> GetAll();
        public Task<string> UpdateAsync(Patrocinador patrocinador);
    }
}
using frontend_sistema.Models;

namespace frontend_sistema.Repositories
{
    public interface IPatrocinadorRepository
    {
        public Task<IEnumerable<Patrocinador>> GetAll();
        public Task<Patrocinador> GetById(int id);
        public Task<string> CreateAsync(Patrocinador patrocinador);
        public Task<string> UpdateAsync(Patrocinador patrocinador);
        public Task<string> Delete(int id);
    }
}
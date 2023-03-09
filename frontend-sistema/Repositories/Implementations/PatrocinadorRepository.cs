using frontend_sistema.Models;
using frontend_sistema.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace frontend_sistema.Repositories.Implementations
{
    public class PatrocinadorRepository : IPatrocinadorRepository
    {
        public async Task<IEnumerable<Patrocinador>> GetAll()
        {
            var apiResult = await HttpClientHelper.GetAsync("/api/Patrocinadores/GetAll");
            IEnumerable<Patrocinador>? patrocinadores;
            try
            {
                patrocinadores = JsonConvert.DeserializeObject<IEnumerable<Patrocinador>>(apiResult);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
            return patrocinadores ?? new List<Patrocinador>();
        }

        public async Task<string> UpdateAsync(Patrocinador patrocinador)
        {
            try
            {
                return await HttpClientHelper.PostAsync("api/Patrocinadores", patrocinador);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}
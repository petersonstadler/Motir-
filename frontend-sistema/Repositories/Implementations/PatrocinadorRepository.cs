using frontend_sistema.Models;
using frontend_sistema.Utils;
using Newtonsoft.Json;

namespace frontend_sistema.Repositories.Implementations
{
    public class PatrocinadorRepository : IPatrocinadorRepository
    {
        public async Task<IEnumerable<Patrocinador>> GetAll()
        {
            IEnumerable<Patrocinador>? patrocinadores;
            try
            {
                var apiResult = await HttpClientHelper.GetAsync("/api/Patrocinadores/GetAll");
                patrocinadores = JsonConvert.DeserializeObject<IEnumerable<Patrocinador>>(apiResult);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
            return patrocinadores ?? new List<Patrocinador>();
        }

        public async Task<Patrocinador> GetById(int id)
        {
            Patrocinador? patrocinador;
            try
            {
                var url = "api/Patrocinadores/GetById/" + id.ToString();
                var apiResult = await HttpClientHelper.GetAsync(url);
                patrocinador = JsonConvert.DeserializeObject<Patrocinador>(apiResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
            return patrocinador ?? new Patrocinador();
        }

        public async Task<string> CreateAsync(Patrocinador patrocinador)
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

        public async Task<string> UpdateAsync(int id, Patrocinador patrocinador)
        {
            try
            {
                return await HttpClientHelper.PutAsync("api/Patrocinadores/" + id.ToString(), patrocinador);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<string> Delete(int id)
        {
            try
            {
                return await HttpClientHelper.DeleteAsync("api/Patrocinadores/" + id.ToString());
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<PatrocinadoresPage> GetPaginated(int pageIndex, int pageSize)
        {
            try
            {
                var apiResult = await HttpClientHelper.GetAsync("api/Patrocinadores/GetPaginated?" + "pageIndex=" + pageIndex + "&pageSize=" + pageSize);
                var page = JsonConvert.DeserializeObject<PatrocinadoresPage>(apiResult);
                return page ?? new PatrocinadoresPage();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}
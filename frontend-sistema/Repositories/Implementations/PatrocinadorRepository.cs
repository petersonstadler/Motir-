using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_api.Models;

namespace frontend_sistema.Repositories.Implementations
{
    public class PatrocinadorRepository : IPatrocinadorRepository
    {
        public Task<IEnumerable<Patrocinador>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
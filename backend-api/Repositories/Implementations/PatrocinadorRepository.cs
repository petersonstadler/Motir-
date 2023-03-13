using backend_api.Data;
using backend_api.Models;
using backend_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend_api.Repositories.Implementations
{
    public class PatrocinadorRepository : IPatrocinadorRepository
    {
        public readonly AppPrincipalContext _context;
        private readonly ILogger<PatrocinadorRepository> _logger;

        public PatrocinadorRepository(AppPrincipalContext context, 
                                    ILogger<PatrocinadorRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public  IEnumerable<Patrocinador> GetAllPatrocinadores => _context.Patrocinadores ?? throw new Exception(message: "Erro ao tentar capturar patrocinadores no banco de dados! Patrocinadores não pode ser nulo!");


        public async Task<IEnumerable<Patrocinador>> GetAll()
        {
            if(_context.Patrocinadores != null)
                return await _context.Patrocinadores.ToListAsync();
            throw new Exception(message: "Erro ao tentar capturar patrocinadores no banco de dados! Patrocinadores não pode ser nulo!");
        }
        public async Task<IEnumerable<Patrocinador>> GetByResponsavel(string responsavel)
        {
            if(_context.Patrocinadores != null)
                return await _context.Patrocinadores.Where(p => p.Responsavel == responsavel).ToListAsync();
            throw new Exception(message: "Erro ao tentar capturar patrocinadores no banco de dados! Patrocinadores não pode ser nulo!");
        }

        public async Task<bool> Novo(Patrocinador patrocinador)
        {
            try
            {
                if(patrocinador.Responsavel != null)
                    patrocinador.Responsavel = patrocinador.Responsavel.ToUpper();
                _context.Update(patrocinador);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            return false;
        }

        public async Task<bool> Atualizar(int id, Patrocinador newPatrocinador)
        {
            try
            {
                if(_context.Patrocinadores != null)
                {
                    var oldPatrocinador = await _context.Patrocinadores.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
                    if(oldPatrocinador != null)
                    {
                        if(newPatrocinador.Responsavel != null)
                            newPatrocinador.Responsavel = newPatrocinador.Responsavel.ToUpper();
                        _context.Update(newPatrocinador);
                        await _context.SaveChangesAsync();
                        return true;
                    }
                }
            }
            catch(Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            return false;
        }

        public async Task<bool> Deletar(int id)
        {
            try
            {
                if(_context.Patrocinadores != null)
                {
                    var patrocinador = await _context.Patrocinadores.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
                    if(patrocinador != null)
                    {
                        _context.Remove(patrocinador);
                        await _context.SaveChangesAsync();
                        return true;
                    }
                }
            }
            catch(Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            return false;
        }

        public async Task<Patrocinador?> GetById(int id)
        {
            try
            {
                if (_context.Patrocinadores != null)
                {
                    var patrocinador = await _context.Patrocinadores.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
                    return patrocinador;
                }
            }
            catch(Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            return null;
        }
    }
}
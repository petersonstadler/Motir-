using backend_api.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_api.Data
{
    public class AppPrincipalContext : DbContext
    {
        public AppPrincipalContext(DbContextOptions<AppPrincipalContext> options) : base(options)
        {
            
        }

        public DbSet<Patrocinador>? Patrocinadores { get; set; }

        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     builder.Entity<Patrocinador>()
        //         .HasData(new List<Patrocinador>(){
        //             new Patrocinador
        //             {
        //                FormaDeContato = "Pessoalmente",
        //                Id = 1,
        //                Nome = "Peterson",
        //                Observacoes = "Teste",
        //                Responsavel = "Peter",
        //                Resposta = "Sim",
        //                Status = "Pendente",
        //                Valor = 100
        //             }
        //         });
        // }
    }
}
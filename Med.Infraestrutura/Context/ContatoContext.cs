using Med.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Med.Infraestrutura.Context
{
    
    public class ContatoContext : DbContext
    {
        public ContatoContext(DbContextOptions<ContatoContext> options) :base(options){

        }

        public DbSet<Contato> contatos {get;set;}
    }
    
}
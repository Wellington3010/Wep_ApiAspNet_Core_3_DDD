using Med.Infraestrutura.Context;
using Med.Dominio.Entidades;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace Med.Infraestrutura.Repositorios
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly ContatoContext context;


        public ContatoRepositorio(ContatoContext ctx){
            this.context = ctx;
        } 

        
        public void Alterar(Contato contato)
        {
            context.Entry(contato).State = EntityState.Modified;
            context.SaveChanges();
        }

        public async Task<bool> ContatoExistente(int id)
        {
            return await context.contatos.AnyAsync(x => x.Id == id);
        }

        public int Excluir(int id)
        {
            var entidade = context.contatos.Where(x => x.Id == id).FirstOrDefault();
            context.contatos.Remove(entidade);
            return context.SaveChanges();
        }

        public async Task<int> Incluir(Contato contato)
        {
            context.contatos.Add(contato);
            return await context.SaveChangesAsync();
        }

        public async Task<List<Contato>> Listar()
        {
            return await context.contatos.ToListAsync();
        }

        public async Task<Contato> VisualizarDetalhes(int id)
        {
            var contato = await context.contatos.FirstOrDefaultAsync(x => x.Id == id);
            return contato;
        }


    }
}
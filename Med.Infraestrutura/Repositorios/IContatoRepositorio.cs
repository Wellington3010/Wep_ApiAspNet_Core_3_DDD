using System.Collections.Generic;
using System.Collections;
using Med.Dominio.Entidades;
using System.Threading.Tasks;

namespace Med.Infraestrutura.Repositorios
{
    public interface IContatoRepositorio
    {
         Task<int> Incluir(Contato contato);

         int Excluir(int id);

         void Alterar(Contato contato);

          Task<List<Contato>> Listar();

          Task<Contato> VisualizarDetalhes(int id);

          Task<bool> ContatoExistente (int id);
    }
}
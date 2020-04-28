using System.Text;
using System;
using System.Dynamic;
namespace Med.Aplicacao.DTO
{
    public class ContatoDTO
    {
        public int Id {get; set;}
        
        public string NomeContato {get; set;}

        public DateTime DataNascimento {get; set;}

        public string Sexo {get; set;}

        public int Idade {get; set;}

        public bool isValid() => !string.IsNullOrEmpty(NomeContato) && DataNascimento != null && !string.IsNullOrEmpty(Sexo) && Idade != 0;
    }
}
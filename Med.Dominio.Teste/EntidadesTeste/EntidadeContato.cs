using System;
namespace Med.Dominio.Teste.EntidadesTeste
{
    public class EntidadeContato
    {
        
        public EntidadeContato(int Id,string nomeContato, DateTime dataNascimento,string sexo, int idade)
        {
            this.Id = Id;
            this.NomeContato = nomeContato;
            this.DataNascimento = dataNascimento;
            this.Sexo = sexo;
            this.Idade = idade;
        }
        
        public int Id {get; private set;}
        
        public string NomeContato {get; private set;}

        public DateTime DataNascimento {get; private set;}

        public string Sexo {get; private set;}

        public int Idade {get; private set;}
    }
}
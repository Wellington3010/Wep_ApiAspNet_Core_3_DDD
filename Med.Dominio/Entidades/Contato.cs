using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
namespace Med.Dominio.Entidades
{
    [Table("contato")]
    public class Contato
    {
        public Contato(string nomeContato, DateTime dataNascimento, string sexo, int idade)
        {
            NomeContato = nomeContato;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            Idade = idade;
        }
        [Key]
        public int Id {get; private set;}

        [Required]
        public string NomeContato {get; private set;}

        [Required]
        public DateTime DataNascimento {get; private set;}

        [Required]
        public string Sexo {get; private set;}

        [Required]
        public int Idade {get; private set;}
    }
}
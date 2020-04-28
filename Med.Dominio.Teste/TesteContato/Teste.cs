using System;
using Med.Dominio.Teste.EntidadesTeste;
using Xunit;
using ExpectedObjects;

namespace Med.Dominio.Teste.TesteContato
{
    public class Teste
    {
        [Fact]
        public void DevCriarContato(){


            var contatoEsperado = new 
            {
                Id = 5,
                NomeContato = "João",
                DataNascimento = DateTime.Parse("1985-02-04T00:00:00"),
                Sexo = "M",
                Idade = 35,
            };

            var contato = new EntidadeContato(contatoEsperado.Id,contatoEsperado.NomeContato,contatoEsperado.DataNascimento,contatoEsperado.Sexo,contatoEsperado.Idade);

            contatoEsperado.ToExpectedObject().ShouldMatch(contato);
        }
    }
}
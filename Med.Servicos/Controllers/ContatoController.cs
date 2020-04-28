using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Med.Dominio.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Med.Infraestrutura.Context;
using Med.Infraestrutura.Repositorios;
using Med.Aplicacao.DTO;

namespace Med.Servicos.Controllers
{
    [ApiController]
    [Route("v1/Contatos")]
    public class ContatoController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IContatoRepositorio _icontatoRepositorio;

        public ContatoController(IMapper map, IContatoRepositorio contatoRepositorio)
        {
            this._mapper = map;
            this._icontatoRepositorio = contatoRepositorio;
        }

        [HttpGet]
        [Route("ListarContatos")]
        public async Task<List<ContatoDTO>> ListarContatos()
        {
           var contatos =  await _icontatoRepositorio.Listar();
           var contatosDTO = _mapper.Map<List<ContatoDTO>>(contatos);
           return contatosDTO;
        }


        [HttpGet]
        [Route("VisualizarDetalhes/{Id}")]
        public async Task<ContatoDTO> VisualizarDetalhes([FromRoute]int id)
        {
            try
            {
              var contato = await _icontatoRepositorio.VisualizarDetalhes(id);
              var contatoDTO = _mapper.Map<ContatoDTO>(contato);
              return contatoDTO;

            }catch{
                throw new Exception();
            }
            
        }


        [HttpPost]
        [Route("CadastrarContato")]
        public async Task<IActionResult> CadastrarContato([FromBody] ContatoDTO contatoDTO)
        {
            
            if(!contatoDTO.isValid())
                return BadRequest("Faltam dados. Favor preencha e tente novamente mais tarde.");

            var contato = _mapper.Map<Contato>(contatoDTO);

            var number = await _icontatoRepositorio.Incluir(contato);

            if(number != 0)
                return Ok("Cadastro realizado com sucesso");

                return BadRequest("Não foi possível realizar o cadastro. Favor tente novamente");
        }


        [HttpPut]
        [Route("AlterarContato")]
        public async Task<IActionResult> AlterarContato([FromBody] ContatoDTO contatoDTO)
        {

            if(!contatoDTO.isValid())
                return BadRequest("Faltam dados. Favor preencha e tente novamente mais tarde.");

            if(!await _icontatoRepositorio.ContatoExistente(contatoDTO.Id))
                return BadRequest("Contato inexistente.Alteração não permitida");

            var contato = _mapper.Map<Contato>(contatoDTO);

            try{

                _icontatoRepositorio.Alterar(contato);
                return Ok("Alteração realizada com sucesso");

            }catch{

                throw new Exception("As alterações não foram realizadas. Tente novamente mais tarde");
            }      
        }

        [HttpDelete]
        [Route("DeletarContato/{Id}")]
        public async Task<IActionResult> DeletarContato([FromRoute]int id)
        {
            if(!await _icontatoRepositorio.ContatoExistente(id))
                return BadRequest("Contato inexistente");


            int number = 0;
            try{

                 number = _icontatoRepositorio.Excluir(id);

            }catch{
            
                throw new Exception("Não foi possível realizar a exclusão");

            }

            if(number != 0)
            {
                 return Ok("Registro deletado com sucesso");
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
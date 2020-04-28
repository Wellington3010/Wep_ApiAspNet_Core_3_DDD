using Med.Dominio.Entidades;
using AutoMapper;
namespace Med.Aplicacao.DTO.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() => CreateMap<Contato,ContatoDTO>().ReverseMap();
    }
}
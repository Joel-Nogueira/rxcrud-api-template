using AutoMapper;
using RXCrud.Domain.Dto;
using RXCrud.Domain.Entities;

namespace RXCrud.Service.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Usuario, UsuarioDto>()
                .ReverseMap();
            CreateMap<Estado, EstadoDto>()
                .ReverseMap();
            CreateMap<Cidade, CidadeDto>()
                .ReverseMap();
        }
    }
}
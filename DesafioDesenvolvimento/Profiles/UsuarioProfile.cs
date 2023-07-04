using AutoMapper;
using DesafioDesenvolvimento.Data.Dtos;
using DesafioDesenvolvimento.Models;

namespace DesafioDesenvolvimento.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()

        {
            CreateMap<CreateUsuarioDto, Usuario>();        }
    }
    
}

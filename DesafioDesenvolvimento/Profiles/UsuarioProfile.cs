using AutoMapper;
using DesafioDesenvolvimento.Data.Dtos;
using DesafioDesenvolvimento.Models;

namespace DesafioDesenvolvimento.Profiles
{
   
        public class UsuariProfile : Profile
        {
            public UsuariProfile()
            {
                CreateMap<CreateUsuarioDto, Usuario>();

            }
        }
}

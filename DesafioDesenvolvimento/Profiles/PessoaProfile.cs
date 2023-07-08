using AutoMapper;
using DesafioDesenvolvimento.Data.Dtos;
using DesafioDesenvolvimento.Models;

namespace DesafioDesenvolvimento.Profiles;

public class PessoaProfile : Profile
{
    public PessoaProfile()
    {
        CreateMap<CreatePessoaDto, Pessoa>();
        CreateMap<UpdatePessoaDto, Pessoa>();
        CreateMap<Pessoa, UpdatePessoaDto>();
        CreateMap<Pessoa, ReadPessoaDto>();

    }



}


using AutoMapper;
using DesafioDesenvolvimento.Data.Dtos;
using DesafioDesenvolvimento.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DesafioDesenvolvimento.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsuariosController : ControllerBase
{
    private IMapper _mapper;
    private UserManager<Usuario> _userManager;

    public UsuariosController(IMapper mapper, UserManager<Usuario> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> CadastroUsuario(CreateUsuarioDto dto)

    {
        Usuario usuario = _mapper.Map<Usuario>(dto);
        IdentityResult resultado = await _userManager.CreateAsync(usuario, dto.Password);

        if (resultado.Succeeded) return Ok("Usuario cadastrado");

        throw new ApplicationException("Falha ao cadastrar usuario");
    }




}

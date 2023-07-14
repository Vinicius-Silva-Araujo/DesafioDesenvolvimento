using DesafioDesenvolvimento.Models;
using DesafioDesenvolvimento.Repositorios;
using DesafioDesenvolvimento.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioDesenvolvimento.Controllers
{
    public class LoginController : ControllerBase
    {
        // Chamada para autenticar
        [HttpPost]
        [Route("api/login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Autenticar([FromBody] User model)
        {
            // Recupera o usuário
            var user = UserRepositorios.Get(model.Name, model.Password);

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = TokenService.GenerationToken(user);

            // Oculta a senha
            user.Password = "";

            // Retorna os dados
            return new
            {
                token = token
            };
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioDesenvolvimento.Controllers
{
    public class UserController : ControllerBase 
    {
        [HttpGet]
        [Route("api/anonimo")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("api/usuario")]
        [Authorize(Roles = "usuario,admin")]
        public string Employee() => "usuario";

        [HttpGet]
        [Route("api/admin")]
        [Authorize(Roles = "admin")]
        public string Manager() => "admin";

    }
}

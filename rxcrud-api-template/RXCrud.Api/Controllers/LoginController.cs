using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RXCrud.Api.Security;
using RXCrud.Domain.Dto;
using RXCrud.Domain.Exception;
using RXCrud.Domain.Interfaces.Services;

namespace RXCrud.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public LoginController(IUsuarioService usuarioService)
            => _usuarioService = usuarioService;

        /// <summary>
        /// Autenticar usuário
        /// </summary>
        /// <param name="login"></param>
        /// <response code="200">Usuário autenticado.</response>
        /// <response code="400">Usuário não autenticado.</response>
        [HttpPost]
        [AllowAnonymous]
        [Route("Authenticate")]
        [ProducesResponseType(typeof(TokenDto), 200)]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult AuthenticaterxcrudUser([FromBody] LoginDto login)
            => Ok(new TokenDto(AccessToken.GenerateToken(_usuarioService.PesquisarPorNomeAcessoSenha(login.Usuario, login.Senha))));

        /// <summary>
        /// Verificar o usuário autenticado.
        /// </summary>
        /// <response code="200">Usuário autenticado.</response>
        /// <response code="400">Usuário não autenticado.</response>
        /// <response code="401">Acesso não autorizado.</response>
        [HttpGet]
        [Authorize]
        [Route("Authenticated")]
        [ProducesResponseType(typeof(ExceptionMessage), 200)]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult Authenticated()
            => Ok(new ExceptionMessage(string.Format("Usuário autenticado - {0}", User.Identity.Name)));
    }
}
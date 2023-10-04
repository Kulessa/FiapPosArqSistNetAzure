using FiapStore.DTOs;
using FiapStore.Interfaces;
using FiapStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Controllers
{
    [ApiController, Route("login")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly ITokenService tokenService;

        public LoginController(IUsuarioRepository usuarioRepository, ITokenService tokenService)
        {
            this.usuarioRepository = usuarioRepository;
            this.tokenService = tokenService;
        }
        [HttpPost]
        public IActionResult Autenticar([FromBody] LoginDTO loginDTO)
        {
            var usuario = usuarioRepository.ObterPorNomeUsuarioSenha(loginDTO.NomeUsuario, loginDTO.Senha);
            if (usuario == null)
            {
                return NotFound(new { Mensagem = "Usuario ou senha inválidos" });
            }
            var token = tokenService.GerarToken(usuario);
            usuario.Senha = string.Empty;
            return Ok(new
            {
                Usuario = usuario,
                Token = token
            });
        }
    }
}

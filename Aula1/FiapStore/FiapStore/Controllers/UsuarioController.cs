using FiapStore.Entities;
using FiapStore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Controllers
{
    [ApiController, Route("Usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }
        [HttpGet, Route("obter-todos-usuario")]
        public IActionResult ObterTodosUsuarios()
        {
            return Ok(usuarioRepository.ObterTodosUsuarios());
        }
        [HttpGet, Route("obter-por-usuario-id/{id}")]
        public IActionResult ObterPorUsuarioId(int id)
        {
            return Ok(usuarioRepository.ObterPorUsuarioId(id));
        }
        [HttpPost]
        public IActionResult CadastrarUsuario(Usuario usuario)
        {
            usuarioRepository.CadastrarUsuario(usuario);
            return Ok("Usuário criado com sucesso!");
        }
        [HttpPut]
        public IActionResult AlterarUsuario(Usuario usuario)
        {
            usuarioRepository.AlterarUsuario(usuario);
            return Ok("Usuário alterado com sucesso!");
        }
        [HttpDelete("{id}")]
        public IActionResult RemoverUsuario(int id)
        {
            usuarioRepository.RemoverUsuario(id);
            return Ok("Usuário deletado com sucesso!");
        }
    }
}

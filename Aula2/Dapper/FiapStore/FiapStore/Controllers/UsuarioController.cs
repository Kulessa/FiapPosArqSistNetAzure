using FiapStore.DTOs;
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
        [HttpGet, Route("obter-com-pedidos/{id}")]
        public IActionResult ObterComPedidos(int id)
        {
            return Ok(usuarioRepository.ObterComPedidos(id));
        }
        [HttpGet, Route("obter-todos-usuario")]
        public IActionResult ObterTodosUsuarios()
        {
            return Ok(usuarioRepository.ObterTodos());
        }
        [HttpGet, Route("obter-por-usuario-id/{id}")]
        public IActionResult ObterPorUsuarioId(int id)
        {
            return Ok(usuarioRepository.ObterPorId(id));
        }
        [HttpPost]
        public IActionResult CadastrarUsuario(CadastrarUsuarioDTO usuario)
        {
            usuarioRepository.Cadastrar(new(usuario));
            return Ok("Usuário criado com sucesso!");
        }
        [HttpPut]
        public IActionResult AlterarUsuario(AlterarUsuarioDTO usuario)
        {
            usuarioRepository.Alterar(new(usuario));
            return Ok("Usuário alterado com sucesso!");
        }
        [HttpDelete("{id}")]
        public IActionResult RemoverUsuario(int id)
        {
            usuarioRepository.Deletar(id);
            return Ok("Usuário deletado com sucesso!");
        }
    }
}

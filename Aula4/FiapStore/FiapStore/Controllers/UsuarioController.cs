using FiapStore.DTOs;
using FiapStore.Enums;
using FiapStore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Controllers
{
    [ApiController, Route("Usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly ILogger<UsuarioController> logger;

        public UsuarioController(
            IUsuarioRepository usuarioRepository,
            ILogger<UsuarioController> logger)
        {
            this.usuarioRepository = usuarioRepository;
            this.logger = logger;
        }
        [Authorize, HttpGet, Route("obter-com-pedidos/{id}")]
        public IActionResult ObterComPedidos(int id)
        {
            return Ok(usuarioRepository.ObterComPedidos(id));
        }
        [Authorize(Roles = Permissoes.Administrador), HttpGet, Route("obter-todos-usuario")]
        public IActionResult ObterTodosUsuarios()
        {
            try
            {
                //throw new Exception("Erro forçado para testar log");
                return Ok(usuarioRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Erro forçado: {ex.Message}");
                return BadRequest("Erro forçado log");
            }
        }
        [Authorize(Roles = Permissoes.Funcionario), HttpGet, Route("obter-por-usuario-id/{id}")]
        public IActionResult ObterPorUsuarioId(int id)
        {
            logger.LogInformation("Executando método ObterPorUsuarioId");
            return Ok(usuarioRepository.ObterPorId(id));
        }
        [Authorize(Roles = $"{Permissoes.Administrador},{Permissoes.Funcionario}"), HttpPost]
        public IActionResult CadastrarUsuario(CadastrarUsuarioDTO usuario)
        {
            logger.LogInformation("Executando método CadastrarUsuario");
            usuarioRepository.Cadastrar(new(usuario));
            string mensagem = $"Usuário cadastrado com sucesso! | Nome: {usuario.Nome}";
            logger.LogInformation(mensagem);
            return Ok(mensagem);
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

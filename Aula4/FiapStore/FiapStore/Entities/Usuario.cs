using FiapStore.DTOs;
using FiapStore.Enums;

namespace FiapStore.Entities
{
    public class Usuario : Entity
    {
        public Usuario() { }
        public Usuario(CadastrarUsuarioDTO usuarioDTO)
        {
            Nome = usuarioDTO.Nome;
            NomeUsuario = usuarioDTO.NomeUsuario;
            Senha = usuarioDTO.Senha;
            Permissao = usuarioDTO.Permissao;
        }
        public Usuario(AlterarUsuarioDTO usuarioDTO)
        {
            Id = usuarioDTO.Id;
            Nome = usuarioDTO.Nome;
        }
        public string Nome { get; set; } = string.Empty;
        public string NomeUsuario { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public TipoPermissao Permissao { get; set; } = TipoPermissao.Funcionario;
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
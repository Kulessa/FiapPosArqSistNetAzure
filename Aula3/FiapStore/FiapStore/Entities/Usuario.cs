using FiapStore.DTOs;

namespace FiapStore.Entities
{
    public class Usuario : Entity
    {
        public Usuario() { }
        public Usuario(CadastrarUsuarioDTO usuarioDTO)
        {
            Nome = usuarioDTO.Nome;
        }
        public Usuario(AlterarUsuarioDTO usuarioDTO)
        {
            Id = usuarioDTO.Id;
            Nome = usuarioDTO.Nome;
        }
        public string Nome { get; set; } = string.Empty;
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
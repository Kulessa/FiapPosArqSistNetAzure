using FiapStoreMinimalApi.Entities;

namespace FiapStoreMinimalApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IList<Usuario> usuarios = new List<Usuario>();

        public IList<Usuario> ObterTodosUsuarios()
        {
            return usuarios;
        }

        public Usuario? ObterPorUsuarioId(int id)
        {
            return usuarios.FirstOrDefault(usuario => usuario.Id == id);
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        public void AlterarUsuario(Usuario usuario)
        {
            Usuario? usuarioAlterar = ObterPorUsuarioId(usuario.Id);
            if (usuarioAlterar != null)
            {
                usuarioAlterar.Nome = usuario.Nome;
            }
        }

        public void RemoverUsuario(int id)
        {
            Usuario? usuarioDeletar = ObterPorUsuarioId(id);
            if (usuarioDeletar != null)
            {
                usuarios.Remove(usuarioDeletar);
            }
        }
    }
}

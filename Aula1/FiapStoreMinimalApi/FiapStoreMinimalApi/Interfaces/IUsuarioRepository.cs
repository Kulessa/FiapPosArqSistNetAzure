using FiapStoreMinimalApi.Entities;

internal interface IUsuarioRepository
{
    IList<Usuario> ObterTodosUsuarios();
    Usuario? ObterPorUsuarioId(int id);
    void CadastrarUsuario(Usuario usuario);
    void AlterarUsuario(Usuario usuario);
    void RemoverUsuario(int id);
}
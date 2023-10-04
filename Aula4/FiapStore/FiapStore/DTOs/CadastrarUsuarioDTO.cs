using FiapStore.Enums;

namespace FiapStore.DTOs
{
    public class CadastrarUsuarioDTO
    {
        public string Nome { get; set; } = string.Empty;
        public string NomeUsuario { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public TipoPermissao Permissao { get; set; } = TipoPermissao.Funcionario;
    }
}

namespace FiapStore.Entities
{
    public class Pedido : Entity
    {
        public int UsuarioId { get; set; }
        public string NomeProduto { get; set; } = string.Empty;
    }
}

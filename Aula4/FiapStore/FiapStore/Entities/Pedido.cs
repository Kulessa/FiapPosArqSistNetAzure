namespace FiapStore.Entities
{
    public class Pedido : Entity
    {
        public Pedido()
        {

        }
        public Pedido(Pedido pedido)
        {
            NomeProduto = pedido.NomeProduto;
            UsuarioId = pedido.UsuarioId;
            PrecoTotal = pedido.PrecoTotal;
        }
        public int UsuarioId { get; set; }
        public string NomeProduto { get; set; } = string.Empty;
        public Usuario Usuario { get; set; } = new Usuario();
        public decimal PrecoTotal { get; set; }
    }
}

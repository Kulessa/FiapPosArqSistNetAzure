using FiapStore.Entities;
using FiapStore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiapStore.Repositories
{
    public class UsuarioRepository : EFRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Usuario? ObterComPedidos(int id)
        {
            return context.Usuario
                .Include(u => u.Pedidos)
                .FirstOrDefault(u => u.Id == id);
            /*
            return context.Usuario
                .Include(u => u.Pedidos)
                .Where(u => u.Id == id)
                .ToList()
                .Select(u =>
                {
                    u.Pedidos = u.Pedidos.Select(p => new Pedido(p)).ToList();
                    return u;
                }).FirstOrDefault();
            */
        }

        public Usuario? ObterPorNomeUsuarioSenha(string nomeUsuario, string senha)
        {
            return context.Usuario
                .FirstOrDefault(u => u.NomeUsuario == nomeUsuario && u.Senha == senha);
        }
    }
}

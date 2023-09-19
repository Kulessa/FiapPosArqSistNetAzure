using FiapStore.Entities;
using FiapStore.Interfaces;

namespace FiapStore.Repositories
{
    public abstract class DapperRepository<T> : IRepository<T> where T : Entity
    {
        private readonly string connectionString;
        protected string ConnectionString => connectionString;
        public DapperRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("ConnectionStrings:ConnectionString") ?? string.Empty;
        }
        public abstract void Alterar(T entidade);
        public abstract void Cadastrar(T entidade);
        public abstract void Deletar(int id);
        public abstract T? ObterPorId(int id);
        public abstract IList<T> ObterTodos();
    }
}

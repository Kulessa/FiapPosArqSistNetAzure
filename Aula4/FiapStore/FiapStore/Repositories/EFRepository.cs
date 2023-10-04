using FiapStore.Entities;
using FiapStore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiapStore.Repositories
{
    public class EFRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly ApplicationDbContext context;
        private readonly DbSet<T> dbSet;

        public EFRepository(ApplicationDbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
        public void Alterar(T entidade)
        {
            dbSet.Update(entidade);
            context.SaveChanges();
        }

        public void Cadastrar(T entidade)
        {
            dbSet.Add(entidade);
            context.SaveChanges();
        }

        public void Deletar(int id)
        {
            T? item = ObterPorId(id);
            if (item == null)
            {
                return;
            }
            dbSet.Remove(item);
            context.SaveChanges();
        }

        public T? ObterPorId(int id)
        {
            return dbSet.Find(id);
        }

        public IList<T> ObterTodos()
        {
            return dbSet.ToList();
        }
    }
}

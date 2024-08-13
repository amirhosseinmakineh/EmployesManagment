using EmployeeManagment.Domain.IRpositories;
using EmployeeManagment.Domain.Models;
using EployeeManagemnt.InfraStracture.Context;

namespace EployeeManagemnt.InfraStracture.Repositories
{
    public class BaseRepository<Tkey, TEntity> : IRepository<Tkey,TEntity> where Tkey : struct where TEntity : BaseEntity<Tkey>
    {
        private readonly EmployeeManagmentContext context;

        public BaseRepository(EmployeeManagmentContext context)
        {
            this.context = context;
        }

        public void Add(TEntity tentity)
        {
            context.Set<TEntity>().Add(tentity);
        }

        public void Delete(Tkey tkey)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            return context.Set<TEntity>();
        }

        public TEntity GetById(Tkey Tkey)
        {
            return context.Set<TEntity>().Find(Tkey);
        }
        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public void Update(TEntity tentity)
        {
            context.Set<TEntity>().Update(tentity);
        }
    }
}

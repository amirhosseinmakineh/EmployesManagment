using EmployeeManagment.Domain.Models;

namespace EmployeeManagment.Domain.IRpositories
{
    public interface IRepository<Tkey, Tentity> where Tkey : struct where Tentity : BaseEntity<Tkey>
    {
        IQueryable<Tentity> GetAll();
        void Add(Tentity tentity);
        void Update(Tentity tentity);
        void Delete(Tkey tkey);
        Tentity GetById(Tkey Tkey);
        int SaveChanges();
    }
}

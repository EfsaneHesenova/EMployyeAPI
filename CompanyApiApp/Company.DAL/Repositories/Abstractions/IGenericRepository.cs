using Company.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DAL.Repositories.Abstractions
{
    public interface IGenericRepository<Tentity> where Tentity : BaseEntity , new()
    {
        Task<ICollection<Tentity>> GetAllAsync();
        Task<Tentity> CreateAsync(Tentity entity);
        Task<Tentity> GetByIdAsync(int id);
        void Update(Tentity entity);
        void Delete(Tentity entity);
        Task<int> SaveChangesAsync();
    }
}

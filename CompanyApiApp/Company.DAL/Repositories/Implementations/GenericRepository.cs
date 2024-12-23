using Company.Core.Entities.Base;
using Company.DAL.DAL;
using Company.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DAL.Repositories.Implementations
{
    public class GenericRepository<Tentity> : IGenericRepository<Tentity> where Tentity : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        DbSet<Tentity> table => _context.Set<Tentity>();
        public async Task<Tentity> CreateAsync(Tentity entity)
        {
           await table.AddAsync(entity);
           return entity;
        }

        public void Delete(Tentity entity)
        {
            table.Remove(entity);
        }

        public async Task<ICollection<Tentity>> GetAllAsync()
        {
           return await table.Where(x=>!x.IsDeleted).ToListAsync();
        }

        public async Task<Tentity> GetByIdAsync(int id)
        {
             var entity = await table.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
            _context.Entry(entity).State = EntityState.Detached;
             return entity;
        }

        public async Task<bool> IsExistAsync(int id)
        {
          return await table.AnyAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void SoftDelete(Tentity entity)
        {
           entity.IsDeleted = true;
        }

        public void Update(Tentity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}

using Company.Core.Entities;
using Company.DAL.DAL;
using Company.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DAL.Repositories.Implementations
{
    public class DepartrmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartrmentRepository(AppDbContext context) : base(context)
        {
        }
    }
}

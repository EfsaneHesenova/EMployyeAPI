using Company.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DAL.Repositories.Abstractions
{
    public interface IEmployeeRepository: IGenericRepository<Employee>
    {
    }
}

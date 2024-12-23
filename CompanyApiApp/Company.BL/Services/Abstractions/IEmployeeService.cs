using Company.BL.DTOs.DepartmentDtos;
using Company.BL.DTOs.EmployeeDtos;
using Company.Core.Entities;
using Company.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BL.Services.Abstractions
{
    public interface IEmployeeService
    {
        Task<ICollection<Employee>> GetAllAsync();
        Task<Employee> CreateAsync(EmployeeCreateDto entityDto);
        Task<Employee> GetByIdAsync(int id);
        Task<bool> SoftDeleteAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(int id, EmployeeUpdateDto entityDto);
    }
}

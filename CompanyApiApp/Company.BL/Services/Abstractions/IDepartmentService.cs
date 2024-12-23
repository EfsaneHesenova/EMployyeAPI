using Company.BL.DTOs.DepartmentDtos;
using Company.Core.Entities;
using Company.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BL.Services.Abstractions
{
    public interface IDepartmentService
    {
        Task<ICollection<Department>> GetAllAsync();
        Task<Department> CreateAsync(DepartmentCreateDto entityDto);
        Task<Department> GetByIdAsync(int id);
        Task<bool> SoftDeleteAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(int id, DepartmentUpdateDto entityDto);
    }
}

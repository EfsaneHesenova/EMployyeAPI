using Company.BL.DTOs.DepartmentDtos;
using Company.BL.Services.Abstractions;
using Company.Core.Entities;
using Company.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BL.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepo;

        public DepartmentService(IDepartmentRepository departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }

        public async Task<ICollection<Department>> GetAllAsync()
        {
            return  await _departmentRepo.GetAllAsync();
        }
        public  async Task<Department> CreateAsync(DepartmentCreateDto entityDto)
        {
            Department department = new Department();
            department.Title = entityDto.Title;
            department.Description = entityDto.Description;
            department.CreatetdAt = DateTime.Now;
            department.CreatedBy = "Efsane";
            var createdEntity = await _departmentRepo.CreateAsync(department);
            _departmentRepo.SaveChangesAsync();
            return createdEntity;
        }
    }
}

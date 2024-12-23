using AutoMapper;
using Company.BL.DTOs.DepartmentDtos;
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
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository departmentRepo, IMapper mapper)
        {
            _departmentRepo = departmentRepo;
            _mapper = mapper;
        }

        public async Task<Department> CreateAsync(DepartmentCreateDto entityDto)
        {
            Department createdDepartment = _mapper.Map<Department>(entityDto);
            createdDepartment.CreatetdAt = DateTime.Now;
            var createdEntity = await _departmentRepo.CreateAsync(createdDepartment);
            await _departmentRepo.SaveChangesAsync();
            return createdDepartment;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                Department department = await GetByIdAsync(id);

                _departmentRepo.Delete(department);
                return true;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<ICollection<Department>> GetAllAsync()
        {
            return await _departmentRepo.GetAllAsync();
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            if (!await _departmentRepo.IsExistAsync(id))
            {
                throw new Exception();
            }
            return await _departmentRepo.GetByIdAsync(id);
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var employeeEntity = await GetByIdAsync(id);
            _departmentRepo.SoftDelete(employeeEntity);
            await _departmentRepo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(int id, DepartmentUpdateDto entityDto)
        {
            var departmentEntity = await GetByIdAsync(id);
            _departmentRepo.Update(departmentEntity);
            Department updatedDepartment = _mapper.Map<Department>(entityDto);
            updatedDepartment.UpdatedtAt = DateTime.UtcNow.AddHours(4);
            updatedDepartment.Id = id;
            await _departmentRepo.SaveChangesAsync();
            return true;
        }
    }
}

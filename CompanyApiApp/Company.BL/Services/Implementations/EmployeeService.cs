using AutoMapper;
using Company.BL.DTOs.DepartmentDtos;
using Company.BL.DTOs.EmployeeDtos;
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
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepo, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
        }

        public async Task<Employee> CreateAsync(EmployeeCreateDto entityDto)
        {
            Employee createdEmployee = _mapper.Map<Employee>(entityDto);
            createdEmployee.CreatetdAt = DateTime.Now;
            var createdEntity = await _employeeRepo.CreateAsync(createdEmployee);
            await _employeeRepo.SaveChangesAsync();
            return createdEmployee;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                Employee employee = await GetByIdAsync(id);

                _employeeRepo.Delete(employee);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<ICollection<Employee>> GetAllAsync()
        {
           return await _employeeRepo.GetAllAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            if (!await _employeeRepo.IsExistAsync(id))
            {
                throw new Exception();
            }
            return await _employeeRepo.GetByIdAsync(id);
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var employeeEntity = await GetByIdAsync(id);
            _employeeRepo.SoftDelete(employeeEntity);
            await _employeeRepo.SaveChangesAsync();
            return true;
        }


        public async Task<bool> UpdateAsync(int id, EmployeeUpdateDto entityDto)
        {
            var employeeEntity = await _employeeRepo.GetByIdAsync(id);
            _employeeRepo.Update(employeeEntity);
            Employee updatedEmployee = _mapper.Map<Employee>(entityDto);
            updatedEmployee.UpdatedtAt = DateTime.UtcNow.AddHours(4);
            updatedEmployee.Id = id;
            await _employeeRepo.SaveChangesAsync();
            return true;
        }

    }
}

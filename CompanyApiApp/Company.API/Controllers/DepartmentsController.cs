using Company.BL.DTOs.DepartmentDtos;
using Company.BL.Services.Abstractions;
using Company.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService department)
        {
            _departmentService = department;
        }

        [HttpGet]
        public async Task<ICollection<Department>> GetAllAsync()
        {
            return await _departmentService.GetAllAsync();
        }
        [HttpPost]
        public async Task<Department> Create(DepartmentCreateDto createDto)
        {
           return await _departmentService.CreateAsync(createDto);
        }
    }
}

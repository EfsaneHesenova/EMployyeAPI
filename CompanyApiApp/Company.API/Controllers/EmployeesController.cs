using Company.BL.DTOs.EmployeeDtos;
using Company.BL.Services.Abstractions;
using Company.Core.Entities;
using Company.DAL.DAL;
using Company.DAL.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ICollection<Employee>> GetAllAsync()
        {
            return await _employeeService.GetAllAsync();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAsync(EmployeeCreateDto employeeCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            return StatusCode(StatusCodes.Status201Created, await _employeeService.CreateAsync(employeeCreateDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdASync(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _employeeService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _employeeService.SoftDeleteAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpPut("updatebook/{id}")]
        public async Task<IActionResult> UpdateASync(int id, EmployeeUpdateDto employeeUpdateDto)
        {
            if(!ModelState.IsValid)
            {
                StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }

            try
            {
                return StatusCode(StatusCodes.Status200OK, await _employeeService.UpdateAsync(id, employeeUpdateDto));
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

    }
}

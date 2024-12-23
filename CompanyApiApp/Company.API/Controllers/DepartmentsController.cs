using AutoMapper;
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

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var departments = await _departmentService.GetAllAsync();
                return Ok(departments);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var department = await _departmentService.GetByIdAsync(id);
                if (department == null)
                {
                    return NotFound($"Department with ID {id} not found.");
                }
                return Ok(department);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DepartmentCreateDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdDepartment = await _departmentService.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetByIdAsync), new { id = createdDepartment.Id }, createdDepartment);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DepartmentUpdateDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var exists = await _departmentService.GetByIdAsync(id);
                if (exists == null)
                {
                    return NotFound($"Department with ID {id} not found.");
                }

                var updated = await _departmentService.UpdateAsync(id, updateDto);
                return Ok($"Department with ID {id} updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var exists = await _departmentService.GetByIdAsync(id);
                if (exists == null)
                {
                    return NotFound($"Department with ID {id} not found.");
                }

                var deleted = await _departmentService.DeleteAsync(id);
                if (deleted)
                {
                    return Ok($"Department with ID {id} deleted successfully.");
                }

                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete department.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPatch("{id}/soft-delete")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            try
            {
                var exists = await _departmentService.GetByIdAsync(id);
                if (exists == null)
                {
                    return NotFound($"Department with ID {id} not found.");
                }

                var softDeleted = await _departmentService.SoftDeleteAsync(id);
                if (softDeleted)
                {
                    return Ok($"Department with ID {id} soft-deleted successfully.");
                }

                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to soft-delete department.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
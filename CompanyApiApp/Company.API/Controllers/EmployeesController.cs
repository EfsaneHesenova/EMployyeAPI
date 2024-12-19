using Company.Core.Entities;
using Company.DAL.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public List<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }
    }
}

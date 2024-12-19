using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BL.DTOs.DepartmentDtos
{
    public record DepartmentCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

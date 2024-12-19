using Company.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Entities
{
    public class Employee: BaseAuditableEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}

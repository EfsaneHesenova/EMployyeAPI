using Company.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Entities
{
    public class Department: BaseAuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}

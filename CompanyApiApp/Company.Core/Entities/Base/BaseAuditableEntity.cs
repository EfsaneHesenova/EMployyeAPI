using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Entities.Base
{
    public class BaseAuditableEntity: BaseEntity
    {
        public DateTime CreatetdAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedtAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? DeletedBy { get; set; }

    }
}

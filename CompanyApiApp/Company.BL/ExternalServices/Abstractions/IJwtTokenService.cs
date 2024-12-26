using Company.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BL.ExternalServices.Abstractions;

public interface IJwtTokenService
{
    string GenerateToken(AppUser user);
}
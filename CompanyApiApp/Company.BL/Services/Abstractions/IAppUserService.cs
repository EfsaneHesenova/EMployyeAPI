using Company.BL.DTOs.AppUserDtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BL.Services.Abstractions
{
    public interface IAppUserService
    {
        Task<bool> RegisterAppUserAsync(RegisterDto registerDto, IUrlHelper urlHelper);
        Task<bool> LoginAppUserAsync(LoginDto loginDto);
        Task<bool> LogoutAppUserAsync();
        Task<bool> ConfirmEmailAsync(string userId, string token);
        List<AppUserReadDto> GetAllUsers();
        Task<AppUserReadDto> GetOneUser(string userId);
    }
}

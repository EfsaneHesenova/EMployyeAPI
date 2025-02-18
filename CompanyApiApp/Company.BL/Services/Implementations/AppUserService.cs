﻿using AutoMapper;
using Company.BL.DTOs.AppUserDtos;
using Company.BL.Exceptions.CommonExceptions;
using Company.BL.ExternalServices.Abstractions;
using Company.BL.Services.Abstractions;
using Company.Core.Entities;
using Company.DAL.Enums;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BL.Services.Implementations
{
    public class AppUserService : IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AppUserService(UserManager<AppUser> userManager, IMapper mapper, SignInManager<AppUser> signInManager, IEmailService emailService, IJwtTokenService jwtTokenService, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _emailService = emailService;
            _jwtTokenService = jwtTokenService;
            _roleManager = roleManager;
        }


        public async Task<bool> ConfirmEmailAsync(string userId, string token)
        {
           AppUser? appUser = await _userManager.FindByIdAsync(userId);
            if (appUser == null)
            {
                return false;
            }
            var result = await _userManager.ConfirmEmailAsync(appUser, token);
            return result.Succeeded;
        }

        public async Task CreateRoleAsync()
        {
            await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
            await _roleManager.CreateAsync(new IdentityRole { Name = "Manager" });
            await _roleManager.CreateAsync(new IdentityRole { Name = "User" });
        }

        public List<AppUserReadDto> GetAllUsers()
        {
            var users = _userManager.Users.ToList();
            var result = _mapper.Map<List<AppUserReadDto>>(users);
            return result;
        }

        public async Task<AppUserReadDto> GetOneUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception();
            }
            var result = _mapper.Map<AppUserReadDto>(user);
            return result;
        }

        public async Task<string> LoginAppUserAsync(LoginDto loginDto)
        {
            AppUser? user = await _userManager.FindByEmailAsync(loginDto.UserNameOrEmail);
            if (user == null)
            {
                user = await _userManager.FindByNameAsync(loginDto.UserNameOrEmail);
                if(user == null)
                {
                    throw new Exception();
                }
            }
            bool result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!result) { throw new Exception("Username or password is wrong"); }
            string token = _jwtTokenService.GenerateToken(user);
            return token;
        }


        public async Task<bool> LogoutAppUserAsync()
        {
            await _signInManager.SignOutAsync();
            return true;
        }

        public async Task<bool> RegisterAppUserAsync(RegisterDto registerDto, IUrlHelper urlHelper)
        {
            AppUser appUser = _mapper.Map<AppUser>(registerDto);
            var result = await _userManager.CreateAsync(appUser, registerDto.Password);
            if (!result.Succeeded)
            {
                throw new Exception();
            }
            _emailService.SendWelcomeEmail(appUser.Email);
            string userToken = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
            string? url = urlHelper.Action(
                action: "ConfirmEmail",
                controller: "Accounts",
                values: new { userId = appUser.Id, token = userToken },
                protocol: "https"
                );
            _emailService.SendConfirmEmail(userToken, url);
            return true;
        }
    }
}

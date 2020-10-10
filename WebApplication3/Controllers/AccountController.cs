using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.DTOs;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class AccountController:BaseAPIController
    {
       
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public AccountController(DataContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDTO registerdto)
        {
            using var hmac = new HMACSHA512();
            var user = new AppUser
            {
                UserName = registerdto.UserName.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerdto.Password)),
               //PasswordSalt == hmac.Key
            };
            if (await UserExists(registerdto.UserName)) { return BadRequest("UserName is taken"); }
            {
                _context.AppUser.Add(user);
                await _context.SaveChangesAsync();
                return new UserDto { Username=user.UserName,Token=_tokenService.CreateToken(user)};
            }
           
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>>Login([FromBody]LoginDto loginDto) 
        {
            var user = await _context.AppUser.SingleOrDefaultAsync(x => x.UserName == loginDto.Username);
            if (user == null) { return Unauthorized("Invalid Username"); }
            //var password= await _context.AppUser.SingleOrDefaultAsync(x => x.PasswordHash == loginDto.Password);
            return new UserDto { Username = user.UserName, Token = _tokenService.CreateToken(user) };
        }
        private async Task<bool> UserExists(string username)
        {
            return await _context.AppUser.AnyAsync(i =>i.UserName == username.ToLower());
        }

    }
}

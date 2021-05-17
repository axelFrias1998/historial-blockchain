using Microsoft.AspNetCore.Mvc;
using historial_blockchain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using historial_blockchain.Models.DTOs;
using historial_blockchain.Entities;

namespace historial_blockchain.Contexts
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AccountsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            this.context = context;
        }

        [Authorize(Roles = "SysAdmin,PacsAdmin,ClinicAdmin")]
        [AllowAnonymous]
        [HttpGet("GetAccountInfo/{id}")]
        public async Task<ActionResult<ApplicationUser>> GetAccountInfo(string id)
        {
            var account = await _userManager.FindByIdAsync(id); 
            if(account is null)
                return NotFound();
            return account;
        }

        [AllowAnonymous]
        [HttpPost("CreateAccount")]
        public async Task<ActionResult<UserToken>> CreateAccount([FromBody] UserInfo userInfo)
        {
            var user = new ApplicationUser {
                Apellido = userInfo.Apellido,
                Email = userInfo.Email, 
                Nombre = userInfo.Nombre,
                PhoneNumber = userInfo.PhoneNumber,
                UserName = userInfo.UserName, 
            };
            var result = await _userManager.CreateAsync(user, userInfo.Password);
            if(result.Succeeded)
            {
                var userData = await _userManager.FindByEmailAsync(userInfo.Email);
                await _userManager.AddClaimAsync(userData, new Claim(ClaimTypes.Role, "SysAdmin"));
                await _userManager.AddToRoleAsync(userData, "SysAdmin");
                
                var roles = await _userManager.GetRolesAsync(userData);
                return BuildToken(
                    new UserLogin {
                        Username = userInfo.UserName,
                        Password = userInfo.Password
                    }, 
                    roles,
                    userData.Id);
            }
            return BadRequest("Datos incorrectos");
        }

        [Authorize(Roles = "SysAdmin")]
        [HttpPost("CreateAdmin/{type}")]
        public async Task<IActionResult> CreateAdminAccount([FromBody] UserInfo userInfo, bool type)
        {
            var user = new ApplicationUser { 
                Apellido = userInfo.Apellido,
                Email = userInfo.Email, 
                Nombre = userInfo.Nombre,
                PhoneNumber = userInfo.PhoneNumber,
                UserName = userInfo.UserName, 
            };
            var result = await _userManager.CreateAsync(user, userInfo.Password);
            if(result.Succeeded)
            {
                var userData = await _userManager.FindByEmailAsync(userInfo.Email);
                string roleName = (type) ? "ClinicAdmin" : "PacsAdmin";
                if(type)
                {
                    await _userManager.AddClaimAsync(userData, new Claim(ClaimTypes.Role, "Doctor"));
                    await _userManager.AddToRoleAsync(userData, "Doctor");
                }
                await _userManager.AddClaimAsync(userData, new Claim(ClaimTypes.Role, roleName));
                await _userManager.AddToRoleAsync(userData, roleName);
                return new CreatedAtActionResult("GetAccountInfo/{id}", "Accounts", new { id = userData.Id }, userData);
            }
            return BadRequest("Datos incorrectos");
        }

        [Authorize(Roles = "PacsAdmin,ClinicAdmin")]
        [HttpPost("CreateDoctor")]
        public async Task<ActionResult> CreateDoctorAccount([FromBody] UserInfo userInfo)
        {
            var user = new ApplicationUser { 
                Apellido = userInfo.Apellido,
                Email = userInfo.Email, 
                Nombre = userInfo.Nombre,
                PhoneNumber = userInfo.PhoneNumber,
                UserName = userInfo.UserName, 
            };
            var result = await _userManager.CreateAsync(user, userInfo.Password);
            if(result.Succeeded)
            {
                var userData = await _userManager.FindByEmailAsync(userInfo.Email);
                await _userManager.AddClaimAsync(userData, new Claim(ClaimTypes.Role, "Doctor"));
                await _userManager.AddToRoleAsync(userData, "Doctor");
                return new CreatedAtActionResult("GetAccountInfo", "Accounts", new { id = userData.Id }, userData);
            }
            return BadRequest("Datos incorrectos");
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] UserLogin userLogin)
        {
            var result = await _signInManager.PasswordSignInAsync(userLogin.Username, userLogin.Password, isPersistent: true, lockoutOnFailure: false);
            if(result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(userLogin.Username);
                var roles = await _userManager.GetRolesAsync(user);
                return BuildToken(userLogin, roles, user.Id);
            }
            ModelState.AddModelError(string.Empty, "Ingreso fallido");
            return BadRequest(ModelState);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SysAdmin,PacsAdmin,ClinicAdmin")]
        [HttpDelete("DeleteDoctor")]
        public async Task<ActionResult<UserToken>> DeleteDoctor([FromBody] UserLogin userLogin)
        {
            var result = await _signInManager.PasswordSignInAsync(userLogin.Username, userLogin.Password, isPersistent: true, lockoutOnFailure: false);
            if(result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(userLogin.Username);
                var roles = await _userManager.GetRolesAsync(user);
                return BuildToken(userLogin, roles, user.Id);
            }
            ModelState.AddModelError(string.Empty, "Ingreso fallido");
            return BadRequest(ModelState);
        }

        private UserToken BuildToken(UserLogin userInfo, IList<string> roles, string userId)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Username),
                new Claim("UserId", userId)
            };

            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddDays(1);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );

            return new UserToken(){
                Expiration = expiration,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }    
    }
}
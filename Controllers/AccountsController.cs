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
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using historial_blockchain.Enums;
using Microsoft.AspNetCore.DataProtection;
using historial_blockchain.Services;
using System.Security.Cryptography;

namespace historial_blockchain.Contexts
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AccountsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly HashService hashService;
        private readonly IConfiguration _configuration;
        private readonly IMapper mapper;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration, ApplicationDbContext context, IMapper mapper, HashService hashService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            this.context = context;
            this.mapper = mapper;
            this.hashService = hashService;
        }

        [Authorize(Roles = "SysAdmin,PacsAdmin,ClinicAdmin")]
        [AllowAnonymous]
        [HttpGet("GetAccountInfo/{id}", Name = "GetAccountInfo")]
        public async Task<ActionResult<CreatedUserDTO>> GetAccountInfo(string id)
        {
            var account = mapper.Map<CreatedUserDTO>(await _userManager.FindByIdAsync(id)); 
            if(account is null)
                return NotFound();
            return account;
        }

        [Authorize(Roles = "SysAdmin")]
        [HttpGet("GetAdmins/{type}")]
        public async Task<ActionResult<IEnumerable<CreatedUserDTO>>> GetAdmins(bool type)
        {
            var admins = (IEnumerable<ApplicationUser>) await _userManager.GetUsersInRoleAsync((type) ? "PacsAdmin" : "ClinicAdmin");
            if (admins is null)
                return NotFound();
            var adminsDTO = mapper.Map<List<CreatedUserDTO>>(admins);
            return adminsDTO;
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

        [AllowAnonymous]
        [HttpPost("CreatePacient")]
        public async Task<ActionResult<UserToken>> CreatePacient([FromBody] UserInfo userInfo)
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
                await _userManager.AddClaimAsync(userData, new Claim(ClaimTypes.Role, "Pacient"));
                await _userManager.AddToRoleAsync(userData, "Pacient");
                
                //El protector del archivo es el usuario y la contraseña
                string genNodeId = EncryptText($"123_{userData.Id}_456", $"prot_{userInfo.UserName}.{userInfo.Password}_ector");
                return File(Encoding.UTF8.GetBytes(genNodeId), "text/plain", $"{userData.Nombre}_genNode.gti");
                //PROBLEMA: NO PUEDO CREAR UN NODO EXTENSIÓN GNI
            }
            return BadRequest("Datos incorrectos");
        }

        [Authorize(Roles = "SysAdmin")]
        [HttpPost("CreateAdmin/{type}")]
        public async Task<ActionResult<CreatedUserDTO>> CreateAdminAccount([FromBody] UserInfo userInfo, bool type)
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

                var adminDTO = mapper.Map<CreatedUserDTO>(userData);
                return new CreatedAtRouteResult($"GetAccountInfo", new { id = adminDTO.Id}, adminDTO);
            }
            return BadRequest("Datos incorrectos");
        }

        [Authorize(Roles = "PacsAdmin,ClinicAdmin")]
        [HttpPost("CreateDoctor")]
        public async Task<ActionResult<CreatedUserDTO>> CreateDoctorAccount([FromBody] DoctorInfo doctorInfo)
        {
            var user = new ApplicationUser { 
                Apellido = doctorInfo.Apellido,
                Email = doctorInfo.Email, 
                Nombre = doctorInfo.Nombre,
                PhoneNumber = doctorInfo.PhoneNumber,
                UserName = doctorInfo.UserName, 
            };
            var result = await _userManager.CreateAsync(user, doctorInfo.Password);
            if(result.Succeeded)
            {
                var userData = await _userManager.FindByEmailAsync(doctorInfo.Email);
                await _userManager.AddClaimAsync(userData, new Claim(ClaimTypes.Role, "Doctor"));

                var hospital = await context.HospitalAdministrador.FirstOrDefaultAsync(x => x.AdminId.Equals(doctorInfo.AdminId));
                
                await context.HospitalDoctor.AddAsync(new HospitalDoctor{
                    HospitalId = hospital.HospitalId,
                    EspecialidadId = doctorInfo.EspecialidadId,
                    DoctorId = userData.Id
                });
                await context.SaveChangesAsync();
                await _userManager.AddToRoleAsync(userData, "Doctor");

                var clinicAdminDTO = mapper.Map<CreatedUserDTO>(userData);
                return new CreatedAtRouteResult($"GetAccountInfo", new { id = clinicAdminDTO.Id}, clinicAdminDTO);
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

        /*[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SysAdmin,PacsAdmin,ClinicAdmin")]
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
        }*/

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] UpdateUserDTO updateUserDTO)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user is null)
                return NotFound();
            
            user.Nombre = updateUserDTO.Nombre;
            user.Apellido = updateUserDTO.Apellido;
            user.UserName = updateUserDTO.UserName;
            user.Email = updateUserDTO.Email;
            user.PhoneNumber = updateUserDTO.PhoneNumber;
            
            context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();
            return NoContent();
        }

        private UserToken BuildToken(UserLogin userInfo, IList<string> roles, string userId, UserType userType)
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

            var expiration = DateTime.UtcNow.AddDays(15);

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

            //TODO Reducir el tiempo del token. Está así por pruebas
            var expiration = DateTime.UtcNow.AddDays(15);

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

        private string EncryptText(string encryptval, string key)  
        {  
            byte[] SrctArray;  
            byte[] EnctArray = UTF8Encoding.UTF8.GetBytes(encryptval);  
            SrctArray = UTF8Encoding.UTF8.GetBytes(key);  
            TripleDESCryptoServiceProvider objt = new TripleDESCryptoServiceProvider();  
            MD5CryptoServiceProvider objcrpt = new MD5CryptoServiceProvider();  
            SrctArray = objcrpt.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));  
            objcrpt.Clear();  
            objt.Key = SrctArray;  
            objt.Mode = CipherMode.ECB;  
            objt.Padding = PaddingMode.PKCS7;  
            ICryptoTransform crptotrns = objt.CreateEncryptor();  
            byte[] resArray = crptotrns.TransformFinalBlock(EnctArray, 0, EnctArray.Length);  
            objt.Clear();  
            return Convert.ToBase64String(resArray, 0, resArray.Length);  
        }      
    }
}

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using historial_blockchain.Models;
using historial_blockchain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace historial_blockchain.Contexts
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BlockchainController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public BlockchainController(HashService hashService, IDataProtectionProvider protectionProvider, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost("GetNode/{username}/{password}")]
        public async Task<ActionResult<string>> GetNode([FromForm(Name = "file")] IFormFile file, string username, string password)
        {
            if(file is null || file.Length < 0)
                return BadRequest();

            var result = await signInManager.PasswordSignInAsync(username, password, isPersistent: true, lockoutOnFailure: false);
            if(result.Succeeded)
            {
                var text = new StringBuilder();
                using var reader = new StreamReader(file.OpenReadStream());
                while (reader.Peek() >= 0)
                    text.AppendLine(await reader.ReadLineAsync());
                string textoArchivo = text.ToString();
                string textoDesencriptado = DecryptFile(textoArchivo, $"prot_{username}.{password}_ector");
                return textoDesencriptado;
            }
            return BadRequest("Datos incorrectos");
        }

        public string DecryptFile(string decryptText, string key)  
        {  
            byte[] SrctArray;  
            byte[] DrctArray = Convert.FromBase64String(decryptText);  
            SrctArray = UTF8Encoding.UTF8.GetBytes(key);  
            TripleDESCryptoServiceProvider objt = new TripleDESCryptoServiceProvider();  
            MD5CryptoServiceProvider objmdcript = new MD5CryptoServiceProvider();  
            SrctArray = objmdcript.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));  
            objmdcript.Clear();  
            objt.Key = SrctArray;  
            objt.Mode = CipherMode.ECB;  
            objt.Padding = PaddingMode.PKCS7;  
            ICryptoTransform crptotrns = objt.CreateDecryptor();  
            byte[] resArray = crptotrns.TransformFinalBlock(DrctArray, 0, DrctArray.Length);  
            objt.Clear();  
            return UTF8Encoding.UTF8.GetString(resArray);  
        }
    }
}

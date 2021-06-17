using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using historial_blockchain.Contexts;
using historial_blockchain.Data;
using historial_blockchain.Entities;
using historial_blockchain.Models;
using historial_blockchain.Models.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace historial_blockchain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ClinicAdmin,Doctor")]
    public class HospitalConsultasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly BlockchainTransactionsRepository repository;
        private readonly UserManager<ApplicationUser> userManager;
        
        public HospitalConsultasController(ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, BlockchainTransactionsRepository repository)
        {
            this.mapper = mapper;
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        
        [HttpPost("GetNode/{username}/{password}")]
        public async Task<ActionResult<ConsultaKeyDTO>> GetNode([FromForm(Name = "file")] IFormFile file, string username, string password)
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
                var pacient = await userManager.FindByNameAsync(username);
                var consultaKey = new ConsultaKeyDTO
                {
                    GenNode = textoDesencriptado,
                    PacientId = pacient.Id
                };
                return consultaKey;
            }
            return BadRequest("Datos incorrectos");
        }

        [HttpGet("GetTransactions/{genNode}")]
        public async Task<ActionResult<IEnumerable<TransactionBlock>>> GetTransactions(string genNode)
        {
            return await repository.GetTransactions(genNode);
        }


        [HttpPost]
        public async Task<ActionResult<CreateConsultaDTO>> InsertConsulta(CreateConsultaDTO createConsultaDTO)
        {
            DateTime timeStamp = DateTime.Now;
            var hospitalConsulta = new HospitalConsulta
            {
                HospitalId = createConsultaDTO.HospitalId,
                PacienteId = createConsultaDTO.PacienteId,
                DoctorId = createConsultaDTO.DoctorId,
                DateStamp = timeStamp
            };
            await context.HospitalConsulta.AddAsync(hospitalConsulta);
            await context.SaveChangesAsync();
            var transactionBlock = new TransactionBlock
            {
                TimeStamp = timeStamp,
                Type = "Registro consulta",
                ConsultaMedica = createConsultaDTO.ConsultaMedica
            };
            await repository.InsertTransaction(transactionBlock, createConsultaDTO.GenNodeId);
            return Ok();
        }

        private string DecryptFile(string decryptText, string key)  
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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

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
        
        [AllowAnonymous]
        [HttpGet("{hospitalId}")]
        public async Task<ActionResult<List<HospitalConsultasDTO>>> GetConsultasHospital(string hospitalId)
        {
            var hospitalConsultas = from HC in context.HospitalConsulta
                                    join U in context.Users on HC.DoctorId equals U.Id
                                    join UP in context.Users on HC.PacienteId equals UP.Id
                                    join H in context.Hospitals on HC.HospitalId equals H.HospitalId
                                    where HC.HospitalId == hospitalId
                                    select new HospitalConsultasDTO
                                    {
                                        DateStamp = HC.DateStamp,
                                        Paciente = UP.Nombre + " " + UP.Apellido,
                                        Doctor = U.Nombre + " " + U.Apellido,
                                    };
            if(hospitalConsultas is null)
                return NotFound();
            var res = await hospitalConsultas.ToListAsync();
            return res;  
        }

        [AllowAnonymous]
        [HttpGet("Doctor/{doctorId}")]
        public async Task<ActionResult<List<HospitalConsultasDTO>>> GetConsultasDoctor(string doctorId)
        {
            var hospitalConsultas = from HC in context.HospitalConsulta
                                    join U in context.Users on HC.DoctorId equals U.Id
                                    join UP in context.Users on HC.PacienteId equals UP.Id
                                    join H in context.Hospitals on HC.HospitalId equals H.HospitalId
                                    where HC.DoctorId == doctorId
                                    select new HospitalConsultasDTO
                                    {
                                        DateStamp = HC.DateStamp,
                                        Paciente = UP.Nombre + " " + UP.Apellido,
                                        Doctor = U.Nombre + " " + U.Apellido,
                                    };
            if(hospitalConsultas is null)
                return NotFound();
            var res = await hospitalConsultas.ToListAsync();
            return res;  
        }

        [AllowAnonymous]
        [HttpGet("MisConsultas/{genNode}/{pacientId}")]
        public async Task<ActionResult<MiCalendarioConsultasDTO>> GetTransactions(string genNode, string pacientId)
        {
            var calendarioConsultasDTO = new MiCalendarioConsultasDTO();
            var hospitalConsultas = from HC in context.HospitalConsulta
                                    join U in context.Users on HC.DoctorId equals U.Id
                                    join H in context.Hospitals on HC.HospitalId equals H.HospitalId
                                    where HC.PacienteId == pacientId
                                    select new MisConsultasDTO
                                    {
                                        NombreDoctor = U.Nombre,
                                        NombreHospital = H.Name,
                                        FechaConsulta = HC.DateStamp
                                    };

            var misMedicamentos = new List<PlanMedicamento>();
            foreach (var consultas in await repository.GetTransactions(genNode))
            {
                if(consultas.ConsultaMedica is not null)
                {
                    misMedicamentos.Add(consultas.ConsultaMedica.PlanMedicamentos);
                }
            }
            calendarioConsultasDTO.MisMedicamentos = misMedicamentos;
            calendarioConsultasDTO.MisConsultas = hospitalConsultas.ToList();
//
            //calendarioConsultasDTO.MisConsultas = hospitalConsultas.ToList();
            //calendarioConsultasDTO.MisMedicamentos = misMedicamentos;
            return calendarioConsultasDTO;
        }

        [HttpGet("GetTransactions/{genNode}")]
        public async Task<ActionResult<IEnumerable<TransactionBlock>>> GetTransactions(string genNode)
        {
            return await repository.GetTransactions(genNode);
        }

        [AllowAnonymous]
        [HttpPost("GetNode/{Username}/{Password}")]
        public async Task<ActionResult<ConsultaKeyDTO>> GetNode([FromForm] IFormFile file, string Username, string Password)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            if(file is null || file.Length < 0)
                return BadRequest();

            var result = await signInManager.PasswordSignInAsync(Username, Password, isPersistent: true, lockoutOnFailure: false);
            if(result.Succeeded)
            {
                var text = new StringBuilder();
                using var reader = new StreamReader(file.OpenReadStream());
                while (reader.Peek() >= 0)
                    text.AppendLine(await reader.ReadLineAsync());
                string textoArchivo = text.ToString();
                string textoDesencriptado = DecryptFile(textoArchivo, $"prot_{Username}.{Password}_ector");
                var pacient = await userManager.FindByNameAsync(Username);
                var consultaKey = new ConsultaKeyDTO
                {
                    GenNode = textoDesencriptado,
                    PacientId = pacient.Id
                };
                return consultaKey;
            }
            return BadRequest("Datos incorrectos");
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
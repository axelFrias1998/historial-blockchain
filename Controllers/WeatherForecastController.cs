using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using historial_blockchain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace historial_blockchain.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SysAdmin")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IDataProtector _protector;

        private readonly HashService _hashService;

        public WeatherForecastController(IDataProtectionProvider protectionProvider, ILogger<WeatherForecastController> logger, HashService hashService)
        {
            //El valor único será el contenido del archivo génesis
            _protector = protectionProvider.CreateProtector("valor_unico_y_quizas_secreto");
            _logger = logger;
            _hashService = hashService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("Hash")]
        public ActionResult GetHash()
        {
            string texto = "Axel";
            var hashResult1 = _hashService.Hash(texto).Hash;
            var hashResult2 = _hashService.Hash(texto).Hash;
            return Ok(new { texto, hashResult1, hashResult2 });
        }

        [HttpGet("Cifrado")]
        public ActionResult<string> GetCifrado()
        {
            var protectorPorTiempo = _protector.ToTimeLimitedDataProtector();
            
            string textoPlano = "AxelitoPrueba";
            //string textoCifrado = _protector.Protect(textoPlano);
            string textoCifrado = protectorPorTiempo.Protect(textoPlano, TimeSpan.FromSeconds(5));
            Thread.Sleep(6000);
            //string textoDesencriptado = _protector.Unprotect(textoCifrado);
            string textoDesencriptado = protectorPorTiempo.Unprotect(textoCifrado);
            return Ok(new { textoPlano, textoCifrado, textoDesencriptado });
        }
    }
}

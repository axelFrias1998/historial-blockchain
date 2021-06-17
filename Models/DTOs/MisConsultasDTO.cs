using System;
using System.Collections.Generic;

namespace historial_blockchain.Models.DTOs
{
    public class MisConsultasDTO
    {
        public string NombreDoctor { get; set; }

        public string NombreHospital { get; set; }

        public DateTime FechaConsulta { get; set; }
    }
}

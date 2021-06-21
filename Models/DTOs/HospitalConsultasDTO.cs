using System;

namespace historial_blockchain.Models.DTOs
{
    public class HospitalConsultasDTO
    {

        public DateTime DateStamp { get; set; }

        public string Paciente { get; set; }

        public string Doctor { get; set; }
    }
}
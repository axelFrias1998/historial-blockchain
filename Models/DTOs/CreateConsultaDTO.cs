namespace historial_blockchain.Models.DTOs
{
    public class CreateConsultaDTO
    {
        public string PacienteId { get; set; }

        public string DoctorId { get; set; }

        public string HospitalId { get; set; }

        public ConsultaMedica ConsultaMedica { get; set; }
        
        public string GenNodeId { get; set; }
    }
}
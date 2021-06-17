using System.Collections.Generic;

namespace historial_blockchain.Models.DTOs
{
    public class MiCalendarioConsultasDTO
    {
        public List<MisConsultasDTO> MisConsultas { get; set; }

        public List<PlanMedicamento> MisMedicamentos { get; set; }
    }
}
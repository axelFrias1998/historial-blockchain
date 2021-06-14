using System;

namespace historial_blockchain.Models
{
    public class PlanMedicamento
    {
        public DateTime Init { get; set; }

        public string NombreMedicamento { get; set; }

        public string Indicaciones { get; set; }

        public DateTime Finish { get; set; }
    }
}
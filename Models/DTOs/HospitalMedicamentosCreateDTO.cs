namespace historial_blockchain.Models.DTOs
{
    public class HospitalMedicamentosCreateDTO
    {
        public string Descripcion { get; set; }

        public string Indicaciones { get; set; }

        public string ViaAdministracion { get; set; }

        public int GrupoMedicamentosId { get; set; }

        public string HospitalId { get; set; }
    }
}
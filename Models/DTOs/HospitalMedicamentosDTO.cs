namespace historial_blockchain.Models.DTOs
{
    public class HospitalMedicamentosDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public string Indicaciones { get; set; }

        public string ViaAdministracion { get; set; }

        public string GrupoMedicamentos { get; set; }
    }
}
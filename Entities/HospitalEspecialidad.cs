namespace historial_blockchain.Entities
{
    public class HospitalEspecialidad
    {
        public int EspecialidadId { get; set; }

        public string HospitalId { get; set; }

        public virtual SpecialitiesCatalog Especialidad { get; set; }

        public virtual Hospital Hospital { get; set; }
    }
}

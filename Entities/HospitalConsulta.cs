namespace historial_blockchain.Entities
{
    public class HospitalConsulta
    {
        public string ConsultaId { get; set; }

        public string HospitalId { get; set; }

        public virtual Consulta Consulta { get; set; }

        public virtual Hospital Hospital { get; set; }
    }
}

namespace historial_blockchain.Models
{
    public class Subjetivo
    {
        //Dolencia principal, enfermedad actual, apropiada revisión por sistemas
        public string Dolencia { get; set; }

        //Partes apropiadas o significativas de la historia médica pasada
        public string RelacionPasada { get; set; }
    }
}
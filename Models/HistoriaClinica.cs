using System;

namespace historial_blockchain.Models
{
    public class HistoriaClinica
    {
        public DateTime FechaElaboracion { get; set; }

        public DateTime FechaNacimiento { get; set; }

        //1 = Mujer, 0 = hombre 
        public bool Sexo { get; set; }

        //Indirecto (1) o directo (0) 
        public bool Interrogatorio { get; set; }

        public string PadecimientosMadre { get; set; }
        
        public string PadecimientosPadre { get; set; }
        
        public string PadecimientosHermanos { get; set; }
        
        public string PadecimientosRamaMaterna { get; set; }
        
        public string PadecimientosRamaPaterna { get; set; }
        
        public string EsquemaVacunacion { get; set; }
        
        public string AntecedentesQuirurgicos { get; set; }
        
        public string AntecedentesTraumaticos { get; set; }
        
        public string AntecedentesAlergicos { get; set; }
        
        public string AntecedentesHospitalizaciones { get; set; }
    }
}
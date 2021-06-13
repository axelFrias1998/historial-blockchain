namespace historial_blockchain.Models
{
    public class ConsultaMedica
    {
        /////////////SUBJETIVO
        //Dolencia principal, enfermedad actual, apropiada revisión por sistemas
        public string Dolencia { get; set; }

        //Partes apropiadas o significativas de la historia médica pasada
        public string RelacionPasada { get; set; }

        /////////////OBJETIVO
        //Hallazgos al examen físico
        public string Hallazgos { get; set; }

        //Pruebas diagnósticas
        public string PruebasDiagnosticas { get; set; }

        /////////ANALISIS
        //Resumen del paciente
        public string Resumen { get; set; }

        //Sus problemas
        public string Problemas { get; set; }

        //Posibles diferenciales
        public string Diferenciales { get; set; }

        //Razonamiento clínico
        public string Razonamiento { get; set; }

       //////////PLAN
       //Pruebas Dx
        public string Pruebas { get; set; }

        public string PlanTerapeutico { get; set; }
        
        //Indicaciones o recomendaciones
        public string Educacion { get; set; }

        public string Seguimiento { get; set; }
    }
}
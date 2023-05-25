namespace api_pecano.Models
{
    public class Trabajador
    {
        public string dni { get; set; }
        public int horasLaboradas { get; set; }
        public int diasLaborados { get; set; }
        public int faltas { get; set; }
        public int tipoTrabajador { get; set; }
        public double salario { get; set; }
    }
}

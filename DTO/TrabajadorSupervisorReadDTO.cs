using api_pecano.Models;

namespace api_pecano.DTO
{
    public class TrabajadorSupervisorReadDTO
    {
        public string dni { get; set; }
        public int horasLaboradas { get; set; }
        public int diasLaborados { get; set; }
        public int faltas { get; set; }
        public int tipoTrabajador { get; set; }
        public TipoTrabajador trabajador { get; set; }
        public double salario
        {
            get
            {

                return ((horasLaboradas * 55) - (faltas * 280) + 200) - (((horasLaboradas * 55) - (faltas * 280) + 200) * 0.16);

            }

        }
    }
}

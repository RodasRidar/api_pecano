using api_pecano.Models;

namespace api_pecano.DTO
{
    public class TrabajadorGerenteDTO
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

                return ((horasLaboradas * 85) - (faltas * 680) + 350) - (((horasLaboradas * 85) - (faltas * 680) + 350) * 0.18);

            }

        }
    }
}

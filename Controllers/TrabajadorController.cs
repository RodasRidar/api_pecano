using api_pecano.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;

namespace api_pecano.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajadorController : ControllerBase
    {
        [HttpGet("getAll")]
        public async Task<IActionResult> get()
        {
           
            List<Trabajador> trabajadores = new List<Trabajador>();
            List<string> lineas = getFromDocument();
            lineas.ForEach(x =>
            {
                string[] columnas = x.Split('|');
                Trabajador aux = new Trabajador
                {
                    dni = columnas[0],
                    horasLaboradas = Int32.Parse(columnas[1]),
                    diasLaborados = Int32.Parse(columnas[2]),
                    faltas = Int32.Parse(columnas[3]),
                    tipoTrabajador = Int32.Parse(columnas[4]),
                };
                trabajadores.Add(aux);
            });


            trabajadores.ForEach(x =>
            {
                x.salario = x.tipoTrabajador == 0 ? salarioObrero(x.horasLaboradas, x.faltas,x.diasLaborados) : salarioSupervisor(x.horasLaboradas, x.faltas, x.diasLaborados);
                x.salario = x.tipoTrabajador == 1 && x.salario == 0.0 ? salarioSupervisor(x.horasLaboradas, x.faltas, x.diasLaborados) : salarioGerente(x.horasLaboradas, x.faltas, x.diasLaborados);
            });

            return Ok(trabajadores);
        }
        [HttpGet("getByDni/{dni}")]
        public async Task<IActionResult> getByDNI(string dni)
        {
            List<Trabajador> trabajadores = new List<Trabajador>();
            List<string> lineas = getFromDocument();
            lineas.ForEach(x =>
            {
                string[] columnas = x.Split('|');
                Trabajador aux = new Trabajador
                {
                    dni = columnas[0],
                    horasLaboradas = Int32.Parse(columnas[1]),
                    diasLaborados = Int32.Parse(columnas[2]),
                    faltas = Int32.Parse(columnas[3]),
                    tipoTrabajador = Int32.Parse(columnas[4]),
                };
                trabajadores.Add(aux);
            });

            return Ok(trabajadores.FirstOrDefault(x => x.dni == dni));
        }

        private List<string>  getFromDocument()
        {
            List<string> lineas = new List<string>();
            using (StreamReader sr = new StreamReader("/Data/data-trabajadores.csv"))
            {
                sr.ReadLine();
                while (sr.Peek() != -1)
                {

                    lineas.Add(sr.ReadLine());
                }
            }
            return lineas;
        }
        private double salarioGerente(int horasLaboradas, int faltas,int dias)
        {
            var salarioDiario = ((horasLaboradas * 85) * dias) - (faltas * 680) + 350;
            var resultado = salarioDiario - (salarioDiario * 0.18);
            return resultado;
        }
        private double salarioObrero(int horasLaboradas, int faltas, int dias)
        {
            var salarioDiario = ((horasLaboradas * 15) * dias) - (faltas * 120) + 130;
            var resultado = salarioDiario - (salarioDiario * 0.12);
            return resultado;
        }
        private double salarioSupervisor(int horasLaboradas, int faltas, int dias)
        {
            var salarioDiario = ((horasLaboradas * 35) * dias) - (faltas * 280) +200;
            var resultado = salarioDiario - (salarioDiario * 0.16);
            return resultado;
        }
    }
}

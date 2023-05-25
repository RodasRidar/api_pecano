using api_pecano.Models;
using Microsoft.EntityFrameworkCore;

namespace api_pecano.Context
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions options) :base (options){ }  

        public DbSet<Trabajador> Trabajadores { get; set; }
        public DbSet<TipoTrabajador> TipoTrabajadores { get; set; }
    }
}

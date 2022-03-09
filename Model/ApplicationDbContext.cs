using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext() : base("name = defaultConnection") //aqui va el nombre del connection string
        {

        }

        public DbSet<Configuracion> Configuraciones { get; set; }
        public DbSet<Experiencia> Experiencias { get; set; }
        public DbSet<Habilidad> Habilidades { get; set; }
        public DbSet<Testimonio> Testimonios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}

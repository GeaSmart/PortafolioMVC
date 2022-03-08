using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("Usuarios")]
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombres { get; set; }
        [Required]
        [StringLength(50)]
        public string Apellidos { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(100)]
        public string Password { get; set; }
        [Required]
        [StringLength(100)]
        public string Direccion { get; set; }
        [Required]
        [StringLength(50)]
        public string Ciudad { get; set; }
        [Required]
        [StringLength(50)]
        public string Pais { get; set; }
        public string Telefono { get; set; }
        public string Linkedin { get; set; }
        public string Github { get; set; }
        public string Youtube { get; set; }
        public string Twitter { get; set; }

        //propiedades de navegación
        public List<Experiencia> Experiencias{ get; set; }
        public List<Testimonio> Testimonios { get; set; }
        public List<Habilidad> Habilidades { get; set; }

    }
}

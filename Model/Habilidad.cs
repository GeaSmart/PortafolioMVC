using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("Habilidades")]
    public class Habilidad
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        public string Dominio { get; set; }

        //propiedades de navegación
        public Usuario Usuario { get; set; }
    }
}

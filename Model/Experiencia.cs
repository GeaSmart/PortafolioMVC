using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("Experiencias")]
    public class Experiencia
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public byte Tipo { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string Titulo { get; set; }
        [Required]
        [StringLength(10)]
        public string Desde { get; set; }
        [Required]
        [StringLength(10)]
        public string Hasta { get; set; }
        [Column(TypeName = "text")]
        public string Descripcion { get; set; }

        //propiedades de navegacion
        public Usuario Usuario { get; set; }
    }
}

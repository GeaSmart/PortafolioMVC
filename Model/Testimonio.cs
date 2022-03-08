using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("Testimonios")]
    public class Testimonio
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        [Required]
        [StringLength(50)]
        public string Ip { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Column(TypeName = "text")]
        [Required]
        public string Comentario { get; set; }
        [Required]
        [StringLength(10)]
        public string Fecha { get; set; }

        //propiedades de navegación
        public Usuario Usuario { get; set; }
    }
}

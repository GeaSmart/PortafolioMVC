using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("Configuraciones")]
    public class Configuracion
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string Relacion { get; set; }
        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string Valor { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }
        public int Orden { get; set; }
    }
}

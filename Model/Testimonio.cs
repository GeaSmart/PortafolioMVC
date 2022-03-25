using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
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

        #region Métodos

        public Testimonio Obtener(int id)
        {
            var testimonio = new Testimonio();

            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    testimonio = ctx.Testimonios.Where(x => x.Id == id)
                                                 .SingleOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return testimonio;
        }

        public ResponseModel Guardar()
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    if (this.Id > 0) ctx.Entry(this).State = EntityState.Modified;
                    else ctx.Entry(this).State = EntityState.Added;

                    ctx.SaveChanges();
                    rm.SetResponse(true);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return rm;
        }

        public ResponseModel Eliminar(int id)
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    this.Id = id;
                    ctx.Entry(this).State = EntityState.Deleted;

                    ctx.SaveChanges();
                    rm.SetResponse(true);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return rm;
        }

        public MyGridResponde Listar(MyGrid grid, int UsuarioId)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;

                    grid.Inicializar();

                    var query = ctx.Testimonios.Where(x => x.UsuarioId == UsuarioId);

                    // Ordenamiento
                    if (grid.columna == "Id")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Id)
                                                             : query.OrderBy(x => x.Id);
                    }

                    if (grid.columna == "Nombre")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Nombre)
                                                             : query.OrderBy(x => x.Nombre);
                    }

                    if (grid.columna == "Ip")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Ip)
                                                             : query.OrderBy(x => x.Ip);
                    }
                    if (grid.columna == "Comentario")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Comentario)
                                                             : query.OrderBy(x => x.Comentario);
                    }
                    if (grid.columna == "Fecha")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Fecha)
                                                             : query.OrderBy(x => x.Fecha);
                    }

                    // Id, Nombre, Dominio

                    var testimonios = query.Skip(grid.pagina)
                                            .Take(grid.limite)
                                             .ToList();

                    var total = query.Count();

                    grid.SetData(testimonios, total);
                }
            }
            catch (Exception E)
            {

                throw;
            }

            return grid.responde();
        }

        #endregion
    }
}

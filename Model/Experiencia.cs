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




        #region Métodos

        public Experiencia Obtener(int id)
        {
            var experiencia = new Experiencia();

            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    experiencia = ctx.Experiencias.Where(x => x.Id == id)
                                                 .SingleOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return experiencia;
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

        public MyGridResponde Listar(MyGrid grid, int tipo)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;

                    grid.Inicializar();

                    var query = ctx.Experiencias.Where(x => x.Tipo == tipo);

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

                    if (grid.columna == "Titulo")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Titulo)
                                                             : query.OrderBy(x => x.Titulo);
                    }

                    if (grid.columna == "Desde")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Desde)
                                                             : query.OrderBy(x => x.Desde);
                    }

                    if (grid.columna == "Hasta")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Hasta)
                                                             : query.OrderBy(x => x.Id);
                    }

                    // id, Nombre, Titulo, Desde, Hasta

                    var experiencias = query.Skip(grid.pagina)
                                            .Take(grid.limite)
                                             .ToList();

                    var total = query.Count();

                    grid.SetData(experiencias, total);
                }
            }
            catch (Exception E)
            {

                throw;
            }

            return grid.responde();
        }
    }

    #endregion
}

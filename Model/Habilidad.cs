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


        #region Métodos

        public Habilidad Obtener(int id)
        {
            var habilidad = new Habilidad();

            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    habilidad = ctx.Habilidades.Where(x => x.Id == id)
                                                 .SingleOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return habilidad;
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

                    var query = ctx.Experiencias.Where(x => x.UsuarioId == UsuarioId);

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

                    if (grid.columna == "Dominio")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Titulo)
                                                             : query.OrderBy(x => x.Titulo);
                    }

                    // Id, Nombre, Dominio

                    var habilidades = query.Skip(grid.pagina)
                                            .Take(grid.limite)
                                             .ToList();

                    var total = query.Count();

                    grid.SetData(habilidades, total);
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

using Common;
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
        public int PaisId { get; set; }
        [StringLength(50)]
        public string Telefono { get; set; }
        [StringLength(100)]
        public string Linkedin { get; set; }
        [StringLength(100)]
        public string Github { get; set; }
        [StringLength(100)]
        public string Youtube { get; set; }
        [StringLength(100)]
        public string Twitter { get; set; }
        public string Foto { get; set; }

        //propiedades de navegación
        public List<Experiencia> Experiencias{ get; set; }
        public List<Testimonio> Testimonios { get; set; }
        public List<Habilidad> Habilidades { get; set; }


        public ResponseModel AccederUsuario(string email, string password)
        {
            var response = new ResponseModel();
            var hashedPassword = HashHelper.MD5(password);
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var usuario = context.Usuarios.Where(x => x.Email == email && x.Password == hashedPassword).FirstOrDefault();

                    if (usuario != null)
                    {
                        SessionHelper.AddUserToSession(usuario.Id.ToString());
                        response.SetResponse(true);
                    }
                    else
                    {
                        response.SetResponse(false, "Credenciales incorrectas");
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return response;
        }

        public Usuario Obtener(int id)
        {
            var usuario = new Usuario();
            try
            {
                using(var context =new ApplicationDbContext())
                {
                    usuario = context.Usuarios.Where(x => x.Id == id).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return usuario;            
        }

        public ResponseModel Guardar( )
        {
            var rm = new ResponseModel();
                        
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Configuration.ValidateOnSaveEnabled = false;

                    var usuario = context.Entry(this);
                    usuario.State = EntityState.Modified;
                    //context.Usuarios.Add(this);

                    //ignoro campo password
                    if (this.Password == null) usuario.Property(x => x.Password).IsModified = false;

                    context.SaveChanges();
                    rm.SetResponse(true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rm;
        }
    }
}

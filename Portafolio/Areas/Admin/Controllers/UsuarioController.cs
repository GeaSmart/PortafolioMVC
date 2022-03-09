using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Portafolio.Areas.Admin.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Admin/Usuario
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ResponseModel> Acceder(string email, string password)
        {
            var response = new ResponseModel();
            var hashedPassword = HashHelper.MD5(password);
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var usuario = await context.Usuarios.Where(x => x.Email == email && x.Password == hashedPassword).FirstOrDefaultAsync();

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
            catch(Exception ex)
            {
                throw;
            }
            return response;
        }
    }
}
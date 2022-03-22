using Common;
using Model;
using Portafolio.Areas.Admin.Filters;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Portafolio.Areas.Admin.Controllers
{    
    public class LoginController : Controller
    {
        private Usuario usuario = new Usuario();

        // GET: Admin/Login
        [NoLogin]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Acceder(string email, string password)
        {
            var rm = usuario.AccederUsuario(email, password);

            if (rm.response)
            {
                rm.href = Url.Content("~/admin/usuario");
            }

            return Json(rm);
        }

        public ActionResult Logout()
        {
            // Eliminar la sesion actual
            SessionHelper.DestroyUserSession();
            return Redirect("~/");
        }
    }
}
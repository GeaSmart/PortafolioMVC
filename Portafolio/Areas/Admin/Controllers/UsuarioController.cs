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
    [Autenticado]
    public class UsuarioController : Controller
    {
        private Usuario usuario = new Usuario();
        private Configuracion configuracion = new Configuracion();

        public ActionResult Index()
        {
            ViewBag.Paises = configuracion.Listar("pais");
            return View(usuario.Obtener(SessionHelper.GetUser()));
        }

        public JsonResult Guardar(Usuario usuario)
        {
            var rm = new ResponseModel();

            ModelState.Remove("Password");//ignoro campo password en la validacion del modelo
            if (ModelState.IsValid)
            {
                rm = usuario.Guardar();
            }
            return Json(rm);
        }
    }
}
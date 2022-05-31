using Model;
using Portafolio.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portafolio.Controllers
{
    public class DefaultController : Controller
    {
        private Usuario usuario = new Usuario();
        // GET: Default
        public ActionResult Index()
        {
            var usuarioActual = usuario.Obtener(Startup.DefaultUserId(),true);
            return View(usuarioActual);
        }
    }
}
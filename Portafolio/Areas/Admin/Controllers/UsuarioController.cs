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
        // GET: Admin/Usuario
        public ActionResult Index()
        {
            return View();
        }

 
    }
}
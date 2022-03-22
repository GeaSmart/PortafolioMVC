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

 
    }
}
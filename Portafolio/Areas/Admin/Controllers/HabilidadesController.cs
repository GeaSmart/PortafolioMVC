using Common;
using Model;
using Portafolio.Areas.Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portafolio.Areas.Admin.Controllers
{
    [Autenticado]
    public class HabilidadesController : Controller
    {
        private Habilidad habilidad = new Habilidad();

        // GET: Admin/Habilidades
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Listar(MyGrid grid)
        {
            return Json(habilidad.Listar(grid, SessionHelper.GetUser()));
        }

        public ActionResult Crud(int id = 0)
        {
            if (id == 0)
            {                
                habilidad.UsuarioId = SessionHelper.GetUser();
            }
            else
            {
                habilidad = habilidad.Obtener(id);
            }
            return View(habilidad);
        }

        public JsonResult Guardar(Habilidad model)
        {
            var rm = new ResponseModel();

            if (ModelState.IsValid)
            {
                rm = model.Guardar();
                if (rm.response)
                {
                    rm.href = Url.Content("~/admin/habilidades/");
                }
            }
            return Json(rm);
        }

        public JsonResult Eliminar(int id)
        {
            var rm = habilidad.Eliminar(id);

            //if (rm.response)
            //{
            //    rm.href = "self";
            //}

            return Json(rm);
        }
    }
}
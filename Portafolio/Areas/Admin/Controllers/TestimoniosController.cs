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
    public class TestimoniosController : Controller
    {
        private Testimonio testimonio = new Testimonio();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Listar(MyGrid grid)
        {
            return Json(testimonio.Listar(grid, SessionHelper.GetUser()));
        }

        public ActionResult Crud(int id)//no se puede desde el backoffice añadir testimonios, estos vienen desde el frontoffice
        {
            testimonio = testimonio.Obtener(id);            
            return View(testimonio);
        }

        public JsonResult Guardar(Testimonio model)
        {
            var rm = new ResponseModel();

            if (ModelState.IsValid)
            {
                rm = model.Guardar();
                if (rm.response)
                {
                    rm.href = Url.Content("~/admin/testimonios/");
                }
            }
            return Json(rm);
        }

        public JsonResult Eliminar(int id)
        {
            var rm = testimonio.Eliminar(id);

            //if (rm.response)
            //{
            //    rm.href = "self";
            //}

            return Json(rm);
        }
    }
}
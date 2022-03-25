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
    public class ExperienciasController : Controller
    {
        private Experiencia experiencia = new Experiencia();
        public ActionResult Index(int tipo)
        {
            ViewBag.Tipo = tipo;
            ViewBag.Title = tipo == 1 ? "Trabajos realizados" : "Estudios previos";
            return View();
        }

        public JsonResult Listar(MyGrid grid, int tipo)
        {
            return Json(experiencia.Listar(grid, tipo));
        }

        public ActionResult Crud(byte tipo, int id = 0)
        {
            if(id == 0)
            {
                experiencia.Tipo = tipo;
                experiencia.UsuarioId = SessionHelper.GetUser();
            }
            else
            {
                experiencia = experiencia.Obtener(id);
            }
            return View(experiencia);
        }

        public JsonResult Guardar(Experiencia model)
        {
            var rm = new ResponseModel();

            if (ModelState.IsValid)
            {
                rm = model.Guardar();
                if (rm.response)
                {
                    rm.href = Url.Content("~/admin/experiencias/?tipo=" + model.Tipo);
                }
            }
            return Json(rm);
        }

        public JsonResult Eliminar(int id)
        {            
            var rm = experiencia.Eliminar(id);

            if (rm.response)
            {
                rm.href = "self";
            }
            
            return Json(rm);
        }
    }
}
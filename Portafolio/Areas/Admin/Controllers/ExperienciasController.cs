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

        public ActionResult Crud(byte tipo, int id = 0)
        {
            if(id == 0)
            {
                experiencia.Tipo = tipo;
            }
            else
            {

            }
            return View(experiencia);
        }

        public JsonResult Guardar(Experiencia model)
        {

        }
    }
}
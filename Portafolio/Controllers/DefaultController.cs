using Common;
using Model;
using Portafolio.App_Start;
using Portafolio.DTO;
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

        public JsonResult EnviarCorreo(ContactoDTO contactoDTO)
        {
            var rm = new ResponseModel();

            if (ModelState.IsValid)
            {
                try
                {
                    var destinatario = usuario.Obtener(Startup.DefaultUserId());
                    //var mensaje = $"<h1 style='color:blue'>Buenas tardes,</h1><hr><p>Hola esta es una prueba hecha el {DateTime.Now}</p>";
                    EmailHelper.SendEmail(contactoDTO.Nombre, destinatario.Email, $"Mensaje de {contactoDTO.Correo}", contactoDTO.Mensaje);
                }
                catch(Exception ex)
                {
                    rm.SetResponse(false, ex.Message);
                    return Json(rm);
                    throw;
                }
                rm.SetResponse(true);
                rm.function = "cerrarModal();";
            }
            return Json(rm);
        }
    }
}
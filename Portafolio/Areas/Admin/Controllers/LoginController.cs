﻿using Common;
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
    [NoLogin]
    public class LoginController : Controller
    {
        //private Usuario usuario = new Usuario();
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Acceder(string email, string password)
        {
            var rm = AccederUsuario(email, password);

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

        public ResponseModel AccederUsuario(string email, string password)
        {
            var response = new ResponseModel();
            var hashedPassword = HashHelper.MD5(password);
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var usuario = context.Usuarios.Where(x => x.Email == email && x.Password == hashedPassword).FirstOrDefault();

                    if (usuario != null)
                    {
                        SessionHelper.AddUserToSession(usuario.Id.ToString());
                        response.SetResponse(true);
                    }
                    else
                    {
                        response.SetResponse(false, "Credenciales incorrectas");
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return response;
        }
    }
}
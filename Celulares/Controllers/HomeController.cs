using Celulares.Models.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Celulares.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return RedirectToAction("Index", new { Area = "Registro", Controller = "Registro" });
        }

        public PartialViewResult UsuarioInfo(Usuario model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                DBContext db = new DBContext();
                Usuario usuario = db.T_Usuario.One(u => u.Nombre == model.Nombre && u.Contrasena == model.Contrasena);
                if (usuario == null)
                {
                    model.UltimoIngreso = DateTime.Now;
                    model.Rol = db.T_Rol.One(r=>r.Nombre=="Invitado");
                    db.T_Usuario.Add(model);

                    ModelState.AddModelError("Nombre", "El usuario no esta registrado");
                    return PartialView("_UsuarioInfo");
                }
                else
                {
                    usuario.EnLinea = true;
                    usuario.UltimoIngreso = DateTime.Now;
                    db.T_Usuario.Alter(usuario);
                    return PartialView("_UsuarioInfo", usuario);
                }
            }
            return PartialView("_UsuarioInfo");
        }

        public ActionResult LogOut(String username, String Passwword)
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        

    }
}

using Celulares.Areas.Registro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Celulares.Areas.Registro.Controllers
{
    public class RegistroController : Controller
    {
        //
        // GET: /Registro/Registro/

        public ActionResult Index()
        {
            DBContext db = new DBContext();
            ViewBag.Motivos = db.T_Motivo.ToList();
            TempRegistrarDenuncia salida = new TempRegistrarDenuncia();
            salida.Denuncias = new List<Denuncia>();
            return View(salida);
        }

        public ActionResult Registrar(TempRegistrarDenuncia temp)
        {
            DBContext db = new DBContext();
            temp.Telefono = (string)Session["telefono"];
            Demandado demandado = db.T_Demandado.Include("Denuncias").Where(i => i.Telefono == temp.Telefono).FirstOrDefault();
            if (demandado == null)
            {
                demandado = new Demandado();
                demandado.Telefono = temp.Telefono;
                demandado.Demandantes = new List<Demandante>();
                demandado.Demandantes.Add(new Demandante { Usuario = db.T_Usuario.One(i => i.Id == 1) });
                demandado.Denuncias = new List<Denuncia>();
                demandado.Denuncias.Add(new Denuncia { MotivoId = temp.MotivoId, Titulo = temp.Titulo, Mensaje = temp.Mensaje, Estado = true, Eliminado = false, FechaCreacion = DateTime.Now, FechaModificacion = DateTime.Now });
                db.T_Demandado.Add(demandado);
            }
            else
            {
                demandado.Denuncias.Add(new Denuncia { MotivoId = temp.MotivoId, Titulo = temp.Titulo, Mensaje = temp.Mensaje, Estado = true, Eliminado = false, FechaCreacion = DateTime.Now, FechaModificacion = DateTime.Now });
                db.T_Demandado.Alter(demandado);
            }


            return Content("Registro Realizado satisfactoriamente");
        }

        [HttpPost]
        public PartialViewResult FindNumber(string telefono)
        {
            Session["telefono"] = telefono;
            DBContext db = new DBContext();
            Demandado demandado = db.Demandado.Include("Denuncias").Where(i => i.Telefono == telefono).FirstOrDefault();
            TempRegistrarDenuncia salida = new TempRegistrarDenuncia();

            salida.Denuncias = new List<Denuncia>();
            salida.Telefono = telefono;
            if (demandado == null)
            {
                salida.Denuncias = new List<Denuncia>();
            }
            else
            {
                salida.Denuncias = demandado.Denuncias;
            }
            foreach (Denuncia denuncia in salida.Denuncias)
            {
                denuncia.Motivo = db.T_Motivo.One(i => i.Id == denuncia.MotivoId);
            }

            //salida.Denuncias.Add(new Denuncia { Mensaje = " Mi mensajes es Me acosan", Titulo = "Ya no soporto", MotivoId = 1, Motivo = db.T_Motivo.One(i => i.Id == 1), FechaCreacion = DateTime.Now });
            //salida.Denuncias.Add(new Denuncia { Mensaje = "Mi mensajes es Me acosan", Titulo = "Ya no soporto", MotivoId = 2, Motivo = db.T_Motivo.One(i => i.Id == 2), FechaCreacion = DateTime.Now });
            //salida.Denuncias.Add(new Denuncia { Mensaje = "Mi mensajes es Me acosan", Titulo = "Ya no soporto", MotivoId = 3, Motivo = db.T_Motivo.One(i => i.Id == 3), FechaCreacion = DateTime.Now });
            //salida.Denuncias.Add(new Denuncia { Mensaje = "Mi mensajes es Me acosan", Titulo = "Ya no soporto", MotivoId = 2, Motivo = db.T_Motivo.One(i => i.Id == 2), FechaCreacion = DateTime.Now });
            //salida.Denuncias.Add(new Denuncia { Mensaje = "Mi mensajes es Me acosan", Titulo = "Ya no soporto", MotivoId = 3, Motivo = db.T_Motivo.One(i => i.Id == 3), FechaCreacion = DateTime.Now });
            //salida.Denuncias.Add(new Denuncia { Mensaje = "Mi mensajes es Me acosan", Titulo = "Ya no soporto", MotivoId = 1, Motivo = db.T_Motivo.One(i => i.Id == 1), FechaCreacion = DateTime.Now });

            return PartialView("_ResumenDemandas", salida);
        }

    }
}

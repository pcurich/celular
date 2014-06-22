using Celulares.Util.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Celulares.Models.Seguridad
{
    public class Usuario:DBable
    {
        public static String TABLENAME = "Usuarios";
        public String Nombre { get; set; }
        public String Contrasena { get; set; }

        public String Email { get; set; }
        public String Pregunta { get; set; }
        public String Respuesta { get; set; }
        public String NombreAplicacion { get; set; }
        public bool EnLinea { get; set; }
        public DateTime UltimoIngreso { get; set; }
        
        public Rol Rol { get; set; }
        public int RolId { get; set; }

       
    }
}
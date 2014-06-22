using Celulares.Util.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Celulares.Models.Seguridad
{
    public class Rol:DBable
    {
        public static String TABLENAME = "Roles";
        public String Nombre { get; set; }
        public List<Usuario> Usuarios { get; set; }
    }
}
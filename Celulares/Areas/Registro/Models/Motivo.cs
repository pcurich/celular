using Celulares.Util.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Celulares.Areas.Registro.Models
{
    public class Motivo : DBable
    {
        public static String TABLENAME = "Motivo";

        public List<Denuncia> Denuncias { get; set; }

        public String Descripcion { get; set; }
    }
}
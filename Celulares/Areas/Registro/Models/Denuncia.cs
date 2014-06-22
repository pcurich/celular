using Celulares.Util.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Celulares.Areas.Registro.Models
{
    public class Denuncia : DBable
    {
        public Demandado demandado { get; set; }
        public int demandadoId { get; set; }

        public static String TABLENAME = "Denuncia";
        public String mensaje { get; set; }
    }
}
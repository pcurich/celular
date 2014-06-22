
using Celulares.Models.Seguridad;
using Celulares.Util.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Celulares.Areas.Registro.Models
{
    public class Demandante : DBable
    {
        public static String TABLENAME = "Demandante";

        public Demandado demandado { get; set; }
        public int demandadoId { get; set; }
        public Usuario  usuario { set;get; }
        public String request { get; set; }
    }
}
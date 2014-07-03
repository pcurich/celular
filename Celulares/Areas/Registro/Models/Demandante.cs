
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

        public Demandado Demandado { get; set; }
        public int DemandadoId { get; set; }
        public Usuario  Usuario { set;get; }
        public String Request { get; set; }
    }
}
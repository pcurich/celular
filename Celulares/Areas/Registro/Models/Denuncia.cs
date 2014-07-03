using Celulares.Util.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Celulares.Areas.Registro.Models
{
    public class Denuncia : DBable
    {
        public Demandado Demandado { get; set; }
        public int DemandadoId { get; set; }

        public static String TABLENAME = "Denuncia";
        public String Mensaje { get; set; }

        public String Titulo { get; set; }

        public int MotivoId { get; set; }
        public Motivo Motivo { get; set; }
    }
}
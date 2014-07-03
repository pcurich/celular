using Celulares.Util.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Celulares.Areas.Registro.Models
{
    public class TempRegistrarDenuncia : DBable
    {
        public String Telefono { get; set; }
        public String Titulo { get; set; }

        public String Mensaje { get; set; }

        public int MotivoId { get; set; }

        public List<Denuncia> Denuncias { get; set; }
    }
}
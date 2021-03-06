﻿using Celulares.Util.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Celulares.Areas.Registro.Models
{
    public class Demandado : DBable
    {
        public static String TABLENAME = "Demandado";

        public String Telefono { get; set; }

        public List<Denuncia> Denuncias { get; set; }

        public List<Demandante> Demandantes { get; set; }

    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Celulares.Util.Entity;
using System.ComponentModel;
using System.Reflection;

namespace Celulares
{
    public class Actividad
    {
        public DateTime FechaActividad { get; set; }
        public String Nombre { get; set; }
        public String Extra { get; set; }

    }

        public enum TipoActividad
        {
            [Description("Ingreso")]
            Ingreso,
            [Description("Salida")]
            Salida,
            [Description("Agregado")]
            Agregado,
            [Description("Modificado")]
            Modificado,
            [Description("EliminadoFisico")]
            EliminadoFisico,
            [Description("EliminadoLogico")]
            EliminadoLogico
        }
    
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Celulares.Util.Entity
{
    public class DBable
    {
        [Key]
        [Display(AutoGenerateField = false)]
        public int Id { get; set; }

        public bool Estado { get; set; }

        [DisplayName("SomeThing")]
        [Display(AutoGenerateField = false)]
        public bool Eliminado { get; set; }

        [ScaffoldColumn(false)]
        public DateTime FechaCreacion { get; set; }

        [ScaffoldColumn(false)]
        public DateTime FechaModificacion { get; set; }

        [ScaffoldColumn(false)]
        public List<Actividad> Actividades = new List<Actividad>();
    }
}
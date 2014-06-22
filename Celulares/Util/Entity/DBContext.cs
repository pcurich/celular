using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Celulares
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        //: base(@"Data Source=IDEA-PC\SQLEXPRESS;Initial Catalog=TrHelena2014;Integrated Security=True")
            : base(Celulares.MvcApplication.ConnectionString)
        {
            RegistrarTablas();
            this.Configuration.LazyLoadingEnabled = false; //http://sebys.com.ar/2011/06/01/entity-framework-4-1-cf-y-lazy-load/
        }
    }
}
using Celulares.Util.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Celulares
{
    public partial class DBContext :DbContext
    {
        public class InitializerDropAlways : DropCreateDatabaseAlways<DBContext>
        {
            protected override void Seed(DBContext context)
            {
                context.Seed();
            } 
        }

        public class InitializerIfModelChange : DropCreateDatabaseIfModelChanges<DBContext>
        {
            protected override void Seed(DBContext context)
            {
                context.Seed();
            }
        }
               
    }
}
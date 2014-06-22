using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Celulares.Models.Seguridad
{
    public class MemberShipUser : MembershipUser
    {
        public Usuario usuario { get; set; }

    }
}
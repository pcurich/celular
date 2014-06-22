using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Celulares.Areas.Registro.Models
{
    public class HttpMethod
    {
        enum Method
        {
            GET, 
            HEAD, 
            POST, 
            PUT, 
            DELETE, 
            OPTIONS, 
            TRACE, 
            CONNECT
        }
    }
}
using Celulares.Util.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Celulares.Areas.Registro.Models
{
    public class HttpVersion:DBable
    {
        enum Version
        {
            [Description("HTTP/1.1")]
            HTTP_1_1,
            [Description("HTTP/1.0")]
            HTTP_1_0
        }
    }
}
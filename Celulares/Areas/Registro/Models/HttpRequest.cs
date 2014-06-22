using Celulares.Util.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Celulares.Areas.Registro.Models
{
    public class HttpRequest
    {
        public HttpVersion version;

        public HttpMethod method;

        public String requestedPath;

        public String queryString;

        public Dictionary<String, String> headers;
    }
}
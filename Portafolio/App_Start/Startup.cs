using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portafolio.App_Start
{
    public class Startup
    {
        public static int DefaultUserId()
        {
            //devuelve el id 1 es decir mi usuario en caso que entren al Index sin especificar user Id
            int defaultUserId = 1;
            string userId = HttpContext.Current.Request.QueryString["id"];
            return userId != null ? Convert.ToInt32(userId) : defaultUserId;
        }
    }
}
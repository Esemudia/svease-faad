using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;

namespace saveasze
{
    class connString
    {
        public string connstring(string connLocation)
        {
            string svrName = HttpContext.Current.Request.Url.Host;
            svrName = svrName.ToLower();

            string config = "";
            if(svrName.Contains("localhost"))
                config = "Faad";
            else
                config = "FaadOnline";

            return ConfigurationManager.ConnectionStrings[config].ConnectionString;

        }
    }
}

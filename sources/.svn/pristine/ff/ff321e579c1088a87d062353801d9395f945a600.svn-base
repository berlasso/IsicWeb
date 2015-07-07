using System;

using System.Globalization;
using System.Configuration;

namespace MPBA.SIAC.Web.Models
{
    public class WebAppAdoNetAppender : log4net.Appender.AdoNetAppender
    {
        public new string ConnectionString
        {
            get { return base.ConnectionString; }
            set { base.ConnectionString = ConfigurationManager.ConnectionStrings["PersonasBuscadasConnectionString"].ConnectionString; }
          
        }
      
    }
}
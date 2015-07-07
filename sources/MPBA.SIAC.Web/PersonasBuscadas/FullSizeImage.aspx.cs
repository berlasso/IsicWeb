using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MPBA.PersonasBuscadas.Web
{
    public partial class FullSizeImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string url = Request.QueryString["url"];
            string r = Request.QueryString["r"];//random xa q no use cache
            string p = Request.QueryString["p"];//tipo persona
            string esBI = Request.QueryString["bi"];//si es busq indiv

            this.imgImagen.ImageUrl = url+"&r="+r+"&p="+p+"&bi="+esBI;
            
        }
    }
}

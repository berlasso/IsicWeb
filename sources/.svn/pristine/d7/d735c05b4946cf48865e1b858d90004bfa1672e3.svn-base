using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MPBA.PersonasBuscadas.Web
{
    public partial class ImagenFoto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["imgPreview"] != null)
            {
                this.Response.ContentType = "image/jpeg";
                Byte[] im = (Byte[])Session["imgPreview"];
                Response.BinaryWrite(im);
             
            }
        }
    }
}

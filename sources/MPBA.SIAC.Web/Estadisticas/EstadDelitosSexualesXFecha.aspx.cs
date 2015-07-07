using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MPBA.SIAC.Web
{
    public partial class EstadDelitosSexualesXFecha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string dpto = Request.QueryString["dpto"];
                this.divCartelDSXDep.InnerText = "Cant. de Delitos Sexuales Por Dependencia en " + MPBA.SIAC.Bll.DepartamentoManager.GetItem(Convert.ToInt32(dpto), false).departamento.Trim();
            }
        }
    }
}
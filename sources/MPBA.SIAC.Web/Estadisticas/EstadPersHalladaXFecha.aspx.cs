using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPBA.PersonasBuscadas.Bll;
using MPBA.PersonasBuscadas.BusinessEntities;

namespace MPBA.SIAC.Web
{
    public partial class EstadPersHalladaXFecha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string dpto = Request.QueryString["dpto"];
                this.divCartelPHXDep.InnerText = "Cant. de Personas Halladas Por Dependencia en " + MPBA.SIAC.Bll.DepartamentoManager.GetItem(Convert.ToInt32(dpto), false).departamento.Trim();
            }
        }
    }
}
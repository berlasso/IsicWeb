using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPBA.AutoresIgnorados.Bll;
using MPBA.AutoresIgnorados.BusinessEntities;
using System.Data;

namespace MPBA.AutoresIgnorados.Web
{
    public partial class BusquedaPruebasPendientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string moduloActual = Request.QueryString["tipo"].ToString().Substring(1, 1);
                switch (moduloActual)
                {
                    case "1":
                        Session["moduloActual"] = "RH";
                        break;
                    case "2":
                        Session["moduloActual"] = "DS";
                        break;
                }


                string tipo = Request.QueryString["tipo"];
                int idClaseDelito;
                if (tipo != null)
                    idClaseDelito = Convert.ToInt16(tipo);
                else
                    idClaseDelito = 0;
                RastrosList rl=RastrosManager.GetListByIdClaseEstadoInformeRastro(1,idClaseDelito);
                rl.FindAll(delegate(Rastros r) { return r.Baja == false; });
                this.gvPrueba.DataSource = rl;
                this.gvPrueba.DataBind();
            }
        }


        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session["moduloActual"] = null;
            Response.Redirect("~/Home.aspx");
        }

       
      }
}

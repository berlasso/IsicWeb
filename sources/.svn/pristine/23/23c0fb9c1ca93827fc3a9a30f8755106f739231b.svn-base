using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MPBA.SIAC.Web
{
    public partial class EstadisticasSeleccion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string idPg=Session["idPuntoGestion"].ToString();
                string idDepto = MPBA.SIAC.Bll.PuntoGestionManager.GetItem(idPg,false).idDepartamento.ToString();
                this.ddlDepto.SelectedValue = idDepto;
              
            }
        }

        protected void btnEstadistica_Click(object sender, EventArgs e)
        {
            string d = this.txtFechaDesde.Text.Trim();
            string h = this.txtFechaHasta.Text.Trim();
          
            string depto = this.ddlDepto.SelectedValue;
            string r = new Random().Next().ToString();
            switch (this.ddlModulo.SelectedValue)
            {
                case "bpd":
                    this.ifEstadisticas.Attributes["src"] = @"\Estadisticas\EstadPersDesapXFecha.aspx?d=" + d + "&h=" + h+"&dpto="+depto+"&r="+r;
                    //this.ifEstadisticas.Visible = true;
                    //Response.Redirect( @"\EstadPersDesapXFecha.aspx?d=" + d + "&h=" + h+"&dpto="+depto+"&r="+r);
                    break;
                case "bph":
                    this.ifEstadisticas.Attributes["src"] = @"\Estadisticas\EstadPersHalladaXFecha.aspx?d=" + d + "&h=" + h + "&dpto=" + depto + "&r=" + r;
                    this.ifEstadisticas.Visible = true;
                    //Response.Redirect(@"\EstadPersDesapXFecha.aspx?d=" + d + "&h=" + h);
                    break;
                case "rh":
                    this.ifEstadisticas.Attributes["src"] = @"\Estadisticas\EstadRobosHurtosXFecha.aspx?t=1&d=" + d + "&h=" + h + "&dpto=" + depto;
                    this.ifEstadisticas.Visible = true;
                    //Response.Redirect(@"\EstadPersDesapXFecha.aspx?d=" + d + "&h=" + h);
                    break;
                case "ds":
                    this.ifEstadisticas.Attributes["src"] = @"\Estadisticas\EstadDelitosSexualesXFecha.aspx?t=2&d=" + d + "&h=" + h + "&dpto=" + depto;
                    this.ifEstadisticas.Visible = true;
                    //Response.Redirect(@"\EstadPersDesapXFecha.aspx?d=" + d + "&h=" + h);
                    break;

            }
        }
    }
}
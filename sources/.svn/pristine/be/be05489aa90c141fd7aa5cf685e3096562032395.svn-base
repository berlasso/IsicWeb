using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MPBA.SIAC.Web.PersonasBuscadas
{
    public partial class BusquedasActivas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Session["moduloActual"] = "BP";
                string idGrupo = Session["idGrupo"].ToString();//grupousuario al que pertenece el usuario actual
                this.ddlDepto.Enabled = idGrupo == "1";//si es superadministrador
                if (idGrupo != "1")
                {
                    string idPg = Session["miUFI"].ToString();
                    string idDepto = MPBA.SIAC.Bll.PuntoGestionManager.GetItem(idPg, false).idDepartamento.ToString();
                    this.ddlDepto.SelectedValue = idDepto;
                    
                }
               
                this.txtFechaDesde.Text = DateTime.Today.ToString("01/MM/yyyy");
                this.txtFechaHasta.Text = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month).ToString() + "/" + DateTime.Today.ToString("MM/yyyy");
                
            }

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEstadistica_Click(object sender, EventArgs e)
        {
            string d = this.txtFechaDesde.Text.Trim();
            string h = this.txtFechaHasta.Text.Trim();
            string titulo = "";
            string depto = this.ddlDepto.SelectedValue;
            titulo = "Busquedas de Personas Desaparecidas Activas cargadas entre el " + d + " y " + h;
            this.ifEstadisticas.Attributes["src"] = "ReportDesaparecidosActivos.aspx?d=" + d + "&h=" + h + "&titulo=" + titulo + "&dpto=" + depto;
            this.ifEstadisticas.Visible = true;

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using MPBA.SIAC.Bll;
using MPBA.SIAC.BusinessEntities;

namespace MPBA.SIAC.Web
{
    public partial class EstadisticasDelitos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Session["moduloActual"] = "E";
                string tipo = Request.QueryString["r"];
                switch (tipo)
                {
      
                    case "mo":
                               Microsoft.Reporting.WebForms.ReportDataSource dsModusOperandi = new Microsoft.Reporting.WebForms.ReportDataSource("dsEstadisticasDelitos", "odsDelitosMO");
                               this.rvDelitos.LocalReport.DataSources.Add(dsModusOperandi);
                        break;
                }

                string idPg = Session["miUFI"].ToString();
                int idDepto = MPBA.SIAC.Bll.PuntoGestionManager.GetItem(idPg, false).idDepartamento;
                string deptoJud = DepartamentoManager.GetItem(idDepto).departamento.Trim();
                string lugarFecha = deptoJud + ", " + DateTime.Today.ToString("dd") + " de " + (FuncionesGenerales.NombreMes)DateTime.Today.Month + " de " + DateTime.Today.Year;
                string titulo = Request.QueryString["titulo"];
                string depto=Request.QueryString["dpto"];
                string tituloDepto = DepartamentoManager.GetItem(Convert.ToInt32(depto)).departamento.Trim();
                if (depto == "0")
                    tituloDepto = "Todos los Departamentos Judiciales";
                ReportParameterCollection reportParameters = new ReportParameterCollection();
                reportParameters.Add(new ReportParameter("Titulo", titulo));
                reportParameters.Add(new ReportParameter("TituloDepto", tituloDepto));
                reportParameters.Add(new ReportParameter("LugarFecha", lugarFecha));
                this.rvDelitos.LocalReport.SetParameters(reportParameters);
                this.rvDelitos.DataBind();
                this.rvDelitos.LocalReport.Refresh();

            }
        }
    }
}
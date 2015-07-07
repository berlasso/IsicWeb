using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace MPBA.SIAC.Web.PersonasBuscadas
{
    public partial class ReportDesaparecidosActivos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Microsoft.Reporting.WebForms.ReportDataSource dsDesapActivas = null;
                this.ReportViewer1.LocalReport.ReportPath = @"PersonasBuscadas\rptDesaparecidasActivas.rdlc";
                dsDesapActivas = new Microsoft.Reporting.WebForms.ReportDataSource("dsActivas", "odsDesaparecidasActivas");
                this.ReportViewer1.LocalReport.Refresh();
                this.ReportViewer1.LocalReport.DataSources.Add(dsDesapActivas);
                this.ReportViewer1.LocalReport.Refresh();
                string titulo = Request.QueryString["titulo"];
                string depto = Request.QueryString["dpto"];
                ReportParameterCollection reportParameters = new ReportParameterCollection();
                reportParameters.Add(new ReportParameter("Titulo", titulo));
                this.ReportViewer1.LocalReport.SetParameters(reportParameters);
                this.ReportViewer1.DataBind();
                this.ReportViewer1.LocalReport.Refresh();
            }
        }

        protected void odsDesaparecidasActivas_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {

        }
    }
}
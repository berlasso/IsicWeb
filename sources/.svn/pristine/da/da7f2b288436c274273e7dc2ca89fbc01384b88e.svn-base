using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace MPBA.PersonasBuscadas.Web
{
    public partial class ReporteFormD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string esExJur = Request.QueryString["esExJur"].ToString();
                this.ReportViewer1.Reset();

                this.ReportViewer1.LocalReport.DataSources.Clear();



                Microsoft.Reporting.WebForms.ReportDataSource dsDesaparecidas = new Microsoft.Reporting.WebForms.ReportDataSource("PersonasBuscadasDataSet_PersonasDesaparecidasArmadoSelectSingleItem", "odsDesaparecidas");
                this.ReportViewer1.LocalReport.DataSources.Add(dsDesaparecidas);
                Microsoft.Reporting.WebForms.ReportDataSource dsTatuajes = new Microsoft.Reporting.WebForms.ReportDataSource("PersonasBuscadasDataSet_TatuajesArmadoSelectByIppAndTablaDestino", "odsTatuajes");
                this.ReportViewer1.LocalReport.DataSources.Add(dsTatuajes);
                Microsoft.Reporting.WebForms.ReportDataSource dsSenas = new Microsoft.Reporting.WebForms.ReportDataSource("PersonasBuscadasDataSet_SeniasParticularesArmadoSelectByIdPersonaAndTablaDestino", "odsSenasPart");
                this.ReportViewer1.LocalReport.DataSources.Add(dsSenas);
                Microsoft.Reporting.WebForms.ReportDataSource dsFotos = new Microsoft.Reporting.WebForms.ReportDataSource("PathFotos", "odsFotos");
                this.ReportViewer1.LocalReport.DataSources.Add(dsFotos);

              


                switch (esExJur)
                {
                    case "0":
                        this.ReportViewer1.LocalReport.ReportPath = @"PersonasBuscadas\rptPersonaDesapSinExJur.rdlc";
                        break;
                    case "1":
                        Microsoft.Reporting.WebForms.ReportDataSource dsExJur = new Microsoft.Reporting.WebForms.ReportDataSource("dsExtranaJurisdiccion", "odsExJur");
                        this.ReportViewer1.LocalReport.DataSources.Add(dsExJur);
                        this.ReportViewer1.LocalReport.ReportPath = @"PersonasBuscadas\rptPersonaDesapConExJur.rdlc";
                        break;
                }
                this.ReportViewer1.LocalReport.EnableExternalImages = true;

                this.ReportViewer1.DataBind();

                this.ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
                this.ReportViewer1.LocalReport.Refresh();
            }
        }

        private void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
        
            
           // MPBA.SIAC.Web.PersonasBuscadas.PersonasBuscadasDataSet.SeniasParticularesArmadoSelectByIdPersonaAndTablaDestinoDataTable dtSenias=new SIAC.Web.PersonasBuscadas.PersonasBuscadasDataSet.SeniasParticularesArmadoSelectByIdPersonaAndTablaDestinoDataTable();


             //Supply a DataTable corresponding to each subreport dataset
             //The dataset name must match the name defined in the subreport
            e.DataSources.Add(new ReportDataSource((e.DataSourceNames[0]), this.odsSenasPart));
            e.DataSources.Add(new ReportDataSource((e.DataSourceNames[1]), this.odsTatuajes));
            e.DataSources.Add(new ReportDataSource((e.DataSourceNames[2]), this.odsFotos));
        }
    }
}

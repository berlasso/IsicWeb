using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace MPBA.PersonasBuscadas.Web
{
    public partial class ReporteFormH : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string esExJur = Request.QueryString["esExJur"].ToString();
                this.ReportViewer1.Reset();
             
              this.ReportViewer1.LocalReport.DataSources.Clear();

                //this.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;  
                //this.ReportViewer1.LocalReport.ReportPath = "rptDesaparecidas.rdlc";
                //this.ReportViewer1.LocalReport.DataSources.Clear();

                //Microsoft.Reporting.WebForms.ReportDataSource dsSeniasParticulares = new Microsoft.Reporting.WebForms.ReportDataSource();//"PersonasBuscadasDataset_SeniasParticularesArmadoSelectByIdPersonaAndTablaDestino", "odsSeniasParticulares");
                //dsSeniasParticulares.Name = "PersonasBuscadasDataSet_SeniasParticularesArmadoSelectByIdPersonaAndTablaDestino";
                //dsSeniasParticulares.DataSourceId = "odsSeniasParticulares";
                //this.ReportViewer1.LocalReport.DataSources.Add(dsSeniasParticulares);

                //Microsoft.Reporting.WebForms.ReportDataSource dsTatuajes = new Microsoft.Reporting.WebForms.ReportDataSource();
                //dsTatuajes.Name = "PersonasBuscadasDataset_TatuajesPersonaArmadoSelectByIdPersonaAndTablaDestino";
                //dsTatuajes.DataSourceId = "odsTatuajesPersona";
                //this.ReportViewer1.LocalReport.DataSources.Add(dsTatuajes);


              Microsoft.Reporting.WebForms.ReportDataSource dsHalladas = new Microsoft.Reporting.WebForms.ReportDataSource("PersonasBuscadasDataSet_PersonasHalladasArmadoSelectSingleItem", "odsHalladas");
                this.ReportViewer1.LocalReport.DataSources.Add(dsHalladas);
                Microsoft.Reporting.WebForms.ReportDataSource dsTatuajes = new Microsoft.Reporting.WebForms.ReportDataSource("PersonasBuscadasDataSet_TatuajesArmadoSelectByIppAndTablaDestino", "odsTatuajes");
                this.ReportViewer1.LocalReport.DataSources.Add(dsTatuajes);
                Microsoft.Reporting.WebForms.ReportDataSource dsSenas = new Microsoft.Reporting.WebForms.ReportDataSource("PersonasBuscadasDataSet_SeniasParticularesArmadoSelectByIdPersonaAndTablaDestino", "odsSenasPart");
                this.ReportViewer1.LocalReport.DataSources.Add(dsSenas);
                Microsoft.Reporting.WebForms.ReportDataSource dsFotos = new Microsoft.Reporting.WebForms.ReportDataSource("PathFotos", "odsFotos");
                this.ReportViewer1.LocalReport.DataSources.Add(dsFotos);

                //Microsoft.Reporting.WebForms.ReportDataSource dsFotos = new Microsoft.Reporting.WebForms.ReportDataSource("PathFotos", this.odsFotos);
                //this.ReportViewer1.LocalReport.DataSources.Add(dsFotos);
                ////this.ReportViewer1.LocalReport.DataSources["PersonasBuscadasDataset_PersonasDesaparecidasArmadoSelectSingleItem"].Value = this.odsDesaparecidas;
                ////this.ReportViewer1.LocalReport.DataSources["PersonasBuscadasDataset_PersonasDesaparecidasArmadoSelectSingleItem"].DataSourceId = "odsDesaparecidas";
                ////this.ReportViewer1.LocalReport.DataSources["PersonasBuscadasDataset_SeniasParticularesArmadoSelectByIdPersonaAndTablaDestino"].Value = this.odsSeniasParticulares;
                ////this.ReportViewer1.LocalReport.DataSources["PersonasBuscadasDataset_SeniasParticularesArmadoSelectByIdPersonaAndTablaDestino"].DataSourceId = "odsSeniasParticulares";
                ////this.ReportViewer1.LocalReport.DataSources["PersonasBuscadasDataset_TatuajesPersonaArmadoSelectByIdPersonaAndTablaDestino"].Value = this.odsTatuajesPersona;
                ////this.ReportViewer1.LocalReport.DataSources["PersonasBuscadasDataset_TatuajesPersonaArmadoSelectByIdPersonaAndTablaDestino"].DataSourceId = "odsTatuajesPersona";
                ////this.ReportViewer1.LocalReport.DataSources["PersonasBuscadasDataset_PathFotosDesaparecidas"].Value = this.odsPathFotosDesap;
                ////this.ReportViewer1.LocalReport.DataSources["PersonasBuscadasDataset_PathFotosDesaparecidas"].DataSourceId = "odsPathFotosDesap";
                ////this.ReportViewer1.LocalReport.DataSources["PersonasBuscadasDataset_PathFotosDesap"].Value = this.odsPathFotosDesap;
                ////this.ReportViewer1.LocalReport.DataSources["PersonasBuscadasDataset_PathFotosDesap"].DataSourceId = "odsPathFotosDesap";
                ////this.ReportViewer1.LocalReport.DataSources["PathFotos"].Value = this.odsPathFotosDesap;
                ////this.ReportViewer1.LocalReport.DataSources["PathFotos"].DataSourceId = "odsPathFotosDesap";
                ////this.ReportViewer1.LocalReport.DataSources["Fotos"].Value = this.odsFotos;
                ////this.ReportViewer1.LocalReport.DataSources["Fotos"].DataSourceId = "odsFotos";


                switch(esExJur)
                {
                    case "0":
                        this.ReportViewer1.LocalReport.ReportPath = @"PersonasBuscadas\rptPersonaHalladaSinExJur.rdlc";
                        break;
                    case "1":
                        Microsoft.Reporting.WebForms.ReportDataSource dsExJur = new Microsoft.Reporting.WebForms.ReportDataSource("dsExtranaJurisdiccion", "odsExtrJur");
                        this.ReportViewer1.LocalReport.DataSources.Add(dsExJur);
                        this.ReportViewer1.LocalReport.ReportPath = @"PersonasBuscadas\rptPersonaHalladaConExJur.rdlc";
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


            // Supply a DataTable corresponding to each subreport dataset
            // The dataset name must match the name defined in the subreport
            e.DataSources.Add(new ReportDataSource((e.DataSourceNames[0]), this.odsSenasPart));
            e.DataSources.Add(new ReportDataSource((e.DataSourceNames[1]), this.odsTatuajes));
            e.DataSources.Add(new ReportDataSource((e.DataSourceNames[2]), this.odsFotos));
        }
    }
}
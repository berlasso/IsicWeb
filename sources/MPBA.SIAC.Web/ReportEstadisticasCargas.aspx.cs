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
    public partial class EstadisticasCargas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Session["moduloActual"] = "E";
                string tipo = Request.QueryString["r"];
                string agrupamiento = Request.QueryString["a"];
                Microsoft.Reporting.WebForms.ReportDataSource dsDelitos=null;
                switch (tipo)
                {
                    case "rh":
                    case "ds":
                    case "dpto":
                        switch (agrupamiento)
                        {
                            case "d"://dependencia
                                this.ReportViewer1.LocalReport.ReportPath = @"Estadisticas\rptEstadDelitosCargadosTotalDepto.rdlc";
                                dsDelitos = new Microsoft.Reporting.WebForms.ReportDataSource("dsEstadDelitosTotalDepto", "odsEstadDelitoTotalDepto");
                                break;
                            case "o"://operador
                                this.ReportViewer1.LocalReport.ReportPath = @"Estadisticas\rptEstadDelitosCargados.rdlc";
                                dsDelitos = new Microsoft.Reporting.WebForms.ReportDataSource("dsEstadDelitos", "odsEstadDelitosOperador");
                                break;
                            case "dpto"://dptos jud
                                this.ReportViewer1.LocalReport.ReportPath = @"Estadisticas\rptEstadDelitosCargadosTodosDeptos.rdlc";
                                dsDelitos = new Microsoft.Reporting.WebForms.ReportDataSource("dsEstadDelitosTotalDepto", "odsEstadDelitosTodosDeptos");
                                break;
                        }
                        
                      
                       this.ReportViewer1.LocalReport.Refresh();
                       this.ReportViewer1.LocalReport.DataSources.Add(dsDelitos);
                        break;
                    case "bpd":
                        Microsoft.Reporting.WebForms.ReportDataSource dsDesap=null;
                        switch (agrupamiento)
                        {
                            case "d"://dependencia
                                this.ReportViewer1.LocalReport.ReportPath = @"Estadisticas\rptEstadPersonasDesapCargadasTotalDepto.rdlc";
                                     dsDesap = new Microsoft.Reporting.WebForms.ReportDataSource("dsCargasDesapTotalDepto", "odsEstadPDTodosDeptos");
                                break;
                            case "o":
                                this.ReportViewer1.LocalReport.ReportPath = @"Estadisticas\rptEstadPersonasDesapCargadas.rdlc";
                                dsDesap = new Microsoft.Reporting.WebForms.ReportDataSource("dsCargasDesap", "odsEstadPersDesap");
                                break;
                            case "dpto"://dptos jud
                                this.ReportViewer1.LocalReport.ReportPath = @"Estadisticas\rptEstadPersonasDesapCargadasTodosDeptos.rdlc";
                                dsDesap = new Microsoft.Reporting.WebForms.ReportDataSource("dsDesapTotalDepto", "odsEstadPDTodosDeptos");
                                break;

                        }


                        this.ReportViewer1.LocalReport.Refresh();
                        
                        this.ReportViewer1.LocalReport.DataSources.Add(dsDesap);
                        break;
                    case "bph":
                        Microsoft.Reporting.WebForms.ReportDataSource dsHalladas = null;
                        switch (agrupamiento)
                        {
                            
                            case "d"://dependencia
                                this.ReportViewer1.LocalReport.ReportPath = @"Estadisticas\rptEstadPersonasHalladasCargadasTotalDepto.rdlc";
                                dsHalladas = new Microsoft.Reporting.WebForms.ReportDataSource("dsEstadisticasCargasTotalDepto", "odsEstadPHTodosDeptos");
                                break;
                            case "o":
                                this.ReportViewer1.LocalReport.ReportPath = @"Estadisticas\rptEstadPersonasHalladasCargadas.rdlc";
                                dsHalladas = new Microsoft.Reporting.WebForms.ReportDataSource("dsEstadisticasCargas", "odsEstadPersHalladas");
                                break;
                            case "dpto"://dptos jud
                                this.ReportViewer1.LocalReport.ReportPath = @"Estadisticas\rptEstadPersonasHalladasCargadasTodosDeptos.rdlc";
                                dsHalladas = new Microsoft.Reporting.WebForms.ReportDataSource("dsHalladasTotalDepto", "odsEstadPHTodosDeptos");
                                break;

                        }
                         this.ReportViewer1.LocalReport.Refresh();
                        
                        this.ReportViewer1.LocalReport.DataSources.Add(dsHalladas);
                        break;
                    case "IPP":
                        Microsoft.Reporting.WebForms.ReportDataSource dsIppXFecha = null;
                               this.ReportViewer1.LocalReport.ReportPath = @"Estadisticas\rptListadoIppsXFecha.rdlc";
                                dsIppXFecha = new Microsoft.Reporting.WebForms.ReportDataSource("dsListadoIppsXFecha", "odsListadoIppsXFecha");
                        this.ReportViewer1.LocalReport.Refresh();
                        this.ReportViewer1.LocalReport.DataSources.Add(dsIppXFecha);
                        break;
                }

                string titulo = Request.QueryString["titulo"];
                string depto = Request.QueryString["dpto"];
                string tituloDepto = DepartamentoManager.GetItem(Convert.ToInt32(depto)).departamento.Trim();

                string idPg = Session["miUFI"].ToString();
                int idDepto = MPBA.SIAC.Bll.PuntoGestionManager.GetItem(idPg, false).idDepartamento;
                string deptoJud = DepartamentoManager.GetItem(idDepto).departamento.Trim();
                string lugarFecha = deptoJud + ", " + DateTime.Today.ToString("dd") + " de " + (FuncionesGenerales.NombreMes)DateTime.Today.Month + " de " + DateTime.Today.Year;
                if (depto == "0")
                    tituloDepto = "Todos los Departamentos Judiciales";
                ReportParameterCollection reportParameters = new ReportParameterCollection();
                reportParameters.Add(new ReportParameter("Titulo", titulo));
                reportParameters.Add(new ReportParameter("TituloDepto", tituloDepto));
                reportParameters.Add(new ReportParameter("LugarFecha", lugarFecha));
                this.ReportViewer1.LocalReport.SetParameters(reportParameters);
                this.ReportViewer1.DataBind();
                this.ReportViewer1.LocalReport.Refresh();
                

            }
        }
    }
}
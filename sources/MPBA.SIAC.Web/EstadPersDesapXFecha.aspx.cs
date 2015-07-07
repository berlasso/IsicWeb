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
    public partial class EstadPersDesapXFecha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!this.IsPostBack)
                {
                    string dpto = Request.QueryString["dpto"];
                    this.divCartelPDXDep.InnerText = "Cant. de Personas Desaparecidas Por Dependencia en " + MPBA.SIAC.Bll.DepartamentoManager.GetItem(Convert.ToInt32(dpto), false).departamento.Trim();
                }
                //string fechaDesde = Request.QueryString["d"];
                //string fechaHasta = Request.QueryString["h"];
                //int idDepto = Convert.ToInt32(Request.QueryString["dpto"]);
                //PersDesapCantXDeptoXFechaList pds = MPBA.PersonasBuscadas.Bll.PersDesapCantXDeptoXFechaManager.GetList(fechaDesde, fechaHasta);
                //PersDesapCantXDependenciaXFechaList pddeps = PersDesapCantXDependenciaXFechaManager.GetList(fechaDesde, fechaHasta, idDepto);
                //this.chrPersDesapXDeptoXFecha.DataSourceID = "";
                //this.chrPersDesapXDeptoXFecha.DataSource = pds;
                
                //this.chrPersDesapXDeptoXFecha.DataBind();
                //this.chrPersDesapXDepenenciaXFecha.DataSourceID = "";
                //this.chrPersDesapXDepenenciaXFecha.DataSource = pddeps;
                //this.chrPersDesapXDepenenciaXFecha.DataBind();
                //this.gvPersDesapXDeptoXFecha.DataSource = pds;
                //this.gvPersDesapXDependenciaXFecha.DataSource = pddeps;
                //this.gvPersDesapXDeptoXFecha.DataBind();
                //this.gvPersDesapXDependenciaXFecha.DataBind();

            }
        }
    }
}
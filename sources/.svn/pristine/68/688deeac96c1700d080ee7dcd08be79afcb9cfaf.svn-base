using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Bll;

namespace MPBA.SIAC.Web
{
    public partial class EstadisticasSeleccion : System.Web.UI.Page
    {
        string TipoEstadistica = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            TipoEstadistica = Request.QueryString["tipo"];
            if (!this.IsPostBack)
            {
                Session["moduloActual"] = "EST";
                string idGrupo = Session["idGrupo"].ToString();//grupousuario al que pertenece el usuario actual
                this.ddlDepto.Enabled = idGrupo == "1";//si es superadministrador
                if (idGrupo != "1")
                {
                    foreach (ListItem li in this.ddlAgrupadoPor.Items)
                    {
                        if (li.Value == "dpto")
                        {
                            this.ddlAgrupadoPor.Items.Remove(li);
                            break;
                        }
                    }
                }
                string idPg = Session["miUFI"].ToString();
                string idDepto = MPBA.SIAC.Bll.PuntoGestionManager.GetItem(idPg, false).idDepartamento.ToString();
                this.ddlDepto.SelectedValue = idDepto;
                this.txtFechaDesde.Text = DateTime.Today.ToString("01/MM/yyyy");
                this.txtFechaHasta.Text = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month).ToString() + "/" + DateTime.Today.ToString("MM/yyyy");
                if (TipoEstadistica == "car")
                {
                    this.ddlModulo.Visible = true;
                    this.ddlTipoEstad.Visible = false;
                    this.lblAgrupadoPor.Visible = true;
                    this.ddlAgrupadoPor.Visible = true;
                }
                else
                {
                    this.ddlModulo.Visible = false;
                    this.ddlTipoEstad.Visible = true;
                    this.lblAgrupadoPor.Visible = false;
                    this.ddlAgrupadoPor.Visible = false;
                }
            }
        }

        protected void btnEstadistica_Click(object sender, EventArgs e)
        {
            string d = this.txtFechaDesde.Text.Trim();
            string h = this.txtFechaHasta.Text.Trim();
            string titulo = "";
            string agrupamiento = this.ddlAgrupadoPor.SelectedValue;
            string depto = this.ddlDepto.SelectedValue;
            switch (TipoEstadistica)
            {
                case "car": //cargas

                    string r = this.ddlModulo.SelectedValue;//tipo de reporte

                    switch (r)
                    {
                        case "IPP":
                            titulo = "IPPs cargadas entre el " + d + " y " + h;
                         
                                    this.ifEstadisticas.Attributes["src"] = "ReportEstadisticasCargas.aspx?d=" + d + "&h=" + h + "&titulo=" + titulo + "&dpto="+depto + "&r=" + r + "&a=" + agrupamiento;
                                    this.ifEstadisticas.Visible = true;
                                   
                        
                            break;
                        case "mo":
                            titulo = "Delitos cometidos entre el " + d + " y " + h;
                            switch (agrupamiento)
                            {
                                case "d"://dependencia
                                case "o"://operador
                                    this.ifEstadisticas.Attributes["src"] = "ReportEstadisticasDelitos.aspx?d=" + d + "&h=" + h + "&dpto=" + depto + "&titulo=" + titulo + "&r=" + r + "&a=" + agrupamiento;
                                    this.ifEstadisticas.Visible = true;
                                    break;
                            }
                            break;
                        case "bpd":
                            // this.ifEstadisticas.Attributes["src"] = @"\Estadisticas\EstadPersDesapXFecha.aspx?d=" + d + "&h=" + h+"&dpto="+depto+"&r="+r;
                            titulo = "Cantidad de Personas Desaparecidas cargadas entre el " + d + " y " + h;
                            switch (agrupamiento)
                            {
                                case "d"://dependencia
                                case "o"://operador
                                case "dpto"://dptos jud
                                    this.ifEstadisticas.Attributes["src"] = "ReportEstadisticasCargas.aspx?d=" + d + "&h=" + h + "&dpto=" + depto + "&titulo=" + titulo + "&r=" + r + "&a=" + agrupamiento;
                                    this.ifEstadisticas.Visible = true;
                                    break;

                            }


                            //this.ifEstadisticas.Visible = true;
                            //Response.Redirect( @"\EstadPersDesapXFecha.aspx?d=" + d + "&h=" + h+"&dpto="+depto+"&r="+r);
                            break;
                        case "bph":
                            //this.ifEstadisticas.Attributes["src"] = @"\Estadisticas\EstadPersHalladaXFecha.aspx?d=" + d + "&h=" + h + "&dpto=" + depto + "&r=" + r;
                            titulo = "Cantidad de Personas Halladas cargadas entre el " + d + " y " + h;
                            switch (agrupamiento)
                            {
                                case "d"://dependencia
                                case "o"://operador
                                case "dpto"://dptos jud
                                    this.ifEstadisticas.Attributes["src"] = "ReportEstadisticasCargas.aspx?d=" + d + "&h=" + h + "&dpto=" + depto + "&titulo=" + titulo + "&r=" + r + "&a=" + agrupamiento;
                                    this.ifEstadisticas.Visible = true;
                                    break;
                            }


                            //Response.Redirect(@"\EstadPersDesapXFecha.aspx?d=" + d + "&h=" + h);
                            break;
                        case "rh":
                            //this.ifEstadisticas.Attributes["src"] = @"\Estadisticas\EstadRobosHurtosXFecha.aspx?t=1&d=" + d + "&h=" + h + "&dpto=" + depto;
                            titulo = "Cantidad de Robos y Hurtos cargados entre el " + d + " y " + h;
                            switch (agrupamiento)
                            {
                                case "d"://dependencia
                                case "o"://operador
                                case "dpto"://dptos jud
                                    this.ifEstadisticas.Attributes["src"] = "ReportEstadisticasCargas.aspx?t=1&d=" + d + "&h=" + h + "&dpto=" + depto + "&titulo=" + titulo + "&r=" + r + "&a=" + agrupamiento;
                                    this.ifEstadisticas.Visible = true;
                                    break;
                            }


                            //Response.Redirect(@"\EstadPersDesapXFecha.aspx?d=" + d + "&h=" + h);
                            break;
                        case "ds":
                            // this.ifEstadisticas.Attributes["src"] = @"\Estadisticas\EstadDelitosSexualesXFecha.aspx?t=2&d=" + d + "&h=" + h + "&dpto=" + depto;
                            titulo = "Cantidad de Delitos Sexuales cargados entre el " + d + " y " + h;
                            switch (agrupamiento)
                            {
                                case "d"://dependencia
                                case "o"://operador
                                case "dpto"://dptos jud
                                    this.ifEstadisticas.Attributes["src"] = "ReportEstadisticasCargas.aspx?t=2&d=" + d + "&h=" + h + "&dpto=" + depto + "&titulo=" + titulo + "&r=" + r + "&a=" + agrupamiento;
                                    this.ifEstadisticas.Visible = true;
                                    break;
                            }
                            break;

                    }
                    break;
                case "del": //estadisticas delitos
                    string est = this.ddlTipoEstad.SelectedValue;//tipo de reporte
                    switch (est)
                    {
                        case "mo":
                            titulo = "Modus Operandi cargados entre el " + d + " y " + h;
                            this.ifEstadisticas.Attributes["src"] = "ReportEstadisticasDelitos.aspx?d=" + d + "&h=" + h + "&dpto=" + depto + "&titulo=" + titulo + "&r=" + est;
                            this.ifEstadisticas.Visible = true;
                            break;
                    }
                    break;

            }
          //  this.upEstadisticas.Update();
        }

        protected void ddlAgrupadoPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlAgrupadoPor.SelectedValue == "dpto")
            {
                this.ddlDepto.SelectedValue = "0";
                this.ddlDepto.Enabled = false;
            //    this.upEstadisticas.Update();
            }
            else
            {
                if (this.ddlDepto.Enabled == false)
                {
                    this.ddlDepto.Enabled = true;
              //      this.upEstadisticas.Update();
                }
            }
            this.ifEstadisticas.Attributes["src"] = "";
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.ifEstadisticas.Attributes["src"] = "";

        }

        protected void ddlModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlModulo.SelectedValue == "IPP")
            {
                this.ddlAgrupadoPor.Visible = false;
                this.lblAgrupadoPor.Visible = false;
                this.ddlDepto.SelectedValue = "0";
            }
            else
            {
                this.lblAgrupadoPor.Visible = true;
                this.ddlAgrupadoPor.Visible = true;
            }
            this.ifEstadisticas.Attributes["src"] = "";
           // this.ifEstadisticas.Visible = false;
        }
    }
}
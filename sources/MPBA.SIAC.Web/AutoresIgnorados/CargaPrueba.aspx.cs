using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPBA.AutoresIgnorados.Bll;
using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Web
{
    public partial class CargaPrueba : System.Web.UI.Page
    {
        //private static Delitos miDelito;
        //private static Rastros miRastro;//lo uso para editar o dar de alta

        #region "Eventos"
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //bool esConsulta = Request.QueryString["c"].ToString() == "1" ? true : false;
                //if (esConsulta)
                //{
                //    this.pnlPruebas.Enabled = false;
                //    this.btnGuardarDelito.Enabled = false;
                //}
            
                LimpiarControles();
                LlenarControles();
                IndicarStatus();
                
            }
            //this.pnlGuardoBien.Style.Add("display", "none");
        }

        protected void btnOkPrueba_Click(object sender, EventArgs e)
        {
            Delitos miDelito = (Delitos)Session["miDelito"];
            GuardarBien();
            this.gvPrueba.DataSource = "";
            this.gvPrueba.DataSource = miDelito.rastross.FindAll(delegate(Rastros Rt) { return Rt.Baja == false; });
            this.gvPrueba.DataBind();
            this.PanelPrueba.Style.Add("display", "none");
            this.pnlGuardoBien.Style.Add("display", "none");
            this.hfGestionPrueba_ModalPopupExtender.Hide();
            Session["miRastro"] = null;
            //this.btnNuevo0_ModalPopupExtender.Hide();
        }

        protected void gvPrueba_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
            Delitos miDelito = (Delitos)Session["miDelito"];
            List<Rastros> rastros = miDelito.rastross.FindAll(delegate(Rastros Rt) { return Rt.Baja == false; });
            Rastros rastro = rastros[e.RowIndex];
            if (rastro.id == -1)
            {
                for (int i = 0; i < miDelito.rastross.Count; i++)
                {
                    if (rastro.Equals(miDelito.rastross[i]))
                    {
                        Rastros ra = miDelito.rastross[i];
                        miDelito.rastross.Remove(ra);
                    }
                }
            }
            else
            {
                rastro.Baja = true;
            }
            this.gvPrueba.DataSource = null;
            this.gvPrueba.DataSource = miDelito.rastross.FindAll(delegate(Rastros Rt) { return Rt.Baja == false; });
            this.gvPrueba.DataBind();
        }

        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            bool esConsulta = Request.QueryString["c"].ToString() == "1" ? true : false;
            if (esConsulta)
                Response.Redirect("CargaBienesSustraidos.aspx?c=1");
            else
                Response.Redirect("CargaBienesSustraidos.aspx?c=0");
        }

        protected void btnGuardarDelito_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            GuardarDelito();
            Delitos miDelito = (Delitos)Session["miDelito"];
            if (DelitosManager.Save(miDelito) > 0)
            {
                this.btnGuardarDelito_ModalPopupExtender.Enabled = true;
                this.btnGuardarDelito_ModalPopupExtender.Show();
            }
        }

        protected void btnAceptarCartelExito_Click(object sender, EventArgs e)
        {
            string tipo = ((Delitos)Session["miDelito"]).idClaseDelito.ToString();
            Session["miDelito"] = null;
            bool esConsulta = Request.QueryString["c"].ToString() == "1" ? true : false;
            Response.Redirect("CargaVictimas.aspx?tipo=1"+tipo+"&status=1&C="+esConsulta);
        }

        protected void btnNuevo0_Click(object sender, EventArgs e)
        {
            LimpiarControlesPanelRastro();
            
            Session["miRastro"] = null;
            //this.btnNuevo0_ModalPopupExtender.Show();
            this.hfGestionPrueba_ModalPopupExtender.Show();
        }

        protected void btnCancelarRastro_Click(object sender, EventArgs e)
        {
            this.PanelPrueba.Style.Add("display", "none");
            this.hfGestionPrueba_ModalPopupExtender.Hide();
            //this.btnNuevo0_ModalPopupExtender.Hide();
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session["miDelito"] = null;
            Session["moduloActual"] = null;
            Response.Redirect("~/Home.aspx");
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            Delitos miDelito = (Delitos)Session["miDelito"];
            DelitosManager.Save(miDelito);
        }

        protected void gvPrueba_SelectedIndexChanged(object sender, EventArgs e)
        {
            Delitos miDelito = (Delitos)Session["miDelito"];
            List<Rastros> rastros = miDelito.rastross.FindAll(delegate(Rastros Rt) { return Rt.Baja == false; });
            Session["miRastro"] = rastros[this.gvPrueba.SelectedIndex];
            LimpiarControlesPanelRastro();
            LlenarControlesPanelRastro();
            this.hfGestionPrueba_ModalPopupExtender.Show();
            //this.btnNuevo0_ModalPopupExtender.Show();
        }

        #endregion

        #region "Metodos"
        private void IndicarStatus()
        {
            Delitos miDelito = (Delitos)Session["miDelito"];
            if (miDelito.id ==-1)
            {
                this.lblCondicionCarga.Text = "NUEVO";
                this.lblCondicionCarga.Style.Add("color", "Blue");
            }
            else
            {
                this.lblCondicionCarga.Text = "MODIFICANDO";
                this.lblCondicionCarga.Style.Add("color", "Red");
            }
            bool esConsulta = Request.QueryString["c"].ToString() == "1" ? true : false;
            if (esConsulta)
            {
                this.lblCondicionCarga.Text = "CONSULTANDO";
                this.lblCondicionCarga.Style.Add("color", "Green");
            }
        }

        private void LimpiarControles()
        {
            this.ddlCantidadAutoresRec.SelectedValue = "0"; //Antes era 11 indeterminado
            this.ddlCantidadVictimas.SelectedValue="0";//Antes era 11 indeterminado
           // this.ddlSusceptibleCotejo.SelectedValue="No";
                                                       //NNClaseCantAutores era 11 indeterminado ahora 0
            this.PanelPrueba.Style.Add("display", "none");
            this.pnlGuardoBien.Style.Add("display", "none");

        }

        private void LlenarControles()
        {
            Delitos miDelito = (Delitos)Session["miDelito"];
            this.ddlCantidadAutoresRec.SelectedValue = Convert.ToString(miDelito.idClaseCantAutorReconocidos);
            this.ddlCantidadVictimas.SelectedValue = Convert.ToString(miDelito.idVicTestRecRueda);
            this.gvPrueba.DataSource = miDelito.rastross.FindAll(delegate(Rastros Rt) { return Rt.Baja == false; });
            this.gvPrueba.DataBind();
            
        }

        private void GuardarBien()
        {
            Delitos miDelito = (Delitos)Session["miDelito"];
            Rastros miRastro = (Rastros)Session["miRastro"];
            bool esNuevoRastro = (miRastro == null);//si es nulo estoy dando de alta
            if (esNuevoRastro)
            {
                miRastro = new Rastros();
                miRastro.id = -1;
            }
            miRastro.idCausa = miDelito.idCausa;
            miRastro.idClaseRastro = Convert.ToInt32(this.ddlRastro.SelectedValue);
            miRastro.idClaseEstadoInformeRastro = Convert.ToInt32(this.ddlEstadoInforme.SelectedValue);
            miRastro.SusceptibleCotejoRastro = this.ddlSusceptibleCotejo.Text.Trim()=="1"?true:false;
            miRastro.Descripcion = this.txtDescripcion.Text.Trim();
            miRastro.FechaUltimaModificacion = DateTime.Now;

            miRastro.idUsuarioUltimaModificacion = Session["miUsuario"].ToString();
            if (esNuevoRastro)
                miDelito.rastross.Add(miRastro);
            Session["miRastro"] = null;

        }

        private void LlenarControlesPanelRastro()
        {
            Rastros miRastro = (Rastros)Session["miRastro"];
            this.ddlEstadoInforme.SelectedValue = miRastro.idClaseEstadoInformeRastro.ToString();
            this.ddlRastro.SelectedValue = miRastro.idClaseRastro.ToString();
            this.ddlSusceptibleCotejo.SelectedIndex = miRastro.SusceptibleCotejoRastro? 1 : 0;
            if (ddlRastro.SelectedValue == "7") //es una evidencia (Otro/a)
            {
                this.txtDescripcion.Text = miRastro.Descripcion.Trim();
                this.lblDescripcion.Visible = true;
                this.txtDescripcion.Visible = true;
                this.lblSusceptibleCotejo.Visible = false;
                this.ddlSusceptibleCotejo.SelectedIndex = 1;//si es una evidencia (Otro/s) es susceptible de cotejo
                this.ddlSusceptibleCotejo.Visible = false;
            }
            else
            {
                this.lblDescripcion.Visible = false;
                this.txtDescripcion.Visible = false;
                this.lblSusceptibleCotejo.Visible = true;
                this.ddlSusceptibleCotejo.Visible = true;
            }
        }

        private void GuardarDelito()
        {
            Delitos miDelito = (Delitos)Session["miDelito"];
            miDelito.idClaseCantAutorReconocidos = Convert.ToInt16(this.ddlCantidadAutoresRec.SelectedValue);
            miDelito.idVicTestRecRueda = Convert.ToInt16(this.ddlCantidadVictimas.SelectedValue);
            miDelito.FechaUltimaModificacion = DateTime.Now;
            miDelito.idUsuarioUltimaModificacion = Session["miUsuario"].ToString();
            if (miDelito.id == -1)
            {
                miDelito.idUsuarioAlta = Session["miUsuario"].ToString();
                miDelito.FechaAlta = DateTime.Now;
            }
            Session["miDelito"] = miDelito;
        }
        #endregion

        protected void ddlRastro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRastro.SelectedValue == Convert.ToString(7))
            {
                this.txtDescripcion.Text = "";
                this.lblDescripcion.Visible = true;
                this.txtDescripcion.Visible = true;
                this.lblSusceptibleCotejo.Visible = false;
                this.ddlSusceptibleCotejo.Visible = false;
                this.ddlSusceptibleCotejo.SelectedIndex = 1;//si es una evidencia (Otro/s) es susceptible de cotejo
            }
            else
            {
                this.lblDescripcion.Visible = false;
                this.txtDescripcion.Visible = false;
                this.ddlSusceptibleCotejo.SelectedIndex = 0;
                this.lblSusceptibleCotejo.Visible = true;
                this.ddlSusceptibleCotejo.Visible = true;
            }
        }
        private void LimpiarControlesPanelRastro()
        {
            this.ddlRastro.SelectedValue = "1";
            this.ddlEstadoInforme.SelectedValue = "0";
            this.lblSusceptibleCotejo.Visible = true;
            this.ddlSusceptibleCotejo.Visible = true;
            this.ddlSusceptibleCotejo.SelectedIndex = 0;
            this.txtDescripcion.Text = "";
            this.lblDescripcion.Visible = false;
            this.txtDescripcion.Visible = false;

        }

        protected void ddlRastro_DataBound(object sender, EventArgs e)
        {
            //Delitos miDelito = (Delitos)Session["miDelito"];
            
            //if (miDelito.idClaseDelito == 1)//robos y hurtos
            //{
            //    foreach (ListItem item in this.ddlRastro.Items)
            //    {
            //        if (item.Text.Trim().ToLower() == "adn")
            //        {
            //            this.ddlRastro.Items.Remove(item);
            //            break;
            //        }
            //    }
            //}
        }

       
     

     
    }
}

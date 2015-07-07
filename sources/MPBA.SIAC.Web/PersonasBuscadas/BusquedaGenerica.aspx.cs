using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPBA.PersonasBuscadas.Bll;
using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.SIAC.BusinessEntities;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Mail;
using System.Xml;
using System.Data;
using System.Web.Routing;
using System.Web.Mvc;


namespace MPBA.PersonasBuscadas.Web
{

    public partial class BusquedaGenerica : System.Web.UI.Page
    {
       
       
        Busqueda PersonasBuscadas;//contiene los datos de la busqueda realizada
        SeniasParticularesList Senias;
        System.Windows.Forms.BindingSource FotosGralesD; //me permite itirerar por la coleccion de fotos grales de la IPP en uso
        System.Windows.Forms.BindingSource FotosGralesBI; //me permite itirerar por la coleccion de fotos grales de la IPP en uso para la ficha de busq individual
        System.Windows.Forms.BindingSource FotosSeniasD; //me permite itirerar por la coleccion de fotos de senias part de la IPP en uso
        System.Windows.Forms.BindingSource FotosSeniasBI; //me permite itirerar por la coleccion de fotos de senias part de la IPP en uso para la ficha de busq indivicual;
        TatuajesPersonaList TatuajesD;
        TatuajesPersonaList TatuajesH;
        TatuajesPersonaList TatuajesBI;
        SeniasParticularesList SeniasD;
        SeniasParticularesList SeniasH;
        SeniasParticularesList SeniasBI;


        protected void Page_Load(object sender, EventArgs e)
        {
            //resalta en el menu, el modulo en el que estoy actualmente
            Session["moduloActual"] = "BP";
            
            //**********************
            //CAMBIAR
            //**********************
            //Session["miUsuario"] = "nn";
            //Session["miUfi"] = "xx";
            //*********************
            FotosGralesD = Session["FotosGralesD"] == null ? new System.Windows.Forms.BindingSource() : (System.Windows.Forms.BindingSource)Session["FotosGralesD"];
            FotosSeniasD = Session["FotosSeniasD"] == null ? new System.Windows.Forms.BindingSource() : (System.Windows.Forms.BindingSource)Session["FotosSeniasD"];
            FotosGralesBI = Session["FotosGralesBI"] == null ? new System.Windows.Forms.BindingSource() : (System.Windows.Forms.BindingSource)Session["FotosGralesBI"];
            FotosSeniasBI = Session["FotosSeniasBI"] == null ? new System.Windows.Forms.BindingSource() : (System.Windows.Forms.BindingSource)Session["FotosSeniasBI"];
            TatuajesD = Session["TatuajesD"] == null ? new TatuajesPersonaList() : (TatuajesPersonaList)Session["TatuajesD"];
            TatuajesH = Session["TatuajesH"] == null ? new TatuajesPersonaList() : (TatuajesPersonaList)Session["TatuajesH"];
            TatuajesBI = Session["TatuajesBI"] == null ? new TatuajesPersonaList() : (TatuajesPersonaList)Session["TatuajesBI"];
            SeniasD = Session["SeniasD"] == null ? new SeniasParticularesList() : (SeniasParticularesList)Session["SeniasD"];
            SeniasH = Session["SeniasH"] == null ? new SeniasParticularesList() : (SeniasParticularesList)Session["SeniasH"];
            SeniasBI = Session["SeniasBI"] == null ? new SeniasParticularesList() : (SeniasParticularesList)Session["SeniasBI"];

            this.btnAgregarBusquedaFavoritos.Style.Add("display", "none");
            this.btnBusquedasFavoritas.Visible = false;
            PersonasBuscadas = Session["miPersonaBuscada"] != null ? (Busqueda)Session["miPersonaBuscada"] : null;
            Senias = Session["misSenias"] == null ? new SeniasParticularesList() : (SeniasParticularesList)Session["misSenias"];
            if (!IsPostBack)
            {
                //MPBA.PersonasBuscadas.Web.MasterPage Master = (MPBA.PersonasBuscadas.Web.MasterPage)this.Master;
                //Master.MenuPrincipal.FindItem("Busqueda").Selected = true;
                
                this.pnlExito.Style.Add("display", "none");
                this.pnlResultadosBI.Style.Add("display", "none");
                this.pnlCantCoincidencias.Style.Add("display", "none");
                LimpiarControlesB();
                this.btnBuscarOtros.Enabled = false;
                this.tblBuscarIpp.Visible = false;
                this.cartelTipoBusqueda.InnerText = "BUSCAR POR CRITERIOS VARIOS";
                //Seteo controles UpdateProgess
                Panel pnlWaitingOverlayBusquedas = (Panel)this.upWaitingBusquedas.FindControl("pnlWaitingOverlayBusquedas");
                Panel pnlWaitingBusquedas = (Panel)this.upWaitingBusquedas.FindControl("pnlWaitingBusquedas");
                pnlWaitingOverlayBusquedas.CssClass = "overlay";
                pnlWaitingBusquedas.CssClass = "loader";
            }
        }

        /// <summary>
        /// Limpia los controles de la Busqueda Generica
        /// </summary>
        private void LimpiarControlesB()
        {
            Session["imgPreview"] = null;
            Session["TipoBusquedaPersonas"] = null;
            this.lblCantResultados.Text = "";
            this.btnAgregarBusquedaFavoritos.Style.Add("display", "none");
            this.txtEdadDesdeB.Text = "";
            this.txtEdadHastaB.Text = "";
            this.txtFechaDesdeB.Text = "";
            this.txtFechaHastaB.Text = "";
            this.txtPesoDesdeB.Text = "";
            this.txtPesoHastaB.Text = "";
            this.txtTallaDesdeB.Text = "";
            this.txtTallaHastaB.Text = "";
            this.txtIppB.Text = "";
            this.txtApellidoB.Text = "";
            this.txtNombresB.Text = "";

            //elimino 'seleccionar' de la lista de opciones
            //**********
            this.lstAspectoCabelloB.DataSourceID = "";
            this.lstAspectoCabelloB.DataSource = PBClaseAspectoCabelloManager.GetList().FindAll(delegate(PBClaseAspectoCabello ac) { return ac.Id != 0 && ac.Id !=1; });
            this.lstAspectoCabelloB.DataBind();

            this.lstCalvicieB.DataSourceID = "";
            this.lstCalvicieB.DataSource = PBClaseCalvicieManager.GetList().FindAll(delegate(PBClaseCalvicie c) { return c.Id != 0 && c.Id != 1; });
            this.lstCalvicieB.DataBind();

            this.ddlAdnB.DataSourceID = "";
            this.ddlAdnB.DataSource = PBClaseBooleanManager.GetList().FindAll(delegate(PBClaseBoolean b) { return b.Id != 0 && b.Id != 1; });
            this.ddlAdnB.DataBind();

            this.lstColorCabelloB.DataSourceID = "";
            this.lstColorCabelloB.DataSource = PBClaseColorCabelloManager.GetList().FindAll(delegate(PBClaseColorCabello cc) { return cc.Id != 0 && cc.Id != 1; });
            this.lstColorCabelloB.DataBind();

            this.lstColorOjosB.DataSourceID = "";
            this.lstColorOjosB.DataSource = PBClaseColorOjosManager.GetList().FindAll(delegate(PBClaseColorOjos co) { return co.Id != 0 && co.Id != 1; });
            this.lstColorOjosB.DataBind();

            this.lstColorPielB.DataSourceID = "";
            this.lstColorPielB.DataSource = PBClaseColorDePielManager.GetList().FindAll(delegate(PBClaseColorDePiel cp) { return cp.Id != 0 && cp.Id != 1; });
            this.lstColorPielB.DataBind();

            this.lstColorTenidoB.DataSourceID = "";
            this.lstColorTenidoB.DataSource = PBClaseColorCabelloManager.GetList().FindAll(delegate(PBClaseColorCabello ct) { return ct.Id != 0 && ct.Id != 1; });
            this.lstColorTenidoB.DataBind();

            this.lstLongitudCabelloB.DataSourceID = "";
            this.lstLongitudCabelloB.DataSource = PBClaseLongitudCabelloManager.GetList().FindAll(delegate(PBClaseLongitudCabello lc) { return lc.Id != 0 && lc.Id != 1; });
            this.lstLongitudCabelloB.DataBind();

            this.lstSexoB.DataSourceID = "";
            this.lstSexoB.DataSource = PBClaseSexoManager.GetList().FindAll(delegate(PBClaseSexo s) { return s.Id != 0 && s.Id != 1; });
            this.lstSexoB.DataBind();

            this.ddlFaltanPiezasDentalesB.DataSourceID = "";
            this.ddlFaltanPiezasDentalesB.DataSource = PBClaseBooleanManager.GetList().FindAll(delegate(PBClaseBoolean fpd) { return fpd.Id != 0 && fpd.Id != 1; });
            this.ddlFaltanPiezasDentalesB.DataBind();

            //***********

            Senias = new SeniasParticularesList();
            Session["misSenias"] = Senias;
            Session["ResultadoBusquedaPersonas"] = null;
            this.gvSenasPartB.DataSource = Senias;
            this.gvSenasPartB.DataBind();
            foreach (ListItem item in this.lstAspectoCabelloB.Items)
            {
                item.Selected = false;
            }
            foreach (ListItem item in this.lstCalvicieB.Items)
            {
                item.Selected = false;
            }
            foreach (ListItem item in this.lstColorCabelloB.Items)
            {
                item.Selected = false;
            }
            foreach (ListItem item in this.lstColorOjosB.Items)
            {
                item.Selected = false;
            }
            foreach (ListItem item in this.lstColorPielB.Items)
            {
                item.Selected = false;
            }
            foreach (ListItem item in this.lstColorTenidoB.Items)
            {
                item.Selected = false;
            }
            foreach (ListItem item in this.lstLongitudCabelloB.Items)
            {
                item.Selected = false;
            }
            foreach (ListItem item in this.lstSexoB.Items)
            {
                item.Selected = false;
            }
            this.ddlFaltanPiezasDentalesB.SelectedValue = "2";
            this.gvResultadoBusquedaPersonasHalladas.Visible = false;
            this.gvResultadoBusquedaPersonasDesap.Visible = false;
            this.btnGuardarBusqueda.Style.Add("display", "none");
            this.btnBorrarBusqueda.Style.Add("display", "none");
            this.gvResultadoBusquedaPersonasHalladas.DataSource = "";
            this.gvResultadoBusquedaPersonasDesap.DataSource = "";
            this.gvResultadoBusquedaPersonasHalladas.DataBind();
            this.gvResultadoBusquedaPersonasDesap.DataBind();
            PersonasBuscadas = null;
            Session["miPersonaBuscada"] = null;
            //****************8
            //CONTROLAR
            this.ddlCantCoincidencias.SelectedValue = "1";
            //this.ddlCantCoincReqB.SelectedValue = "0";
            //******************
           
            this.lblGuardoExitoB.Visible = false;
            this.divResultados.Style.Add("display", "none");


        }

        protected void gvResultadoBusquedaParsonasHalladas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(this.gvResultadoBusquedaPersonasHalladas.DataKeys[e.RowIndex].Value);
            if (MPBA.PersonasBuscadas.Bll.PersonasHalladasManager.Delete(MPBA.PersonasBuscadas.Bll.PersonasHalladasManager.GetItem(id)))
                this.gvResultadoBusquedaPersonasHalladas.Rows[e.RowIndex].Visible = false;
          
        }

        protected void gvResultadoBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.ddlTipoBusqueda.SelectedValue)
            {
                case "1"://desaparecidas
                    {

                        int id = Convert.ToInt32(this.gvResultadoBusquedaPersonasDesap.SelectedValue.ToString());
                        PersonasDesaparecidas pd = PersonasDesaparecidasManager.GetItem(id, true);
                        LimpiarControlesFichaPersDesapBI();
                        LlenarControlesFichaPersDesapBI(pd);
                        this.hfOkFichaBID.Value = id.ToString();
                        this.hfGestionFichaPersDesapBI_ModalPopupExtender.Enabled = true;
                        this.pnlResultadosBI.Visible = true;
                        this.hfGestionFichaPersDesapBI_ModalPopupExtender.Show();
                        this.hfAbrirResultadosBI_ModalPopupExtender1.Hide();
                        break;
                    }
                case "2": //halladas
                    {
                        int id = Convert.ToInt32(this.gvResultadoBusquedaPersonasHalladas.SelectedValue.ToString());
                        PersonasHalladas ph = PersonasHalladasManager.GetItem(id, true);
                        LimpiarControlesFichaPersHalladaBI();
                        LlenarControlesFichaPersHalladaBI(ph);
                        this.hfOkFichaBIH.Value = id.ToString();
                        this.hfGestionFichaPersHalladaBI_ModalPopupExtender.Enabled = true;
                        this.pnlResultadosBI.Visible = true;
                        this.hfGestionFichaPersHalladaBI_ModalPopupExtender.Show();
                        this.hfAbrirResultadosBI_ModalPopupExtender1.Hide();
                        break;

                       
                    }
            }
        }

        protected void gvResultadoBusquedaParsonasDesap_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(this.gvResultadoBusquedaPersonasDesap.DataKeys[e.RowIndex].Value);
            if (MPBA.PersonasBuscadas.Bll.PersonasDesaparecidasManager.Delete(MPBA.PersonasBuscadas.Bll.PersonasDesaparecidasManager.GetItem(id)))
                this.gvResultadoBusquedaPersonasDesap.Rows[e.RowIndex].Visible = false;
          
        }

        protected void btnLimpiarB_Click(object sender, EventArgs e)
        {
            LimpiarControlesB();
        }
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session["idBusqueda"]=null;
            Session["moduloActual"] = null;//no resalta menu
            Response.Redirect("~/Home.aspx");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.pnlCantCoincidencias.Style.Remove("display");
            this.hfCantCoincidencias_ModalPopupExtender.Show();
        }

        private void Buscar()
        {
            FuncionesGrales.TipoBusqueda tipoBusqueda = (FuncionesGrales.TipoBusqueda)Enum.Parse(typeof(FuncionesGrales.TipoBusqueda), this.ddlTipoBusqueda.SelectedValue, true);
            Busqueda busqueda = GuardarDatosBusqueda(tipoBusqueda);
            //RealizarBusqueda((TipoBusqueda)Enum.Parse(typeof(TipoBusqueda), PersonasBuscadas.idOrigen.ToString().Trim(),true));
            //RealizarBusqueda(busqueda, (FuncionesGrales.TipoBusqueda)Enum.Parse(typeof(FuncionesGrales.TipoBusqueda), busqueda.idOrigen.ToString().Trim(), true));
            RealizarBusqueda(busqueda,tipoBusqueda);
            this.lblGuardoExitoB.Visible = false;
            
        }

        /// <summary>
        /// Trae la persona desaparecida de acuerdo a los datos de busqueda
        /// </summary>
        /// <param name="parametrosBusqueda">parametros de busqueda</param>
        /// <returns>persona desaparecida que coincide con los datos de busqueda</returns>
        private PersonasDesaparecidasList TraerPersonasDesaparecidas(Busqueda parametrosBusqueda)
        {
            PersonasDesaparecidasList pl = new PersonasDesaparecidasList();
            return MPBA.PersonasBuscadas.Bll.PersonasDesaparecidasManager.GetList(parametrosBusqueda);
        }

        /// <summary>
        /// Trae la persona hallada de acuerdo a los datos de busqueda
        /// </summary>
        /// <param name="parametrosBusqueda">parametros de busqueda</param>
        /// <returns>persona hallada que coincide con los datos de busqueda</returns>
        private PersonasHalladasList TraerPersonasHalladas(Busqueda parametrosBusqueda)
        {
            PersonasHalladasList pl = new PersonasHalladasList();
            return MPBA.PersonasBuscadas.Bll.PersonasHalladasManager.GetList(parametrosBusqueda);
        }


        /// <summary>
        /// Realiza la busqueda generica
        /// </summary>
        /// <param name="busqueda">parametros de busqueda</param>
        /// <param name="tipoBusqueda">tipo de busqueda a realizar</param>
        private void RealizarBusqueda(Busqueda busqueda, FuncionesGrales.TipoBusqueda tipoBusqueda)
        {
            Session["TipoBusquedaPersonas"] =tipoBusqueda;
            switch (tipoBusqueda)
            {
                case FuncionesGrales.TipoBusqueda.PersonaDesaparecida:
                    List<MPBA.PersonasBuscadas.BusinessEntities.PersonasDesaparecidas> personasDesaparecidas = TraerPersonasDesaparecidas(busqueda).FindAll(delegate(MPBA.PersonasBuscadas.BusinessEntities.PersonasDesaparecidas pd) { return pd.Baja == false; });
                    this.gvResultadoBusquedaPersonasDesap.DataSource = personasDesaparecidas;
                    Session["ResultadoBusquedaPersonas"] = personasDesaparecidas;
                    
                    if (personasDesaparecidas.Count > 0)
                        this.divResultados.Style.Remove("display");
                    else
                        this.divResultados.Style.Add("display", "none");
                    this.gvResultadoBusquedaPersonasDesap.DataBind();
                    this.gvResultadoBusquedaPersonasDesap.Visible = true;
                    this.gvResultadoBusquedaPersonasDesap.Focus();
                    this.gvResultadoBusquedaPersonasHalladas.Visible = false;
                    break;
                case FuncionesGrales.TipoBusqueda.PersonaHallada:
                    List<MPBA.PersonasBuscadas.BusinessEntities.PersonasHalladas> personasHalladas = TraerPersonasHalladas(busqueda).FindAll(delegate(MPBA.PersonasBuscadas.BusinessEntities.PersonasHalladas ph) { return  ph.Baja == false; });
                    this.gvResultadoBusquedaPersonasHalladas.DataSource = personasHalladas;
                    Session["ResultadoBusquedaPersonas"] = personasHalladas;
                    if (personasHalladas.Count > 0)
                    {
                        this.btnAgregarBusquedaFavoritos.Style.Remove("display");
                        this.divResultados.Style.Remove("display");
                    }
                    else
                    {
                        this.btnAgregarBusquedaFavoritos.Style.Add("display", "none");
                        this.divResultados.Style.Add("display", "none");
                    }
                    this.gvResultadoBusquedaPersonasHalladas.DataBind();
                    this.gvResultadoBusquedaPersonasHalladas.Visible = true;
                    this.gvResultadoBusquedaPersonasHalladas.Focus();
                    //this.gvResultadoBusquedaPersonasDesap.Visible = false;
                    break;

            }

        }


        /// <summary>
        /// Guarda los datos de la busqueda
        /// </summary>
        /// <param name="tipoBusqueda">tipo de busqueda de que se trata</param>
        /// <returns></returns>
        private Busqueda GuardarDatosBusqueda(FuncionesGrales.TipoBusqueda tipoBusqueda)
        {
            int entero = 0;
            float flotante;
            DateTime fecha;
            Busqueda busqueda = new Busqueda();
            //PersonasBuscadas.BusinessEntities.Busqueda personasBuscadas = new Busqueda();
            //if (PersonasBuscadas == null)
            //    PersonasBuscadas = new Busqueda();
            if (busqueda.Id == 0)
                busqueda.Id = -1;
            busqueda.TablaDestino = null;
            //personasBuscadas.idOrigen = null;
            busqueda.idOrigen = Convert.ToInt32(this.ddlTipoBusqueda.SelectedValue);
            //busqueda.CodigoADN = this.txtAdnB.Text.Trim();
            //PersonasBuscadas.FechaActuaciones = null;
            if (Int32.TryParse(this.txtEdadDesdeB.Text.Trim(), out entero))
                busqueda.EdadDesde = entero;
            else
                busqueda.EdadDesde = null;
            if (Int32.TryParse(this.txtEdadHastaB.Text.Trim(), out entero))
                busqueda.EdadHasta = entero;
            else
                busqueda.EdadHasta = null;
            //busqueda.FaltanPiezasDentales = Convert.ToInt32(this.ddlFaltanPiezasDentalesB.SelectedValue);
            if (DateTime.TryParse(this.txtFechaDesdeB.Text.Trim(), out fecha))
                busqueda.FechaDesde = fecha;
            else
                busqueda.FechaDesde = null;
            if (DateTime.TryParse(this.txtFechaHastaB.Text.Trim(), out fecha))
                busqueda.FechaHasta = fecha;
            else
                busqueda.FechaHasta = null;
            //PersonasBuscadas.idAspectoCabello = Convert.ToInt32(this.ddlAspectoCabelloB.SelectedValue);
            foreach (ListItem item in this.lstAspectoCabelloB.Items)
            {
                if (item.Selected)
                {
                    BusquedaAspectoCabello bac = new BusquedaAspectoCabello();
                    bac.id = -1;
                    bac.idAspectoCabello = Convert.ToInt32(item.Value);
                    bac.idBusqueda = -1;
                    busqueda.busquedaAspectoCabellos.Add(bac);
                }
            }
            //PersonasBuscadas.idCalvicie = Convert.ToInt32(this.ddlCalvicieB.SelectedValue);
            foreach (ListItem item in this.lstCalvicieB.Items)
            {
                if (item.Selected)
                {
                    BusquedaCalvicie bc = new BusquedaCalvicie();
                    bc.id = -1;
                    bc.idClaseCalvicie = Convert.ToInt32(item.Value);
                    bc.idBusqueda = -1;
                    busqueda.busquedaCalvicies.Add(bc);
                }
            }
            //PersonasBuscadas.idColorCabello = Convert.ToInt32(this.ddlColorCabelloB.SelectedValue);
            foreach (ListItem item in this.lstColorCabelloB.Items)
            {
                if (item.Selected)
                {
                    BusquedaColorCabello bcc = new BusquedaColorCabello();
                    bcc.id = -1;
                    bcc.idClaseColorCabello = Convert.ToInt32(item.Value);
                    bcc.idBusqueda = -1;
                    busqueda.busquedaColorCabellos.Add(bcc);
                }
            }
            //PersonasBuscadas.idColorOjos = Convert.ToInt32(this.ddlColorOjosB.SelectedValue);
            foreach (ListItem item in this.lstColorOjosB.Items)
            {
                if (item.Selected)
                {
                    BusquedaColorOjos bco = new BusquedaColorOjos();
                    bco.id = -1;
                    bco.idClaseColorOjos = Convert.ToInt32(item.Value);
                    bco.idBusqueda = -1;
                    busqueda.busquedaColorOjoss.Add(bco);
                }
            }
            //PersonasBuscadas.idColorPiel = Convert.ToInt32(this.ddlColorPielB.SelectedValue);
            foreach (ListItem item in this.lstColorPielB.Items)
            {
                if (item.Selected)
                {
                    BusquedaColorPiel bcp = new BusquedaColorPiel();
                    bcp.id = -1;
                    bcp.idClaseColorPiel = Convert.ToInt32(item.Value);
                    bcp.idBusqueda = -1;
                    busqueda.busquedaColorPiels.Add(bcp);
                }
            }
            //PersonasBuscadas.idColorTenido = Convert.ToInt32(this.ddlColorTenidoB.SelectedValue);
            foreach (ListItem item in this.lstColorTenidoB.Items)
            {
                if (item.Selected)
                {
                    BusquedaColorTenido bct = new BusquedaColorTenido();
                    bct.id = -1;
                    bct.idClaseColorTenido = Convert.ToInt32(item.Value);
                    bct.idBusqueda = -1;
                    busqueda.busquedaColorTenidos.Add(bct);
                }
            }
            //PersonasBuscadas.idLongitudCabellos = Convert.ToInt32(this.ddlLongitudCabelloB.SelectedValue);
            foreach (ListItem item in this.lstLongitudCabelloB.Items)
            {
                if (item.Selected)
                {
                    BusquedaLongitudCabello blc = new BusquedaLongitudCabello();
                    blc.id = -1;
                    blc.idClaseLongitudCabello = Convert.ToInt32(item.Value);
                    blc.idBusqueda = -1;
                    busqueda.busquedaLongitudCabellos.Add(blc);
                }
            }
            //PersonasBuscadas.idSeniaParticular = Convert.ToInt32(this.ddlSeniasParticularesB.SelectedValue);

            //foreach (ListItem item in this.lstRostroBI.Items)
            //{
            //    if (item.Selected)
            //    {
            //        BusquedaRostro br = new BusquedaRostro();
            //        br.id = -1;
            //        br.idClaseRostro = Convert.ToInt32(item.Value);
            //        br.idBusqueda = -1;
            //        BusquedaIndividual.busquedaRostros.Add(br);
            //    }
            //}

            foreach (SeniasParticulares sp in Senias)
            {
                BusquedaSeniasParticulares bsp = new BusquedaSeniasParticulares();
                bsp.id = -1;
                bsp.idClaseSeniaParticular = sp.idSeniaParticular;
                bsp.idUbicacionSeniaParticular = sp.idUbicacionSeniaParticular;
                bsp.idBusqueda = -1;
                busqueda.busquedaSeniasParticularess.Add(bsp);
            }
            //busqueda.idsexo = Convert.ToInt32(this.ddlSexoB.SelectedValue);
            foreach (ListItem item in this.lstSexoB.Items)
            {
                if (item.Selected)
                {
                    busqueda.idsexo = Convert.ToInt32(item.Value);
                }
            }
            //PersonasBuscadas.idUbicacionSeniaParticular = Convert.ToInt32(this.ddlUbicacionSeniaParticularB.SelectedValue);
            if (float.TryParse(this.txtPesoDesdeB.Text.Trim(), out flotante))
                busqueda.PesoDesde = flotante;
            else
                busqueda.PesoDesde = null;
            if (float.TryParse(this.txtPesoHastaB.Text.Trim(), out flotante))
                busqueda.PesoHasta = flotante;
            else
                busqueda.PesoHasta = null;
            if (float.TryParse(this.txtTallaDesdeB.Text.Trim(), out flotante))
                busqueda.TallaDesde = flotante;
            else
                busqueda.TallaDesde = null;
            if (float.TryParse(this.txtTallaHastaB.Text.Trim(), out flotante))
                busqueda.TallaHasta = flotante;
            else
                busqueda.TallaHasta = null;
            busqueda.FaltanPiezasDentales = Convert.ToInt16(this.ddlFaltanPiezasDentalesB.SelectedValue);
           
            busqueda.UFI = Session["miUfi"].ToString().Trim();
            //***************************
            //CONTROLAR
            busqueda.Usuario = Session["miUsuario"].ToString();

            busqueda.CantidadCoincidencias = Convert.ToInt32(this.ddlCantCoincidencias.SelectedValue);
            //busqueda.CantidadCoincidencias = 3;
            //***************************
            //busqueda.UsuarioUltimaModificacion = Session["miUsuario"].ToString();
            busqueda.UsuarioUltimaModificacion = null;
            busqueda.FechaUltimaModificacion = null;
            busqueda.Apellido = this.txtApellidoB.Text.Trim();
            busqueda.Nombre = this.txtNombresB.Text.Trim();
            busqueda.IPP = this.txtIppB.Text.Trim();
            //*********************
            //REVISAR****************
            busqueda.idMotivoHallazgo = 1;
            //************************************
            return busqueda;
        }


        /// <summary>
        /// Realiza la validacion de los controles de la busqueda generica
        /// </summary>
        private void ValidarB()
        {
            //fechas
            string fechaDesde = this.txtFechaDesdeB.Text.Trim();
            string fechaHasta = this.txtFechaHastaB.Text.Trim();
            if (fechaDesde != "" && fechaHasta != "")
            {
                if (this.mevFechaDesdeB.IsValid == true && this.mevFechaHastaB.IsValid == true)
                {
                    if (Convert.ToDateTime(fechaDesde) > Convert.ToDateTime(fechaHasta))
                    {
                        this.cvFechas.IsValid = false;
                    }
                }
            }

            //edades
            string edadDesde = this.txtEdadDesdeB.Text.Trim();
            string edadHasta = this.txtEdadHastaB.Text.Trim();
            if (edadDesde != "" && edadHasta != "")
            {
                if (this.mevEdadDesdeB.IsValid == true && this.mevEdadHastaB.IsValid == true)
                {
                    if (Convert.ToInt32(edadDesde) > Convert.ToInt32(edadHasta))
                    {
                        this.cvEdades.IsValid = false;
                    }
                }
            }

            //tallas
            string tallaDesde = this.txtTallaDesdeB.Text.Trim();
            string tallaHasta = this.txtTallaHastaB.Text.Trim();
            if (tallaDesde != "" && tallaHasta != "")
            {
                if (this.mevTallaDesdeB.IsValid == true && this.mevTallaDesdeB.IsValid == true)
                {
                    if (Convert.ToInt32(tallaDesde) > Convert.ToInt32(tallaHasta))
                    {
                        this.cvTallas.IsValid = false;
                    }
                }
            }

            //pesos
            string pesoDesde = this.txtPesoDesdeB.Text.Trim();
            string pesoHasta = this.txtPesoHastaB.Text.Trim();
            if (pesoDesde != "" && pesoHasta != "")
            {
                if (this.mevPesoDesdeB.IsValid == true && this.mevPesoHastaB.IsValid == true)
                {
                    if (Convert.ToInt32(pesoDesde) > Convert.ToInt32(pesoHasta))
                    {
                        this.cvPeso.IsValid = false;
                    }
                }
            }
        }

        /// <summary>
        /// Borra la persona indicada junto con sus fotos
        /// </summary>
        /// <param name="tipoBusqueda">si es hallada o desap</param>
        private void BorrarPersonas(FuncionesGrales.TipoBusqueda tipoBusqueda, int idParaBorrar)
        {
            switch (tipoBusqueda)
            {
                case FuncionesGrales.TipoBusqueda.PersonaDesaparecida:
                    //PersonasDesaparecidas desaparecida = PersonasDesaparecidasManager.GetList().Find(delegate(PersonasDesaparecidas pd) { return pd.idBusqueda == idParaBorrar; });
                    PersonasDesaparecidas desaparecida = PersonasDesaparecidasManager.GetItem(idParaBorrar, false);

                    desaparecida.Baja = true;
                    PersonasDesaparecidasManager.Save(desaparecida);
                    break;
                case FuncionesGrales.TipoBusqueda.PersonaHallada:
                    PersonasHalladas hallada = PersonasHalladasManager.GetItem(idParaBorrar, false);

                    hallada.Baja = true;
                    PersonasHalladasManager.Save(hallada);
                    break;

            }
        }


        protected void btnBorrarBusqueda_Click(object sender, EventArgs e)
        {
            BorrarPersonas((FuncionesGrales.TipoBusqueda)Enum.Parse(typeof(FuncionesGrales.TipoBusqueda), PersonasBuscadas.idOrigen.ToString().Trim(), true), Convert.ToInt32(PersonasBuscadas.Id));
            if (MPBA.PersonasBuscadas.Bll.BusquedaManager.Delete(PersonasBuscadas))
            {
                Session["idBusqueda"] = null;
                PersonasBuscadas = null;
                Session["miPersonaBuscada"] = null;
                this.btnGuardarBusqueda.Style.Add("display", "none");
                this.gvResultadoBusquedaPersonasHalladas.Visible = false;
                this.gvResultadoBusquedaPersonasDesap.Visible = false;
                this.btnBorrarBusqueda.Style.Add("display", "none");
                LimpiarControlesB();
                //MPBA.PersonasBuscadas.Web.MasterPage miMaster = (MPBA.PersonasBuscadas.Web.MasterPage)this.Master;
            }
        }

        protected void btnGuardarBusqueda_Click(object sender, EventArgs e)
        {

        }

        protected void ddlTipoBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.gvResultadoBusquedaPersonasHalladas.Visible = false;
            this.gvResultadoBusquedaPersonasDesap.Visible = false;
            this.btnAgregarBusquedaFavoritos.Visible = false;
            this.lblCantResultados.Text = "";
            this.btnBorrarBusqueda.Style.Add("display", "none");
            this.btnGuardarBusqueda.Style.Add("display", "none");
            this.divResultados.Style.Add("display", "none");
        }

        protected void gvSenasPart_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            e.Cancel = true;
            string tipoBusqueda = "";
            GridView gvSenasPart = (GridView)sender;
            switch (gvSenasPart.ID)
            {
                case "gvSenasPartD":
                    tipoBusqueda = "D";
                    break;
                case "gvSenasPartH":
                    tipoBusqueda = "H";
                    break;
                case "gvSenasPartB":
                    tipoBusqueda = "B";
                    break;
                case "gvSenasPartBI":
                    tipoBusqueda = "BI";
                    break;
            }
            gvSenasPart.EditIndex = -1;
            gvSenasPart.DataSource = Senias;
            gvSenasPart.DataBind();
           
        }

        protected void gvSenasPart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
            string tipoBusqueda = "";
            GridView gvSenasPart = (GridView)sender;
            switch (gvSenasPart.ID)
            {
                case "gvSenasPartD":
                    tipoBusqueda = "D";
                    break;
                case "gvSenasPartH":
                    tipoBusqueda = "H";
                    break;
                case "gvSenasPartBI":
                    tipoBusqueda = "BI";
                    break;
                case "gvSenasPartB":
                    tipoBusqueda = "B";
                    break;
            }
            gvSenasPart.EditIndex = -1;
            Senias.RemoveAt(e.RowIndex);
            Session["misSenias"] = Senias;
            gvSenasPart.DataSource = Senias;
            gvSenasPart.DataBind();
           
        }

        protected void gvSenasPart_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string tipoBusqueda = "";
            GridView gvSenasPart = (GridView)sender;
            switch (gvSenasPart.ID)
            {
                case "gvSenasPartD":
                    tipoBusqueda = "D";
                    break;
                case "gvSenasPartH":
                    tipoBusqueda = "H";
                    break;
                case "gvSenasPartB":
                    tipoBusqueda = "B";
                    break;
                case "gvSenasPartBI":
                    tipoBusqueda = "BI";
                    break;
            }

            gvSenasPart.EditIndex = e.NewEditIndex;
            int id = Convert.ToInt32(gvSenasPart.DataKeys[e.NewEditIndex].Value);
            gvSenasPart.DataSource = Senias;
            gvSenasPart.DataBind();
           
        }

        protected void gvSenasPart_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
            GridView gvSenasPart = (GridView)sender;
            //switch (gvSenasPart.ID)
            //{
            //    case "gvSenasPartD":
            //        tipoBusqueda = "D";
            //        break;
            //    case "gvSenasPartH":
            //        tipoBusqueda = "H";
            //        break;
            //    case "gvSenasPartB":
            //        tipoBusqueda = "B";
            //        break;
            //    case "gvSenasPartBI":
            //        tipoBusqueda = "BI";
            //        break;
            //}
            SeniasParticulares senia = Senias[e.RowIndex];
            senia.idSeniaParticular = Convert.ToInt32(((DropDownList)(gvSenasPart.Rows[e.RowIndex].Cells[3].FindControl("ddlSeniaPart"))).SelectedValue);
            senia.idUbicacionSeniaParticular = Convert.ToInt32(((DropDownList)(gvSenasPart.Rows[e.RowIndex].Cells[4].FindControl("ddlUbicacionSenaPart"))).SelectedValue);
            gvSenasPart.EditIndex = -1;
            gvSenasPart.DataSource = Senias;
            gvSenasPart.DataBind();
           
        }

        protected void btnBuscarIpp_Click(object sender, EventArgs e)
        {
            LimpiarControlesB();
            this.tblBuscarOtros.Visible = false;
            this.tblBuscarIpp.Visible = true;
            this.btnBuscarIpp.Enabled = false;
            this.btnBuscarOtros.Enabled = true;
            this.cartelTipoBusqueda.InnerText = "BUSCAR POR IPP";
            this.lblAyudaSeleccionMultiple.Visible = false;
        }

        protected void btnBuscarOtros_Click(object sender, EventArgs e)
        {
            LimpiarControlesB();
            this.tblBuscarOtros.Visible = true;
            this.tblBuscarIpp.Visible = false;
            this.btnBuscarIpp.Enabled = true;
            this.btnBuscarOtros.Enabled = false;
            this.cartelTipoBusqueda.InnerText = "BUSCAR POR CRITERIOS VARIOS";
            this.lblAyudaSeleccionMultiple.Visible = true;
        }

        protected void btnAgregarSenia_Click(object sender, EventArgs e)
        {
            GridView gvSenasPart = null;
            string argumento = ((LinkButton)sender).CommandArgument;
            switch (argumento)
            {
                case "H":
                    //gvSenasPart = this.gvSenasPartH;
                    break;
                case "D":
                    //gvSenasPart = this.gvSenasPartD;
                    break;
                case "B":
                    gvSenasPart = this.gvSenasPartB;
                    break;
                case "BI":
                    //gvSenasPart = this.gvSenasPartBI;
                    return;//no permito que se busque por mas de una sena
            }
            int idSenia = Convert.ToInt32(((DropDownList)gvSenasPart.FooterRow.FindControl("ddlSeniaPartInsert")).SelectedValue);
            int idUbicacionSenia = Convert.ToInt32(((DropDownList)gvSenasPart.FooterRow.FindControl("ddlUbicacionSenaPartInsert")).SelectedValue);
            if (idSenia == 0 || idUbicacionSenia == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Debe indicar la seña y su ubicación.');", true);
                return;
            }
            SeniasParticulares sena = new SeniasParticulares();
            sena.idSeniaParticular = idSenia;
            sena.idUbicacionSeniaParticular = idUbicacionSenia;
            sena.id = -1;
            sena.idTablaDestino = 1;
            Senias.Add(sena);
            gvSenasPart.DataSource = Senias;
            Session["misSenias"] = Senias;
            gvSenasPart.DataBind();
          
        }

        protected void btnAgregarPrimeraSenia_Click(object sender, EventArgs e)
        {
            GridView gvSenasPart = null;
            string argumento = ((LinkButton)sender).CommandArgument;
            switch (argumento)
            {
                case "H":
                    //gvSenasPart = this.gvSenasPartH;
                    break;
                case "D":
                    //gvSenasPart = this.gvSenasPartD;
                    break;
                case "BI":
                    //gvSenasPart = this.gvSenasPartBI;
                    break;
                case "B":
                    gvSenasPart = this.gvSenasPartB;
                    break;
            }

           int idSenia = Convert.ToInt32(((DropDownList)gvSenasPart.Controls[0].Controls[0].Controls[0].FindControl("ddlSenasParticulares")).SelectedValue);
           int idUbicacionSenia = Convert.ToInt32(((DropDownList)gvSenasPart.Controls[0].Controls[0].Controls[0].FindControl("ddlUbicacionSenasPart")).SelectedValue);
           if (idSenia == 0 || idUbicacionSenia == 0)
           {
               ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Debe indicar la seña y su ubicación.');", true);
               return;
           }
           SeniasParticulares sena = new SeniasParticulares();           
            sena.idSeniaParticular = idSenia;
            sena.idUbicacionSeniaParticular = idUbicacionSenia;

            sena.id = -1;
            sena.idTablaDestino = 2;
            Senias = new SeniasParticularesList();
            Senias.Add(sena);
            Session["misSenias"] = Senias;
            gvSenasPart.DataSource = Senias;
            gvSenasPart.DataBind();
            switch (argumento)
            {
                case "D":
                   
                    break;
                case "H":
                 
                    break;
                case "B":
                   
                    break;
                case "BI":
                    gvSenasPart.ShowFooter = false;
                    gvSenasPart.DataBind();
                    break;
            }
        }

        protected void btnAgregarBusquedaFavoritos_Click(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(this.ddlTipoBusqueda.SelectedValue))
            {
                case (int)FuncionesGrales.TipoBusqueda.PersonaDesaparecida:
                    int contador = 0;
                    foreach (GridViewRow row in this.gvResultadoBusquedaPersonasDesap.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {


                            CheckBox chkFavoritosD = (CheckBox)row.FindControl("chkFavoritosD");
                            HiddenField hfFavoritasD = (HiddenField)row.FindControl("hfFavoritasD");
                            if (chkFavoritosD.Checked)
                            {
                                BusquedasFavoritas bf = new BusquedasFavoritas();
                                bf.id = -1;
                                bf.idPersona = Convert.ToInt32(hfFavoritasD.Value);
                                bf.idTablaDestino = 1;
                                bf.Usuario = Session["miUsuario"].ToString();
                                try
                                {
                                    BusquedasFavoritasManager.Save(bf);
                                }
                                catch (System.Data.SqlClient.SqlException ex)
                                {
                                    
                                }
                                contador++;

                            }
                        }
                    }
                    if (contador > 0)
                    {
                        this.pnlExito.Style.Remove("display");
                        hfExito_ModalPopupExtender.Show();
                        this.pnlExito.Style.Add("display", "none");

                    }
                    break;
                case (int)FuncionesGrales.TipoBusqueda.PersonaHallada:
                    contador = 0;
                    foreach (GridViewRow row in this.gvResultadoBusquedaPersonasHalladas.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chkFavoritosH = (CheckBox)row.FindControl("chkFavoritosH");
                            HiddenField hfFavoritasH = (HiddenField)row.FindControl("hfFavoritasH");
                            if (chkFavoritosH.Checked)
                            {
                                BusquedasFavoritas bf = new BusquedasFavoritas();
                                bf.id = -1;
                                bf.idPersona = Convert.ToInt32(hfFavoritasH.Value);
                                bf.idTablaDestino = 2;
                                bf.Usuario = Session["miUsuario"].ToString();
                                try
                                {
                                    BusquedasFavoritasManager.Save(bf);
                                }
                                catch { }
                                contador++;
                            }
                        }
                    }
                    if (contador > 0)
                    {
                        this.pnlExito.Style.Remove("display");
                        hfExito_ModalPopupExtender.Show();
                        this.pnlExito.Style.Add("display", "none");

                    }
                    break;
            }
        }

        protected void btnBusquedasFavoritas_Click(object sender, EventArgs e)
        {
         

            List<MPBA.PersonasBuscadas.BusinessEntities.PersonasDesaparecidas> bfDesap = BusquedasFavoritasManager.GetListJoinedDesaparecidas(Session["miUsuario"].ToString().Trim());
            List<MPBA.PersonasBuscadas.BusinessEntities.PersonasHalladas> bfHalladas = BusquedasFavoritasManager.GetListJoinedHalladas(Session["miUsuario"].ToString().Trim());
            this.gvResultadosDesapBI.DataSource = bfDesap;
            this.gvResultadosDesapBI.Columns[0].Visible = true;
            this.gvResultadosDesapBI.DataBind();
            this.gvResultadosHalladasBI.DataSource = bfHalladas;
            this.gvResultadosHalladasBI.Columns[0].Visible = true;
            this.gvResultadosHalladasBI.DataBind();
            this.lblResultadosBI.Text = "MIS FAVORITOS";
            this.gvResultadosDesapBI.Style.Remove("display");
            this.gvResultadosHalladasBI.Style.Remove("display");
            this.pnlResultadosBI.Style.Remove("display");
            this.hfAbrirResultadosBI_ModalPopupExtender1.Show();
            
        }

     

        protected void gvResultadosHalladasBI_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idPersona = Convert.ToInt32(this.gvResultadosHalladasBI.DataKeys[e.RowIndex].Value);
            BusquedasFavoritas bf = BusquedasFavoritasManager.GetItem(idPersona, (int)FuncionesGrales.TipoBusqueda.PersonaHallada);
            bool borroBien = BusquedasFavoritasManager.Delete(bf);
            this.gvResultadosHalladasBI.Rows[e.RowIndex].Visible = false;
        }


        protected void gvResultadosDesapBI_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idPersona = Convert.ToInt32(this.gvResultadosDesapBI.DataKeys[e.RowIndex].Value);
            BusquedasFavoritas bf = BusquedasFavoritasManager.GetItem(idPersona, (int)FuncionesGrales.TipoBusqueda.PersonaDesaparecida);
            bool borroBien = BusquedasFavoritasManager.Delete(bf);
            this.gvResultadosDesapBI.Rows[e.RowIndex].Visible = false;
        }

        protected void btnCancelarResultadosBI_Click(object sender, EventArgs e)
        {
            this.pnlResultadosBI.Style.Add("display", "none");
            this.hfAbrirResultadosBI_ModalPopupExtender1.Hide();

        }

        protected void btnCantCoincidencias_Click(object sender, EventArgs e)
        {
            ValidarB();
            if (this.IsValid)
            {
                Buscar();
                int cantResultados = 0;
                switch (this.ddlTipoBusqueda.SelectedValue)
                {
                    case "2"://ph
                        cantResultados = this.gvResultadoBusquedaPersonasHalladas.Rows.Count;
                      //  Session["ResultadoBusquedaPersonas"] = this.gvResultadoBusquedaPersonasHalladas;
                        SetearGridView(this.gvResultadoBusquedaPersonasHalladas);
                        break;
                    case "1"://pd
                        cantResultados = this.gvResultadoBusquedaPersonasDesap.Rows.Count;
                       // Session["ResultadoBusquedaPersonas"] = this.gvResultadoBusquedaPersonasDesap;
                        SetearGridView(this.gvResultadoBusquedaPersonasDesap);
                        break;
                }
                if (cantResultados == 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('No se hallaron coincidencias.');", true);
                }
                else
                {
                    this.lblCantResultados.Text = "Resultados Encontrados: " + cantResultados.ToString();

                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "btnOkCantCoincidencias();", true);

                }
            }

            this.pnlCantCoincidencias.Style.Add("display", "none");
        }

     

        
        protected void btnCancelarCantCoincidencias_Click(object sender, EventArgs e)
        {
            this.pnlCantCoincidencias.Style.Add("display", "none");
        }


        private void SetearGridView(GridView gv)
        {
            foreach (GridViewRow gvr in gv.Rows)
            {
                foreach (TableCell c in gvr.Cells)
                {
                    TableCell celda = c;
                    switch (((DataControlFieldCell)c).ContainingField.ToString().Trim().ToUpper())
                    {
                        case "FECHA NAC.":
                            if (c.Text != null)
                            {
                                DateTime dtFechaNac;
                                if (DateTime.TryParse(c.Text, out dtFechaNac))
                                {
                                    c.Text = dtFechaNac.ToString("dd/MM/yyyy");
                                }
                                else
                                    c.Text = "";
                            }
                            break;
                    }
                }
            }
        }

        protected void btnLimiparListSexo_Click(object sender, EventArgs e)
        {
            this.lstSexoB.SelectedIndex = -1;
        }
        protected void btnFotoSigGeneralBIH_Click(object sender, EventArgs e)
        {
            AvanzarFotoFichaBI(FuncionesGrales.TipoBusqueda.PersonaHallada, FuncionesGrales.TipoFoto.General, Convert.ToInt32(this.hfOkFichaBIH.Value));
        }

        protected void btnFotoSigSeniasBIH_Click(object sender, EventArgs e)
        {
            AvanzarFotoFichaBI(FuncionesGrales.TipoBusqueda.PersonaHallada, FuncionesGrales.TipoFoto.SeniasParticulares, Convert.ToInt32(this.hfOkFichaBIH.Value));
        }

        protected void btnFotoPrevSeniasBIH_Click(object sender, EventArgs e)
        {
            RetrocederFotoFichaBI(FuncionesGrales.TipoBusqueda.PersonaHallada, FuncionesGrales.TipoFoto.SeniasParticulares, Convert.ToInt32(this.hfOkFichaBIH.Value));
        }

        protected void btnFotoPrevGeneralBIH_Click(object sender, EventArgs e)
        {
            RetrocederFotoFichaBI(FuncionesGrales.TipoBusqueda.PersonaHallada, FuncionesGrales.TipoFoto.General, Convert.ToInt32(this.hfOkFichaBIH.Value));
        }

        protected void btnCerrarBIH_Click(object sender, EventArgs e)
        {
            this.hfGestionFichaPersHalladaBI_ModalPopupExtender.Hide();
            ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "btnOkCantCoincidencias();", true);
            //this.hfAbrirResultadosBI_ModalPopupExtender1.Show();
            //this.gvResultadosHalladasBI.DataBind();
        }
        private void AvanzarFotoFichaBI(FuncionesGrales.TipoBusqueda tipoBusqueda, FuncionesGrales.TipoFoto tipoFoto, int idPersona)
        {
            
                    switch (tipoBusqueda)
                    {
                        case FuncionesGrales.TipoBusqueda.PersonaHallada:
                            switch (tipoFoto)
                            {
                                case FuncionesGrales.TipoFoto.General:
                                    if (FotosGralesBI.Position < FotosGralesBI.Count)
                                    {
                                        FotosGralesBI.MoveNext();
                                        PBFotos f = (PBFotos)FotosGralesBI.Current;
                                        LlenarImgBoxFichaBI(f, FuncionesGrales.TipoBusqueda.PersonaHallada, tipoFoto);
                                    }
                                    break;
                                case FuncionesGrales.TipoFoto.SeniasParticulares:
                                    if (FotosSeniasBI.Position < FotosSeniasBI.Count)
                                    {
                                        FotosSeniasBI.MoveNext();
                                        PBFotos f = (PBFotos)FotosSeniasBI.Current;
                                        LlenarImgBoxFichaBI(f, FuncionesGrales.TipoBusqueda.PersonaHallada, tipoFoto);
                                    }
                                    break;
                            }
                            this.lblNroFotoGralBIH.Text = (FotosGralesBI.Position + 1).ToString() + "/" + FotosGralesBI.Count.ToString();
                            this.lblNroFotoSenasBIH.Text = (FotosSeniasBI.Position + 1).ToString() + "/" + FotosSeniasBI.Count.ToString();
                            this.hfGestionFichaPersHalladaBI_ModalPopupExtender.Show();
                            break;
                        case FuncionesGrales.TipoBusqueda.PersonaDesaparecida:
                            switch (tipoFoto)
                            {
                                case FuncionesGrales.TipoFoto.General:
                                    if (FotosGralesBI.Position < FotosGralesBI.Count)
                                    {
                                        FotosGralesBI.MoveNext();
                                        PBFotos f = (PBFotos)FotosGralesBI.Current;
                                        LlenarImgBoxFichaBI(f, FuncionesGrales.TipoBusqueda.PersonaDesaparecida, tipoFoto);
                                    }
                                    break;
                                case FuncionesGrales.TipoFoto.SeniasParticulares:
                                    if (FotosSeniasBI.Position < FotosSeniasBI.Count)
                                    {
                                        FotosSeniasBI.MoveNext();
                                        PBFotos f = (PBFotos)FotosSeniasBI.Current;
                                        LlenarImgBoxFichaBI(f, FuncionesGrales.TipoBusqueda.PersonaDesaparecida, tipoFoto);
                                    }
                                    break;
                            }
                            this.lblNroFotoGralBID.Text = (FotosGralesBI.Position + 1).ToString() + "/" + FotosGralesBI.Count.ToString();
                            this.lblNroFotoSeniasBID.Text = (FotosSeniasBI.Position + 1).ToString() + "/" + FotosSeniasBI.Count.ToString();
                            this.hfGestionFichaPersDesapBI_ModalPopupExtender.Show();
                            break;
                    }
        }
        /// <summary>
        /// Llena el imagebox de la ficha de busq individual con el nro de foto indicada
        /// </summary>
        /// <param name="tipoBusqueda">si es para persona hallada o desap</param>
        /// <param name="fullNameFoto">el nombre completo virtual de foto a mostrar</param>
        /// <param name="idPersona">el id de la persona cuyas fotos se quiere traer</param>
        private void LlenarImgBoxFichaBI(PBFotos fotoAMostrar, FuncionesGrales.TipoBusqueda tipoBusqueda, FuncionesGrales.TipoFoto tipoFoto)
        {
            int cantFotos = 0;
            int nroFotoActual = 0;
            switch (tipoFoto)
            {
                case FuncionesGrales.TipoFoto.General:
                    cantFotos = FotosGralesBI.Count;
                    nroFotoActual = FotosGralesBI.Position + 1;
                    //this.btnBorrarFotoGralBI.Enabled = cantFotos > 0;
                    break;
                case FuncionesGrales.TipoFoto.SeniasParticulares:
                    cantFotos = FotosSeniasBI.Count;
                    nroFotoActual = FotosSeniasBI.Position + 1;
                    break;
            }
            if (cantFotos == 0)
                return;
            System.Drawing.Image imgPhoto = null;
            Byte[] input = fotoAMostrar.Foto;
            using (MemoryStream ms = new MemoryStream(input))
            {
                imgPhoto = System.Drawing.Image.FromStream(ms);
                ms.Close();
            }


            int[] dim = DimensionarImgBox(imgPhoto, 100, 100);
            imgPhoto.Dispose();
            if (dim != null)
            {
                string url = "";
                switch (tipoFoto)
                {
                    case FuncionesGrales.TipoFoto.General:

                        Session["FotosGralesBI"] = FotosGralesBI;
                        url = "ImageHandler1.ashx?t=" + ((int)tipoFoto).ToString() + "&r=" + new Random().Next().ToString() + "&bi=t&p=h";
                        if (tipoBusqueda == FuncionesGrales.TipoBusqueda.PersonaHallada)
                        {
                            this.imgFotoGralBIH.ImageUrl = url;
                            this.imgFotoGralBIH.OnClientClick = "window.open('FullSizeImage.aspx?url=" + url + "')";
                            this.imgFotoGralBIH.Width = dim[0];
                            this.imgFotoGralBIH.Height = dim[1];
                            
                        }
                        else
                        {
                            this.imgFotoGeneralBID.ImageUrl = url;
                            this.imgFotoGeneralBID.OnClientClick = "window.open('FullSizeImage.aspx?url=" + url + "')";
                            this.imgFotoGeneralBID.Width = dim[0];
                            this.imgFotoGeneralBID.Height = dim[1];
                        }
                        break;
                    case FuncionesGrales.TipoFoto.SeniasParticulares:
                        Session["FotosSeniasBI"] = FotosSeniasBI;
                        url = "ImageHandler1.ashx?t=" + ((int)tipoFoto).ToString() + "&r=" + new Random().Next().ToString() + "&bi=t&p=h";
                        if (tipoBusqueda == FuncionesGrales.TipoBusqueda.PersonaHallada)
                        {
                            this.imgFotoSenasBIH.ImageUrl = url;
                            this.imgFotoSenasBIH.OnClientClick = "window.open('FullSizeImage.aspx?url=" + url + "')";
                            this.imgFotoSenasBIH.Width = dim[0];
                            this.imgFotoSenasBIH.Height = dim[1];
                        }
                        else
                        {
                            this.imgFotoSeniasBID.ImageUrl = url;
                            this.imgFotoSeniasBID.OnClientClick = "window.open('FullSizeImage.aspx?url=" + url + "')";
                            this.imgFotoSeniasBID.Width = dim[0];
                            this.imgFotoSeniasBID.Height = dim[1];
                        }
                        break;
                }
                switch (tipoFoto)
                {
                    case FuncionesGrales.TipoFoto.General:
                        if (cantFotos == 1)
                        {
                            if (tipoBusqueda == FuncionesGrales.TipoBusqueda.PersonaHallada)
                            {
                                this.btnFotoSigGeneralBIH.Enabled = false;
                                this.btnFotoPrevGeneralBIH.Enabled = false;
                            }
                            else
                            {
                                this.btnFotoSigGeneralBID.Enabled = false;
                                this.btnFotoPrevGeneralBID.Enabled = false;
                            }
                        }
                        else if (cantFotos > 1)
                        {

                            if (nroFotoActual == 1)
                            {
                                if (tipoBusqueda == FuncionesGrales.TipoBusqueda.PersonaHallada)
                                {
                                    this.btnFotoSigGeneralBIH.Enabled = true;
                                    this.btnFotoPrevGeneralBIH.Enabled = false;
                                }
                                else
                                {
                                    this.btnFotoSigGeneralBID.Enabled = true;
                                    this.btnFotoPrevGeneralBID.Enabled = false;
                                }
                            }
                            else if (nroFotoActual > 1 && nroFotoActual < cantFotos)
                            {
                                if (tipoBusqueda == FuncionesGrales.TipoBusqueda.PersonaHallada)
                                {
                                    this.btnFotoSigGeneralBIH.Enabled = true;
                                    this.btnFotoPrevGeneralBIH.Enabled = true;
                                }
                                else
                                {
                                    this.btnFotoSigGeneralBID.Enabled = true;
                                    this.btnFotoPrevGeneralBID.Enabled = true;
                                }
                            }
                            else if (nroFotoActual == cantFotos)
                            {
                                if (tipoBusqueda == FuncionesGrales.TipoBusqueda.PersonaHallada)
                                {
                                    this.btnFotoSigGeneralBIH.Enabled = false;
                                    this.btnFotoPrevGeneralBIH.Enabled = true;
                                }
                                else
                                {
                                    this.btnFotoSigGeneralBID.Enabled = false;
                                    this.btnFotoPrevGeneralBID.Enabled = true;
                                }
                            }
                        }
                        else
                        {
                            if (tipoBusqueda == FuncionesGrales.TipoBusqueda.PersonaHallada)
                            {
                                this.btnFotoSigGeneralBIH.Enabled = false;
                                this.btnFotoPrevGeneralBIH.Enabled = false;
                                this.imgFotoGralBIH.ImageUrl = "~/App_Images/SinFoto.GIF";
                                this.imgFotoGralBIH.Width = 80;
                                this.imgFotoGralBIH.Height = 100;
                            }
                            else
                            {
                                this.btnFotoSigGeneralBID.Enabled = false;
                                this.btnFotoPrevGeneralBID.Enabled = false;
                                this.imgFotoGeneralBID.ImageUrl = "~/App_Images/SinFoto.GIF";
                                this.imgFotoGeneralBID.Width = 80;
                                this.imgFotoGeneralBID.Height = 100;
                            }
                        }
                        break;
                    case FuncionesGrales.TipoFoto.SeniasParticulares:
                        if (cantFotos == 1)
                        {
                            if (tipoBusqueda == FuncionesGrales.TipoBusqueda.PersonaHallada)
                            {
                                this.btnFotoSigSeniasBIH.Enabled = false;
                                this.btnFotoPrevSeniasBIH.Enabled = false;
                            }
                            else
                            {
                                this.btnFotoSigSeniasBID.Enabled = false;
                                this.btnFotoPrevSeniasBID.Enabled = false;
                            }
                        }
                        else if (cantFotos > 1)
                        {

                            if (nroFotoActual == 1)
                            {
                                if (tipoBusqueda == FuncionesGrales.TipoBusqueda.PersonaHallada)
                                {
                                    this.btnFotoSigSeniasBIH.Enabled = true;
                                    this.btnFotoPrevSeniasBIH.Enabled = false;
                                }
                                else
                                {
                                    this.btnFotoSigSeniasBID.Enabled = true;
                                    this.btnFotoPrevSeniasBID.Enabled = false;
                                }
                            }
                            else if (nroFotoActual > 1 && nroFotoActual < cantFotos)
                            {
                                if (tipoBusqueda == FuncionesGrales.TipoBusqueda.PersonaHallada)
                                {
                                    this.btnFotoSigSeniasBIH.Enabled = true;
                                    this.btnFotoPrevSeniasBIH.Enabled = true;
                                }
                                else
                                {
                                    this.btnFotoSigSeniasBID.Enabled = true;
                                    this.btnFotoPrevSeniasBID.Enabled = true;
                                }
                            }
                            else if (nroFotoActual == cantFotos)
                            {
                                if (tipoBusqueda == FuncionesGrales.TipoBusqueda.PersonaHallada)
                                {
                                    this.btnFotoSigSeniasBIH.Enabled = false;
                                    this.btnFotoPrevSeniasBIH.Enabled = true;
                                }
                                else
                                {
                                    this.btnFotoSigSeniasBID.Enabled = false;
                                    this.btnFotoPrevSeniasBID.Enabled = true;
                                }
                            }
                            else
                            {
                                if (tipoBusqueda == FuncionesGrales.TipoBusqueda.PersonaHallada)
                                {
                                    this.btnFotoSigSeniasBIH.Enabled = false;
                                    this.btnFotoPrevSeniasBIH.Enabled = false;
                                    this.imgFotoSenasBIH.ImageUrl = "~/App_Images/SinFoto.GIF";
                                    this.imgFotoSenasBIH.Width = 80;
                                    this.imgFotoSenasBIH.Height = 100;
                                }
                                else
                                {
                                    this.btnFotoSigSeniasBID.Enabled = false;
                                    this.btnFotoPrevSeniasBID.Enabled = false;
                                    this.imgFotoSeniasBID.ImageUrl = "~/App_Images/SinFoto.GIF";
                                    this.imgFotoSeniasBID.Width = 80;
                                    this.imgFotoSeniasBID.Height = 100;
                                }
                            }
                        }
                        break;
                }

            }


        }
        /// <summary>
        /// Me devuelve cuanto debe medir el Imagebox en funcion de las medidas indicadas para que mantenga el ratio
        /// </summary>
        /// <param name="FromFile">el nombre fisico completo de la imagen a medir</param>
        /// <param name="imgBoxH">alto original de la Imagebox</param>
        /// <param name="imgBoxW">Ancho original de la Imagebox</param>
        /// <returns>nueva medida recomendada</returns>
        private int[] DimensionarImgBox(System.Drawing.Image imgPhoto, Int16 imgBoxH, Int16 imgBoxW)
        {

            if (imgPhoto == null)
                return null;
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            Single scalefactor = Math.Max(sourceWidth / imgBoxW, sourceHeight / imgBoxH);
            int destWidth = Convert.ToInt32(sourceWidth / scalefactor);
            int destHeight = Convert.ToInt32(sourceHeight / scalefactor);
            int[] dimensiones = { destWidth, destHeight };
            imgPhoto.Dispose();
            return dimensiones;
        }
        private void RetrocederFotoFichaBI(FuncionesGrales.TipoBusqueda tipoBusqueda, FuncionesGrales.TipoFoto tipoFoto, int idPersona)
        {
            switch (tipoFoto)
            {
                case FuncionesGrales.TipoFoto.General:
                    if (FotosGralesBI.Position > 0)
                    {
                        FotosGralesBI.MovePrevious();
                        PBFotos f = (PBFotos)FotosGralesBI.Current;
                        LlenarImgBoxFichaBI(f, tipoBusqueda, tipoFoto);
                    }
                    break;
                case FuncionesGrales.TipoFoto.SeniasParticulares:
                    if (FotosSeniasBI.Position > 0)
                    {
                        FotosSeniasBI.MovePrevious();
                        PBFotos f = (PBFotos)FotosSeniasBI.Current;
                        LlenarImgBoxFichaBI(f, tipoBusqueda, tipoFoto);
                    }
                    break;
            }
            switch (tipoBusqueda)
            {
                case FuncionesGrales.TipoBusqueda.PersonaHallada:
                    this.hfGestionFichaPersHalladaBI_ModalPopupExtender.Show();
                    break;
                case FuncionesGrales.TipoBusqueda.PersonaDesaparecida:
                    this.hfGestionFichaPersDesapBI_ModalPopupExtender.Show();
                    break;

            }
            this.lblNroFotoGralBIH.Text = (FotosGralesBI.Position + 1).ToString() + "/" + FotosGralesBI.Count.ToString();
            this.lblNroFotoSenasBIH.Text = (FotosSeniasBI.Position + 1).ToString() + "/" + FotosSeniasBI.Count.ToString();
        }
        private void LimpiarControlesFichaPersHalladaBI()
        {
            this.lblIppBIH.Text = "";
            this.lblOrgIntBIH.Text = "";
            this.lblComisariaBIH.Text = "";
            this.lblHayRadiografiasBIH.Text = "";
            this.lblDeptoComisariaBIH.Text = "";
            this.lblLugarHallazgoBIH.Text = "";
            this.lblPartidoHallazgoBIH.Text = "";
            this.lblProvHallazgoBIH.Text = "";
            this.lblNroFotoGralBIH.Text = "";
            this.lblNroFotoSenasBIH.Text = "";
            this.imgFotoGralBIH.ImageUrl = "~/App_Images/SinFoto.GIF";
            this.imgFotoGralBIH.Width = 80;
            this.imgFotoGralBIH.Height = 100;
            this.imgFotoGralBIH.PostBackUrl = "";
            this.imgFotoSenasBIH.ImageUrl = "~/App_Images/SinFoto.GIF";
            this.imgFotoSenasBIH.Width = 80;
            this.imgFotoSenasBIH.Height = 100;
            this.imgFotoSenasBIH.PostBackUrl = "";
            this.lblSexoBIH.Text = "";
            this.lblColorPielBIH.Text = "";
            this.lblLongitudCabelloBIH.Text = "";
            this.lblColorOjosBIH.Text = "";
            this.lblFaltanPiezasDentalesBIH.Text = "";
            this.lblTallaBIH.Text = "";
            this.lblColorCabelloBIH.Text = "";
            this.lblAspectoCabelloBIH.Text = "";
            this.lblRostroBIH.Text = "";
            this.lblFechaHallazgoBIH.Text = "";
            this.lblPesoBIH.Text = "";
            this.lblColorTenidoBIH.Text = "";
            this.lblCalvicieBIH.Text = "";
            this.lblCantidadDiasNoAfeitadoBIH.Text = "";
            this.gvSenasPartBIH.DataSource = "";
            this.gvTatuajesBIH.DataSource = "";
            this.lblCodigoAdnBIH.Text = "";
            this.lblRopaBIH.Text = "";
            this.lblApellidoBIH.Text = "";
            this.lblEdadAparenteBIH.Text = "";
            this.lblEdadCientificaBIH.Text = "";
            this.lblArticulosPersonalesBIH.Text = "";
            this.lblNombresBIH.Text = "";
            this.lblViveBIH.Text = "";
            this.lblFichasDactilaresBIH.Text = "";
            this.btnFotoPrevGeneralBIH.Enabled = false;
            this.btnFotoPrevSeniasBIH.Enabled = false;
            this.btnFotoSigGeneralBIH.Enabled = false;
            this.btnFotoSigSeniasBIH.Enabled = false;
        }
        private void LlenarControlesFichaPersHalladaBI(PersonasHalladas personaHallada)
        {
            if (personaHallada.tieneADN != null)
                this.lblCodigoAdnBIH.Text = PBClaseBooleanManager.GetItem((int)personaHallada.tieneADN).Descripcion.Trim();
            if (personaHallada.Vive != null)
                this.lblViveBIH.Text = PBClaseBooleanManager.GetItem((int)personaHallada.Vive).Descripcion.Trim();
            if (personaHallada.Ipp != null)
                this.lblIppBIH.Text = personaHallada.Ipp.Trim();
            if (personaHallada.Apellido != null)
                this.lblApellidoBIH.Text = personaHallada.Apellido.Trim();
            if (personaHallada.Nombre != null)
                this.lblNombresBIH.Text = personaHallada.Nombre.Trim();
            if (personaHallada.ArticulosPersonales != null)
                this.lblArticulosPersonalesBIH.Text = personaHallada.ArticulosPersonales.Trim();
            if (personaHallada.CantidadDiasNoAfeitado != null)
                this.lblCantidadDiasNoAfeitadoBIH.Text = personaHallada.CantidadDiasNoAfeitado.ToString().Trim();
            if (personaHallada.EdadAparente != null)
                this.lblEdadAparenteBIH.Text = personaHallada.EdadAparente.ToString().Trim();
            if (personaHallada.EdadCientifica != null)
                this.lblEdadCientificaBIH.Text = personaHallada.EdadCientifica.ToString().Trim();
            if (personaHallada.FechaHallazgo != null)
                this.lblFechaHallazgoBIH.Text = Convert.ToDateTime(personaHallada.FechaHallazgo).ToString("dd/MM/yyyy");
            if (personaHallada.Peso != null)
                this.lblPesoBIH.Text = personaHallada.Peso.ToString();
            if (personaHallada.Ropa != null)
                this.lblRopaBIH.Text = personaHallada.Ropa.Trim();
            if (personaHallada.Talla != null)
                this.lblTallaBIH.Text = personaHallada.Talla.ToString().Trim();
            this.lblAspectoCabelloBIH.Text = PBClaseAspectoCabelloManager.GetItem(personaHallada.idAspectoCabello).Descripcion.Trim();
            this.lblCalvicieBIH.Text = PBClaseCalvicieManager.GetItem(personaHallada.idCalvicie).Descripcion.Trim();
            this.lblColorCabelloBIH.Text = PBClaseColorCabelloManager.GetItem(personaHallada.idColorCabello).Descripcion.Trim();
            this.lblColorOjosBIH.Text = PBClaseColorOjosManager.GetItem(personaHallada.idColorOjos).Descripcion.Trim();
            this.lblColorPielBIH.Text = PBClaseColorDePielManager.GetItem(personaHallada.idColorPiel).Descripcion.Trim();
            this.lblColorTenidoBIH.Text = PBClaseColorCabelloManager.GetItem(personaHallada.idColorTenido).Descripcion.Trim();

            if (personaHallada.idLugarHallazgo > 0)
            {
                this.lblLugarHallazgoBIH.Text = MPBA.SIAC.Bll.LocalidadManager.GetItem(personaHallada.idLugarHallazgo).localidad.Trim();
                this.lblPartidoHallazgoBIH.Text = MPBA.SIAC.Bll.PartidoManager.GetItem((MPBA.SIAC.Bll.LocalidadManager.GetItem(personaHallada.idLugarHallazgo).Partido)).partido.Trim();
                this.lblProvHallazgoBIH.Text = MPBA.SIAC.Bll.ProvinciaManager.GetItem((MPBA.SIAC.Bll.LocalidadManager.GetItem(personaHallada.idLugarHallazgo).Provincia)).provincia.Trim();
            }
            if (personaHallada.idComisaria > 0)
            {
                this.lblComisariaBIH.Text = MPBA.SIAC.Bll.ComisariaManager.GetItem(personaHallada.idComisaria).comisaria.Trim();
                this.lblDeptoComisariaBIH.Text = MPBA.SIAC.Bll.DepartamentoManager.GetItem((MPBA.SIAC.Bll.ComisariaManager.GetItem(personaHallada.idComisaria).idDepartamento)).departamento.Trim();
            }
            //this.lblDentaduraD.Text = personaDesaparecida.idDentadura.ToString();
            this.lblHayRadiografiasBIH.Text = PBClaseBooleanManager.GetItem((int)personaHallada.ExistenRadiografia).Descripcion.Trim();
            this.lblFaltanPiezasDentalesBIH.Text = PBClaseBooleanManager.GetItem((int)personaHallada.FaltanPiezasDentales).Descripcion.Trim();
            this.lblFichasDactilaresBIH.Text = PBClaseBooleanManager.GetItem((int)personaHallada.FichasDactilares).Descripcion.Trim();
            //this.lblFotoBIH.Text = PBClaseBooleanManager.GetItem((int)personaHallada.Foto).Descripcion.Trim();
            this.lblLongitudCabelloBIH.Text = PBClaseLongitudCabelloManager.GetItem(personaHallada.idLongitudCabello).Descripcion.Trim();
            this.lblOrgIntBIH.Text = PBClaseOrganismoIntervinienteManager.GetItem(personaHallada.idOrganismoInterviniente).Descripcion.ToString();
            this.lblRostroBIH.Text = PBClaseRostroManager.GetItem(personaHallada.idRostro).Descripcion.Trim();
            //this.lblSeniasParticularesD.Text = personaDesaparecida.idSeniaParticular.ToString();
            this.lblSexoBIH.Text = PBClaseSexoManager.GetItem(personaHallada.idSexo).Descripcion.Trim();
            //Senas Particulares
            SeniasH = personaHallada.seniasParticularess;
            Session["SeniasH"] = SeniasH;
            this.gvSenasPartBIH.DataSource = SeniasH;
            this.gvSenasPartBIH.DataBind();
            ///////////////////
            //Tatuajes
            TatuajesH = personaHallada.tatuajesPersonas;
            Session["TatuajesH"] = TatuajesH;
            this.gvTatuajesBIH.DataSource = TatuajesH;
            this.gvTatuajesBIH.DataBind();
            ///////////////
            this.hfGestionFichaPersHalladaBI.Value = personaHallada.Id.ToString();
            FotosGralesBI.DataSource = personaHallada.fotoss.FindAll(delegate(PBFotos f) { return f.idTipoFoto == (int)FuncionesGrales.TipoFoto.General; });
            if (FotosGralesBI.Count > 0)
            {
                FotosGralesBI.MoveFirst();
                PBFotos f = (PBFotos)FotosGralesBI.Current;
                LlenarImgBoxFichaBI(f, FuncionesGrales.TipoBusqueda.PersonaHallada, FuncionesGrales.TipoFoto.General);
                this.lblNroFotoGralBIH.Text = (FotosGralesBI.Position + 1).ToString() + "/" + FotosGralesBI.Count.ToString();
                this.lblNroFotoSenasBIH.Text = (FotosSeniasBI.Position + 1).ToString() + "/" + FotosSeniasBI.Count.ToString();
            }
            FotosSeniasBI.DataSource = personaHallada.fotoss.FindAll(delegate(PBFotos f) { return f.idTipoFoto == (int)FuncionesGrales.TipoFoto.SeniasParticulares; });
            if (FotosSeniasBI.Count > 0)
            {
                FotosSeniasBI.MoveFirst();
                PBFotos f = (PBFotos)FotosSeniasBI.Current;
                LlenarImgBoxFichaBI(f, FuncionesGrales.TipoBusqueda.PersonaHallada, FuncionesGrales.TipoFoto.SeniasParticulares);
                this.lblNroFotoGralBIH.Text = (FotosGralesBI.Position + 1).ToString() + "/" + FotosGralesBI.Count.ToString();
                this.lblNroFotoSenasBIH.Text = (FotosSeniasBI.Position + 1).ToString() + "/" + FotosSeniasBI.Count.ToString();
                this.lblSeniaPartBIH.Visible = true;
            }
            else
                this.lblSeniaPartBIH.Visible = false;
        }

        private void LimpiarControlesFichaPersDesapBI()
        {
            this.lblIppBID.Text = "";
            this.lblExistenRadiografiasBID.Text = "";
            this.lblOrganismoIntervinienteBID.Text = "";
            this.lblComisariaPersonaBID.Text = "";
            this.lblExistenRadiografiasBID.Text = "";
            this.lblDepartamentoComisariaBID.Text = "";
            this.lblLugarDesapPersonaBI.Text = "";
            this.lblPartidoDesaparicionBI.Text = "";
            this.lblProvinciaDesapBID.Text = "";
            this.lblNroFotoGralBID.Text = "";
            this.lblNroFotoSeniasBID.Text = "";
            this.imgFotoGeneralBID.ImageUrl = "~/App_Images/SinFoto.GIF";
            this.imgFotoGeneralBID.Width = 80;
            this.imgFotoGeneralBID.Height = 100;
            this.imgFotoGeneralBID.PostBackUrl = "";
            this.imgFotoSeniasBID.ImageUrl = "~/App_Images/SinFoto.GIF";
            this.imgFotoSeniasBID.Width = 80;
            this.imgFotoSeniasBID.Height = 100;
            this.imgFotoSeniasBID.PostBackUrl = "";
            this.lblSexoBID.Text = "";
            this.lblEdadBID.Text = "";
            this.lblColorPielBID.Text = "";
            this.lblLongitudCabelloBID.Text = "";
            this.lblColorOjosBID.Text = "";
            this.lblFaltanPiezasDentalesBID.Text = "";
            this.lblFechaNacimientoBID.Text = "";
            this.lblTallaBID.Text = "";
            this.lblColorCabelloBID.Text = "";
            this.lblAspectoCabelloBID.Text = "";
            this.lblRostroBID.Text = "";
            this.lblFechaDesaparicionBID.Text = "";
            this.lblPesoBID.Text = "";
            this.lblColorTenidoBID.Text = "";
            this.lblCalvicieBID.Text = "";
            this.lblCantidadDiasNoAfeitadoBID.Text = "";
            this.gvSenasPartBID.DataSource = "";
            this.gvTatuajesBID.DataSource = "";
            this.lblCodigoAdnBID.Text = "";
            this.lblRopaBID.Text = "";
            this.lblApellidoBID.Text = "";
            this.lblArticulosPersonalesBID.Text = "";
            this.lblNombresBID.Text = "";
            this.lblFichasDactilaresBID.Text = "";
            this.btnFotoPrevGeneralBID.Enabled = false;
            this.btnFotoPrevSeniasBID.Enabled = false;
            this.btnFotoSigGeneralBID.Enabled = false;
            this.btnFotoSigSeniasBID.Enabled = false;
        }

        private void LlenarControlesFichaPersDesapBI(PersonasDesaparecidas personaDesaparecida)
        {
            if (personaDesaparecida.tieneADN != null)
                this.lblCodigoAdnBID.Text = PBClaseBooleanManager.GetItem((int)personaDesaparecida.tieneADN).Descripcion.Trim();
            if (personaDesaparecida.Ipp != null)
                this.lblIppBID.Text = personaDesaparecida.Ipp.Trim();
            if (personaDesaparecida.Apellido != null)
                this.lblApellidoBID.Text = personaDesaparecida.Apellido.Trim();
            if (personaDesaparecida.Nombre != null)
                this.lblNombresBID.Text = personaDesaparecida.Nombre.Trim();
            if (personaDesaparecida.ArticulosPersonales != null)
                this.lblArticulosPersonalesBID.Text = personaDesaparecida.ArticulosPersonales.Trim();
            if (personaDesaparecida.CantidadDiasNoAfeitado != null)
                this.lblCantidadDiasNoAfeitadoBID.Text = personaDesaparecida.CantidadDiasNoAfeitado.ToString().Trim();
            if (personaDesaparecida.EdadMomentoDesaparicion != null)
                this.lblEdadBID.Text = personaDesaparecida.EdadMomentoDesaparicion.ToString().Trim();
            if (personaDesaparecida.FechaDesaparicion != null)
                this.lblFechaDesapBID.Text = Convert.ToDateTime(personaDesaparecida.FechaDesaparicion).ToString("dd/MM/yyyy");
            if (personaDesaparecida.FechaNacimiento != null)
                this.lblFechaNacBID.Text = Convert.ToDateTime(personaDesaparecida.FechaNacimiento).ToString("dd/MM/yyyy");
            if (personaDesaparecida.Peso != null)
                this.lblPesoBID.Text = personaDesaparecida.Peso.ToString();
            if (personaDesaparecida.Ropa != null)
                this.lblRopaBID.Text = personaDesaparecida.Ropa.Trim();
            if (personaDesaparecida.Talla != null)
                this.lblTallaBID.Text = personaDesaparecida.Talla.ToString().Trim();
            this.lblAspectoCabelloBID.Text = PBClaseAspectoCabelloManager.GetItem(personaDesaparecida.idAspectoCabello).Descripcion.Trim();
            this.lblCalvicieBID.Text = PBClaseCalvicieManager.GetItem(personaDesaparecida.idCalvicie).Descripcion.Trim();
            this.lblColorCabelloBID.Text = PBClaseColorCabelloManager.GetItem(personaDesaparecida.idColorCabello).Descripcion.Trim();
            this.lblColorOjosBID.Text = PBClaseColorOjosManager.GetItem(personaDesaparecida.idColorOjos).Descripcion.Trim();
            this.lblColorPielBID.Text = PBClaseColorDePielManager.GetItem(personaDesaparecida.idColorPiel).Descripcion.Trim();
            this.lblColorTenidoBID.Text = PBClaseColorCabelloManager.GetItem(personaDesaparecida.idColorTenido).Descripcion.Trim();

            if (personaDesaparecida.idLugarDesaparicion > 0)
            {
                this.lblLugarDesapPersonaBI.Text = MPBA.SIAC.Bll.LocalidadManager.GetItem(personaDesaparecida.idLugarDesaparicion).localidad.Trim();
                this.lblPartidoDesaparicionBI.Text = MPBA.SIAC.Bll.PartidoManager.GetItem((MPBA.SIAC.Bll.LocalidadManager.GetItem(personaDesaparecida.idLugarDesaparicion).Partido)).partido.Trim();
                this.lblProvinciaDesapBID.Text = MPBA.SIAC.Bll.ProvinciaManager.GetItem((MPBA.SIAC.Bll.LocalidadManager.GetItem(personaDesaparecida.idLugarDesaparicion).Provincia)).provincia.Trim();
            }
            if (personaDesaparecida.idComisaria > 0)
            {
                this.lblComisariaPersonaBID.Text = MPBA.SIAC.Bll.ComisariaManager.GetItem(personaDesaparecida.idComisaria).comisaria.Trim();
                this.lblDepartamentoComisariaBID.Text = MPBA.SIAC.Bll.DepartamentoManager.GetItem((MPBA.SIAC.Bll.ComisariaManager.GetItem(personaDesaparecida.idComisaria).idDepartamento)).departamento.Trim();
            }
            //this.lblDentaduraD.Text = personaDesaparecida.idDentadura.ToString();
            this.lblExistenRadiografiasBID.Text = PBClaseBooleanManager.GetItem((int)personaDesaparecida.ExistenRadiografia).Descripcion.Trim();
            this.lblFaltanPiezasDentalesBID.Text = PBClaseBooleanManager.GetItem((int)personaDesaparecida.FaltanPiezasDentales).Descripcion.Trim();
            this.lblFichasDactilaresBID.Text = PBClaseBooleanManager.GetItem((int)personaDesaparecida.FichasDactilares).Descripcion.Trim();
            //this.lblFotoBID.Text = PBClaseBooleanManager.GetItem((int)personaDesaparecida.Foto).Descripcion.Trim();
            this.lblLongitudCabelloBID.Text = PBClaseLongitudCabelloManager.GetItem(personaDesaparecida.idLongitudCabello).Descripcion.Trim();
            this.lblOrganismoIntervinienteBID.Text = PBClaseOrganismoIntervinienteManager.GetItem(personaDesaparecida.idOrganismoInterviniente).Descripcion;
            this.lblRostroBID.Text = PBClaseRostroManager.GetItem(personaDesaparecida.idRostro).Descripcion.Trim();
            //this.lblSeniasParticularesD.Text = personaDesaparecida.idSeniaParticular.ToString();
            this.lblSexoBID.Text = PBClaseSexoManager.GetItem(personaDesaparecida.idSexo).Descripcion.Trim();
            //Senas Particulares
            SeniasD = personaDesaparecida.seniasParticularess;
            Session["SeniasD"] = SeniasD;
            this.gvSenasPartBID.DataSource = SeniasD;
            this.gvSenasPartBID.DataBind();
            ////////////
            //Tatuajes
            TatuajesD = personaDesaparecida.tatuajesPersonas;
            Session["TatuajesD"] = TatuajesD;
            this.gvTatuajesBID.DataSource = TatuajesD;
            this.gvTatuajesBID.DataBind();
            ///////////////
            this.hfGestionFichaPersDesapBI.Value = personaDesaparecida.Id.ToString();
            FotosGralesBI.DataSource = personaDesaparecida.fotoss.FindAll(delegate(PBFotos f) { return f.idTipoFoto == (int)FuncionesGrales.TipoFoto.General; });
            if (FotosGralesBI.Count > 0)
            {
                FotosGralesBI.MoveFirst();
                PBFotos f = (PBFotos)FotosGralesBI.Current;
                LlenarImgBoxFichaBI(f, FuncionesGrales.TipoBusqueda.PersonaDesaparecida, FuncionesGrales.TipoFoto.General);
                this.lblNroFotoGralBID.Text = (FotosGralesBI.Position + 1).ToString() + "/" + FotosGralesBI.Count.ToString();
                this.lblNroFotoSeniasBID.Text = (FotosSeniasBI.Position + 1).ToString() + "/" + FotosSeniasBI.Count.ToString();
            }
            FotosSeniasBI.DataSource = personaDesaparecida.fotoss.FindAll(delegate(PBFotos f) { return f.idTipoFoto == (int)FuncionesGrales.TipoFoto.SeniasParticulares; });
            if (FotosSeniasBI.Count > 0)
            {
                FotosSeniasBI.MoveFirst();
                PBFotos f = (PBFotos)FotosSeniasBI.Current;
                LlenarImgBoxFichaBI(f, FuncionesGrales.TipoBusqueda.PersonaDesaparecida, FuncionesGrales.TipoFoto.SeniasParticulares);
                this.lblNroFotoGralBID.Text = (FotosGralesBI.Position + 1).ToString() + "/" + FotosGralesBI.Count.ToString();
                this.lblNroFotoSeniasBID.Text = (FotosSeniasBI.Position + 1).ToString() + "/" + FotosSeniasBI.Count.ToString();
                //this.lblSeniaParticularBI.Visible = true;
            }
            //else
                //this.lblSeniaParticularBI.Visible = false;

        }
        protected void btnFotoSigGeneralBID_Click(object sender, EventArgs e)
        {
            AvanzarFotoFichaBI(FuncionesGrales.TipoBusqueda.PersonaDesaparecida, FuncionesGrales.TipoFoto.General, Convert.ToInt32(this.hfOkFichaBID.Value));
        }

        protected void btnFotoPrevGeneralBID_Click(object sender, EventArgs e)
        {
            RetrocederFotoFichaBI(FuncionesGrales.TipoBusqueda.PersonaDesaparecida, FuncionesGrales.TipoFoto.General, Convert.ToInt32(this.hfOkFichaBID.Value));
        }

        protected void btnFotoSigSeniasBID_Click(object sender, EventArgs e)
        {
            AvanzarFotoFichaBI(FuncionesGrales.TipoBusqueda.PersonaDesaparecida, FuncionesGrales.TipoFoto.SeniasParticulares, Convert.ToInt32(this.hfOkFichaBID.Value));
        }

        protected void btnFotoPrevSeniasBID_Click(object sender, EventArgs e)
        {
            RetrocederFotoFichaBI(FuncionesGrales.TipoBusqueda.PersonaDesaparecida, FuncionesGrales.TipoFoto.SeniasParticulares, Convert.ToInt32(this.hfOkFichaBID.Value));
        }
        protected void btnCerrarBID_Click(object sender, EventArgs e)
        {
            //FuncionesGrales.

            this.hfGestionFichaPersDesapBI_ModalPopupExtender.Hide();
            ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "btnOkCantCoincidencias();", true);
            //this.hfAbrirResultadosBI_ModalPopupExtender1.Show();
        }
      
    }


    
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Bll;
using MPBA.AutoresIgnorados.Bll;
using MPBA.AutoresIgnorados.BusinessEntities;
using System.Xml;
using System.Net;
using MPBA.SIAC.Web;
using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Bll;
using MPBA.SIAC.Web.WebServiceSIC;


namespace MPBA.AutoresIgnorados.Web
{
    public partial class CargaAutores : System.Web.UI.Page
    {
 //prueba
        bool esNN;//si es nn o aprehendidos
        //FuncionesComunes.TipoAutores TipoAutor;
        private bool ConsultandoSIC = false;
        SeniasParticularesList SeniasD;
        TatuajesPersonaList TatuajesD;
        

        #region "Eventos"
        protected void Page_Load(object sender, EventArgs e)
        {
            esNN = Convert.ToBoolean(Session["esNN"]);
            //esNN = true;
           // this.lblLoggeadoSic.Visible = (Session["ClaveSIC"] != null);
            //TipoAutor = (FuncionesComunes.TipoAutores)(Convert.ToInt32(Request.QueryString["tipo"].ToString().Substring(0, 1)));
            //TipoAutor = FuncionesComunes.TipoAutores.Desconocidos;
            SeniasD = Session["SeniasD"] == null ? new SeniasParticularesList() : (SeniasParticularesList)Session["SeniasD"];
            TatuajesD = Session["TatuajesD"] == null ? new TatuajesPersonaList() : (TatuajesPersonaList)Session["TatuajesD"];
            if (!Page.IsPostBack)
            {

                HabilitarCamposSomaticos(false);
                //esNN = true;
                //Delitos delito = new Delitos();
                //delito.idCausa = "010000000103";
                //Session["miDelito"] = delito;
                switch (esNN)
                {
                    case false://autores aprehendidos
                        this.imgCartelVictimas.ImageUrl = "~/App_Images/cartelAutoresConocidos.png";
                        this.cartelPrincipal.InnerText = "AUTORES APREHENDIDOS";
                        this.pnlAutor.Visible = true;
                       this.gvAutores.Columns[4].Visible = true;//nombre
                        this.gvAutores.Columns[5].Visible = true;//apellido
                        this.gvAutores.Columns[6].Visible = true;//doc nro
                        this.pnlAutorSic.Visible = true;
                        break;
                    case true://autores desconocidos
                        this.imgCartelVictimas.ImageUrl = "~/App_Images/cartelAutores.png";
                        this.cartelPrincipal.InnerText = "AUTORES IGNORADOS";
                        this.pnlAutor.Visible = false;
                        this.pnlAutorSic.Visible = false;
                         this.gvAutores.Columns[4].Visible = false;//nombre
                        this.gvAutores.Columns[5].Visible = false;//apellido
                        this.gvAutores.Columns[6].Visible = false;//doc nro
                        break;
                    default:
                        return;

                }
                bool esConsulta = Request.QueryString["c"].ToString() == "1" ? true : false;
                if (esConsulta)
                    this.pnlAutores.Enabled = false;
                LimpiarControles();
                LlenarControles();
                IndicarStatus();
                this.pnlDelitosSIC.Style.Add("display", "none");
                this.pnlServerSicOcupado.Style.Add("display", "none");
                this.pnlCargaAutores.Style.Add("display", "none");
                this.pnlResultadosDatosSic.Style.Add("display", "none");
                this.pnlPersonasEncontradas.Style.Add("display", "none");
                Panel pnlWaitingOverlaySic = (Panel)this.upWaitingSic.FindControl("pnlWaitingOverlaySic");
                Panel pnlWaitingSic = (Panel)this.upWaitingSic.FindControl("pnlWaitingSic");
                Panel pnlWaitingOverlayPersonas = (Panel)this.upWaitingPersonas.FindControl("pnlWaitingOverlayPersonas");
                Panel pnlWaitingPersonas = (Panel)this.upWaitingPersonas.FindControl("pnlWaitingPersonas");
                Panel pnlWaitingOverlayBusquedaSic = (Panel)this.upBusquedaSic.FindControl("pnlWaitingOverlayBusquedaSic");
                Panel pnlWaitingBusquedaSic = (Panel)this.upBusquedaSic.FindControl("pnlWaitingBusquedaSic");
                pnlWaitingSic.CssClass = "loader";
                pnlWaitingOverlaySic.CssClass = "overlay";
                pnlWaitingPersonas.CssClass = "loader";
                pnlWaitingOverlayPersonas.CssClass = "overlay";
                pnlWaitingBusquedaSic.CssClass = "loader";
                pnlWaitingOverlayBusquedaSic.CssClass = "overlay";
                ActivarBotonesSic(Session["ClaveSIC"]!=null);
                //ActivarBotonesSic(true);
            }
        }

        protected void btnAgregarPrimerTatuaje_Click(object sender, EventArgs e)
        {
            GridView gvTatuajes = null;
            string argumento = ((LinkButton)sender).CommandArgument;
            switch (argumento)
            {
                case "D":
                    gvTatuajes = this.gvTatuajesD;
                    break;
            }

            MPBA.SIAC.BusinessEntities.TatuajesPersona tatuaje = new TatuajesPersona();
            tatuaje.idTatuaje = Convert.ToInt32(((DropDownList)gvTatuajes.Controls[0].Controls[0].Controls[0].FindControl("ddlTatuajes")).SelectedValue);
            tatuaje.idUbicacionTatuaje = Convert.ToInt32(((DropDownList)gvTatuajes.Controls[0].Controls[0].Controls[0].FindControl("ddlUbicacionTatuaje")).SelectedValue);
            tatuaje.descripcion = Convert.ToString(((TextBox)gvTatuajes.Controls[0].Controls[0].Controls[0].FindControl("descripcionTatuajeInsert")).Text);
            tatuaje.id = -1;
            TatuajesD = new TatuajesPersonaList();
            TatuajesD.Add(tatuaje);
            Session["TatuajesD"] = TatuajesD;
            gvTatuajes.DataSource = TatuajesD;
            gvTatuajes.DataBind();
         }
        protected void gvTatuajes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            e.Cancel = true;
            GridView gvTatuajes = (GridView)sender;
                    gvTatuajes.EditIndex = -1;
                    gvTatuajes.DataSource = TatuajesD;
                    gvTatuajes.DataBind();
        }

        protected void gvTatuajes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
            GridView gvTatuajes = (GridView)sender;
                 
                    gvTatuajes.EditIndex = -1;
                    TatuajesD.RemoveAt(e.RowIndex);
                    gvTatuajes.DataSource = TatuajesD;
                    gvTatuajes.DataBind();
         }

        protected void gvTatuajes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView gvTatuajes = (GridView)sender;
                    gvTatuajes.EditIndex = e.NewEditIndex;
                    int id = Convert.ToInt32(gvTatuajes.DataKeys[e.NewEditIndex].Value);
                    gvTatuajes.DataSource = TatuajesD;
                    gvTatuajes.DataBind();
         }

        protected void gvTatuajes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
  
            GridView gvTatuajes = (GridView)sender;
                    MPBA.SIAC.BusinessEntities.TatuajesPersona tatuaje = TatuajesD[e.RowIndex];
                    tatuaje.idTatuaje = Convert.ToInt32(((DropDownList)(gvTatuajes.Rows[e.RowIndex].Cells[3].FindControl("ddlTatuajes"))).SelectedValue);
                    tatuaje.idUbicacionTatuaje = Convert.ToInt32(((DropDownList)(gvTatuajes.Rows[e.RowIndex].Cells[4].FindControl("ddlUbicacionTatuaje"))).SelectedValue);
                    tatuaje.descripcion = Convert.ToString(((TextBox)(gvTatuajes.Rows[e.RowIndex].Cells[5].FindControl("descripcionTatuajePart"))).Text);
                      gvTatuajes.EditIndex = -1;
                    gvTatuajes.DataSource = TatuajesD;
                    gvTatuajes.DataBind();
          }

        protected void btnAgregarTatuaje_Click(object sender, EventArgs e)
        {
            GridView gvTatuajes = null;
            string argumento = ((LinkButton)sender).CommandArgument;
                    gvTatuajes = this.gvTatuajesD;
            MPBA.SIAC.BusinessEntities.TatuajesPersona tatuaje = new TatuajesPersona();
            tatuaje.idTatuaje = Convert.ToInt32(((DropDownList)gvTatuajes.FooterRow.FindControl("ddlTatuajeInsert")).SelectedValue);
            tatuaje.idUbicacionTatuaje = Convert.ToInt32(((DropDownList)gvTatuajes.FooterRow.FindControl("ddlUbicacionTatuajeInsert")).SelectedValue);
            tatuaje.descripcion = Convert.ToString(((TextBox)gvTatuajes.FooterRow.FindControl("descripcionTatuajeInsert")).Text);
            tatuaje.id = -1;
            tatuaje.idTablaDestino = 1;
                TatuajesD.Add(tatuaje);
                gvTatuajes.DataSource = TatuajesD;
  
            gvTatuajes.DataBind();

        }

        protected void btnAgregarSenia_Click(object sender, EventArgs e)
        {
            GridView gvSenasPart = null;
            string argumento = ((LinkButton)sender).CommandArgument;
            switch (argumento)
            {
                case "D":
                    gvSenasPart = this.gvSenasPartD;
                    SeniasParticulares sena = new SeniasParticulares();
                    sena.idSeniaParticular = Convert.ToInt32(((DropDownList)gvSenasPart.FooterRow.FindControl("ddlSeniaPartInsert")).SelectedValue);
                    sena.idUbicacionSeniaParticular = Convert.ToInt32(((DropDownList)gvSenasPart.FooterRow.FindControl("ddlUbicacionSenaPartInsert")).SelectedValue);
                    sena.descripcion = Convert.ToString(((TextBox)gvSenasPart.FooterRow.FindControl("descripcionInsert")).Text);
                    sena.id = -1;
                    sena.idTablaDestino = 1;
                    SeniasD.Add(sena);
                    gvSenasPart.DataSource = SeniasD;
                    gvSenasPart.DataBind();
                    break;
               
            }
           }


        protected void gvSenasPart_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int id = 0;
            GridView gvSenasPart = (GridView)sender;
           
                    gvSenasPart.EditIndex = e.NewEditIndex;
                    id = Convert.ToInt32(gvSenasPart.DataKeys[e.NewEditIndex].Value);
                    gvSenasPart.DataSource = SeniasD;
                    gvSenasPart.DataBind();
                
               
        }

        protected void gvSenasPart_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            e.Cancel = true;
            GridView gvSenasPart = (GridView)sender;
             gvSenasPart.EditIndex = -1;
                    gvSenasPart.DataSource = SeniasD;
                    gvSenasPart.DataBind();
        }

        protected void gvSenasPart_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SeniasParticulares senia;
            GridView gvSenasPart = (GridView)sender;
            switch (gvSenasPart.ID)
            {
                case "gvSenasPartD":
                    senia = SeniasD[e.RowIndex];
                    senia.idSeniaParticular = Convert.ToInt32(((DropDownList)(gvSenasPart.Rows[e.RowIndex].Cells[3].FindControl("ddlSeniaPart"))).SelectedValue);
                    senia.idUbicacionSeniaParticular = Convert.ToInt32(((DropDownList)(gvSenasPart.Rows[e.RowIndex].Cells[4].FindControl("ddlUbicacionSenaPart"))).SelectedValue);
                    senia.descripcion = Convert.ToString(((TextBox)(gvSenasPart.Rows[e.RowIndex].Cells[5].FindControl("descripcionSenaPart"))).Text);
                    gvSenasPart.EditIndex = -1;
                    gvSenasPart.DataSource = SeniasD;
                    gvSenasPart.DataBind();
                    break;
               
            }



        }

        protected void gvSenasPart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
            GridView gvSenasPart = (GridView)sender;
            switch (gvSenasPart.ID)
            {
                case "gvSenasPartD":

                    gvSenasPart.EditIndex = -1;
                    SeniasD.RemoveAt(e.RowIndex);
                    gvSenasPart.DataSource = SeniasD;
                    gvSenasPart.DataBind();
                    break;
               
            }


        }

        protected void btnAgregarPrimeraSenia_Click(object sender, EventArgs e)
        {

            GridView gvSenasPart = null;
            string argumento = ((LinkButton)sender).CommandArgument;
            SeniasParticulares sena;
            switch (argumento)
            {
             
                case "D":
                    gvSenasPart = this.gvSenasPartD;
                    sena = new SeniasParticulares();
                    sena.idSeniaParticular = Convert.ToInt32(((DropDownList)gvSenasPart.Controls[0].Controls[0].Controls[0].FindControl("ddlSenasParticulares")).SelectedValue);
                    sena.idUbicacionSeniaParticular = Convert.ToInt32(((DropDownList)gvSenasPart.Controls[0].Controls[0].Controls[0].FindControl("ddlUbicacionSenasPart")).SelectedValue);
                    sena.descripcion = Convert.ToString(((TextBox)(gvSenasPart.Controls[0].Controls[0].Controls[0].FindControl("descripcionSenaPart"))).Text);
                    sena.id = -1;
                    sena.idTablaDestino = 1;
                    SeniasD = new SeniasParticularesList();
                    SeniasD.Add(sena);
                    Session["SeniasD"] = SeniasD;
                    gvSenasPart.DataSource = SeniasD;
                    gvSenasPart.DataBind();
                    break;
              
            }

           

        }

        
        
        
        private void TraerAutorDelSimpConWebService(string ipp)
        {
            Session["plSimp"] = null;
            MPBA.SIAC.Web.WebServiceIPP.WebServiceMesaVirtualNN wsIPP = new MPBA.SIAC.Web.WebServiceIPP.WebServiceMesaVirtualNN();
            try
            {
                string depto = System.Configuration.ConfigurationManager.AppSettings["dptos_SIMP6"].ToString();
                string ippSimp;

                if (ipp.Substring(0, 2).Contains(depto))
                {
                    ippSimp = wsIPP.ConsultaCaratula(ipp, "00");
                }
                else
                {
                    ippSimp = wsIPP.ConsultaCaratula(ipp, "NULL");

                }
                wsIPP.Dispose();
                XmlTextReader reader = new XmlTextReader(new System.IO.StringReader(ippSimp));
                PersonaList plSimp = new PersonaList();
                while (reader.Read())
                {
                    if (reader.NodeType != XmlNodeType.Element)
                        continue;
                    switch (reader.Name)
                    {
                         case "Imputado":
                            while (reader.MoveToNextAttribute())
                            {
                                string nombre = reader.Name.ToLower();
                                string valor = reader.Value;
                                Persona pSimp = new Persona();
                                switch (nombre)
                                {
                                    case "apellido":
                                        pSimp.Apellido = valor;
                                        break;
                                    case "nombre":
                                        pSimp.Nombre = valor;
                                        break;
                                    case "dni":
                                        pSimp.DocumentoNumero = Convert.ToInt32(valor);
                                        break;
                                }
                                if (pSimp.Apellido != null && pSimp.Apellido != "")
                                {
                                    plSimp.Add(pSimp);
                                }
                            }
                            break;
                         
                    }
                    if (plSimp.Count > 0)
                    {
                        Session["plSimp"] = plSimp;
                        this.divHeaderPersonas.InnerText = "PERSONAS ENCONTRADAS EN EL SIMP";
                        this.btnElegirPersonaEncontrada.Visible = false;
                        this.gvPersonasEncontradas.DataSource = plSimp;
                        this.gvPersonasEncontradas.DataBind();
                        this.btnVerPersonasSimp.Visible = true;
                    }
                    else
                        this.btnVerPersonasSimp.Visible = false;
                }
            }
            catch { System.Web.Services.Protocols.SoapException ex; }
        }

        protected void gvAutores_SelectedIndexChanged(object sender, EventArgs e)
        {
            Delitos miDelito = (Delitos)Session["miDelito"];
            Session["miAutor"] = miDelito.autoress[this.gvAutores.SelectedIndex];
            if (ConsultandoSIC && Session["ClaveSIC"] != null)
            {
                //if (Session["ClaveSIC"] == "false")
                //{
                //    //this.txtUsuarioSic.Text = "";
                //    //this.txtClaveSic.Text = "";
                //    this.hfGestionAccesoSic_ModalPopupExtender.Show();
                //}

                //if (Session["ClaveSIC"] == "false")
                //    return;
                LimpiarControlesPanelSic();
                LlenarControlesPanelSic();
                ConsultandoSIC = false;
                //TraerDelitosSIC(false);
                this.hfGestionSIC_ModalPopupExtender.Show();

                return;
            }
            else if (ConsultandoSIC == false)
            {


                LimpiarControlesPanelAutor();

                LlenarControlesPanelAutor();

                this.hfGestionAutor_ModalPopupExtender.Show();
            }
        }

        protected void gvAutores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
            Delitos miDelito = (Delitos)Session["miDelito"];
            List<Autores> autores = miDelito.autoress.FindAll(delegate(Autores aut) { return aut.Baja == false; });
            Autores autor = autores[e.RowIndex];
            if (autor.id == -1)
            {
                for (int i = 0; i < miDelito.autoress.Count; i++)
                {
                    if (autor.Equals(miDelito.autoress[i]))
                    {
                        Autores au = miDelito.autoress[i];
                        //*********************************************************
                        //PARA BORRAR LA PERSONA SI NO ESTA SIENDO USADA POR SIAC**
                        //*********************************************************
                        //Persona per;
                        //if (PersonaSoloEstaCausa(au.idPersona))
                        //{
                        //    per = PersonaManager.GetItem(au.idPersona);
                        //    PersonaManager.Delete(per);
                        //}
                        //**********************************************************
                        miDelito.autoress.Remove(au);
                    }
                }
            }
            //miDelito.autoress.Remove(autor);
            else
                autor.Baja = true;
            this.gvAutores.DataSource = "";
            this.gvAutores.DataSource = miDelito.autoress.FindAll(delegate(Autores aut) { return aut.Baja == false; });
            //this.gvAutores.DataSource = miDelito.autoress;
            this.gvAutores.DataBind();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.rfvApellidoAutor.Enabled = false;
            this.pnlCargaAutores.Style.Add("display","none");
            this.hfGestionAutor_ModalPopupExtender.Hide();

        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session["miDelito"] = null;
            Session["moduloActual"] = null;
            Response.Redirect("~/Home.aspx");
            
          
            
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
        
            this.rfvApellidoAutor.Enabled = true;
            if (this.txtDniAutor.Text.Trim().Length > 9)
                this.cvDniAutor.IsValid = false;
            else
                this.cvDniAutor.IsValid = true;
            this.rfvApellidoAutor.Validate();
            if (!this.IsValid)
                return;

            //if ((Autores)Session["miAutor"] == null)//es nuevo autor
            //{
            if (!esNN && ControlarPersonaExistente() == true)
                return;
            
            //}


            this.cvSenaSinIncorporar.IsValid = ValidarSenas();
            this.cvTatuajeSinIncorporar.IsValid = ValidarTatuajes();
            if (!this.IsValid)
                return;
            GuardarAutor();
            MPBA.AutoresIgnorados.Web.CargaAutores ca = (MPBA.AutoresIgnorados.Web.CargaAutores)Session["miCargaAutores"];
            this.hfGestionAutor_ModalPopupExtender.Hide();
            ActivarBotonesSic(Session["ClaveSIC"] != null);
            this.pnlCargaAutores.Style.Add("display", "none");

            
        }



        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            GuardarDelito();
            //Session["moduloActual"] = null;
            //Server.Transfer("~/CargaBienesSustraidos.aspx");
            bool esConsulta = Request.QueryString["c"].ToString() == "1" ? true : false;
            if (esConsulta)
                Response.Redirect("CargaBienesSustraidos.aspx?c=1");
            else
                Response.Redirect("CargaBienesSustraidos.aspx?c=0");
        }

        #endregion

        #region "Metodos"
        private void IndicarStatus()
        {
            Delitos miDelito = (Delitos)Session["miDelito"];
            if (miDelito.id == -1)
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
            this.ddlCantidad.SelectedValue = Convert.ToString(0);
            this.pnlCargaAutores.Style.Add("display", "none");
            this.txtRostroCon.Visible = false;
            this.lblRostroCon.Visible = false;
            this.lblLimiteResultadosSic.Visible = false;
            SeniasD = null;
            SeniasD = new SeniasParticularesList();
            this.gvSenasPartD.DataSource = SeniasD;
            this.gvSenasPartD.DataBind();
            TatuajesD = null;
            TatuajesD = new TatuajesPersonaList();
            this.gvTatuajesD.DataSource = TatuajesD;
            this.gvTatuajesD.DataBind();
          
        }

        private void LlenarControles()
        {
            Delitos miDelito = (Delitos)Session["miDelito"];
            this.ddlCantidad.Text = Convert.ToString(miDelito.idClaseCantidadAutores);
            this.gvAutores.DataSource = miDelito.autoress.FindAll(delegate(Autores aut) { return aut.Baja == false; });
            this.gvAutores.DataBind();
            TatuajesD = Session["TatuajesD"] == null ? new TatuajesPersonaList() : (TatuajesPersonaList)Session["TatuajesD"];
           SeniasD = Session["SeniasD"] == null ? new SeniasParticularesList() : (SeniasParticularesList)Session["SeniasD"];
            
            
        }

        private void GuardarAutor()
        {
            Autores miAutor = (Autores)Session["miAutor"];
            bool esNuevoAutor = (miAutor == null);//si es nulo estoy dando de alta
            if (esNuevoAutor)
            {
                miAutor = new Autores();
                miAutor.id = -1;
            }
            Delitos miDelito = (Delitos)Session["miDelito"];
            miAutor.idCausa = miDelito.idCausa;
            miAutor.Nro = this.txtNroAutor.Text.Trim();
            miAutor.idClaseEdadAproximada = Convert.ToInt32(this.ddlEdad.SelectedValue);
            miAutor.idClaseSexo = Convert.ToInt32(this.ddlSexo.SelectedValue);
            miAutor.idClaseCalvicie = Convert.ToInt32(this.ddlTipoCalvicie.SelectedValue);
            miAutor.idClaseColorCabello = Convert.ToInt32(this.ddlColorCabello.SelectedValue);
            miAutor.idClaseColorOjos = Convert.ToInt32(this.ddlColorOjos.SelectedValue);
            miAutor.idClaseColorPiel = Convert.ToInt32(this.ddlColorPiel.SelectedValue);
            miAutor.idClaseEstatura = Convert.ToInt32(this.ddlEstatura.SelectedValue);
            miAutor.idClaseFormaCara = Convert.ToInt32(this.ddlFormaCara.SelectedValue);
            miAutor.idClaseRobustez = Convert.ToInt32(this.ddlRobustez.SelectedValue);
            miAutor.idTipoCeja = Convert.ToInt32(this.ddlTipoCeja.SelectedValue);
            miAutor.idClaseTipoCabello = Convert.ToInt32(this.ddlTipoCabello.SelectedValue);
            miAutor.idDimensionCeja = Convert.ToInt32(this.ddlCejasDimension.SelectedValue);
            miAutor.idFormaBoca = Convert.ToInt32(this.ddlFormaBoca.SelectedValue);
            miAutor.idFormaLabioInferior = Convert.ToInt32(this.ddlFormaLabioInferior.SelectedValue);
            miAutor.idFormaLabioSuperior = Convert.ToInt32(this.ddlFormaLabioSuperior.SelectedValue);
            miAutor.idFormaMenton = Convert.ToInt32(this.ddlFormaMenton.SelectedValue);
            miAutor.idFormaNariz = Convert.ToInt32(this.ddlFormaNariz.SelectedValue);
            miAutor.idFormaOreja = Convert.ToInt32(this.ddlFormaOreja.SelectedValue);
            miAutor.idClaseRostro = Convert.ToInt32(this.ddlRostro.SelectedValue);
            int idDestino;
            idDestino = esNN ? (int) MPBA.SIAC.Web.FuncionesGenerales.TipoPersonas.AutorIgnorado : (int) MPBA.SIAC.Web.FuncionesGenerales.TipoPersonas.AutorAprehendido;
            //Senas Particulares
            if (SeniasD != null)
                
            { 
                /*Borra las senias Particulares que tenia e inserta las nuevas*/
                /*El tipo de Persona es 3 : Ignorado 4 : Aprehendido */
            


                SeniasParticularesList spl = SeniasParticularesManager.GetListByidAutor(miAutor.id);
                foreach (SeniasParticulares sp in spl)
                {
                    SeniasParticularesManager.Delete(sp);
                }
                foreach (SeniasParticulares sp in SeniasD)
                {
                    sp.id = -1;
                    sp.idTablaDestino = idDestino;
                }


                miAutor.seniasParticularess = SeniasD;
            }

            TatuajesPersonaList tpl = TatuajesPersonaManager.GetListByidAutor(miAutor.id);
            foreach (TatuajesPersona tp in tpl)
            {
                TatuajesPersonaManager.Delete(tp);
            }

            foreach (TatuajesPersona tp in TatuajesD)
            {
                tp.id = -1;
                tp.idTablaDestino = idDestino;
            }
            miAutor.tatuajesPersonas = TatuajesD;


        /*    miAutor.idClaseSeniaParticular = Convert.ToInt32(this.ddlSena.SelectedValue);
            miAutor.idClaseLugarDelCuerpo = Convert.ToInt32(this.ddlTatuajeLugar.SelectedValue);
            miAutor.idClaseTatuaje = Convert.ToInt32(this.ddlTatuajeTipo.SelectedValue);*/

            miAutor.OtraCaracteristica = this.txtOtraCaracteristica.Text.Trim();
            miAutor.CubiertoCon = this.txtRostroCon.Text.Trim();
            //miAutor.UbicacionSeniaParticular = this.txtUbicacion.Text.Trim();
            miAutor.FechaUltimaModificacion = DateTime.Now;
            miAutor.idUsuarioUltimaModificacion = Session["miUsuario"].ToString();
            if (!esNN)
            {
                Persona identificacionAutor = new Persona();

                if (miAutor.idPersona > 0)
                {
                    identificacionAutor = PersonaManager.GetItem(miAutor.idPersona);
                    identificacionAutor.DocumentoNumero = Convert.ToInt32( this.txtDniAutor.Text.Trim());
                        identificacionAutor.Nombre = this.txtNombreAutor.Text.Trim();
                        identificacionAutor.Apellido = this.txtApellidoAutor.Text.Trim();
                        identificacionAutor.Apodo = this.txtApodoAutor.Text.Trim();
                        miAutor.idPersona = PersonaManager.Save(identificacionAutor);
                    //if (PersonaSoloEstaCausa(miAutor.idPersona))
                        //PersonaManager.Delete(identificacionAutor);

                    //identificacionAutor = new Persona();
                    //miAutor.idPersona = -1;
                    
                }
                if (miAutor.idPersona<=0)
                {
                    if (this.hfIdPersonaEncontrada.Value != null && this.hfIdPersonaEncontrada.Value.Trim() != "")
                        miAutor.idPersona = Convert.ToInt32(this.hfIdPersonaEncontrada.Value);
                    else
                    {
                        identificacionAutor.id = -1;
                        string dni;
                        //if (Int32.TryParse(this.txtDniAutor.Text.Trim(), out dni))
                        //    identificacionAutor.DocumentoNumero = dni;
                        identificacionAutor.DocumentoNumero = Convert.ToInt32(this.txtDniAutor.Text.Trim());
                        identificacionAutor.Nombre = this.txtNombreAutor.Text.Trim();
                        identificacionAutor.Apellido = this.txtApellidoAutor.Text.Trim();
                        identificacionAutor.Apodo = this.txtApodoAutor.Text.Trim();
                        miAutor.idPersona = PersonaManager.Save(identificacionAutor);
                    }
                }
                
            }
            if (esNuevoAutor)
                miDelito.autoress.Add(miAutor);
            miAutor = null;
            Session["miAutor"] = null;
            this.gvAutores.DataSource = null;
            //Delitos miDelito = (Delitos)Session["miDelito"];
            this.gvAutores.DataSource = miDelito.autoress.FindAll(delegate(Autores aut) { return aut.Baja == false; });
            this.gvAutores.DataBind();
        }


        /// <summary>
        /// Indica si la persona solo se usa en esta causa, por lo que podria modificarla
        /// </summary>
        /// <param name="idPersona">persona en cuestion</param>
        /// <returns>Si se usa solo en esta ipp o no</returns>
        private bool PersonaSoloEstaCausa(int idPersona)
        {
            Delitos miDelito = (Delitos)Session["miDelito"];
            AutoresList alist = AutoresManager.GetListJoinedPersonasByIdPersona(idPersona);
            if  (alist.Count==0 || (alist.Count == 1 && alist[0].idCausa == miDelito.idCausa))
                return true;
            else
                return false;
        }

        private void GuardarDelito()
        {
            int nro = 0;
            Delitos miDelito = (Delitos)Session["miDelito"];
            if (int.TryParse(this.ddlCantidad.Text.Trim(), out nro))
                miDelito.idClaseCantidadAutores = nro;
            Session["miDelito"] = miDelito;
        }

        /// <summary>
        /// Para Carga o editar datos del autor: Llena los controles del panel de datos del autor
        /// </summary>
        private void LlenarControlesPanelAutor()
        {
            Autores miAutor = (Autores)Session["miAutor"];
            if (miAutor.Nro != null)
            {
                this.txtNroAutor.Text = miAutor.Nro.Trim();
            }
            else
            {
                this.txtNroAutor.Text = "";
            }
            if (miAutor.idPersona != 0)
            {
                string nombre = PersonaManager.GetItem(miAutor.idPersona).Nombre;
                string apodo = PersonaManager.GetItem(miAutor.idPersona).Apodo;
                int docnro = PersonaManager.GetItem(miAutor.idPersona).DocumentoNumero;
                if (nombre!=null)
                    this.txtNombreAutor.Text = nombre.Trim();
                if (apodo != null)
                    this.txtApodoAutor.Text = apodo.Trim();
                this.txtApellidoAutor.Text = PersonaManager.GetItem(miAutor.idPersona).Apellido.Trim();
                if (docnro != null)
                    this.txtDniAutor.Text = docnro.ToString();
            }
            this.ddlEdad.SelectedValue = miAutor.idClaseEdadAproximada.ToString();
            this.ddlSexo.SelectedValue = miAutor.idClaseSexo.ToString();
            this.ddlCejasDimension.SelectedValue = miAutor.idDimensionCeja.ToString();
            this.ddlColorCabello.SelectedValue = miAutor.idClaseColorCabello.ToString();
            this.ddlColorOjos.SelectedValue = miAutor.idClaseColorOjos.ToString();
            this.ddlColorPiel.SelectedValue = miAutor.idClaseColorPiel.ToString();
            this.ddlEstatura.SelectedValue = miAutor.idClaseEstatura.ToString();
            this.ddlFormaBoca.SelectedValue = miAutor.idFormaBoca.ToString();
            this.ddlFormaCara.SelectedValue = miAutor.idClaseFormaCara.ToString();
            this.ddlFormaLabioInferior.SelectedValue = miAutor.idFormaLabioInferior.ToString();
            this.ddlFormaLabioSuperior.SelectedValue = miAutor.idFormaLabioSuperior.ToString();
            this.ddlFormaMenton.SelectedValue = miAutor.idFormaMenton.ToString();
            this.ddlFormaNariz.SelectedValue = miAutor.idFormaNariz.ToString();
            this.ddlFormaOreja.SelectedValue = miAutor.idFormaOreja.ToString();
            this.ddlRobustez.SelectedValue = miAutor.idClaseRobustez.ToString();
            this.ddlTipoCabello.SelectedValue = miAutor.idClaseTipoCabello.ToString();
            this.ddlTipoCalvicie.SelectedValue = miAutor.idClaseCalvicie.ToString();
            this.ddlTipoCeja.SelectedValue = miAutor.idTipoCeja.ToString();
            this.ddlRostro.SelectedValue = miAutor.idClaseRostro.ToString();
            //Senas Particulares
            Session["SeniasD"] = miAutor.seniasParticularess;
            this.gvSenasPartD.DataSource = miAutor.seniasParticularess;
            this.gvSenasPartD.DataBind();
                        
            //Tatuajes
            Session["TatuajesD"] = miAutor.tatuajesPersonas;
            this.gvTatuajesD.DataSource = miAutor.tatuajesPersonas;
            this.gvTatuajesD.DataBind();
          /*  this.ddlSena.SelectedValue = miAutor.idClaseSeniaParticular.ToString();
            this.ddlTatuajeLugar.SelectedValue = miAutor.idClaseLugarDelCuerpo.ToString();
            this.ddlTatuajeTipo.SelectedValue = miAutor.idClaseTatuaje.ToString();*/
            if (miAutor.OtraCaracteristica != null)
            {
                this.txtOtraCaracteristica.Text = miAutor.OtraCaracteristica.Trim();
            }
            else
            {
                this.txtOtraCaracteristica.Text = "";
            }
            if (miAutor.CubiertoCon != null)
            {
                this.txtRostroCon.Text = miAutor.CubiertoCon.Trim();
            }
            else
            {
                this.txtRostroCon.Text = "";
            }
            //if (miAutor.UbicacionSeniaParticular != null)
            //{
            //    this.txtUbicacion.Text = miAutor.UbicacionSeniaParticular.Trim();
            //}
            //else
            //{
            //    this.txtUbicacion.Text = "";
            //}
          /*  if (miAutor.OtroTatuaje != null)
            {
                this.txtOtro.Text = miAutor.OtroTatuaje.Trim();
            }
            else
            {
                this.txtOtro.Text = "";
            }*/
        }

        private void LlenarControlesPanelSic()
        {
            Autores miAutor = (Autores)Session["miAutor"];
            Delitos miDelito = (Delitos)Session["miDelito"];
            Persona miPersona = null;
            if (miAutor.idPersona > 0 && !esNN)
            {
                miPersona = PersonaManager.GetItem(miAutor.idPersona);
                //this.txtDniBusquedaSic.Text = miPersona.DocumentoNumero == 0 ? "" : miPersona.DocumentoNumero.ToString();
                this.txtDniBusquedaSic.Text =  miPersona.DocumentoNumero.ToString();
                this.txtApellidoBusquedaSic.Text = miPersona.Apellido.Trim();
                this.txtNombreBusquedaSic.Text = miPersona.Nombre == null ? "" : miPersona.Nombre.Trim();
            }
            this.txtTatuajeSic.Text = "";
            if (miAutor.tatuajesPersonas.Count > 0)
            {
                foreach (TatuajesPersona tp in miAutor.tatuajesPersonas)
                {
                    txtTatuajeSic.Text += ClaseTatuajeManager.GetItem(tp.idTatuaje).descripcion.Trim() + " " + ClaseUbicacionSeniaPartManager.GetItem(tp.idUbicacionTatuaje).Descripcion.Trim() + " ";
                }
            }
            this.ddlEdadSic.SelectedValue = miAutor.idClaseEdadAproximada.ToString();
            this.ddlSexoSic.SelectedValue = miAutor.idClaseSexo.ToString();
            this.ddlDimensionCejaSic.SelectedValue = miAutor.idDimensionCeja.ToString();
            this.ddlColorCabelloSic.SelectedValue = miAutor.idClaseColorCabello.ToString();
            this.ddlColorOjosSic.SelectedValue = miAutor.idClaseColorOjos.ToString();
            this.ddlColorPielSic.SelectedValue = miAutor.idClaseColorPiel.ToString();
            this.ddlEstaturaSic.SelectedValue = miAutor.idClaseEstatura.ToString();
            this.ddlFormaBocaSic.SelectedValue = miAutor.idFormaBoca.ToString();
            this.ddlFormaCaraSic.SelectedValue = miAutor.idClaseFormaCara.ToString();
            this.ddlLabioInfSic.SelectedValue = miAutor.idFormaLabioInferior.ToString();
            this.ddlLabioSupSic.SelectedValue = miAutor.idFormaLabioSuperior.ToString();
            this.ddlFormaMentonSic.SelectedValue = miAutor.idFormaMenton.ToString();
            this.ddlFormaNarizSic.SelectedValue = miAutor.idFormaNariz.ToString();
            this.ddlFormaOrejaSic.SelectedValue = miAutor.idFormaOreja.ToString();
            this.ddlRobustezSic.SelectedValue = miAutor.idClaseRobustez.ToString();
            this.ddlTipoCabelloSic.SelectedValue = miAutor.idClaseTipoCabello.ToString();
            this.ddlCalvicieSic.SelectedValue = miAutor.idClaseCalvicie.ToString();
            this.ddlTipoCejaSic.SelectedValue = miAutor.idTipoCeja.ToString();
        }

        private void LimpiarControlesPanelAutor()
        {
            this.lblCartelAutorDelSimp.Visible = false;
            this.txtNroAutor.Text = "";
            this.txtApellidoAutor.Text = "";
            this.txtApodoAutor.Text = "";
            this.txtNombreAutor.Text = "";
            this.txtDniAutor.Text = "";
            this.ddlEdad.SelectedValue = Convert.ToString(0);
            this.ddlSexo.SelectedValue = Convert.ToString(0);
            this.ddlCejasDimension.SelectedValue = Convert.ToString(0);
            this.ddlColorCabello.SelectedValue = Convert.ToString(0);
            this.ddlColorOjos.SelectedValue = Convert.ToString(0);
            this.ddlColorPiel.SelectedValue = Convert.ToString(0);
            this.ddlEstatura.SelectedValue = Convert.ToString(0);
            this.ddlFormaBoca.SelectedValue = Convert.ToString(0);
            this.ddlFormaCara.SelectedValue = Convert.ToString(0);
            this.ddlFormaLabioInferior.SelectedValue = Convert.ToString(0);
            this.ddlFormaLabioSuperior.SelectedValue = Convert.ToString(0);
            this.ddlFormaMenton.SelectedValue = Convert.ToString(0);
            this.ddlFormaNariz.SelectedValue = Convert.ToString(0);
            this.ddlFormaOreja.SelectedValue = Convert.ToString(0);
            this.ddlRobustez.SelectedValue = Convert.ToString(0);
            this.ddlTipoCabello.SelectedValue = Convert.ToString(0);
            this.ddlTipoCalvicie.SelectedValue = Convert.ToString(0);
            this.ddlTipoCeja.SelectedValue = Convert.ToString(0);
            this.ddlRostro.SelectedValue = Convert.ToString(0);
           /* this.ddlSena.SelectedValue = Convert.ToString(0);
            this.ddlTatuajeLugar.SelectedValue = Convert.ToString(0);
            this.ddlTatuajeTipo.SelectedValue = Convert.ToString(0);*/
            this.gvSenasPartD.DataSource = "";
            this.gvSenasPartD.DataBind();
            this.gvTatuajesD.DataSource = "";
            this.gvTatuajesD.DataBind();
            this.txtOtraCaracteristica.Text = "";
            this.txtRostroCon.Text = "";
           
        }

        private void LimpiarControlesPanelSic()
        {
            this.ddlEdadSic.SelectedValue = "0";
            this.ddlSexoSic.SelectedValue = "0";
            this.txtTatuajeSic.Text = "";
            this.txtApellidoBusquedaSic.Text = "";
            this.txtNombreBusquedaSic.Text = "";
            this.txtDniBusquedaSic.Text = "";
            this.ddlDimensionCejaSic.SelectedValue = Convert.ToString(0);
            this.ddlColorCabelloSic.SelectedValue = Convert.ToString(0);
            this.ddlColorOjosSic.SelectedValue = Convert.ToString(0);
            this.ddlColorPielSic.SelectedValue = Convert.ToString(0);
            this.ddlEstaturaSic.SelectedValue = Convert.ToString(0);
            this.ddlFormaBocaSic.SelectedValue = Convert.ToString(0);
            this.ddlFormaCaraSic.SelectedValue = Convert.ToString(0);
            this.ddlLabioInfSic.SelectedValue = Convert.ToString(0);
            this.ddlLabioSupSic.SelectedValue = Convert.ToString(0);
            this.ddlFormaMentonSic.SelectedValue = Convert.ToString(0);
            this.ddlFormaNarizSic.SelectedValue = Convert.ToString(0);
            this.ddlFormaOrejaSic.SelectedValue = Convert.ToString(0);
            this.ddlRobustezSic.SelectedValue = Convert.ToString(0);
            this.ddlTipoCabelloSic.SelectedValue = Convert.ToString(0);
            this.ddlCalvicieSic.SelectedValue = Convert.ToString(0);
            this.ddlTipoCejaSic.SelectedValue = Convert.ToString(0);

        }
        #endregion

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Delitos miDelito = (Delitos)Session["miDelito"];
            Session["miAutor"] = null;
            LimpiarControlesPanelAutor();
            TraerAutorDelSimpConWebService(miDelito.idCausa);
            this.rfvApellidoAutor.Enabled = true;
            hfGestionAutor_ModalPopupExtender.Show();
            this.txtApellidoAutor.Focus();
        }

        protected void ddlRostro_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esRostroCubierto = (this.ddlRostro.SelectedItem.Text.Trim().ToUpper() == "CUBIERTO");
            this.lblRostroCon.Visible = esRostroCubierto;
            this.txtRostroCon.Visible = esRostroCubierto;
            if (!esRostroCubierto)
                this.txtRostroCon.Text = "";
        }

        protected void btnBuscarSIC_Click(object sender, EventArgs e)
        {
            ConsultandoSIC = true;
            
            Delitos miDelito = (Delitos)Session["miDelito"];
            try
            {
                this.ddlFisGral.SelectedValue = Convert.ToInt32(miDelito.idCausa.Substring(0, 2)).ToString();
            }
            catch
            {
                this.ddlFisGral.SelectedValue = "0";
            }
            if (Session["ClaveSIC"] == null)
            {
                //this.txtClaveSic.Text = "";
                
                SIAC.Web.MasterPage myMaster = (SIAC.Web.MasterPage)this.Master;
                myMaster.btnLoginSic_Click(null, null);
                //this.hfGestionAccesoSic_ModalPopupExtender.Show();
                //this.txtUsuarioSic.Focus();
            }
            //this.btnBuscarSIC_Click(sender, e);

        }



    

        private void ActualizarLinkFotos()
        {
        
        }


        private bool ValidarTatuajes()
        {
            int idTatuaje = 0;
            int idUbicacionTatuaje = 0;
            if (this.gvTatuajesD.Rows.Count == 0)
            {
                idTatuaje = Convert.ToInt32(((DropDownList)this.gvTatuajesD.Controls[0].Controls[0].Controls[0].FindControl("ddlTatuajes")).SelectedValue);
                idUbicacionTatuaje = Convert.ToInt32(((DropDownList)this.gvTatuajesD.Controls[0].Controls[0].Controls[0].FindControl("ddlUbicacionTatuaje")).SelectedValue);
            }
            else
            {
                idTatuaje = Convert.ToInt32(((DropDownList)this.gvTatuajesD.FooterRow.FindControl("ddlTatuajeInsert")).SelectedValue);
                idUbicacionTatuaje = Convert.ToInt32(((DropDownList)this.gvTatuajesD.FooterRow.FindControl("ddlUbicacionTatuajeInsert")).SelectedValue);

            }
            if (idTatuaje != 0 || idUbicacionTatuaje != 0)
            {

                return false;
            }
            else
            {

                return true;
            }
        }

        private bool ValidarSenas()
        {
            int idSena = 0;
            int idUbicacionSena = 0;
            if (this.gvSenasPartD.Rows.Count == 0)
            {
                idSena = Convert.ToInt32(((DropDownList)this.gvSenasPartD.Controls[0].Controls[0].Controls[0].FindControl("ddlSenasParticulares")).SelectedValue);
                idUbicacionSena = Convert.ToInt32(((DropDownList)this.gvSenasPartD.Controls[0].Controls[0].Controls[0].FindControl("ddlUbicacionSenasPart")).SelectedValue);
            }
            else
            {
                idSena = Convert.ToInt32(((DropDownList)this.gvSenasPartD.FooterRow.FindControl("ddlSeniaPartInsert")).SelectedValue);
                idUbicacionSena = Convert.ToInt32(((DropDownList)this.gvSenasPartD.FooterRow.FindControl("ddlUbicacionSenaPartInsert")).SelectedValue);

            }
            if (idSena != 0 || idUbicacionSena != 0)
            {

                return false;
            }
            else
            {

                return true;

            }
        }

        protected void btnBuscarDelitosSIC_Click(object sender, EventArgs e)
        {
            string clave = Session["ClaveSIC"] == null ? "" : Session["ClaveSIC"].ToString();
            string usuario = Session["UserSIC"] == null ? "" : Session["UserSIC"].ToString();
            if (clave == "" || usuario == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Consulta SIC", "alert('Debe loggearse al SIC.');", true);
                //((MPBA.SIAC.Web.MasterPage)this.Master).btnLoginSic_Click(null, null);
                return;
            }
            string fltSexo = "";
            switch (this.ddlSexoSic.SelectedValue)
            {
                case "1":
                    fltSexo = "M";
                    break;
                case "2":
                    fltSexo = "F";
                    break;
            }

            string fltDomicilio = "";
            string fltLocalidad = "";
            string fltNombreSic = "";
            string fltApellidoSic = "";
            string fltDocNroSic = "";
            string valor = "";
            string fltEstatura="",
                fltRobustez = "",
                fltColorOjos = "",
                fltColorPiel = "",
                fltColorCabello = "",
                fltTipoCabello = "",
                fltCalvicie = "",
                fltFormaCara = "",
                fltDimensionCeja = "",
                fltFormaCeja = "",
                fltFormaMenton = "",
                fltFormaOreja = "",
                fltFormaNariz = "",
                fltFormaBoca = "",
                fltLabioInf = "",
                fltLabioSup = "";
            if (this.chkBuscaPorDatosSomaticos.Checked)
            {
                valor = this.ddlEstaturaSic.SelectedValue;
                fltEstatura = valor == "0" ? "" : SICClaseEstaturaManager.GetItem(Convert.ToInt32(valor)).Letra.Trim();
                valor = this.ddlRobustezSic.SelectedValue;
                fltRobustez = valor == "0" ? "" : SICClaseRobustezManager.GetItem(Convert.ToInt32(valor)).Letra.Trim();
                valor = this.ddlColorOjosSic.SelectedValue;
                fltColorOjos = valor == "0" ? "" : SICClaseColorOjosManager.GetItem(Convert.ToInt32(valor)).Letra.Trim();
                valor = this.ddlColorPielSic.SelectedValue;
                fltColorPiel = valor == "0" ? "" : SICClaseColorPielManager.GetItem(Convert.ToInt32(valor)).Letra.Trim();
                valor = this.ddlColorCabelloSic.SelectedValue;
                fltColorCabello = valor == "0" ? "" : SICClaseColorCabelloManager.GetItem(Convert.ToInt32(valor)).Letra.Trim();
                valor = this.ddlTipoCabelloSic.SelectedValue;
                fltTipoCabello = valor == "0" ? "" : SICClaseTipoCabelloManager.GetItem(Convert.ToInt32(valor)).Letra.Trim();
                valor = this.ddlCalvicieSic.SelectedValue;
                fltCalvicie = valor == "0" ? "" : SICClaseTipoCalvicieManager.GetItem(Convert.ToInt32(valor)).Letra.Trim();
                valor = this.ddlFormaCaraSic.SelectedValue;
                fltFormaCara = valor == "0" ? "" : SICClaseFormaCaraManager.GetItem(Convert.ToInt32(valor)).Letra.Trim();
                valor = this.ddlDimensionCejaSic.SelectedValue;
                fltDimensionCeja = valor == "0" ? "" : SICClaseCejasDimensionManager.GetItem(Convert.ToInt32(valor)).Letra.Trim();
                valor = this.ddlTipoCejaSic.SelectedValue;
                fltFormaCeja = valor == "0" ? "" : SICClaseCejasTipoManager.GetItem(Convert.ToInt32(valor)).Letra.Trim();
                valor = this.ddlFormaMentonSic.SelectedValue;
                fltFormaMenton = valor == "0" ? "" : SICClaseFormaMentonManager.GetItem(Convert.ToInt32(valor)).Letra.Trim();
                valor = this.ddlFormaOrejaSic.SelectedValue;
                fltFormaOreja = valor == "0" ? "" : SICClaseFormaOrejaManager.GetItem(Convert.ToInt32(valor)).Letra.Trim();
                valor = this.ddlFormaNarizSic.SelectedValue;
                fltFormaNariz = valor == "0" ? "" : SICClaseFormaNarizManager.GetItem(Convert.ToInt32(valor)).Letra.Trim();
                valor = this.ddlFormaBocaSic.SelectedValue;
                fltFormaBoca = valor == "0" ? "" : SICClaseFormaBocaManager.GetItem(Convert.ToInt32(valor)).Letra.Trim();
                valor = this.ddlLabioInfSic.SelectedValue;
                fltLabioInf = valor == "0" ? "" : SICClaseFormaLabioInferiorManager.GetItem(Convert.ToInt32(valor)).Letra.Trim();
                valor = this.ddlLabioSupSic.SelectedValue;
                fltLabioSup = valor == "0" ? "" : SICClaseFormaLabioSuperiorManager.GetItem(Convert.ToInt32(valor)).Letra.Trim();
            }
          

            FuncionesGenerales.TipoAutores tipoAutor = esNN ? FuncionesGenerales.TipoAutores.Desconocidos : FuncionesGenerales.TipoAutores.Conocidos;
            if (!esNN)
            {
                fltNombreSic = this.txtNombreBusquedaSic.Text.Trim();
                fltApellidoSic = this.txtApellidoBusquedaSic.Text.Trim();
                fltDocNroSic = this.txtDniBusquedaSic.Text.Trim();
            }
            fltLocalidad = this.txtLocalidadSic.Text.Trim();
            string fltTatuaje = "";
            fltTatuaje = this.txtTatuajeSic.Text.Trim();
            string fltEdadAprox = this.ddlEdadSic.SelectedValue.ToString();
            string fltIPP = "";
            int cantMaxMostrar = 50;
            string fltFisGralSic = DepartamentoManager.GetItem(Convert.ToInt32(this.ddlFisGral.SelectedValue)).IdCorte.ToString("00");
            string codUsuarioSic=Session["CodUsuarioSic"]==null?"":Session["CodUsuarioSic"].ToString();
            if (codUsuarioSic == "")
                throw new Exception("error en codUsuario del webservice");



            MyFiltroObject filtroSic = new MyFiltroObject();
            filtroSic.codUsuario = codUsuarioSic;
            filtroSic.apellido = fltApellidoSic;
            filtroSic.nombre = fltNombreSic;
            filtroSic.docNro = fltDocNroSic;
            filtroSic.domicilio = fltDomicilio;
            filtroSic.edadAprox = fltEdadAprox;
            filtroSic.fisGral = fltFisGralSic == "00" ? "" : fltFisGralSic;
            filtroSic.IPP = fltIPP;
            filtroSic.localidad = fltLocalidad;
            filtroSic.tatuaje = fltTatuaje;
            filtroSic.sexo = fltSexo;
            filtroSic.cantResultados = cantMaxMostrar.ToString();
            filtroSic.estatura=fltEstatura;
            filtroSic.robustez=fltRobustez;
            filtroSic.colorOjos=fltColorOjos;
            filtroSic.colorPiel=fltColorPiel;
            filtroSic.colorCabello=fltColorCabello;
            filtroSic.tipoCabello=fltTipoCabello;
            filtroSic.calvicie=fltCalvicie;
            filtroSic.formaCara=fltFormaCara;
            filtroSic.dimensionCeja=fltDimensionCeja;
            filtroSic.formaCeja=fltFormaCeja;
            filtroSic.formaMenton=fltFormaMenton;
            filtroSic.formaOreja=fltFormaOreja;
            filtroSic.formaNariz=fltFormaNariz;
            filtroSic.formaBoca=fltFormaBoca;
            filtroSic.labioInferior=fltLabioInf;
            filtroSic.labioSuperior=fltLabioSup;
            
            
            Services s = new Services();
            MyResultadoObject[] resultadosSic = new MyResultadoObject[Convert.ToInt32(filtroSic.cantResultados)];
            resultadosSic = s.ProcessMyFiltroObject(filtroSic);
            List<MyResultadoObject> listaDelitosSic = resultadosSic.ToList();
            this.lblLimiteResultadosSic.Text = "Solo se muestran los primeros " + cantMaxMostrar.ToString() + " resultados.";
            this.lblLimiteResultadosSic.Visible = (listaDelitosSic.Count >= cantMaxMostrar);
            this.gvDelitosSIC.DataSource = "";
            this.gvDelitosSIC.DataBind();
            if (listaDelitosSic.Count > 0)
            {
                this.pnlResultadosDatosSic.Style.Remove("display");
                this.hfResultadosDatosSic_ModalPopupExtender.Show();
            }
    
            this.lblLimiteResultadosSic.Text = "Solo se muestran los primeros " + cantMaxMostrar.ToString() + " resultados.";
            this.lblLimiteResultadosSic.Visible = (listaDelitosSic.Count >= cantMaxMostrar);

            this.gvDelitosSIC.DataSource = "";
            this.gvDelitosSIC.DataBind();

            if (listaDelitosSic.Count > 0)
            {
                this.gvDelitosSIC.DataSource = listaDelitosSic;
                this.gvDelitosSIC.DataBind();
                this.lblNoHayResultadosSic.Visible = false;
            }
            else
            {
                this.lblNoHayResultadosSic.Visible = true;
            }
        }


        protected void btnCerrarDelitosSIC_Click(object sender, EventArgs e)
        {
            this.pnlDelitosSIC.Style.Add("display", "none");
        }


        protected void gvAutores_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                //Button btnSic=(Button)e.Row.FindControl("btnBuscarSIC");
                //btnSic.Enabled = (Session["ClaveSIC"] != null);
                Label lblIdPersona = (Label)e.Row.FindControl("lblIdPersona");
                int idPersona;
                int.TryParse(DataBinder.Eval(lblIdPersona, "Text").ToString(), out idPersona);
                
                string nombre = "";
                string apellido = "";
                string docnro = "";
                string apodo = "";

                
                try
                {
                    Persona persona=MPBA.SIAC.Bll.PersonaManager.GetItem(idPersona);
                    
                    nombre=(persona.Nombre==null)?"":persona.Nombre;
                    apellido =(persona.Apellido==null)?"":persona.Apellido;
                    docnro = (persona.DocumentoNumero==null)?"":persona.DocumentoNumero.ToString();
                    apodo = (persona.Apodo == null) ? "" : persona.Apodo;
    
                }
                catch { }
                ((Label)e.Row.FindControl("lblNombrePersona")).Text = nombre;
                ((Label)e.Row.FindControl("lblApellidoPersona")).Text = apellido;
                ((Label)e.Row.FindControl("lblDocNroPersona")).Text = docnro;
                ((Label)e.Row.FindControl("lblApodoPersona")).Text = apodo;
            }
        }

        public void ActivarBotonesSic(bool activar)
        {
            foreach (GridViewRow gvr in this.gvAutores.Rows)
            {
                Button b = (Button)gvr.FindControl("btnBuscarSIC");

                b.Enabled = activar;
            }

            
        }

    
   

        protected void gvDelitosSIC_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[2] == null || e.Row.Cells[2].Text=="null")
                {
                    e.Row.Cells[2].Text = "";
                }
            }
        }

        private void GenerarUrlFotosSic()
        {
            string fltSexo = "";
            switch (this.ddlSexoSic.SelectedValue)
            {
                case "1":
                    fltSexo = "M";
                    break;
                case "2":
                    fltSexo = "F";
                    break;
            }
            string user = Session["CodUsuarioSic"].ToString();
            string fltDomicilio = "";
            string fltLocalidad = "";
            fltLocalidad = this.txtLocalidadSic.Text.Trim();
            string fltTatuaje = "";
            fltTatuaje = this.txtTatuajeSic.Text.Trim();
            string fltEdadAprox = this.ddlEdadSic.SelectedValue.ToString();
            string fltIPP = "";
            string fltFisGralSic = DepartamentoManager.GetItem(Convert.ToInt32(this.ddlFisGral.SelectedValue)).IdCorte.ToString("00");
            if (fltFisGralSic == "00")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Consulta SIC", "alert('Debe indicar una Fiscalia en particular.');", true);
                return;
            }
            string valor = "";
            string fltEstatura = "",
                fltRobustez = "",
                fltColorOjos = "",
                fltColorPiel = "",
                fltColorCabello = "",
                fltTipoCabello = "",
                fltCalvicie = "",
                fltFormaCara = "",
                fltDimensionCeja = "",
                fltFormaCeja = "",
                fltFormaMenton = "",
                fltFormaOreja = "",
                fltFormaNariz = "",
                fltFormaBoca = "",
                fltLabioInf = "",
                fltLabioSup = "";

            if (this.chkBuscaPorDatosSomaticos.Checked)
            {
                valor = this.ddlEstaturaSic.SelectedValue;
                fltEstatura = valor == "0" ? "" : SICClaseEstaturaManager.GetItem(Convert.ToInt32(valor)).Letra.Trim();
                valor = this.ddlRobustezSic.SelectedValue;
                fltRobustez = valor == "0" ? "" : SICClaseRobustezManager.GetItem(Convert.ToInt32(valor)).Letra.Trim();
                valor = this.ddlColorOjosSic.SelectedValue;
                fltColorOjos = valor == "0" ? "" : SICClaseColorOjosManager.GetItem(Convert.ToInt32(valor)).Letra.Trim();
                valor = this.ddlColorPielSic.SelectedValue;
                fltColorPiel = valor == "0" ? "" : SICClaseColorPielManager.GetItem(Convert.ToInt32(valor)).Letra.Trim();
                valor = this.ddlColorCabelloSic.SelectedValue;
                fltColorCabello = valor == "0" ? "" : SICClaseColorCabelloManager.GetItem(Convert.ToInt32(valor)).Letra.Trim();
                valor = this.ddlTipoCabelloSic.SelectedValue;
                fltTipoCabello = valor == "0" ? "" : SICClaseTipoCabelloManager.GetItem(Convert.ToInt32(valor)).Letra.Trim();
                valor = this.ddlCalvicieSic.SelectedValue;
                fltCalvicie = valor == "0" ? "" : SICClaseTipoCalvicieManager.GetItem(Convert.ToInt32(valor)).Letra.Trim();
                valor = this.ddlFormaCaraSic.SelectedValue;
                fltFormaCara = valor == "0" ? "" : SICClaseFormaCaraManager.GetItem(Convert.ToInt32(valor)).Letra.Trim();
                valor = this.ddlDimensionCejaSic.SelectedValue;
                fltDimensionCeja = valor == "0" ? "" : SICClaseCejasDimensionManager.GetItem(Convert.ToInt32(valor)).Letra.Trim();
                valor = this.ddlTipoCejaSic.SelectedValue;
                fltFormaCeja = valor == "0" ? "" : SICClaseCejasTipoManager.GetItem(Convert.ToInt32(valor)).Letra.Trim();
                valor = this.ddlFormaMentonSic.SelectedValue;
                fltFormaMenton = valor == "0" ? "" : SICClaseFormaMentonManager.GetItem(Convert.ToInt32(valor)).Letra.Trim();
                valor = this.ddlFormaOrejaSic.SelectedValue;
                fltFormaOreja = valor == "0" ? "" : SICClaseFormaOrejaManager.GetItem(Convert.ToInt32(valor)).Letra.Trim();
                valor = this.ddlFormaNarizSic.SelectedValue;
                fltFormaNariz = valor == "0" ? "" : SICClaseFormaNarizManager.GetItem(Convert.ToInt32(valor)).Letra.Trim();
                valor = this.ddlFormaBocaSic.SelectedValue;
                fltFormaBoca = valor == "0" ? "" : SICClaseFormaBocaManager.GetItem(Convert.ToInt32(valor)).Letra.Trim();
                valor = this.ddlLabioInfSic.SelectedValue;
                fltLabioInf = valor == "0" ? "" : SICClaseFormaLabioInferiorManager.GetItem(Convert.ToInt32(valor)).Letra.Trim();
                valor = this.ddlLabioSupSic.SelectedValue;
                fltLabioSup = valor == "0" ? "" : SICClaseFormaLabioSuperiorManager.GetItem(Convert.ToInt32(valor)).Letra.Trim();
            }
            string t = DateTime.Now.Ticks.ToString(); //random para evitar cache
            string urlFotosSic = "http://www.sic.mpba.gov.ar/cons1/frmBuscaXFoto.php?sid=siac&u=" + user + "&NroPagina=1&NroFila=0&NroFilaPrev=0&Sexo=" + fltSexo + "&IPP=" + fltIPP + "&EdadAprox=" + fltEdadAprox + "&Localidad=" + fltLocalidad + "&Tatuaje=" + fltTatuaje + "&Domicilio=" + fltDomicilio + "&FisGral=" + fltFisGralSic + "&Estatura=" + fltEstatura + "&Robustez=" + fltRobustez + "&ColorOjos=" + fltColorOjos + "&ColorPiel=" + fltColorPiel + "&ColorCabello=" + fltColorCabello + "&TipoCabello=" + fltTipoCabello + "&Calvicie=" + fltCalvicie + "&FormaCara=" + fltFormaCara + "&DimensionCeja=" + fltDimensionCeja + "&TipoCeja=" + fltFormaCeja + "&FormaMenton=" + fltFormaMenton + "&FormaOreja=" + fltFormaOreja + "&FormaNariz=" + fltFormaNariz + "&FormaBoca=" + fltFormaBoca + "&LabioInferior=" + fltLabioInf + "&LabioSuperior=" + fltLabioSup + "&t="+t;
            ScriptManager.RegisterStartupScript(this.upBusquedaSic,typeof(string), "fotos", "window.open('"+ urlFotosSic + "');", true);
        }

        private void HabilitarCamposSomaticos(bool habilitar)
        {
            this.ddlEstaturaSic.Enabled = habilitar;
            this.ddlRobustezSic.Enabled = habilitar;
            this.ddlColorOjosSic.Enabled = habilitar;
            this.ddlColorPielSic.Enabled = habilitar;
            this.ddlColorCabelloSic.Enabled = habilitar;
            this.ddlTipoCabelloSic.Enabled = habilitar;
            this.ddlCalvicieSic.Enabled = habilitar;
            this.ddlFormaCaraSic.Enabled = habilitar;
            this.ddlDimensionCejaSic.Enabled = habilitar;
            this.ddlTipoCejaSic.Enabled = habilitar;
            this.ddlFormaMentonSic.Enabled = habilitar;
            this.ddlFormaOrejaSic.Enabled = habilitar;
            this.ddlFormaNarizSic.Enabled = habilitar;
            this.ddlFormaBocaSic.Enabled = habilitar;
            this.ddlLabioInfSic.Enabled = habilitar;
            this.ddlLabioSupSic.Enabled = habilitar;
        }

     

        protected void btnMostrarFotosSic_Click(object sender, EventArgs e)
        {
            GenerarUrlFotosSic();
            
        }

        protected void btnCerrarResultadosDatosSic_Click(object sender, EventArgs e)
        {
            this.hfResultadosDatosSic_ModalPopupExtender.Hide();
            this.pnlResultadosDatosSic.Style.Add("display", "none");
        }

        protected void btnCancelarPersonasEncontradas_Click(object sender, EventArgs e)
        {
            this.hfIdPersonaEncontrada.Value = null;
            this.hfGestionPersonasEncontradas_ModalPopupExtender.Hide();
            this.pnlPersonasEncontradas.Style.Add("display", "none");
            this.pnlCargaAutores.Enabled = true;
            this.hfGestionAutor_ModalPopupExtender.Show();
        }

     
        protected void btnElegirPersonaEncontrada_Click(object sender, EventArgs e)
        {
            this.hfIdPersonaEncontrada.Value = null;
            this.hfGestionPersonasEncontradas_ModalPopupExtender.Hide();
            this.pnlPersonasEncontradas.Style.Add("display", "none");
            //this.hfGestionAutor_ModalPopupExtender.Show();
            GuardarAutor();
            ActivarBotonesSic(Session["ClaveSIC"] != null);
        }

       
        /// <summary>
        /// Controla si la persona ya existe en base
        /// </summary>
        /// <returns>si existe o no</returns>
        private bool ControlarPersonaExistente()
        {
            Persona personaActual = new Persona();
            Autores miAutor = (Autores)Session["miAutor"];
            if (miAutor != null && miAutor.idPersona > 0)
            {
                personaActual = PersonaManager.GetItem(miAutor.idPersona);
                //if (personaActual.Apellido.Trim() == this.txtApellidoAutor.Text.Trim() &&
                //    personaActual.DocumentoNumero == Convert.ToInt32(this.txtDniAutor.Text)) 
                if (personaActual.Apellido.Trim() == this.txtApellidoAutor.Text.Trim() &&
                    personaActual.DocumentoNumero == Convert.ToInt32(this.txtDniAutor.Text.Trim())) 

                return false;
            }

            PersonaList pl = new PersonaList();
            //if (this.txtDniAutor.Text.Trim() != "")
            //{
            int? docnro=null;
            if (this.txtDniAutor.Text!="" && Convert.ToInt32(this.txtDniAutor.Text)>0)
                docnro = Convert.ToInt32(this.txtDniAutor.Text.Trim());


                string apellido = this.txtApellidoAutor.Text.Trim();
                pl = PersonaManager.GetListByDocNroApellido(docnro,apellido);
                if (pl.Count > 0)
                {
                    this.divHeaderPersonas.InnerText = "PERSONAS ENCONTRADAS";
                    this.gvPersonasEncontradas.DataSource = pl;
                    this.gvPersonasEncontradas.DataBind();
                    this.btnElegirPersonaEncontrada.Visible = true;
                    this.hfGestionPersonasEncontradas_ModalPopupExtender.Show();
                    this.hfGestionAutor_ModalPopupExtender.Hide();
                    return true;
                }
            //}

            //if (this.txtApellidoAutor.Text.Trim() != "")
            //{
                
            //    pl = PersonaManager.GetListByApellido(this.txtApellidoAutor.Text.Trim());
            //    if (pl.Count > 0)
            //    {
            //        this.gvPersonasEncontradas.DataSource = pl;
            //        this.gvPersonasEncontradas.DataBind();
            //        this.hfGestionPersonasEncontradas_ModalPopupExtender.Show();
            //        this.hfGestionAutor_ModalPopupExtender.Hide();
            //        return true;
            //    }

            //}
            return false;
        }

        protected void gvPersonasEncontradas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.hfIdPersonaEncontrada.Value = ((Label)this.gvPersonasEncontradas.SelectedRow.FindControl("lblID")).Text;
            this.pnlCargaAutores.Enabled = true;
            this.hfGestionPersonasEncontradas_ModalPopupExtender.Hide();
            this.pnlPersonasEncontradas.Style.Add("display", "none");
            if (this.btnElegirPersonaEncontrada.Visible)//estoy con listado de la tabla Personas y no con las del SIMP
            {
                GuardarAutor();
            }
            else
            {
                PersonaList plSimp = (PersonaList)Session["plSimp"];
                if (plSimp != null)
                {
                    LlenarPersonaConSimp(plSimp[this.gvPersonasEncontradas.SelectedIndex]);
                }
                

            }
            ActivarBotonesSic(Session["ClaveSIC"] != null);
        }

        /// <summary>
        /// Llena los campos de identificacion del autor con los datos traidos del SIMP
        /// </summary>
        /// <param name="p">Persona cuyos datos se van a usar para llenar campos de autor</param>
        private void LlenarPersonaConSimp(Persona p)
        {
            if (p != null)
            {
                this.txtApellidoAutor.Text = p.Apellido;
                this.txtApodoAutor.Text = p.Apodo;
                this.txtNombreAutor.Text = p.Nombre;
                this.txtDniAutor.Text = p.DocumentoNumero.ToString();
            }

            
        }


        protected void btnOkServerSicOcupado_Click(object sender, EventArgs e)
        {
            this.pnlServerSicOcupado.Style.Add("display", "none");
            this.hfServerSicOcupado_ModalPopupExtender.Hide();
        }

        protected void btnVerPersonasSimp_Click(object sender, EventArgs e)
        {
            this.rfvApellidoAutor.Enabled = false;
            this.pnlPersonasEncontradas.Style.Remove("display");
            this.pnlCargaAutores.Enabled = false;
            this.hfGestionPersonasEncontradas_ModalPopupExtender.Show();
        }

        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            bool esConsulta = Request.QueryString["c"].ToString() == "1" ? true : false;
            if (esConsulta)
                Response.Redirect("CargaModusOperandi.aspx?c=1");
            else
                Response.Redirect("CargaModusOperandi.aspx?c=0");
        }

        protected void chkBuscaPorDatosSomaticos_CheckedChanged(object sender, EventArgs e)
        {
            this.divDatosSomaticos.Visible = this.chkBuscaPorDatosSomaticos.Checked;
            HabilitarCamposSomaticos(this.chkBuscaPorDatosSomaticos.Checked);
            if (this.chkBuscaPorDatosSomaticos.Checked)
            {
                LlenarControlesPanelSic();
                
              }
              
        }


   

   
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPBA.PersonasBuscadas.Bll;
using MPBA.PersonasBuscadas.BusinessEntities;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Mail;
using System.Xml;
using System.Data;
using MPBA.SIAC.Bll;
using MPBA.SIAC.BusinessEntities;



namespace MPBA.PersonasBuscadas.Web
{
    //*********************
    //PERMISOS:
    //PARA MODIFICAR solo pueden aquellos que pertenezcan al mismo depto jud
    //que la ipp que estan consultando
    //************************
    public partial class BusquedaDesaparecida : System.Web.UI.Page
    {
        #region "VARIABLES":
        int idPersonaDesaparecida = 0;//si es mayor a 0 estoy editando una pers. desap existente
        FuncionesGrales.EstadoPrograma state = FuncionesGrales.EstadoPrograma.Creando; //C si se está creando una instancia, M si se está modificando y O si se está consultando
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
        SIAC.Web.MasterPage myMaster;
        #endregion

        #region "EVENTOS":
        protected void Page_Load(object sender, EventArgs e)
        {
            
            state = (FuncionesGrales.EstadoPrograma)Convert.ToInt32(Request.QueryString["status"]);
            //Solo se puede modificar la ipp perteneciente al mismo depto jud de quien consulta

            if (state == FuncionesGrales.EstadoPrograma.Modificando)
            {
                if (DeptoIppIgualQueOperador() == false && Session["idGrupo"].ToString().Trim() != "1")
                    state = FuncionesGrales.EstadoPrograma.Consultando;

            }
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
            idPersonaDesaparecida = Session["idPersonaDesaparecida"] == null ? 0 : Convert.ToInt32(Session["idPersonaDesaparecida"]);
            myMaster = (SIAC.Web.MasterPage)this.Master;
            //myMaster.btnConfigurarMailPB.Visible = true;
            
            if (!this.IsPostBack)
            {

                //resalta en el menu, el modulo en el que estoy actualmente
                Session["moduloActual"] = "BP";
                //**********************
                //CAMBIAR
                //**********************
                //Session["miUsuario"] = "nn";
                //Session["miUfi"] = "xx";
                //*********************
                LimpiarControlesD();
                LimpiarControlesBI();
                switch (state)
                {
                    case FuncionesGrales.EstadoPrograma.Creando:
                        this.cartelConsultandoD.InnerText = "Alta Persona Desaparecida";
                        break;
                    case FuncionesGrales.EstadoPrograma.Modificando:
                        this.cartelConsultandoD.InnerText = "Modificación Persona Desaparecida";
                        break;
                }
                this.pnlComisarias.Style.Add("display", "none");
                this.pnlLugar.Style.Add("display", "none");
                this.pnlGuardarFotos.Style.Add("display", "none");
                this.pnlBusquedaIndividual.Style.Add("display", "none");
                this.pnlMailAsociado.Style.Add("display", "none");
                this.pnlFichaPersHalladaBI.Style.Add("display", "none");
                this.pnlResultadosBI.Style.Add("display", "none");
                this.pnlCartelAlert.Style.Add("display", "none");
                #region "Seteo controles UpdateProgess"
                Panel pnlWaitingOverlayD = (Panel)this.upWaitingD.FindControl("pnlWaitingOverlayD");
                Panel pnlWaitingVerBI = (Panel)this.upWaitingVerBI.FindControl("pnlWaitingVerBI");
                Panel pnlWaitingOverlayVerBI = (Panel)this.upWaitingVerBI.FindControl("pnlWaitingOverlayVerBI");
                Panel pnlWaitingD = (Panel)this.upWaitingD.FindControl("pnlWaitingD");
                Panel pnlWaitingFichaBIH = (Panel)this.upWaitingFichaBIH.FindControl("pnlWaitingFichaBIH");
                Panel pnlWaitingOverlayBI = (Panel)this.upWaitingBI.FindControl("pnlWaitingOverlayBI");
                Panel pnlWaitingOverlayFichaBIH = (Panel)this.upWaitingFichaBIH.FindControl("pnlWaitingOverlayFichaBIH");
                Panel pnlWaitingBI = (Panel)this.upWaitingBI.FindControl("pnlWaitingBI");
                Panel pnlWaitingOverlayResultadosBI = (Panel)this.upWaitingResultadosBI.FindControl("pnlWaitingOverlayResultadosBI");
                Panel pnlWaitingResultadosBI = (Panel)this.upWaitingResultadosBI.FindControl("pnlWaitingResultadosBI");
                Panel pnlWaitingComisaria = (Panel)this.upWaitingComisaria.FindControl("pnlWaitingComisaria");
                Panel pnlWaitingLocalidad = (Panel)this.upWaitingLocalidad.FindControl("pnlWaitingLocalidad");
                pnlWaitingComisaria.CssClass = "loader";
                pnlWaitingLocalidad.CssClass = "loader";
                pnlWaitingOverlayD.CssClass = "overlay";
                pnlWaitingD.CssClass = "loader";
                pnlWaitingOverlayBI.CssClass = "overlay";
                pnlWaitingBI.CssClass = "loader";
                pnlWaitingFichaBIH.CssClass = "loader";
                pnlWaitingOverlayFichaBIH.CssClass = "overlay";
                pnlWaitingOverlayResultadosBI.CssClass = "overlay";
                pnlWaitingResultadosBI.CssClass = "loader";

                #endregion
                this.pnlPersonadesaparecida.Enabled = false;
                this.txtIppBuscadoD.Focus();
                SetearGvPersonas();
            }
        }

        private void LimpiarControlesExtJur()
        {
            /////////ext jur///////////
            this.txtOrgReqExtJur.Text = "";
            this.txtTelefonoExtJur.Text = "";
            this.txtMailExtJur.Text = "";
            this.txtCaratulaExtJur.Text = "";
            this.txtJurisdiccionExtJur.Text = "";
        }

        private void SetearGvPersonas()
        {
            foreach (GridViewRow row in this.gvPersonasD.Rows)
            {
                row.BackColor = Color.Transparent;
                row.ForeColor = Color.Blue;
                int cantPersonasD = this.gvPersonasD.Rows.Count;
                if (cantPersonasD>0)
                {
                    Button btnElegirPersonaD=(Button)row.Cells[0].FindControl("btnElegirPersonaD");
                    Button btnBorrarPersonaD = (Button)row.Cells[0].FindControl("btnBorrarPersonaD");
                    btnElegirPersonaD.Visible = cantPersonasD>1;
                    btnBorrarPersonaD.Visible = cantPersonasD > 1;
                   
                }
            }
            if (this.gvPersonasD.SelectedIndex == -1 && this.gvPersonasD.Rows.Count > 0)
                this.gvPersonasD.SelectedIndex = 0;
            //int ind  = -1;
            foreach (GridViewRow gvr in this.gvPersonasD.Rows)
            {
                gvr.BorderColor = Color.White;
                gvr.BorderStyle = BorderStyle.Solid;
                gvr.BorderWidth = 2;
                Button btnElegirPersonaD = (Button)gvr.FindControl("btnElegirPersonaD");
                Button btnBorrarPersonaD = (Button)gvr.FindControl("btnBorrarPersonaD");
                Label lblBajaPersonaD = (Label)gvr.FindControl("lblBajaPersona");
                CheckBox cbaja = (CheckBox)gvr.Cells[7].FindControl("Baja");
                bool dadoDeBaja= cbaja.Checked;
                    btnElegirPersonaD.Visible = !dadoDeBaja;
                    btnBorrarPersonaD.Visible = false;
                    lblBajaPersonaD.Visible = dadoDeBaja;

           

                foreach (TableCell c in gvr.Cells)
                {
                    TableCell celda = c;
                    switch (((DataControlFieldCell)c).ContainingField.ToString().Trim().ToUpper())
                    {
                        case "FECHA DESAP.":
                            if (c.Text != null)
                            {
                                DateTime dtDesap;
                                if (DateTime.TryParse(c.Text, out dtDesap))
                                {
                                    //c.CssClass = "CeldaColor";
                                    c.Text = dtDesap.ToString("dd/MM/yyyy");
                                }
                                else
                                    c.Text = "";
                                //c.DataBind();
                            }
                            break;
                    }
                }


            }
            //if (this.gvPersonasD.SelectedRow != null && ind !=  -1)
            if (this.gvPersonasD.Rows.Count>0 && this.gvPersonasD.SelectedRow != null)
            {
                GridViewRow gvr = this.gvPersonasD.SelectedRow;
                gvr.BorderColor = Color.Brown;
                gvr.BorderStyle = BorderStyle.Solid;
                gvr.BorderWidth = 4;
                //gvr.BackColor = Color.FromName("#13507d");
                Button btnElegirPersonaD= (Button)gvr.FindControl("btnElegirPersonaD");
                CheckBox cbaja = (CheckBox)gvr.FindControl("Baja");
                if (cbaja.Checked)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Se dio de baja a la persona desaparecida seleccionada. No podra hacer modificaciones.');", true);
                    //LimpiarControlesD();
                    this.fuFotoUploaderD.Enabled = false;
                    this.pnlPersonadesaparecida.Enabled = false;
                    this.btnAgregarMailAsociado.Style.Add("display", "none");
                    this.btnGuardarD.Style.Add("display", "none");
                }
                else
                    this.btnAgregarMailAsociado.Style.Remove("display");
                if (btnElegirPersonaD != null)
                    btnElegirPersonaD.Visible = false;
                if (state==FuncionesGrales.EstadoPrograma.Consultando)
                    this.btnAgregarMailAsociado.Style.Add("display", "none");
                else
                    this.btnAgregarMailAsociado.Style.Remove("display");
                    
           
            }

            //if (ind == -1 && this.gvPersonasD.Rows.Count > 0)
            //{
            //    //btnSalir_Click(null, null);
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Se dio de baja a las personas desaparecidas ingresadas en la causa.');window.location ='BusquedaDesaparecida.aspx?status=2';", true);
            //}
           
        }



        protected void btnSubirFotoD_Click(object sender, EventArgs e)
        {
            this.lblMesgErrorFotoD.Visible = false;
            if (this.fuFotoUploaderD.HasFile)
            {
                FileInfo fiArchivo = new FileInfo(this.fuFotoUploaderD.PostedFile.FileName);
                if (fiArchivo.Extension.ToUpper() == ".JPG")
                {
                    if (this.fuFotoUploaderD.PostedFile.ContentLength < 1000000)
                    {
                        int len = this.fuFotoUploaderD.PostedFile.ContentLength;
                        Byte[] input = new Byte[len];
                        using (System.IO.Stream s = this.fuFotoUploaderD.PostedFile.InputStream)
                        {
                            s.Read(input, 0, len);
                            s.Close();
                            Session["imgPreview"] = input;
                            this.imgFotoPreview.ImageUrl = "";
                            this.imgFotoPreview.ImageUrl = "ImagenFoto.aspx?id=" + DateTime.Now.Second.ToString();
                            this.upImage.Update();
                            this.hfElegirTipoFotoD_ModalPopupExtender.Show();
                        }
                    }
                    else
                    {
                        this.lblMesgErrorFotoD.Text = "Error:La Imagen debe tener un tamaño inferior a 1 Mb.";
                        this.lblMesgErrorFotoD.Visible = true;
                    }
                }
                else
                {
                    this.imgFotoPreview.ImageUrl = "~/App_Images/SinFoto.GIF";
                    this.imgFotoPreview.Width = 80;
                    this.imgFotoPreview.Height = 100;
                    this.lblMesgErrorFotoD.Text = "Error:La Imagen debe ser en formato JPG.";
                    this.lblMesgErrorFotoD.Visible = true;
                    this.lblMesgErrorFotoD.Focus();
                }
            }
        }

        protected void btnCancelarResultadosBI_Click(object sender, EventArgs e)
        {
            switch (this.btnCancelarResultadosBI.CommandArgument)
            {

                case "H":
                    this.gvResultadosHalladasBI.DataSource = null;
                    this.gvResultadosHalladasBI.DataBind();

                    break;

            }
            this.lblResultadosBI.Text = "RESULTADOS DE LA BUSQUEDA";
            this.lblLeyendaBI.Visible = true;
            this.lblLeyendaVerdeBI.Visible = true;
            this.hfAbrirResultadosBI_ModalPopupExtender1.Hide();
        }

        private bool DeptoIppIgualQueOperador()
        {
            string miUfi = Session["miUfi"].ToString();
            int deptoMiUfi = PuntoGestionManager.GetItem(miUfi).idDepartamento;
            if (this.txtIppBuscadoD.Text.Trim().Length > 3)
            {
                if (this.txtIppBuscadoD.Text.Trim().Substring(0, 2) != deptoMiUfi.ToString("00"))
                    return false;
                else
                    return true;
            }
            else
                return false;
        }

        private void BuscarIpp(int idDelito,string ipp, bool esExtJur)
        {
            this.btnGuardarD.Style.Remove("display");
            
            
            bool esIppExistente = EsIppExistente(ipp, FuncionesGrales.TipoBusqueda.PersonaDesaparecida,esExtJur);

            if (esIppExistente)
            {

                //Solo se puede modificar la ipp perteneciente al mismo depto jud de quien consulta
                if (state == FuncionesGrales.EstadoPrograma.Modificando)
                {
                  if (DeptoIppIgualQueOperador()==false && Session["idGrupo"].ToString().Trim()!="1")
                      state = FuncionesGrales.EstadoPrograma.Consultando;

                }

                if (state != FuncionesGrales.EstadoPrograma.Modificando && 
                    state != FuncionesGrales.EstadoPrograma.Consultando)
                {
                    this.gvMailsAsociados.DataSource = "";
                    this.gvMailsAsociados.DataBind();
                    LimpiarControlesD();
                  
                    this.fuFotoUploaderD.Enabled = false;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('El número de causa ya se encuentra cargado.');", true);
                  
                    this.btnGuardarD.Style.Add("display", "none");
                    this.txtIppBuscadoD.Focus();
                    return;
                }

            

                //if (state == FuncionesGrales.EstadoPrograma.Consultando)
                //    this.pnlPersonadesaparecida.Enabled = false;
             
                
                    
                //PersonasDesaparecidas myPD = PersonasDesaparecidasManager.GetItemByidCausa(ipp, true);
              
                PersonasDesaparecidas myPD = PersonasDesaparecidasManager.GetItem(idDelito, true);
                
                LlenarControlesD(myPD);
                if (state == FuncionesGrales.EstadoPrograma.Creando || state == FuncionesGrales.EstadoPrograma.Modificando)
                {
                    this.btnGuardarD.Style.Remove("display");
                    this.btnAgregarPersonaD.Style.Remove("display");
                    this.pnlPersonadesaparecida.Enabled = true;
                }
                else
                {
                    this.btnGuardarD.Style.Add("display", "none");
                    this.btnAgregarPersonaD.Style.Add("display", "none");
                    this.pnlPersonadesaparecida.Enabled = false;
                }
                if (!esExtJur)
                    BuscarIppEnWebService(ipp, FuncionesGrales.TipoBusqueda.PersonaDesaparecida);
                if (myPD.busqueda != null)
                {
                    LlenarControlesBI(myPD.busqueda);
                    this.btnVerCriterioBusquedaD.CommandArgument = myPD.busqueda.Id.ToString();
                    this.btnVerResultadosD.CommandArgument = myPD.Id.ToString();
                    this.btnImprimirD.Style.Remove("display");
                    this.btnVerCriterioBusquedaD.Style.Remove("display");
                    this.btnVerResultadosD.Style.Remove("display");
                    Session["idPersonaDesaparecida"] = myPD.Id;
                    string esExJur = this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur ? "1" : "0";
                    this.btnImprimirD.OnClientClick = "window.open('ReporteFormD.aspx?Ipp=" + myPD.Ipp + "&id=" + myPD.Id.ToString() + "&esExJur=" + esExJur + "')";
                    if (state == FuncionesGrales.EstadoPrograma.Creando && this.gvPersonasD.Rows.Count > 0)
                    {
                        this.pnlPersonadesaparecida.Enabled = false;
                        this.btnGuardarD.Style.Add("display", "none");
                    }
                }
                else
                {
                    LimpiarControlesD();
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Inconsistencia en los datos guardados. Comuníquese con Sistemas');", true);
                    this.hfCartelAlert_ModalPopupExtender.Show();
                    this.btnGuardarD.Style.Add("display", "none");
                    this.txtIppBuscadoD.Focus();
                    return;
                }
            }
            else
            {
                if (state != FuncionesGrales.EstadoPrograma.Creando)
                {
                    LimpiarControlesD();
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('La persona no se encuentra cargada.');", true);
                    //this.lblMensajeCartelAlert.Text = "La persona no se encuentra cargada";
                    //this.hfCartelAlert_ModalPopupExtender.Show();
                    this.gvMailsAsociados.DataSource = "";
                    this.gvMailsAsociados.DataBind();
                    this.btnGuardarD.Style.Add("display", "none");
                    this.txtIppBuscadoD.Focus();
                    return;
                }
                this.pnlExtranaJurisdiccion.Enabled = true;
                BuscarIppEnWebService(ipp, FuncionesGrales.TipoBusqueda.PersonaDesaparecida);
                this.pnlPersonadesaparecida.Enabled = true;
                this.btnImprimirD.Style.Add("display", "none");
                this.btnVerCriterioBusquedaD.Style.Add("display", "none");
                this.btnVerResultadosD.Style.Add("display", "none");
                idPersonaDesaparecida = 0;
            }
            this.cartelConsultandoD.Style.Remove("display");
            this.fuFotoUploaderD.Enabled = true;
           
        }

        protected void btnBuscarIppD_Click(object sender, EventArgs e)
        {
            LimpiarControlesD();
            LimpiarControlesBI();
            LimpiarControlesExtJur();
            this.gvPersonasD.DataSource = "";
            this.gvPersonasD.DataBind();
            string ipp = "";
            List<PersonasDesaparecidas> myPersonas = null;
            if (this.tcTipoJurisdiccion.ActiveTab == this.tpPJ)
            {
                 ipp = this.txtIppBuscadoD.Text.Trim();
            if (ipp.Length == 0)
            {
                this.cvIppD.IsValid = false;
                return;
            }
            if (ipp.Length != 12)
            {
                string msg = "Cantidad incorrecta de dígitos. (Deberían ser 12).";
                ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('" + msg + "');", true);
                return;
            }
                 this.pnlExtranaJurisdiccion.Visible = false;
                 myPersonas = PersonasDesaparecidasManager.GetListByIPP(ipp).FindAll(delegate(PersonasDesaparecidas pd) { return (pd.esExtJurisdiccion == null || pd.esExtJurisdiccion == false); });
          

            }
            else if (this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur)
            {
                ipp = this.txtCausa.Text.Trim();
                if (ipp.Length == 0)
                {
                    this.cvCausa.IsValid = false;
                    return;
                }
                this.pnlExtranaJurisdiccion.Visible = true;
                myPersonas = PersonasDesaparecidasManager.GetListByIPP(ipp).FindAll(delegate(PersonasDesaparecidas pd) { return  (pd.esExtJurisdiccion != null && pd.esExtJurisdiccion == true); });
        
                
            }
            bool esExtJur = this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur;
            if (myPersonas.Count > 0)
            {
         

                this.gvPersonasD.DataSource = myPersonas;
                this.gvPersonasD.DataBind();
                this.gvPersonasD.Rows[0].BackColor = Color.FromName("#13507d");
                this.divPersonasD.Style.Remove("display");
                int primeraFilaSinBaja=PrimeraFilaSinBajaEnGvPersonas();
                int idDelito=0;
                if (primeraFilaSinBaja > -1)
                    this.gvPersonasD.SelectedIndex=primeraFilaSinBaja;
                else
                    this.gvPersonasD.SelectedIndex=0;
                idDelito = Convert.ToInt32(this.gvPersonasD.SelectedDataKey.Value);
                TraerMailsAsociados(idDelito);
                BuscarIpp(idDelito, ipp, esExtJur);

            }
            else
            {
                this.divPersonasD.Style.Add("display", "none");
                BuscarIpp(-1,ipp,esExtJur);
            }
            //if (this.gvPersonasD.Rows.Count > 0)
            //    this.gvPersonasD.SelectedIndex = 0;

            if (this.gvPersonasD.Rows.Count > 0)
            {
               
                
                    for(int i=0;i<this.gvPersonasD.Rows.Count;i++)
                    {
                        GridView gvr=this.gvPersonasD;
                        Button btnBorrarPersonaD=(Button)gvr.FindControl("btnBorrarPersonaD");
                        if (btnBorrarPersonaD != null)
                        {
                            if (state == FuncionesGrales.EstadoPrograma.Consultando)
                                btnBorrarPersonaD.Style.Add("display", "none");
                            else
                                btnBorrarPersonaD.Style.Remove("display");
                        }
                    }
                
            }

            SetearGvPersonas();
        }

        private int PrimeraFilaSinBajaEnGvPersonas()
        {
            int filaSinBaja = -1;
            if (this.gvPersonasD.Rows.Count > 0)
            {
                
                //this.gvPersonasD.SelectedIndex = 0;

                for (int i = 0; i < this.gvPersonasD.Rows.Count; i++)
                {
                    GridView gvr = this.gvPersonasD;
                    CheckBox chkBaja = (CheckBox)gvr.Rows[i].Cells[7].FindControl("Baja");
                    if (!chkBaja.Checked && filaSinBaja == -1)
                    {
                        filaSinBaja = i;
                        //gvr.SelectedIndex = i;
                    }
                }
            }
            return filaSinBaja;
        }
        protected void btnFotoSigGeneralD_Click(object sender, EventArgs e)
        {


            AvanzarFoto(FuncionesGrales.TipoFoto.General);


        }

        protected void btnFotoSigSeniasD_Click(object sender, EventArgs e)
        {
            AvanzarFoto(FuncionesGrales.TipoFoto.SeniasParticulares);
        }

        protected void btnFotoPrevGeneralD_Click(object sender, EventArgs e)
        {

            RetrocederFoto(FuncionesGrales.TipoFoto.General);


        }

        protected void btnFotoPrevSeniasD_Click(object sender, EventArgs e)
        {
            RetrocederFoto(FuncionesGrales.TipoFoto.SeniasParticulares);
        }

        protected void btnBorrarFotoSeniasD_Click(object sender, EventArgs e)
        {

            BorrarFoto(this.imgFotoSeniasD.ImageUrl, FuncionesGrales.TipoFoto.SeniasParticulares);
        }

        protected void btnBorrarFotoGralD_Click(object sender, EventArgs e)
        {
            BorrarFoto(this.imgFotoGeneralD.ImageUrl, FuncionesGrales.TipoFoto.General);
        }

        protected void btnVerResultadosD_Click(object sender, EventArgs e)
        {

            GestionBusquedaIndividual(FuncionesGrales.TipoBusqueda.PersonaDesaparecida, FuncionesGrales.EstadoPrograma.Consultando);
        }

        protected void gvResultadosHalladasBI_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idPersona = Convert.ToInt32(this.gvResultadosHalladasBI.DataKeys[e.RowIndex].Value);
            BusquedasFavoritas bf = BusquedasFavoritasManager.GetItem(idPersona, (int)FuncionesGrales.TipoBusqueda.PersonaHallada);
            bool borroBien = BusquedasFavoritasManager.Delete(bf);
            this.gvResultadosHalladasBI.Rows[e.RowIndex].Visible = false;
        }

        //protected void gvResultadosHalladasBI_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    return;
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        foreach (TableCell c in e.Row.Cells)
        //        {
        //            TableCell celda = c;


        //            MPBA.PersonasBuscadas.BusinessEntities.PersonasHalladas personaHallada = (MPBA.PersonasBuscadas.BusinessEntities.PersonasHalladas)e.Row.DataItem;
        //            switch (((DataControlFieldCell)c).ContainingField.ToString().Trim().ToUpper())
        //            {
        //                case "LUGAR HALLAZGO":
        //                    c.Text = SIAC.Bll.LocalidadManager.GetItem(personaHallada.idLugarHallazgo).localidad.Trim();
        //                    break;
        //                case "ADN":
        //                    if (personaHallada.CoincidenciaAdn > 0)
        //                        c.ForeColor = Color.Green;
        //                    break;
        //                case "ASPECTO CABELLO":
        //                    c.Text = PBClaseAspectoCabelloManager.GetItem(personaHallada.idAspectoCabello).Descripcion;
        //                    if (personaHallada.CoincidenciaAspectoCabello > 0)
        //                        c.ForeColor = Color.Green;
        //                    break;
        //                case "CALVICIE":
        //                    c.Text = PBClaseCalvicieManager.GetItem(personaHallada.idCalvicie).Descripcion;
        //                    if (personaHallada.CoincidenciaCalvicie > 0)
        //                        c.ForeColor = Color.Green;
        //                    break;
        //                case "COLOR CABELLO":
        //                    c.Text = PBClaseColorCabelloManager.GetItem(personaHallada.idColorCabello).Descripcion;
        //                    if (personaHallada.CoincidenciaColorCabello > 0)
        //                        c.ForeColor = Color.Green;
        //                    break;
        //                case "COLOR OJOS":
        //                    c.Text = PBClaseColorOjosManager.GetItem(personaHallada.idColorOjos).Descripcion;
        //                    if (personaHallada.CoincidenciaColorOjos > 0)
        //                        c.ForeColor = Color.Green;
        //                    break;
        //                case "COLOR PIEL":
        //                    c.Text = PBClaseColorDePielManager.GetItem(personaHallada.idColorPiel).Descripcion;
        //                    if (personaHallada.CoincidenciaColorPiel > 0)
        //                        c.ForeColor = Color.Green;
        //                    break;
        //                case "COLOR TENIDO":
        //                    c.Text = PBClaseColorCabelloManager.GetItem(personaHallada.idColorTenido).Descripcion;
        //                    if (personaHallada.CoincidenciaColorTenido > 0)
        //                        c.ForeColor = Color.Green;
        //                    break;
        //                case "EDAD APARENTE":
        //                    if (personaHallada.CoincidenciaEdadAparente > 0)
        //                        c.ForeColor = Color.Green;
        //                    break;
        //                case "FALTAN DIENTES":

        //                    if (personaHallada.FaltanPiezasDentales != null)
        //                    {
        //                        int faltandientes = Convert.ToInt16(personaHallada.FaltanPiezasDentales);
        //                        c.Text = PBClaseBooleanManager.GetItem(faltandientes).Descripcion;
        //                    }
        //                    if (personaHallada.CoincidenciaFaltanDientes > 0)
        //                        c.ForeColor = Color.Green;
        //                    break;
        //                case "FECHA HALLAZGO":
        //                    if (personaHallada.CoincidenciaFecha > 0)
        //                        c.ForeColor = Color.Green;
        //                    break;
        //                case "ROSTRO":
        //                    c.Text = PBClaseRostroManager.GetItem(personaHallada.idRostro).Descripcion;
        //                    break;
        //                case "LONG. CABELLO":
        //                    c.Text = PBClaseLongitudCabelloManager.GetItem(personaHallada.idLongitudCabello).Descripcion;
        //                    if (personaHallada.CoincidenciaLongitudCabello > 0)
        //                        c.ForeColor = Color.Green;
        //                    break;
        //                case "NOMBRE":
        //                    if (personaHallada.CoincidenciaNombreyApellido > 0)
        //                        c.ForeColor = Color.Green;
        //                    break;
        //                case "PESO":
        //                    if (personaHallada.CoincidenciaPeso > 0)
        //                        c.ForeColor = Color.Green;
        //                    break;
        //                case "SEXO":
        //                    c.Text = PBClaseSexoManager.GetItem(personaHallada.idSexo).Descripcion;
        //                    if (personaHallada.CoincidenciaSexo > 0)
        //                        c.ForeColor = Color.Green;
        //                    break;
        //                case "TALLA":
        //                    if (personaHallada.CoincidenciaTalla > 0)
        //                        c.ForeColor = Color.Green;
        //                    break;

        //            }

        //        }
        //    }
        //}

        protected void gvResultadosDesapBI_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (TableCell c in e.Row.Cells)
                {
                    TableCell celda = c;

                    MPBA.PersonasBuscadas.BusinessEntities.PersonasDesaparecidas personaDesaparecida = (MPBA.PersonasBuscadas.BusinessEntities.PersonasDesaparecidas)e.Row.DataItem;
                    switch (((DataControlFieldCell)c).ContainingField.ToString().Trim().ToUpper())
                    {
                        case "ADN":
                            if (personaDesaparecida.CoincidenciaAdn > 0)
                            {
                                c.CssClass = "CeldaColor";
                                //c.DataBind();
                            }
                            break;
                        case "ASPECTO CABELLO":
                            if (personaDesaparecida.CoincidenciaAspectoCabello > 0)
                            {
                                c.CssClass = "CeldaColor";
                                //c.DataBind();
                            }
                            break;
                        case "CALVICIE":
                            if (personaDesaparecida.CoincidenciaCalvicie > 0)
                            {
                                c.CssClass = "CeldaColor";
                                //c.DataBind();
                            }
                            break;
                        case "COLOR CABELLO":
                            if (personaDesaparecida.CoincidenciaColorCabello > 0)
                            {
                                c.CssClass = "CeldaColor";
                                //c.DataBind();
                            }
                            break;
                        case "COLOR OJOS":
                            if (personaDesaparecida.CoincidenciaColorOjos > 0)
                            {
                                c.CssClass = "CeldaColor";
                                //c.DataBind();
                            }
                            break;
                        case "COLOR PIEL":
                            if (personaDesaparecida.CoincidenciaColorPiel > 0)
                            {
                                c.CssClass = "CeldaColor";
                                //c.DataBind();
                            }
                            break;
                        case "COLOR TENIDO":
                            if (personaDesaparecida.CoincidenciaColorTenido > 0)
                            {
                                c.CssClass = "CeldaColor";
                                //c.DataBind();
                            }
                            break;
                        case "EDAD DESAP.":
                            if (personaDesaparecida.CoincidenciaEdad > 0)
                            {
                                c.CssClass = "CeldaColor";
                                //c.DataBind();
                            }
                            break;
                        case "FALTAN DIENTES":
                            if (personaDesaparecida.CoincidenciaFaltanDientes > 0)
                            {
                                c.CssClass = "CeldaColor";
                                //c.DataBind();
                            }
                            break;
                        case "FECHA DESAP.":
                            if (personaDesaparecida.CoincidenciaFecha > 0)
                            {
                                c.CssClass = "CeldaColor";
                                //c.DataBind();
                            }
                            break;
                        case "LONG. CABELLO":
                            if (personaDesaparecida.CoincidenciaLongitudCabello > 0)
                            {
                                c.CssClass = "CeldaColor";
                                //c.DataBind();
                            }
                            break;
                        case "NOMBRE":
                            if (personaDesaparecida.CoincidenciaNombreyApellido > 0)
                            {
                                c.CssClass = "CeldaColor";
                                //c.DataBind();
                            }
                            break;
                        case "PESO":
                            if (personaDesaparecida.CoincidenciaPeso > 0)
                            {
                                c.CssClass = "CeldaColor";
                                //c.DataBind();
                            }
                            break;
                        case "SEXO":
                            if (personaDesaparecida.CoincidenciaSexo > 0)
                            {
                                c.CssClass = "CeldaColor";
                                //c.DataBind();
                            }
                            break;
                        case "TALLA":
                            if (personaDesaparecida.CoincidenciaTalla > 0)
                            {
                                c.CssClass = "CeldaColor";
                                //c.DataBind();
                            }
                            break;

                    }

                }
            }
        }

        protected void btnOkTipoFoto_Click(object sender, EventArgs e)
        {


            ////this.btnSubirFotoD.Enabled = false;
            //this.fuFotoUploaderD.SaveAs(Server.MapPath(FuncionesGrales.RutaFotosTemp + "/" + this.fuFotoUploaderD.FileName));
            switch (this.rblTipoFotos.SelectedValue)
            {
                case "1":

                    SubirFoto(FuncionesGrales.TipoBusqueda.PersonaDesaparecida, FuncionesGrales.TipoFoto.General);
                    break;
                case "2":

                    SubirFoto(FuncionesGrales.TipoBusqueda.PersonaDesaparecida, FuncionesGrales.TipoFoto.SeniasParticulares);
                    break;
                case "3":

                    SubirFoto(FuncionesGrales.TipoBusqueda.PersonaDesaparecida, FuncionesGrales.TipoFoto.Huellas);
                    break;
            }

            Session["imgPreview"] = null;
            this.imgFotoPreview.ImageUrl = "~/App_Images/SinFoto.GIF";
            this.upImage.Update();
            this.upSubirFotoGeneralD.Update();
            this.imgFotoGeneralD.Focus();
        }

        protected void btnLimpiarD_Click(object sender, EventArgs e)
        {
            LimpiarControlesD();
            LimpiarControlesBI();
            LimpiarControlesExtJur();
            this.txtIppBuscadoD.Text = "";
            this.txtCausa.Text = "";
            this.pnlIPPD.Enabled = true;
            this.pnlPersonadesaparecida.Enabled = false;
            this.txtIppBuscadoD.Focus();
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session["imgPreview"] = null;
            myMaster.btnConfigurarMailPB.Visible = false;
            Session["moduloActual"] = null;//no resalta nada en el menu
            Response.Redirect("~/Home.aspx");
        }

        protected void btnAgregarSenia_Click(object sender, EventArgs e)
        {
            GridView gvSenasPart = null;
            int idSenia;
            int idUbicacionSenia;
            SeniasParticulares sena;
            string argumento = ((LinkButton)sender).CommandArgument;
            switch (argumento)
            {
                case "H":
                    //gvSenasPart = this.gvSenasPartH;
                    break;
                case "D":
                    gvSenasPart = this.gvSenasPartD;
                    idSenia = Convert.ToInt32(((DropDownList)gvSenasPart.FooterRow.FindControl("ddlSeniaPartInsert")).SelectedValue);
                    idUbicacionSenia = Convert.ToInt32(((DropDownList)gvSenasPart.FooterRow.FindControl("ddlUbicacionSenaPartInsert")).SelectedValue);
                    if (idSenia == 0 || idUbicacionSenia == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Debe indicar la seña y su ubicación.');", true);
                        return;
                    }
                    sena = new SeniasParticulares();
                    sena.idSeniaParticular = idSenia;
                    sena.idUbicacionSeniaParticular = idUbicacionSenia;
                    sena.descripcion = Convert.ToString(((TextBox)gvSenasPart.FooterRow.FindControl("descripcionInsert")).Text);
                    sena.id = -1;
                    sena.idTablaDestino = 1;
                    SeniasD.Add(sena);
                    gvSenasPart.DataSource = SeniasD;
                    gvSenasPart.DataBind();
                    break;
                case "B":
                    //gvSenasPart = this.gvSenasPartB;
                    break;
                case "BI":
                    gvSenasPart = this.gvSenasPartBI;
                    idSenia = Convert.ToInt32(((DropDownList)gvSenasPart.FooterRow.FindControl("ddlSeniaPartInsert")).SelectedValue);
                    idUbicacionSenia = Convert.ToInt32(((DropDownList)gvSenasPart.FooterRow.FindControl("ddlUbicacionSenaPartInsert")).SelectedValue);
                    if (idSenia == 0 || idUbicacionSenia == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Debe indicar la seña y su ubicación.');", true);
                        return;
                    }
                    sena = new SeniasParticulares();
                    sena.idSeniaParticular = idSenia;
                    sena.idUbicacionSeniaParticular = idUbicacionSenia;
                    //sena.descripcion = Convert.ToString(((TextBox)gvSenasPart.FooterRow.FindControl("descripcionInsert")).Text);
                    sena.id = -1;
                    sena.idTablaDestino = 1;
                    SeniasBI.Add(sena);
                    gvSenasPartBI.DataSource = SeniasBI;
                    gvSenasPartBI.DataBind();
                    break;
            }



        }

        protected void gvResultadosHalladasBI_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(this.gvResultadosHalladasBI.SelectedValue.ToString());
            PersonasHalladas ph = PersonasHalladasManager.GetItem(id, true);
            LimpiarControlesFichaPersHalladaBI();
            LlenarControlesFichaPersHalladaBI(ph);
            this.hfOkFichaBIH.Value = id.ToString();
            this.hfGestionFichaPersHalladaBI_ModalPopupExtender.Enabled = true;
            this.pnlResultadosBI.Visible = true;
            this.hfGestionFichaPersHalladaBI_ModalPopupExtender.Show();
            this.hfAbrirResultadosBI_ModalPopupExtender1.Hide();
        }

        protected void ddlDepartamentosComisarias_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComisariaList cl = MPBA.SIAC.Bll.ComisariaManager.GetList(Convert.ToInt32(this.ddlDepartamentosComisarias.SelectedValue));
            this.gvComisarias.DataSource = cl;
            this.gvComisarias.DataBind();
        }

        protected void gvComisarias_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblComisariaPersonaD.Text = this.gvComisarias.SelectedRow.Cells[2].Text.Trim();
            //this.lblDepartamentoComisariaD.Text = this.ddlDepartamentosComisarias.SelectedItem.Text.Trim();
            this.hfComisariaDId.Value = this.gvComisarias.SelectedValue.ToString();
            if (this.gvWebServerCausaD.Rows.Count > 0)
            {
                string celdaComisaria = this.gvWebServerCausaD.Rows[0].Cells[4].Text.Trim().ToLower();
                if (celdaComisaria != this.lblComisariaPersonaD.Text.ToLower())
                    this.lblSeccionalNoCoincide.Style.Remove("display");
                else
                    this.lblSeccionalNoCoincide.Style.Add("display", "none");
            }

            this.pnlComisarias.Style.Add("display", "none");
            this.hfAbrirComisarias_ModalPopupExtender.Hide();
        }

        protected void btnCancelarComisarias_Click(object sender, EventArgs e)
        {
            this.pnlComisarias.Style.Add("display", "none");
            //this.pnlComisarias.Visible = false;
            this.hfAbrirComisarias_ModalPopupExtender.Hide();
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
            
            this.hfAbrirResultadosBI_ModalPopupExtender1.Show();
            //this.gvResultadosHalladasBI.DataBind();
        }

        protected void btnAgregarPrimerTatuaje_Click(object sender, EventArgs e)
        {
            GridView gvTatuajes = null;
            int idTatuaje = 0;
            int idUbicacionTatuaje = 0;
            MPBA.SIAC.BusinessEntities.TatuajesPersona tatuaje = new TatuajesPersona();
            string argumento = ((LinkButton)sender).CommandArgument;
            switch (argumento)
            {
                case "D":
                    gvTatuajes = this.gvTatuajesD;
                    break;
                case "BI":
                     gvTatuajes = this.gvTatuajesBI;
                    break;
            }
            idTatuaje = Convert.ToInt32(((DropDownList)gvTatuajes.Controls[0].Controls[0].Controls[0].FindControl("ddlTatuajes")).SelectedValue);
            idUbicacionTatuaje = Convert.ToInt32(((DropDownList)gvTatuajes.Controls[0].Controls[0].Controls[0].FindControl("ddlUbicacionTatuaje")).SelectedValue);
            if (idTatuaje == 0 || idUbicacionTatuaje == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Debe indicar el tatuaje y su ubicación.');", true);
                return;
            }
            tatuaje = new TatuajesPersona();
            tatuaje.idTatuaje = idTatuaje;
            tatuaje.idUbicacionTatuaje = idUbicacionTatuaje;
            tatuaje.id = -1;
            tatuaje.idTablaDestino = 1;
            tatuaje.idPersona = idPersonaDesaparecida;
            switch (argumento)
            {
                case "D":
                    TatuajesD = new TatuajesPersonaList();
                    TatuajesD.Add(tatuaje);
                    Session["TatuajesD"] = TatuajesD;
                    gvTatuajes.DataSource = TatuajesD;
                    gvTatuajes.DataBind();
                    break;

                case "BI":
                    TatuajesBI = new TatuajesPersonaList();
                    TatuajesBI.Add(tatuaje);
                    Session["TatuajesBI"] = TatuajesBI;
                    gvTatuajes.DataSource = TatuajesBI;
                    gvTatuajes.DataBind();
                    break;
            }
        }

        protected void btnTraerComisariaD_Click(object sender, ImageClickEventArgs e)
        {
            this.hfAbrirComisarias_ModalPopupExtender.Enabled = true;
            this.hfComisarias.Value = "D";
            this.hfLugarElegido.Value = "d";
            this.pnlComisarias.Visible = true;
            this.hfAbrirComisarias_ModalPopupExtender.Show();

        }

        protected void btnBuscarLocalidadD_Click(object sender, ImageClickEventArgs e)
        {
            this.hfAbrirLugar_ModalPopupExtender.Enabled = true;
            this.hfLugarElegido.Value = "D";
            this.pnlLugar.Visible = true;
            this.hfAbrirLugar_ModalPopupExtender.Show();
            this.txtLugar.Focus();
        }

        protected void gvLugarD_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.hfLugarDId.Value = this.gvLugar.SelectedValue.ToString();
            this.lblLugarDesapPersona.Text = this.gvLugar.SelectedRow.Cells[2].Text.Trim();
            this.lblPartidoDesaparicion.Text = ((Label)this.gvLugar.SelectedRow.Cells[3].FindControl("lblPartidoGrid")).Text.Trim();
            this.lblProvinciaDesapD.Text = ((Label)this.gvLugar.SelectedRow.Cells[4].FindControl("lblProvinciaGrid")).Text.Trim();
            this.pnlLugar.Style.Add("display", "none");
            this.hfAbrirLugar_ModalPopupExtender.Hide();
        }

        protected void btnBuscarPartidoD_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnBusDesap_Click(object sender, EventArgs e)
        {
            //switch (this.hfBA.Value)
            //{
            //    case "A"://busqueda activa
            //        List<MPBA.PersonasBuscadas.BusinessEntities.Busqueda> busqDesap = MPBA.PersonasBuscadas.Bll.BusquedaManager.GetList().FindAll(delegate(MPBA.PersonasBuscadas.BusinessEntities.Busqueda bs) { return bs.Usuario.Trim() == Session["miUsuario"].ToString().Trim() && bs.Baja == false; }).FindAll(delegate(MPBA.PersonasBuscadas.BusinessEntities.Busqueda bs) { return bs.idOrigen == 1 && (DateTime.Today.Subtract((bs.FechaUltimaModificacion))).Days < CantDiasBusqActiva; });
            //        this.gvBusqActivas.DataSource = busqDesap;
            //        this.gvBusqActivas.DataBind();
            //        this.gvBusqActivas.Visible = true;
            //        break;
            //    case "F"://busquedas favoritas
            //        List<MPBA.PersonasBuscadas.BusinessEntities.PersonasDesaparecidas> bfDesap = BusquedasFavoritasManager.GetListJoinedDesaparecidas(Session["miUsuario"].ToString().Trim());
            //        this.gvBusqActivas.DataSource = bfDesap;
            //        this.gvBusqActivas.DataBind();
            //        this.gvBusqActivas.Visible = true;
            //        break;
            //}
        }

        protected void gvResultadoBusquedaParsonasDesap_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //int id = Convert.ToInt32(this.gvResultadoBusquedaPersonasDesap.DataKeys[e.RowIndex].Value);
            //if (MPBA.PersonasBuscadas.Bll.PersonasDesaparecidasManager.Delete(MPBA.PersonasBuscadas.Bll.PersonasDesaparecidasManager.GetItem(id)))
            //    this.gvResultadoBusquedaPersonasDesap.Rows[e.RowIndex].Visible = false;
        }

        protected void btnBorrarD_Click(object sender, EventArgs e)
        {
            MPBA.PersonasBuscadas.BusinessEntities.PersonasDesaparecidas personaDesaparecida = MPBA.PersonasBuscadas.Bll.PersonasDesaparecidasManager.GetItem(idPersonaDesaparecida);
            if (MPBA.PersonasBuscadas.Bll.PersonasDesaparecidasManager.Delete(personaDesaparecida))
            {
                LimpiarControlesD();
                ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "updatealert", @"<script language='javascript'>setTimeout(""alert('Registro borrado correctamente.')"",1000); </script>");
            }
        }

        protected void btnVerCriterioBusquedaD_Click(object sender, EventArgs e)
        {

            // this.btnGuardarBusquedaBI.Style.Add("display", "none");
            PersonasDesaparecidas personaDesaparecida = PersonasDesaparecidasManager.GetItem(Convert.ToInt32(this.btnVerResultadosD.CommandArgument), true);
            LimpiarControlesVerCriterioBI();
            this.lblGuardoExitoD.Visible = false;
            if (personaDesaparecida != null)
                LlenarControlesVerPersonaDesaparecidaEnCriterioBI();
            LlenarControlesVerCriterioBI(BusquedaManager.GetItem(Convert.ToInt32(this.btnVerCriterioBusquedaD.CommandArgument), true));
            this.hfVerCriterioBI_ModalPopupExtender.Show();

        }

        protected void gvTatuajes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.gvTatuajesD.ShowFooter = true;
            e.Cancel = true;
            string tipoBusqueda = "";
            GridView gvTatuajes = (GridView)sender;
            switch (gvTatuajes.ID)
            {
                case "gvTatuajesD":
                    tipoBusqueda = "D";
                    gvTatuajes.EditIndex = -1;
                    gvTatuajes.DataSource = TatuajesD;
                    gvTatuajes.DataBind();
                    break;
                case "gvTatuajesH":
                    tipoBusqueda = "H";
                    break;
                case "gvTatuajesB":
                    tipoBusqueda = "B";
                    break;
                case "gvTatuajesBI":
                    tipoBusqueda = "BI";
                    gvTatuajes.EditIndex = -1;
                    gvTatuajes.DataSource = TatuajesBI;
                    gvTatuajes.DataBind();
                    break;
            }


        }

        protected void gvTatuajes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
            string tipoBusqueda = "";
            GridView gvTatuajes = (GridView)sender;
            switch (gvTatuajes.ID)
            {
                case "gvTatuajesD":
                    tipoBusqueda = "D";
                    gvTatuajes.EditIndex = -1;
                    TatuajesD.RemoveAt(e.RowIndex);
                    gvTatuajes.DataSource = TatuajesD;
                    gvTatuajes.DataBind();
                    break;
                case "gvTatuajesH":
                    tipoBusqueda = "H";
                    break;
                case "gvTatuajesBI":
                    tipoBusqueda = "BI";
                    gvTatuajes.EditIndex = -1;
                    TatuajesBI.RemoveAt(e.RowIndex);
                    gvTatuajes.DataSource = TatuajesBI;
                    gvTatuajes.DataBind();
                    break;
                case "gvTatuajesB":
                    tipoBusqueda = "B";
                    break;
            }


        }

        protected void gvTatuajes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.gvTatuajesD.ShowFooter = false;
            string tipoBusqueda = "";
            int id;
            GridView gvTatuajes = (GridView)sender;
            switch (gvTatuajes.ID)
            {
                case "gvTatuajesD":
                    tipoBusqueda = "D";
                    gvTatuajes.EditIndex = e.NewEditIndex;
                    id = Convert.ToInt32(gvTatuajes.DataKeys[e.NewEditIndex].Value);
                    gvTatuajes.DataSource = TatuajesD;
                    gvTatuajes.DataBind();
                    break;
                case "gvTatuajesH":
                    tipoBusqueda = "H";
                    break;
                case "gvTatuajesB":
                    tipoBusqueda = "B";
                    break;
                case "gvTatuajesBI":
                    tipoBusqueda = "BI";
                    gvTatuajes.EditIndex = e.NewEditIndex;
                    id = Convert.ToInt32(gvTatuajes.DataKeys[e.NewEditIndex].Value);
                    gvTatuajes.DataSource = TatuajesBI;
                    gvTatuajes.DataBind();
                    break;
            }




        }

        protected void gvTatuajes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            this.gvTatuajesD.ShowFooter = true;
            string tipoBusqueda = "";
            int idTatuaje;
            int idUbicacionTatuaje;
            MPBA.SIAC.BusinessEntities.TatuajesPersona tatuaje;
            GridView gvTatuajes = (GridView)sender;
            switch (gvTatuajes.ID)
            {
                case "gvTatuajesD":
                    tipoBusqueda = "D";
                    idTatuaje = Convert.ToInt32(((DropDownList)(gvTatuajes.Rows[e.RowIndex].Cells[3].FindControl("ddlTatuajes"))).SelectedValue);
                    idUbicacionTatuaje = Convert.ToInt32(((DropDownList)(gvTatuajes.Rows[e.RowIndex].Cells[4].FindControl("ddlUbicacionTatuaje"))).SelectedValue);
                    if (idTatuaje == 0 || idUbicacionTatuaje == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Debe indicar el tatuaje y su ubicación.');", true);
                        return;
                    }
                    tatuaje = TatuajesD[e.RowIndex];
                    tatuaje.idTatuaje = idTatuaje;
                    tatuaje.idUbicacionTatuaje = idUbicacionTatuaje;
                    tatuaje.descripcion = Convert.ToString(((TextBox)(gvTatuajes.Rows[e.RowIndex].Cells[5].FindControl("descripcionTatuajePart"))).Text);
                    tatuaje.idPersona = idPersonaDesaparecida;

                    gvTatuajes.EditIndex = -1;
                    gvTatuajes.DataSource = TatuajesD;
                    gvTatuajes.DataBind();
                    break;
                case "gvTatuajesH":
                    tipoBusqueda = "H";
                    break;
                case "gvTatuajesB":
                    tipoBusqueda = "B";
                    break;
                case "gvTatuajesBI":
                    tipoBusqueda = "BI";
                    idTatuaje = Convert.ToInt32(((DropDownList)(gvTatuajes.Rows[e.RowIndex].Cells[3].FindControl("ddlTatuajes"))).SelectedValue);
                    idUbicacionTatuaje = Convert.ToInt32(((DropDownList)(gvTatuajes.Rows[e.RowIndex].Cells[4].FindControl("ddlUbicacionTatuaje"))).SelectedValue);
                    if (idTatuaje == 0 || idUbicacionTatuaje == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Debe indicar el tatuaje y su ubicación.');", true);
                        return;
                    }
                    tatuaje = TatuajesBI[e.RowIndex];
                    tatuaje.idTatuaje = idTatuaje;
                    tatuaje.idUbicacionTatuaje = idUbicacionTatuaje;
                    tatuaje.idPersona = idPersonaDesaparecida;
                    gvTatuajes.EditIndex = -1;
                    gvTatuajes.DataSource = TatuajesBI;
                    gvTatuajes.DataBind();
                    break;
            }


        }

        protected void btnAgregarTatuaje_Click(object sender, EventArgs e)
        {
            GridView gvTatuajes = null;
            string argumento = ((LinkButton)sender).CommandArgument;
            switch (argumento)
            {

                case "D":
                    gvTatuajes = this.gvTatuajesD;
                    break;
                case "BI":
                   gvTatuajes = this.gvTatuajesBI;
                    break;
            }
            int idTatuaje = Convert.ToInt32(((DropDownList)gvTatuajes.FooterRow.FindControl("ddlTatuajeInsert")).SelectedValue);
            int idUbicacionTatuaje = Convert.ToInt32(((DropDownList)gvTatuajes.FooterRow.FindControl("ddlUbicacionTatuajeInsert")).SelectedValue);
            if (idTatuaje == 0 || idUbicacionTatuaje == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Debe indicar el tatuaje y su ubicación.');", true);
                return;
            }
            MPBA.SIAC.BusinessEntities.TatuajesPersona tatuaje = new TatuajesPersona();
            tatuaje.idTatuaje = idTatuaje;
            tatuaje.idUbicacionTatuaje = idUbicacionTatuaje;
            tatuaje.id = -1;
            tatuaje.idTablaDestino = 1;
            if (argumento == "D")
            {
                TatuajesD.Add(tatuaje);
                gvTatuajes.DataSource = TatuajesD;
                gvTatuajes.DataBind();
            }
            else if (argumento == "BI")
            {
                TatuajesBI.Add(tatuaje);
                gvTatuajes.DataSource = TatuajesBI;
                gvTatuajes.DataBind();
            }

        }

        protected void gvSenasPart_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string tipoBusqueda = "";
            int id = 0;
            GridView gvSenasPart = (GridView)sender;
            switch (gvSenasPart.ID)
            {
                case "gvSenasPartD":
                    tipoBusqueda = "D";
                    gvSenasPart.EditIndex = e.NewEditIndex;
                    id = Convert.ToInt32(gvSenasPart.DataKeys[e.NewEditIndex].Value);
                    gvSenasPart.DataSource = SeniasD;
                    gvSenasPart.DataBind();
                    break;
                case "gvSenasPartH":
                    tipoBusqueda = "H";
                    break;
                case "gvSenasPartB":
                    tipoBusqueda = "B";
                    break;
                case "gvSenasPartBI":
                    tipoBusqueda = "BI";
                     gvSenasPart.EditIndex = e.NewEditIndex;
                    id = Convert.ToInt32(gvSenasPart.DataKeys[e.NewEditIndex].Value);
                    gvSenasPart.DataSource = SeniasBI;
                    gvSenasPart.DataBind();
                    break;
            }
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
                    gvSenasPart.EditIndex = -1;
                    gvSenasPart.DataSource = SeniasD;
                    gvSenasPart.DataBind();
                    break;
                case "gvSenasPartH":
                    tipoBusqueda = "H";
                    break;
                case "gvSenasPartB":
                    tipoBusqueda = "B";
                    break;
                case "gvSenasPartBI":
                    tipoBusqueda = "BI";
                     gvSenasPart.EditIndex = -1;
                    gvSenasPart.DataSource = SeniasBI;
                    gvSenasPart.DataBind();
                    break;
            }



        }

        protected void gvSenasPart_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string tipoBusqueda = "";
            SeniasParticulares senia;
            GridView gvSenasPart = (GridView)sender;
            int idSenia = 0;
            int idUbicacionSenia = 0;
            switch (gvSenasPart.ID)
            {
                case "gvSenasPartD":
                    tipoBusqueda = "D";
                    senia = SeniasD[e.RowIndex];
                    idSenia = Convert.ToInt32(((DropDownList)(gvSenasPart.Rows[e.RowIndex].Cells[3].FindControl("ddlSeniaPart"))).SelectedValue);
                    idUbicacionSenia = Convert.ToInt32(((DropDownList)(gvSenasPart.Rows[e.RowIndex].Cells[4].FindControl("ddlUbicacionSenaPart"))).SelectedValue);
                    if (idSenia == 0 || idUbicacionSenia == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Debe indicar la seña y su ubicación.');", true);
                        return;
                    }
                    senia.idSeniaParticular = idSenia;
                    senia.idUbicacionSeniaParticular = idUbicacionSenia;
                    senia.descripcion = Convert.ToString(((TextBox)(gvSenasPart.Rows[e.RowIndex].Cells[5].FindControl("descripcionSenaPart"))).Text);
                    gvSenasPart.EditIndex = -1;
                    gvSenasPart.DataSource = SeniasD;
                    gvSenasPart.DataBind();
                    break;
                case "gvSenasPartH":
                    tipoBusqueda = "H";
                    break;
                case "gvSenasPartB":
                    tipoBusqueda = "B";
                    break;
                case "gvSenasPartBI":
                    tipoBusqueda = "BI";
                    senia = SeniasBI[e.RowIndex];
                    idSenia = Convert.ToInt32(((DropDownList)(gvSenasPart.Rows[e.RowIndex].Cells[3].FindControl("ddlSeniaPart"))).SelectedValue);
                    idUbicacionSenia = Convert.ToInt32(((DropDownList)(gvSenasPart.Rows[e.RowIndex].Cells[4].FindControl("ddlUbicacionSenaPart"))).SelectedValue);
                    if (idSenia == 0 || idUbicacionSenia == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Debe indicar la seña y su ubicación.');", true);
                        return;
                    }
                    senia.idSeniaParticular = idSenia;
                    senia.idUbicacionSeniaParticular = idUbicacionSenia;
                    senia.descripcion = "";
                    gvSenasPart.EditIndex = -1;
                    gvSenasPart.DataSource = SeniasBI;
                    gvSenasPart.DataBind();
                    break;
            }



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
                    gvSenasPart.EditIndex = -1;
                    SeniasD.RemoveAt(e.RowIndex);
                    gvSenasPart.DataSource = SeniasD;
                    gvSenasPart.DataBind();
                    break;
                case "gvSenasPartH":
                    tipoBusqueda = "H";
                    break;
                case "gvSenasPartBI":
                    tipoBusqueda = "BI";
                     gvSenasPart.EditIndex = -1;
                    SeniasBI.RemoveAt(e.RowIndex);
                    gvSenasPart.DataSource = SeniasBI;
                    gvSenasPart.DataBind();
                    break;
                case "gvSenasPartB":
                    tipoBusqueda = "B";
                    break;
            }


        }

        protected void btnAgregarPrimeraSenia_Click(object sender, EventArgs e)
        {

            GridView gvSenasPart = null;
            string argumento = ((LinkButton)sender).CommandArgument;
            int idSenia = 0;
            int idUbicacionSenia = 0;
            SeniasParticulares sena;
            switch (argumento)
            {
                case "H":
                    //gvSenasPart = this.gvSenasPartH;
                    break;
                case "D":
                    gvSenasPart = this.gvSenasPartD;
                    idSenia=Convert.ToInt32(((DropDownList)gvSenasPart.Controls[0].Controls[0].Controls[0].FindControl("ddlSenasParticulares")).SelectedValue);
                    idUbicacionSenia = Convert.ToInt32(((DropDownList)gvSenasPart.Controls[0].Controls[0].Controls[0].FindControl("ddlUbicacionSenasPart")).SelectedValue);
                    if (idSenia == 0 || idUbicacionSenia == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Debe indicar la seña y su ubicación.');", true);
                        return;
                    }
                    sena = new SeniasParticulares();
                    sena.idSeniaParticular = idSenia;
                    sena.idUbicacionSeniaParticular = idUbicacionSenia;
                    sena.descripcion = Convert.ToString(((TextBox)(gvSenasPart.Controls[0].Controls[0].Controls[0].FindControl("descripcionSenaPart"))).Text);
                    sena.id = -1;
                    sena.idTablaDestino = 1;
                    SeniasD = new SeniasParticularesList();
                    SeniasD.Add(sena);
                    Session["SeniasD"] = SeniasD;
                    gvSenasPart.DataSource = SeniasD;
                    gvSenasPart.DataBind();
                    break;
                case "BI":
                    gvSenasPart = this.gvSenasPartBI;
                    idSenia=Convert.ToInt32(((DropDownList)gvSenasPart.Controls[0].Controls[0].Controls[0].FindControl("ddlSenasParticulares")).SelectedValue);
                    idUbicacionSenia = Convert.ToInt32(((DropDownList)gvSenasPart.Controls[0].Controls[0].Controls[0].FindControl("ddlUbicacionSenasPart")).SelectedValue);
                    if (idSenia == 0 || idUbicacionSenia == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Debe indicar la seña y su ubicación.');", true);
                        return;
                    }
                    sena = new SeniasParticulares();
                    sena.idSeniaParticular = idSenia;
                    sena.idUbicacionSeniaParticular = idUbicacionSenia;
                    //sena.descripcion = Convert.ToString(((TextBox)(gvSenasPart.Controls[0].Controls[0].Controls[0].FindControl("descripcionSenaPart"))).Text);
                    sena.descripcion = "";
                    sena.id = -1;
                    sena.idTablaDestino = 2;
                    SeniasBI = new SeniasParticularesList();
                    SeniasBI.Add(sena);
                    Session["SeniasBI"] = SeniasBI;
                    gvSenasPart.DataSource = SeniasBI;
                    gvSenasPart.DataBind();
                    break;
                case "B":
                    break;
            }
        }

        protected void btnGuardarD_Click(object sender, EventArgs e)
        {

         //   this.btnGuardarD.Style.Add("display", "none");
            this.lblGuardoExitoD.Visible = false;
            this.btnGuardarBusquedaBI.Style.Remove("display");
            //this.mevtxtCoincidencia.Enabled = true;
            ValidarD();
            if (this.IsValid)
            {
                //if (state == FuncionesGrales.EstadoPrograma.Creando)//estoy creando una persona desaparecida
                LimpiarControlesBI();
                if (idPersonaDesaparecida > 0)
                    LlenarControlesBI(BusquedaManager.GetItem(Convert.ToInt32(this.btnVerCriterioBusquedaD.CommandArgument), true));
                else
                {
                    this.txtApellidoBI.Text = this.txtApellidoD.Text;
                    this.txtNombresBI.Text = this.txtNombresD.Text;
                    this.txtDNIBI.Text = this.txtDNI.Text;

                }
                //this.hfBusquedaIndividual.Value = TipoBusqueda.PersonaDesaparecida.ToString();
                LlenarControlesPersonaDesaparecidaEnBI();
              //  this.btnGuardarBusquedaBI.Style.Remove("display");
                this.btnCerrarBI.CommandArgument = "2";
                this.hfAbrirBusquedaIndividual_ModalPopupExtender.Show();
            }

            //this.mevtxtCoincidencia.Enabled = false;
            //this.btnGuardarD.Style.Remove("display");
        }

        protected void btnGuardarBusquedaBI_Click(object sender, EventArgs e)
        {
            ValidarBI();
            if (this.IsValid)
            {


                //GestionBusquedaIndividual((TipoBusqueda)Enum.Parse(typeof(TipoBusqueda), this.hfBusquedaIndividual.Value, true), state);

                GestionBusquedaIndividual(FuncionesGrales.TipoBusqueda.PersonaDesaparecida, state);


                if (state == FuncionesGrales.EstadoPrograma.Creando)
                {
                    this.btnGuardarD.Style.Add("display", "none");
                    this.fuFotoUploaderD.Enabled = false;
                    this.pnlPersonadesaparecida.Enabled = false;
                }
                //FuncionesGrales.FotosGralesD.DataSource = FotosManager.GetList(idPersonaDesaparecida, (int)FuncionesGrales.TipoBusqueda.PersonaDesaparecida).FindAll(delegate(Fotos f) { return f.idTipoFoto == (int)FuncionesGrales.TipoFoto.General; });
                //FuncionesGrales.FotosSeniasD.DataSource = FotosManager.GetList(idPersonaDesaparecida, (int)FuncionesGrales.TipoBusqueda.PersonaDesaparecida).FindAll(delegate(Fotos f) { return f.idTipoFoto == (int)FuncionesGrales.TipoFoto.SeniasParticulares; });

                if (this.imgFotoGeneralD.ImageUrl.ToUpper().StartsWith("IMAGEHANDLER1"))
                {
                    string url = this.imgFotoGeneralD.ImageUrl;
                    //string foto = url.Substring(url.LastIndexOf("/") + 1);
                    //url = FuncionesGrales.RutaFotosGeneralesD + "/" + foto;
                    //this.imgFotoGeneralD.ImageUrl = url;
                    this.imgFotoGeneralD.OnClientClick = "window.open('FullSizeImage.aspx?url=" + url + "')";
                }
                else
                {
                    this.imgFotoGeneralD.ImageUrl = "~/App_Images/SinFoto.GIF";
                    this.imgFotoGeneralD.Width = 80;
                    this.imgFotoGeneralD.Height = 100;
                    this.imgFotoGeneralD.OnClientClick = null;
                }
                if (this.imgFotoSeniasD.ImageUrl.ToUpper().StartsWith("IMAGEHANDLER1"))
                {
                    string url = this.imgFotoSeniasD.ImageUrl;
                    //string foto = url.Substring(url.LastIndexOf("/") + 1);
                    //url = FuncionesGrales.RutaFotosSeniasD + "/" + foto;
                    //this.imgFotoSeniasD.ImageUrl = url;
                    this.imgFotoSeniasD.OnClientClick = "window.open('FullSizeImage.aspx?url=" + url + "')";
                }
                else
                {
                    this.imgFotoSeniasD.ImageUrl = "~/App_Images/SinFoto.GIF";
                    this.imgFotoSeniasD.Width = 80;
                    this.imgFotoSeniasD.Height = 100;
                    this.imgFotoSeniasD.OnClientClick = null;
                }
            }
            else
                this.hfAbrirBusquedaIndividual_ModalPopupExtender.Show();

            btnGuardarBusquedaBI.Enabled=true;
            btnGuardarBusquedaBI.Text = "Guardar Búsqueda";

        }

        protected void btnCerrarBI_Click(object sender, EventArgs e)
        {

            this.hfAbrirBusquedaIndividual_ModalPopupExtender.Hide();
        }

        protected void btnTraerLugar_Click(object sender, EventArgs e)
        {
            LocalidadList localidades = MPBA.SIAC.Bll.LocalidadManager.GetList(this.txtLugar.Text);

            if (localidades.Count > 500) //demasiados registros
            {
                this.lblDemasiadosResultados.Visible = true;
                this.lblDemasiadosResultados.Text = "Demasiados resultados, acote el criterio.";
                return;
            }
            if (localidades.Count == 0)
            {
                this.lblDemasiadosResultados.Visible = true;
                this.lblDemasiadosResultados.Text = "No se encontraron resultados";
                return;
            }
            this.lblDemasiadosResultados.Visible = false;
            this.gvLugar.DataSource = localidades;
            this.gvLugar.DataBind();
        }

        protected void btnCancelarLugar_Click(object sender, EventArgs e)
        {
            this.pnlLugar.Style.Add("display", "none");
        }

        protected void gvLugar_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.hfLugarElegido.Value)
            {

                case "D":
                    this.hfLugarDId.Value = this.gvLugar.SelectedValue.ToString();
                    this.lblLugarDesapPersona.Text = this.gvLugar.SelectedRow.Cells[2].Text.Trim();
                    this.lblPartidoDesaparicion.Text = ((Label)this.gvLugar.SelectedRow.Cells[3].FindControl("lblPartidoGrid")).Text.Trim();
                    this.lblProvinciaDesapD.Text = ((Label)this.gvLugar.SelectedRow.Cells[4].FindControl("lblProvinciaGrid")).Text.Trim();
                    break;
            }
            this.pnlLugar.Style.Add("display", "none");
            this.hfAbrirLugar_ModalPopupExtender.Hide();
        }

        #endregion

        #region "METODOS":
        /// <summary>
        /// /// Limpia los controles de la Busqueda Individual
        /// </summary>
        private void LimpiarControlesBI()
        {
            this.txtCoincidenciaBI.Text = "";
            this.txtEdadDesdeBI.Text = "";
            this.txtEdadHastaBI.Text = "";
            this.txtFechaDesdeBI.Text = "";
            this.txtFechaHastaBI.Text = "";
            this.txtPesoDesdeBI.Text = "";
            this.txtPesoHastaBI.Text = "";
            this.txtTallaDesdeBI.Text = "";
            this.txtTallaHastaBI.Text = "";
            this.txtDNIBI.Text = "";
            this.txtApellidoBI.Text = "";
            this.txtNombresBI.Text = "";
            //elimino 'indeterminado' y 'seleccionar' de la lista de opciones
            //**********
            
            this.lstAspectoCabelloBI.DataSourceID = "";
            this.lstAspectoCabelloBI.DataSource = PBClaseAspectoCabelloManager.GetList().FindAll(delegate(PBClaseAspectoCabello ac) { return ac.Id != 0 && ac.Id!=1; });
            this.lstCalvicieBI.DataSourceID = "";
            this.lstCalvicieBI.DataSource = PBClaseCalvicieManager.GetList().FindAll(delegate(PBClaseCalvicie c) { return c.Id != 0 && c.Id != 1; });
            this.lstColorCabelloBI.DataSourceID = "";
            this.lstColorCabelloBI.DataSource = PBClaseColorCabelloManager.GetList().FindAll(delegate(PBClaseColorCabello cc) { return cc.Id != 0 && cc.Id != 1; });
            this.lstColorOjosBI.DataSourceID = "";
            this.lstColorOjosBI.DataSource = PBClaseColorOjosManager.GetList().FindAll(delegate(PBClaseColorOjos co) { return co.Id != 0 && co.Id != 1; });
            this.lstColorPielBI.DataSourceID = "";
            this.lstColorPielBI.DataSource = PBClaseColorDePielManager.GetList().FindAll(delegate(PBClaseColorDePiel cp) { return cp.Id != 0 && cp.Id != 1; });
            this.lstColorTenidoBI.DataSourceID = "";
            this.lstColorTenidoBI.DataSource = PBClaseColorCabelloManager.GetList().FindAll(delegate(PBClaseColorCabello ct) { return ct.Id != 0 && ct.Id != 1; });
            this.lstLongitudCabelloBI.DataSourceID = "";
            this.lstLongitudCabelloBI.DataSource = PBClaseLongitudCabelloManager.GetList().FindAll(delegate(PBClaseLongitudCabello lc) { return lc.Id != 0 && lc.Id != 1; });
            this.ddlSexoBI.DataSourceID = "";
            this.ddlSexoBI.DataSource = PBClaseSexoManager.GetList().FindAll(delegate(PBClaseSexo s) { return s.Id != 0; });
            this.ddlFaltanPiezasDentalesBI.DataSourceID = "";
            this.ddlFaltanPiezasDentalesBI.DataSource = PBClaseBooleanManager.GetList().FindAll(delegate(PBClaseBoolean fpd) { return fpd.Id != 0; });
            //***********
            //this.ddlFaltanPiezasDentalesBI.SelectedValue = "1";
            //this.ddlSexoBI.SelectedValue = "1";
            SeniasBI = null;
            SeniasBI = new SeniasParticularesList();
            this.gvSenasPartBI.DataSource = SeniasBI;
            this.gvSenasPartBI.DataBind();
            TatuajesBI = null;
            TatuajesBI = new TatuajesPersonaList();
            this.gvTatuajesBI.DataSource = TatuajesBI;
            this.gvTatuajesBI.DataBind();
            //listboxes
            foreach (ListItem item in this.lstAspectoCabelloBI.Items)
            {
                item.Selected = false;
            }
            foreach (ListItem item in this.lstCalvicieBI.Items)
            {
                item.Selected = false;
            }
            foreach (ListItem item in this.lstColorCabelloBI.Items)
            {
                item.Selected = false;
            }
            foreach (ListItem item in this.lstColorOjosBI.Items)
            {
                item.Selected = false;
            }
            foreach (ListItem item in this.lstColorPielBI.Items)
            {
                item.Selected = false;
            }
            foreach (ListItem item in this.lstColorTenidoBI.Items)
            {
                item.Selected = false;
            }
            foreach (ListItem item in this.lstLongitudCabelloBI.Items)
            {
                item.Selected = false;
            }
            //foreach (ListItem item in this.lstRostroBI.Items)
            //{
            //    item.Selected = false;
            //}
            this.lblFechaBI.Text = "Fecha";
            this.lblValorFechaBI.Text = "";
            this.lblValorEdadBI.Text = "";
            this.lblApellidoPersonaBIValor.Text = "";
            this.lblNombrePersonaBIValor.Text = "";
            this.lblDNIPersonaBIValor.Text = "";
            this.lblValorEdadBI.Text = "";
            this.lblFaltanDientesPersonaBIValor.Text = "";
            this.lblAspectoCabelloPersonaBiValor.Text = "";
            this.lblCalviciePersonaBIValor.Text = "";
            this.lblColorCabelloPersonaBIValor.Text = "";
            this.lblColorOjosBIValor.Text = "";
            this.lblColorPielPersonaValorBI.Text = "";
            this.lblColorTeñidoPersonaBIValor.Text = "";
            this.lblLongCabelloPersonaBIValor.Text = "";
            this.lblSexoPersonaBIValor.Text = "";
            this.lblPesoPersonaBIValor.Text = "";
            this.lblSeniasBIValor.Text = "";
            this.lblTatuajesBIValor.Text = "";
            this.lblTallaPersonaBIValor.Text = "";
            this.ddlSexoBI.SelectedIndex = 0;
            this.ddlFaltanPiezasDentalesBI.SelectedIndex = 0;
        }

        private void LimpiarControlesVerCriterioBI()
        {
            this.txtVerCoincidenciaBI.Text = "";
            this.txtVerEdadDesdeBI.Text = "";
            this.txtVerEdadHastaBI.Text = "";
            this.txtVerFechaDesdeBI.Text = "";
            this.txtVerFechaHastaBI.Text = "";
            this.txtVerPesoDesdeBI.Text = "";
            this.txtVerPesoHastaBI.Text = "";
            this.txtVerTallaDesdeBI.Text = "";
            this.txtVerTallaHastaBI.Text = "";
            this.txtVerDNIBI.Text = "";
            this.txtVerApellidoBI.Text = "";
            this.txtVerNombresBI.Text = "";
            this.txtVerAspectoCabelloBI.Text = "";
            this.txtVerCalvicieBI.Text = "";
            this.txtVerColorCabelloBI.Text = "";
            this.txtVerColorOjosBI.Text = "";
            this.txtVerColorPielBI.Text = "";
            this.txtVerColorTenidoBI.Text = "";
            this.txtVerLongitudCabelloBI.Text = "";
            this.txtVerSexoBI.Text = "";
            this.txtVerFaltanPiezasDentalesBI.Text = "";
            this.txtVerFaltanPiezasDentalesBI.Text = "";
            this.txtVerSenasPartBI.Text = "";
            this.txtVerTatuajesBI.Text = "";
            this.lblVerFechaBI.Text = "Fecha";
            this.lblVerValorFechaBI.Text = "";
            this.lblVerValorEdadBI.Text = "";
            this.lblVerDNIPersonaBIValor.Text = "";
            this.lblVerApellidoPersonaBIValor.Text = "";
            this.lblVerNombrePersonaBIValor.Text = "";
            this.lblVerValorEdadBI.Text = "";
            this.lblVerFaltanDientesPersonaBIValor.Text = "";
            this.lblVerAspectoCabelloPersonaBiValor.Text = "";
            this.lblVerCalviciePersonaBIValor.Text = "";
            this.lblVerColorCabelloPersonaBIValor.Text = "";
            this.lblVerColorOjosBIValor.Text = "";
            this.lblVerColorPielPersonaValorBI.Text = "";
            this.lblVerColorTeñidoPersonaBIValor.Text = "";
            this.lblVerLongCabelloPersonaBIValor.Text = "";
            this.lblVerSexoPersonaBIValor.Text = "";
            this.lblVerPesoPersonaBIValor.Text = "";
            this.lblVerTallaPersonaBIValor.Text = "";
        }


        /// <summary>
        /// Llena los listboxes de la busqueda individual
        /// </summary>
        /// <param name="miBI">busqueda con datos para los listboxes</param>
        private void LlenarListBoxesBI(Busqueda miBI)
        {
            if (miBI.busquedaAspectoCabellos != null && miBI.busquedaAspectoCabellos.Count > 0)
            {
                foreach (BusquedaAspectoCabello ac in miBI.busquedaAspectoCabellos)
                {
                    foreach (ListItem item in this.lstAspectoCabelloBI.Items)
                    {
                        if (item.Value == ac.idAspectoCabello.ToString())
                        {
                            item.Selected = true;
                        }
                    }

                }

            }

            if (miBI.busquedaCalvicies != null && miBI.busquedaCalvicies.Count > 0)
            {
                foreach (BusquedaCalvicie c in miBI.busquedaCalvicies)
                {
                    foreach (ListItem item in this.lstCalvicieBI.Items)
                    {
                        if (item.Value == c.idClaseCalvicie.ToString())
                            item.Selected = true;
                    }

                }

            }
            if (miBI.busquedaColorCabellos != null && miBI.busquedaColorCabellos.Count > 0)
            {
                foreach (BusquedaColorCabello cc in miBI.busquedaColorCabellos)
                {
                    foreach (ListItem item in this.lstColorCabelloBI.Items)
                    {
                        if (item.Value == cc.idClaseColorCabello.ToString())
                            item.Selected = true;
                    }

                }

            }
            if (miBI.busquedaColorOjoss != null && miBI.busquedaColorOjoss.Count > 0)
            {
                foreach (BusquedaColorOjos co in miBI.busquedaColorOjoss)
                {
                    foreach (ListItem item in this.lstColorOjosBI.Items)
                    {
                        if (item.Value == co.idClaseColorOjos.ToString())
                            item.Selected = true;
                    }

                }

            }
            if (miBI.busquedaColorPiels != null && miBI.busquedaColorPiels.Count > 0)
            {
                foreach (BusquedaColorPiel cp in miBI.busquedaColorPiels)
                {
                    foreach (ListItem item in this.lstColorPielBI.Items)
                    {
                        if (item.Value == cp.idClaseColorPiel.ToString())
                            item.Selected = true;
                    }

                }

            }
            if (miBI.busquedaColorTenidos != null && miBI.busquedaColorTenidos.Count > 0)
            {
                foreach (BusquedaColorTenido ct in miBI.busquedaColorTenidos)
                {
                    foreach (ListItem item in this.lstColorTenidoBI.Items)
                    {
                        if (item.Value == ct.idClaseColorTenido.ToString())
                            item.Selected = true;
                    }

                }

            }
            //if (miBI.busquedaRostros != null && miBI.busquedaRostros.Count > 0)
            //{
            //    foreach (BusquedaRostro r in miBI.busquedaRostros)
            //    {
            //        foreach (ListItem item in this.lstRostroBI.Items)
            //        {
            //            if (item.Value == r.idClaseRostro.ToString())
            //                item.Selected = true;
            //        }

            //    }

            //}
            if (miBI.busquedaLongitudCabellos != null && miBI.busquedaLongitudCabellos.Count > 0)
            {
                foreach (BusquedaLongitudCabello lc in miBI.busquedaLongitudCabellos)
                {
                    foreach (ListItem item in this.lstLongitudCabelloBI.Items)
                    {
                        if (item.Value == lc.idClaseLongitudCabello.ToString())
                            item.Selected = true;
                    }

                }

            }
        }




        /// <summary>
        /// Llena los controles de la busqueda individual
        /// </summary>
        /// <param name="miBI">parametros de la busqueda</param>
        private void LlenarControlesBI(Busqueda miBI)
        {
            //if (miBI.tieneADN != null)
            //    this.ddlAdnBI.SelectedValue = miBI.tieneADN.ToString();
            if (miBI.CantidadCoincidencias != null)
                this.txtCoincidenciaBI.Text = miBI.CantidadCoincidencias.ToString();
            if (miBI.Apellido != null)
                this.txtApellidoBI.Text = miBI.Apellido.Trim();
            if (miBI.EdadDesde != null)
                this.txtEdadDesdeBI.Text = miBI.EdadDesde.ToString();
            if (miBI.EdadHasta != null)
                this.txtEdadHastaBI.Text = miBI.EdadHasta.ToString();
            if (miBI.FechaDesde != null)
                this.txtFechaDesdeBI.Text = miBI.FechaDesde.ToString();
            if (miBI.FechaHasta != null)
                this.txtFechaHastaBI.Text = miBI.FechaHasta.ToString();
            this.ddlSexoBI.SelectedValue = miBI.idsexo.ToString();
            if (miBI.DNI != null)
                this.txtDNIBI.Text = miBI.DNI.Trim();
            if (miBI.Nombre != null)
                this.txtNombresBI.Text = miBI.Nombre.Trim();
            if (miBI.PesoDesde != null)
                this.txtPesoDesdeBI.Text = miBI.PesoDesde.ToString();
            if (miBI.PesoHasta != null)
                this.txtPesoHastaBI.Text = miBI.PesoHasta.ToString();
            if (miBI.TallaDesde != null)
                this.txtTallaDesdeBI.Text = miBI.TallaDesde.ToString();
            if (miBI.TallaHasta != null)
                this.txtTallaHastaBI.Text = miBI.TallaHasta.ToString();
            this.ddlFaltanPiezasDentalesBI.SelectedValue = miBI.FaltanPiezasDentales.ToString();

            LlenarListBoxesBI(miBI);

            if (miBI.busquedaSeniasParticularess != null && miBI.busquedaSeniasParticularess.Count > 0)
            {
                SeniasParticularesList seniaList= new SeniasParticularesList();
                foreach (BusquedaSeniasParticulares bsp in miBI.busquedaSeniasParticularess)
                {
                    SeniasParticulares senia = new SeniasParticulares();
                    senia.idSeniaParticular = Convert.ToInt32(bsp.idClaseSeniaParticular);
                    senia.idUbicacionSeniaParticular = Convert.ToInt32(bsp.idUbicacionSeniaParticular);
                    senia.descripcion = Convert.ToString(bsp.descripcion);
                    seniaList.Add(senia);
                }
                SeniasBI = seniaList;
                Session["SeniasBI"] = SeniasBI;
                this.gvSenasPartBI.DataSource = SeniasBI;
                this.gvSenasPartBI.DataBind();
               

            }
            else
                if (state == FuncionesGrales.EstadoPrograma.Modificando)
                {
                    SeniasBI = new SeniasParticularesList();
                    this.gvSenasPartBI.DataSource = SeniasBI;
                    this.gvSenasPartBI.DataBind();
                }
            if (miBI.busquedaTatuajess != null && miBI.busquedaTatuajess.Count > 0)
            {
                TatuajesPersonaList tatuajesList = new TatuajesPersonaList();
                foreach (BusquedaTatuajes bt in miBI.busquedaTatuajess)
                {
                    TatuajesPersona tatuaje = new TatuajesPersona();
                    tatuaje.idTatuaje = Convert.ToInt32(bt.IdClaseTatuaje);
                    tatuaje.idUbicacionTatuaje = Convert.ToInt32(bt.IdUbicacionTatuaje);
                    tatuajesList.Add(tatuaje);
                }
                TatuajesBI = tatuajesList;
                Session["TatuajesBI"] = TatuajesBI;
                this.gvTatuajesBI.DataSource = TatuajesBI;
                this.gvTatuajesBI.DataBind();


            }
            else
            if (state == FuncionesGrales.EstadoPrograma.Modificando)
            {
                TatuajesBI = new TatuajesPersonaList();
                this.gvTatuajesBI.DataSource = TatuajesBI;
                this.gvTatuajesBI.DataBind();
            }


        }

        private void LlenarControlesVerCriterioBI(Busqueda miBI)
        {
            if (miBI.CantidadCoincidencias != null)
                this.txtVerCoincidenciaBI.Text = miBI.CantidadCoincidencias.ToString();
            if (miBI.Apellido != null)
                this.txtVerApellidoBI.Text = miBI.Apellido.Trim();
            if (miBI.EdadDesde != null)
                this.txtVerEdadDesdeBI.Text = miBI.EdadDesde.ToString();
            if (miBI.EdadHasta != null)
                this.txtVerEdadHastaBI.Text = miBI.EdadHasta.ToString();
            if (miBI.FechaDesde != null)
                this.txtVerFechaDesdeBI.Text = Convert.ToDateTime(miBI.FechaDesde).ToString("dd/MM/yyyy");
            if (miBI.FechaHasta != null)
                this.txtVerFechaHastaBI.Text = Convert.ToDateTime(miBI.FechaHasta).ToString("dd/MM/yyyy");
            this.txtVerSexoBI.Text = PBClaseSexoManager.GetItem(miBI.idsexo).Descripcion.Trim();
            if (miBI.DNI != null)
                this.txtVerDNIBI.Text = miBI.DNI.Trim();
            if (miBI.Nombre != null)
                this.txtVerNombresBI.Text = miBI.Nombre.Trim();
            if (miBI.PesoDesde != null)
                this.txtVerPesoDesdeBI.Text = miBI.PesoDesde.ToString();
            if (miBI.PesoHasta != null)
                this.txtVerPesoHastaBI.Text = miBI.PesoHasta.ToString();
            if (miBI.TallaDesde != null)
                this.txtVerTallaDesdeBI.Text = miBI.TallaDesde.ToString();
            if (miBI.TallaHasta != null)
                this.txtVerTallaHastaBI.Text = miBI.TallaHasta.ToString();
            this.txtVerFaltanPiezasDentalesBI.Text = PBClaseBooleanManager.GetItem(miBI.FaltanPiezasDentales).Descripcion.Trim();

            if (miBI.busquedaAspectoCabellos != null && miBI.busquedaAspectoCabellos.Count > 0)
            {
                foreach (BusquedaAspectoCabello ac in miBI.busquedaAspectoCabellos)
                {
                    this.txtVerAspectoCabelloBI.Text += PBClaseAspectoCabelloManager.GetItem(ac.idAspectoCabello).Descripcion.ToString() + "\n";
                }
            }

            if (miBI.busquedaCalvicies != null && miBI.busquedaCalvicies.Count > 0)
            {
                foreach (BusquedaCalvicie c in miBI.busquedaCalvicies)
                {
                    this.txtVerCalvicieBI.Text += PBClaseCalvicieManager.GetItem(c.idClaseCalvicie).Descripcion + "\n";

                }

            }
            if (miBI.busquedaColorCabellos != null && miBI.busquedaColorCabellos.Count > 0)
            {
                foreach (BusquedaColorCabello cc in miBI.busquedaColorCabellos)
                {
                    this.txtVerColorCabelloBI.Text += PBClaseColorCabelloManager.GetItem(cc.idClaseColorCabello).Descripcion + "\n";

                }

            }
            if (miBI.busquedaColorOjoss != null && miBI.busquedaColorOjoss.Count > 0)
            {
                foreach (BusquedaColorOjos co in miBI.busquedaColorOjoss)
                {
                    this.txtVerColorOjosBI.Text += PBClaseColorOjosManager.GetItem(co.idClaseColorOjos).Descripcion + "\n";

                }

            }
            if (miBI.busquedaColorPiels != null && miBI.busquedaColorPiels.Count > 0)
            {
                foreach (BusquedaColorPiel cp in miBI.busquedaColorPiels)
                {
                    this.txtVerColorPielBI.Text += PBClaseColorDePielManager.GetItem(cp.idClaseColorPiel).Descripcion + "\n";

                }

            }
            if (miBI.busquedaColorTenidos != null && miBI.busquedaColorTenidos.Count > 0)
            {
                foreach (BusquedaColorTenido ct in miBI.busquedaColorTenidos)
                {
                    this.txtVerColorTenidoBI.Text += PBClaseColorCabelloManager.GetItem(ct.idClaseColorTenido).Descripcion + "\n";

                }

            }

            if (miBI.busquedaLongitudCabellos != null && miBI.busquedaLongitudCabellos.Count > 0)
            {
                foreach (BusquedaLongitudCabello lc in miBI.busquedaLongitudCabellos)
                {
                    this.txtVerLongitudCabelloBI.Text += PBClaseLongitudCabelloManager.GetItem(lc.idClaseLongitudCabello).Descripcion + "\n";

                }

            }


            if (miBI.busquedaSeniasParticularess != null && miBI.busquedaSeniasParticularess.Count > 0)
            {
                SeniasParticulares senia;
                foreach (BusquedaSeniasParticulares sp in miBI.busquedaSeniasParticularess)
                {
                    senia  = new SeniasParticulares();
                    senia.idSeniaParticular = Convert.ToInt32(sp.idClaseSeniaParticular);
                    senia.idUbicacionSeniaParticular = Convert.ToInt32(sp.idUbicacionSeniaParticular);
                    senia.descripcion = Convert.ToString(sp.descripcion);
                    this.txtVerSenasPartBI.Text += ClaseSeniaParticularManager.GetItem(senia.idSeniaParticular).Descripcion.Trim() + " en " + ClaseUbicacionSeniaPartManager.GetItem(senia.idUbicacionSeniaParticular).Descripcion.Trim() + " , ";
                }
                if (this.txtVerSenasPartBI.Text.Length > 2)
                    this.txtVerSenasPartBI.Text = this.txtVerSenasPartBI.Text.Substring(0, this.txtVerSenasPartBI.Text.Length - 2);
            }
            if (miBI.busquedaTatuajess != null && miBI.busquedaTatuajess.Count > 0)
            {
                TatuajesPersona tatuaje;
                foreach (BusquedaTatuajes bt in miBI.busquedaTatuajess)
                {
                    tatuaje = new TatuajesPersona();
                    tatuaje.idTatuaje = Convert.ToInt32(bt.IdClaseTatuaje);
                    tatuaje.idUbicacionTatuaje = Convert.ToInt32(bt.IdUbicacionTatuaje);
                    this.txtVerTatuajesBI.Text += ClaseTatuajeManager.GetItem(tatuaje.idTatuaje).descripcion.Trim() + " en " + ClaseUbicacionSeniaPartManager.GetItem(tatuaje.idUbicacionTatuaje).Descripcion.Trim() + " , ";
                }
                if (this.txtVerTatuajesBI.Text.Length > 2)
                    this.txtVerTatuajesBI.Text = this.txtVerTatuajesBI.Text.Substring(0, this.txtVerTatuajesBI.Text.Length - 2);
            }
        }

        /// <summary>
        /// Guarda datos de la busqueda individual
        /// </summary>
        /// <param name="tipoBusqueda">tipo de busqueda de que se trata</param>
        /// <returns>busqueda con los datos guardados</returns>
        private Busqueda GuardarBusquedaIndividual(FuncionesGrales.TipoBusqueda tipoBusqueda, int id)
        {
            int entero = 0;
            float flotante;
            DateTime fecha;
            Busqueda BusquedaIndividual = new Busqueda();
            BusquedaIndividual.Id = id;
            BusquedaIndividual.TablaDestino = null;
            BusquedaIndividual.idOrigen = Convert.ToInt16(tipoBusqueda);
            //BusquedaIndividual.CodigoADN = this.txtAdnBI.Text.Trim();
            //BusquedaIndividual.tieneADN = Convert.ToInt32(this.ddlAdnBI.SelectedValue);
            if (Int32.TryParse(this.txtEdadDesdeBI.Text.Trim(), out entero))
                BusquedaIndividual.EdadDesde = entero;
            else
                BusquedaIndividual.EdadDesde = null;
            if (Int32.TryParse(this.txtEdadHastaBI.Text.Trim(), out entero))
                BusquedaIndividual.EdadHasta = entero;
            else
                BusquedaIndividual.EdadHasta = null;
            if (Int32.TryParse(this.txtCoincidenciaBI.Text.Trim(), out entero))
                BusquedaIndividual.CantidadCoincidencias = entero;
            else
                BusquedaIndividual.CantidadCoincidencias = null;
            BusquedaIndividual.FaltanPiezasDentales = Convert.ToInt32(this.ddlFaltanPiezasDentalesBI.SelectedValue);
            if (DateTime.TryParse(this.txtFechaDesdeBI.Text.Trim(), out fecha))
                BusquedaIndividual.FechaDesde = fecha;
            else
                BusquedaIndividual.FechaDesde = null;
            if (DateTime.TryParse(this.txtFechaHastaBI.Text.Trim(), out fecha))
                BusquedaIndividual.FechaHasta = fecha;
            else
                BusquedaIndividual.FechaHasta = null;
            BusquedaIndividual.idsexo = Convert.ToInt32(this.ddlSexoBI.SelectedValue);
            BusquedaIndividual.FaltanPiezasDentales = Convert.ToInt32(this.ddlFaltanPiezasDentalesBI.SelectedValue);
            //LISTBOXES
            foreach (ListItem item in this.lstAspectoCabelloBI.Items)
            {
                if (item.Selected)
                {
                    BusquedaAspectoCabello bac = new BusquedaAspectoCabello();
                    bac.id = -1;
                    bac.idAspectoCabello = Convert.ToInt32(item.Value);
                    bac.idBusqueda = -1;
                    BusquedaIndividual.busquedaAspectoCabellos.Add(bac);
                }
            }
            if (BusquedaIndividual.busquedaAspectoCabellos.Count == 0)
            {
                BusquedaAspectoCabello bac = new BusquedaAspectoCabello();
                bac.id = -1;
                bac.idAspectoCabello = 1;
                bac.idBusqueda = -1;
                BusquedaIndividual.busquedaAspectoCabellos.Add(bac);
            }



            foreach (SeniasParticulares sp in SeniasBI)
            {
                BusquedaSeniasParticulares bsp = new BusquedaSeniasParticulares();
                bsp.id = -1;
                bsp.idClaseSeniaParticular = sp.idSeniaParticular;
                bsp.idUbicacionSeniaParticular = sp.idUbicacionSeniaParticular;
                bsp.descripcion = sp.descripcion;
                bsp.idBusqueda = -1;
                BusquedaIndividual.busquedaSeniasParticularess.Add(bsp);
            }
            foreach (TatuajesPersona sp in TatuajesBI)
            {
                BusquedaTatuajes bt = new BusquedaTatuajes();
                bt.id = -1;
                bt.IdClaseTatuaje = sp.idTatuaje;
                bt.IdUbicacionTatuaje = sp.idUbicacionTatuaje;
                bt.idBusqueda = -1;
                BusquedaIndividual.busquedaTatuajess.Add(bt);
            }

            foreach (ListItem item in this.lstCalvicieBI.Items)
            {
                if (item.Selected)
                {
                    BusquedaCalvicie bc = new BusquedaCalvicie();
                    bc.id = -1;
                    bc.idClaseCalvicie = Convert.ToInt32(item.Value);
                    bc.idBusqueda = -1;
                    BusquedaIndividual.busquedaCalvicies.Add(bc);
                }
            }
            if (BusquedaIndividual.busquedaCalvicies.Count == 0)
            {//agrego indeterminado
                BusquedaCalvicie bc = new BusquedaCalvicie();
                bc.id = -1;
                bc.idClaseCalvicie = 1;
                bc.idBusqueda = -1;
                BusquedaIndividual.busquedaCalvicies.Add(bc);
            }

            foreach (ListItem item in this.lstColorCabelloBI.Items)
            {
                if (item.Selected)
                {
                    BusquedaColorCabello bcc = new BusquedaColorCabello();
                    bcc.id = -1;
                    bcc.idClaseColorCabello = Convert.ToInt32(item.Value);
                    bcc.idBusqueda = -1;
                    BusquedaIndividual.busquedaColorCabellos.Add(bcc);
                }
            }
            if (BusquedaIndividual.busquedaColorCabellos.Count == 0)
            {//agrego indeterminado
                BusquedaColorCabello bcc = new BusquedaColorCabello();
                bcc.id = -1;
                bcc.idClaseColorCabello = 1;
                bcc.idBusqueda = -1;
                BusquedaIndividual.busquedaColorCabellos.Add(bcc);
            }

            foreach (ListItem item in this.lstColorOjosBI.Items)
            {
                if (item.Selected)
                {
                    BusquedaColorOjos bco = new BusquedaColorOjos();
                    bco.id = -1;
                    bco.idClaseColorOjos = Convert.ToInt32(item.Value);
                    bco.idBusqueda = -1;
                    BusquedaIndividual.busquedaColorOjoss.Add(bco);
                }
            }
            if (BusquedaIndividual.busquedaColorOjoss.Count == 0)
            {//agrego indeterminado
                BusquedaColorOjos bco = new BusquedaColorOjos();
                bco.id = -1;
                bco.idClaseColorOjos = 1;
                bco.idBusqueda = -1;
                BusquedaIndividual.busquedaColorOjoss.Add(bco);
            }
            foreach (ListItem item in this.lstColorPielBI.Items)
            {
                if (item.Selected)
                {
                    BusquedaColorPiel bcp = new BusquedaColorPiel();
                    bcp.id = -1;
                    bcp.idClaseColorPiel = Convert.ToInt32(item.Value);
                    bcp.idBusqueda = -1;
                    BusquedaIndividual.busquedaColorPiels.Add(bcp);
                }
            }
            if (BusquedaIndividual.busquedaColorPiels.Count == 0)
            {//agrego indeterminado
                BusquedaColorPiel bcp = new BusquedaColorPiel();
                bcp.id = -1;
                bcp.idClaseColorPiel = 1;
                bcp.idBusqueda = -1;
                BusquedaIndividual.busquedaColorPiels.Add(bcp);
            }

            foreach (ListItem item in this.lstColorTenidoBI.Items)
            {
                if (item.Selected)
                {
                    BusquedaColorTenido bct = new BusquedaColorTenido();
                    bct.id = -1;
                    bct.idClaseColorTenido = Convert.ToInt32(item.Value);
                    bct.idBusqueda = -1;
                    BusquedaIndividual.busquedaColorTenidos.Add(bct);
                }
            }
            if (BusquedaIndividual.busquedaColorTenidos.Count == 0)
            {//agrego indeterminado
                BusquedaColorTenido bct = new BusquedaColorTenido();
                bct.id = -1;
                bct.idClaseColorTenido = 1;
                bct.idBusqueda = -1;
                BusquedaIndividual.busquedaColorTenidos.Add(bct);
            }

            foreach (ListItem item in this.lstLongitudCabelloBI.Items)
            {
                if (item.Selected)
                {
                    BusquedaLongitudCabello blc = new BusquedaLongitudCabello();
                    blc.id = -1;
                    blc.idClaseLongitudCabello = Convert.ToInt32(item.Value);
                    blc.idBusqueda = -1;
                    BusquedaIndividual.busquedaLongitudCabellos.Add(blc);
                }
            }
            if (BusquedaIndividual.busquedaLongitudCabellos.Count == 0)
            {//agrego indeterminado
                BusquedaLongitudCabello blc = new BusquedaLongitudCabello();
                blc.id = -1;
                blc.idClaseLongitudCabello = 1;
                blc.idBusqueda = -1;
                BusquedaIndividual.busquedaLongitudCabellos.Add(blc);
            }

            if (float.TryParse(this.txtPesoDesdeBI.Text.Trim(), out flotante))
                BusquedaIndividual.PesoDesde = flotante;
            else
                BusquedaIndividual.PesoDesde = null;
            if (float.TryParse(this.txtPesoHastaBI.Text.Trim(), out flotante))
                BusquedaIndividual.PesoHasta = flotante;
            else
                BusquedaIndividual.PesoHasta = null;
            if (float.TryParse(this.txtTallaDesdeBI.Text.Trim(), out flotante))
                BusquedaIndividual.TallaDesde = flotante;
            else
                BusquedaIndividual.TallaDesde = null;
            if (float.TryParse(this.txtTallaHastaBI.Text.Trim(), out flotante))
                BusquedaIndividual.TallaHasta = flotante;
            else
                BusquedaIndividual.TallaHasta = null;
            BusquedaIndividual.UFI = Session["miUfi"].ToString().Trim();
            //***************************
            //CONTROLAR
            BusquedaIndividual.Usuario = Session["miUsuario"].ToString();
            //***************************
            BusquedaIndividual.UsuarioUltimaModificacion = Session["miUsuario"].ToString();
            //BusquedaIndividual.FechaUltimaModificacion = DateTime.Now;
            BusquedaIndividual.FechaUltimaModificacion = null;
            BusquedaIndividual.FechaAlta = null;
            BusquedaIndividual.FechaUltimaCoincidencia = DateTime.Now;
            BusquedaIndividual.Apellido = this.txtApellidoBI.Text.Trim();
            BusquedaIndividual.Nombre = this.txtNombresBI.Text.Trim();
            BusquedaIndividual.DNI = this.txtDNIBI.Text.Trim();
            
            //*********************
            //REVISAR****************
            BusquedaIndividual.idMotivoHallazgo = 1;
            return BusquedaIndividual;
            //************************************
            //BusquedaManager.Save(BusquedaIndividual);
            //switch (tipoBusqueda)
            //{
            //    case TipoBusqueda.PersonaHallada:
            //        GuardarPersonasHalladas(BusquedaIndividual);
            //        break;
            //    case TipoBusqueda.PersonaDesaparecida:
            //        GuardarPersonasDesaparecidas(BusquedaIndividual);
            //        break;
            //}
        }


        /// <summary>
        /// Realiza la busqueda individual
        /// </summary>
        /// <param name="tipoBusqueda">tipo de busqueda a realizar</param>
        /// <param name="esNuevo">si es para una carga nueva o ya existente</param>
        private void GestionBusquedaIndividual(FuncionesGrales.TipoBusqueda tipoBusqueda, FuncionesGrales.EstadoPrograma estado)
        {
            Busqueda busqueda = new Busqueda();
            bool GuardoExito = false;
            switch (tipoBusqueda)
            {
                case FuncionesGrales.TipoBusqueda.PersonaDesaparecida:
                    if (estado == FuncionesGrales.EstadoPrograma.Creando)//creo la búsqueda
                        busqueda = GuardarBusquedaIndividual(FuncionesGrales.TipoBusqueda.PersonaDesaparecida, -1);
                    else
                    {
                        busqueda = BusquedaManager.GetItem(PersonasDesaparecidasManager.GetItem(Convert.ToInt32(this.btnVerResultadosD.CommandArgument)).idBusqueda, true);
                        //if (estado == FuncionesGrales.EstadoPrograma.Consultando)
                        //    busqueda.FechaUltimaModificacion = Convert.ToDateTime("30-01-2700");//guardo una fecha bien grande, asi me trae todas las coincidencias sin importar la fecha de modificacion
                        if (estado == FuncionesGrales.EstadoPrograma.Modificando) //modifico la búsuqeda
                            busqueda = GuardarBusquedaIndividual(FuncionesGrales.TipoBusqueda.PersonaDesaparecida, Convert.ToInt32(busqueda.Id));
                    }

                    if (busqueda != null && estado == FuncionesGrales.EstadoPrograma.Creando)
                        GuardoExito = GuardarPersonasDesaparecidas(busqueda, -1);
                    else if (busqueda != null && estado == FuncionesGrales.EstadoPrograma.Modificando)
                        GuardoExito = GuardarPersonasDesaparecidas(busqueda, idPersonaDesaparecida);
                    else if (busqueda != null && estado == FuncionesGrales.EstadoPrograma.Agregando)
                        GuardoExito = GuardarPersonasDesaparecidas(busqueda, -1);
                    PersonasHalladasList ph = new PersonasHalladasList();
                    if (GuardoExito)
                    {
                        string ipp = "";
                        List<PersonasDesaparecidas> myPersonas = null;
                        if (this.tcTipoJurisdiccion.ActiveTab == this.tpPJ)
                        {
                            ipp = this.txtIppBuscadoD.Text.Trim();
                            myPersonas = PersonasDesaparecidasManager.GetListByIPP(ipp).FindAll(delegate(PersonasDesaparecidas pd) {return pd.esExtJurisdiccion == null || pd.esExtJurisdiccion == false; });
                        }
                        else if (this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur)
                        {
                            ipp = this.txtCausa.Text.Trim();
                            myPersonas = PersonasDesaparecidasManager.GetListByIPP(ipp).FindAll(delegate(PersonasDesaparecidas pd) { return pd.esExtJurisdiccion != null && pd.esExtJurisdiccion == true; });
                        }
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Cambios guardados correctamente.');", true);
                        //this.lblGuardoExitoD.Visible = true;
                        //this.lblGuardoExitoD.Style.Remove("display");
                        Session["FotosGralesD"] = FotosGralesD;
                        Session["FotosSeniasD"] = FotosSeniasD;
                        Session["FotosGralesBI"] = FotosGralesBI;
                        Session["FotosSeniasBI"] = FotosSeniasBI;
                        
                        

                        //PersonasDesaparecidasManager.GetListByIPP(ipp).FindAll(delegate(PersonasDesaparecidas p) { return p.Baja == false; });
                        
                        if (myPersonas.Count > 0)
                        {
                            this.divPersonasD.Style.Remove("display");
                            this.gvPersonasD.DataSource = myPersonas;
                            this.gvPersonasD.DataBind();
                            //this.gvPersonasD.SelectedIndex = 0;
                        }

                        foreach (GridViewRow row in this.gvPersonasD.Rows)
                        {
                            if (this.gvPersonasD.DataKeys[row.RowIndex].Value.ToString() == idPersonaDesaparecida.ToString())
                                this.gvPersonasD.SelectedIndex = row.RowIndex;

                        }

                        SetearGvPersonas();
                        TraerMailsAsociados(idPersonaDesaparecida);
                        this.divAgregandoPersona.Style.Add("display", "none");
                        Session["idPersonaDesaparecida"] = idPersonaDesaparecida;
                    }
                    else
                    {
                        this.lblGuardoExitoD.Visible = false;
                        this.lblGuardoExitoD.Style.Add("display", "none");
                    }
                    busqueda.IPP = null;
                    ph = PersonasHalladasManager.GetList(busqueda);
                    int cantidadResultados = ph.Count;
                    int nroMaximoResultados = 50;
                    if (cantidadResultados > nroMaximoResultados)
                    {
                        string msg = "Demasiados resultados, se mostraran solo " + nroMaximoResultados.ToString() + ". Restrinja el numero minimo de coincidencias."; 
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('" + msg + "');", true);
                        
                        //this.lblMensajeCartelAlert.Text = "Demasiados resultados, se mostraran solo " + nroMaximoResultados.ToString() + ". Restrinja el numero minimo de coincidencias.";
                        //hfCartelAlert_ModalPopupExtender.Show();
                        //return;
                        ph.RemoveRange(nroMaximoResultados - 1, cantidadResultados - nroMaximoResultados);
                    }
                    if (ph.Count > 0)
                    {

                        this.gvResultadosHalladasBI.DataSource = ph;
                        this.gvResultadosHalladasBI.Columns[0].Visible = false;
                        this.gvResultadosHalladasBI.DataBind();
                        this.gvResultadosHalladasBI.Style.Remove("display");
                        //this.gvResultadosDesapBI.Style.Add("display", "none");
                        this.btnCancelarResultadosBI.CommandArgument = "H";
                        //RefrescarEstadoBusquedasActivas();
                        //BuscarCoincidenciasEnBusquedasActivas();
                        this.lblCantResultados.Text = " (" + ph.Count.ToString() + ") ";
                        this.hfAbrirResultadosBI_ModalPopupExtender1.Show();
                        this.hfAbrirBusquedaIndividual_ModalPopupExtender.Hide();
                    }
                    else
                    {
                        //ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "updatealert", @"<script language='javascript'>setTimeout(""alert('No se encontraron resultados.')"",1000); </script>");
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('No se hallaron resultados.');", true);
                        this.hfAbrirBusquedaIndividual_ModalPopupExtender.Hide();
                    }
                    //if (GuardoExito)
                    //{
                    //    this.cartelConsultandoH.InnerText = "MODIFICANDO PERSONA DESAPARECIDA";
                    //    state = FuncionesGrales.EstadoPrograma.Modificando;
                    //}
                    //this.btnGuardarD.Style.Add("display", "none");
                    this.btnVerResultadosD.Style.Remove("display");
                    this.btnVerCriterioBusquedaD.CommandArgument = busqueda.Id.ToString();
                    this.btnVerCriterioBusquedaD.Style.Remove("display");
                    //this.pnlPersonadesaparecida.Enabled = false;
                    break;

            }
        }




        /// <summary>
        /// Realiza la validacion de los controles de la carga de personas desaparecidas
        /// </summary>
        private void ValidarD()
        {
            int edadAnios = 0;
            // Requerimientos de datos minimos
            //DropDownLists
            this.cvSenaSinIncorporar.IsValid = ValidarSenas();
            this.cvTatuajeSinIncorporar.IsValid = ValidarTatuajes();
            if (this.ddlAspectoCabelloD.SelectedValue == "0")
                this.cvAspectoCabelloD.IsValid = false;
            if (this.ddlCalvicieD.SelectedValue == "0" || this.ddlCalvicieD.SelectedValue == "1")
                this.cvCalvicieD.IsValid = false;
            if (this.ddlColorCabelloD.SelectedValue == "0" || this.ddlColorCabelloD.SelectedValue == "1")
                this.cvColorCabelloD.IsValid = false;
            if (this.ddlColorOjosD.SelectedValue == "0" || this.ddlColorOjosD.SelectedValue == "1")
                this.cvColorOjosD.IsValid = false;
            if (this.ddlColorPielD.SelectedValue == "0" || this.ddlColorPielD.SelectedValue == "1")
                this.cvColorPielD.IsValid = false;
            if (this.ddlColorTenidoD.SelectedValue == "0")
                this.cvColorTenidoD.IsValid = false;
            if (this.ddlExistenRadiografiasD.SelectedValue == "0")
                this.cvExistenRadiografiasD.IsValid = false;
            if (this.ddlFaltanPiezasDentalesD.SelectedValue == "0")
                this.cvFaltanDientesD.IsValid = false;
            if (this.ddlFichasDactilaresD.SelectedValue == "0")
                this.cvFichasDactilaresD.IsValid = false;
            if (this.ddlFotoD.SelectedValue == "0")
                this.cvFotoD.IsValid = false;
            if (this.ddlLongitudCabelloD.SelectedValue == "0")
                this.cvLongitudCabelloD.IsValid = false;
            if (this.ddlOrgIntD.SelectedValue == "0")
                this.cvOrgIntD.IsValid = false;
            if (this.ddlRostroD.SelectedValue == "0")
                this.cvRostroD.IsValid = false;
            if (this.ddlSexoD.SelectedValue == "0" || this.ddlSexoD.SelectedValue == "1")
                this.cvSexoD.IsValid = false;
            if (this.ddlAdnD.SelectedValue == "0")
                this.cvTieneAdnD.IsValid = false;

            //IPP
            if (this.tcTipoJurisdiccion.ActiveTab == this.tpPJ)
            {
                if (this.txtIppBuscadoD.Text.Trim() == "")
                {
                    this.cvIppD.Text = "Debe ingresar la IPP";
                    this.cvIppD.IsValid = false;
                }
            }
            else if (this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur)
            {
                if (this.txtCausa.Text.Trim() == "")
                {
                    this.cvCausa.Text = "Debe ingresar el numero de causa";
                    this.cvCausa.IsValid = false;
                }
            }

            //fechas
            string fechaDesap = this.txtFechaDesapD.Text.Trim();
            string fechaNacD = this.txtFechaNacD.Text.Trim();
            if (fechaDesap != "")
            {
                if (this.mevFechaDesapD.IsValid == true)
                {
                    if (Convert.ToDateTime(fechaDesap) > DateTime.Today)
                    {
                        this.cvFechaDesapD.IsValid = false;
                    }
                }
            }
            else
            {
                this.cvFechaDesapD.ErrorMessage = "Ingrese al menos una Fecha aproximada";
                this.cvFechaDesapD.IsValid = false;
            }


            //edades
            string edadD = this.txtEdadD.Text.Trim();
            int edadDI = 0;
            if (fechaNacD != "")
            {
                if (this.mevFechaNacD.IsValid == true)
                {
                    if (Convert.ToDateTime(fechaNacD) > DateTime.Today)
                    {
                        this.cvFechaNacD.IsValid = false;
                        this.cvFechaNacD.ErrorMessage = "No puede ser mayor a la Actualidad";
                    }
                    else
                    {
                        edadAnios = DateTime.Today.Year - Convert.ToDateTime(fechaNacD).Year;
                    }
                    if ((fechaDesap != "") && Convert.ToDateTime(fechaNacD).CompareTo(Convert.ToDateTime(fechaDesap)) > 0 )
                    {
                        this.cvFechaNacD.IsValid = false;
                        this.cvFechaNacD.ErrorMessage = "La Fecha De Desaparición, debe ser mayor a la Fecha de Nac.";
                    }
                    
                }
                
            }
            

          
            if (edadD != "")
            {
                 edadDI = Convert.ToInt32(edadD);
                if (edadDI > 110)
                {
                    this.cvEdadD.IsValid = false;
                    this.cvEdadD.ErrorMessage = "La edad es erronea";
                 }
                  if (edadAnios > 0 && (!(edadAnios == edadDI+1 ) && !(edadAnios == edadDI) )) 
                  {
                      this.cvEdadD.IsValid = false;
                      this.cvEdadD.ErrorMessage = "La edad es erronea";
                  }

            }

            // Debe ingresar o bien La fecha de Nac o la edad
            if (fechaNacD == "" && edadD == "")
            {
                this.cvEdadD.IsValid = false;
                this.cvEdadD.ErrorMessage = "Ingreso Obligatorio o bien la Fecha de Nac.";
            }

            //pesos
            string pesoD = this.txtPesoD.Text.Trim();
            if (pesoD != "")
            {
                try
                {
                    if (Math.Round(Convert.ToDouble(pesoD)) / 100 > 500)
                    {
                        this.cvPesoD.IsValid = false;
                        this.cvPesoD.ErrorMessage = "Dato erróneo";
                    }
                }
                catch
                {
                    this.cvPesoD.IsValid = false;
                    this.cvPesoD.ErrorMessage = "Dato erróneo";
                }

            }
            else
            {
                this.cvPesoD.IsValid = false;
                this.cvPesoD.ErrorMessage = "Ingreso Obligatorio (aprox.)";
            }


            // Talla 
            if (this.txtTallaD.Text.Contains(',') || this.txtTallaD.Text.Contains('.'))
            {
                cvtalla.IsValid = false;
                cvtalla.ErrorMessage = "Ingrese la talla en centimetros, sin comas ni puntos";
            }
            else if (this.txtTallaD.Text == "" || Convert.ToDouble(txtTallaD.Text) > 250)
            {
                cvtalla.IsValid = false;
                cvtalla.ErrorMessage = this.txtTallaD.Text == "" ? "Ingreso Obligatorio" : "La talla supera los 2 metros y medio!";
            }
               
             
            // apellidos y nombres
             if (this.txtApellidoD.Text == "" )
             { 
                 this.cvApellido.IsValid = false;
             }
             if (this.txtNombresD.Text == "")
             {
                 this.cvNombres.IsValid = false;
             }


            //dias sin afeitar
            string diasSinAfeitarD = this.txtCantDiasSinAfeitarD.Text.Trim();
            if (diasSinAfeitarD != "")
            {
                if (Convert.ToInt32(diasSinAfeitarD) > 500)
                {
                    this.cvCantDiasSinAfeitarD.IsValid = false;
                }

            }

        }

        /// <summary>
        /// Llena los controles que muestran los valores de la persona Desaparecida en la view que permite cargar los parámetros de búsqueda
        /// </summary>
        /// <param name="PersonaDesaparecida">datos de la Persona Desaparecida</param>
        private void LlenarControlesPersonaDesaparecidaEnBI(/*PersonasDesaparecidas PersonaDesaparecida*/)
        {
            this.lblFechaBI.Text = "Fecha Desaparición";
            DateTime fecha;
            float flotante;
            if (DateTime.TryParse(this.txtFechaDesapD.Text.Trim(), out fecha))
                this.lblValorFechaBI.Text = fecha.ToShortDateString();
            else
                this.lblValorFechaBI.Text = "";
            this.lblApellidoPersonaBIValor.Text = this.txtApellidoD.Text.Trim();
            this.lblNombrePersonaBIValor.Text = this.txtNombresD.Text.Trim();
            this.lblDNIPersonaBIValor.Text = this.txtDNI.Text.Trim();
            this.lblValorEdadBI.Text = this.txtEdadD.Text.Trim();
            if (this.ddlFaltanPiezasDentalesD.SelectedValue != "")
                this.lblFaltanDientesPersonaBIValor.Text = PBClaseBooleanManager.GetItem(Convert.ToInt32(this.ddlFaltanPiezasDentalesD.SelectedValue)).Descripcion;
            if (DateTime.TryParse(this.txtFechaDesapD.Text.Trim(), out fecha))
                this.lblValorFechaBI.Text = fecha.ToShortDateString();
            if (this.ddlAspectoCabelloD.SelectedValue != "")
                this.lblAspectoCabelloPersonaBiValor.Text = PBClaseAspectoCabelloManager.GetItem(Convert.ToInt32(this.ddlAspectoCabelloD.SelectedValue)).Descripcion;
            if (this.ddlCalvicieD.SelectedValue != "")
                this.lblCalviciePersonaBIValor.Text = PBClaseCalvicieManager.GetItem(Convert.ToInt32(this.ddlCalvicieD.SelectedValue)).Descripcion;
            if (this.ddlColorCabelloD.SelectedValue != "")
                this.lblColorCabelloPersonaBIValor.Text = PBClaseColorCabelloManager.GetItem(Convert.ToInt32(this.ddlColorCabelloD.SelectedValue)).Descripcion;
            if (this.ddlColorOjosD.SelectedValue != "")
                this.lblColorOjosBIValor.Text = PBClaseColorOjosManager.GetItem(Convert.ToInt32(this.ddlColorOjosD.SelectedValue)).Descripcion;
            if (this.ddlColorPielD.SelectedValue != "")
                this.lblColorPielPersonaValorBI.Text = PBClaseColorDePielManager.GetItem(Convert.ToInt32(this.ddlColorPielD.SelectedValue)).Descripcion;
            if (this.ddlColorTenidoD.SelectedValue != "")
                this.lblColorTeñidoPersonaBIValor.Text = PBClaseColorCabelloManager.GetItem(Convert.ToInt32(this.ddlColorTenidoD.SelectedValue)).Descripcion;
            if (this.ddlLongitudCabelloD.SelectedValue != "")
                this.lblLongCabelloPersonaBIValor.Text = PBClaseLongitudCabelloManager.GetItem(Convert.ToInt32(this.ddlLongitudCabelloD.SelectedValue)).Descripcion;
            if (this.ddlSexoD.SelectedValue != "")
                this.lblSexoPersonaBIValor.Text = PBClaseSexoManager.GetItem(Convert.ToInt32(this.ddlSexoD.SelectedValue)).Descripcion;
            if (float.TryParse(this.txtPesoD.Text.Trim(), out flotante))
                this.lblPesoPersonaBIValor.Text = flotante.ToString();
            if (float.TryParse(this.txtTallaD.Text.Trim(), out flotante))
                this.lblTallaPersonaBIValor.Text = flotante.ToString();
            //SeniasParticularesList SeniasD = (SeniasParticularesList)Session["SeniasD"];
            if (SeniasD.Count != 0)
            {
                foreach (SeniasParticulares sp in SeniasD)
                {
                    this.lblSeniasBIValor.Text += ClaseSeniaParticularManager.GetItem(sp.idSeniaParticular).Descripcion + " en " + ClaseUbicacionSeniaPartManager.GetItem(sp.idUbicacionSeniaParticular).Descripcion + ", ";
                }
                this.lblSeniasBIValor.Text = this.lblSeniasBIValor.Text.Substring(0, this.lblSeniasBIValor.Text.Length - 2);
            }
            else
            {
                this.lblSeniasBIValor.Text = "";
            }
           // TatuajesPersonaList TatuajesD = (TatuajesPersonaList)Session["TatuajesD"];
            if (TatuajesD.Count != 0)
            {
                foreach (TatuajesPersona tp in TatuajesD)
                {
                    this.lblTatuajesBIValor.Text += ClaseTatuajeManager.GetItem(tp.idTatuaje).descripcion + " en " + ClaseUbicacionSeniaPartManager.GetItem(tp.idUbicacionTatuaje).Descripcion + ", ";
                }
                this.lblTatuajesBIValor.Text = this.lblTatuajesBIValor.Text.Substring(0, this.lblTatuajesBIValor.Text.Length - 2);
            }
            else
            {
                this.lblTatuajesBIValor.Text = "";
            }
        }


        private void LlenarControlesVerPersonaDesaparecidaEnCriterioBI()
        {
            this.lblVerFechaBI.Text = "Fecha Desaparición";
            DateTime fecha;
            float flotante;
            if (DateTime.TryParse(this.txtFechaDesapD.Text.Trim(), out fecha))
                this.lblVerValorFechaBI.Text = fecha.ToShortDateString();
            else
                this.lblVerValorFechaBI.Text = "";
            this.lblVerDNIPersonaBIValor.Text = this.txtDNI.Text.Trim();
            this.lblVerApellidoPersonaBIValor.Text = this.txtApellidoD.Text.Trim();
            this.lblVerNombrePersonaBIValor.Text = this.txtNombresD.Text.Trim();
            this.lblVerValorEdadBI.Text = this.txtEdadD.Text.Trim();
            if (this.ddlFaltanPiezasDentalesD.SelectedValue != "")
                this.lblVerFaltanDientesPersonaBIValor.Text = PBClaseBooleanManager.GetItem(Convert.ToInt32(this.ddlFaltanPiezasDentalesD.SelectedValue)).Descripcion;
            if (DateTime.TryParse(this.txtFechaDesapD.Text.Trim(), out fecha))
                this.lblVerValorFechaBI.Text = fecha.ToShortDateString();
            if (this.ddlAspectoCabelloD.SelectedValue != "")
                this.lblVerAspectoCabelloPersonaBiValor.Text = PBClaseAspectoCabelloManager.GetItem(Convert.ToInt32(this.ddlAspectoCabelloD.SelectedValue)).Descripcion;
            if (this.ddlCalvicieD.SelectedValue != "")
                this.lblVerCalviciePersonaBIValor.Text = PBClaseCalvicieManager.GetItem(Convert.ToInt32(this.ddlCalvicieD.SelectedValue)).Descripcion;
            if (this.ddlColorCabelloD.SelectedValue != "")
                this.lblVerColorCabelloPersonaBIValor.Text = PBClaseColorCabelloManager.GetItem(Convert.ToInt32(this.ddlColorCabelloD.SelectedValue)).Descripcion;
            if (this.ddlColorOjosD.SelectedValue != "")
                this.lblVerColorOjosBIValor.Text = PBClaseColorOjosManager.GetItem(Convert.ToInt32(this.ddlColorOjosD.SelectedValue)).Descripcion;
            if (this.ddlColorPielD.SelectedValue != "")
                this.lblVerColorPielPersonaValorBI.Text = PBClaseColorDePielManager.GetItem(Convert.ToInt32(this.ddlColorPielD.SelectedValue)).Descripcion;
            if (this.ddlColorTenidoD.SelectedValue != "")
                this.lblVerColorTeñidoPersonaBIValor.Text = PBClaseColorCabelloManager.GetItem(Convert.ToInt32(this.ddlColorTenidoD.SelectedValue)).Descripcion;
            if (this.ddlLongitudCabelloD.SelectedValue != "")
                this.lblVerLongCabelloPersonaBIValor.Text = PBClaseLongitudCabelloManager.GetItem(Convert.ToInt32(this.ddlLongitudCabelloD.SelectedValue)).Descripcion;
            if (this.ddlSexoD.SelectedValue != "")
                this.lblVerSexoPersonaBIValor.Text = PBClaseSexoManager.GetItem(Convert.ToInt32(this.ddlSexoD.SelectedValue)).Descripcion;
            if (float.TryParse(this.txtPesoD.Text.Trim(), out flotante))
                this.lblVerPesoPersonaBIValor.Text = flotante.ToString();
            if (float.TryParse(this.txtTallaD.Text.Trim(), out flotante))
                this.lblVerTallaPersonaBIValor.Text = flotante.ToString();
        }



      
        /// <summary>
        /// Llena los controles de la persona desaparecida
        /// </summary>
        /// <param name="personaDesaparecida"></param>
        private void LlenarControlesD(MPBA.PersonasBuscadas.BusinessEntities.PersonasDesaparecidas personaDesaparecida)
        {
            
            //this.lblIppD.Text = "IPP: " + this.txtIppBuscadoD.Text.Trim();
            if (personaDesaparecida.tieneADN != null)
                this.ddlAdnD.SelectedValue = personaDesaparecida.tieneADN.ToString();
            //if (personaDesaparecida.Ipp != null)
            //    this.lblIppD.Text = personaDesaparecida.Ipp.Trim();
            if (personaDesaparecida.Apellido != null)
                this.txtApellidoD.Text = personaDesaparecida.Apellido.Trim();
            if (personaDesaparecida.Nombre != null)
                this.txtNombresD.Text = personaDesaparecida.Nombre.Trim();
            if (personaDesaparecida.DNI != null)
                this.txtDNI.Text = personaDesaparecida.DNI.Trim();
            this.ddlTipoDoc.SelectedValue = personaDesaparecida.idTipoDNI.ToString();
            if (personaDesaparecida.ArticulosPersonales != null)
                this.txtArticulosPersonalesD.Text = personaDesaparecida.ArticulosPersonales.Trim();
            if (personaDesaparecida.CantidadDiasNoAfeitado != null)
                this.txtCantDiasSinAfeitarD.Text = personaDesaparecida.CantidadDiasNoAfeitado.ToString().Trim();
            if (personaDesaparecida.EdadMomentoDesaparicion != null)
                this.txtEdadD.Text = personaDesaparecida.EdadMomentoDesaparicion.ToString().Trim();
            if (personaDesaparecida.FechaDesaparicion != null)
                this.txtFechaDesapD.Text = personaDesaparecida.FechaDesaparicion.ToString().Trim();
            if (personaDesaparecida.FechaNacimiento != null)
                this.txtFechaNacD.Text = personaDesaparecida.FechaNacimiento.ToString().Trim();
            //if (personaDesaparecida.Ipp != null)
            //    this.txtIppBuscadoD.Text = personaDesaparecida.Ipp.Trim();
            if (personaDesaparecida.Peso != null)
                this.txtPesoD.Text = personaDesaparecida.Peso.ToString();
            if (personaDesaparecida.Ropa != null)
                this.txtRopaD.Text = personaDesaparecida.Ropa.Trim();
            if (personaDesaparecida.Talla != null)
                this.txtTallaD.Text = personaDesaparecida.Talla.ToString().Trim();
            this.ddlAspectoCabelloD.SelectedValue = personaDesaparecida.idAspectoCabello.ToString();
            this.ddlCalvicieD.SelectedValue = personaDesaparecida.idCalvicie.ToString();
            this.ddlColorCabelloD.SelectedValue = personaDesaparecida.idColorCabello.ToString();
            this.ddlColorOjosD.SelectedValue = personaDesaparecida.idColorOjos.ToString();
            this.ddlColorPielD.SelectedValue = personaDesaparecida.idColorPiel.ToString();
            this.ddlColorTenidoD.SelectedValue = personaDesaparecida.idColorTenido.ToString();
            if (this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur && personaDesaparecida.PBCausaExtranaJurisdiccion != null)
            {
                PBCausaExtranaJurisdiccion extJur = personaDesaparecida.PBCausaExtranaJurisdiccion;
                this.txtOrgReqExtJur.Text = extJur.OrganoRequirente == null ? "" : extJur.OrganoRequirente.Trim();
                this.txtTelefonoExtJur.Text = extJur.telefono == null ? "" : extJur.telefono.Trim();
                this.txtMailExtJur.Text = extJur.mail == null ? "" : extJur.mail.Trim();
                this.txtCaratulaExtJur.Text = extJur.caratula == null ? "" : extJur.caratula.Trim();
                this.ddlProvinciaExtJur.SelectedValue = extJur.Provincia == null ? "0" : extJur.Provincia.Trim();
                this.txtJurisdiccionExtJur.Text = extJur.Jurisdiccion == null ? "" : extJur.Jurisdiccion.Trim();
                this.pnlExtranaJurisdiccion.Visible = true;
            }
            if (personaDesaparecida.idLugarDesaparicion > 0)
            {
                this.lblLugarDesapPersona.Text = MPBA.SIAC.Bll.LocalidadManager.GetItem(personaDesaparecida.idLugarDesaparicion).localidad.Trim();
                this.lblPartidoDesaparicion.Text = MPBA.SIAC.Bll.PartidoManager.GetItem((MPBA.SIAC.Bll.LocalidadManager.GetItem(personaDesaparecida.idLugarDesaparicion).Partido)).partido.Trim();
                this.lblProvinciaDesapD.Text = MPBA.SIAC.Bll.ProvinciaManager.GetItem((MPBA.SIAC.Bll.LocalidadManager.GetItem(personaDesaparecida.idLugarDesaparicion).Provincia)).provincia.Trim();
                this.hfLugarDId.Value = personaDesaparecida.idLugarDesaparicion.ToString();
            }
            if (personaDesaparecida.idComisaria >= 0)
            {
                this.lblComisariaPersonaD.Text = MPBA.SIAC.Bll.ComisariaManager.GetItem(personaDesaparecida.idComisaria).comisaria.Trim();
                //this.lblDepartamentoComisariaD.Text = DepartamentoManager.GetItem(ComisariaManager.GetItem(personaDesaparecida.idComisaria).idDepartamento).departamento.Trim();
                this.hfComisariaDId.Value = personaDesaparecida.idComisaria.ToString();
            }
            //this.ddlDentaduraD.SelectedValue = personaDesaparecida.idDentadura.ToString();
            this.ddlExistenRadiografiasD.SelectedValue = personaDesaparecida.ExistenRadiografia.ToString();
            this.ddlFaltanPiezasDentalesD.SelectedValue = personaDesaparecida.FaltanPiezasDentales.ToString();
            this.ddlFichasDactilaresD.SelectedValue = personaDesaparecida.FichasDactilares.ToString();
            this.ddlFotoD.SelectedValue = personaDesaparecida.Foto.ToString();
            this.ddlLongitudCabelloD.SelectedValue = personaDesaparecida.idLongitudCabello.ToString();
            this.ddlOrgIntD.SelectedValue = personaDesaparecida.idOrganismoInterviniente.ToString();
            this.ddlRostroD.SelectedValue = personaDesaparecida.idRostro.ToString();
            //this.ddlSeniasParticularesD.SelectedValue = personaDesaparecida.idSeniaParticular.ToString();
            this.ddlSexoD.SelectedValue = personaDesaparecida.idSexo.ToString();
            //Senas Particulares
            Session["SeniasD"] = personaDesaparecida.seniasParticularess;
            this.gvSenasPartD.DataSource = personaDesaparecida.seniasParticularess;
            this.gvSenasPartD.DataBind();
            //Tatuajes
            Session["TatuajesD"] = personaDesaparecida.tatuajesPersonas;
            this.gvTatuajesD.DataSource = personaDesaparecida.tatuajesPersonas;
            this.gvTatuajesD.DataBind();
            ///
            idPersonaDesaparecida = personaDesaparecida.Id;
            switch (state)
            {
                case FuncionesGrales.EstadoPrograma.Creando:
                    break;
                case FuncionesGrales.EstadoPrograma.Modificando:
                    this.cartelConsultandoD.InnerText = "Modificando Persona Desaparecida";
                    this.cartelConsultandoD.Style.Remove("display");
                    this.cartelConsultandoD.Style.Remove("color");
                    break;
                case FuncionesGrales.EstadoPrograma.Consultando:
                    this.cartelConsultandoD.InnerText = "Consultando Persona Desaparecida";
                    this.cartelConsultandoD.Style.Remove("display");
                    this.cartelConsultandoD.Style.Remove("color");
                    //this.btnBorrarH.Style.Remove("display");
                    this.btnGuardarD.Style.Add("display", "none");
                    this.btnVerCriterioBusquedaD.Style.Remove("display");
                    this.btnVerResultadosD.Style.Remove("display");
                    break;
            }


            FotosGralesD.DataSource = PBFotosManager.GetList(idPersonaDesaparecida, (int)FuncionesGrales.TipoBusqueda.PersonaDesaparecida).FindAll(delegate(PBFotos f) { return f.idTipoFoto == (int)FuncionesGrales.TipoFoto.General; });
            FotosSeniasD.DataSource = PBFotosManager.GetList(idPersonaDesaparecida, (int)FuncionesGrales.TipoBusqueda.PersonaDesaparecida).FindAll(delegate(PBFotos f) { return f.idTipoFoto == (int)FuncionesGrales.TipoFoto.SeniasParticulares; });
            if (FotosGralesD.Count > 0)
            {
                FotosGralesD.MoveFirst();
                PBFotos f = (PBFotos)FotosGralesD.Current;

                LlenarImgBox(f, FuncionesGrales.TipoBusqueda.PersonaDesaparecida, FuncionesGrales.TipoFoto.General);
                this.lblNroFotoGralD.Text = (FotosGralesD.Position + 1).ToString() + "/" + FotosGralesD.Count.ToString();
                this.lblNroFotoSeniasD.Text = (FotosSeniasD.Position + 1).ToString() + "/" + FotosSeniasD.Count.ToString();
            }
            if (FotosSeniasD.Count > 0)
            {
                FotosSeniasD.MoveFirst();
                PBFotos f = (PBFotos)FotosSeniasD.Current;
                LlenarImgBox(f, FuncionesGrales.TipoBusqueda.PersonaDesaparecida, FuncionesGrales.TipoFoto.SeniasParticulares);
                this.lblNroFotoGralD.Text = (FotosGralesD.Position + 1).ToString() + "/" + FotosGralesD.Count.ToString();
                this.lblNroFotoSeniasD.Text = (FotosSeniasD.Position + 1).ToString() + "/" + FotosSeniasD.Count.ToString();
            }
            this.pnlPersonadesaparecida.Enabled = true;
        }

        /// <summary>
        /// Llena el imagebox con el nro de foto indicada
        /// </summary>
        /// <param name="tipoBusqueda">si es para persona hallada o desap</param>
        /// <param name="foto"la foto a poner en el ImageBox</param>
        private void LlenarImgBox(PBFotos fotoAMostrar, FuncionesGrales.TipoBusqueda tipoBusqueda, FuncionesGrales.TipoFoto tipoFoto)
        {
            int cantFotos = 0;
            int nroFotoActual = 0;
            switch (tipoFoto)
            {
                case FuncionesGrales.TipoFoto.General:
                    cantFotos = FotosGralesD.Count;
                    nroFotoActual = FotosGralesD.Position + 1;
                    this.btnBorrarFotoGralD.Enabled = cantFotos > 0;
                    break;
                case FuncionesGrales.TipoFoto.SeniasParticulares:
                    cantFotos = FotosSeniasD.Count;
                    nroFotoActual = FotosSeniasD.Position + 1;
                    this.btnBorrarFotoSeniasD.Enabled = cantFotos > 0;
                    break;
            }
            if (cantFotos == 0)
                return;
            System.Drawing.Image imgPhoto = null;
            if (Session["imgPreview"] != null)
            {
                Byte[] input = (Byte[])Session["imgPreview"];
                using (MemoryStream ms = new MemoryStream(input))
                {
                    imgPhoto = System.Drawing.Image.FromStream(ms);
                    ms.Close();
                }
            }
            else
            {
                Byte[] input = fotoAMostrar.Foto;
                using (MemoryStream ms = new MemoryStream(input))
                {
                    imgPhoto = System.Drawing.Image.FromStream(ms);
                    ms.Close();
                }

            }
            int[] dim = DimensionarImgBox(imgPhoto, 100, 100);
            imgPhoto.Dispose();
            if (dim != null)
            {
                string url = "";
                switch (tipoFoto)
                {
                    case FuncionesGrales.TipoFoto.General:

                        Session["FotosGralesD"] = FotosGralesD;
                        url = "ImageHandler1.ashx?t=" + ((int)tipoFoto).ToString() + "&r=" + new Random().Next().ToString() + "&bi=f&p=d";
                        this.imgFotoGeneralD.ImageUrl = url;
                        this.upImage.Update();
                        this.imgFotoGeneralD.OnClientClick = "window.open('FullSizeImage.aspx?url=" + url + "')";
                        this.imgFotoGeneralD.Width = dim[0];
                        this.imgFotoGeneralD.Height = dim[1];
                        break;
                    case FuncionesGrales.TipoFoto.SeniasParticulares:
                        Session["FotosSeniasD"] = FotosSeniasD;
                        url = "ImageHandler1.ashx?t=" + ((int)tipoFoto).ToString() + "&r=" + new Random().Next().ToString() + "&bi=f&p=d";
                        this.imgFotoSeniasD.ImageUrl = url;
                        this.imgFotoSeniasD.OnClientClick = "window.open('FullSizeImage.aspx?url=" + url + "')";
                        this.imgFotoSeniasD.Width = dim[0];
                        this.imgFotoSeniasD.Height = dim[1];
                        break;
                }
                switch (tipoFoto)
                {
                    case FuncionesGrales.TipoFoto.General:
                        if (cantFotos == 1)
                        {
                            this.btnFotoSigGeneralD.Enabled = false;
                            this.btnFotoPrevGeneralD.Enabled = false;
                        }
                        else if (cantFotos > 1)
                        {
                            if (nroFotoActual == 1)
                            {
                                this.btnFotoSigGeneralD.Enabled = true;
                                this.btnFotoPrevGeneralD.Enabled = false;
                            }
                            else if (nroFotoActual > 1 && nroFotoActual < cantFotos)
                            {
                                this.btnFotoSigGeneralD.Enabled = true;
                                this.btnFotoPrevGeneralD.Enabled = true;
                            }
                            else if (nroFotoActual == cantFotos)
                            {
                                this.btnFotoSigGeneralD.Enabled = false;
                                this.btnFotoPrevGeneralD.Enabled = true;
                            }
                        }
                        else
                        {
                            this.btnFotoSigGeneralD.Enabled = false;
                            this.btnFotoPrevGeneralD.Enabled = false;
                            this.imgFotoGeneralD.ImageUrl = "~/App_Images/SinFoto.GIF";
                            this.imgFotoGeneralD.Width = 80;
                            this.imgFotoGeneralD.Height = 100;
                        }
                        break;
                    case FuncionesGrales.TipoFoto.SeniasParticulares:
                        if (cantFotos == 1)
                        {
                            this.btnFotoSigSeniasD.Enabled = false;
                            this.btnFotoPrevSeniasD.Enabled = false;
                        }
                        else if (cantFotos > 1)
                        {

                            if (nroFotoActual == 1)
                            {
                                this.btnFotoSigSeniasD.Enabled = true;
                                this.btnFotoPrevSeniasD.Enabled = false;
                            }
                            else if (nroFotoActual > 1 && nroFotoActual < cantFotos)
                            {
                                this.btnFotoSigSeniasD.Enabled = true;
                                this.btnFotoPrevSeniasD.Enabled = true;
                            }
                            else if (nroFotoActual == cantFotos)
                            {
                                this.btnFotoSigSeniasD.Enabled = false;
                                this.btnFotoPrevSeniasD.Enabled = true;
                            }
                            else
                            {
                                this.btnFotoSigSeniasD.Enabled = false;
                                this.btnFotoPrevSeniasD.Enabled = false;
                                this.imgFotoSeniasD.ImageUrl = "~/App_Images/SinFoto.GIF";
                                this.imgFotoSeniasD.Width = 80;
                                this.imgFotoSeniasD.Height = 100;
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


        /// <summary>
        /// Limpia los controles de la pantalla de persona desaparecida
        /// </summary>
        private void LimpiarControlesD()
        {
          
              this.divPersonasD.Style.Add("display", "none");
            this.divAgregandoPersona.Style.Add("display", "none");
            Session["imgPreview"] = null;
                this.pnlExtranaJurisdiccion.Visible = false;

                this.gvWebServerCausaD.Columns.Clear();
                this.gvWebServerDelitoD.Columns.Clear();
                this.gvWebServerDenuncianteD.Columns.Clear();
                this.gvWebServerImputadoD.Columns.Clear();
                this.gvWebServerPersonasD.Columns.Clear();
                this.gvWebServerVictimaD.Columns.Clear();
            this.lblSeccionalNoCoincide.Style.Add("display", "none");
            //this.fuFotoUploaderD.Enabled = false;
            this.btnAgregarMailAsociado.Visible = false;
            //this.gvMailsAsociados.Columns.Clear();
            this.gvMailsAsociados.DataSource = "";
            this.gvMailsAsociados.DataBind();
            this.gvWebServerCausaD.DataSource = "";
            this.gvWebServerCausaD.DataBind();
            this.gvWebServerDelitoD.DataSource = "";
            this.gvWebServerDelitoD.DataBind();
            this.gvWebServerDenuncianteD.DataSource = "";
            this.gvWebServerDenuncianteD.DataBind();
            this.gvWebServerImputadoD.DataSource = "";
            this.gvWebServerImputadoD.DataBind();
            this.gvWebServerPersonasD.DataSource = "";
            this.gvWebServerPersonasD.DataBind();
            this.gvWebServerVictimaD.DataSource = "";
            this.gvWebServerVictimaD.DataBind();
            this.btnSubirFotoD.CommandArgument = "";
            this.txtApellidoD.Text = "";
            this.txtNombresD.Text = "";
            this.ddlTipoDoc.SelectedValue = "0";
            this.txtDNI.Text = "";
            this.txtArticulosPersonalesD.Text = "";
            this.txtEdadD.Text = "";
            this.txtFechaDesapD.Text = "";
            this.txtFechaNacD.Text = "";
            this.txtPesoD.Text = "";
            this.txtRopaD.Text = "";
            this.txtTallaD.Text = "";
            this.lblNroFotoGralD.Text = "";
            this.ddlAspectoCabelloD.SelectedValue = "0";
            this.ddlRostroD.SelectedValue = "0";
            this.ddlLongitudCabelloD.SelectedValue = "0";
            this.lblLugarDesapPersona.Text = "";
            this.ddlCalvicieD.SelectedValue = "0";
            this.txtCantDiasSinAfeitarD.Text = "";
            this.ddlColorCabelloD.SelectedValue = "0";
            this.ddlColorOjosD.SelectedValue = "0";
            this.ddlColorPielD.SelectedValue = "0";
            this.ddlColorTenidoD.SelectedValue = "0";
            this.ddlAdnD.SelectedValue = "0";
            this.lblComisariaPersonaD.Text = "";
            this.ddlOrgIntD.SelectedValue = "0";
            this.ddlSexoD.SelectedValue = "0";
            this.ddlFotoD.SelectedValue = "0";
            this.ddlFichasDactilaresD.SelectedValue = "0";
            this.ddlExistenRadiografiasD.SelectedValue = "0";
            this.ddlFaltanPiezasDentalesD.SelectedValue = "0";
            this.lblPartidoDesaparicion.Text = "";
            this.lblProvinciaDesapD.Text = "";
            this.hfLugarDId.Value = "0";//por defecto cuando no hay lugar elegido
            this.hfComisariaDId.Value = "0";//por defecto cuando no hay comisaria elegida
            this.lblGuardoExitoD.Visible = false;
            SeniasD = null;
            SeniasD = new SeniasParticularesList();
            this.gvSenasPartD.DataSource = SeniasD;
            this.gvSenasPartD.DataBind();
          
            TatuajesD = null;
            TatuajesD = new TatuajesPersonaList();
            this.gvTatuajesD.DataSource = TatuajesD;
            this.gvTatuajesD.DataBind();
            this.btnBorrarD.Visible = false;
            this.btnVerCriterioBusquedaD.Style.Add("display", "none");
            this.btnGuardarD.Style.Add("display", "none");
            this.btnVerResultadosD.Style.Add("display", "none");
            this.btnImprimirD.Style.Add("display", "none");
            this.imgFotoGeneralD.ImageUrl = null;
            this.imgFotoSeniasD.ImageUrl = null;
            this.imgFotoGeneralD.ImageUrl = "~/App_Images/SinFoto.GIF";
            this.imgFotoSeniasD.ImageUrl = "~/App_Images/SinFoto.GIF";
            this.imgFotoSeniasD.Width = 80;
            this.imgFotoSeniasD.Height = 100;
            this.imgFotoGeneralD.Width = 80;
            this.imgFotoGeneralD.Height = 100;
            this.btnBorrarFotoGralD.Enabled = false;
            this.btnFotoPrevGeneralD.Enabled = false;
            this.btnFotoSigGeneralD.Enabled = false;
            this.btnBorrarFotoSeniasD.Enabled = false;
            this.btnFotoPrevSeniasD.Enabled = false;
            this.btnFotoSigSeniasD.Enabled = false;
            this.btnVerResultadosD.Style.Add("display", "none");
            this.btnVerCriterioBusquedaD.Style.Add("display", "none");
            this.lblNroFotoSeniasD.Text = "";
            this.lblNroFotoGralD.Text = "";
            this.btnImprimirD.OnClientClick = "";
            this.lblPresioneBoton.Style.Add("display", "none");
            Session["FotosSeniasD"] = null;
            Session["FotosGralesD"] = null;
          

            //this.lblIppD.Text = "";
            Session["idPersonaDesaparecida"] = -1;

            this.rblTipoFotos.SelectedIndex = 0;
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
        /// Guarda los datos de la persona desaparecida
        /// </summary>
        /// <param name="miBusqueda">parametros de busqueda</param>
        /// <returns>Devuelve si guardo o no con exito</returns>
        private bool GuardarPersonasDesaparecidas(Busqueda miBusqueda, int id)
        {

                      
            bool GuardoBien = false;
            PersonasDesaparecidas personaDesaparecida = new PersonasDesaparecidas();
            personaDesaparecida.busqueda = miBusqueda;
            int entero;
            DateTime fecha;
            float flotante;
            personaDesaparecida.Id = id;
            personaDesaparecida.tieneADN = Convert.ToInt32(this.ddlAdnD.SelectedValue);
            if (this.tcTipoJurisdiccion.ActiveTab == this.tpPJ)
                personaDesaparecida.Ipp = this.txtIppBuscadoD.Text.Trim();
            else if (this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur)
                personaDesaparecida.Ipp = this.txtCausa.Text.Trim();
            personaDesaparecida.Apellido = this.txtApellidoD.Text.Trim();
            personaDesaparecida.Nombre = this.txtNombresD.Text.Trim();
            personaDesaparecida.DNI = this.txtDNI.Text.Trim();
            personaDesaparecida.idTipoDNI = Convert.ToInt32(this.ddlTipoDoc.SelectedValue);
            personaDesaparecida.ArticulosPersonales = this.txtArticulosPersonalesD.Text.Trim();
            if (this.tcTipoJurisdiccion.ActiveTab == this.tpPJ)
                personaDesaparecida.Ipp = this.txtIppBuscadoD.Text.Trim();
            else if (this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur)
                personaDesaparecida.Ipp = this.txtCausa.Text.Trim();
            if (int.TryParse(this.txtCantDiasSinAfeitarD.Text.Trim(), out entero))
                personaDesaparecida.CantidadDiasNoAfeitado = entero;
            else
                personaDesaparecida.CantidadDiasNoAfeitado = null;
            if (int.TryParse(this.txtEdadD.Text.Trim(), out entero))
                personaDesaparecida.EdadMomentoDesaparicion = entero;
            else
                personaDesaparecida.EdadMomentoDesaparicion = null;
            personaDesaparecida.ExistenRadiografia = Convert.ToInt32(this.ddlExistenRadiografiasD.SelectedValue);
            personaDesaparecida.FaltanPiezasDentales = Convert.ToInt32(this.ddlFaltanPiezasDentalesD.SelectedValue);

            if (DateTime.TryParse(this.txtFechaDesapD.Text.Trim(), out fecha))
                personaDesaparecida.FechaDesaparicion = fecha;
            else
                personaDesaparecida.FechaDesaparicion = null;
            if (DateTime.TryParse(this.txtFechaNacD.Text.Trim(), out fecha))
                personaDesaparecida.FechaNacimiento = fecha;
            else
                personaDesaparecida.FechaNacimiento = null;
            personaDesaparecida.FichasDactilares = Convert.ToInt32(this.ddlFichasDactilaresD.SelectedValue);
            if (this.ddlFotoD.SelectedValue!=null & this.ddlFotoD.SelectedValue.Trim()!="")
                personaDesaparecida.Foto = Convert.ToInt32(this.ddlFotoD.SelectedValue);
            personaDesaparecida.idAspectoCabello = Convert.ToInt32(this.ddlAspectoCabelloD.SelectedValue);
            personaDesaparecida.idCalvicie = Convert.ToInt32(this.ddlCalvicieD.SelectedValue);
            personaDesaparecida.idColorCabello = Convert.ToInt32(this.ddlColorCabelloD.SelectedValue);
            personaDesaparecida.idColorOjos = Convert.ToInt32(this.ddlColorOjosD.SelectedValue);
            personaDesaparecida.idColorPiel = Convert.ToInt32(this.ddlColorPielD.SelectedValue);
            personaDesaparecida.idColorTenido = Convert.ToInt32(this.ddlColorTenidoD.SelectedValue);
            //****************************
            if (Int32.TryParse(this.hfComisariaDId.Value, out entero))
                personaDesaparecida.idComisaria = entero;
            else
                personaDesaparecida.idComisaria = 0;
            personaDesaparecida.idDentadura = 1;
            //***************************
            //personaHallada.idDentadura = Convert.ToInt32(this.ddlDentadura.SelectedValue);
            personaDesaparecida.idLongitudCabello = Convert.ToInt32(this.ddlLongitudCabelloD.SelectedValue);
            //*****************************
            if (Int32.TryParse(this.hfLugarDId.Value, out entero))
                personaDesaparecida.idLugarDesaparicion = entero;
            else
                personaDesaparecida.idLugarDesaparicion = 0;
            personaDesaparecida.idLugarDesaparicion = Convert.ToInt32(this.hfLugarDId.Value);
            personaDesaparecida.idOrganismoInterviniente = Convert.ToInt32(this.ddlOrgIntD.SelectedValue);
            personaDesaparecida.idRostro = Convert.ToInt32(this.ddlRostroD.SelectedValue);
            personaDesaparecida.idSexo = Convert.ToInt32(this.ddlSexoD.SelectedValue);
            if (float.TryParse(this.txtPesoD.Text.Trim(), out flotante))
                personaDesaparecida.Peso = flotante;
            else
                personaDesaparecida.Peso = null;
            personaDesaparecida.Ropa = this.txtRopaD.Text.Trim();
            if (float.TryParse(this.txtTallaD.Text.Trim(), out flotante))
                personaDesaparecida.Talla = flotante;
            else
                personaDesaparecida.Talla = null;
            //***************************
            personaDesaparecida.UFI = Session["miUfi"].ToString();
            //***************************
            personaDesaparecida.FechaUltimaModificacion = DateTime.Now;
            personaDesaparecida.UsuarioUltimaModificacion = Session["miUsuario"].ToString();
            if (personaDesaparecida.Id == -1)
            {
                personaDesaparecida.FechaAlta = DateTime.Now;
                personaDesaparecida.UsuarioAlta = Session["miUsuario"].ToString();
            }
            else
            {
                PersonasDesaparecidas pd = PersonasDesaparecidasManager.GetItem(id);
                personaDesaparecida.FechaAlta = pd.FechaAlta;
                personaDesaparecida.UsuarioAlta = pd.UsuarioAlta;
            }

            //Senas Particulares
            SeniasParticularesList spl = SeniasParticularesManager.GetList(personaDesaparecida.Id, (int)FuncionesGrales.TipoBusqueda.PersonaDesaparecida);
            foreach (SeniasParticulares sp in spl)
            {
                SeniasParticularesManager.Delete(sp);
            }

            if (SeniasD != null)
            {
                
                foreach (SeniasParticulares sp in SeniasD)
                {
                    sp.id = -1;
                }


                personaDesaparecida.seniasParticularess = SeniasD;
            }
            //Tatuajes
            TatuajesPersonaList tpl = TatuajesPersonaManager.GetList(personaDesaparecida.Id, (int)FuncionesGrales.TipoBusqueda.PersonaDesaparecida);
            foreach (TatuajesPersona tp in tpl)
            {
                TatuajesPersonaManager.Delete(tp);
            }
            if (TatuajesD != null)
            {
                foreach (TatuajesPersona tp in TatuajesD)
                {
                    tp.id = -1;
                }
                personaDesaparecida.tatuajesPersonas = TatuajesD;
            }

            //Guarda fotos
            if (FotosGralesD.Count > 0 || FotosSeniasD.Count > 0)
            {
                PBFotosList fotos = new PBFotosList();
                for (int i = 0; i < FotosGralesD.Count; i++)
                {
                    PBFotos f = (PBFotos)FotosGralesD[i];
                    fotos.Add(f);
                }
                for (int i = 0; i < FotosSeniasD.Count; i++)
                {
                    PBFotos f = (PBFotos)FotosSeniasD[i];
                    fotos.Add(f);
                }
                personaDesaparecida.fotoss = fotos;
            }

            //Extrana Jurisdiccion
           
                if (this.tcTipoJurisdiccion.ActiveTab == this.tpPJ)
                    personaDesaparecida.esExtJurisdiccion = false;
                else if (this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur)
                {
                    personaDesaparecida.esExtJurisdiccion = true;
                    PBCausaExtranaJurisdiccion extJur = PBCausaExtranaJurisdiccionManager.GetItem(this.txtCausa.Text.Trim(), 1);
                    if (extJur == null)
                    {
                        extJur = new PBCausaExtranaJurisdiccion();
                        extJur.id = -1;
                    }
                  
                        extJur.NroCausa = personaDesaparecida.Ipp.Trim();
                        extJur.caratula = this.txtCaratulaExtJur.Text.Trim();
                        extJur.idTipoBusqueda = 1;
                        extJur.Jurisdiccion = this.txtJurisdiccionExtJur.Text.Trim();
                        extJur.mail = this.txtMailExtJur.Text.Trim();
                        extJur.OrganoRequirente = this.txtOrgReqExtJur.Text.Trim();
                        extJur.Provincia = this.ddlProvinciaExtJur.SelectedValue;
                        extJur.telefono = this.txtTelefonoExtJur.Text.Trim();
                        personaDesaparecida.PBCausaExtranaJurisdiccion = extJur;
                    
                }
            idPersonaDesaparecida = PersonasDesaparecidasManager.Save(personaDesaparecida);
            if (idPersonaDesaparecida > 0 && id == -1)
            {
                string miusuario = Session["miUsuario"].ToString();
                MPBA.ConfigurationCL.BusinessObject.Usuarios xUsuario = MPBA.ConfigurationCL.BusinessLogic.UsuariosManager.GetItem(miusuario, true);
                PersonalPoderJudicial ppj = PersonalPoderJudicialManager.GetItem(xUsuario.IdPersonalPoderJudicial);

                Persona per = PersonaManager.GetItem(ppj.idPersona);
                //****GUARDA MAIL ASOCIADO***********
                MailsAsociadosPersonasBuscadas mailAsociado = new MailsAsociadosPersonasBuscadas();
                mailAsociado.Apellido = per.Apellido.Trim();
                mailAsociado.Nombre = per.Nombre.Trim();
                mailAsociado.Mail = miusuario + "@mpba.gov.ar";
                mailAsociado.FechaAlta = DateTime.Now;
                mailAsociado.idPersonaBuscada = idPersonaDesaparecida;
                mailAsociado.idTipoPersona = 1;
                mailAsociado.id = -1;
                mailAsociado.seleccionado = true;
                bool guardoBienMailAsociado = MailsAsociadosPersonasBuscadasManager.Save(mailAsociado)>0;
                //**************************
                if (guardoBienMailAsociado)
                {
                    TraerMailsAsociados(idPersonaDesaparecida);
                    this.btnAgregarMailAsociado.Visible = true;
                }
                string esExJur = this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur ? "1" : "0";
                this.btnImprimirD.OnClientClick = "window.open('ReporteFormD.aspx?Ipp=" + personaDesaparecida.Ipp + "&id=" + personaDesaparecida.Id.ToString() +"&esExJur="+esExJur+"')";
                this.btnImprimirD.Style.Remove("display");
                ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Cambios guardados correctamente.');", true);
                //this.lblGuardoExitoD.Visible = true;
                //this.lblGuardoExitoD.Style.Remove("display");
                this.btnVerResultadosD.CommandArgument = idPersonaDesaparecida.ToString();
                this.btnVerCriterioBusquedaD.CommandArgument = miBusqueda.Id.ToString();
                SeniasD = null;
                GuardoBien = true;

            }
            else if (idPersonaDesaparecida > 0 && id > -1)
            {
                GuardoBien = true;
            }
            else
            {
                GuardoBien = false;
            }
            return GuardoBien;

        }

        /// <summary>
        /// Mueve la foto de la carpeta temporaria a la definitiva
        /// </summary>
        /// <param name="nameFotoOriginal">el nombre de la foto original</param>
        /// <param name="tipo">si es hallada o desap</param>
        /// <returns>su hubo exito o no</returns>
        private bool GuardarFotoDefinitiva(string nameFotoOriginal, FuncionesGrales.TipoBusqueda tipoBusqueda, FuncionesGrales.TipoFoto tipoFoto)
        {
            try
            {
                //string pathFisico = Context.Request.PhysicalApplicationPath;
                //string pathOrigen = Server.MapPath(FuncionesGrales.RutaFotosTemp + "/");
                string pathOrigen = "";
                //string pathDestino = "";


                //string nombreFotoDestino = nameFotoOriginal.Replace("tmp", "");


               
                //if (!File.Exists(pathDestino + nombreFotoDestino))
                //{

                //        File.Move(pathOrigen + nameFotoOriginal, pathDestino + nombreFotoDestino);

                //}
                PBFotos foto = new PBFotos();
                foto.id = -1;
                foto.idPersona = idPersonaDesaparecida;
                foto.idTablaDestino = (int)tipoBusqueda;
                foto.idTipoFoto = (int)tipoFoto;

                if (nameFotoOriginal == "")
                {
                    foto.Foto = (Byte[])Session["imgPreview"];
                    //switch (tipoFoto)
                    //{
                    //    case FuncionesGrales.TipoFoto.General:

                    //        break;
                    //    case FuncionesGrales.TipoFoto.SeniasParticulares:
                    //        break;
                    //}
                }
                else
                {
                    FileStream fs = new FileStream(pathOrigen + nameFotoOriginal, FileMode.Open, FileAccess.Read);

                    byte[] ImageData = new byte[fs.Length];
                    fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length));
                    fs.Close();

                    foto.Foto = ImageData;
                }
                if (PBFotosManager.Save(foto) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                throw e;

            }
        }

        private void BuscarIppEnWebService(string ipp, FuncionesGrales.TipoBusqueda tipoBusqueda)
        {
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
                //Defino tabla para grilla de Victimas/Denunciante
                System.Data.DataTable tblWebServerCausa = new System.Data.DataTable();
                System.Data.DataTable tblWebServerDelito = new System.Data.DataTable();
                System.Data.DataTable tblWebServerDenunciante = new System.Data.DataTable();
                System.Data.DataTable tblWebServerPersonas = new System.Data.DataTable();
                System.Data.DataTable tblWebServerVictima = new System.Data.DataTable();
                System.Data.DataTable tblWebServerImputado = new DataTable();
                this.gvWebServerCausaD.Columns.Clear();
                this.gvWebServerDelitoD.Columns.Clear();
                this.gvWebServerDenuncianteD.Columns.Clear();
                this.gvWebServerImputadoD.Columns.Clear();
                this.gvWebServerPersonasD.Columns.Clear();
                this.gvWebServerVictimaD.Columns.Clear();



                while (reader.Read())
                {
                    if (reader.NodeType != XmlNodeType.Element)
                        continue;

                    switch (reader.Name)
                    {
                        case "Causa":
                            if (reader.HasAttributes)
                            {
                                DataRow drCausa = tblWebServerCausa.NewRow();
                                while (reader.MoveToNextAttribute())
                                {
                                    string nombreReader = reader.Name.Trim().ToLower();
                                    if (nombreReader == "sedepolicial")
                                    {
                                        string comisaria = reader.Value.Trim().ToLower();
                                        List<Comisaria> com = ComisariaManager.GetList().FindAll(delegate(Comisaria c) { return c.comisaria.Trim().ToLower() == comisaria; });
                                        if (com.Count != 0)
                                        {
                                            if (state == FuncionesGrales.EstadoPrograma.Creando)
                                            {
                                                int idComisaria = com[0].id;
                                                hfComisariaDId.Value = idComisaria.ToString();
                                                this.lblComisariaPersonaD.Text = comisaria;
                                            }
                                            else
                                            {
                                                if (comisaria != this.lblComisariaPersonaD.Text.ToLower())
                                                    this.lblSeccionalNoCoincide.Style.Remove("display");
                                                else
                                                    this.lblSeccionalNoCoincide.Style.Add("display", "none");
                                            }
                                        }
                                    }
                                    if (nombreReader != "ufi" &&
                                        nombreReader != "titularufi" &&
                                        nombreReader != "juzgadogarantia" &&
                                        nombreReader != "titularjg" &&
                                        nombreReader != "departamento" &&
                                        nombreReader != "sedepolicial" &&
                                        nombreReader != "fechainicioipp")
                                        continue;
                                    if (!tblWebServerCausa.Columns.Contains(reader.Name))
                                    {
                                        DataColumn dcCausa = new DataColumn(reader.Name);
                                        tblWebServerCausa.Columns.Add(dcCausa);
                                    }
                                    drCausa[reader.Name] = reader.Value;
                                }
                                tblWebServerCausa.Rows.Add(drCausa);
                            }
                            break;
                        case "personas":
                            if (reader.HasAttributes)
                            {
                                DataRow drPersonas = tblWebServerPersonas.NewRow();
                                while (reader.MoveToNextAttribute())
                                {
                                    if (!tblWebServerPersonas.Columns.Contains(reader.Name))
                                        if (reader.Name != "ID")
                                        {
                                            {
                                                DataColumn dcPersonas = new DataColumn(reader.Name);
                                                tblWebServerPersonas.Columns.Add(dcPersonas);
                                            }
                                            drPersonas[reader.Name] = reader.Value;


                                        }

                                }
                                tblWebServerPersonas.Rows.Add(drPersonas);
                            }
                            break;
                        case "Denunciante":
                            if (reader.HasAttributes)
                            {
                                DataRow drDenunciante = tblWebServerDenunciante.NewRow();
                                while (reader.MoveToNextAttribute())
                                {
                                    if (!tblWebServerDenunciante.Columns.Contains(reader.Name))
                                        if (reader.Name != "ID")
                                        {
                                            {
                                                DataColumn dcDenunciante = new DataColumn(reader.Name);
                                                tblWebServerDenunciante.Columns.Add(dcDenunciante);
                                            }
                                            drDenunciante[reader.Name] = reader.Value;


                                        }

                                }
                                tblWebServerDenunciante.Rows.Add(drDenunciante);
                            }
                            break;
                        case "Victima":
                            if (reader.HasAttributes)
                            {
                                DataRow drVictima = tblWebServerVictima.NewRow();
                                while (reader.MoveToNextAttribute())
                                {
                                    if (!tblWebServerVictima.Columns.Contains(reader.Name))
                                        if (reader.Name != "ID" & reader.Name != "idTipoVinculo")
                                        {
                                            {
                                                DataColumn dcVictima = new DataColumn(reader.Name);
                                                tblWebServerVictima.Columns.Add(dcVictima);
                                            }
                                            drVictima[reader.Name] = reader.Value;


                                        }

                                }
                                tblWebServerVictima.Rows.Add(drVictima);
                            }
                            break;
                        case "Imputado":
                            if (reader.HasAttributes)
                            {
                                DataRow drImputado = tblWebServerImputado.NewRow();
                                while (reader.MoveToNextAttribute())
                                {
                                    if (!tblWebServerImputado.Columns.Contains(reader.Name))
                                        if (reader.Name != "ID" & reader.Name != "idTipoVinculo")
                                        {
                                            {
                                                DataColumn dcImputado = new DataColumn(reader.Name);
                                                tblWebServerImputado.Columns.Add(dcImputado);
                                            }
                                            drImputado[reader.Name] = reader.Value;


                                        }

                                }
                                tblWebServerImputado.Rows.Add(drImputado);
                            }
                            break;
                        case "Delito":
                            if (reader.HasAttributes)
                            {
                                DataRow drDelito = tblWebServerDelito.NewRow();
                                while (reader.MoveToNextAttribute())
                                {
                                    if (!tblWebServerDelito.Columns.Contains(reader.Name))
                                    {
                                        DataColumn dcDelito = new DataColumn(reader.Name);
                                        tblWebServerDelito.Columns.Add(dcDelito);
                                    }
                                    drDelito[reader.Name] = reader.Value;
                                }
                                tblWebServerDelito.Rows.Add(drDelito);
                            }
                            break;
                    }
                    switch (tipoBusqueda)
                    {
                        case FuncionesGrales.TipoBusqueda.PersonaDesaparecida:
                            this.gvWebServerCausaD.DataSource = tblWebServerCausa;
                            this.gvWebServerCausaD.DataBind();
                            this.gvWebServerDelitoD.DataSource = tblWebServerDelito;
                            this.gvWebServerDelitoD.DataBind();
                            this.gvWebServerDenuncianteD.DataSource = tblWebServerDenunciante;
                            this.gvWebServerDenuncianteD.DataBind();
                            this.gvWebServerImputadoD.DataSource = tblWebServerImputado;
                            this.gvWebServerImputadoD.DataBind();
                            this.gvWebServerPersonasD.DataSource = tblWebServerPersonas;
                            this.gvWebServerPersonasD.DataBind();
                            this.gvWebServerVictimaD.DataSource = tblWebServerVictima;
                            this.gvWebServerVictimaD.DataBind();
                            break;
                        case FuncionesGrales.TipoBusqueda.PersonaHallada:

                            break;
                    }
                }
                int status = Convert.ToInt32(Request.QueryString["status"]);
                if (status == (int)FuncionesGrales.EstadoPrograma.Creando & this.gvWebServerCausaD.Rows.Count > 0)
                {
                    this.lblComisariaPersonaD.Text = this.gvWebServerCausaD.Rows[0].Cells[4].Text.Trim().ToLower();
                    if (this.lblComisariaPersonaD.Text != "&nbsp;")
                        this.ddlOrgIntD.SelectedValue = "2";
                    if (ComisariaManager.GetItemByDescripcion(this.lblComisariaPersonaD.Text.Trim()) != null)
                        this.hfComisariaDId.Value = ComisariaManager.GetItemByDescripcion(this.lblComisariaPersonaD.Text.Trim()).id.ToString();
                }
                if (status == (int)FuncionesGrales.EstadoPrograma.Modificando & this.gvWebServerCausaD.Rows.Count > 0)
                {
                    if (this.gvWebServerCausaD.Rows[0].Cells[4].Text.Trim().ToLower() != this.lblComisariaPersonaD.Text.ToLower())
                        this.lblSeccionalNoCoincide.Style.Remove("display");
                    else
                        this.lblSeccionalNoCoincide.Style.Add("display", "none");

                }
            }
            catch (Exception ex)
            {
                this.cvIppD.Text = ex.Message.ToString();
                this.cvIppD.IsValid = false;
            }


        }

        /// <summary>
        /// Controla si la ipp indicada ya existe en base
        /// </summary>
        /// <param name="IPP">ipp a controlar</param>
        /// <param name="destino">si es para una persona desaparecida o hallada</param>
        /// <returns>Devuelve si existe la ipp o no</returns>
        private bool EsIppExistente(string IPP, FuncionesGrales.TipoBusqueda destino, bool esExtJur)
        {
            Busqueda b = new Busqueda();
            b.IPP = IPP.Trim();

            switch (destino)
            {
                case FuncionesGrales.TipoBusqueda.PersonaDesaparecida:
                    return PersonasDesaparecidasManager.GetList(b).FindAll(delegate(PersonasDesaparecidas pd) { return pd.esExtJurisdiccion == esExtJur; }).Count > 0;
                //return PersonasDesaparecidasManager.GetList().FindAll(delegate(PersonasDesaparecidas pd) { return pd.Ipp.Trim() == IPP; }).Count > 0;

                case FuncionesGrales.TipoBusqueda.PersonaHallada:
                    return PersonasHalladasManager.GetList(b).FindAll(delegate(PersonasHalladas ph) { return ph.esExtJurisdiccion == esExtJur; }).Count > 0;
                //return PersonasHalladasManager.GetList().FindAll(delegate(PersonasHalladas ph) { return ph.Ipp.Trim() == IPP; }).Count > 0;
            }
            return false;
        }


        private void AvanzarFoto(FuncionesGrales.TipoFoto tipoFoto)
        {
            switch (tipoFoto)
            {
                case FuncionesGrales.TipoFoto.General:
                    if (FotosGralesD.Position < FotosGralesD.Count)
                    {
                        FotosGralesD.MoveNext();
                        PBFotos f = (PBFotos)FotosGralesD.Current;
                        LlenarImgBox(f, FuncionesGrales.TipoBusqueda.PersonaDesaparecida, tipoFoto);
                    }
                    break;
                case FuncionesGrales.TipoFoto.SeniasParticulares:
                    if (FotosSeniasD.Position < FotosSeniasD.Count)
                    {
                        FotosSeniasD.MoveNext();
                        PBFotos f = (PBFotos)FotosSeniasD.Current;
                        LlenarImgBox(f, FuncionesGrales.TipoBusqueda.PersonaDesaparecida, tipoFoto);
                    }
                    break;
            }
            this.lblNroFotoGralD.Text = (FotosGralesD.Position + 1).ToString() + "/" + FotosGralesD.Count.ToString();
            this.lblNroFotoSeniasD.Text = (FotosSeniasD.Position + 1).ToString() + "/" + FotosSeniasD.Count.ToString();



        }

        private void RetrocederFoto(FuncionesGrales.TipoFoto tipoFoto)
        {
            switch (tipoFoto)
            {
                case FuncionesGrales.TipoFoto.General:
                    if (FotosGralesD.Position > 0)
                    {
                        FotosGralesD.MovePrevious();
                        PBFotos f = (PBFotos)FotosGralesD.Current;
                        LlenarImgBox(f, FuncionesGrales.TipoBusqueda.PersonaDesaparecida, tipoFoto);
                    }
                    break;
                case FuncionesGrales.TipoFoto.SeniasParticulares:
                    if (FotosSeniasD.Position > 0)
                    {
                        FotosSeniasD.MovePrevious();
                        PBFotos f = (PBFotos)FotosSeniasD.Current;
                        LlenarImgBox(f, FuncionesGrales.TipoBusqueda.PersonaDesaparecida, tipoFoto);
                    }
                    break;
            }

            this.lblNroFotoGralD.Text = (FotosGralesD.Position + 1).ToString() + "/" + FotosGralesD.Count.ToString();
            this.lblNroFotoSeniasD.Text = (FotosSeniasD.Position + 1).ToString() + "/" + FotosSeniasD.Count.ToString();

        }

        private bool BorrarFoto(string fullNameFoto, FuncionesGrales.TipoFoto tipoFoto)
        {
            bool borroBien = false;
            int cantFotos = 0;
            PBFotos foto = null;
            switch (tipoFoto)
            {

                case FuncionesGrales.TipoFoto.General:
                    foto = (PBFotos)FotosGralesD.Current;
                    borroBien = PBFotosManager.Delete(foto);
                    FotosGralesD.Remove(foto);
                    cantFotos = FotosGralesD.Count;
                    FotosGralesD.MoveFirst();
                    this.imgFotoGeneralD.ImageUrl = "~/App_Images/SinFoto.GIF";
                    if (cantFotos > 0)
                        LlenarImgBox((PBFotos)FotosGralesD.Current, FuncionesGrales.TipoBusqueda.PersonaDesaparecida, tipoFoto);
                    if (cantFotos == 0)
                    {
                        this.imgFotoGeneralD.ImageUrl = "~/App_Images/SinFoto.GIF";
                        this.imgFotoGeneralD.Width = 80;
                        this.imgFotoGeneralD.Height = 100;
                        this.btnBorrarFotoGralD.Enabled = false;
                        this.btnFotoSigGeneralD.Enabled = false;
                        this.btnFotoPrevGeneralD.Enabled = false;
                    }
                    break;
                case FuncionesGrales.TipoFoto.SeniasParticulares:
                    foto = (PBFotos)FotosSeniasD.Current;
                    borroBien = PBFotosManager.Delete(foto);
                    FotosSeniasD.Remove(foto);
                    cantFotos = FotosSeniasD.Count;
                    FotosSeniasD.MoveFirst();
                    this.imgFotoSeniasD.ImageUrl = "~/App_Images/SinFoto.GIF";
                    this.imgFotoSeniasD.Width = 80;
                    this.imgFotoSeniasD.Height = 100;
                    if (cantFotos > 0)
                        LlenarImgBox((PBFotos)FotosSeniasD.Current, FuncionesGrales.TipoBusqueda.PersonaDesaparecida, tipoFoto);
                    if (cantFotos == 0)
                    {
                        this.imgFotoSeniasD.ImageUrl = "~/App_Images/SinFoto.GIF";
                        this.imgFotoSeniasD.Width = 80;
                        this.imgFotoSeniasD.Height = 100;
                        this.btnBorrarFotoSeniasD.Enabled = false;
                        this.btnFotoSigSeniasD.Enabled = false;
                        this.btnFotoPrevSeniasD.Enabled = false;
                    }

                    break;
            }

            this.lblNroFotoGralD.Text = (FotosGralesD.Position + 1).ToString() + "/" + FotosGralesD.Count.ToString();
            this.lblNroFotoSeniasD.Text = (FotosSeniasD.Position + 1).ToString() + "/" + FotosSeniasD.Count.ToString();
            return borroBien;
        }

        private void SubirFoto(FuncionesGrales.TipoBusqueda tipoBusqueda, FuncionesGrales.TipoFoto tipoFoto)
        {
            int fotosSubidas = 0;
            string random = DateTime.Now.Millisecond.ToString();
            fotosSubidas = 1;
            for (int i = 1; i <= fotosSubidas; i++)
            {
                bool yaTieneFoto = false;
                if (idPersonaDesaparecida > 0)
                {
                    switch (tipoFoto)
                    {
                        case FuncionesGrales.TipoFoto.General:
                            yaTieneFoto = FotosGralesD.Count > 0;
                            if (yaTieneFoto)
                            {
                                FotosGralesD.MoveLast();
                            }
                            break;
                        case FuncionesGrales.TipoFoto.SeniasParticulares:
                            yaTieneFoto = FotosSeniasD.Count > 0;
                            if (yaTieneFoto)
                            {
                                FotosSeniasD.MoveLast();
                            }
                            break;
                    }
                }
                PBFotos nuevaFoto = new PBFotos();
                nuevaFoto.id = -1;
                nuevaFoto.idTablaDestino = (int)tipoBusqueda;
                nuevaFoto.idTipoFoto = (int)tipoFoto;
                nuevaFoto.Foto = (Byte[])Session["imgPreview"];
                if (idPersonaDesaparecida > 0)
                {
                    nuevaFoto.idPersona = idPersonaDesaparecida;
                    PBFotosManager.Save(nuevaFoto);
                }
                else
                    nuevaFoto.idPersona = -1;

                switch (tipoFoto)
                {
                    case FuncionesGrales.TipoFoto.General:
                        FotosGralesD.Add(nuevaFoto);
                        FotosGralesD.EndEdit();
                        FotosGralesD.MoveLast();
                        break;
                    case FuncionesGrales.TipoFoto.SeniasParticulares:
                        FotosSeniasD.Add(nuevaFoto);
                        FotosSeniasD.EndEdit();
                        FotosSeniasD.MoveLast();
                        break;
                }
            }
            if (fotosSubidas > 0)
            {
                PBFotos f;
                switch (tipoFoto)
                {
                    case FuncionesGrales.TipoFoto.General:
                        FotosGralesD.MoveLast();
                        f = (PBFotos)FotosGralesD.Current;
                        LlenarImgBox(f, FuncionesGrales.TipoBusqueda.PersonaDesaparecida, tipoFoto);
                        break;
                    case FuncionesGrales.TipoFoto.SeniasParticulares:
                        FotosSeniasD.MoveLast();
                        f = (PBFotos)FotosSeniasD.Current;
                        LlenarImgBox(f, FuncionesGrales.TipoBusqueda.PersonaDesaparecida, tipoFoto);
                        break;
                }
                switch (tipoFoto)
                {
                    case FuncionesGrales.TipoFoto.General:
                        FotosGralesD.MoveLast();
                        break;
                    case FuncionesGrales.TipoFoto.SeniasParticulares:
                        FotosSeniasD.MoveLast();
                        break;
                }
            }
            this.lblNroFotoGralD.Text = (FotosGralesD.Position + 1).ToString() + "/" + FotosGralesD.Count.ToString();
            this.lblNroFotoSeniasD.Text = (FotosSeniasD.Position + 1).ToString() + "/" + FotosSeniasD.Count.ToString();
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
            if (personaHallada.DNI != null)
                this.lblDNINumeroBIH.Text = personaHallada.DNI.Trim();
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


                    break;
            }
        }

        /// <summary>
        /// /// Realiza la validacion de los controles de la busqueda individual
        /// </summary>
        private void ValidarBI()
        {
            //coincidencias
            if (this.txtCoincidenciaBI.Text.Trim() == "" || Convert.ToInt32(this.txtCoincidenciaBI.Text.Trim()) < 5)
            {
                //this.mevtxtCoincidencia.IsValid = false;
                this.txtCoincidenciaBI.Focus();
            }
            //fechas
            string fechaDesde = this.txtFechaDesdeBI.Text.Trim();
            string fechaHasta = this.txtFechaHastaBI.Text.Trim();
            if (fechaDesde != "" && fechaHasta != "")
            {
                if (this.mevFechaDesdeBI.IsValid == true && this.mevFechaHastaBI.IsValid == true)
                {
                    if (Convert.ToDateTime(fechaDesde) > Convert.ToDateTime(fechaHasta))
                    {
                        this.cvFechasBI.IsValid = false;
                    }
                }
            }

            //edades
            string edadDesde = this.txtEdadDesdeBI.Text.Trim();
            string edadHasta = this.txtEdadHastaBI.Text.Trim();
            if (edadDesde != "" && edadHasta != "")
            {
                if (this.mevEdadDesdeBI.IsValid == true && this.mevEdadHastaBI.IsValid == true)
                {
                    if (Convert.ToInt32(edadDesde) > Convert.ToInt32(edadHasta))
                    {
                        this.cvEdadesBI.IsValid = false;
                    }
                    else
                    // La edad desde y Hasta deben comprender la edad ingresada por el usuario
                    {
                        if (this.txtEdadD.Text != "")
                        {
                            if (Convert.ToInt32(edadDesde) > Convert.ToInt32(this.txtEdadD.Text) || Convert.ToInt32(this.txtEdadD.Text) > Convert.ToInt32(edadHasta))
                            {
                                this.cvEdadesBI.IsValid = false;
                                this.cvEdadesBI.ErrorMessage = "El rango de Búsqueda deben incluir la especificada";

                            }
                        }
                        else
                        {  // La edad calculada debe estar dentro del rango de busqueda
                            string fn=  this.txtFechaNacD.Text.Trim();
                            int edadcalculada=   DateTime.Today.Year - Convert.ToDateTime(fn).Year ;
                            if (Convert.ToInt32(edadDesde) > edadcalculada - 1 && Convert.ToInt32(edadHasta) < edadcalculada)
                            {
                                this.cvEdadesBI.IsValid = false;
                                this.cvEdadesBI.ErrorMessage = "El rango de Búsqueda deben incluir la especificada";

                            }
                         
                        }

                    
                    }
                }
            }
            else
            { 
                this.cvEdadesBI.IsValid = false;
                this.cvEdadesBI.ErrorMessage = "La edad Desde/Hasta es obligatoria";

            }

            //tallas 
            string tallaDesde = this.txtTallaDesdeBI.Text.Trim();
            string tallaHasta = this.txtTallaHastaBI.Text.Trim();
            if (tallaDesde != "" && tallaHasta != "")
            {
                if (this.mevTallaDesdeBI.IsValid == true && this.mevTallaDesdeBI.IsValid == true)
                {
                    if (Convert.ToInt32(tallaDesde) > Convert.ToInt32(tallaHasta))
                    {
                        this.cvTallasBI.IsValid = false;
                    }
                }
            }

            // Color de piel: Debe incluir el color de Piel que especifico en la búsqueda
           int coincidencia = 0;
           int seleccionado;
            if (this.lstColorPielBI.Items.Count > 0)
            {
                for (int i = 0; i < lstColorPielBI.Items.Count; i++)
                {
                    if (lstColorPielBI.Items[i].Selected)
                    {
                        if (this.ddlColorPielD.SelectedValue == lstColorPielBI.Items[i].Value)
                        {
                            coincidencia = 1;
                        }
                        
                    }
                }
              }
            if (coincidencia == 0 )
            {
                // No ingreso nada o no coincide con lo especificado
                   
                    seleccionado = Convert.ToInt32(ddlColorPielD.SelectedValue);
                    this.cbColorDePiel.IsValid = false;
                    this.cbColorDePiel.ErrorMessage = "Incluya " + this.ddlColorPielD.Items[seleccionado].Text;
                                                      
            }
            // El Color de Ojos debe ser coincidente
            coincidencia = 0;

            if (this.lstColorOjosBI.Items.Count > 0)
            {
                for (int i = 0; i < lstColorOjosBI.Items.Count; i++)
                {
                    if (lstColorOjosBI.Items[i].Selected)
                    {
                        if (this.ddlColorOjosD.SelectedValue == lstColorOjosBI.Items[i].Value)
                        {
                            coincidencia = 1;
                        }

                    }
                }
            }
            if (coincidencia == 0)
            {
                // No ingreso nada o no coincide con lo especificado
                seleccionado = Convert.ToInt32(ddlColorOjosD.SelectedValue);
                this.cbColorOjos.IsValid = false;
                this.cbColorOjos.ErrorMessage = "Incluya " + this.ddlColorOjosD.Items[seleccionado].Text;
              }
        

            // El sexo debe ser obligatorio
            if (this.ddlSexoBI.SelectedValue != this.ddlSexoD.SelectedValue)
            {
                seleccionado = Convert.ToInt32(ddlSexoD.SelectedValue);
                this.cbSexo.IsValid = false;
                this.cbSexo.ErrorMessage = "Ingrese "+this.ddlSexoD.Items[seleccionado].Text;
             }

            
            //pesos  
            string pesoDesde = this.txtPesoDesdeBI.Text.Trim();
            string pesoHasta = this.txtPesoHastaBI.Text.Trim();
            if (pesoDesde != "" && pesoHasta != "")
            {
                if (this.mevPesoDesdeBI.IsValid == true && this.mevPesoHastaBI.IsValid == true)
                {
                    if (Convert.ToInt32(pesoDesde) > Convert.ToInt32(pesoHasta))
                    {
                        this.cvPesosBI.IsValid = false;
                    }
                }
            }
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
                        LlenarImgBoxFichaBI(f, FuncionesGrales.TipoBusqueda.PersonaHallada, tipoFoto);
                    }
                    break;
                case FuncionesGrales.TipoFoto.SeniasParticulares:
                    if (FotosSeniasBI.Position > 0)
                    {
                        FotosSeniasBI.MovePrevious();
                        PBFotos f = (PBFotos)FotosSeniasBI.Current;
                        LlenarImgBoxFichaBI(f, FuncionesGrales.TipoBusqueda.PersonaHallada, tipoFoto);
                    }
                    break;
            }

            this.lblNroFotoGralBIH.Text = (FotosGralesBI.Position + 1).ToString() + "/" + FotosGralesBI.Count.ToString();
            this.lblNroFotoSenasBIH.Text = (FotosSeniasBI.Position + 1).ToString() + "/" + FotosSeniasBI.Count.ToString();
        }

        /// <summary>
        /// Copia la foto indicada al directorio temporario
        /// </summary>
        /// <param name="fullNameFotoOriginal">nombre de origen completo de la foto con ruta fisica </param>
        /// <param name="fullNameFotoDestino">nombre de destino completo de la foto con ruta fisica</param>
        /// <param name="tipo"></param>
        /// <returns></returns>
        //private string CopiarFotoADirTmp(string fullNameFotoOriginal, string fullNameFotoDestino)
        private string CopiarFotoADirTmp(string fullNameFotoDestino)
        {

            Byte[] input = (Byte[])Session["imgPreview"];
            using (MemoryStream ms = new MemoryStream(input))
            {
                using (System.Drawing.Image imgPhoto = System.Drawing.Image.FromStream(ms))
                {

                    //string rutaTmp = FuncionesGrales.RutaFotosTemp + "/";
                    int i = 1;
                    if (File.Exists(fullNameFotoDestino))
                        i++;
                    using (FileStream fs = File.OpenWrite(fullNameFotoDestino))
                    {
                        fs.Write(input, 0, Convert.ToInt32(ms.Position));
                        fs.Close();
                    }
                    imgPhoto.Dispose();
                    ms.Close();
                    //File.Move(fullNameFotoOriginal, fullNameFotoDestino);
                }
            }
            return fullNameFotoDestino;
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
                        this.imgFotoGralBIH.ImageUrl = url;
                        this.imgFotoGralBIH.OnClientClick = "window.open('FullSizeImage.aspx?url=" + url + "')";
                        this.imgFotoGralBIH.Width = dim[0];
                        this.imgFotoGralBIH.Height = dim[1];
                        break;
                    case FuncionesGrales.TipoFoto.SeniasParticulares:
                        Session["FotosSeniasBI"] = FotosSeniasBI;
                        url = "ImageHandler1.ashx?t=" + ((int)tipoFoto).ToString() + "&r=" + new Random().Next().ToString() + "&bi=t&p=h";
                        this.imgFotoSenasBIH.ImageUrl = url;
                        this.imgFotoSenasBIH.OnClientClick = "window.open('FullSizeImage.aspx?url=" + url + "')";
                        this.imgFotoSenasBIH.Width = dim[0];
                        this.imgFotoSenasBIH.Height = dim[1];
                        break;
                }
                switch (tipoFoto)
                {
                    case FuncionesGrales.TipoFoto.General:
                        if (cantFotos == 1)
                        {
                            this.btnFotoSigGeneralBIH.Enabled = false;
                            this.btnFotoPrevGeneralBIH.Enabled = false;
                        }
                        else if (cantFotos > 1)
                        {

                            if (nroFotoActual == 1)
                            {
                                this.btnFotoSigGeneralBIH.Enabled = true;
                                this.btnFotoPrevGeneralBIH.Enabled = false;
                            }
                            else if (nroFotoActual > 1 && nroFotoActual < cantFotos)
                            {
                                this.btnFotoSigGeneralBIH.Enabled = true;
                                this.btnFotoPrevGeneralBIH.Enabled = true;
                            }
                            else if (nroFotoActual == cantFotos)
                            {
                                this.btnFotoSigGeneralBIH.Enabled = false;
                                this.btnFotoPrevGeneralBIH.Enabled = true;
                            }
                        }
                        else
                        {
                            this.btnFotoSigGeneralBIH.Enabled = false;
                            this.btnFotoPrevGeneralBIH.Enabled = false;
                            this.imgFotoGralBIH.ImageUrl = "~/App_Images/SinFoto.GIF";
                            this.imgFotoGralBIH.Width = 80;
                            this.imgFotoGralBIH.Height = 100;
                        }
                        break;
                    case FuncionesGrales.TipoFoto.SeniasParticulares:
                        if (cantFotos == 1)
                        {
                            this.btnFotoSigSeniasBIH.Enabled = false;
                            this.btnFotoPrevSeniasBIH.Enabled = false;
                        }
                        else if (cantFotos > 1)
                        {

                            if (nroFotoActual == 1)
                            {
                                this.btnFotoSigSeniasBIH.Enabled = true;
                                this.btnFotoPrevSeniasBIH.Enabled = false;
                            }
                            else if (nroFotoActual > 1 && nroFotoActual < cantFotos)
                            {
                                this.btnFotoSigSeniasBIH.Enabled = true;
                                this.btnFotoPrevSeniasBIH.Enabled = true;
                            }
                            else if (nroFotoActual == cantFotos)
                            {
                                this.btnFotoSigSeniasBIH.Enabled = false;
                                this.btnFotoPrevSeniasBIH.Enabled = true;
                            }
                            else
                            {
                                this.btnFotoSigSeniasBIH.Enabled = false;
                                this.btnFotoPrevSeniasBIH.Enabled = false;
                                this.imgFotoSenasBIH.ImageUrl = "~/App_Images/SinFoto.GIF";
                                this.imgFotoSenasBIH.Width = 80;
                                this.imgFotoSenasBIH.Height = 100;
                            }
                        }
                        break;
                }

            }


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
            this.lblDNINumeroBIH.Text = "";
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

        #endregion

        protected void btnCerrarVerBI_Click(object sender, EventArgs e)
        {
            this.hfVerCriterioBI_ModalPopupExtender.Hide();
        }

        protected void btnAgregarPersonaDD_Click(object sender, EventArgs e)
        {
            
            idPersonaDesaparecida = 0;
            Session["FotosGralesD"] = null;
            Session["FotosSeniasD"] = null;
            Session["FotosGralesBI"] = null;
            Session["FotosSeniasBI"] = null;
            Session["TatuajesD"] = new TatuajesPersonaList();
            Session["TatuajesH"] = new TatuajesPersonaList();
            Session["TatuajesBI"] = new TatuajesPersonaList();
            Session["SeniasD"] = new SeniasParticularesList();
            Session["SeniasH"] =new SeniasParticularesList();
            Session["SeniasBI"] = new SeniasParticularesList();
            state = FuncionesGrales.EstadoPrograma.Agregando;
            LimpiarControlesBI();
            LimpiarControlesD();
            if (this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur)
                this.pnlExtranaJurisdiccion.Visible = true;
            else
                this.pnlExtranaJurisdiccion.Visible = false;
            LimpiarControlesFichaPersHalladaBI();
            LimpiarControlesVerCriterioBI();
            this.btnGuardarD.Style.Remove("display");
            //this.lblAgregandoPersona.Visible = true;
            this.divAgregandoPersona.Style.Remove("display");
            this.pnlPersonadesaparecida.Enabled = true;
        }

        protected void gvPersonasD_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblGuardoExitoD.Visible = false;
            LimpiarControlesD();
            this.divPersonasD.Style.Remove("display");
            SetearGvPersonas();
            string ipp = "";
            if (this.tcTipoJurisdiccion.ActiveTab == this.tpPJ)
                ipp = this.txtIppBuscadoD.Text.Trim();
            else if (this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur)
                ipp = this.txtCausa.Text.Trim();
            //state = FuncionesGrales.EstadoPrograma.Consultando;
            //BuscarIpp(Convert.ToInt32(this.gvPersonasD.DataKeys[this.gvPersonasD.SelectedIndex].Value),ipp);
            //this.gvPersonasD.DataBind();
            int idDelito = Convert.ToInt32(this.gvPersonasD.DataKeys[this.gvPersonasD.SelectedIndex].Value);
            PersonasDesaparecidas myPD = PersonasDesaparecidasManager.GetItem(idDelito, true);

            LlenarControlesD(myPD);

            BuscarIppEnWebService(ipp, FuncionesGrales.TipoBusqueda.PersonaDesaparecida);
            LlenarControlesBI(myPD.busqueda);
            this.btnVerCriterioBusquedaD.CommandArgument = myPD.busqueda.Id.ToString();
            this.btnVerResultadosD.CommandArgument = myPD.Id.ToString();
            this.btnImprimirD.Style.Remove("display");
            this.btnVerCriterioBusquedaD.Style.Remove("display");
            this.btnVerResultadosD.Style.Remove("display");
            Session["idPersonaDesaparecida"] = myPD.Id;
            string esExJur = this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur ? "1" : "0";
            this.btnImprimirD.OnClientClick = "window.open('ReporteFormD.aspx?Ipp=" + myPD.Ipp + "&id=" + myPD.Id.ToString() + "&esExJur="+esExJur+"')";
            this.fuFotoUploaderD.Enabled = true;
            if (state == FuncionesGrales.EstadoPrograma.Creando || state==FuncionesGrales.EstadoPrograma.Consultando)
            {
                this.pnlPersonadesaparecida.Enabled = false;
                this.btnGuardarD.Style.Add("display", "none");
            }
            else if (state == FuncionesGrales.EstadoPrograma.Modificando)
            {
                this.pnlPersonadesaparecida.Enabled = true;
                this.btnGuardarD.Style.Remove("display");
            }
            TraerMailsAsociados(idDelito);
        }

        protected void gvPersonasD_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
            //ScriptManager.RegisterStartupScript(this, typeof(string), "Borrar", "confirm('Seguro que desea borrar?');", true);
            int id = Convert.ToInt32(this.gvPersonasD.DataKeys[e.RowIndex].Value);
            string ipp = "";
            PersonasDesaparecidas pd = PersonasDesaparecidasManager.GetItem(id, true);
            pd.Baja = true;

            PersonasDesaparecidasManager.Save(pd);
            List<PersonasDesaparecidas> myPersonas = null;
            if (this.tcTipoJurisdiccion.ActiveTab == this.tpPJ)
            {
                ipp = this.txtIppBuscadoD.Text.Trim();
                myPersonas = PersonasDesaparecidasManager.GetListByIPP(ipp).FindAll(delegate(PersonasDesaparecidas p) { return p.Baja == false && (p.esExtJurisdiccion == null || p.esExtJurisdiccion == false); });
            }
            else if (this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur)
            {
                ipp = this.txtCausa.Text.Trim();
                myPersonas = PersonasDesaparecidasManager.GetListByIPP(ipp).FindAll(delegate(PersonasDesaparecidas p) { return p.Baja == false && (p.esExtJurisdiccion != null && p.esExtJurisdiccion == true); });
            }


            
            
             if (myPersonas.Count > 0)
             {

                 this.gvPersonasD.DataSource = myPersonas;
                 this.gvPersonasD.DataBind();
                 this.gvPersonasD.SelectedIndex = 0;
             }

             if (this.gvPersonasD.Rows.Count > 0)
             {
                 this.gvPersonasD.SelectedIndex = 0;
                 int idDelito = Convert.ToInt32(this.gvPersonasD.DataKeys[this.gvPersonasD.SelectedIndex].Value);
                 PersonasDesaparecidas myPD = PersonasDesaparecidasManager.GetItem(idDelito, true);

                 LlenarControlesD(myPD);
             }
            SetearGvPersonas();
            TraerMailsAsociados(idPersonaDesaparecida);
        }

        protected void btnCancelarAgregarPersonaD_Click(object sender, EventArgs e)
        {
            this.divAgregandoPersona.Style.Add("display", "none");
            this.divPersonasD.Style.Remove("display");
          
            if (this.gvPersonasD.Rows.Count > 0)
            {
                FuncionesGrales.EstadoPrograma estado = state;
                this.gvPersonasD.SelectedIndex = 0;
                //state = FuncionesGrales.EstadoPrograma.Modificando;
                this.gvPersonasD_SelectedIndexChanged(this.gvPersonasD, null);
                //state = estado;
            }
            SetearGvPersonas();
            
            if (this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur)
                this.pnlExtranaJurisdiccion.Visible = true;
            else
                this.pnlExtranaJurisdiccion.Visible = false;
            if (state == FuncionesGrales.EstadoPrograma.Creando)
            {
                this.pnlPersonadesaparecida.Enabled = this.gvPersonasD.Rows.Count == 0;
            }
            
        }

        protected void tcTipoJurisdiccion_ActiveTabChanged(object sender, EventArgs e)
        {
            this.pnlPersonadesaparecida.Enabled = false;
            if (this.tcTipoJurisdiccion.ActiveTab == this.tpPJ)
            {
                this.pnlExtranaJurisdiccion.Visible = false;
                LimpiarControlesD();
                LimpiarControlesBI();
                this.txtIppBuscadoD.Focus();
            }
            else if (this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur)
            {
                this.pnlExtranaJurisdiccion.Visible = false;
                LimpiarControlesD();
                LimpiarControlesBI();
                LimpiarControlesExtJur();
                this.txtCausa.Focus();
            }
            
       
        }

        protected void btnImprimirD_Click(object sender, EventArgs e)
        {
            SetearGvPersonas();
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

        protected void gvMailsAsociados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
            if (state == FuncionesGrales.EstadoPrograma.Consultando)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No esta habilitado para realizar modificaciones.');", true);
                return;
            }
            if (this.gvMailsAsociados.Rows.Count == 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Debe haber al menos un mail asociado a la causa.');", true);
                return;
            }
            int id = Convert.ToInt32(this.gvMailsAsociados.DataKeys[e.RowIndex].Value);
            MailsAsociadosPersonasBuscadas mail = MailsAsociadosPersonasBuscadasManager.GetItem(id);
            if (mail != null && MailsAsociadosPersonasBuscadasManager.Delete(mail))
            {
                MailsAsociadosPersonasBuscadasList MailsAsociados = new MailsAsociadosPersonasBuscadasList();
                MailsAsociados = MailsAsociadosPersonasBuscadasManager.GetListByPersonaBuscada(idPersonaDesaparecida, 1);
                this.gvMailsAsociados.DataSource = MailsAsociados;
                this.gvMailsAsociados.DataBind();
            }
            
        }

        protected void btnAgregarMailAsociado_Click(object sender, EventArgs e)
        {
            this.txtMailAsociado.Text = "";
            this.txtApellidoMailAsociado.Text = "";
            this.txtNombreMailAsociado.Text = "";
            this.pnlMailAsociado.Style.Remove("display");
            this.hfGestionMailAsociado_ModalPopupExtender.Show();
        }

        protected void btnCancelarMailAsociado_Click(object sender, EventArgs e)
        {
            this.pnlMailAsociado.Style.Add("display", "none");
        }

        protected void btnOkMailAsociado_Click(object sender, EventArgs e)
        {
            string mail=this.txtMailAsociado.Text.Trim();
            if (mail == "")
                this.cvMailAsociado.IsValid = false;
            if (this.txtNombreMailAsociado.Text.Trim() == "")
                this.cvNombreMailAsociado.IsValid = false;
            if (this.txtApellidoMailAsociado.Text.Trim() == "")
                this.cvApellidoMailAsociado.IsValid = false;
            if (mail != "" && mail.Contains('@'))
            {
                this.cvMailInvalido.IsValid = false;
               
            }
            if (mail.Contains('@') || mail.Length<3)
                    this.cvMailInvalido.IsValid = false;
            if (this.IsValid)
            {
               
                for (int i = 0; i < this.gvMailsAsociados.Rows.Count; i++)
                {
                    string mailEnBase = this.gvMailsAsociados.Rows[i].Cells[3].Text.Trim();
                    if (mail == mailEnBase)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El mail indicado ya se encuentra asociado a la causa.');", true);
                        return;
                    }
                }
                //****GUARDA MAIL ASOCIADO***********
                MailsAsociadosPersonasBuscadas mailAsociado = new MailsAsociadosPersonasBuscadas();
                mailAsociado.Apellido = this.txtApellidoMailAsociado.Text.Trim();
                mailAsociado.Nombre = this.txtNombreMailAsociado.Text.Trim();
                mailAsociado.Mail = this.txtMailAsociado.Text.Trim() + "@mpba.gov.ar";
                mailAsociado.FechaAlta = DateTime.Now;
                mailAsociado.idPersonaBuscada = idPersonaDesaparecida;
                mailAsociado.idTipoPersona = 1;
                mailAsociado.id = -1;
                mailAsociado.seleccionado = true;
                MailsAsociadosPersonasBuscadasManager.Save(mailAsociado);
                TraerMailsAsociados(idPersonaDesaparecida);
                this.hfGestionMailAsociado_ModalPopupExtender.Hide();
                this.pnlMailAsociado.Style.Add("display", "none");
            }
            
        }

      

        private void TraerMailsAsociados(int idDelito)
        {
            //********TRAE MAILS ASOCIADOS
            MailsAsociadosPersonasBuscadasList MailsAsociados = new MailsAsociadosPersonasBuscadasList();
            MailsAsociados = MailsAsociadosPersonasBuscadasManager.GetListByPersonaBuscada(idDelito, 1);
            this.gvMailsAsociados.DataSource = MailsAsociados;
            this.gvMailsAsociados.DataBind();
            if (state != FuncionesGrales.EstadoPrograma.Creando)
                this.btnAgregarMailAsociado.Visible = true;
            //*****************************
        }
        

        

     

      

    }
}

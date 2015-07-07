using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPBA.PersonasBuscadas.Bll;
using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.SIAC.Bll;
using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Mail;
using System.Xml;
using System.Data;

namespace MPBA.PersonasBuscadas.Web
{

    //*********************
    //PERMISOS:
    //PARA MODIFICAR solo pueden aquellos que pertenezcan al mismo depto jud
    //que la ipp que estan consultando
    //************************

    public partial class BusquedaHallada : System.Web.UI.Page
    {
        #region "VARIABLES":
        int idPersonaHallada = 0;//si es mayor a 0 estoy editando una pers. hallada existente
        //static MPBA.PersonasBuscadas.BusinessEntities.Busqueda PersonasBuscadas=null;//contiene los datos de la busqueda realizada
        FuncionesGrales.EstadoPrograma state = FuncionesGrales.EstadoPrograma.Creando; //C si se está creando una instancia, M si se está modificando y O si se está consultando
        System.Windows.Forms.BindingSource FotosGralesH; //me permite itirerar por la coleccion de fotos grales de la IPP en uso
        System.Windows.Forms.BindingSource FotosGralesBI; //me permite itirerar por la coleccion de fotos grales de la IPP en uso para la ficha de busq individual
        System.Windows.Forms.BindingSource FotosSeniasH; //me permite itirerar por la coleccion de fotos de senias part de la IPP en uso
        System.Windows.Forms.BindingSource FotosSeniasBI;//me permite itirerar por la coleccion de fotos de senias part de la IPP en uso para la ficha de busq indivicual;
        System.Windows.Forms.BindingSource FotosHuellasH;//me permite itirerar por la coleccion de fotos de las huellas dactilares de la IPP en uso para la ficha de busq indivicual;
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
                if (DeptoIppIgualQueOperador() == false && Session["idGrupo"].ToString().Trim()!="1")
                    state = FuncionesGrales.EstadoPrograma.Consultando;

            }
            FotosGralesH = Session["FotosGralesH"] == null ? new System.Windows.Forms.BindingSource() : (System.Windows.Forms.BindingSource)Session["FotosGralesH"];
            FotosSeniasH = Session["FotosSeniasH"] == null ? new System.Windows.Forms.BindingSource() : (System.Windows.Forms.BindingSource)Session["FotosSeniasH"];
            FotosGralesBI = Session["FotosGralesBI"] == null ? new System.Windows.Forms.BindingSource() : (System.Windows.Forms.BindingSource)Session["FotosGralesBI"];
            FotosSeniasBI = Session["FotosSeniasBI"] == null ? new System.Windows.Forms.BindingSource() : (System.Windows.Forms.BindingSource)Session["FotosSeniasBI"];
            FotosHuellasH = Session["FotosHuellasH"] == null ? new System.Windows.Forms.BindingSource() : (System.Windows.Forms.BindingSource)Session["FotosHuellasH"];
            TatuajesD = Session["TatuajesD"] == null ? new TatuajesPersonaList() : (TatuajesPersonaList)Session["TatuajesD"];
            TatuajesH = Session["TatuajesH"] == null ? new TatuajesPersonaList() : (TatuajesPersonaList)Session["TatuajesH"];
            TatuajesBI = Session["TatuajesBI"] == null ? new TatuajesPersonaList() : (TatuajesPersonaList)Session["TatuajesBI"];
            SeniasD = Session["SeniasD"] == null ? new SeniasParticularesList() : (SeniasParticularesList)Session["SeniasD"];
            SeniasH = Session["SeniasH"] == null ? new SeniasParticularesList() : (SeniasParticularesList)Session["SeniasH"];
            SeniasBI = Session["SeniasBI"] == null ? new SeniasParticularesList() : (SeniasParticularesList)Session["SeniasBI"];
            idPersonaHallada = Session["idPersonaHallada"] == null ? 0 : Convert.ToInt32(Session["idPersonaHallada"]);
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

                //MPBA.PersonasBuscadas.Web.MasterPage Master = (MPBA.PersonasBuscadas.Web.MasterPage)this.Master;
                //Master.MenuPrincipal.FindItem("Halladas").Selected = true;
                //Master.MenuPrincipal.Items[2].Selected = true;
                LimpiarControlesH();
                LimpiarControlesBI();
                int status = Convert.ToInt32(Request.QueryString["status"]);
                switch (status)
                {
                    case (int)FuncionesGrales.EstadoPrograma.Creando:
                        this.cartelConsultandoH.InnerText = "Alta Persona Hallada";
                        state = FuncionesGrales.EstadoPrograma.Creando;
                        break;
                    case (int)FuncionesGrales.EstadoPrograma.Modificando:
                        this.cartelConsultandoH.InnerText = "Modificación Persona Hallada";
                        state = FuncionesGrales.EstadoPrograma.Modificando;
                        break;
                }
                this.pnlComisarias.Style.Add("display", "none");
                this.pnlLugar.Style.Add("display", "none");
                this.pnlGuardarFotos.Style.Add("display", "none");
                this.pnlCartelAlert.Style.Add("display", "none");
                #region "Seteo controles UpdateProgess"
                Panel pnlWaitingOverlayH = (Panel)this.upWaitingH.FindControl("pnlWaitingOverlayH");
                Panel pnlWaitingH = (Panel)this.upWaitingH.FindControl("pnlWaitingH");
                Panel pnlWaitingFichaBID = (Panel)this.upWaitingFichaBID.FindControl("pnlWaitingFichaBID");
                Panel pnlWaitingOverlayFichaBID = (Panel)this.upWaitingFichaBID.FindControl("pnlWaitingOverlayFichaBID");
                Panel pnlWaitingOverlayBI = (Panel)this.upWaitingBI.FindControl("pnlWaitingOverlayBI");
                Panel pnlWaitingBI = (Panel)this.upWaitingBI.FindControl("pnlWaitingBI");
                Panel pnlWaitingOverlayResultadosBI = (Panel)this.upWaitingResultadosBI.FindControl("pnlWaitingOverlayResultadosBI");
                Panel pnlWaitingResultadosBI = (Panel)this.upWaitingResultadosBI.FindControl("pnlWaitingResultadosBI");
                Panel pnlWaitingComisaria = (Panel)this.upWaitingComisaria.FindControl("pnlWaitingComisaria");
                Panel pnlWaitingLocalidad = (Panel)this.upWaitingLocalidad.FindControl("pnlWaitingLocalidad");
                pnlWaitingOverlayH.CssClass = "overlay";
                pnlWaitingComisaria.CssClass = "loader";
                pnlWaitingLocalidad.CssClass = "loader";
                pnlWaitingH.CssClass = "loader";
                pnlWaitingFichaBID.CssClass = "loader";
                pnlWaitingOverlayBI.CssClass = "overlay";
                pnlWaitingBI.CssClass = "loader";
                pnlWaitingOverlayResultadosBI.CssClass = "overlay";
                pnlWaitingResultadosBI.CssClass = "loader";
                pnlWaitingOverlayFichaBID.CssClass = "overlay";
                this.pnlExtranaJurisdiccion.Enabled = false;
                this.pnlPersonaHallada.Enabled = false;
                this.txtIppBuscadoH.Focus();
                //myMaster = (SIAC.Web.MasterPage)this.Master;
                //myMaster.btnConfigurarMailPB.Visible = true;
                #endregion
                SetearGvPersonas();
                this.txtIppBuscadoH.Focus();
            }
        }

        private bool DeptoIppIgualQueOperador()
        {
            string miUfi = Session["miUfi"].ToString();
            int deptoMiUfi = PuntoGestionManager.GetItem(miUfi).idDepartamento;
            if (this.txtIppBuscadoH.Text.Trim().Length > 3)
            {
                if (this.txtIppBuscadoH.Text.Trim().Substring(0, 2) != deptoMiUfi.ToString("00"))
                    return false;
                else
                    return true;
            }
            else
                return false;
        }

        protected void btnFotoSigGeneralH_Click(object sender, EventArgs e)
        {
            AvanzarFoto(FuncionesGrales.TipoFoto.General);
        }

        protected void btnFotoSigSeniasH_Click(object sender, EventArgs e)
        {
            AvanzarFoto(FuncionesGrales.TipoFoto.SeniasParticulares);
        }

        protected void btnSigHuellasH_Click(object sender, EventArgs e)
        {
            AvanzarFoto(FuncionesGrales.TipoFoto.Huellas);
        }

        protected void btnFotoPrevGeneralH_Click(object sender, EventArgs e)
        {
            RetrocederFoto(FuncionesGrales.TipoFoto.General);
        }

        protected void btnFotoPrevSeniasH_Click(object sender, EventArgs e)
        {
            RetrocederFoto(FuncionesGrales.TipoFoto.SeniasParticulares);
        }

        protected void btnPrevHuellasH_Click(object sender, EventArgs e)
        {
            RetrocederFoto(FuncionesGrales.TipoFoto.Huellas);
        }



        protected void btnBorrarFotoSeniasH_Click(object sender, EventArgs e)
        {

            BorrarFoto(this.imgFotoSeniasH.ImageUrl, FuncionesGrales.TipoFoto.SeniasParticulares);
        }

        protected void btnBorrarFotoGralH_Click(object sender, EventArgs e)
        {
            BorrarFoto(this.imgFotoGeneralH.ImageUrl, FuncionesGrales.TipoFoto.General);
        }

        protected void btnBorrarHuellasH_Click(object sender, EventArgs e)
        {
            BorrarFoto(this.imgHuellasH.ImageUrl, FuncionesGrales.TipoFoto.Huellas);
        }
    

        protected void btnSubirFotoH_Click(object sender, EventArgs e)
        {
            this.lblMesgErrorFotoH.Visible = false;
            if (this.fuFotoUploaderH.HasFile)
            {
                FileInfo fiArchivo = new FileInfo(this.fuFotoUploaderH.PostedFile.FileName);
                if (fiArchivo.Extension.ToUpper() == ".JPG")
                {
                    if (this.fuFotoUploaderH.PostedFile.ContentLength < 1000000)
                    {
                        int len = this.fuFotoUploaderH.PostedFile.ContentLength;
                        Byte[] input = new Byte[len];
                        using (System.IO.Stream s = this.fuFotoUploaderH.PostedFile.InputStream)
                        {
                            s.Read(input, 0, len);
                            s.Close();
                            Session["imgPreview"] = input;
                            this.imgFotoPreview.ImageUrl = "";
                            this.imgFotoPreview.ImageUrl = "ImagenFoto.aspx?id=" + DateTime.Now.Second.ToString();
                            this.upImage.Update();
                            this.hfElegirTipoFotoH_ModalPopupExtender.Show();
                        }
                    }
                    else
                    {
                        this.lblMesgErrorFotoH.Text = "Error:La Imagen debe tener un tamaño inferior a 1 Mb.";
                        this.lblMesgErrorFotoH.Visible = true;
                    }

                }
                else
                {
                    this.imgFotoPreview.ImageUrl = "~/App_Images/SinFoto.GIF";
                    this.imgFotoPreview.Width = 80;
                    this.imgFotoPreview.Height = 100;
                    this.lblMesgErrorFotoH.Text = "Error:La Imagen debe ser en formato JPG.";
                    this.lblMesgErrorFotoH.Visible = true;
                    this.lblMesgErrorFotoH.Focus();
                }
            }
        }

        protected void gvResultadosDesapBI_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(this.gvResultadosDesapBI.SelectedValue.ToString());
            PersonasDesaparecidas pd = PersonasDesaparecidasManager.GetItem(id, true);
            LimpiarControlesFichaPersDesapBI();
            LlenarControlesFichaPersDesapBI(pd);
            //this.btnCancelarResultadosBI.CommandArgument = id.ToString();
            this.hfOkFichaBID.Value = id.ToString();
            this.hfGestionFichaPersDesapBI_ModalPopupExtender.Enabled = true;
            this.pnlResultadosBI.Visible = true;
            this.hfGestionFichaPersDesapBI_ModalPopupExtender.Show();
            this.hfAbrirResultadosBI_ModalPopupExtender1.Hide();
        }

        protected void btnAgregarPrimerTatuaje_Click(object sender, EventArgs e)
        {
            GridView gvTatuaje = null;
            string argumento = ((LinkButton)sender).CommandArgument;
            int idTatuaje = 0;
            int idUbicacionTatuaje = 0;
            MPBA.SIAC.BusinessEntities.TatuajesPersona tatuaje = new TatuajesPersona(); ;
            switch (argumento)
            {
                case "H":
                    idTatuaje = Convert.ToInt32(((DropDownList)this.gvTatuajesH.Controls[0].Controls[0].Controls[0].FindControl("ddlTatuajes")).SelectedValue);
                    idUbicacionTatuaje = Convert.ToInt32(((DropDownList)this.gvTatuajesH.Controls[0].Controls[0].Controls[0].FindControl("ddlUbicacionTatuaje")).SelectedValue);
                    if (idTatuaje == 0 || idUbicacionTatuaje == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Debe indicar el tatuaje y su ubicación.');", true);
                        return;
                    }
                    tatuaje.idTatuaje = idTatuaje;
                    tatuaje.idUbicacionTatuaje = idUbicacionTatuaje;
                    tatuaje.descripcion = Convert.ToString(((TextBox)this.gvTatuajesH.Controls[0].Controls[0].Controls[0].FindControl("descripcionTatuajePart")).Text);
                    tatuaje.id = -1;
                    tatuaje.idTablaDestino = 2;
                    tatuaje.idPersona = idPersonaHallada;
                    TatuajesH = new TatuajesPersonaList();
                    TatuajesH.Add(tatuaje);
                    Session["TatuajesH"] = TatuajesH;
                    this.gvTatuajesH.DataSource = TatuajesH;
                    this.gvTatuajesH.DataBind();
                    break;
                case "BI":
                    idTatuaje = Convert.ToInt32(((DropDownList)this.gvTatuajesBI.Controls[0].Controls[0].Controls[0].FindControl("ddlTatuajes")).SelectedValue);
                    idUbicacionTatuaje = Convert.ToInt32(((DropDownList)this.gvTatuajesBI.Controls[0].Controls[0].Controls[0].FindControl("ddlUbicacionTatuaje")).SelectedValue);
                    if (idTatuaje == 0 || idUbicacionTatuaje == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Debe indicar el tatuaje y su ubicación.');", true);
                        return;
                    }
                    tatuaje.idTatuaje = idTatuaje;
                    tatuaje.idUbicacionTatuaje = idUbicacionTatuaje;
                    tatuaje.id = -1;
                    tatuaje.idTablaDestino = 2;
                    tatuaje.idPersona = idPersonaHallada;
                    TatuajesBI = new TatuajesPersonaList();
                    TatuajesBI.Add(tatuaje);
                    Session["TatuajesBI"] = TatuajesBI;
                    this.gvTatuajesBI.DataSource = TatuajesBI;
                    this.gvTatuajesBI.DataBind();
                    break;
            }
            
            
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

            this.hfLugarHId.Value = this.gvLugar.SelectedValue.ToString();
            this.lblLugarHallazgoPersona.Text = this.gvLugar.SelectedRow.Cells[2].Text.Trim();
            this.lblPartidoHallazgo.Text = ((Label)this.gvLugar.SelectedRow.Cells[3].FindControl("lblPartidoGrid")).Text.Trim();
            this.lblProvinciaHallazgo.Text = ((Label)this.gvLugar.SelectedRow.Cells[4].FindControl("lblProvinciaGrid")).Text.Trim();
            this.pnlLugar.Style.Add("display", "none");
            this.hfAbrirLugar_ModalPopupExtender.Hide();
        }

        protected void ddlDepartamentosComisarias_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComisariaList cl = MPBA.SIAC.Bll.ComisariaManager.GetList(Convert.ToInt32(this.ddlDepartamentosComisarias.SelectedValue));
            this.gvComisarias.DataSource = cl;
            this.gvComisarias.DataBind();
        }

        protected void gvComisarias_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblComisariaPersonaH.Text = this.gvComisarias.SelectedRow.Cells[2].Text.Trim();
            //this.lblDepartamentoComisariaH.Text = this.ddlDepartamentosComisarias.SelectedItem.Text.Trim();
            this.hfComisariaHId.Value = this.gvComisarias.SelectedValue.ToString();
            if (this.gvWebServerCausaH.Rows.Count>0)
            {
                string celdaComisaria = this.gvWebServerCausaH.Rows[0].Cells[4].Text.Trim().ToLower();
                if (celdaComisaria!=this.lblComisariaPersonaH.Text.ToLower())
                    this.lblSeccionalNoCoincide.Style.Remove("display");
                else
                    this.lblSeccionalNoCoincide.Style.Add("display","none");
            }
            
            this.pnlComisarias.Style.Add("display", "none");
            this.hfAbrirComisarias_ModalPopupExtender.Hide();
        }

        protected void btnCancelarComisarias_Click(object sender, EventArgs e)
        {
            this.pnlComisarias.Style.Add("display", "none");
            this.hfAbrirComisarias_ModalPopupExtender.Hide();
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

        protected void btnGuardarBusquedaBI_Click(object sender, EventArgs e)
        {
            ValidarBI();
            if (this.IsValid)
            {
                GestionBusquedaIndividual(FuncionesGrales.TipoBusqueda.PersonaHallada, state);

                if (state == FuncionesGrales.EstadoPrograma.Creando)
                {
                    this.btnGuardarH.Style.Add("display", "none");
                    this.fuFotoUploaderH.Enabled = false;
                    this.pnlPersonaHallada.Enabled = false;
                }
                //FuncionesGrales.FotosGralesH.DataSource = PBFotosManager.GetList(idPersonaHallada, (int)FuncionesGrales.TipoBusqueda.PersonaHallada).FindAll(delegate(Fotos f) { return f.idTipoFoto == (int)FuncionesGrales.TipoFoto.General; });
                //FuncionesGrales.FotosSeniasH.DataSource = PBFotosManager.GetList(idPersonaHallada, (int)FuncionesGrales.TipoBusqueda.PersonaHallada).FindAll(delegate(Fotos f) { return f.idTipoFoto == (int)FuncionesGrales.TipoFoto.SeniasParticulares; });
                if (this.imgFotoGeneralH.ImageUrl.ToUpper().StartsWith("IMAGEHANDLER1"))
                {
                    string url = this.imgFotoGeneralH.ImageUrl;
                    //string foto = url.Substring(url.LastIndexOf("/") + 1);
                    //url = FuncionesGrales.RutaFotosGeneralesH + "/" + foto;
                    //this.imgFotoGeneralH.ImageUrl = url;
                    this.imgFotoGeneralH.OnClientClick = "window.open('FullSizeImage.aspx?url=" + url + "')";
                }
                else
                {
                    this.imgFotoGeneralH.ImageUrl = "~/App_Images/SinFoto.GIF";
                    this.imgFotoGeneralH.Width = 80;
                    this.imgFotoGeneralH.Height = 100;
                    this.imgFotoGeneralH.OnClientClick = null;
                }
                if (this.imgFotoSeniasH.ImageUrl.ToUpper().StartsWith("IMAGEHANDLER1"))
                {
                    string url = this.imgFotoSeniasH.ImageUrl;
                    //string foto = url.Substring(url.LastIndexOf("/") + 1);
                    //url = FuncionesGrales.RutaFotosSeniasD + "/" + foto;
                    //this.imgFotoSeniasD.ImageUrl = url;
                    this.imgFotoSeniasH.OnClientClick = "window.open('FullSizeImage.aspx?url=" + url + "')";
                }
                else
                {
                    this.imgFotoSeniasH.ImageUrl = "~/App_Images/SinFoto.GIF";
                    this.imgFotoSeniasH.Width = 80;
                    this.imgFotoSeniasH.Height = 100;
                    this.imgFotoSeniasH.OnClientClick = null;
                }
                if (this.imgHuellasH.ImageUrl.ToUpper().StartsWith("IMAGEHANDLER1"))
                {
                    string url = this.imgHuellasH.ImageUrl;
                    //string foto = url.Substring(url.LastIndexOf("/") + 1);
                    //url = FuncionesGrales.RutaFotosGeneralesH + "/" + foto;
                    //this.imgFotoGeneralH.ImageUrl = url;
                    this.imgHuellasH.OnClientClick = "window.open('FullSizeImage.aspx?url=" + url + "')";
                }
                else
                {
                    this.imgHuellasH.ImageUrl = "~/App_Images/SinFoto.GIF";
                    this.imgHuellasH.Width = 80;
                    this.imgHuellasH.Height = 100;
                    this.imgHuellasH.OnClientClick = null;
                }

            }
            else
            {
              
                this.hfAbrirBusquedaIndividual_ModalPopupExtender.Show();
            }
            btnGuardarBusquedaBI.Enabled = true;
            btnGuardarBusquedaBI.Text = "Guardar Búsqueda";
        }

        protected void gvTatuajes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.gvTatuajesH.ShowFooter = true;
            e.Cancel = true;
            string tipoBusqueda = "";
            GridView gvTatuajes = (GridView)sender;
            switch (gvTatuajes.ID)
            {
                case "gvTatuajesD":
                    tipoBusqueda = "D";
                    break;
                case "gvTatuajesH":
                    tipoBusqueda = "H";
                     gvTatuajes.EditIndex = -1;
            gvTatuajes.DataSource = TatuajesH;
            gvTatuajes.DataBind();
                    break;
                case "gvTatuajesB":
                    tipoBusqueda = "B";
                    break;
                case "gvTatuajesBI":
                    tipoBusqueda = "BI";
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
                    break;
                case "gvTatuajesH":
                    tipoBusqueda = "H";
                    gvTatuajes.EditIndex = -1;
                    TatuajesH.RemoveAt(e.RowIndex);
                    gvTatuajes.DataSource = TatuajesH;
                    gvTatuajes.DataBind();
                    break;
                case "gvTatuajesBI":
                    tipoBusqueda = "BI";
                    gvTatuajesBI.EditIndex = -1;
                    TatuajesBI.RemoveAt(e.RowIndex);
                    gvTatuajesBI.DataSource = TatuajesBI;
                    gvTatuajes.DataBind();
                    break;
                case "gvTatuajesB":
                    tipoBusqueda = "B";
                    break;
            }
         

        }

        protected void gvTatuajes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            
            this.gvTatuajesH.ShowFooter = false;
            int id;
            //string tipoBusqueda = "";
            GridView gvTatuajes = (GridView)sender;
            switch (gvTatuajes.ID)
            {
                case "gvTatuajesD":
                    //tipoBusqueda = "D";
                    break;
                case "gvTatuajesH":
                    //tipoBusqueda = "H";
                    gvTatuajes.EditIndex = e.NewEditIndex;
                    id = Convert.ToInt32(gvTatuajes.DataKeys[e.NewEditIndex].Value);
                    gvTatuajes.DataSource = TatuajesH;
                    gvTatuajes.DataBind();
                    break;
                case "gvTatuajesB":
                    //tipoBusqueda = "B";
                    break;
                case "gvTatuajesBI":
                    gvTatuajesBI.EditIndex = e.NewEditIndex;
                    id = Convert.ToInt32(gvTatuajesBI.DataKeys[e.NewEditIndex].Value);
                    gvTatuajesBI.DataSource = TatuajesBI;
                    gvTatuajesBI.DataBind();
                    break;
            }

            

        }

        protected void gvTatuajes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            this.gvTatuajesH.ShowFooter = true;
            string tipoBusqueda = "";
            int idTatuaje;
            int idUbicacionTatuaje;
            GridView gvTatuajes = (GridView)sender;
            MPBA.SIAC.BusinessEntities.TatuajesPersona tatuaje;
            switch (gvTatuajes.ID)
            {
                case "gvTatuajesD":
                    tipoBusqueda = "D";
                    break;
                case "gvTatuajesH":
                    tipoBusqueda = "H";
                    idTatuaje = Convert.ToInt32(((DropDownList)(gvTatuajes.Rows[e.RowIndex].Cells[3].FindControl("ddlTatuajes"))).SelectedValue);
                    idUbicacionTatuaje = Convert.ToInt32(((DropDownList)(gvTatuajes.Rows[e.RowIndex].Cells[4].FindControl("ddlUbicacionTatuaje"))).SelectedValue);
                    if (idTatuaje == 0 || idUbicacionTatuaje == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Debe indicar el tatuaje y su ubicación.');", true);
                        return;
                    }
                    tatuaje = TatuajesH[e.RowIndex];
                    tatuaje.idTatuaje = idTatuaje;
                    tatuaje.idUbicacionTatuaje = idUbicacionTatuaje;
                    tatuaje.descripcion = Convert.ToString(((TextBox)(gvTatuajes.Rows[e.RowIndex].Cells[5].FindControl("descripcionTatuajePart"))).Text);
                    tatuaje.idPersona = idPersonaHallada;
                    gvTatuajes.EditIndex = -1;
                    gvTatuajes.DataSource = TatuajesH;
                    gvTatuajes.DataBind();
                    break;
                case "gvTatuajesB":
                    tipoBusqueda = "B";
                    break;
                case "gvTatuajesBI":
                    tipoBusqueda = "BI";
                    idTatuaje = Convert.ToInt32(((DropDownList)(gvTatuajesBI.Rows[e.RowIndex].Cells[3].FindControl("ddlTatuajes"))).SelectedValue);
                    idUbicacionTatuaje = Convert.ToInt32(((DropDownList)(gvTatuajesBI.Rows[e.RowIndex].Cells[4].FindControl("ddlUbicacionTatuaje"))).SelectedValue);
                    if (idTatuaje == 0 || idUbicacionTatuaje == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Debe indicar el tatuaje y su ubicación.');", true);
                        return;
                    }
                    tatuaje = TatuajesBI[e.RowIndex];
                    tatuaje.idTatuaje = idTatuaje;
                    tatuaje.idUbicacionTatuaje = idUbicacionTatuaje;
                    tatuaje.idPersona = idPersonaHallada;
                    gvTatuajesBI.EditIndex = -1;
                    gvTatuajesBI.DataSource = TatuajesBI;
                    gvTatuajesBI.DataBind();
                    break;
            }
 

        }

        protected void btnAgregarTatuaje_Click(object sender, EventArgs e)
        {

            GridView gvTatuajes = null;
            string argumento = ((LinkButton)sender).CommandArgument;
            MPBA.SIAC.BusinessEntities.TatuajesPersona tatuaje = new TatuajesPersona();
            switch (argumento)
            {
                case "H":
                    gvTatuajes = this.gvTatuajesH;
                    int idTatuaje = Convert.ToInt32(((DropDownList)gvTatuajes.FooterRow.FindControl("ddlTatuajeInsert")).SelectedValue);
                    int idUbicacionTatuaje = Convert.ToInt32(((DropDownList)gvTatuajes.FooterRow.FindControl("ddlUbicacionTatuajeInsert")).SelectedValue);
                    if (idTatuaje == 0 || idUbicacionTatuaje == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Debe indicar el tatuaje y su ubicación.');", true);
                        return;
                    }
                    tatuaje = new TatuajesPersona();
                    tatuaje.idTatuaje = idTatuaje;
                    tatuaje.idUbicacionTatuaje = idUbicacionTatuaje;
                    tatuaje.descripcion = Convert.ToString(((TextBox)gvTatuajes.FooterRow.FindControl("descripcionTatuajeInsert")).Text);
                    tatuaje.id = -1;
                    tatuaje.idTablaDestino = 2;
                    TatuajesH.Add(tatuaje);
                    gvTatuajes.DataSource = TatuajesH;
                    gvTatuajes.DataBind();
                    break;
                case "D":
                    //gvTatuajes = this.gvTatuajesD;
                    break;
                case "B":
                    //gvTatuajes = this.gvTatuajesB;
                    break;
                case "BI":
                    gvTatuajes = this.gvTatuajesBI;
                    idTatuaje = Convert.ToInt32(((DropDownList)gvTatuajesBI.FooterRow.FindControl("ddlTatuajeInsert")).SelectedValue);
                    idUbicacionTatuaje = Convert.ToInt32(((DropDownList)gvTatuajesBI.FooterRow.FindControl("ddlUbicacionTatuajeInsert")).SelectedValue);
                    if (idTatuaje == 0 || idUbicacionTatuaje == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Debe indicar el tatuaje y su ubicación.');", true);
                        return;
                    }
                    tatuaje = new TatuajesPersona();
                    tatuaje.idTatuaje = idTatuaje;
                    tatuaje.idUbicacionTatuaje = idUbicacionTatuaje;
                    tatuaje.id = -1;
                    tatuaje.idTablaDestino = 2;
                    TatuajesBI.Add(tatuaje);
                    //Session["SeniasBI"] = "";
                    //Session["SeniasBI"] = SeniasBI;
                    gvTatuajesBI.DataSource = TatuajesBI;
                    gvTatuajesBI.DataBind();
                    break;
            }
            //int idTatuaje = Convert.ToInt32(((DropDownList)gvTatuajes.FooterRow.FindControl("ddlTatuajeInsert")).SelectedValue);
            //int idUbicacionTatuaje = Convert.ToInt32(((DropDownList)gvTatuajes.FooterRow.FindControl("ddlUbicacionTatuajeInsert")).SelectedValue);
            //if (idTatuaje == 0 || idUbicacionTatuaje == 0)
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Debe indicar el tatuaje seña y su ubicación.');", true);
            //    return;
            //}
            //MPBA.SIAC.BusinessEntities.TatuajesPersona tatuaje = new TatuajesPersona();
            //tatuaje.idTatuaje = idTatuaje;
            //tatuaje.idUbicacionTatuaje = idUbicacionTatuaje;
            //tatuaje.descripcion = Convert.ToString(((TextBox)gvTatuajes.FooterRow.FindControl("descripcionTatuajeInsert")).Text);
            //tatuaje.id = -1;
            //tatuaje.idTablaDestino = 2;
            //if (argumento == "H")
            //{
            //    TatuajesH.Add(tatuaje);
            //    gvTatuajes.DataSource = TatuajesH;
            //}
            //if (argumento == "BI")
            //{
            //    TatuajesBI.Add(tatuaje);
            //    gvTatuajes.DataSource = TatuajesBI;
            //}
            //gvTatuajes.DataBind();

        }
        
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

        protected void gvResultadosDesapBI_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idPersona = Convert.ToInt32(this.gvResultadosDesapBI.DataKeys[e.RowIndex].Value);
            BusquedasFavoritas bf = BusquedasFavoritasManager.GetItem(idPersona, (int)FuncionesGrales.TipoBusqueda.PersonaDesaparecida);
            bool borroBien = BusquedasFavoritasManager.Delete(bf);
            this.gvResultadosDesapBI.Rows[e.RowIndex].Visible = false;
        }

        protected void btnCancelarResultadosBI_Click(object sender, EventArgs e)
        {
            this.gvResultadosDesapBI.DataSource = null;
            this.gvResultadosDesapBI.DataBind();
            this.lblResultadosBI.Text = "RESULTADOS DE LA BUSQUEDA";
            this.lblLeyendaBI.Visible = true;
            this.lblLeyendaVerdeBI.Visible = true;
            this.hfAbrirResultadosBI_ModalPopupExtender1.Hide();
        }

        protected void btnActualizarBusqueda_Click(object sender, EventArgs e)
        {

        }

      
        protected void btnCerrarBI_Click(object sender, EventArgs e)
        {

            this.hfAbrirBusquedaIndividual_ModalPopupExtender.Hide();
        }

        private int PrimeraFilaSinBajaEnGvPersonas()
        {
            int filaSinBaja = -1;
            if (this.gvPersonasH.Rows.Count > 0)
            {

                //this.gvPersonasD.SelectedIndex = 0;

                for (int i = 0; i < this.gvPersonasH.Rows.Count; i++)
                {
                    GridView gvr = this.gvPersonasH;
                    CheckBox chkBaja = (CheckBox)gvr.Rows[i].Cells[6].FindControl("Baja");
                    if (!chkBaja.Checked && filaSinBaja == -1)
                    {
                        filaSinBaja = i;
                        //gvr.SelectedIndex = i;
                    }
                }
            }
            return filaSinBaja;
        }

        protected void btnBuscarIppH_Click(object sender, EventArgs e)
        {
            LimpiarControlesH();
            LimpiarControlesBI();
            LimpiarControlesExtJur();
            string ipp = "";
            this.gvPersonasH.DataSource = "";
            this.gvPersonasH.DataBind();
            List<PersonasHalladas> myPersonas = null;
            if (this.tcTipoJurisdiccion.ActiveTab == this.tpPJ)
            {

                ipp = this.txtIppBuscadoH.Text.Trim();
                if (ipp.Length == 0)
                {
                    this.cvIppH.IsValid = false;
                    return;
                }
                if (ipp.Length != 12)
                {
                    string msg = "Cantidad incorrecta de dígitos. (Deberían ser 12).";
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('" + msg + "');", true);
                    return;
                }
                this.pnlExtranaJurisdiccion.Visible = false;
                myPersonas = PersonasHalladasManager.GetListByIPP(ipp).FindAll(delegate(PersonasHalladas ph) { return (ph.esExtJurisdiccion==null ||ph.esExtJurisdiccion==false); });
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
                myPersonas = PersonasHalladasManager.GetListByIPP(ipp).FindAll(delegate(PersonasHalladas ph) { return (ph.esExtJurisdiccion!=null && ph.esExtJurisdiccion==true); });


            }

            bool esExtJur = this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur;
                if (myPersonas.Count > 0)
                {

                    this.gvPersonasH.DataSource = myPersonas;
                    this.gvPersonasH.DataBind();
                    this.gvPersonasH.Rows[0].BackColor = Color.FromName("#13507d");
                    this.divPersonasH.Style.Remove("display");
                    int primeraFilaSinBaja = PrimeraFilaSinBajaEnGvPersonas();
                    int idDelito = 0;
                    if (primeraFilaSinBaja > -1)
                        this.gvPersonasH.SelectedIndex = primeraFilaSinBaja;
                    else
                        this.gvPersonasH.SelectedIndex = 0;
                    idDelito = Convert.ToInt32(this.gvPersonasH.SelectedDataKey.Value);
                    TraerMailsAsociados(idDelito);
                    BuscarIpp(idDelito, ipp, esExtJur);
                    
                }
                else
                {
                    this.divPersonasH.Style.Add("display", "none");
                    BuscarIpp(-1,ipp,esExtJur);
                }



                if (this.gvPersonasH.Rows.Count > 0)
                {

                    for (int i = 0; i < this.gvPersonasH.Rows.Count; i++)
                    {
                        GridView gvr = this.gvPersonasH;
                        Button btnBorrarPersonaH = (Button)gvr.FindControl("btnBorrarPersonaH");
                        if (btnBorrarPersonaH != null)
                        {
                            if (state == FuncionesGrales.EstadoPrograma.Consultando)
                                btnBorrarPersonaH.Style.Add("display", "none");
                            else
                                btnBorrarPersonaH.Style.Remove("display");
                        }
                    }
                }
               
               
            SetearGvPersonas();
        }

        private void TraerMailsAsociados(int idDelito)
        {
            //********TRAE MAILS ASOCIADOS
            MailsAsociadosPersonasBuscadasList MailsAsociados = new MailsAsociadosPersonasBuscadasList();
            MailsAsociados = MailsAsociadosPersonasBuscadasManager.GetListByPersonaBuscada(idDelito, 2);
            this.gvMailsAsociados.DataSource = MailsAsociados;
            this.gvMailsAsociados.DataBind();
            if (state != FuncionesGrales.EstadoPrograma.Creando)
                this.btnAgregarMailAsociado.Visible = true;
            //*****************************
        }

        private void BuscarIpp(int idDelito,string ipp, bool esExtJur)
        {
            this.btnGuardarH.Style.Remove("display");
            bool esIppExistente = EsIppExistente(ipp, FuncionesGrales.TipoBusqueda.PersonaHallada, esExtJur);
            if (esIppExistente)
            {
                //Solo se puede modificar la ipp perteneciente al mismo depto jud de quien consulta
                if (state == FuncionesGrales.EstadoPrograma.Modificando)
                {
                    if (DeptoIppIgualQueOperador() == false && Session["idGrupo"].ToString().Trim()!="1")
                        state = FuncionesGrales.EstadoPrograma.Consultando;

                }
                if (state != FuncionesGrales.EstadoPrograma.Modificando &&
              state != FuncionesGrales.EstadoPrograma.Consultando)
                {
                    LimpiarControlesH();
                    this.fuFotoUploaderH.Enabled = false;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('La causa ya se encuentra cargada.');", true);
                    //this.lblMensajeCartelAlert.Text = "La persona ya se encuentra cargada";
                    //this.hfCartelAlert_ModalPopupExtender.Show();
                    this.gvMailsAsociados.Columns.Clear();
                    this.gvMailsAsociados.DataSource = "";
                    this.gvMailsAsociados.DataBind();
                    this.btnGuardarH.Style.Add("display", "none");
                    this.txtIppBuscadoH.Focus();
                    return;
                }

          

                //state = FuncionesGrales.EstadoPrograma.Modificando;
                //if (state == FuncionesGrales.EstadoPrograma.Consultando)
                //    this.pnlPersonaHallada.Enabled = false;
                PersonasHalladas myPH = PersonasHalladasManager.GetItem(idDelito, true);
                LlenarControlesH(myPH);
                if (state == FuncionesGrales.EstadoPrograma.Creando || state == FuncionesGrales.EstadoPrograma.Modificando)
                {
                    this.btnGuardarH.Style.Remove("display");
                    this.btnAgregarPersonaH.Style.Remove("display");
                    this.pnlPersonaHallada.Enabled = true;
                }
                else
                {
                    this.btnGuardarH.Style.Add("display", "none");
                    this.btnAgregarPersonaH.Style.Add("display", "none");
                    this.pnlPersonaHallada.Enabled = false;
                }

                if (!esExtJur)
                    BuscarIppEnWebService(this.txtIppBuscadoH.Text.Trim(), FuncionesGrales.TipoBusqueda.PersonaHallada);
                LlenarControlesBI(myPH.busqueda);
                this.btnVerCriterioBusquedaH.CommandArgument = myPH.busqueda.Id.ToString();
                this.btnVerResultadosH.CommandArgument = myPH.Id.ToString();
                Session["idPersonaHallada"] = myPH.Id;
                this.btnImprimirH.Style.Remove("display");
                //this.btnImprimirH.OnClientClick = "window.open('WebForm2.aspx?id=" + idPersonaHallada + "')";
                string esExJur= this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur?"1":"0";
                this.btnImprimirH.OnClientClick = "window.open('ReporteFormH.aspx?Ipp=" + myPH.Ipp + "&id=" + idPersonaHallada.ToString() + "&esExJur="+esExJur+"')";
                this.btnVerCriterioBusquedaH.Style.Remove("display");
                this.btnVerResultadosH.Style.Remove("display");
            }
            else
            {
                //this.cartelConsultandoH.InnerText = "CREANDO PERSONA HALLADA";
                //this.cartelConsultandoH.Style.Add("color", "Yellow");
                if (state != FuncionesGrales.EstadoPrograma.Creando)
                {
                    LimpiarControlesH();
                    //this.lblMensajeCartelAlert.Text = "La persona no se encuentra cargada";
                    //this.hfCartelAlert_ModalPopupExtender.Show();
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('La causa no se encuentra cargada.');", true);
                    this.btnGuardarH.Style.Add("display", "none");

                    this.txtIppBuscadoH.Focus();
                    return;
                }
                this.pnlPersonaHallada.Enabled = true;
                this.pnlExtranaJurisdiccion.Enabled = true;
                BuscarIppEnWebService(this.txtIppBuscadoH.Text.Trim(), FuncionesGrales.TipoBusqueda.PersonaHallada);
                //this.pnlIPPH.Enabled = false;
                //this.lblIppH.Text = this.txtIppBuscadoH.Text.Trim();
                //state = FuncionesGrales.EstadoPrograma.Creando;
                this.btnImprimirH.Style.Add("display", "none");
                this.btnVerCriterioBusquedaH.Style.Add("display", "none");
                this.btnVerResultadosH.Style.Add("display", "none");
                idPersonaHallada = 0;

            }
            //this.btnGuardarH.Style.Remove("display");
            //this.btnImprimirH.Style.Remove("display");
            this.cartelConsultandoH.Style.Remove("display");
            this.fuFotoUploaderH.Enabled = true;
        }
        
        protected void btnGuardarH_Click(object sender, EventArgs e)
        {
            this.lblGuardoExitoH.Visible = false;
            //this.mevtxtCoincidencia.Enabled = true;
            ValidarH();
            if (this.IsValid)
            {

               // if (state == FuncionesGrales.EstadoPrograma.Creando)//estoy creando una persona hallada
                LimpiarControlesBI();
                if (idPersonaHallada > 0)

                    LlenarControlesBI(BusquedaManager.GetItem(Convert.ToInt32(this.btnVerCriterioBusquedaH.CommandArgument), true));
                else
                {
                    this.txtApellidoBI.Text = this.txtApellidoH.Text;
                    this.txtNombresBI.Text = this.txtNombresH.Text;
                    this.txtDNIBI.Text = this.txtDNI.Text;

                }
                
                //this.hfBusquedaIndividual.Value = TipoBusqueda.PersonaHallada.ToString();
                LlenarControlesPersonaHalladasEnBI();
                this.btnGuardarBusquedaBI.Style.Remove("display");
                this.btnCerrarBI.CommandArgument = "1";
                this.hfAbrirBusquedaIndividual_ModalPopupExtender.Show();
            }
            //this.mevtxtCoincidencia.Enabled = false;
        }
        
        protected void btnBorrarH_Click(object sender, EventArgs e)
        {
            MPBA.PersonasBuscadas.BusinessEntities.PersonasHalladas personaHallada = MPBA.PersonasBuscadas.Bll.PersonasHalladasManager.GetItem(idPersonaHallada);
            if (MPBA.PersonasBuscadas.Bll.PersonasHalladasManager.Delete(personaHallada))
            {
                LimpiarControlesH();
                ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "updatealert", @"<script language='javascript'>setTimeout(""alert('Registro borrado correctamente.')"",1000); </script>");
            }
        }

        protected void btnVerResultadosH_Click(object sender, EventArgs e)
        {

            GestionBusquedaIndividual(FuncionesGrales.TipoBusqueda.PersonaHallada, FuncionesGrales.EstadoPrograma.Consultando);
        }
        
        protected void btnVerCriterioBusquedaH_Click(object sender, EventArgs e)
        {
            PersonasHalladas personasHalladas = PersonasHalladasManager.GetItem(Convert.ToInt32(this.btnVerResultadosH.CommandArgument), true);
            LimpiarControlesVerCriterioBI();
            this.lblGuardoExitoH.Visible = false;
            if (personasHalladas != null)
                LlenarControlesVerPersonaHalladasCriterioEnBI();
            LlenarControlesVerCriterioBI(BusquedaManager.GetItem(Convert.ToInt32(this.btnVerCriterioBusquedaH.CommandArgument), true));
            this.hfVerCriterioBI_ModalPopupExtender.Show();
        }

        protected void btnCerrarBID_Click(object sender, EventArgs e)
        {
            //FuncionesGrales.
         
            this.hfGestionFichaPersDesapBI_ModalPopupExtender.Hide();
            this.hfAbrirResultadosBI_ModalPopupExtender1.Show();
        }

        protected void btnBuscarComisariaH_Click(object sender, ImageClickEventArgs e)
        {
            this.hfAbrirComisarias_ModalPopupExtender.Enabled = true;
            this.hfLugarElegido.Value = "h";
            this.hfComisarias.Value = "H";
            this.pnlComisarias.Visible = true;
            this.hfAbrirComisarias_ModalPopupExtender.Show();
        }

        protected void btnBuscarLocalidadH_Click(object sender, ImageClickEventArgs e)
        {
            this.hfAbrirLugar_ModalPopupExtender.Enabled = true;
            this.hfLugarElegido.Value = "H";
            this.pnlLugar.Visible = true;
            this.hfAbrirLugar_ModalPopupExtender.Show();
            this.txtLugar.Focus();
        }

        protected void btnLimpiarH_Click(object sender, EventArgs e)
        {
           
            LimpiarControlesH();
            LimpiarControlesBI();
            LimpiarControlesExtJur();
            this.txtIppBuscadoH.Text = "";
            this.txtCausa.Text = "";
            this.pnlIPPH.Enabled = true;
            this.pnlPersonaHallada.Enabled = false;
            this.pnlExtranaJurisdiccion.Enabled = false;
            this.txtIppBuscadoH.Focus();
        }
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session["imgPreview"] = null;
            //myMaster.btnConfigurarMailPB.Visible = false;
            Session["moduloActual"] = null;//no resalta nada en el menu
            Response.Redirect("~/Home.aspx");
        }
        #endregion

        #region "METODOS":
      
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
                }
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
            this.lblDNINumeroBID.Text = "";
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
            if (personaDesaparecida.DNI != null)
                this.lblDNINumeroBID.Text = personaDesaparecida.DNI.Trim();
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
                this.lblSeniaParticularBI.Visible = true;
            }
            else
                this.lblSeniaParticularBI.Visible = false;
    
        }
        
        private string CopiarFotoADirTmp(string fullNameFotoDestino)
        {

            Byte[] input = (Byte[])Session["imgPreview"];
            using (MemoryStream ms = new MemoryStream(input))
            {
                using (System.Drawing.Image imgPhoto = System.Drawing.Image.FromStream(ms))
                {
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
                }
            }
            return fullNameFotoDestino;
        }

        protected void btnOkTipoFoto_Click(object sender, EventArgs e)
        {


            ////this.btnSubirFotoD.Enabled = false;
            //this.fuFotoUploaderD.SaveAs(Server.MapPath(FuncionesGrales.RutaFotosTemp + "/" + this.fuFotoUploaderD.FileName));
            switch (this.rblTipoFotos.SelectedValue)
            {
                case "1":

                    SubirFoto(FuncionesGrales.TipoBusqueda.PersonaHallada, FuncionesGrales.TipoFoto.General);
                    break;
                case "2":

                    SubirFoto(FuncionesGrales.TipoBusqueda.PersonaHallada, FuncionesGrales.TipoFoto.SeniasParticulares);
                    break;
                case "3":

                    SubirFoto(FuncionesGrales.TipoBusqueda.PersonaHallada, FuncionesGrales.TipoFoto.Huellas);
                    break;
            }

            Session["imgPreview"] = null;
            this.imgFotoPreview.ImageUrl = "~/App_Images/SinFoto.GIF";
            this.upImage.Update();
            this.upSubirFotoGeneralH.Update();
            this.imgFotoGeneralH.Focus();
        }
        
        protected void btnAgregarPrimeraSenia_Click(object sender, EventArgs e)
        {
            GridView gvSenasPart = null;
            string argumento = ((LinkButton)sender).CommandArgument;
            int idSenia = 0;
            int idUbicacionSenia = 0;
            switch (argumento)
            {
                case "H":
                    gvSenasPart = this.gvSenasPartH;
                    idSenia = Convert.ToInt32(((DropDownList)gvSenasPart.Controls[0].Controls[0].Controls[0].FindControl("ddlSenasParticulares")).SelectedValue);
                    idUbicacionSenia = Convert.ToInt32(((DropDownList)gvSenasPart.Controls[0].Controls[0].Controls[0].FindControl("ddlUbicacionSenasPart")).SelectedValue);
                    if (idSenia == 0 || idUbicacionSenia == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Debe indicar la seña y su ubicación.');", true);
                        return;
                    }
                    SeniasParticulares sena = new SeniasParticulares();
                    sena.idSeniaParticular = idSenia;
                    sena.idUbicacionSeniaParticular = idUbicacionSenia;
                    sena.descripcion = Convert.ToString(((TextBox)(gvSenasPart.Controls[0].Controls[0].Controls[0].FindControl("descripcionSenaPart"))).Text);
                    sena.id = -1;
                    sena.idTablaDestino = 2;
                    SeniasH = new SeniasParticularesList();
                    SeniasH.Add(sena);
                    Session["SeniasH"] = SeniasH;
                    gvSenasPart.DataSource = SeniasH;
                    gvSenasPart.DataBind();
                    break;
                case "BI":
                    gvSenasPart = this.gvSenasPartBI;
                    idSenia = Convert.ToInt32(((DropDownList)gvSenasPart.Controls[0].Controls[0].Controls[0].FindControl("ddlSenasParticularesBI")).SelectedValue);
                    idUbicacionSenia = Convert.ToInt32(((DropDownList)gvSenasPart.Controls[0].Controls[0].Controls[0].FindControl("ddlUbicacionSenasPartBI")).SelectedValue);
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
                    sena.idTablaDestino = 1;
                    SeniasBI = new SeniasParticularesList();
                    SeniasBI.Add(sena);
                    Session["SeniasBI"] = SeniasBI;
                    gvSenasPart.DataSource = SeniasBI;
                    gvSenasPart.DataBind();
                    break;
            }

            //if (argumento == "BI")
            //{
            //    gvSenasPart.ShowFooter = false;
            //    gvSenasPart.DataBind();
            //}

        }

        protected void btnAgregarSenia_Click(object sender, EventArgs e)
        {
            GridView gvSenasPart = null;
            string argumento = ((LinkButton)sender).CommandArgument;
            switch (argumento)
            {
                case "H":
                    gvSenasPart = this.gvSenasPartH;
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
                    sena.descripcion = Convert.ToString(((TextBox)gvSenasPart.FooterRow.FindControl("descripcionInsert")).Text);
                    sena.id = -1;
                    sena.idTablaDestino = 2;
                    SeniasH.Add(sena);
                    Session["SeniasH"] = "";
                    Session["SeniasH"] = SeniasH;
                    gvSenasPart.DataSource = SeniasH;
                    gvSenasPart.DataBind();
                    break;
                case "BI":
                    //return;//no permito que se busque por mas de una sena
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
                    sena.id = -1;
                    sena.idTablaDestino = 2;
                    SeniasBI.Add(sena);
                    Session["SeniasBI"] = "";
                    Session["SeniasBI"] = SeniasBI;
                    gvSenasPart.DataSource = SeniasBI;
                    gvSenasPart.DataBind();
                    break;
            }
            
        }

        protected void gvSenasPart_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //this.gvSenasPartH.ShowFooter = false;
            //string tipoBusqueda = "";
            GridView gvSenasPart = (GridView)sender;
            int id = 0;
            switch (gvSenasPart.ID)
            {
                case "gvSenasPartD":
                    //tipoBusqueda = "D";
                    break;
                case "gvSenasPartH":
                    //tipoBusqueda = "H";
                    this.gvSenasPartH.ShowFooter = false;
                    gvSenasPart.EditIndex = e.NewEditIndex;
                    id = Convert.ToInt32(gvSenasPart.DataKeys[e.NewEditIndex].Value);
                    gvSenasPart.DataSource = SeniasH;
                    gvSenasPart.DataBind();
                    break;
                case "gvSenasPartB":
                    //tipoBusqueda = "B";
                    break;
                case "gvSenasPartBI":
                    //tipoBusqueda = "BI";
                    this.gvSenasPartBI.ShowFooter = false;
                    gvSenasPart.EditIndex = e.NewEditIndex;
                    id = Convert.ToInt32(gvSenasPart.DataKeys[e.NewEditIndex].Value);
                    gvSenasPart.DataSource = SeniasBI;
                    gvSenasPart.DataBind();
                    break;
            }

            



        }

        protected void gvSenasPart_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView gvSenasPart = (GridView)sender;
            gvSenasPart.ShowFooter = true;
            e.Cancel = true;
            string tipoBusqueda = "";
            switch (gvSenasPart.ID)
            {
                case "gvSenasPartD":
                    tipoBusqueda = "D";
                    break;
                case "gvSenasPartH":
                    tipoBusqueda = "H";
                    gvSenasPart.EditIndex = -1;
            gvSenasPart.DataSource = SeniasH;
            gvSenasPart.DataBind();
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
            GridView gvSenasPart = (GridView)sender;
            int idSenia = 0;
            int idUbicacionSenia = 0;
           
            
            SeniasParticulares senia;
            switch (gvSenasPart.ID)
            {
                case "gvSenasPartD":
                    tipoBusqueda = "D";
                    break;
                case "gvSenasPartH":
                    this.gvSenasPartH.ShowFooter = true;
                    tipoBusqueda = "H";
                    senia = SeniasH[e.RowIndex];
                    idSenia = Convert.ToInt32(((DropDownList)(gvSenasPart.Rows[e.RowIndex].Cells[3].FindControl("ddlSeniaPart"))).SelectedValue);;
                    idUbicacionSenia = Convert.ToInt32(((DropDownList)(gvSenasPart.Rows[e.RowIndex].Cells[4].FindControl("ddlUbicacionSenaPart"))).SelectedValue);
                    if (idSenia == 0 || idUbicacionSenia == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Debe indicar la seña y su ubicación.');", true);
                        return;
                    }
                    senia.idSeniaParticular = idSenia;
                    senia.idUbicacionSeniaParticular = idUbicacionSenia;
                    senia.descripcion = Convert.ToString(((TextBox)(gvSenasPart.Rows[e.RowIndex].Cells[5].FindControl("descripcionSenaPart"))).Text);
                    SeniasH[e.RowIndex] = senia;
                    Session["SeniaH"] = SeniasH;
                    gvSenasPart.EditIndex = -1;
                    gvSenasPart.DataSource = SeniasH;
                    gvSenasPart.DataBind();
                    break;
                case "gvSenasPartB":
                    tipoBusqueda = "B";
                    break;
                case "gvSenasPartBI":
                    this.gvSenasPartBI.ShowFooter = true;
                    tipoBusqueda = "BI";
                    senia = SeniasBI[e.RowIndex];
                    idSenia = Convert.ToInt32(((DropDownList)(gvSenasPart.Rows[e.RowIndex].Cells[3].FindControl("ddlSeniaPartBI"))).SelectedValue);
                    idUbicacionSenia = Convert.ToInt32(((DropDownList)(gvSenasPart.Rows[e.RowIndex].Cells[4].FindControl("ddlUbicacionSenaPartBI"))).SelectedValue);
                    if (idSenia == 0 || idUbicacionSenia == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Debe indicar la seña y su ubicación.');", true);
                        return;
                    }
                    senia.idSeniaParticular = idSenia;
                    senia.idUbicacionSeniaParticular = idUbicacionSenia;
                    //senia.descripcion = Convert.ToString(((TextBox)(gvSenasPart.Rows[e.RowIndex].Cells[5].FindControl("descripcionSenaPart"))).Text);
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
                    break;
                case "gvSenasPartH":
                    tipoBusqueda = "H";
                    gvSenasPart.EditIndex = -1;
                    SeniasH.RemoveAt(e.RowIndex);
                    Session["SeniasH"] = SeniasH;
                    gvSenasPart.DataSource = SeniasH;
                    gvSenasPart.DataBind();
                    break;
                case "gvSenasPartBI":
                    tipoBusqueda = "BI";
                    gvSenasPart.EditIndex = -1;
                    SeniasBI.RemoveAt(e.RowIndex);
                    Session["SeniasBI"] = SeniasBI;
                    gvSenasPart.DataSource = SeniasBI;
                    gvSenasPart.DataBind();
                    break;
                case "gvSenasPartB":
                    tipoBusqueda = "B";
                    break;
            }
            

        }

        protected void btnLimpiarBI_Click(object sender, EventArgs e)
        {
            LimpiarControlesBI();
        }

        private void SubirFoto(FuncionesGrales.TipoBusqueda tipoBusqueda, FuncionesGrales.TipoFoto tipoFoto)
        
        {
            //string body, subject, mailto;
            //byte[] imgh;
            int fotosSubidas = 0;
            string random = DateTime.Now.Millisecond.ToString();
            fotosSubidas = 1;
            for (int i = 1; i <= fotosSubidas; i++)
            {
                bool yaTieneFoto = false;
                if (idPersonaHallada > 0)
                {
                    switch (tipoFoto)
                    {
                        case FuncionesGrales.TipoFoto.General:
                            yaTieneFoto = FotosGralesH.Count > 0;
                            if (yaTieneFoto)
                            {
                                FotosGralesH.MoveLast();
                            }
                            break;
                        case FuncionesGrales.TipoFoto.SeniasParticulares:
                            yaTieneFoto = FotosSeniasH.Count > 0;
                            if (yaTieneFoto)
                            {
                                FotosSeniasH.MoveLast();
                            }
                            break;
                        case FuncionesGrales.TipoFoto.Huellas:
                            yaTieneFoto = FotosHuellasH.Count > 0;
                            if (yaTieneFoto)
                            {
                                FotosHuellasH.MoveLast();
                            }
                            //    mailto = "afis@mpba.gov.ar";
                            //    body = "Huella para cotejo, subida por el usuario : " + Session["miUsuario"] + " para la IPP Nro: " + this.txtIppBuscadoH.Text.Trim();
                            //    subject = "Cotejo de Huella de la IPP Nro:" + this.txtIppBuscadoH.Text.Trim();
                                
                                //imgh =(Byte[])Session["imgPreview"];

                            //    if (FuncionesGenerales.Produccion())
                            //    {   // En Produccion le envia un mail al usuario  que cargo a la Persona Desaparecida
                            //        MPBA.SIAC.Web.FuncionesGenerales.EnvioHuellaMails(mailto, body, subject);
                                    //MPBA.SIAC.Web.FuncionesGenerales.EnvioHuellaMails(mailto, body, subject, imgh);
                            //    }
                            //    else
                            //    {
                            //        mailto = "afis@mpba.gov.ar";
                            //        MPBA.SIAC.Web.FuncionesGenerales.EnvioHuellaMails(mailto, body, subject);
                                    //MPBA.SIAC.Web.FuncionesGenerales.EnvioHuellaMails(mailto, body, subject, imgh);
                            //    }
                            
                            break;
                    }
                }
                PBFotos nuevaFoto = new PBFotos();
                nuevaFoto.id = -1;
                nuevaFoto.idTablaDestino = (int)tipoBusqueda;
                nuevaFoto.idTipoFoto = (int)tipoFoto;
                nuevaFoto.Foto = (Byte[])Session["imgPreview"];
                if (idPersonaHallada > 0)
                {
                    nuevaFoto.idPersona = idPersonaHallada;
                    PBFotosManager.Save(nuevaFoto);
                }
                else
                    nuevaFoto.idPersona = -1;

                switch (tipoFoto)
                {
                    case FuncionesGrales.TipoFoto.General:
                        FotosGralesH.Add(nuevaFoto);
                        FotosGralesH.EndEdit();
                        FotosGralesH.MoveLast();
                        break;
                    case FuncionesGrales.TipoFoto.SeniasParticulares:
                        FotosSeniasH.Add(nuevaFoto);
                        FotosSeniasH.EndEdit();
                        FotosSeniasH.MoveLast();
                        break;
                    case FuncionesGrales.TipoFoto.Huellas:
                        FotosHuellasH.Add(nuevaFoto);
                        FotosHuellasH.EndEdit();
                        FotosHuellasH.MoveLast();
                        break;
                }
            }
            if (fotosSubidas > 0)
            {
                PBFotos f;
                switch (tipoFoto)
                {
                    case FuncionesGrales.TipoFoto.General:
                        FotosGralesH.MoveLast();
                        f = (PBFotos)FotosGralesH.Current;
                        LlenarImgBox(f, FuncionesGrales.TipoBusqueda.PersonaHallada, tipoFoto);
                        break;
                    case FuncionesGrales.TipoFoto.SeniasParticulares:
                        FotosSeniasH.MoveLast();
                        f = (PBFotos)FotosSeniasH.Current;
                        LlenarImgBox(f, FuncionesGrales.TipoBusqueda.PersonaHallada, tipoFoto);
                        break;
                    case FuncionesGrales.TipoFoto.Huellas:
                        FotosHuellasH.MoveLast();
                        f = (PBFotos)FotosHuellasH.Current;
                        LlenarImgBox(f, FuncionesGrales.TipoBusqueda.PersonaHallada, tipoFoto);
                        break;
                }
                switch (tipoFoto)
                {
                    case FuncionesGrales.TipoFoto.General:
                        FotosGralesH.MoveLast();
                        break;
                    case FuncionesGrales.TipoFoto.SeniasParticulares:
                        FotosSeniasH.MoveLast();
                        break;
                    case FuncionesGrales.TipoFoto.Huellas:
                        FotosHuellasH.MoveLast();
                        break;
                }
            }
            this.lblNroFotoGralH.Text = (FotosGralesH.Position + 1).ToString() + "/" + FotosGralesH.Count.ToString();
            this.lblNroFotoSeniasH.Text = (FotosSeniasH.Position + 1).ToString() + "/" + FotosSeniasH.Count.ToString();
            this.lblNroHuellaH.Text = (FotosHuellasH.Position + 1).ToString() + "/" + FotosHuellasH.Count.ToString();
        }

        private void AvanzarFoto(FuncionesGrales.TipoFoto tipoFoto)
        {
            switch (tipoFoto)
            {
                case FuncionesGrales.TipoFoto.General:
                    if (FotosGralesH.Position < FotosGralesH.Count)
                    {
                        FotosGralesH.MoveNext();
                        PBFotos f = (PBFotos)FotosGralesH.Current;
                        LlenarImgBox(f, FuncionesGrales.TipoBusqueda.PersonaHallada, tipoFoto);
                    }
                    break;
                case FuncionesGrales.TipoFoto.SeniasParticulares:
                    if (FotosSeniasH.Position < FotosSeniasH.Count)
                    {
                        FotosSeniasH.MoveNext();
                        PBFotos f = (PBFotos)FotosSeniasH.Current;
                        LlenarImgBox(f, FuncionesGrales.TipoBusqueda.PersonaHallada, tipoFoto);
                    }
                    break;
                case FuncionesGrales.TipoFoto.Huellas:
                    if (FotosHuellasH.Position < FotosHuellasH.Count)
                    {
                        FotosHuellasH.MoveNext();
                        PBFotos f = (PBFotos)FotosHuellasH.Current;
                        LlenarImgBox(f, FuncionesGrales.TipoBusqueda.PersonaHallada, tipoFoto);
                    }
                    break;
            }
            this.lblNroFotoGralH.Text = (FotosGralesH.Position + 1).ToString() + "/" + FotosGralesH.Count.ToString();
            this.lblNroFotoSeniasH.Text = (FotosSeniasH.Position + 1).ToString() + "/" + FotosSeniasH.Count.ToString();
            this.lblNroHuellaH.Text = (FotosHuellasH.Position + 1).ToString() + "/" + FotosHuellasH.Count.ToString();



        }

        private void RetrocederFoto(FuncionesGrales.TipoFoto tipoFoto)
        {
            switch (tipoFoto)
            {
                case FuncionesGrales.TipoFoto.General:
                    if (FotosGralesH.Position > 0)
                    {
                        FotosGralesH.MovePrevious();
                        PBFotos f = (PBFotos)FotosGralesH.Current;
                        LlenarImgBox(f, FuncionesGrales.TipoBusqueda.PersonaHallada, tipoFoto);
                    }
                    break;
                case FuncionesGrales.TipoFoto.SeniasParticulares:
                    if (FotosSeniasH.Position > 0)
                    {
                        FotosSeniasH.MovePrevious();
                        PBFotos f = (PBFotos)FotosSeniasH.Current;
                        LlenarImgBox(f, FuncionesGrales.TipoBusqueda.PersonaHallada, tipoFoto);
                    }
                    break;
                case FuncionesGrales.TipoFoto.Huellas:
                    if (FotosHuellasH.Position > 0)
                    {
                        FotosHuellasH.MovePrevious();
                        PBFotos f = (PBFotos)FotosHuellasH.Current;
                        LlenarImgBox(f, FuncionesGrales.TipoBusqueda.PersonaHallada, tipoFoto);
                    }
                    break;
            }

            this.lblNroFotoGralH.Text = (FotosGralesH.Position + 1).ToString() + "/" + FotosGralesH.Count.ToString();
            this.lblNroFotoSeniasH.Text = (FotosSeniasH.Position + 1).ToString() + "/" + FotosSeniasH.Count.ToString();
            this.lblNroHuellaH.Text = (FotosHuellasH.Position + 1).ToString() + "/" + FotosHuellasH.Count.ToString();

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
                        url = "ImageHandler1.ashx?t=" + ((int)tipoFoto).ToString() + "&r=" + new Random().Next().ToString() + "&bi=t&p=d";
                        this.imgFotoGeneralBID.ImageUrl = url;
                        this.imgFotoGeneralBID.OnClientClick = "window.open('FullSizeImage.aspx?url=" + url + "')";
                        this.imgFotoGeneralBID.Width = dim[0];
                        this.imgFotoGeneralBID.Height = dim[1];
                        break;
                    case FuncionesGrales.TipoFoto.SeniasParticulares:
                        Session["FotosSeniasBI"] = FotosSeniasBI;
                        url = "ImageHandler1.ashx?t=" + ((int)tipoFoto).ToString() + "&r=" + new Random().Next().ToString() + "&bi=t&p=d";
                        this.imgFotoSeniasBID.ImageUrl = url;
                        this.imgFotoSeniasBID.OnClientClick = "window.open('FullSizeImage.aspx?url=" + url + "')";
                        this.imgFotoSeniasBID.Width = dim[0];
                        this.imgFotoSeniasBID.Height = dim[1];
                        break;
                }

                switch (tipoFoto)
                {
                    case FuncionesGrales.TipoFoto.General:
                        if (cantFotos == 1)
                        {
                            this.btnFotoSigGeneralBID.Enabled = false;
                            this.btnFotoPrevGeneralBID.Enabled = false;
                        }
                        else if (cantFotos > 1)
                        {

                            if (nroFotoActual == 1)
                            {
                                this.btnFotoSigGeneralBID.Enabled = true;
                                this.btnFotoPrevGeneralBID.Enabled = false;
                            }
                            else if (nroFotoActual > 1 && nroFotoActual < cantFotos)
                            {
                                this.btnFotoSigGeneralBID.Enabled = true;
                                this.btnFotoPrevGeneralBID.Enabled = true;
                            }
                            else if (nroFotoActual == cantFotos)
                            {
                                this.btnFotoSigGeneralBID.Enabled = false;
                                this.btnFotoPrevGeneralBID.Enabled = true;
                            }
                        }
                        else
                        {
                            this.btnFotoSigGeneralBID.Enabled = false;
                            this.btnFotoPrevGeneralBID.Enabled = false;
                            this.imgFotoGeneralBID.ImageUrl = "~/App_Images/SinFoto.GIF";
                            this.imgFotoGeneralBID.Width = 80;
                            this.imgFotoGeneralBID.Height = 100;
                        }
                        break;
                    case FuncionesGrales.TipoFoto.SeniasParticulares:
                        if (cantFotos == 1)
                        {
                            this.btnFotoSigSeniasBID.Enabled = false;
                            this.btnFotoPrevSeniasBID.Enabled = false;
                        }
                        else if (cantFotos > 1)
                        {

                            if (nroFotoActual == 1)
                            {
                                this.btnFotoSigSeniasBID.Enabled = true;
                                this.btnFotoPrevSeniasBID.Enabled = false;
                            }
                            else if (nroFotoActual > 1 && nroFotoActual < cantFotos)
                            {
                                this.btnFotoSigSeniasBID.Enabled = true;
                                this.btnFotoPrevSeniasBID.Enabled = true;
                            }
                            else if (nroFotoActual == cantFotos)
                            {
                                this.btnFotoSigSeniasBID.Enabled = false;
                                this.btnFotoPrevSeniasBID.Enabled = true;
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
                        break;
                }

            }


        }


        private void AvanzarFotoFichaBI(FuncionesGrales.TipoBusqueda tipoBusqueda, FuncionesGrales.TipoFoto tipoFoto, int idPersona)
        {
            switch (tipoBusqueda)
            {

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


                    break;
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
                        LlenarImgBoxFichaBI(f, FuncionesGrales.TipoBusqueda.PersonaDesaparecida, tipoFoto);
                    }
                    break;
                case FuncionesGrales.TipoFoto.SeniasParticulares:
                    if (FotosSeniasBI.Position > 0)
                    {
                        FotosSeniasBI.MovePrevious();
                        PBFotos f = (PBFotos)FotosSeniasBI.Current;
                        LlenarImgBoxFichaBI(f, FuncionesGrales.TipoBusqueda.PersonaDesaparecida, tipoFoto);
                    }
                    break;
            }

            this.lblNroFotoGralBID.Text = (FotosGralesBI.Position + 1).ToString() + "/" + FotosGralesBI.Count.ToString();
            this.lblNroFotoSeniasBID.Text = (FotosSeniasBI.Position + 1).ToString() + "/" + FotosSeniasBI.Count.ToString();
        }

        private bool BorrarFoto(string fullNameFoto, FuncionesGrales.TipoFoto tipoFoto)
        {
            bool borroBien = false;
            int cantFotos = 0;
            PBFotos foto = null;
            switch (tipoFoto)
            {

                case FuncionesGrales.TipoFoto.General:
                    foto = (PBFotos)FotosGralesH.Current;
                    borroBien = PBFotosManager.Delete(foto);
                    FotosGralesH.Remove(foto);
                    cantFotos = FotosGralesH.Count;
                    FotosGralesH.MoveFirst();
                    this.imgFotoGeneralH.ImageUrl = "~/App_Images/SinFoto.GIF";
                    if (cantFotos > 0)
                        LlenarImgBox((PBFotos)FotosGralesH.Current, FuncionesGrales.TipoBusqueda.PersonaHallada, tipoFoto);
                    if (cantFotos == 0)
                    {
                        this.imgFotoGeneralH.ImageUrl = "~/App_Images/SinFoto.GIF";
                        this.imgFotoGeneralH.Width = 80;
                        this.imgFotoGeneralH.Height = 100;
                        this.btnBorrarFotoGralH.Enabled = false;
                        this.btnFotoSigGeneralH.Enabled = false;
                        this.btnFotoPrevGeneralH.Enabled = false;
                    }
                    break;
                case FuncionesGrales.TipoFoto.SeniasParticulares:
                    foto = (PBFotos)FotosSeniasH.Current;
                    borroBien = PBFotosManager.Delete(foto);
                    FotosSeniasH.Remove(foto);
                    cantFotos = FotosSeniasH.Count;
                    FotosSeniasH.MoveFirst();
                    this.imgFotoSeniasH.ImageUrl = "~/App_Images/SinFoto.GIF";
                    this.imgFotoSeniasH.Width = 80;
                    this.imgFotoSeniasH.Height = 100;
                    if (cantFotos > 0)
                        LlenarImgBox((PBFotos)FotosSeniasH.Current, FuncionesGrales.TipoBusqueda.PersonaHallada, tipoFoto);
                    if (cantFotos == 0)
                    {
                        this.imgFotoSeniasH.ImageUrl = "~/App_Images/SinFoto.GIF";
                        this.imgFotoSeniasH.Width = 80;
                        this.imgFotoSeniasH.Height = 100;
                        this.btnBorrarFotoSeniasH.Enabled = false;
                        this.btnFotoSigSeniasH.Enabled = false;
                        this.btnFotoPrevSeniasH.Enabled = false;
                    }

                    break;
                case FuncionesGrales.TipoFoto.Huellas:
                    foto = (PBFotos)FotosHuellasH.Current;
                    borroBien = PBFotosManager.Delete(foto);
                    FotosHuellasH.Remove(foto);
                    cantFotos = FotosHuellasH.Count;
                    FotosHuellasH.MoveFirst();
                    this.imgHuellasH.ImageUrl = "~/App_Images/SinFoto.GIF";
                    this.imgHuellasH.Width = 80;
                    this.imgHuellasH.Height = 100;
                    if (cantFotos > 0)
                        LlenarImgBox((PBFotos)FotosHuellasH.Current, FuncionesGrales.TipoBusqueda.PersonaHallada, tipoFoto);
                    if (cantFotos == 0)
                    {
                        this.imgHuellasH.ImageUrl = "~/App_Images/SinFoto.GIF";
                        this.imgHuellasH.Width = 80;
                        this.imgHuellasH.Height = 100;
                        this.btnBorrarHuellasH.Enabled = false;
                        this.btnSigHuellasH.Enabled = false;
                        this.btnPrevHuellasH.Enabled = false;
                    }

                    break;
            }

            this.lblNroFotoGralH.Text = (FotosGralesH.Position + 1).ToString() + "/" + FotosGralesH.Count.ToString();
            this.lblNroFotoSeniasH.Text = (FotosSeniasH.Position + 1).ToString() + "/" + FotosSeniasH.Count.ToString();
            this.lblNroHuellaH.Text = (FotosHuellasH.Position + 1).ToString() + "/" + FotosHuellasH.Count.ToString();
            return borroBien;
        }

        /// <summary>
        /// Llena los controles de la busqueda individual
        /// </summary>
        /// <param name="miBI">parametros de la busqueda</param>
        private void LlenarControlesBI(Busqueda miBI)
        {
              if (miBI.CantidadCoincidencias != null)
                this.txtCoincidenciaBI.Text = miBI.CantidadCoincidencias.ToString();
              if (miBI.DNI != null)
                  this.txtDNIBI.Text = miBI.DNI.Trim();
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
                SeniasParticularesList seniaList = new SeniasParticularesList();
                SeniasParticulares senia = new SeniasParticulares();
                
                foreach (BusquedaSeniasParticulares bsp in miBI.busquedaSeniasParticularess)
                {
                    senia.idSeniaParticular = Convert.ToInt32(bsp.idClaseSeniaParticular);
                    senia.idUbicacionSeniaParticular = Convert.ToInt32(bsp.idUbicacionSeniaParticular);
                    senia.idTablaDestino = Convert.ToInt32(miBI.TablaDestino);
                    seniaList.Add(senia);
                    senia = null;
                    senia = new SeniasParticulares();
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
                TatuajesPersonaList tatuajeList = new TatuajesPersonaList();
                TatuajesPersona tatuaje = new TatuajesPersona();

                foreach (BusquedaTatuajes bt in miBI.busquedaTatuajess)
                {
                    tatuaje.idTatuaje = Convert.ToInt32(bt.IdClaseTatuaje);
                    tatuaje.idUbicacionTatuaje = Convert.ToInt32(bt.IdUbicacionTatuaje);
                    tatuaje.idTablaDestino = Convert.ToInt32(miBI.TablaDestino);
                    tatuajeList.Add(tatuaje);
                    tatuaje = null;
                    tatuaje = new TatuajesPersona();
                }
                TatuajesBI = null;
                TatuajesBI = tatuajeList;
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
                this.txtVerFechaDesdeBI.Text = Convert.ToDateTime(miBI.FechaDesde.ToString()).ToString("dd/MM/yyyy");
            if (miBI.FechaHasta != null)
                this.txtVerFechaHastaBI.Text = Convert.ToDateTime(miBI.FechaHasta.ToString()).ToString("dd/MM/yyyy");
                this.txtVerSexoBI.Text = PBClaseSexoManager.GetItem(miBI.idsexo).Descripcion;
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
                this.txtVerFaltanPiezasDentalesBI.Text = PBClaseBooleanManager.GetItem(miBI.FaltanPiezasDentales).Descripcion;
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
                SeniasParticulares senia = new SeniasParticulares();
                foreach (BusquedaSeniasParticulares sp in miBI.busquedaSeniasParticularess)
                {
                    senia.idSeniaParticular = Convert.ToInt32(sp.idClaseSeniaParticular);
                    senia.idUbicacionSeniaParticular = Convert.ToInt32(sp.idUbicacionSeniaParticular);
                    senia.descripcion = Convert.ToString(sp.descripcion);
                    this.txtVerSenasPartBI.Text += ClaseSeniaParticularManager.GetItem(senia.idSeniaParticular).Descripcion.Trim() + ", " + ClaseUbicacionSeniaPartManager.GetItem(senia.idUbicacionSeniaParticular).Descripcion.Trim() + " - ";
                }
                if (this.txtVerSenasPartBI.Text.Length > 0)
                    this.txtVerSenasPartBI.Text = this.txtVerSenasPartBI.Text.Substring(0, this.txtVerSenasPartBI.Text.Length - 2);
            }
            if (miBI.busquedaTatuajess != null && miBI.busquedaTatuajess.Count > 0)
            {
                TatuajesPersona tatuaje = new TatuajesPersona();
                foreach (BusquedaTatuajes tp in miBI.busquedaTatuajess)
                {
                    tatuaje.idTatuaje = Convert.ToInt32(tp.IdClaseTatuaje);
                    tatuaje.idUbicacionTatuaje = Convert.ToInt32(tp.IdUbicacionTatuaje);
                    this.txtVerTatuajesBI.Text += ClaseTatuajeManager.GetItem(tatuaje.idTatuaje).descripcion.Trim() + ", " + ClaseUbicacionSeniaPartManager.GetItem(tatuaje.idUbicacionTatuaje).Descripcion.Trim() + " - ";
                }
                if (this.txtVerTatuajesBI.Text.Length > 0)
                    this.txtVerTatuajesBI.Text = this.txtVerTatuajesBI.Text.Substring(0, this.txtVerTatuajesBI.Text.Length - 2);
            }

          
        }

        /// <summary>
        /// Llena los listboxes de la busqueda individual
        /// </summary>
        /// <param name="miBI">busqueda con datos para los listboxes</param>
        private void LlenarListBoxesBI(Busqueda miBI)
        {
            //Si en los listboxes no hay items seleccionados, para la busqueda se toma indeterminado
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
            {//agrego indeterminado
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

            foreach (TatuajesPersona tp in TatuajesBI)
            {
                BusquedaTatuajes bt = new BusquedaTatuajes();
                bt.id = -1;
                bt.IdClaseTatuaje = tp.idTatuaje;
                bt.IdUbicacionTatuaje = tp.idUbicacionTatuaje;
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
            BusquedaIndividual.FechaUltimaModificacion = null;
            BusquedaIndividual.FechaAlta = null;
            BusquedaIndividual.FechaUltimaCoincidencia = DateTime.Now;
            BusquedaIndividual.Apellido = this.txtApellidoBI.Text.Trim();
            BusquedaIndividual.Nombre = this.txtNombresBI.Text.Trim();
            BusquedaIndividual.IPP = "";
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
                case FuncionesGrales.TipoBusqueda.PersonaHallada:
                    if (estado == FuncionesGrales.EstadoPrograma.Creando)//creo la búsqueda
                        busqueda = GuardarBusquedaIndividual(FuncionesGrales.TipoBusqueda.PersonaHallada, -1);
                    else
                    {
                        busqueda = BusquedaManager.GetItem(PersonasHalladasManager.GetItem(Convert.ToInt32(this.btnVerResultadosH.CommandArgument)).idBusqueda, true);
                        //if (estado == FuncionesGrales.EstadoPrograma.Consultando)
                        //    busqueda.FechaUltimaModificacion = Convert.ToDateTime("01-01-1800");//guardo una fecha bien chica, asi me trae todas las coincidencias sin importar la fecha de modificacion
                       
                        if (estado == FuncionesGrales.EstadoPrograma.Modificando) //modifico la búsuqeda
                            busqueda = GuardarBusquedaIndividual(FuncionesGrales.TipoBusqueda.PersonaHallada, Convert.ToInt32(busqueda.Id));
                    }

                    if (busqueda != null && estado == FuncionesGrales.EstadoPrograma.Creando)
                        GuardoExito = GuardarPersonasHalladas(busqueda, -1);
                    else if (busqueda != null && estado == FuncionesGrales.EstadoPrograma.Modificando)
                        GuardoExito = GuardarPersonasHalladas(busqueda, idPersonaHallada);
                    PersonasDesaparecidasList pd = new PersonasDesaparecidasList();
                    if (GuardoExito)
                    {
                        string ipp = "";
                        List<PersonasHalladas> myPersonas = null;
                        if (this.tcTipoJurisdiccion.ActiveTab == this.tpPJ)
                        {
                            ipp = this.txtIppBuscadoH.Text.Trim();
                            myPersonas = PersonasHalladasManager.GetListByIPP(ipp).FindAll(delegate(PersonasHalladas ph) { return (ph.esExtJurisdiccion == null || ph.esExtJurisdiccion == false); });
                        }
                        else if (this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur)
                        {
                            ipp = this.txtCausa.Text.Trim();
                            myPersonas = PersonasHalladasManager.GetListByIPP(ipp).FindAll(delegate(PersonasHalladas ph) { return  (ph.esExtJurisdiccion != null && ph.esExtJurisdiccion == true); });
                        }
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Cambios guardados correctamente.');", true);
                        //this.lblGuardoExitoH.Visible = true;
                        //this.lblGuardoExitoH.Style.Remove("display");
                        Session["FotosGralesH"] = FotosGralesH;
                        Session["FotosSeniasH"] = FotosSeniasH;
                        Session["FotosHuellasH"] = FotosHuellasH;
                        Session["FotosGralesBI"] = FotosGralesBI;
                        Session["FotosSeniasBI"] = FotosSeniasBI;
                       // List<PersonasHalladas> myPersonas = PersonasHalladasManager.GetListByIPP(ipp).FindAll(delegate(PersonasHalladas p) { return p.Baja == false && (p.esExtJurisdiccion == null || p.esExtJurisdiccion == false); });

                        if (myPersonas.Count > 0)
                        {
                            this.divPersonasH.Style.Remove("display");
                            this.gvPersonasH.DataSource = myPersonas;
                            this.gvPersonasH.DataBind();
                            //this.gvPersonasD.SelectedIndex = 0;
                        }

                        foreach (GridViewRow row in this.gvPersonasH.Rows)
                        {
                            if (this.gvPersonasH.DataKeys[row.RowIndex].Value.ToString() == idPersonaHallada.ToString())
                                this.gvPersonasH.SelectedIndex = row.RowIndex;
                            
                        }

                        SetearGvPersonas();
                        TraerMailsAsociados(idPersonaHallada);
                        this.divAgregandoPersona.Style.Add("display", "none");
                        Session["idPersonaHallada"] = idPersonaHallada;
                    }
                    else
                    {
                        this.lblGuardoExitoH.Visible = false;
                        this.lblGuardoExitoH.Style.Add("display", "none");
                    }
                    busqueda.IPP = null;
                    pd = PersonasDesaparecidasManager.GetList(busqueda);
                     int cantidadResultados = pd.Count;
                    int nroMaximoResultados = 50;
                    if (cantidadResultados > nroMaximoResultados)
                    {
                        string msg = "Demasiados resultados, se mostraran solo " + nroMaximoResultados.ToString() + ". Restrinja el numero minimo de coincidencias.";
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('" + msg + "');", true);
                        //this.lblMensajeCartelAlert.Text = "Demasiados resultados, se mostraran solo " + nroMaximoResultados.ToString() + ". Restrinja el numero minimo de coincidencias.";
                        //hfCartelAlert_ModalPopupExtender.Show();
                        //return;
                        pd.RemoveRange(nroMaximoResultados - 1, cantidadResultados - nroMaximoResultados);
                    }
                    if (pd.Count > 0)
                    {

                        this.gvResultadosDesapBI.DataSource = pd;
                        this.gvResultadosDesapBI.Columns[0].Visible = false;
                        this.gvResultadosDesapBI.DataBind();
                        this.gvResultadosDesapBI.Style.Remove("display");
                        //this.gvResultadosDesapBI.Style.Add("display", "none");
                        this.btnCancelarResultadosBI.CommandArgument = "D";
                        //RefrescarEstadoBusquedasActivas();
                        //BuscarCoincidenciasEnBusquedasActivas();
                        this.lblCantResultados.Text = " (" + pd.Count.ToString() + ") ";
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
                    this.btnVerResultadosH.Style.Remove("display");
                    this.btnVerCriterioBusquedaH.CommandArgument = busqueda.Id.ToString();
                    this.btnVerCriterioBusquedaH.Style.Remove("display");
                    //this.pnlPersonadesaparecida.Enabled = false;
                    break;

            }
        }

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
            this.ddlFaltanPiezasDentalesBI.SelectedValue = "1";
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
            this.lblFechaBI.Text = "Fecha";
            this.lblValorFechaBI.Text = "";
            this.lblApellidoPersonaBIValor.Text = "";
            this.lblDNIPersonaBIValor.Text = "";
            this.lblNombrePersonaBIValor.Text = "";
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
            this.lblTallaPersonaBIValor.Text = "";
            this.ddlSexoBI.SelectedIndex = 0;
            this.ddlFaltanPiezasDentalesBI.SelectedIndex = 0;
            this.lblSeniaParticularBIValor.Text = "";
            this.lbltatuajeBIValor.Text = "";
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
            this.txtVerSexoBI.Text = "1";
            this.txtVerSenasPartBI.Text = "";
            this.lblVerFechaBI.Text = "Fecha";
            this.lblVerValorFechaBI.Text = "";
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
        /// Realiza la validacion de los controles de la carga de personas halladas
        /// </summary>
        private void ValidarH()
        {
            // Los datos obligatorios para todos los casos
            // Lugar Hallazgo, Fecha del Hallazgo
            // Edad cientifica o Edad aparente para restos Oseos
            // Requerimientos minimos de informacion
            // Datos de locacion del cuerpo
            // Lugar/Partido / Pcia

            this.cvSenaSinIncorporar.IsValid=ValidarSenas();
            this.cvTatuajeSinIncorporar.IsValid=ValidarTatuajes();
            
            if (this.lblLugarHallazgoPersona.Text == "" ||
                 this.lblPartidoHallazgo.Text == "" ||
                  this.lblProvinciaHallazgo.Text == "")
            {
                this.cvLugarHallazgo.IsValid = false;

            }


            // SI es resto Oseo, VIVE en NO
            // VIVE=  this.ddlViveH.SelectedValue="3"
            // MUERTO=  this.ddlViveH.SelectedValue="2"

            if (this.cvRestoOseo.Checked == true && this.ddlViveH.SelectedValue == "3")
            { // Si es resto oseo va no VIVE
                this.cvViveH.IsValid = false;
                this.cvViveH.ErrorMessage = "Si es Resto Oseo, indique No Vive";

            }


            // Caso NO RESTO Oseo Completitud de informacion
            // VIVE o NO en comun Chequea..          
            if (this.cvRestoOseo.Checked == false)
            {
                // Edad aparente o Edad Cientifica
                if (this.txtEdadAparenteH.Text == "" && this.txtEdadCientificaH.Text == "")
                {
                    cvEdadAparenteH.IsValid = this.txtEdadAparenteH.Text == "" ? false : true;
                    if (this.txtEdadAparenteH.Text == "")
                        cvEdadAparenteH.ErrorMessage = "Ingreso Obligatorio";
                    cvEdadCientificaH.ErrorMessage = "";
                    if (this.txtEdadCientificaH.Text == "" && this.ddlViveH.SelectedValue == "2")
                    {
                        cvEdadCientificaH.ErrorMessage = "Ingreso Obligatorio";
                        cvEdadCientificaH.IsValid = false;
                    }

                }

                // Sexo
                if (Convert.ToInt32(this.ddlSexoH.SelectedValue) < 2)
                {
                    cvSexoH.IsValid = false;

                }
                // Talla 
                if (this.txtTallaH.Text.Contains(',') || this.txtTallaH.Text.Contains('.'))
                {
                    cvtalla.IsValid = false;
                    cvtalla.ErrorMessage = "Ingrese la talla en centimetros, sin comas ni puntos";
                }
                else if (this.txtTallaH.Text == "" || Convert.ToDouble(txtTallaH.Text) > 250 )
                    {
                        cvtalla.IsValid = false;
                        cvtalla.ErrorMessage = this.txtTallaH.Text == "" ? "Ingreso Obligatorio" : "La talla supera los 2 metros y medio!";
                    }
               

                // Color de Piel
                if (Convert.ToInt32(this.ddlColorPielH.SelectedValue) < 2)
                {
                    cvColorPielH.IsValid = false;
                }

               


            }
            else
            { /* En Restos Oseos solo especifica fecha del hallazgo y lugar del  hallazgo
                // edad cientifica en caso de resto oseo Ver porque no siempre la tienen
                // y en el caso de hallazgo de una mano, no se tiene
                 if ( this.txtEdadCientificaH.Text == "")
                {
                       cvEdadCientificaH.ErrorMessage = "Ingreso Obligatorio";
                        cvEdadCientificaH.IsValid = false;
                  }
            */
            }

            // Si la Persona VIVE , no es resto Oseo y ya se le
            // solicito datos:   Edad aparente o Edad Cientifica,
            //  Sexo, Talla, Color del Piel,Color de Ojos
            if (this.ddlViveH.SelectedValue == "3")
            {
                // Campos que se agregan como requeridos cuando VIVE
                // Color de Ojos
                if (Convert.ToInt32(this.ddlColorOjosH.SelectedValue) < 2)
                {
                    cvColorOjosH.IsValid = false;
                }

                 //  Peso
                if (this.txtPesoH.Text == "")
                {
                    cvPesoH.IsValid = false;
                    cvPesoH.ErrorMessage = "Ingreso Obligatorio";
                }

                //Color de Cabello (ver calvicie)

                if (Convert.ToInt32(this.ddlCalvicieH.SelectedValue) < 2)
                {
                    cvCalvicieH.IsValid = false;
                    cvCalvicieH.ErrorMessage = "Ingreso Obligatorio";
                }
                if (this.ddlCalvicieH.SelectedValue == "5")
                {
                    if (this.ddlColorCabelloH.SelectedValue == "0")
                    {
                        cvColorCabelloH.IsValid = false;
                        cvColorCabelloH.ErrorMessage = "Esta vivo,Especifique Color Cabello, Aspecto y Longitud";
                    }

                }




            }



            //DropDownLists
            if (this.ddlAspectoCabelloH.SelectedValue == "0")
                this.cvAspectoCabelloH.IsValid = false;
            if (this.ddlCalvicieH.SelectedValue == "0")
                this.cvCalvicieH.IsValid = false;
            if (this.ddlColorCabelloH.SelectedValue == "0")
                this.cvColorCabelloH.IsValid = false;
            if (this.ddlColorOjosH.SelectedValue == "0")
                this.cvColorOjosH.IsValid = false;
            if (this.ddlColorPielH.SelectedValue == "0")
                this.cvColorPielH.IsValid = false;
            if (this.ddlColorTenidoH.SelectedValue == "0")
                this.cvColorTenidoH.IsValid = false;
            if (this.ddlExistenRadiografiasH.SelectedValue == "0")
                this.cvExistenRadiografiasH.IsValid = false;
            if (this.ddlFaltanDientesH.SelectedValue == "0")
                this.cvFaltanDientesH.IsValid = false;
            if (this.ddlFichasDactilaresH.SelectedValue == "0")
                this.cvFichasDactilaresH.IsValid = false;
            if (this.ddlFotoH.SelectedValue == "0")
                this.cvFotoH.IsValid = false;
            if (this.ddlLongitudCabelloH.SelectedValue == "0")
                this.cvLongitudCabelloH.IsValid = false;
            if (this.ddlOrgIntH.SelectedValue == "0")
                this.cvOrgIntH.IsValid = false;
            if (this.ddlRostroH.SelectedValue == "0")
                this.cvRostroH.IsValid = false;
            if (this.ddlSexoH.SelectedValue == "0")
                this.cvSexoH.IsValid = false;
            if (this.ddlViveH.SelectedValue == "0" || this.ddlViveH.SelectedValue == "1")
            {
                this.cvViveH.IsValid = false;
                cvViveH.ErrorMessage = "Ingreso Obligatorio";
            }
            if (this.ddlAdnH.SelectedValue == "0")
                this.cvTieneAdnH.IsValid = false;

            //fechas: La fecha del Hallazgo es OBLIGATORIA siempre
            string fechaHallazgo = this.txtFechaHallazgo.Text.Trim();
            if (fechaHallazgo != "")
            {
                if (this.mevFechaHallazgo.IsValid == true)
                {
                    if (Convert.ToDateTime(fechaHallazgo) > DateTime.Today)
                    {
                        this.cvFechaHallazgo.IsValid = false;
                        this.cvFechaHallazgo.ErrorMessage = "Fecha Incorrecta";
                    }
                }
            }
            else { this.cvFechaHallazgo.IsValid = false;
            this.cvFechaHallazgo.ErrorMessage = "Ingreso Obligatorio";
            }

            //IPP
            if (this.tcTipoJurisdiccion.ActiveTab == this.tpPJ)
            {
                if (this.txtIppBuscadoH.Text.Trim() == "")
                {
                    this.cvIppH.Text = "Debe ingresar la IPP";
                    this.cvIppH.IsValid = false;
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

            //edades
            string edadAparenteH = this.txtEdadAparenteH.Text.Trim();
            string edadCientificaH = this.txtEdadCientificaH.Text.Trim();
            if (edadAparenteH != "")
            {
                if (Convert.ToInt32(edadAparenteH) > 110)
                {
                    this.cvEdadAparenteH.IsValid = false;
                }
            }

            if (edadCientificaH != "")
            {
                if (Convert.ToInt32(edadCientificaH) > 110)
                {
                    this.cvEdadCientificaH.IsValid = false;
                }
            }

            //pesos
            string pesoH = this.txtPesoH.Text.Trim();
            if (pesoH != "")
            {
                try
                {
                    if (Math.Round(Convert.ToDouble(pesoH)) / 100 > 500)
                    {
                        this.cvPesoH.IsValid = false;
                    }
                }
                catch
                {
                    this.cvPesoH.IsValid = false;
                }

            }

            //dias sin afeitar
            string diasSinAfeitarH = this.txtCantidadDiasNoAfeitadoH.Text.Trim();
            if (diasSinAfeitarH != "")
            {
                if (Convert.ToInt32(diasSinAfeitarH) > 500)
                {
                    this.cvCantidadDiasNoAfeitadoH.IsValid = false;
                }

            }
        }

        /// <summary>
        /// Llena los controles de la persona hallada
        /// </summary>
        /// <param name="personaHallada"></param>
        private void LlenarControlesH(MPBA.PersonasBuscadas.BusinessEntities.PersonasHalladas personaHallada)
        {
           
            //this.lblIppH.Text = "IPP: " + this.txtIppBuscadoH.Text.Trim();
            if (personaHallada.tieneADN != null)
                this.ddlAdnH.SelectedValue = personaHallada.tieneADN.ToString();

             // Restos Oseos
             this.cvRestoOseo.Checked = personaHallada.RestosOseos;

            //if (personaHallada.Ipp != null)
            //    this.lblIppH.Text =  personaHallada.Ipp.Trim();
            if (personaHallada.Apellido != null)
                this.txtApellidoH.Text = personaHallada.Apellido.Trim();
            if (personaHallada.Nombre != null)
                this.txtNombresH.Text = personaHallada.Nombre.Trim();
            this.ddlTipoDoc.SelectedValue = personaHallada.idTipoDNI.ToString();
            if (personaHallada.DNI != null)
                this.txtDNI.Text = personaHallada.DNI.Trim();
            if (personaHallada.ArticulosPersonales != null)
                this.txtArticulosPersonalesH.Text = personaHallada.ArticulosPersonales;
            if (personaHallada.CantidadDiasNoAfeitado != null)
                this.txtCantidadDiasNoAfeitadoH.Text = personaHallada.CantidadDiasNoAfeitado.ToString();
            if (personaHallada.EdadAparente != null)
                this.txtEdadAparenteH.Text = personaHallada.EdadAparente.ToString();
            if (personaHallada.EdadCientifica != null)
                this.txtEdadCientificaH.Text = personaHallada.EdadCientifica.ToString();
            if (personaHallada.FechaHallazgo != null)
                this.txtFechaHallazgo.Text = personaHallada.FechaHallazgo.ToString();
            if (personaHallada.Peso != null)
                this.txtPesoH.Text = personaHallada.Peso.ToString();
            if (personaHallada.Ropa != null)
                this.txtRopaH.Text = personaHallada.Ropa;
            if (personaHallada.Talla != null)
                this.txtTallaH.Text = personaHallada.Talla.ToString();
            this.ddlAspectoCabelloH.SelectedValue = personaHallada.idAspectoCabello.ToString();
            this.ddlCalvicieH.SelectedValue = personaHallada.idCalvicie.ToString();
            this.ddlColorCabelloH.SelectedValue = personaHallada.idColorCabello.ToString();
            this.ddlColorOjosH.SelectedValue = personaHallada.idColorOjos.ToString();
            this.ddlColorPielH.SelectedValue = personaHallada.idColorPiel.ToString();
            this.ddlColorTenidoH.SelectedValue = personaHallada.idColorTenido.ToString();
            //this.ddlDentaduraH.SelectedValue = personaHallada.idDentadura.ToString();
            this.ddlExistenRadiografiasH.SelectedValue = personaHallada.ExistenRadiografia.ToString();
            this.ddlFaltanDientesH.SelectedValue = personaHallada.FaltanPiezasDentales.ToString();
            this.ddlFichasDactilaresH.SelectedValue = personaHallada.FichasDactilares.ToString();
            this.ddlFotoH.SelectedValue = personaHallada.Foto.ToString();
            this.ddlLongitudCabelloH.SelectedValue = personaHallada.idLongitudCabello.ToString();
            if (this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur && personaHallada.PBCausaExtranaJurisdiccion != null)
            {
                PBCausaExtranaJurisdiccion extJur=personaHallada.PBCausaExtranaJurisdiccion;
                this.txtOrgReqExtJur.Text = extJur.OrganoRequirente == null ? "" : extJur.OrganoRequirente.Trim();
                this.txtTelefonoExtJur.Text = extJur.telefono == null ? "" : extJur.telefono.Trim();
                this.txtMailExtJur.Text = extJur.mail == null ? "" : extJur.mail.Trim();
                this.txtCaratulaExtJur.Text = extJur.caratula==null?"":extJur.caratula.Trim();
                this.ddlProvinciaExtJur.SelectedValue = extJur.Provincia == null ? "0" : extJur.Provincia.Trim();
                this.txtJurisdiccionExtJur.Text = extJur.Jurisdiccion == null ? "" : extJur.Jurisdiccion.Trim();
                this.pnlExtranaJurisdiccion.Visible = true;
            }
            if (personaHallada.idLugarHallazgo > 0)
            {
                this.lblLugarHallazgoPersona.Text = MPBA.SIAC.Bll.LocalidadManager.GetItem(personaHallada.idLugarHallazgo).localidad.Trim();
                this.lblPartidoHallazgo.Text = MPBA.SIAC.Bll.PartidoManager.GetItem((MPBA.SIAC.Bll.LocalidadManager.GetItem(personaHallada.idLugarHallazgo).Partido)).partido.Trim();
                this.lblProvinciaHallazgo.Text = MPBA.SIAC.Bll.ProvinciaManager.GetItem((MPBA.SIAC.Bll.LocalidadManager.GetItem(personaHallada.idLugarHallazgo).Provincia)).provincia.Trim();
                this.hfLugarHId.Value = personaHallada.idLugarHallazgo.ToString();
            }
            if (personaHallada.idComisaria >= 0)
            {
                this.lblComisariaPersonaH.Text = MPBA.SIAC.Bll.ComisariaManager.GetItem(personaHallada.idComisaria).comisaria.Trim();
                this.hfComisariaHId.Value = personaHallada.idComisaria.ToString();
                //this.lblDepartamentoComisariaH.Text = DepartamentoManager.GetItem(ComisariaManager.GetItem(personaHallada.idComisaria).idDepartamento).departamento.Trim();
            }
            this.ddlOrgIntH.SelectedValue = personaHallada.idOrganismoInterviniente.ToString();
            this.ddlRostroH.SelectedValue = personaHallada.idRostro.ToString();
            this.ddlSexoH.SelectedValue = personaHallada.idSexo.ToString();
            this.ddlViveH.SelectedValue = personaHallada.Vive.ToString();
            //Senas Particulares
            Session["SeniasH"] = personaHallada.seniasParticularess;
            this.gvSenasPartH.DataSource = personaHallada.seniasParticularess;
            this.gvSenasPartH.DataBind();
            //Tatuajes
            Session["TatuajesH"] = personaHallada.tatuajesPersonas;
            this.gvTatuajesH.DataSource = personaHallada.tatuajesPersonas;
            this.gvTatuajesH.DataBind();
            ////
            idPersonaHallada = personaHallada.Id;
            switch (state)
            {
                case FuncionesGrales.EstadoPrograma.Creando:
                    break;
                case FuncionesGrales.EstadoPrograma.Modificando:
                    this.cartelConsultandoH.InnerText = "Modificando Persona Hallada";
                    this.cartelConsultandoH.Style.Remove("color");
                    break;
                case FuncionesGrales.EstadoPrograma.Consultando:
                    this.cartelConsultandoH.InnerText = "Consultando Persona Hallada";
                    this.cartelConsultandoH.Style.Remove("display");
                    this.cartelConsultandoH.Style.Remove("color");
                    this.btnGuardarH.Style.Add("display", "none");
                    this.btnVerCriterioBusquedaH.Style.Remove("display");
                    this.btnVerResultadosH.Style.Remove("display");
                    break;
            }
            FotosGralesH.DataSource = PBFotosManager.GetList(idPersonaHallada, (int)FuncionesGrales.TipoBusqueda.PersonaHallada).FindAll(delegate(PBFotos f) { return f.idTipoFoto == (int)FuncionesGrales.TipoFoto.General; });
            FotosSeniasH.DataSource = PBFotosManager.GetList(idPersonaHallada, (int)FuncionesGrales.TipoBusqueda.PersonaHallada).FindAll(delegate(PBFotos f) { return f.idTipoFoto == (int)FuncionesGrales.TipoFoto.SeniasParticulares; });
            FotosHuellasH.DataSource = PBFotosManager.GetList(idPersonaHallada, (int)FuncionesGrales.TipoBusqueda.PersonaHallada).FindAll(delegate(PBFotos f) { return f.idTipoFoto == (int)FuncionesGrales.TipoFoto.Huellas; });
            if (FotosGralesH.Count > 0)
            {
                FotosGralesH.MoveFirst();
                PBFotos f = (PBFotos)FotosGralesH.Current;

                LlenarImgBox(f, FuncionesGrales.TipoBusqueda.PersonaHallada, FuncionesGrales.TipoFoto.General);
                this.lblNroFotoGralH.Text = (FotosGralesH.Position + 1).ToString() + "/" + FotosGralesH.Count.ToString();
                this.lblNroFotoSeniasH.Text = (FotosSeniasH.Position + 1).ToString() + "/" + FotosSeniasH.Count.ToString();
                this.lblNroHuellaH.Text = (FotosHuellasH.Position + 1).ToString() + "/" + FotosHuellasH.Count.ToString();
            }
            if (FotosSeniasH.Count > 0)
            {
                FotosSeniasH.MoveFirst();
                PBFotos f = (PBFotos)FotosSeniasH.Current;
                LlenarImgBox(f, FuncionesGrales.TipoBusqueda.PersonaHallada, FuncionesGrales.TipoFoto.SeniasParticulares);
                this.lblNroFotoGralH.Text = (FotosGralesH.Position + 1).ToString() + "/" + FotosGralesH.Count.ToString();
                this.lblNroFotoSeniasH.Text = (FotosSeniasH.Position + 1).ToString() + "/" + FotosSeniasH.Count.ToString();
                this.lblNroHuellaH.Text = (FotosHuellasH.Position + 1).ToString() + "/" + FotosHuellasH.Count.ToString();
            }
            if (FotosHuellasH.Count > 0)
            {
                FotosHuellasH.MoveFirst();
                PBFotos f = (PBFotos)FotosHuellasH.Current;
                LlenarImgBox(f, FuncionesGrales.TipoBusqueda.PersonaHallada, FuncionesGrales.TipoFoto.Huellas);
                this.lblNroFotoGralH.Text = (FotosGralesH.Position + 1).ToString() + "/" + FotosGralesH.Count.ToString();
                this.lblNroFotoSeniasH.Text = (FotosSeniasH.Position + 1).ToString() + "/" + FotosSeniasH.Count.ToString();
                this.lblNroHuellaH.Text = (FotosHuellasH.Position + 1).ToString() + "/" + FotosHuellasH.Count.ToString();
            }
        
            this.pnlPersonaHallada.Enabled = true;
            this.pnlExtranaJurisdiccion.Enabled = true;

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
                    cantFotos = FotosGralesH.Count;
                    nroFotoActual = FotosGralesH.Position + 1;
                    this.btnBorrarFotoGralH.Enabled = cantFotos > 0;
                    break;
                case FuncionesGrales.TipoFoto.SeniasParticulares:
                    cantFotos = FotosSeniasH.Count;
                    nroFotoActual = FotosSeniasH.Position + 1;
                    this.btnBorrarFotoSeniasH.Enabled = cantFotos > 0;
                    break;
                case FuncionesGrales.TipoFoto.Huellas:
                    cantFotos = FotosHuellasH.Count;
                    nroFotoActual = FotosHuellasH.Position + 1;
                    this.btnBorrarHuellasH.Enabled = cantFotos > 0;
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

                        Session["FotosGralesH"] = FotosGralesH;
                        url = "ImageHandler1.ashx?t=" + ((int)tipoFoto).ToString() + "&r=" + new Random().Next().ToString() + "&bi=f&p=h";
                        this.imgFotoGeneralH.ImageUrl = url;
                        this.upImage.Update();
                        this.imgFotoGeneralH.OnClientClick = "window.open('FullSizeImage.aspx?url=" + url + "')";
                        this.imgFotoGeneralH.Width = dim[0];
                        this.imgFotoGeneralH.Height = dim[1];
                        break;
                    case FuncionesGrales.TipoFoto.SeniasParticulares:
                        Session["FotosSeniasH"] = FotosSeniasH;
                        url = "ImageHandler1.ashx?t=" + ((int)tipoFoto).ToString() + "&r=" + new Random().Next().ToString() + "&bi=f&p=h";
                        this.imgFotoSeniasH.ImageUrl = url;
                        this.imgFotoSeniasH.OnClientClick = "window.open('FullSizeImage.aspx?url=" + url + "')";
                        this.imgFotoSeniasH.Width = dim[0];
                        this.imgFotoSeniasH.Height = dim[1];
                        break;
                    case FuncionesGrales.TipoFoto.Huellas:
                        Session["FotosHuellasH"] = FotosHuellasH;
                        url = "ImageHandler1.ashx?t=" + ((int)tipoFoto).ToString() + "&r=" + new Random().Next().ToString() + "&bi=f&p=h";
                        this.imgHuellasH.ImageUrl = url;
                        this.imgHuellasH.OnClientClick = "window.open('FullSizeImage.aspx?url=" + url + "')";
                        this.imgHuellasH.Width = dim[0];
                        this.imgHuellasH.Height = dim[1];
                        break;
                }
                switch (tipoFoto)
                {
                    case FuncionesGrales.TipoFoto.General:
                        if (cantFotos == 1)
                        {
                            this.btnFotoSigGeneralH.Enabled = false;
                            this.btnFotoPrevGeneralH.Enabled = false;
                        }
                        else if (cantFotos > 1)
                        {
                            if (nroFotoActual == 1)
                            {
                                this.btnFotoSigGeneralH.Enabled = true;
                                this.btnFotoPrevGeneralH.Enabled = false;
                            }
                            else if (nroFotoActual > 1 && nroFotoActual < cantFotos)
                            {
                                this.btnFotoSigGeneralH.Enabled = true;
                                this.btnFotoPrevGeneralH.Enabled = true;
                            }
                            else if (nroFotoActual == cantFotos)
                            {
                                this.btnFotoSigGeneralH.Enabled = false;
                                this.btnFotoPrevGeneralH.Enabled = true;
                            }
                        }
                        else
                        {
                            this.btnFotoSigGeneralH.Enabled = false;
                            this.btnFotoPrevGeneralH.Enabled = false;
                            this.imgFotoGeneralH.ImageUrl = "~/App_Images/SinFoto.GIF";
                            this.imgFotoGeneralH.Width = 80;
                            this.imgFotoGeneralH.Height = 100;
                        }
                        break;
                    case FuncionesGrales.TipoFoto.SeniasParticulares:
                        if (cantFotos == 1)
                        {
                            this.btnFotoSigSeniasH.Enabled = false;
                            this.btnFotoPrevSeniasH.Enabled = false;
                        }
                        else if (cantFotos > 1)
                        {

                            if (nroFotoActual == 1)
                            {
                                this.btnFotoSigSeniasH.Enabled = true;
                                this.btnFotoPrevSeniasH.Enabled = false;
                            }
                            else if (nroFotoActual > 1 && nroFotoActual < cantFotos)
                            {
                                this.btnFotoSigSeniasH.Enabled = true;
                                this.btnFotoPrevSeniasH.Enabled = true;
                            }
                            else if (nroFotoActual == cantFotos)
                            {
                                this.btnFotoSigSeniasH.Enabled = false;
                                this.btnFotoPrevSeniasH.Enabled = true;
                            }
                            else
                            {
                                this.btnFotoSigSeniasH.Enabled = false;
                                this.btnFotoPrevSeniasH.Enabled = false;
                                this.imgFotoSeniasH.ImageUrl = "~/App_Images/SinFoto.GIF";
                                this.imgFotoSeniasH.Width = 80;
                                this.imgFotoSeniasH.Height = 100;
                            }
                        }
                        break;

                    case FuncionesGrales.TipoFoto.Huellas:
                        if (cantFotos == 1)
                        {
                            this.btnSigHuellasH.Enabled = false;
                            this.btnPrevHuellasH.Enabled = false;
                        }
                        else if (cantFotos > 1)
                        {

                            if (nroFotoActual == 1)
                            {
                                this.btnSigHuellasH.Enabled = true;
                                this.btnPrevHuellasH.Enabled = false;
                            }
                            else if (nroFotoActual > 1 && nroFotoActual < cantFotos)
                            {
                                this.btnSigHuellasH.Enabled = true;
                                this.btnPrevHuellasH.Enabled = true;
                            }
                            else if (nroFotoActual == cantFotos)
                            {
                                this.btnSigHuellasH.Enabled = false;
                                this.btnPrevHuellasH.Enabled = true;
                            }
                            else
                            {
                                this.btnSigHuellasH.Enabled = false;
                                this.btnPrevHuellasH.Enabled = false;
                                this.imgHuellasH.ImageUrl = "~/App_Images/SinFoto.GIF";
                                this.imgHuellasH.Width = 80;
                                this.imgHuellasH.Height = 100;
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

            //FileInfo inputFile = new FileInfo(FromFile);
            //if (inputFile.Exists == false)
            //    return null;
            if (imgPhoto == null)
                return null;
            //System.Drawing.Image imgPhoto = System.Drawing.Image.FromFile(FromFile);

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
        /// Llena los controles que muestran los valores de la persona Hallada en la view que permite cargar los parámetros de búsqueda
        /// </summary>
        /// <param name="PersonaHallada">datos de la Persona Hallada</param>
        private void LlenarControlesPersonaHalladasEnBI(/*PersonasHalladas PersonaHallada*/)
        {

            DateTime fecha;
            int entero;
            float flotante;
            this.lblFechaBI.Text = "Fecha Hallazgo";
            if (DateTime.TryParse(this.txtFechaHallazgo.Text.Trim(), out fecha))
                this.lblValorFechaBI.Text = fecha.ToShortDateString();
            else
                this.lblValorFechaBI.Text = "";
            this.lblDNIPersonaBIValor.Text = this.txtDNI.Text.Trim();
            this.lblApellidoPersonaBIValor.Text = this.txtApellidoH.Text.Trim();
            this.lblNombrePersonaBIValor.Text = this.txtNombresH.Text.Trim();
            if (int.TryParse(this.txtEdadAparenteH.Text.Trim(), out entero))
                this.lblValorEdadBI.Text = entero.ToString();
            else if (int.TryParse(this.txtEdadCientificaH.Text.Trim(), out entero))
                this.lblValorEdadBI.Text = entero.ToString();
            if (this.ddlFaltanDientesH.SelectedValue != "")
                this.lblFaltanDientesPersonaBIValor.Text = PBClaseBooleanManager.GetItem(Convert.ToInt32(this.ddlFaltanDientesH.SelectedValue)).Descripcion;
            if (this.ddlAspectoCabelloH.SelectedValue != "")
                this.lblAspectoCabelloPersonaBiValor.Text = PBClaseAspectoCabelloManager.GetItem(Convert.ToInt32(this.ddlAspectoCabelloH.SelectedValue)).Descripcion;
            if (this.ddlCalvicieH.SelectedValue != "")
                this.lblCalviciePersonaBIValor.Text = PBClaseCalvicieManager.GetItem(Convert.ToInt32(this.ddlCalvicieH.SelectedValue)).Descripcion;
            if (this.ddlColorCabelloH.SelectedValue != "")
                this.lblColorCabelloPersonaBIValor.Text = PBClaseColorCabelloManager.GetItem(Convert.ToInt32(this.ddlColorCabelloH.SelectedValue)).Descripcion;
            if (this.ddlColorOjosH.SelectedValue != "")
                this.lblColorOjosBIValor.Text = PBClaseColorOjosManager.GetItem(Convert.ToInt32(this.ddlColorOjosH.SelectedValue)).Descripcion;
            if (this.ddlColorPielH.SelectedValue != "")
                this.lblColorPielPersonaValorBI.Text = PBClaseColorDePielManager.GetItem(Convert.ToInt32(this.ddlColorPielH.SelectedValue)).Descripcion;
            if (this.ddlColorTenidoH.SelectedValue != "")
                this.lblColorTeñidoPersonaBIValor.Text = PBClaseColorCabelloManager.GetItem(Convert.ToInt32(this.ddlColorTenidoH.SelectedValue)).Descripcion;
            if (this.ddlLongitudCabelloH.SelectedValue != "")
                this.lblLongCabelloPersonaBIValor.Text = PBClaseLongitudCabelloManager.GetItem(Convert.ToInt32(this.ddlLongitudCabelloH.SelectedValue)).Descripcion;
            if (this.ddlSexoH.SelectedValue != "")
                this.lblSexoPersonaBIValor.Text = PBClaseSexoManager.GetItem(Convert.ToInt32(this.ddlSexoH.SelectedValue)).Descripcion;
            if (float.TryParse(this.txtPesoH.Text.Trim(), out flotante))
                this.lblPesoPersonaBIValor.Text = flotante.ToString();
            if (float.TryParse(this.txtTallaH.Text.Trim(), out flotante))
                this.lblTallaPersonaBIValor.Text = flotante.ToString();
         //   SeniasParticularesList SeniasH = (SeniasParticularesList)Session["SeniasH"];
            if (SeniasH.Count != 0)
            {
                foreach (SeniasParticulares sp in SeniasH)
                {
                    this.lblSeniaParticularBIValor.Text += ClaseSeniaParticularManager.GetItem(sp.idSeniaParticular).Descripcion + " en " + ClaseUbicacionSeniaPartManager.GetItem(sp.idUbicacionSeniaParticular).Descripcion + ", ";
                }
                this.lblSeniaParticularBIValor.Text = this.lblSeniaParticularBIValor.Text.Substring(0,this.lblSeniaParticularBIValor.Text.Length-2);
            }
            else
            {
                this.lblSeniaParticularBIValor.Text = "";
            }
        //   TatuajesPersonaList TatuajesH = (TatuajesPersonaList)Session["TatuajesH"];
            if (TatuajesH.Count != 0)
            {
                foreach (TatuajesPersona tp in TatuajesH)
                {
                    this.lbltatuajeBIValor.Text += ClaseTatuajeManager.GetItem(tp.idTatuaje).descripcion + " en " + ClaseUbicacionSeniaPartManager.GetItem(tp.idUbicacionTatuaje).Descripcion + ", ";
                }
                this.lbltatuajeBIValor.Text = this.lbltatuajeBIValor.Text.Substring(0, this.lbltatuajeBIValor.Text.Length - 2);
            }
            else
            {
                this.lbltatuajeBIValor.Text = "";
            }

        }

        private void LlenarControlesVerPersonaHalladasCriterioEnBI()
        {
            DateTime fecha;
            int entero;
            float flotante;
            this.lblFechaBI.Text = "Fecha Hallazgo";
            if (DateTime.TryParse(this.txtFechaHallazgo.Text.Trim(), out fecha))
                this.lblVerValorFechaBI.Text = fecha.ToShortDateString();
            else
                this.lblVerValorFechaBI.Text = "";
            this.lblVerDNIPersonaBIValor.Text = this.txtDNI.Text.Trim();
            this.lblVerApellidoPersonaBIValor.Text = this.txtApellidoH.Text.Trim();
            this.lblVerNombrePersonaBIValor.Text = this.txtNombresH.Text.Trim();
            if (int.TryParse(this.txtEdadAparenteH.Text.Trim(), out entero))
                this.lblVerValorEdadBI.Text = entero.ToString();
            else if (int.TryParse(this.txtEdadCientificaH.Text.Trim(), out entero))
                this.lblVerValorEdadBI.Text = entero.ToString();
            if (this.ddlFaltanDientesH.SelectedValue != "")
                this.lblVerFaltanDientesPersonaBIValor.Text = PBClaseBooleanManager.GetItem(Convert.ToInt32(this.ddlFaltanDientesH.SelectedValue)).Descripcion;
            if (this.ddlAspectoCabelloH.SelectedValue != "")
                this.lblVerAspectoCabelloPersonaBiValor.Text = PBClaseAspectoCabelloManager.GetItem(Convert.ToInt32(this.ddlAspectoCabelloH.SelectedValue)).Descripcion;
            if (this.ddlCalvicieH.SelectedValue != "")
                this.lblVerCalviciePersonaBIValor.Text = PBClaseCalvicieManager.GetItem(Convert.ToInt32(this.ddlCalvicieH.SelectedValue)).Descripcion;
            if (this.ddlColorCabelloH.SelectedValue != "")
                this.lblVerColorCabelloPersonaBIValor.Text = PBClaseColorCabelloManager.GetItem(Convert.ToInt32(this.ddlColorCabelloH.SelectedValue)).Descripcion;
            if (this.ddlColorOjosH.SelectedValue != "")
                this.lblVerColorOjosBIValor.Text = PBClaseColorOjosManager.GetItem(Convert.ToInt32(this.ddlColorOjosH.SelectedValue)).Descripcion;
            if (this.ddlColorPielH.SelectedValue != "")
                this.lblVerColorPielPersonaValorBI.Text = PBClaseColorDePielManager.GetItem(Convert.ToInt32(this.ddlColorPielH.SelectedValue)).Descripcion;
            if (this.ddlColorTenidoH.SelectedValue != "")
                this.lblVerColorTeñidoPersonaBIValor.Text = PBClaseColorCabelloManager.GetItem(Convert.ToInt32(this.ddlColorTenidoH.SelectedValue)).Descripcion;
            if (this.ddlLongitudCabelloH.SelectedValue != "")
                this.lblVerLongCabelloPersonaBIValor.Text = PBClaseLongitudCabelloManager.GetItem(Convert.ToInt32(this.ddlLongitudCabelloH.SelectedValue)).Descripcion;
            if (this.ddlSexoH.SelectedValue != "")
                this.lblVerSexoPersonaBIValor.Text = PBClaseSexoManager.GetItem(Convert.ToInt32(this.ddlSexoH.SelectedValue)).Descripcion;
            if (float.TryParse(this.txtPesoH.Text.Trim(), out flotante))
                this.lblVerPesoPersonaBIValor.Text = flotante.ToString();
            if (float.TryParse(this.txtTallaH.Text.Trim(), out flotante))
                this.lblVerTallaPersonaBIValor.Text = flotante.ToString();

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
        /// Limpia los controles de la pantalla de persona hallada
        /// </summary>
        private void LimpiarControlesH()
        {
            Session["imgPreview"] = null;
          
                this.pnlExtranaJurisdiccion.Visible = false;
                this.gvWebServerCausaH.Columns.Clear();
                this.gvWebServerDelitoH.Columns.Clear();
                this.gvWebServerDenuncianteH.Columns.Clear();
                this.gvWebServerImputadoH.Columns.Clear();
                this.gvWebServerPersonasH.Columns.Clear();
                this.gvWebServerVictimaH.Columns.Clear();
            //this.tcTipoJurisdiccion.ActiveTab = this.tpPJ;
            //this.lblCuentaFotosGralesH.Text = "";
            this.divPersonasH.Style.Add("display", "none");
            this.divAgregandoPersona.Style.Add("display", "none");
            this.lblSeccionalNoCoincide.Style.Add("display", "none");
            //this.fuFotoUploaderH.Enabled = false;
            this.gvWebServerCausaH.DataSource = "";
            this.gvWebServerCausaH.DataBind();
            this.gvWebServerDelitoH.DataSource = "";
            this.gvWebServerDelitoH.DataBind();
            this.gvWebServerDenuncianteH.DataSource = "";
            this.gvWebServerDenuncianteH.DataBind();
            this.gvWebServerImputadoH.DataSource = "";
            this.gvWebServerImputadoH.DataBind();
            this.gvWebServerPersonasH.DataSource = "";
            this.gvWebServerPersonasH.DataBind();
            this.gvWebServerVictimaH.DataSource = "";
            this.gvWebServerVictimaH.DataBind();
            //this.lblDepartamentoComisariaH.Text = "";
            this.txtApellidoH.Text = "";
            this.txtNombresH.Text = "";
            this.ddlTipoDoc.SelectedValue = "0";
            this.txtDNI.Text = "";
            this.txtArticulosPersonalesH.Text = "";
            this.txtEdadAparenteH.Text = "";
            this.txtEdadCientificaH.Text = "";
            this.txtFechaHallazgo.Text = "";
            this.txtPesoH.Text = "";
            this.txtRopaH.Text = "";
            this.txtTallaH.Text = "";
            this.lblNroFotoSeniasH.Text = "";
            this.lblNroFotoGralH.Text = "";
            this.lblNroHuellaH.Text = "";
            this.txtCantidadDiasNoAfeitadoH.Text = "";
            this.ddlCalvicieH.SelectedValue = "0";
            this.ddlColorCabelloH.SelectedValue = "0";
            this.ddlColorOjosH.SelectedValue = "0";
            this.ddlColorPielH.SelectedValue = "0";
            this.ddlColorTenidoH.SelectedValue = "0";
            this.lblComisariaPersonaH.Text = "";
            this.ddlOrgIntH.SelectedValue = "0";
            this.ddlSexoH.SelectedValue = "0";
            this.ddlAspectoCabelloH.SelectedValue = "0";
            this.btnImprimirH.OnClientClick = "";

            this.lblPresioneBoton.Style.Add("display", "none");
            //***********************
            //CONTROLAR
            //this.ddlDentaduraH.SelectedValue = "1";
            //************************
            this.ddlRostroH.SelectedValue = "0";
            this.ddlLongitudCabelloH.SelectedValue = "0";
            this.lblLugarHallazgoPersona.Text = " ";
            this.ddlFichasDactilaresH.SelectedValue = "0";
            this.ddlExistenRadiografiasH.SelectedValue = "0";
            this.ddlFaltanDientesH.SelectedValue = "0";
            this.ddlAdnH.SelectedValue = "0";
            this.ddlFotoH.SelectedValue = "0";
            this.ddlViveH.SelectedValue = "0";
            this.lblPartidoHallazgo.Text = "";
            this.lblNroFotoGralH.Text = "";
            this.lblLugarHallazgoPersona.Text = "";
            this.lblProvinciaHallazgo.Text = "";
            this.hfLugarHId.Value = "0";//valor por defecto cuando no hay lugar indicado
            this.hfComisariaHId.Value = "0";//valor por defecto cuando no hay comisaria indicada
            this.lblGuardoExitoH.Visible = false;
            //this.cartelConsultandoH.Style.Add("display", "none");
            this.btnBorrarH.Style.Add("display", "none");
            SeniasH = null;
            SeniasH = new SeniasParticularesList();
           
            this.gvSenasPartH.DataSource = SeniasH;
            this.gvSenasPartH.DataBind();
            this.btnAgregarMailAsociado.Visible = false;
            this.gvMailsAsociados.DataSource = "";
            this.gvMailsAsociados.DataBind();
            TatuajesH = null;
            TatuajesH = new TatuajesPersonaList();
            this.gvTatuajesH.DataSource = TatuajesH;
            this.gvTatuajesH.DataBind();
            this.btnVerCriterioBusquedaH.Style.Add("display", "none");
            this.btnGuardarH.Style.Add("display","none");
            this.btnVerResultadosH.Style.Add("display", "none");
            //this.btnGuardarH.Style.Add("display", "none");
            this.btnImprimirH.Style.Add("display", "none");
            this.imgFotoGeneralH.ImageUrl = null;
            this.imgFotoSeniasH.ImageUrl = null;
            this.imgHuellasH.ImageUrl = null;
            this.imgFotoGeneralH.ImageUrl = "~/App_Images/SinFoto.GIF";
            this.imgFotoGeneralH.Width = 80;
            this.imgFotoGeneralH.Height = 100;
            this.imgFotoSeniasH.ImageUrl = "~/App_Images/SinFoto.GIF";
            this.imgFotoSeniasH.Width = 80;
            this.imgFotoSeniasH.Height = 100;
            this.imgHuellasH.ImageUrl = "~/App_Images/SinFoto.GIF";
            this.imgHuellasH.Width = 80;
            this.imgHuellasH.Height = 100;
            this.btnBorrarFotoGralH.Enabled = false;
            this.btnFotoPrevGeneralH.Enabled = false;
            this.btnFotoSigGeneralH.Enabled = false;
            this.btnBorrarFotoSeniasH.Enabled = false;
            this.btnFotoPrevSeniasH.Enabled = false;
            this.btnFotoSigSeniasH.Enabled = false;
            this.btnBorrarHuellasH.Enabled = false;
            this.btnPrevHuellasH.Enabled = false;
            this.btnSigHuellasH.Enabled = false;
            this.lblProvinciaHallazgo.Text = "";
            this.btnVerResultadosH.Style.Add("display", "none");
            this.btnVerCriterioBusquedaH.Style.Add("display", "none");
            FotosSeniasH.DataSource = null;
            FotosGralesH.DataSource = null;
            FotosHuellasH.DataSource = null;
            Session["FotosSeniasH"] = null;
            Session["FotosGralesH"] = null;
            Session["FotosHuellasH"] = null;
            Session["idPersonaHallada"] = -1;
            this.rblTipoFotos.SelectedIndex = 0;
          

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

        /// <summary>
        /// Guarda los datos de la persona hallada
        /// </summary>
        /// <param name="miBusqueda">parametros de busqueda</param>
        /// <returns>Devuelve si guardo o no con exito</returns>
        private bool GuardarPersonasHalladas(Busqueda miBusqueda, int id)
        {
            bool GuardoBien = false;
            PersonasHalladas personaHallada = new PersonasHalladas();
            personaHallada.busqueda = miBusqueda;
            int entero;
            DateTime fecha;
            float flotante;
            personaHallada.Id = id;
            personaHallada.tieneADN = Convert.ToInt32(this.ddlAdnH.SelectedValue);
            if (this.tcTipoJurisdiccion.ActiveTab == this.tpPJ)
                personaHallada.Ipp = this.txtIppBuscadoH.Text.Trim();
            else if (this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur)
                personaHallada.Ipp = this.txtCausa.Text.Trim();
            personaHallada.Apellido = this.txtApellidoH.Text.Trim();
            personaHallada.Nombre = this.txtNombresH.Text.Trim();
            personaHallada.idTipoDNI = Convert.ToInt32(this.ddlTipoDoc.SelectedValue);
            personaHallada.DNI = this.txtDNI.Text.Trim();
            personaHallada.RestosOseos = this.cvRestoOseo.Checked;
            personaHallada.ArticulosPersonales = this.txtArticulosPersonalesH.Text.Trim();
            if (int.TryParse(this.txtCantidadDiasNoAfeitadoH.Text.Trim(), out entero))
                personaHallada.CantidadDiasNoAfeitado = entero;
            else
                personaHallada.CantidadDiasNoAfeitado = null;
            if (int.TryParse(this.txtEdadAparenteH.Text.Trim(), out entero))
                personaHallada.EdadAparente = entero;
            else
                personaHallada.EdadAparente = null;
            if (int.TryParse(this.txtEdadCientificaH.Text.Trim(), out entero))
                personaHallada.EdadCientifica = entero;
            else
                personaHallada.EdadCientifica = null;
            personaHallada.ExistenRadiografia = Convert.ToInt32(this.ddlExistenRadiografiasH.SelectedValue);
            personaHallada.FaltanPiezasDentales = Convert.ToInt32(this.ddlFaltanDientesH.SelectedValue);

            if (DateTime.TryParse(this.txtFechaHallazgo.Text.Trim(), out fecha))
                personaHallada.FechaHallazgo = fecha;
            else
                personaHallada.FechaHallazgo = null;
            personaHallada.FichasDactilares = Convert.ToInt32(this.ddlFichasDactilaresH.SelectedValue);
            if (this.ddlFotoH.SelectedValue != null & this.ddlFotoH.SelectedValue.Trim() != "")
                personaHallada.Foto = Convert.ToInt32(this.ddlFotoH.SelectedValue);
            personaHallada.idAspectoCabello = Convert.ToInt32(this.ddlAspectoCabelloH.SelectedValue);
            personaHallada.idCalvicie = Convert.ToInt32(this.ddlCalvicieH.SelectedValue);
            personaHallada.idColorCabello = Convert.ToInt32(this.ddlColorCabelloH.SelectedValue);
            personaHallada.idColorOjos = Convert.ToInt32(this.ddlColorOjosH.SelectedValue);
            personaHallada.idColorPiel = Convert.ToInt32(this.ddlColorPielH.SelectedValue);
            personaHallada.idColorTenido = Convert.ToInt32(this.ddlColorTenidoH.SelectedValue);
            //****************************
            if (Int32.TryParse(this.hfComisariaHId.Value, out entero))
                personaHallada.idComisaria = entero;
            else
                personaHallada.idComisaria = 0;
            personaHallada.idDentadura = 1;
            //***************************
            //personaHallada.idDentadura = Convert.ToInt32(this.ddlDentadura.SelectedValue);
            personaHallada.idLongitudCabello = Convert.ToInt32(this.ddlLongitudCabelloH.SelectedValue);
            //*****************************
            if (Int32.TryParse(this.hfLugarHId.Value, out entero))
                personaHallada.idLugarHallazgo = entero;
            else
                personaHallada.idLugarHallazgo = 0;
            personaHallada.idLugarHallazgo = Convert.ToInt32(this.hfLugarHId.Value);
            personaHallada.idOrganismoInterviniente = Convert.ToInt32(this.ddlOrgIntH.SelectedValue);
            personaHallada.idRostro = Convert.ToInt32(this.ddlRostroH.SelectedValue);
            personaHallada.idSexo = Convert.ToInt32(this.ddlSexoH.SelectedValue);
            //personaHallada.Ipp = this.txtIppBuscadoH.Text.Trim();
            if (float.TryParse(this.txtPesoH.Text.Trim(), out flotante))
                personaHallada.Peso = flotante;
            else
                personaHallada.Peso = null;
            personaHallada.Ropa = this.txtRopaH.Text.Trim();
            if (float.TryParse(this.txtTallaH.Text.Trim(), out flotante))
                personaHallada.Talla = flotante;
            else
                personaHallada.Talla = null;
            //***************************
            personaHallada.UFI = Session["miUfi"].ToString();
            //***************************
            personaHallada.Vive = Convert.ToInt32(this.ddlViveH.SelectedValue);
            personaHallada.FechaUltimaModificacion = DateTime.Now;
            personaHallada.UsuarioUltimaModificacion = Session["miUsuario"].ToString();
            if (personaHallada.Id == -1)
            {
                personaHallada.FechaAlta = DateTime.Now;
                personaHallada.UsuarioAlta = Session["miUsuario"].ToString();
            }
            else
            {
                PersonasHalladas ph = PersonasHalladasManager.GetItem(id);
                personaHallada.FechaAlta = ph.FechaAlta;
                personaHallada.UsuarioAlta = ph.UsuarioAlta;
            }
            //if (id != -1)
            //{
                //Senas Particulares
                SeniasParticularesList spl = SeniasParticularesManager.GetList(personaHallada.Id, (int)FuncionesGrales.TipoBusqueda.PersonaHallada);
                foreach (SeniasParticulares sp in spl)
                {
                    SeniasParticularesManager.Delete(sp);
                }
                if (SeniasH != null)
                {
                    foreach (SeniasParticulares sp in SeniasH)
                    {
                        sp.id = -1;
                    
                    }
                    personaHallada.seniasParticularess = SeniasH;
                }
                //Tatuajes
                TatuajesPersonaList tpl = TatuajesPersonaManager.GetList(personaHallada.Id, (int)FuncionesGrales.TipoBusqueda.PersonaHallada);
                foreach (TatuajesPersona tp in tpl)
                {
                    TatuajesPersonaManager.Delete(tp);
                }
                if (TatuajesH != null)
                {
                    foreach (TatuajesPersona tp in TatuajesH)
                    {
                        tp.id = -1;
                    }
                }
                personaHallada.tatuajesPersonas = TatuajesH;
            //}
            
            //Guarda fotos
                if (FotosGralesH.Count > 0 || FotosSeniasH.Count > 0 || FotosHuellasH.Count > 0)
            {
                PBFotosList fotos = new PBFotosList();
                for (int i = 0; i < FotosGralesH.Count; i++)
                {
                    PBFotos f = (PBFotos)FotosGralesH[i];
                    fotos.Add(f);
                }
                for (int i = 0; i < FotosSeniasH.Count; i++)
                {
                    PBFotos f = (PBFotos)FotosSeniasH[i];
                    fotos.Add(f);
                }
                for (int i = 0; i < FotosHuellasH.Count; i++)
                {
                    PBFotos f = (PBFotos)FotosHuellasH[i];
                    fotos.Add(f);
                }
                personaHallada.fotoss = fotos;
            }

            //Extrana Jurisdiccion
            if (this.tcTipoJurisdiccion.ActiveTab == this.tpPJ)
                personaHallada.esExtJurisdiccion = false;
            else if (this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur)
            {
                personaHallada.esExtJurisdiccion = true;
                PBCausaExtranaJurisdiccion extJur = PBCausaExtranaJurisdiccionManager.GetItem(this.txtCausa.Text.Trim(), 2);
                //PBCausaExtranaJurisdiccion extJur = personaHallada.PBCausaExtranaJurisdiccion;
                if (extJur == null)
                {
                    extJur = new PBCausaExtranaJurisdiccion();
                    extJur.id = -1;
                }
               
                 //   extJur = personaHallada.PBCausaExtranaJurisdiccion;
                extJur.NroCausa = personaHallada.Ipp.Trim();
                extJur.caratula = this.txtCaratulaExtJur.Text.Trim();
                extJur.idTipoBusqueda = 2;
                extJur.Jurisdiccion = this.txtJurisdiccionExtJur.Text.Trim();
                extJur.mail = this.txtMailExtJur.Text.Trim();
                extJur.OrganoRequirente = this.txtOrgReqExtJur.Text.Trim();
                extJur.Provincia = this.ddlProvinciaExtJur.SelectedValue;
                extJur.telefono = this.txtTelefonoExtJur.Text.Trim();
                personaHallada.PBCausaExtranaJurisdiccion = extJur;
            }

            idPersonaHallada = PersonasHalladasManager.Save(personaHallada);
            if (idPersonaHallada > 0 && id == -1)
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
                mailAsociado.idPersonaBuscada = idPersonaHallada;
                mailAsociado.idTipoPersona = 2;
                mailAsociado.id = -1;
                mailAsociado.seleccionado = true;
                bool guardoBienMailAsociado = MailsAsociadosPersonasBuscadasManager.Save(mailAsociado) > 0;
                //**************************
                if (guardoBienMailAsociado)
                {
                    TraerMailsAsociados(idPersonaHallada);
                    this.btnAgregarMailAsociado.Visible = true;
                }
                string esExJur= this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur?"1":"0";
                this.btnImprimirH.OnClientClick = "window.open('ReporteFormH.aspx?Ipp=" + personaHallada.Ipp + "&id=" + personaHallada.Id.ToString() + "&esExJur=" + esExJur + "')";
                this.btnImprimirH.Style.Remove("display");
                ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Cambios guardados correctamente.');", true);
                //this.lblGuardoExitoH.Visible = true;
                //this.lblGuardoExitoH.Style.Remove("display");
                this.btnVerResultadosH.CommandArgument = idPersonaHallada.ToString();
                this.btnVerCriterioBusquedaH.CommandArgument = miBusqueda.Id.ToString();
                SeniasH = null;
                GuardoBien = true;
            }
            else if (idPersonaHallada > 0 && id > -1)
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
              
                string pathOrigen = "";
              



              
                PBFotos foto = new PBFotos();
                foto.id = -1;
                foto.idPersona = idPersonaHallada;
                foto.idTablaDestino = (int)tipoBusqueda;
                foto.idTipoFoto = (int)tipoFoto;

                if (nameFotoOriginal == "")
                {
                    foto.Foto = (Byte[])Session["imgPreview"];
                  
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
                this.gvWebServerCausaH.Columns.Clear();
                this.gvWebServerDelitoH.Columns.Clear();
                this.gvWebServerDenuncianteH.Columns.Clear();
                this.gvWebServerImputadoH.Columns.Clear();
                this.gvWebServerPersonasH.Columns.Clear();
                this.gvWebServerVictimaH.Columns.Clear();


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
                                        List<Comisaria> com =ComisariaManager.GetList().FindAll(delegate(Comisaria c) { return c.comisaria.Trim().ToLower() == comisaria; });
                                        if (com.Count != 0)
                                        {
                                            if (state == FuncionesGrales.EstadoPrograma.Creando)
                                            {
                                                int idComisaria = com[0].id;
                                                hfComisariaHId.Value = idComisaria.ToString();
                                                this.lblComisariaPersonaH.Text = comisaria;
                                            }
                                            else
                                            {
                                                if (comisaria != this.lblComisariaPersonaH.Text.ToLower())
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

                        case FuncionesGrales.TipoBusqueda.PersonaHallada:
                            this.gvWebServerCausaH.DataSource = tblWebServerCausa;
                            this.gvWebServerCausaH.DataBind();
                            this.gvWebServerDelitoH.DataSource = tblWebServerDelito;
                            this.gvWebServerDelitoH.DataBind();
                            this.gvWebServerDenuncianteH.DataSource = tblWebServerDenunciante;
                            this.gvWebServerDenuncianteH.DataBind();
                            this.gvWebServerImputadoH.DataSource = tblWebServerImputado;
                            this.gvWebServerImputadoH.DataBind();
                            this.gvWebServerPersonasH.DataSource = tblWebServerPersonas;
                            this.gvWebServerPersonasH.DataBind();
                            this.gvWebServerVictimaH.DataSource = tblWebServerVictima;
                            this.gvWebServerVictimaH.DataBind();
                            break;
                    }
                }
                int status = Convert.ToInt32(Request.QueryString["status"]);
                if (status == (int)FuncionesGrales.EstadoPrograma.Creando & this.gvWebServerCausaH.Rows.Count > 0)
                {
                    this.lblComisariaPersonaH.Text = this.gvWebServerCausaH.Rows[0].Cells[4].Text.Trim().ToLower();
                    if (this.lblComisariaPersonaH.Text != "&nbsp;")
                    {
                        this.ddlOrgIntH.SelectedValue = "2";
                        if (ComisariaManager.GetItemByDescripcion(this.lblComisariaPersonaH.Text.Trim())!= null)
                            this.hfComisariaHId.Value = ComisariaManager.GetItemByDescripcion(this.lblComisariaPersonaH.Text.Trim()).id.ToString();
                    }
                }
                if (status == (int)FuncionesGrales.EstadoPrograma.Modificando & this.gvWebServerCausaH.Rows.Count > 0)
                {
                    if (this.gvWebServerCausaH.Rows[0].Cells[4].Text.Trim().ToLower() != this.lblComisariaPersonaH.Text.ToLower())
                        this.lblSeccionalNoCoincide.Style.Remove("display");
                    else
                        this.lblSeccionalNoCoincide.Style.Add("display", "none");
                    
                }
               
            }

            catch { }


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

                case FuncionesGrales.TipoBusqueda.PersonaHallada:
                    return PersonasHalladasManager.GetList(b).FindAll(delegate(PersonasHalladas ph) { return ph.esExtJurisdiccion == esExtJur; }).Count > 0;
            }
            return false;
        }

        protected void btnCerrarVerCriterioBI_Click(object sender, EventArgs e)
        {
            this.hfVerCriterioBI_ModalPopupExtender.Hide();
        }

        protected void btnAgregarPersonaH_Click(object sender, EventArgs e)
        {
            idPersonaHallada = 0;

            Session["FotosGralesD"] = null;
            Session["FotosSeniasD"] = null;
            Session["FotosGralesBI"] = null;
            Session["FotosSeniasBI"] = null;
            Session["TatuajesD"] = new TatuajesPersonaList();
            Session["TatuajesH"] = new TatuajesPersonaList();
            Session["TatuajesBI"] = new TatuajesPersonaList();
            Session["SeniasD"] = new SeniasParticularesList();
            Session["SeniasH"] = new SeniasParticularesList();
            Session["SeniasBI"] = new SeniasParticularesList();
            state = FuncionesGrales.EstadoPrograma.Agregando;
            LimpiarControlesBI();
            LimpiarControlesH();
            if (this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur)
                this.pnlExtranaJurisdiccion.Visible = true;
            else
                this.pnlExtranaJurisdiccion.Visible = false;
            LimpiarControlesFichaPersDesapBI();
            LimpiarControlesVerCriterioBI();
            this.btnGuardarH.Style.Remove("display");
            //this.lblAgregandoPersona.Visible = true;
            this.divAgregandoPersona.Style.Remove("display");
            this.pnlPersonaHallada.Enabled = true;
        }

        protected void gvPersonasH_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblGuardoExitoH.Visible = false;
            LimpiarControlesH();
            this.divPersonasH.Style.Remove("display");
            SetearGvPersonas();
            string ipp = "";
            if (this.tcTipoJurisdiccion.ActiveTab == this.tpPJ)
                ipp = this.txtIppBuscadoH.Text.Trim();
            else if (this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur)
                ipp = this.txtCausa.Text.Trim();
            int idDelito= Convert.ToInt32(this.gvPersonasH.DataKeys[this.gvPersonasH.SelectedIndex].Value);
            PersonasHalladas myPH = PersonasHalladasManager.GetItem(idDelito, true);
            LlenarControlesH(myPH);
            BuscarIppEnWebService(this.txtIppBuscadoH.Text.Trim(), FuncionesGrales.TipoBusqueda.PersonaHallada);
            LlenarControlesBI(myPH.busqueda);
            this.btnVerCriterioBusquedaH.CommandArgument = myPH.busqueda.Id.ToString();
            this.btnVerResultadosH.CommandArgument = myPH.Id.ToString();
            Session["idPersonaHallada"] = myPH.Id;
            this.btnImprimirH.Style.Remove("display");
            //this.btnImprimirH.OnClientClick = "window.open('WebForm2.aspx?id=" + idPersonaHallada + "')";
            string esExJur= this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur?"1":"0";
            this.btnImprimirH.OnClientClick = "window.open('ReporteFormH.aspx?Ipp=" + myPH.Ipp + "&id=" + idPersonaHallada.ToString() + "&esExJur="+esExJur+"')";
            this.btnVerCriterioBusquedaH.Style.Remove("display");
            this.btnVerResultadosH.Style.Remove("display");
            
            this.fuFotoUploaderH.Enabled = true;
            if (state == FuncionesGrales.EstadoPrograma.Creando || state == FuncionesGrales.EstadoPrograma.Consultando)
            {
                this.pnlPersonaHallada.Enabled = false;
                this.btnGuardarH.Style.Add("display", "none");
            }
            else if (state == FuncionesGrales.EstadoPrograma.Modificando)
            {
                this.pnlPersonaHallada.Enabled = true;
                this.btnGuardarH.Style.Remove("display");
            }
            TraerMailsAsociados(idDelito);
        }

        private void SetearGvPersonas()
        {
            foreach (GridViewRow row in this.gvPersonasH.Rows)
            {
                row.BackColor = Color.Transparent;
                row.ForeColor = Color.Blue;
                row.BorderColor = Color.Black;
                row.BorderWidth = 2;
                int cantPersonasH = this.gvPersonasH.Rows.Count;
                if (cantPersonasH > 0)
                {
                    Button btnElegirPersonaH = (Button)row.Cells[0].FindControl("btnElegirPersonaH");
                    Button btnBorrarPersonaH = (Button)row.Cells[0].FindControl("btnBorrarPersonaH");
                    btnElegirPersonaH.Visible = cantPersonasH > 1;
                    btnBorrarPersonaH.Visible = cantPersonasH > 1;
                }
            }
            if (this.gvPersonasH.SelectedIndex == -1 && this.gvPersonasH.Rows.Count > 0)
                this.gvPersonasH.SelectedIndex = 0;
            int ind = -1;
            foreach (GridViewRow gvr in this.gvPersonasH.Rows)
            {
                gvr.BorderColor = Color.White;
                gvr.BorderStyle = BorderStyle.Solid;
                gvr.BorderWidth = 2;
                Button btnElegirPersonaD = (Button)gvr.FindControl("btnElegirPersonaH");
                Button btnBorrarPersonaD = (Button)gvr.FindControl("btnBorrarPersonaH");
                Label lblBajaPersonaD = (Label)gvr.FindControl("lblBajaPersona");
                CheckBox cbaja = (CheckBox)gvr.Cells[6].FindControl("Baja");
                bool dadoDeBaja = cbaja.Checked;
                btnElegirPersonaD.Visible = !dadoDeBaja;
                btnBorrarPersonaD.Visible = false;
                lblBajaPersonaD.Visible = dadoDeBaja;

                foreach (TableCell c in gvr.Cells)
                {
                    TableCell celda = c;
                    switch (((DataControlFieldCell)c).ContainingField.ToString().Trim().ToUpper())
                    {
                        case "FECHA HALLAZGO":
                            if (c.Text != null)
                            {
                                DateTime dtHallada;
                                if (DateTime.TryParse(c.Text, out dtHallada))
                                {
                                    c.Text = dtHallada.ToString("dd/MM/yyyy");
                                }
                                else
                                    c.Text = "";
                            }
                            break;
                    }
                }
            }
            if (this.gvPersonasH.Rows.Count>0 && this.gvPersonasH.SelectedRow != null)
            {
                GridViewRow gvr = this.gvPersonasH.SelectedRow;
                gvr.BorderColor = Color.Brown;
                gvr.BorderStyle = BorderStyle.Solid;
                gvr.BorderWidth = 4;
                //gvr.BackColor = Color.FromName("#13507d");
                Button btnElegirPersonaH = (Button)gvr.FindControl("btnElegirPersonaH");
                CheckBox cbaja = (CheckBox)gvr.FindControl("Baja");
                if (cbaja.Checked)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Se dio de baja a la persona hallada seleccionada. No podra hacer modificaciones.');", true);
                    this.fuFotoUploaderH.Enabled = false;
                    this.pnlPersonaHallada.Enabled = false;
                    this.btnAgregarMailAsociado.Style.Add("display", "none");
                    this.btnGuardarH.Style.Add("display", "none");

                }
                else
                    this.btnAgregarMailAsociado.Style.Remove("display");

                if (btnElegirPersonaH != null)
                    btnElegirPersonaH.Visible = false;
                if (state == FuncionesGrales.EstadoPrograma.Consultando)
                    this.btnAgregarMailAsociado.Style.Add("display", "none");
                else
                    this.btnAgregarMailAsociado.Style.Remove("display");
            }
          
        }

        protected void gvPersonasH_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
            ScriptManager.RegisterStartupScript(this, typeof(string), "Borrar", "confirm('Seguro que desea borrar?');", true);
            int id = Convert.ToInt32(this.gvPersonasH.DataKeys[e.RowIndex].Value);
            string ipp = "";
            PersonasHalladas ph = PersonasHalladasManager.GetItem(id, true);
            ph.Baja = true;

            PersonasHalladasManager.Save(ph);
            List<PersonasHalladas> myPersonas=null;
            if (this.tcTipoJurisdiccion.ActiveTab == this.tpPJ)
            {
                ipp = this.txtIppBuscadoH.Text.Trim();
                myPersonas = PersonasHalladasManager.GetListByIPP(ipp).FindAll(delegate(PersonasHalladas p) { return p.Baja == false && (p.esExtJurisdiccion == null || p.esExtJurisdiccion == false); });
            }
            else if (this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur)
            {
                ipp = this.txtCausa.Text.Trim();
                myPersonas = PersonasHalladasManager.GetListByIPP(ipp).FindAll(delegate(PersonasHalladas p) { return p.Baja == false && (p.esExtJurisdiccion != null && p.esExtJurisdiccion == true); });
            }
          
            if (myPersonas.Count > 0)
            {

                this.gvPersonasH.DataSource = myPersonas;
                this.gvPersonasH.DataBind();
                this.gvPersonasH.SelectedIndex = 0;
            }

            if (this.gvPersonasH.Rows.Count > 0)
            {
                this.gvPersonasH.SelectedIndex = 0;
                int idDelito = Convert.ToInt32(this.gvPersonasH.DataKeys[this.gvPersonasH.SelectedIndex].Value);
                PersonasHalladas myPH = PersonasHalladasManager.GetItem(idDelito, true);
                LlenarControlesH(myPH);
            }
            SetearGvPersonas();
            TraerMailsAsociados(idPersonaHallada);
        }

        protected void btnCancelarAgregarPersonaH_Click(object sender, EventArgs e)
        {
            this.divAgregandoPersona.Style.Add("display", "none");
            this.divPersonasH.Style.Remove("display");
            if (this.gvPersonasH.Rows.Count > 0)
            {
                FuncionesGrales.EstadoPrograma estado = state;
                this.gvPersonasH.SelectedIndex = 0;
                state = FuncionesGrales.EstadoPrograma.Modificando;
                this.gvPersonasH_SelectedIndexChanged(this.gvPersonasH, null);
                state = estado;

            }
            SetearGvPersonas();
            if (this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur)
                this.pnlExtranaJurisdiccion.Visible = true;
            else
                this.pnlExtranaJurisdiccion.Visible = false;
            if (state == FuncionesGrales.EstadoPrograma.Creando)
            {
                this.pnlPersonaHallada.Enabled = this.gvPersonasH.Rows.Count == 0;
            }
        }

        

        #endregion


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
            string mail = this.txtMailAsociado.Text.Trim();
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
            if (mail.Contains('@') || mail.Length < 3)
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
                mailAsociado.idPersonaBuscada = idPersonaHallada;
                mailAsociado.idTipoPersona = 2;
                mailAsociado.id = -1;
                mailAsociado.seleccionado = true;
                MailsAsociadosPersonasBuscadasManager.Save(mailAsociado);
                TraerMailsAsociados(idPersonaHallada);
                this.hfGestionMailAsociado_ModalPopupExtender.Hide();
                this.pnlMailAsociado.Style.Add("display", "none");
            }

        }

       

        protected void tcTipoJurisdiccion_ActiveTabChanged(object sender, EventArgs e)
        {
            this.pnlPersonaHallada.Enabled = false;
            if (this.tcTipoJurisdiccion.ActiveTab == this.tpPJ)
            {
                this.pnlExtranaJurisdiccion.Visible = false;
                LimpiarControlesH();
                LimpiarControlesBI();
                this.txtIppBuscadoH.Focus();
            }
            else if (this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur)
            {
                this.pnlExtranaJurisdiccion.Visible = false;
                LimpiarControlesH();
                LimpiarControlesBI();
                LimpiarControlesExtJur();
                this.txtCausa.Focus();
            }
        }

        protected void btnImprimirH_Click(object sender, EventArgs e)
        {
            SetearGvPersonas();
        }

        private bool ValidarTatuajes()
        {
            int idTatuaje = 0;
            int idUbicacionTatuaje = 0;
            if (this.gvTatuajesH.Rows.Count == 0)
            {
                idTatuaje = Convert.ToInt32(((DropDownList)this.gvTatuajesH.Controls[0].Controls[0].Controls[0].FindControl("ddlTatuajes")).SelectedValue);
                idUbicacionTatuaje = Convert.ToInt32(((DropDownList)this.gvTatuajesH.Controls[0].Controls[0].Controls[0].FindControl("ddlUbicacionTatuaje")).SelectedValue);
            }
            else
            {
                idTatuaje = Convert.ToInt32(((DropDownList)this.gvTatuajesH.FooterRow.FindControl("ddlTatuajeInsert")).SelectedValue);
                idUbicacionTatuaje = Convert.ToInt32(((DropDownList)this.gvTatuajesH.FooterRow.FindControl("ddlUbicacionTatuajeInsert")).SelectedValue);

            }
            if (idTatuaje != 0 || idUbicacionTatuaje != 0)
            {
                this.cvTatuajeSinIncorporar.IsValid = false;
                return false;
            }
            else
            {
                this.cvTatuajeSinIncorporar.IsValid = true;
                return true;
            }
        }

        private bool ValidarSenas()
        {
            int idSena = 0;
            int idUbicacionSena = 0;
            if (this.gvSenasPartH.Rows.Count == 0)
            {
                idSena = Convert.ToInt32(((DropDownList)this.gvSenasPartH.Controls[0].Controls[0].Controls[0].FindControl("ddlSenasParticulares")).SelectedValue);
                idUbicacionSena = Convert.ToInt32(((DropDownList)this.gvSenasPartH.Controls[0].Controls[0].Controls[0].FindControl("ddlUbicacionSenasPart")).SelectedValue);
            }
            else
            {
                idSena = Convert.ToInt32(((DropDownList)this.gvSenasPartH.FooterRow.FindControl("ddlSeniaPartInsert")).SelectedValue);
                idUbicacionSena = Convert.ToInt32(((DropDownList)this.gvSenasPartH.FooterRow.FindControl("ddlUbicacionSenaPartInsert")).SelectedValue);

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
                MailsAsociados = MailsAsociadosPersonasBuscadasManager.GetListByPersonaBuscada(idPersonaHallada, 1);
                this.gvMailsAsociados.DataSource = MailsAsociados;
                this.gvMailsAsociados.DataBind();
            }
        }

        

      
        
    }
}
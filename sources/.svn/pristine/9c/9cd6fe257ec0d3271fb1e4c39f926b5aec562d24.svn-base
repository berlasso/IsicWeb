using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPBA.AutoresIgnorados.Bll;
using MPBA.PersonasBuscadas.Bll;
using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Bll;
using MPBA.SIAC.Web;
using System.Data;
using System.Xml;
using System.Threading;
using System.Globalization;
using Subgurim.Controles;
using System.Configuration;


namespace MPBA.AutoresIgnorados.Web
{
    public partial class BusquedaAutores : System.Web.UI.Page
    {
        private static LocalidadList Localidades;//guarda todas las localidades indicadas para buscar
        private static DepartamentoList Departamentos;//guarda todos los departamentos indicados para buscar
        private static PartidoList Partidos;//guarda todos los partidos indicados para buscar
        private static ComisariaList Comisarias;//guarda todas las comisarias indicadas para buscar
        SeniasParticularesList SeniasD;
        TatuajesPersonaList TatuajesD;
        private string MapaconSimbologia = "N";
        List<GoogleMarker> marcadores;
        FuncionesGenerales.TipoAutores TipoAutor;
        string TipoBusqueda = "1";

        



        protected void Page_Load(object sender, EventArgs e)
        {
           /* TipoAutor = (FuncionesGenerales.TipoAutores)(Convert.ToInt32(Request.QueryString["tipo"].ToString().Substring(0, 1)));*/
            /*  if 
              this.chkIg.Checked = habilitar;
               this.chkAp.Checked = habilitar;

                 Desconocidos = 1,
               Conocidos = 2,

          
             */
            if  ((this.chkIg.Checked == false && this.chkAp.Checked == false) ||  (this.chkIg.Checked ==true && this.chkAp.Checked == true))
            {       TipoAutor=FuncionesGenerales.TipoAutores.Todos;
            }
            else
            {
               if (this.chkIg.Checked)
                   { TipoAutor=FuncionesGenerales.TipoAutores.Desconocidos; }

                if (this.chkAp.Checked)
                    {TipoAutor=FuncionesGenerales.TipoAutores.Conocidos; }

            }

            /*El TipoBusqueda es obsoleto indica lo mismo que tipoAutor, surgio por las consultas de Dragui que partian de Autores conocidos o Ignorados*/
         /*   TipoBusqueda = Request.QueryString["tipoB"].ToString();*/
            TipoBusqueda = "1";
            if (!Page.IsPostBack)
            {

            

                //Session["idPuntoGestion"] = "2899";
                //this.gv.DataSource = BusquedaRobosDelitosSexualesManager.GetListByPuntoGestion(Session["idPuntoGestion"].ToString());
                //this.gvMisBusquedas.DataSource = BusquedaRobosDelitosSexualesManager.GetListByPuntoGestion(Session["idPuntoGestion"].ToString());
                //this.gv.DataBind();
                //this.gvMisBusquedas.DataBind();

            
                   

               string moduloActual = Request.QueryString["tipo"].ToString().Substring(1, 1);
               string norefresca = Request.QueryString["resultados"];   

               switch (moduloActual)
               {
                   case "1":
                       Session["moduloActual"] = "RH";
                       break;
                   case "2":
                       Session["moduloActual"] = "DS";
                        break;
               }
                
                
                
                //switch (TipoAutor)
                //{
                //    case FuncionesComunes.TipoAutores.Desconocidos:
                //        cartelPrincipal.InnerText = "ANALISIS";
                //        this.pnlAutorConocido.Visible = false;
                //        this.tpBienesSustraidos.Visible = true;
                //        break;
                //    case FuncionesComunes.TipoAutores.Conocidos:
                //        cartelPrincipal.InnerText = "ANALISIS";
                //        this.pnlAutorConocido.Visible = true;
                //        this.tpBienesSustraidos.Visible = false;
                //        break;
                //    default:
                //        break;
                //}

                switch (TipoBusqueda)
                {
                    case "1"://analisis
                        this.cartelPrincipal.InnerText = "ANALISIS";
                        this.pnlAutorConocido.Visible = true;
                        this.tpBienesSustraidos.Visible = true;
                        break;
                    case "2"://busqueda autores conocidos SIAC
                        this.cartelPrincipal.InnerText = "BUSQUEDA POR AUTORES CONOCIDOS";
                        this.pnlAutorConocido.Visible = true;
                        this.tcBusquedaAutores.ActiveTab = this.tpAutores;
                        this.tpBienesSustraidos.Visible = false;
                        break;
                    case "3"://busqueda autores conocidos SIAC
                        this.cartelPrincipal.InnerText = "BUSQUEDA DELITOS POR AUTORES IGNORADOS";
                        this.pnlAutorConocido.Visible = false;
                        this.tcBusquedaAutores.ActiveTab = this.tpAutores;
                        this.tpBienesSustraidos.Visible = false;
                        break;
                }
                if (norefresca != null && norefresca == "1")
                {
                    VisualizaResultados();
                    return;
                }
                LlenarGridViewMisBusquedas();
                
                SeteoGeneral();
                if (Localidades == null)
                {
                    Localidades = new LocalidadList();
                    Departamentos = new DepartamentoList();
                    Partidos = new PartidoList();
                    Comisarias = new ComisariaList();
                }
                if (norefresca == "3")//cargo la busqueda con la que dibuje el mapa
                {
                    BusquedaRobosDelitosSexuales miBusqueda = (BusquedaRobosDelitosSexuales)Session["miBusqueda"];
                    LlenarControlesConMiBusqueda(miBusqueda);
                }

            }
        }
    
        protected void gvSenasPart_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int id = 0;
            GridView gvSenasPart = (GridView)sender;
            SeniasD = (SeniasParticularesList)Session["SeniasD"];
            gvSenasPart.EditIndex = e.NewEditIndex;
            id = Convert.ToInt32(gvSenasPart.DataKeys[e.NewEditIndex].Value);
            gvSenasPart.DataSource = SeniasD;
            gvSenasPart.DataBind();


        }

       
        protected void gvTatuajes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView gvTatuajes = (GridView)sender;
            TatuajesD = (TatuajesPersonaList)Session["TatuajesD"];
            gvTatuajes.EditIndex = e.NewEditIndex;
            int id = Convert.ToInt32(gvTatuajes.DataKeys[e.NewEditIndex].Value);
            gvTatuajes.DataSource = TatuajesD;
            gvTatuajes.DataBind();
        }

        protected void gvSenasPart_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            e.Cancel = true;
            GridView gvSenasPart = (GridView)sender;
            gvSenasPart.EditIndex = -1;
            gvSenasPart.DataSource = SeniasD;
            gvSenasPart.DataBind();
        }

        protected void gvTatuajes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            e.Cancel = true;
            GridView gvTatuajes = (GridView)sender;
            gvTatuajes.EditIndex = -1;
            gvTatuajes.DataSource = TatuajesD;
            gvTatuajes.DataBind();
        }

        
        protected void gvSenasPart_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SeniasParticulares senia;
            GridView gvSenasPart = (GridView)sender;
            SeniasD = (SeniasParticularesList)Session["SeniasD"];
            switch (gvSenasPart.ID)
            {
                case "gvSenasPartD":
                    senia = SeniasD[e.RowIndex];
                    senia.idSeniaParticular = Convert.ToInt32(((DropDownList)(gvSenasPart.Rows[e.RowIndex].Cells[3].FindControl("ddlSeniaPart"))).SelectedValue);
                    senia.idUbicacionSeniaParticular = Convert.ToInt32(((DropDownList)(gvSenasPart.Rows[e.RowIndex].Cells[4].FindControl("ddlUbicacionSenaPart"))).SelectedValue);
                    //senia.descripcion = Convert.ToString(((TextBox)(gvSenasPart.Rows[e.RowIndex].Cells[5].FindControl("descripcionSenaPart"))).Text);
                    gvSenasPart.EditIndex = -1;
                    gvSenasPart.DataSource = SeniasD;
                    gvSenasPart.DataBind();
                    break;
            }
        }

        protected void gvTatuajes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            GridView gvTatuajes = (GridView)sender;
            TatuajesD = (TatuajesPersonaList)Session["TatuajesD"];
            MPBA.SIAC.BusinessEntities.TatuajesPersona tatuaje = TatuajesD[e.RowIndex];
            tatuaje.idTatuaje = Convert.ToInt32(((DropDownList)(gvTatuajes.Rows[e.RowIndex].Cells[3].FindControl("ddlTatuajes"))).SelectedValue);
            tatuaje.idUbicacionTatuaje = Convert.ToInt32(((DropDownList)(gvTatuajes.Rows[e.RowIndex].Cells[4].FindControl("ddlUbicacionTatuaje"))).SelectedValue);
            //tatuaje.descripcion = Convert.ToString(((TextBox)(gvTatuajes.Rows[e.RowIndex].Cells[5].FindControl("descripcionTatuajePart"))).Text);
            gvTatuajes.EditIndex = -1;
            gvTatuajes.DataSource = TatuajesD;
            gvTatuajes.DataBind();
        }
        protected void gvSenasPart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
            GridView gvSenasPart = (GridView)sender;
            SeniasD = (SeniasParticularesList)Session["SeniasD"];
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

        protected void gvTatuajes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
            GridView gvTatuajes = (GridView)sender;
            TatuajesD = (TatuajesPersonaList)Session["TatuajesD"];
            gvTatuajes.EditIndex = -1;
            TatuajesD.RemoveAt(e.RowIndex);
            gvTatuajes.DataSource = TatuajesD;
            gvTatuajes.DataBind();
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
                    //sena.descripcion = Convert.ToString(((TextBox)(gvSenasPart.Controls[0].Controls[0].Controls[0].FindControl("descripcionSenaPart"))).Text);
                    sena.id = -1;
                    //sena.idTablaDestino = 1;
                    SeniasD = new SeniasParticularesList();
                    SeniasD.Add(sena);
                    Session["SeniasD"] = SeniasD;
                    gvSenasPart.DataSource = SeniasD;
                    gvSenasPart.DataBind();
                    break;

            }
        }

        protected void btnAutores_Click(object sender, EventArgs e)
        {
            Validar();
            if (!this.IsValid)
            {
                this.ValidationSummary1.DataBind();
                return;
            }
            this.txtDescripcionBusqueda.Text = "";
            BusquedaRobosDelitosSexuales miBusqueda;
            Session["miBusqueda"] = null;
            bool seleccion;
            bool seleccionFecha;
            bool seleccionDomicilio;
            int seleccionAutor;
            LlenarBusqueda(out miBusqueda, out seleccion, out seleccionFecha, out  seleccionAutor, out  seleccionDomicilio);
            int pruebaEsNro = 0;
            Int32.TryParse(this.ddlSexo.SelectedValue.ToString(), out pruebaEsNro);
            if (seleccionFecha == false)
            {
                ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Mensaje", @"<script language='javascript'>setTimeout(""alert('Debe seleccionar un rango de Fechas para filtrar la búsqueda')"",1000); </script>");
                return;
            }
            if (pruebaEsNro == 0)
            {
                ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Mensaje", @"<script language='javascript'>setTimeout(""alert('Debe definir el sexo como filtro principal de búsqueda de Autores')"",1000); </script>");
                return;
            }
            if (!seleccionDomicilio)
            {
                ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Mensaje", @"<script language='javascript'>setTimeout(""alert('El Domicilio seleccionado está incompleto. Como mínimo debe especificar Localidad y Calle')"",1000); </script>");
                return;
            }




              if (seleccionAutor == 0)
            {
                ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Mensaje", @"<script language='javascript'>setTimeout(""alert('Debe definir condiciones que filtren la búsqueda de Autores ademas del sexo')"",1000); </script>");
                return;
            }

            if (seleccionAutor == 2 && chkAp.Checked == false)
            {
                ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Mensaje", @"<script language='javascript'>setTimeout(""alert('Seleccionó criterios que tienen aplicación sólo en Autores Aprehendidos. Por favor, seleccione el check de Aprehendidos.')"",1000); </script>");
                return;
            }
            if (seleccionAutor == 2 && chkIg.Checked == true)
            {
                ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Mensaje", @"<script language='javascript'>setTimeout(""alert('Seleccionó criterios que tienen aplicación sólo en Autores Aprehendidos. Por favor, cambie la selección del check de Ignorados.')"",1000); </script>");
                return;
                
            }

           Session["miBusqueda"] = miBusqueda;
            /*DataTable dtResultados;

            //solo Delitos con ratros
            //dtResultados = GenerarTabla(criterio, true);
            //todos los delitos
            dtResultados = GenerarTabla(miBusqueda, false);*/

            this.tvCriteriosBusqueda.ExpandAll();
           if (chkAp.Checked == false && chkIg.Checked == false)
           {
               ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Mensaje", @"<script language='javascript'>setTimeout(""alert('Por favor, Indique si la búsqueda se aplica a Autores Ignorados,Aprehendidos u ambos')"",1000); </script>");
               return; 
           }

           if (chkAp.Checked == true && chkIg.Checked == true)
           {
               ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "buscarAutores('T');", true);
           }
           else if (chkIg.Checked == true)
           {
               ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "buscarAutores('I');", true);
              // ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "buscarAutoresIgnorados();", true);
           }
           else
           {

               ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "buscarAutores('A');", true);
           }
               

            
                //   this.tcBusquedaAutores.Visible = false;
                this.pnlComisariasH.Style.Add("display", "none");
                this.pnlLugar.Style.Add("display", "none");
                this.pnlAuxiliar.Style.Add("display", "none");
                this.pnlAuxiliar.Visible = false;
                this.hfAbrirComisaria_ModalPopupExtender.Enabled = false;
                this.btnLimpiar.Visible = true;
                this.hfAbrirLugar_ModalPopupExtender.Enabled = false;
                this.btnBuscar.Visible = false;
                this.btnVolver.Visible = true;
            
                

            
                this.pnlBusquedasGuardadas.Visible = false;
            
                this.btnMapaDelito.Visible = false;
                this.label_visualiza.Visible = false;
                this.btnMapaDelitoSimbologia.Visible = false;
                this.btnAutores.Visible = false;

                //this.tvCriteriosBusqueda.ExpandAll();
            
        }


        protected void btnAgregarPrimerTatuaje_Click(object sender, EventArgs e)
        {
            GridView gvTatuajes = null;
            gvTatuajes = this.gvTatuajesD;
            MPBA.SIAC.BusinessEntities.TatuajesPersona tatuaje = new TatuajesPersona();
            tatuaje.idTatuaje = Convert.ToInt32(((DropDownList)gvTatuajes.Controls[0].Controls[0].Controls[0].FindControl("ddlTatuajes")).SelectedValue);
            tatuaje.idUbicacionTatuaje = Convert.ToInt32(((DropDownList)gvTatuajes.Controls[0].Controls[0].Controls[0].FindControl("ddlUbicacionTatuaje")).SelectedValue);
            tatuaje.id = -1;
            TatuajesD = new TatuajesPersonaList();
            TatuajesD.Add(tatuaje);
            Session["TatuajesD"] = TatuajesD;
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
                    SeniasD = (SeniasParticularesList)Session["SeniasD"];
                    SeniasParticulares sena = new SeniasParticulares();
                    sena.idSeniaParticular = Convert.ToInt32(((DropDownList)gvSenasPart.FooterRow.FindControl("ddlSeniaPartInsert")).SelectedValue);
                    sena.idUbicacionSeniaParticular = Convert.ToInt32(((DropDownList)gvSenasPart.FooterRow.FindControl("ddlUbicacionSenaPartInsert")).SelectedValue);
                    //sena.descripcion = Convert.ToString(((TextBox)gvSenasPart.FooterRow.FindControl("descripcionInsert")).Text);
                    sena.id = -1;
                    sena.idTablaDestino = 1;
                    SeniasD.Add(sena);
                    gvSenasPart.DataSource = SeniasD;
                    gvSenasPart.DataBind();
                    break;

            }
        }
        protected void btnAgregarTatuaje_Click(object sender, EventArgs e)
        {
            GridView gvTatuajes = null;
            gvTatuajes = this.gvTatuajesD;
            TatuajesD = (TatuajesPersonaList)Session["TatuajesD"];
            MPBA.SIAC.BusinessEntities.TatuajesPersona tatuaje = new TatuajesPersona();
            tatuaje.idTatuaje = Convert.ToInt32(((DropDownList)gvTatuajes.FooterRow.FindControl("ddlTatuajeInsert")).SelectedValue);
            tatuaje.idUbicacionTatuaje = Convert.ToInt32(((DropDownList)gvTatuajes.FooterRow.FindControl("ddlUbicacionTatuajeInsert")).SelectedValue);
            //tatuaje.descripcion = Convert.ToString(((TextBox)gvTatuajes.FooterRow.FindControl("descripcionTatuajeInsert")).Text);
            tatuaje.id = -1;
            tatuaje.idTablaDestino = 1;
            TatuajesD.Add(tatuaje);
            gvTatuajes.DataSource = TatuajesD;
            gvTatuajes.DataBind();

        }
        
          
        

       


              private void LlenarGridViewMisBusquedas()
        {
            string idPuntoGestion = Session["miUfi"].ToString().Trim();
            int tipoDelito = Convert.ToInt32(Request.QueryString["tipo"].ToString().Substring(1, 1));
            BusquedaRobosDelitosSexualesList bl=null;
                  /*Cuando llena la grilla es con las busquedas de conocidos o ignorados*/
            if (TipoBusqueda=="1")//analisis
                 bl = BusquedaRobosDelitosSexualesManager.GetListByIdPuntoGestionTipoDelitoTipoAutor(idPuntoGestion, tipoDelito,(int)FuncionesGenerales.TipoAutores.Todos);
            else
                 bl = BusquedaRobosDelitosSexualesManager.GetListByIdPuntoGestionTipoDelitoTipoAutor(idPuntoGestion, tipoDelito,(int)TipoAutor);
            if (bl != null)
            {
                this.gvMisBusquedas.DataSource = bl;
            }
            else
                this.gvMisBusquedas.DataSource = "";
            this.gvMisBusquedas.DataBind();
        }

        private void SeteoGeneral()
        {

            this.pnlAuxiliar.Style.Add("display", "none");
            this.pnlLugar.Style.Add("display", "none");
            this.pnlComisariasH.Style.Add("display", "none");
            this.pnlPartido.Style.Add("display", "none");
            this.pnlDeptoJud.Style.Add("display", "none");
            this.dvBSAnimal.Visible = false;
            this.dvBSOtro.Visible = false;
            this.pnlBusquedasGuardadas.Visible = true;
            this.dvBSVehiculo.Visible = false;
            this.pnlAuxiliar.Visible = false;

            /******/
            btnAutores.Visible=true;
            btnMapaDelitoSimbologia.Visible=true;
            btnMapaDelito.Visible=true;
            btnBuscar.Visible = true;
            Panel pnlWaitingOverlayBusquedaLocalidad = (Panel)this.upWaitingBusquedaLocalidad.FindControl("pnlWaitingOverlayBusquedaLocalidad");
            Panel pnlWaitingBusquedaLocalidad = (Panel)this.upWaitingBusquedaLocalidad.FindControl("pnlWaitingBusquedaLocalidad");
            pnlWaitingBusquedaLocalidad.CssClass = "loader";
            pnlWaitingOverlayBusquedaLocalidad.CssClass = "overlay";
            LimpiarControlesTerritorio();
            LimpiarControlesAutor();
            LimpiarControlesMO();
            LimpiarControlesBS();
            HabilitarControlesTiempo(false);
            HabilitarControlesTerritorio(false);
            HabilitarControlesAutor(false);
            HabilitarControlesArribo(false);
            HabilitarControlesMO(false);
            HabilitarControlesBS(false);
        }

        private void LimpiarControlesMO()
        {
            this.ddlModusOperandis.SelectedValue = "0";
            this.ddlModoArriboHuida.SelectedValue = "0";
            this.txtPatente.Text = "";
            this.ddlMarcaMO.SelectedValue = "0";
            this.ddlModeloMO.SelectedValue = "0";
            this.ddlColorMO.SelectedValue = "0";
            this.ddlVidriosVehiculo.SelectedValue = "0";
            this.txtIngresaronPor.Text = "";
            this.ddlHuboVictimas.SelectedValue = "0";
        }

        private void HabilitarControlesTiempo(bool habilitar)
        {
            this.chkBuscarPorTiempo.Checked = habilitar;
            if (habilitar == false)
            {
                this.rbMomentoDia.Checked = habilitar;
                this.rbPorFecha.Checked = habilitar;
                this.rbPorHora.Checked = habilitar;
            }
            this.mevFechaDesde.Enabled = habilitar;
            this.mevFechaHasta.Enabled = habilitar;
            this.cvFechas.Enabled = habilitar;
            this.mevHoraDesde.Enabled = habilitar;
            this.mevHoraHasta.Enabled = habilitar;
            this.txtFechaDesde.Enabled = habilitar;
            this.txtFechaHasta.Enabled = habilitar;
            this.btnCalendarDesde.Enabled = habilitar;
            this.btnCalendarHasta.Enabled = habilitar;
            this.txtHoraDesde.Enabled = habilitar;
            this.txtHoraHasta.Enabled = habilitar;
            this.rbMomentoDia.Enabled = habilitar;
            this.rbPorFecha.Enabled = habilitar;
            this.rbPorHora.Enabled = habilitar;
            this.ddlMomentoDia.Enabled = habilitar;
        }

        private void HabilitarControlesTerritorio(bool habilitar)
        {
            
            this.chkPorIpp.Checked = habilitar;
            this.chkPorLugar.Checked = habilitar;
            this.chkPorTerritorio.Checked = habilitar;
           
            this.txtDepto.Enabled = habilitar;
          
            this.txtIpp.Enabled = habilitar;
            this.txtNomRef.Enabled = habilitar;
            this.txtNro.Enabled = habilitar;
            this.txtOtraCalle.Enabled = habilitar;
            this.txtOtraCalle1.Enabled = habilitar;
            this.txtOtraCalle2.Enabled = habilitar;
            this.txtParaje.Enabled = habilitar;
            this.txtPiso.Enabled = habilitar;
            this.ddlLugar.Enabled = habilitar;
            this.ddlRubro.Enabled = habilitar;
            this.rfvIPP.Enabled = habilitar;
            this.btnBuscarLocalidad.Enabled = habilitar;
            this.btnBuscarDeptoJud.Enabled = habilitar;
            this.btnTraerComisaria.Enabled = habilitar;
            this.btnBuscarPartido.Enabled = habilitar;

        }
        private void LimpiarControlesTerritorio()
        {
            this.txtDepto.Text = "";
            this.txtFechaDesde.Text = "";
            this.txtFechaHasta.Text = "";
            this.txtHoraDesde.Text = "";
            this.txtHoraHasta.Text = "";
            this.txtIpp.Text = "";
            this.txtNomRef.Text = "";
            this.txtNro.Text = "";
            this.txtOtraCalle.Text = "";
            this.txtOtraCalle1.Text = "";
            this.txtOtraCalle2.Text = "";
            this.txtParaje.Text = "";
            this.txtPiso.Text = "";
            if (Localidades != null)
                Localidades.Clear();
            if (Departamentos != null)
                Departamentos.Clear();
            if (Partidos != null)
                Partidos.Clear();
            if (Comisarias != null)
                Comisarias.Clear();
            this.gvPartido.DataSource = "";
            this.gvPartido.DataBind();
            this.gvLocalidades.DataSource = "";
            this.gvLocalidades.DataBind();
            this.gvDeptoJud.DataSource = "";
            this.gvDeptoJud.DataBind();
            this.ddlMomentoDia.SelectedValue = "0";
            this.ddlLugar.SelectedValue = "0";
            this.ddlRubro.SelectedValue = "0";

        }

        private void Validar()
        {
            //Controla Rango fechas
            string fechaDesde = this.txtFechaDesde.Text.Trim();
            string fechaHasta = this.txtFechaHasta.Text.Trim();
            if (this.rbPorFecha.Checked && fechaDesde != "" && fechaHasta != "")
            {
                if (this.mevFechaDesde.IsValid == true && this.mevFechaHasta.IsValid == true)
                {
                    if (Convert.ToDateTime(fechaDesde) > Convert.ToDateTime(fechaHasta))
                    {
                        this.cvFechas.IsValid = false;
                        //this.cvFechas.ErrorMessage = "Fecha desde no es menor a fecha hasta";
                    }
                }
            }
            //Controla Rango horas
            string horaDesde = this.txtHoraDesde.Text.Trim().Replace(":", "");
            string horaHasta = this.txtHoraHasta.Text.Trim().Replace(":", "");
            if (this.rbPorHora.Checked && horaDesde != "" && horaHasta != "")
            {
                if (this.mevHoraDesde.IsValid == true && this.mevHoraHasta.IsValid == true)
                {
                    if (Convert.ToInt32(horaDesde) > Convert.ToInt32(horaHasta))
                    {
                        this.cvHoras.IsValid = false;
                    }
                }
            }
        }



       /* protected void btnMapaDelito_Click(object sender, EventArgs e)
        { 
            // Abrir VisualizaMapa

    

            Response.Redirect("~/VisualizaMapa.aspx?simbolos=" + MapaconSimbologia);

           }
       
       */
        protected void VisualizaResultados()
        {
            this.pnlCriterioBusqueda.Visible = false;
           marcadores = (List<GoogleMarker>) Session["MarcadoresGoogle"] ;
           DataTable dtResultados = (DataTable) Session["Resultados"];
            this.tvCriteriosBusqueda.ExpandAll();
            this.txtDescripcionBusqueda.Text = "";
            this.btnMapaDelito.Visible = true;
             this.tcBusquedaAutores.Visible = false;
             this.pnlComisariasH.Style.Add("display", "none");
             this.pnlLugar.Style.Add("display", "none");
             this.pnlAuxiliar.Style.Add("display", "none");
             this.pnlAuxiliar.Visible = false;
             this.hfAbrirComisaria_ModalPopupExtender.Enabled = false;
                this.btnLimpiar.Visible = false;
                this.hfAbrirLugar_ModalPopupExtender.Enabled = false;
                this.pnlAuxiliar.Visible = true;
                this.gvResultadosGeneral.DataSource = dtResultados;
                this.gvResultadosGeneral.DataBind();
                this.btnBuscar.Visible = false;
                this.btnVolver.Visible = true;
                this.pnlResultados.Visible = true;
                this.cartelResultadoBusqueda.Visible = true;
                this.lblCantResultados.Text = "Resultados Encontrados: "+dtResultados.Rows.Count.ToString()+" - Solo se visualizan los primeros 1000 registros encontrados";
                this.pnlBusquedasGuardadas.Visible = false;
        }
        protected void btnMapaDelitoSimbologia_Click(object sender, EventArgs e)
        {
            MapaconSimbologia = "S";
            btnMapaDelito_Click(null, null);
        }
        
        protected void btnMapaDelito_Click(object sender, EventArgs e)
        {
                  

            Validar();
            if (!this.IsValid)
            {
                this.ValidationSummary1.DataBind();
                return;
            }
            this.txtDescripcionBusqueda.Text = "";
            BusquedaRobosDelitosSexuales miBusqueda;
            bool seleccion;
            bool seleccionFecha;
            bool seleccionDomicilio;
            int seleccionAutor;
            LlenarBusqueda(out miBusqueda, out seleccion, out seleccionFecha, out seleccionAutor, out seleccionDomicilio);
            if (!seleccionFecha)
            {
                ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Mensaje", @"<script language='javascript'>setTimeout(""alert('Debe definir rango de Fechas que filtren la búsqueda de Delitos')"",1000); </script>");
                return;
            }
            if (!seleccion)
            {
                ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Mensaje", @"<script language='javascript'>setTimeout(""alert('Debe definir condiciones que filtren la búsqueda de Delitos')"",1000); </script>");
                return;
            }
            if (!seleccionDomicilio)
            {
                ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Mensaje", @"<script language='javascript'>setTimeout(""alert('El Domicilio seleccionado está incompleto. Como mínimo debe especificar Localidad y Calle')"",1000); </script>");
                return;
            }
            Session["miBusqueda"] = miBusqueda;
            DataTable dtResultados;
            

            //solo Delitos con ratros
            //dtResultados = GenerarTabla(criterio, true);
            //todos los delitos
            dtResultados = GenerarTablaMapaDelDelito(miBusqueda);

            this.tvCriteriosBusqueda.ExpandAll();
            Session["MarcadoresGoogle"] = null;

            if (dtResultados.Rows.Count == 0)
            {
                ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "updatealert", @"<script language='javascript'>setTimeout(""alert('No se encontraron resultados.')"",1000); </script>");
                return;
            }
            else
            {

                marcadores = new List<GoogleMarker>(dtResultados.Rows.Count);

                foreach (DataRow row in dtResultados.Rows)
                {  // Para cada delito hay que recuperar la direccion y llenar los googlemarcas

                    GoogleMarker goo = new GoogleMarker();
                    goo.domicilio = row[2].ToString() + ' ' + row[3].ToString() + ' ' + row[4] + ' ' + row[5] + ',' + row[6] + ',' + row[7];
                    if (goo.domicilio == "0 0 0 0,0,0" || row[2].ToString().Trim() == "" || row[3].ToString().Trim() == "" )
                        continue;

                    goo.InfoWindow = "Nro de IPP: " + row["IPP"].ToString() + " Dirección:";
                    //  goo.imagen = "http://" + Request.Url.Host + ":" + Request.Url.Port + Page.ResolveUrl("/App_Images/clouds_amarilla.png");
                    // Con imagen?

                    switch (row[9].ToString())
                    {
                        case "1":
                        case "18":
                            // Arrebatador - Punguista
                            goo.imagen = "arrebatar.png";
                            break;

                        case "2":
                        case "3":
                            // Automotores Robo y Hurto
                            goo.imagen = "auto.png";
                            break;
                        case "4":
                            goo.imagen = "banco.png";
                            break;
                        case "5":
                        case "6":
                            // Robo * Hurto biciletas
                            goo.imagen = "bicileta.png";
                            break;
                        case "7":
                            // boqueteros
                            goo.imagen = "boqueterosAmarillo.png";
                            break;
                        case "8":
                            // Cables
                            goo.imagen = "cables.png";
                            break;
                        case "9":
                            // Cuatrerismo
                            goo.imagen = "cuatrerismo.png";
                            break;

                        case "10":
                            // extorsion
                            goo.imagen = "money.png";
                            break;
                        case "11":
                            // Hurto
                            goo.imagen = "hurto.png";
                            break;
                        case "12":
                            // Mechera
                            goo.imagen = "mechera.png";
                            break;
                        case "13":
                            // medidor de gas
                            goo.imagen = "medidores.png";
                            break;
                        case "14":
                            // medidor de luz
                            goo.imagen = "luces.png";
                            break;
                        case "15":
                        case "16":
                            // Robo * Hurto de Motos
                            goo.imagen = "moto.png";
                            break;
                        case "17":
                            // Piratas del Asfalto
                            goo.imagen = "piratasAsfalto.png";
                            break;
                        case "19":
                            //robo
                            goo.imagen = "robo.png";
                            break;
                        case "20":
                            // Robos de Ancianos
                            goo.imagen = "robosAncianos.png";
                            break;
                        case "21":
                            // Salidera Bancaria
                            goo.imagen = "entradera2.png";
                            break;
                        case "22":
                        case "23":
                            // secuestro y secuestro express
                            goo.imagen = "secuestro.png";
                            break;
                        case "24":
                            // robo en bandas con armas
                            goo.imagen = "armas.png";
                            break;
                        case "25":
                            // Robo de neumaticos
                            goo.imagen = "neumaticos.png";
                            break;
                        case "26":
                            // entradera
                            goo.imagen = "comercio.png";
                            break;
                        default:
                            goo.imagen = "googleMarker.png";
                            break;
                    }

                    marcadores.Add(goo);




                }



                    

                // Muestra el link que permite visualizar el mapa del delito
                // SI hay direcciones validas

                if (marcadores.Count() == 0)
                { // Alerta de que no hay direcciones cargadas
                    ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "updatealert", @"<script language='javascript'>setTimeout(""alert('No hay Direcciones validas en los datos resultantes,que sean visualizables en el Mapa del Delito.')"",1000); </script>");
                    return;
                    }

                Session["MarcadoresGoogle"] = marcadores;
                this.tcBusquedaAutores.Visible = false;
                this.pnlComisariasH.Style.Add("display", "none");
                this.pnlLugar.Style.Add("display", "none");
                this.pnlAuxiliar.Style.Add("display", "none");
                this.pnlAuxiliar.Visible = false;
                this.hfAbrirComisaria_ModalPopupExtender.Enabled = false;
                this.btnLimpiar.Visible = false;
                this.hfAbrirLugar_ModalPopupExtender.Enabled = false;
                this.pnlAuxiliar.Visible = true;
                this.btnBuscar.Visible = false;
                this.btnVolver.Visible = false;
                
                
                Session["CantidadResultados"] = dtResultados.Rows.Count.ToString();

                this.lblCantResultados.Text = "Resultados Encontrados: " + dtResultados.Rows.Count.ToString() + " - Solo se visualizan los primeros 1000 registros encontrados";
                this.pnlBusquedasGuardadas.Visible = false;
                Session["Resultados"] = dtResultados;
                //this.tvCriteriosBusqueda.ExpandAll();
                Response.Redirect("~/VisualizaMapa.aspx?simbolos=" + MapaconSimbologia);
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Validar();
            if (!this.IsValid)
            {
                this.ValidationSummary1.DataBind();
                return;
            }
            this.txtDescripcionBusqueda.Text = "";
            BusquedaRobosDelitosSexuales miBusqueda;
            bool seleccion;
            bool seleccionFecha;
            bool seleccionDomicilio;
            int seleccionAutor;
            LlenarBusqueda(out miBusqueda, out seleccion, out seleccionFecha, out seleccionAutor, out seleccionDomicilio);
            if (!seleccionFecha)
            {
                ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Mensaje", @"<script language='javascript'>setTimeout(""alert('Debe definir rango de fechas que filtren la búsqueda de Delitos!')"",1000); </script>");
                return;
            }
            if (!seleccion)
            {
                ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Mensaje", @"<script language='javascript'>setTimeout(""alert('Debe definir condiciones que filtren la búsqueda de Delitos!')"",1000); </script>");
                return;
            }
            if (!seleccionDomicilio)
            {
                ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Mensaje", @"<script language='javascript'>setTimeout(""alert('El Domicilio seleccionado está incompleto. Como mínimo debe especificar Localidad y Calle')"",1000); </script>");
                return;
            }
            DataTable dtResultados;

            //solo Delitos con ratros
            //dtResultados = GenerarTabla(criterio, true);
            //todos los delitos
            dtResultados = GenerarTabla(miBusqueda,false);
           
            this.tvCriteriosBusqueda.ExpandAll();
           

            if (dtResultados.Rows.Count == 0)
            {
                ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "updatealert", @"<script language='javascript'>setTimeout(""alert('No se encontraron resultados.')"",1000); </script>");
                return;
            }
            else
            {


                this.tcBusquedaAutores.Visible = false;
                this.pnlComisariasH.Style.Add("display", "none");
                this.pnlLugar.Style.Add("display", "none");
                this.pnlAuxiliar.Style.Add("display", "none");
                this.pnlAuxiliar.Visible = false;
                this.hfAbrirComisaria_ModalPopupExtender.Enabled = false;
                this.btnLimpiar.Visible = false;
                this.hfAbrirLugar_ModalPopupExtender.Enabled = false;
                this.pnlAuxiliar.Visible = true;
                this.gvResultadosGeneral.DataSource = dtResultados;
                this.gvResultadosGeneral.DataBind();
                this.btnBuscar.Visible = false;
                this.btnVolver.Visible = true;
                this.pnlResultados.Visible = true;
                this.cartelResultadoBusqueda.Visible = true;
                Session["CantidadResultados"] = dtResultados.Rows.Count.ToString();

                this.lblCantResultados.Text = "Resultados Encontrados: " + dtResultados.Rows.Count.ToString() + " - Solo se visualizan los primeros 1000 registros encontrados";
                this.pnlBusquedasGuardadas.Visible = false;
                Session["Resultados"] = dtResultados;
                this.btnMapaDelito.Visible = false;
                this.label_visualiza.Visible = false;
                this.btnMapaDelitoSimbologia.Visible = false;
                this.btnAutores.Visible = false;

                //this.tvCriteriosBusqueda.ExpandAll();
            }
        }


        private void LlenarBusqueda(out BusquedaRobosDelitosSexuales criterio, out bool seleccion, out bool seleccionFecha, out int seleccionAutor, out bool seleccionDomicilio)
        {
           // seleccionAutor: 1 selecciono algun item referentes a Autores en gral
           // seleccionAutor: 2 selecciono solo campos de autor aprehendido apellido, nombre, dni
           // seleccionAutor: 0 sin seleccion


            criterio = new BusquedaRobosDelitosSexuales();
            seleccion = false;
            seleccionFecha = false;
            seleccionDomicilio = true;
            seleccionAutor = 0;
            //BusquedaRobosDelitosSexuales criterio = new BusquedaRobosDelitosSexuales();
            int pruebaEsNro = 0;
            criterio.id = -1;
            criterio.IdPuntoGestion = Session["miUfi"].ToString();
            criterio.DescripcionBusqueda = this.txtDescripcionBusqueda.Text.Trim();
            criterio.FechaCreacion = DateTime.Now;
            criterio.FechaUltimaModificacion = DateTime.Now;


            if ((this.chkIg.Checked == false && this.chkAp.Checked == false) || (this.chkIg.Checked == true && this.chkAp.Checked == true))
            {
                TipoAutor = FuncionesGenerales.TipoAutores.Todos;
            }
            else
            {
                if (this.chkIg.Checked)
                { TipoAutor = FuncionesGenerales.TipoAutores.Desconocidos; }

                if (this.chkAp.Checked)
                { TipoAutor = FuncionesGenerales.TipoAutores.Conocidos; }

            }

            criterio.IdTipoAutor = (int)TipoAutor;


            /*if (TipoBusqueda=="1")//analisis
                criterio.IdTipoAutor = (int)FuncionesGenerales.TipoAutores.Todos;
            else
                criterio.IdTipoAutor = (int)TipoAutor;*/



            criterio.UsuarioUltimaModificacion = Session["miUsuario"].ToString();
            ///////////////////////
            //TIEMPO Y TERRITORIO//
            ///////////////////////
            //IPP
            string tipo = Request.QueryString["tipo"].Substring(1, 1);
            if (tipo != null)
                criterio.IdClaseDelito = Convert.ToInt16(tipo);
            if (this.chkPorIpp.Checked)
            {
                TreeNode tn = this.tvCriteriosBusqueda.FindNode("Por IPP");
                if (tn != null)
                {
                    tn.ChildNodes.Clear();
                }
                string ipp = this.txtIpp.Text.Trim();
                criterio.IdCausa = ipp;
                if (tn != null & ipp != "")
                { tn.ChildNodes.Add(new TreeNode("IPP: " + ipp));
                 seleccion = true;
                }
            }

            //FECHA
            if (this.rbPorFecha.Checked)
            {

                tvCriteriosBusqueda.ExpandAll();
                TreeNode tn = this.tvCriteriosBusqueda.FindNode("Por Tiempo/Por Fecha");
                if (tn != null)
                {
                    tn.ChildNodes.Clear();
                }

                DateTime dt;
                DateTime dtHasta;
                if (DateTime.TryParse(this.txtFechaDesde.Text.Trim(), out dt) && DateTime.TryParse(this.txtFechaHasta.Text.Trim(), out dtHasta))
                {
                    seleccion = true;
                    seleccionFecha = true;
                    criterio.FechaDesde = dt;
                    if (tn != null)
                        tn.ChildNodes.Add(new TreeNode("Desde: " + this.txtFechaDesde.Text.Trim()));
                    criterio.FechaHasta = dtHasta;
                    if (tn != null)
                        tn.ChildNodes.Add(new TreeNode("Hasta: " + this.txtFechaHasta.Text.Trim()));
                }
                //if (DateTime.TryParse(this.txtFechaHasta.Text.Trim(), out dt))
                //{
                //    seleccion = true;
                    
                //    criterio.FechaHasta = dt;
                //    if (tn != null)
                //        tn.ChildNodes.Add(new TreeNode("Hasta: " + this.txtFechaHasta.Text.Trim()));
                //}
                if (seleccionFecha == false)
                    return;
            }
            if (this.rbMomentoDia.Checked)
            {
                TreeNode tn;
                tn = this.tvCriteriosBusqueda.FindNode("Por Tiempo/Por Mom. del Día");
                if (tn != null)
                    tn.ChildNodes.Clear();
                criterio.IdClaseMomentoDelDia = Convert.ToInt16(this.ddlMomentoDia.SelectedValue);
                if (tn != null && criterio.IdClaseMomentoDelDia >0)
                {
                    seleccion = true;
                    tn.ChildNodes.Add(new TreeNode("Momento del Día: " + this.ddlMomentoDia.SelectedItem.ToString()));
                }
            }

            //HORA
            if (this.rbPorHora.Checked)
            {
                tvCriteriosBusqueda.ExpandAll();
                TreeNode tn = this.tvCriteriosBusqueda.FindNode("Por Tiempo/Por Hora");
                if (tn != null)
                    tn.ChildNodes.Clear();
                string horaDesde = this.txtHoraDesde.Text.Trim();
                criterio.HoraDesde = horaDesde;
                if (tn != null && horaDesde != "")
                {
                    seleccion = true;
                    tn.ChildNodes.Add(new TreeNode("Desde: " + horaDesde));
                }
                string horaHasta = this.txtHoraHasta.Text.Trim();
                criterio.HoraHasta = horaHasta;
                if (tn != null && horaHasta != "")
                { tn.ChildNodes.Add(new TreeNode("Hasta: " + horaHasta));
                  seleccion = true;
                   }
            }

            //TERRITORIO
            if (this.chkPorTerritorio.Checked)
            {
                
                TreeNode tn;
                tn = this.tvCriteriosBusqueda.FindNode("Por Territorio");
                if (tn != null)
                {
                    tn.ChildNodes.Clear();
                    seleccion = true;
                }
                string otraCalle = this.txtOtraCalle.Text.Trim();
                criterio.IdOtraCalle = otraCalle;
                if (tn != null && otraCalle != "")
                {
                    tn.ChildNodes.Add(new TreeNode("Calle: " + otraCalle));
                    seleccion = true;
                }
                string nroH = this.txtNro.Text.Trim();
                criterio.NroH = nroH;
                if (tn != null && nroH != "")
                {
                    tn.ChildNodes.Add(new TreeNode("Nro: " + nroH));
                    seleccion = true;
                }
                string pisoH = this.txtPiso.Text.Trim();
                criterio.PisoH = pisoH;
                if (tn != null && pisoH != "")
                {
                    tn.ChildNodes.Add(new TreeNode("Piso: " + pisoH));
                    seleccion = true;
                }
                string deptoH = this.txtDepto.Text.Trim();
                criterio.DeptoH = deptoH;
                if (tn != null && deptoH != "")
                {
                    tn.ChildNodes.Add(new TreeNode("Depto: " + deptoH));
                    seleccion = true;
                }
                string parajeBarrioH = this.txtParaje.Text.Trim();
                criterio.ParajeBarrioH = parajeBarrioH;
                if (tn != null && parajeBarrioH != "")
                {
                    tn.ChildNodes.Add(new TreeNode("Paraje: " + parajeBarrioH));
                    seleccion = true;
                }
                string otraEntreCalle2 = this.txtOtraCalle2.Text.Trim();
                criterio.IdOtraEntreCalle2 = otraEntreCalle2;
                if (tn != null && otraEntreCalle2 != "")
                {
                    tn.ChildNodes.Add(new TreeNode("Entre: " + otraEntreCalle2));
                    seleccion = true;
                }
                string otraEntreCalle = this.txtOtraCalle1.Text.Trim();
                criterio.IdOtraEntreCalle = otraEntreCalle;
                if (tn != null && otraEntreCalle != "")
                {
                    tn.ChildNodes.Add(new TreeNode("Y Entre: " + otraEntreCalle));
                    seleccion = true;
                }

                //Caso en el que se ingresen varios departamentos a buscar
                if (this.gvDeptoJud.Rows.Count > 0)
                {
                    seleccion = true;
                    string deptosNros = "";
                    string deptosNombres = "";
                    for (int i = 0; i < Departamentos.Count; i++)
                    {
                        if (i > 0)
                        {
                            deptosNros += ", ";
                            if (i<Departamentos.Count)
                                deptosNombres += ",<br />";
                        }
                        deptosNros += Departamentos[i].Id.ToString();
                        deptosNombres += Departamentos[i].departamento.ToString().Trim();
                    }
                    criterio.IdDepartamento = deptosNros;
                    if (tn != null)
                    {
                        tn.ChildNodes.Add(new TreeNode("Dto. Jud.: <br />" + deptosNombres));
                    }
                    
                }

                //Caso en el que se ingresen varias localidades a buscar
                if (this.gvLocalidades.Rows.Count > 0)
                {
                    seleccion = true;
                    string locNros = "";
                    string locNombres = "";
                    for (int i = 0; i < Localidades.Count; i++)
                    {
                        if (i > 0)
                        {
                            locNros += ", ";
                            if (i < Localidades.Count - 1)
                            locNombres += ",<br />";
                        }
                        locNros += Localidades[i].id.ToString();
                        locNombres += Localidades[i].localidad.ToString().Trim();
                    }
                    criterio.IdLocalidad = locNros;
                    if (tn != null)
                    {
                        tn.ChildNodes.Add(new TreeNode("Localidad: <br />" + locNombres));
                    }
                }

                //Caso en el que se ingresen varios partidos a buscar
                if (this.gvPartido.Rows.Count > 0)
                {
                    seleccion = true;
                    string partNros = "";
                    string partNombres = "";
                    for (int i = 0; i < Partidos.Count; i++)
                    {
                        if (i > 0)
                        {
                            partNros += ", ";
                            if (i < Partidos.Count)
                            partNombres += ",<br />";
                        }
                        partNros += Partidos[i].id.ToString();
                        partNombres += Partidos[i].partido.ToString();
                    }
                    //criterio.IdPartido = part.Remove(part.Length - 4, 4);
                    criterio.IdPartido = partNros;
                    if (tn != null)
                    {
                        tn.ChildNodes.Add(new TreeNode("Partido: <br />" + partNombres));
                    }


                }

                //Caso en el que se ingresen varias comisarias a buscar
                if (this.gvComisarias.Rows.Count > 0)
                {
                    seleccion = true;
                    string comNros = "";
                    string comNombres = "";
                    for (int i = 0; i < Comisarias.Count; i++)
                    {
                        if (i > 0)
                        {
                            comNros += ", ";
                            if (i < Comisarias.Count)
                            comNombres += ",<br />";
                        }
                        comNros += Comisarias[i].id.ToString();
                        comNombres += Comisarias[i].comisaria.ToString();
                    }
                    criterio.IdComisariaH = comNros;
                    if (tn != null)
                    {
                        tn.ChildNodes.Add(new TreeNode("Comisaria: <br />" + comNombres));
                    }


                }
                if ((nroH != "") || (deptoH != "") || (pisoH != "") )
                {
                    if ((otraCalle == "") || (this.gvLocalidades.Rows.Count == 0))
                        seleccionDomicilio = false;

                }
                if ((otraCalle != "") || (otraEntreCalle != "") || (otraEntreCalle2 != ""))
                {
                    if  (this.gvLocalidades.Rows.Count == 0)
                        seleccionDomicilio = false;

                }


            }
            //LUGAR Y RUBRO
            if (this.chkPorLugar.Checked)
            {
                TreeNode tn;
                tn = this.tvCriteriosBusqueda.FindNode("Por Lugar y Rubro");
                if (tn != null)
                    tn.ChildNodes.Clear();
                if (Int32.TryParse(this.ddlLugar.SelectedValue.ToString(), out pruebaEsNro))
                {
                    if (pruebaEsNro > 0)
                    {
                        seleccion = true;
                        criterio.IdClaseLugar = Convert.ToInt32(this.ddlLugar.SelectedValue);
                        if (tn != null)
                            tn.ChildNodes.Add(new TreeNode("Lugar: " + this.ddlLugar.SelectedItem.ToString()));
                    }
                }
                if (Int32.TryParse(this.ddlRubro.SelectedValue.ToString(), out pruebaEsNro))
                {
                    if (pruebaEsNro > 0)
                    {
                        seleccion = true;
                        criterio.IdClaseRubro = Convert.ToInt32(this.ddlRubro.SelectedValue);
                        if (tn != null)
                            tn.ChildNodes.Add(new TreeNode("Rubro: " + this.ddlRubro.SelectedItem.ToString()));
                    }
                }
                string nomRef = this.txtNomRef.Text.Trim();
                criterio.NomReferenciaLugarRubro = nomRef;
                if (tn != null && nomRef != "")
                {
                    seleccion = true;
                    tn.ChildNodes.Add(new TreeNode("Nom. de Referencia: " + nomRef));
                }
            }
            //////////////////
            //MODUS OPERANDI//
            //////////////////

            if (this.chkPorModusOperandis.Checked)
            {
                TreeNode tn;
                tn = this.tvCriteriosBusqueda.FindNode("Por Modus Op.");
                if (tn != null)
                    tn.ChildNodes.Clear();
                if (Int32.TryParse(this.ddlModusOperandis.SelectedValue.ToString(), out pruebaEsNro))
                {
                    if (pruebaEsNro > 0)
                    {
                        seleccion = true;
                        criterio.IdClaseModusOperandi = Convert.ToInt16(this.ddlModusOperandis.SelectedValue);
                        if (tn != null)
                            tn.ChildNodes.Add(new TreeNode("Modus Operandi: " + this.ddlModusOperandis.SelectedItem.ToString()));
                    }
                }
                if (Int32.TryParse(this.ddlModoArriboHuida.SelectedValue.ToString(), out pruebaEsNro))
                {
                    if (pruebaEsNro > 0)
                    {
                        seleccion = true;
                        criterio.IdClaseModoArriboHuida = Convert.ToInt16(this.ddlModoArriboHuida.SelectedValue);
                        if (tn != null)
                            tn.ChildNodes.Add(new TreeNode("Modo Arribo/Huída: " + this.ddlModoArriboHuida.SelectedItem.ToString()));
                    }
                }
                string ingresaronPor = this.txtIngresaronPor.Text.Trim();
                criterio.IngresaronPor = ingresaronPor;
                if (tn != null && ingresaronPor != "")
                {
                    seleccion = true;
                    tn.ChildNodes.Add(new TreeNode("Ingresaron por: " + ingresaronPor));
                }
                if (Int32.TryParse(this.ddlHuboVictimas.SelectedValue.ToString(), out pruebaEsNro))
                {
                    if (pruebaEsNro > 0)
                    {
                        seleccion = true;
                        criterio.VictimasEnElLugar = Convert.ToInt16(this.ddlHuboVictimas.SelectedValue);
                        if (tn != null)
                            tn.ChildNodes.Add(new TreeNode("Hubo Víctimas: " + this.ddlHuboVictimas.SelectedItem.ToString()));
                    }
                }
            }
            if (this.chkPorDetalleModoArriboHuida.Checked)
            {
                TreeNode tn;
                tn = this.tvCriteriosBusqueda.FindNode("Por Vehiculo A-H");
                if (tn != null)
                    tn.ChildNodes.Clear();
                Vehiculos criterioVehiculo = new Vehiculos();
                string dominioMO = this.txtPatente.Text.Trim();
                criterio.DominioMO = dominioMO;
                if (tn != null && dominioMO != "" && criterio.DominioMO.Trim() != "Indeterminada")
                {
                    seleccion = true;
                    tn.ChildNodes.Add(new TreeNode("Dominio: " + dominioMO));
                }
                criterio.IdMarcaVehiculoMO = this.ddlMarcaMO.SelectedValue;
                if (tn != null && this.ddlMarcaMO.SelectedItem.ToString() != "" && this.ddlMarcaMO.SelectedItem.ToString().Trim() != "Indeterminada")
                {    tn.ChildNodes.Add(new TreeNode("Marca: " + this.ddlMarcaMO.SelectedItem.ToString()));
                     seleccion=true;}

                criterio.IdModeloVehiculoMO = this.ddlModeloMO.SelectedValue;
                if (tn != null && this.ddlModeloMO.SelectedItem.ToString() != "" && this.ddlModeloMO.SelectedItem.ToString().Trim() !="Indeterminado")
                {
                    seleccion = true;
                    tn.ChildNodes.Add(new TreeNode("Modelo: " + this.ddlModeloMO.SelectedItem.ToString())); }
                     criterio.IdColorVehiculoMO = this.ddlColorMO.SelectedValue;
                     if (tn != null && this.ddlColorMO.SelectedItem.ToString() != "" && this.   ddlModeloMO.SelectedItem.ToString().Trim() !="Indeterminado")
                     { tn.ChildNodes.Add(new TreeNode("Color: " + this.ddlColorMO.SelectedItem.ToString()));
                       seleccion = true;   
                     }
                if (Int32.TryParse(this.ddlClaseVidrio.SelectedValue.ToString(), out pruebaEsNro))
                    criterio.IdClaseVidrioVehiculoMO = Convert.ToInt16(this.ddlClaseVidrio.SelectedValue);

                if (tn != null && criterio.IdClaseVidrioVehiculoMO > 0 && this.ddlClaseVidrio.SelectedValue.ToString().Trim()!="Indeterminado")
                { tn.ChildNodes.Add(new TreeNode("Vidrios: " + this.ddlClaseVidrio.SelectedItem.ToString()));
                  seleccion = true;
                }
            }
            ///////////////
            //AUTOR      //
            ///////////////
            if (this.chkPorAutor.Checked)
            {
                TreeNode tn;
                tn = this.tvCriteriosBusqueda.FindNode("Por Autor");
                if (tn != null)
                    tn.ChildNodes.Clear();
                if (TipoAutor == FuncionesGenerales.TipoAutores.Conocidos)
                {
                    string nombreAutor = this.txtNombreAutor.Text.Trim();
                    criterio.NombreAutor = nombreAutor;
                    if (tn != null && nombreAutor != "")
                    { tn.ChildNodes.Add(new TreeNode("Nombre Autor: " + nombreAutor));
                    seleccion = true;
                    seleccionAutor = 2;
                    }
                    string apodoAutor = this.txtApodoAutor.Text.Trim();
                    criterio.ApodoAutor = apodoAutor;
                    if (tn != null && apodoAutor != "")
                    {
                        tn.ChildNodes.Add(new TreeNode("Apodo Autor: " + apodoAutor));
                        seleccion = true;
                        seleccionAutor = 2;
                    }
                    string apellidoAutor = this.txtApellidoAutor.Text.Trim();
                    criterio.ApellidoAutor = apellidoAutor;
                    if (tn != null && apellidoAutor != "")
                    {
                        seleccion = true;
                        seleccionAutor = 2;
                        tn.ChildNodes.Add(new TreeNode("Apellido Autor: " + apellidoAutor));
                    }
                    if (Int32.TryParse(this.txtDniAutor.Text.Trim(), out pruebaEsNro))
                    {
                        criterio.DocNroAutor = pruebaEsNro;
                        if (tn != null && pruebaEsNro > 0)
                        { tn.ChildNodes.Add(new TreeNode("Doc. Nro. Autor: " + pruebaEsNro.ToString()));
                        seleccion = true;
                        seleccionAutor = 2;
                        }
                    }

                }
                if (Int32.TryParse(this.ddlCantidadAutores.SelectedValue.ToString(), out pruebaEsNro))
                {
                    if (pruebaEsNro > 0)
                    {
                        criterio.IdClaseCantidadAutores = Convert.ToInt16(this.ddlCantidadAutores.SelectedValue);
                        if (tn != null && criterio.IdClaseCantidadAutores > 0)
                        { tn.ChildNodes.Add(new TreeNode("Cant. Autores: " + this.ddlCantidadAutores.SelectedItem.ToString()));
                          seleccion = true;
                          
                        }
                    }
                }
                if (Int32.TryParse(this.txtNroAutor.Text.Trim(), out pruebaEsNro))
                {
                    criterio.Nro = this.txtNroAutor.Text.Trim();
                    if (tn != null && pruebaEsNro > 0)
                    { tn.ChildNodes.Add(new TreeNode("Nro. Autor: " + this.txtNroAutor.Text.Trim()));
                    seleccion = true;
                    }
                }
                string cubiertoCon = this.txtCon.Text.Trim();
                criterio.CubiertoCon = cubiertoCon;
                if (tn != null && cubiertoCon != "")
                { tn.ChildNodes.Add(new TreeNode("Cubierto con: " + cubiertoCon));
                seleccion = true;
                seleccionAutor = 1;
                }
                if (Int32.TryParse(this.ddlEdadAproximada.SelectedValue.ToString(), out pruebaEsNro))
                {
                    if (pruebaEsNro > 0)
                    {
                        

                        criterio.IdClaseEdadAproximada = Convert.ToInt16(this.ddlEdadAproximada.SelectedValue);
                        if (tn != null)
                        {
                            seleccionAutor = 1;
                            seleccion = true;
                            tn.ChildNodes.Add(new TreeNode("Edad Aprox.: " + this.ddlEdadAproximada.SelectedItem.ToString()));
                        }
                    }
                }
                if (Int32.TryParse(this.ddlSexo.SelectedValue.ToString(), out pruebaEsNro))
                {
                    if (pruebaEsNro > 0)
                    {
                        seleccion = true;
                       // solo sexo no cuenta como selecxcion  seleccionAutor = true;
                        criterio.IdClaseSexo = Convert.ToInt16(this.ddlSexo.SelectedValue);
                        if (tn != null)
                            tn.ChildNodes.Add(new TreeNode("Sexo: " + this.ddlSexo.SelectedItem.ToString()));
                    }
                }
                if (Int32.TryParse(this.ddlClaseRostro.SelectedValue.ToString(), out pruebaEsNro))
                {
                    if (pruebaEsNro > 0)
                    {
                        seleccion = true;
                        seleccionAutor = 1;
                        criterio.IdClaseRostro = Convert.ToInt16(this.ddlClaseRostro.SelectedValue);
                        if (tn != null)
                            tn.ChildNodes.Add(new TreeNode("Rostro: " + this.ddlClaseRostro.SelectedItem.ToString()));
                    }
                }

                if (Int32.TryParse(this.ddlColorCabello.SelectedValue.ToString(), out pruebaEsNro))
                {
                    if (pruebaEsNro > 0)
                    {
                        seleccion = true;
                        seleccionAutor = 1;
                        criterio.idClaseColorCabelloL = Convert.ToInt16(this.ddlColorCabello.SelectedValue).ToString();
                        if (tn != null)
                            tn.ChildNodes.Add(new TreeNode("Color Cabello: " + this.ddlColorCabello.SelectedItem.ToString()));
                    }
                }
                if (Int32.TryParse(this.ddlColorOjos.SelectedValue.ToString(), out pruebaEsNro))
                {
                    if (pruebaEsNro > 0)
                    {
                        seleccion = true;
                        seleccionAutor = 1;
                        criterio.idClaseColorOjosL = Convert.ToInt16(this.ddlColorOjos.SelectedValue).ToString();
                        if (tn != null)
                        {
                            
                            tn.ChildNodes.Add(new TreeNode("Color Ojos: " + this.ddlColorOjos.SelectedItem.ToString()));
                        }
                    }
                }
                if (Int32.TryParse(this.ddlColorPiel.SelectedValue.ToString(), out pruebaEsNro))
                {
                    if (pruebaEsNro > 0)
                    {
                        seleccion = true;
                        seleccionAutor =1;
                        criterio.idClaseColorPielL = Convert.ToInt16(this.ddlColorPiel.SelectedValue).ToString();
                        if (tn != null)
                            tn.ChildNodes.Add(new TreeNode("Color Piel: " + this.ddlColorPiel.SelectedItem.ToString()));
                    }
                }
                if (Int32.TryParse(this.ddlestatura.SelectedValue.ToString(), out pruebaEsNro))
                {
                    if (pruebaEsNro > 0)
                    {
                        seleccion = true;
                        criterio.idClaseEstaturaL = Convert.ToInt16(this.ddlestatura.SelectedValue).ToString();
                        if (tn != null)
                            tn.ChildNodes.Add(new TreeNode("Estatura: " + this.ddlestatura.SelectedItem.ToString()));
                    }
                }
                if (Int32.TryParse(this.ddlFormaBoca.SelectedValue.ToString(), out pruebaEsNro))
                {
                    if (pruebaEsNro > 0)
                    {
                        seleccion = true;
                        seleccionAutor = 1;
                        criterio.idFormaBocaL = Convert.ToInt16(this.ddlFormaBoca.SelectedValue).ToString();
                        if (tn != null)
                            tn.ChildNodes.Add(new TreeNode("Forma Boca: " + this.ddlFormaBoca.SelectedItem.ToString()));
                    }
                }
                if (Int32.TryParse(this.ddlFormaCara.SelectedValue.ToString(), out pruebaEsNro))
                {
                    if (pruebaEsNro > 0)
                    {
                        seleccion = true;
                        seleccionAutor = 1;
                        criterio.idClaseFormaCaraL = Convert.ToInt16(this.ddlFormaCara.SelectedValue).ToString();
                        if (tn != null)
                            tn.ChildNodes.Add(new TreeNode("Forma Cara: " + this.ddlFormaCara.SelectedItem.ToString()));
                    }
                }
                if (Int32.TryParse(this.ddlFormaLabioInferior.SelectedValue.ToString(), out pruebaEsNro))
                {
                    if (pruebaEsNro > 0)
                    {
                        seleccion = true;
                        seleccionAutor = 1;
                        criterio.idFormaLabioInferiorL = Convert.ToInt16(this.ddlFormaLabioInferior.SelectedValue).ToString();
                        if (tn != null)
                            tn.ChildNodes.Add(new TreeNode("Forma Labio Inferior: " + this.ddlFormaLabioInferior.SelectedItem.ToString()));
                    }
                }
                if (Int32.TryParse(this.ddlFormaLabioSuperior.SelectedValue.ToString(), out pruebaEsNro))
                {
                    if (pruebaEsNro > 0)
                    {
                        seleccion = true;
                        seleccionAutor =1;
                        criterio.idFormaLabioSuperiorL = Convert.ToInt16(this.ddlFormaLabioSuperior.SelectedValue).ToString();
                        if (tn != null)
                            tn.ChildNodes.Add(new TreeNode("Forma Labio Superior: " + this.ddlFormaLabioSuperior.SelectedItem.ToString()));
                    }
                }
                if (Int32.TryParse(this.ddlFormaMenton.SelectedValue.ToString(), out pruebaEsNro))
                {
                    if (pruebaEsNro > 0)
                    {
                        seleccion = true;
                        seleccionAutor = 1;
                        criterio.idFormaMentonL = Convert.ToInt16(this.ddlFormaMenton.SelectedValue).ToString();
                        if (tn != null)
                            tn.ChildNodes.Add(new TreeNode("Forma Mentón: " + this.ddlFormaMenton.SelectedItem.ToString()));
                    }
                }
                if (Int32.TryParse(this.ddlFormaNariz.SelectedValue.ToString(), out pruebaEsNro))
                {
                    if (pruebaEsNro > 0)
                    {
                        seleccion = true;
                        seleccionAutor = 1;
                        criterio.idFormaNarizL = Convert.ToInt16(this.ddlFormaNariz.SelectedValue).ToString();
                        if (tn != null)
                            tn.ChildNodes.Add(new TreeNode("Forma Nariz: " + this.ddlFormaNariz.SelectedItem.ToString()));
                    }
                }
                if (Int32.TryParse(this.ddlFormaOreja.SelectedValue.ToString(), out pruebaEsNro))
                {
                    if (pruebaEsNro > 0)
                    {
                        seleccion = true;
                        seleccionAutor = 1;
                        criterio.idFormaOrejaL = Convert.ToInt16(this.ddlFormaOreja.SelectedValue).ToString();
                        if (tn != null)
                            tn.ChildNodes.Add(new TreeNode("Forma Oreja: " + this.ddlFormaOreja.SelectedItem.ToString()));
                    }
                }
                if (Int32.TryParse(this.ddlRobustez.SelectedValue.ToString(), out pruebaEsNro))
                {
                    if (pruebaEsNro > 0)
                    {
                        seleccion = true;
                        seleccionAutor = 1;
                        criterio.idClaseRobustezL = Convert.ToInt16(this.ddlRobustez.SelectedValue).ToString();
                        if (tn != null)
                            tn.ChildNodes.Add(new TreeNode("Robustez: " + this.ddlRobustez.SelectedItem.ToString()));
                    }
                }
                if (Int32.TryParse(this.ddlTipoCabello.SelectedValue.ToString(), out pruebaEsNro))
                {
                    if (pruebaEsNro > 0)
                    {
                        seleccion = true;
                        seleccionAutor = 1;
                        criterio.idClaseTipoCabelloL = Convert.ToInt16(this.ddlTipoCabello.SelectedValue).ToString();
                        if (tn != null)
                            tn.ChildNodes.Add(new TreeNode("Tipo Cabello: " + this.ddlTipoCabello.SelectedItem.ToString()));
                    }
                }
                if (Int32.TryParse(this.ddlTipoCalvicie.SelectedValue.ToString(), out pruebaEsNro))
                {
                    if (pruebaEsNro > 0)
                    {
                        seleccion = true;
                        seleccionAutor =1;
                        criterio.idClaseCalvicieL = Convert.ToInt16(this.ddlTipoCalvicie.SelectedValue).ToString();
                        if (tn != null)
                            tn.ChildNodes.Add(new TreeNode("Tipo Calvicie: " + this.ddlTipoCalvicie.SelectedItem.ToString()));
                    }
                }
                if (Int32.TryParse(this.ddlTipoCeja.SelectedValue.ToString(), out pruebaEsNro))
                {
                    if (pruebaEsNro > 0)
                    {
                        seleccion = true;
                        seleccionAutor = 1;
                        criterio.idTipoCejaL = Convert.ToInt16(this.ddlTipoCeja.SelectedValue).ToString();
                        if (tn != null)
                            tn.ChildNodes.Add(new TreeNode("Tipo Ceja: " + this.ddlTipoCeja.SelectedItem.ToString()));
                    }
                }
                if (Int32.TryParse(this.ddlCejaDimension.SelectedValue.ToString(), out pruebaEsNro))
                {
                    if (pruebaEsNro > 0)
                    {
                        seleccion = true;
                        seleccionAutor = 1;
                        criterio.idDimensionCejaL = Convert.ToInt16(this.ddlCejaDimension.SelectedValue).ToString();
                        if (tn != null)
                            tn.ChildNodes.Add(new TreeNode("Dimensión Ceja: " + this.ddlCejaDimension.SelectedItem.ToString()));
                    }
                }
                 if (this.gvSenasPartD.Rows.Count > 0)
                 {
                     seleccion = true;
                     seleccionAutor = 1;
                    string idSenia = "";
                    string desSenia = "";
                    for (int i = 0; i < this.gvSenasPartD.Rows.Count; i++)
                    {
                        if (i > 0)
                        {
                            idSenia += ", ";
                            if (i < this.gvSenasPartD.Rows.Count)
                            desSenia += ",<br />";
                        }
                        idSenia += ((DropDownList)(this.gvSenasPartD.Rows[i].Cells[3].FindControl("ddlSeniaPartItem"))).SelectedValue + "-" + ((DropDownList)(this.gvSenasPartD.Rows[i].Cells[4].FindControl("ddlUbicacionSenaPartItem"))).SelectedValue;
                        desSenia += ((DropDownList)(this.gvSenasPartD.Rows[i].Cells[3].FindControl("ddlSeniaPartItem"))).SelectedItem + "-" + ((DropDownList)(this.gvSenasPartD.Rows[i].Cells[4].FindControl("ddlUbicacionSenaPartItem"))).SelectedItem;
                    }
                    criterio.IdClaseSeniaParticularL = idSenia;
                    if (tn != null)
                    {
                        tn.ChildNodes.Add(new TreeNode("Señas Part: <br />" + desSenia));
                    }
                                     
                }
                 if (this.gvTatuajesD.Rows.Count > 0)
                 {
                     seleccion = true;
                     seleccionAutor = 1;
                     string idTatuaje = "";
                     string desTatuaje = "";
                     for (int i = 0; i < this.gvTatuajesD.Rows.Count; i++)
                     {
                         if (i > 0)
                         {
                             idTatuaje += ", ";
                             if (i < this.gvTatuajesD.Rows.Count)
                                 desTatuaje += ",<br />";
                         }
                         idTatuaje += ((DropDownList)(this.gvTatuajesD.Rows[i].Cells[3].FindControl("ddlTatuajesItem"))).SelectedValue + "-" + ((DropDownList)(this.gvTatuajesD.Rows[i].Cells[4].FindControl("ddlUbicacionTatuajeItem"))).SelectedValue;
                         desTatuaje += ((DropDownList)(this.gvTatuajesD.Rows[i].Cells[3].FindControl("ddlTatuajesItem"))).SelectedItem + "-" + ((DropDownList)(this.gvTatuajesD.Rows[i].Cells[4].FindControl("ddlUbicacionTatuajeItem"))).SelectedItem;
                     }
                     criterio.IdClaseTatuajeL = idTatuaje;
                     if (tn != null)
                     {
                         tn.ChildNodes.Add(new TreeNode("Tatuajes: <br />" + desTatuaje));
                     }

                 }
                
               

   
            }
            //////////////////
            //BIEN SUSTRAIDO//
            //////////////////
            if (this.chkPorBienSustraido.Checked)
            {
                TreeNode tn;
                tn = this.tvCriteriosBusqueda.FindNode("Por Bien Sust.");
                if (tn != null)
                    tn.ChildNodes.Clear();
                double monto = 0;
                if (Double.TryParse(this.txtMontoTotalEstimado.Text.Trim(), out monto))
                {
                    criterio.MontoTotalEstimadoBienSustraido = Convert.ToDecimal(this.txtMontoTotalEstimado.Text.Trim());
                    if (tn != null && criterio.MontoTotalEstimadoBienSustraido > 0)
                    { tn.ChildNodes.Add(new TreeNode("Monto Total: " + this.txtMontoTotalEstimado.Text.Trim()));
                    seleccion = true;
                    }
                }
                if (Int32.TryParse(this.ddlClaseBienSustraido.SelectedValue, out pruebaEsNro))
                {
                    if (pruebaEsNro > 0)
                    {
                        seleccion = true;
                        criterio.IdClaseBienSustraido = Convert.ToInt32(this.ddlClaseBienSustraido.SelectedValue);
                        if (tn != null)
                            tn.ChildNodes.Add(new TreeNode("Bien: " + this.ddlClaseBienSustraido.SelectedItem.ToString()));
                    }
                }

                switch (this.ddlClaseBienSustraido.SelectedItem.Text.Trim().ToUpper())
                {
                    case "ANIMALES":
                        //Animal Sustraido
                        if (Int32.TryParse(this.ddlClaseGanado.SelectedValue, out pruebaEsNro))
                        {
                            if (pruebaEsNro > 0)
                            {
                                criterio.IdClaseGanado = Convert.ToInt16(this.ddlClaseGanado.SelectedValue);
                                if (tn != null)
                                    tn.ChildNodes.Add(new TreeNode("Ganado: " + this.ddlClaseGanado.SelectedItem.ToString()));
                            }
                        }
                        if (Int32.TryParse(this.txtCantidadAnimalSustraido.Text.Trim(), out pruebaEsNro))
                        {
                            if (pruebaEsNro > 0)
                            {
                                criterio.CantidadGanado = Convert.ToInt32(this.txtCantidadAnimalSustraido.Text.Trim());
                                if (tn != null)
                                    tn.ChildNodes.Add(new TreeNode("Cant.Gan.: " + this.txtCantidadAnimalSustraido.Text.Trim()));
                            }
                        }
                        string marcaGanado = this.txtMarcaAnimalSustraido.Text.Trim();
                        criterio.MarcaGanado = marcaGanado;
                        if (tn != null && marcaGanado != "")
                            tn.ChildNodes.Add(new TreeNode("Marca Gan.: " + marcaGanado));
                        break;

                    case "VEHÍCULOS":
                        //Vehiculo
                        string dominioBS = this.txtPatenteBS.Text.Trim();
                        criterio.DominioBS = dominioBS;
                        if (tn != null && dominioBS != "")
                            tn.ChildNodes.Add(new TreeNode("Patente: " + dominioBS));
                        if (this.ddlMarcaBS.SelectedValue != "0")
                        {
                            criterio.IdMarcaVehiculoBS = this.ddlMarcaBS.SelectedValue;
                            if (tn != null)
                                tn.ChildNodes.Add(new TreeNode("Marca V.: " + this.ddlMarcaBS.SelectedItem.Text.Trim()));
                        }
                        if (this.ddlModeloBS.SelectedValue != "0")
                        {
                            criterio.IdModeloVehiculoBS = this.ddlModeloBS.SelectedValue;
                            if (tn != null)
                                tn.ChildNodes.Add(new TreeNode("Modelo V.: " + this.ddlModeloBS.SelectedItem.Text.Trim()));
                        }
                        if (this.ddlColorBS.SelectedValue != "0")
                        {
                            criterio.IdColorVehiculoBS = this.ddlColorBS.SelectedValue;
                            if (tn != null)
                                tn.ChildNodes.Add(new TreeNode("Color V.: " + this.ddlColorBS.SelectedItem.Text.Trim()));
                        }
                        if (Int32.TryParse(this.ddlTieneGNC.SelectedValue, out pruebaEsNro))
                        {
                            if (pruebaEsNro > 0)
                            {
                                criterio.GNCBS = Convert.ToInt32(this.ddlTieneGNC.SelectedValue);
                                if (tn != null)
                                    tn.ChildNodes.Add(new TreeNode("Tiene GNC: " + this.ddlTieneGNC.SelectedItem.Text.Trim()));
                            }
                        }
                        string numeroMotorBS = this.txtNroMotor.Text.Trim();
                        criterio.NumeroMotorBS = numeroMotorBS;
                        if (tn != null && numeroMotorBS != "")
                            tn.ChildNodes.Add(new TreeNode("Motor: " + numeroMotorBS));
                        string anioBS = this.txtAnioAutoSustraido.Text.Trim();
                        criterio.AnioBS = anioBS;
                        if (tn != null && anioBS != "")
                            tn.ChildNodes.Add(new TreeNode("Año V.: " + anioBS));
                        if (Int32.TryParse(this.ddlVidriosVehiculo.SelectedValue, out pruebaEsNro))
                        {
                            if (pruebaEsNro > 0)
                            {
                                criterio.IdClaseVidrioVehiculoBS = Convert.ToInt32(this.ddlVidriosVehiculo.SelectedValue);
                                if (tn != null)
                                    tn.ChildNodes.Add(new TreeNode("Vidrios V.: " + this.ddlVidriosVehiculo.SelectedItem.Text.Trim()));
                            }
                        }
                        string numeroChasisBS = this.txtNroChasis.Text.Trim();
                        criterio.NumeroChasisBS = numeroChasisBS;
                        if (tn != null && numeroChasisBS != "")
                            tn.ChildNodes.Add(new TreeNode("Chasis: " + numeroChasisBS));
                        break;
                    default:
                        //Otro Bien Sustraido
                        string marcaBienSustraidoOtro = this.txtMarcaOtroBienSustraido.Text.Trim();
                        criterio.MarcaBienSustraidoOtro = marcaBienSustraidoOtro;
                        if (tn != null && marcaBienSustraidoOtro != "")
                            tn.ChildNodes.Add(new TreeNode("Marca Otro: " + marcaBienSustraidoOtro));
                        string nroSerieBienSustraidoOtro = this.txtNroSerieOtroBien.Text.Trim();
                        criterio.NroSerieBienSustraidoOtro = nroSerieBienSustraidoOtro;
                        if (tn != null && nroSerieBienSustraidoOtro != "")
                            tn.ChildNodes.Add(new TreeNode("Serie Otro: " + nroSerieBienSustraidoOtro));
                        if (Int32.TryParse(this.txtCantidadOtroBien.Text.Trim(), out pruebaEsNro))
                        {
                            criterio.CantidadBienSustraidoOtro = Convert.ToInt32(this.txtCantidadOtroBien.Text.Trim());
                            if (tn != null)
                                tn.ChildNodes.Add(new TreeNode("Cant.Otro: " + this.txtCantidadOtroBien.Text.Trim()));
                        }
                        break;
                }
            }
           
            if (!seleccion)
            {
                ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Mensaje", @"<script language='javascript'>setTimeout(""alert('Debe definir condiciones que filtren la búsqueda de Delitos')"",1000); </script>");
                return;
            }
        }





        protected void chkPorIpp_CheckedChanged(object sender, EventArgs e)
        {
            bool fueElegido = this.chkPorIpp.Checked;
            this.txtIpp.Enabled = fueElegido;
            this.rfvIPP.Enabled = fueElegido;
            if (!fueElegido)
                this.txtIpp.Text = "";
            if (fueElegido == true)
                this.txtIpp.Focus();


            //TREEVIEW
            ManipularTreeView("Por IPP", fueElegido);
        }




        protected void chkPorTerritorio_CheckedChanged(object sender, EventArgs e)
        {
            bool fueElegido = this.chkPorTerritorio.Checked;
            if (!fueElegido)
            {
                LimpiarControlesTerritorio();
            }
            this.txtOtraCalle.Enabled = fueElegido;
            this.txtPiso.Enabled = fueElegido;
            this.txtNro.Enabled = fueElegido;
            this.txtOtraCalle1.Enabled = fueElegido;
            this.txtDepto.Enabled = fueElegido;
            this.txtParaje.Enabled = fueElegido;
            this.txtOtraCalle2.Enabled = fueElegido;
            this.btnBuscarLocalidad.Enabled = fueElegido;
            this.btnBuscarDeptoJud.Enabled = fueElegido;
            this.btnTraerComisaria.Enabled = fueElegido;
            this.btnBuscarPartido.Enabled = fueElegido;

            //TREEVIEW
            ManipularTreeView("Por Territorio", fueElegido);

        }
        protected void chkPorLugar_CheckedChanged(object sender, EventArgs e)
        {
            bool fueElegido = this.chkPorLugar.Checked;
            if (!fueElegido)
            {
                this.txtNomRef.Text = "";
                this.ddlLugar.SelectedValue = "0";
                this.ddlRubro.SelectedValue = "0";
            }

            this.ddlLugar.Enabled = fueElegido;
            this.ddlRubro.Enabled = fueElegido;
            this.txtNomRef.Enabled = fueElegido;
            //TREEVIEW
            TreeNode tn = this.tvCriteriosBusqueda.FindNode("Por Lugar y Rubro");
            if (tn != null && !fueElegido)
            {
                this.tvCriteriosBusqueda.Nodes.Remove(tn);
                this.upTree.Update();
                return;
            }
            tn = new TreeNode("Por Lugar y Rubro");
            this.tvCriteriosBusqueda.Nodes.Add(tn);
            this.upTree.Update();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            SeteoGeneral();
            this.tvCriteriosBusqueda.Nodes.Clear();
        }

        protected void rbMomentoDia_CheckedChanged(object sender, EventArgs e)
        {
            GestionRbPorMomentoDelDia();
            //TREEVIEW
            TreeNode node = this.tvCriteriosBusqueda.FindNode("Por Tiempo");
            if (node == null)
            {
                node = new TreeNode();
                node.Text = "Por Tiempo";
                node.Expanded = true;
                this.tvCriteriosBusqueda.Nodes.Add(node);
            }
            int indiceNode = tvCriteriosBusqueda.Nodes.IndexOf(node);
            this.tvCriteriosBusqueda.Nodes[indiceNode].ChildNodes.Clear();
            TreeNode subNode = new TreeNode();
            if (this.rbPorFecha.Checked)
                subNode.Text = "Por Fecha";
            else if (this.rbPorHora.Checked)
                subNode.Text = "Por Hora";
            else if (this.rbMomentoDia.Checked)
                subNode.Text = "Por Mom. del Día";
            tvCriteriosBusqueda.Nodes[indiceNode].ChildNodes.Add(subNode);
            this.upTree.Update();
        }

        private void GestionRbPorMomentoDelDia()
        {
            bool fueElegido = this.rbMomentoDia.Checked;
            //FECHAS
            this.txtFechaDesde.Enabled = !fueElegido;
            this.txtFechaHasta.Enabled = !fueElegido;
            this.mevFechaDesde.Enabled = !fueElegido;
            this.mevFechaHasta.Enabled = !fueElegido;
            this.cvFechas.Enabled = !fueElegido;
            this.txtFechaDesde.Text = "";
            this.txtFechaHasta.Text = "";
            //HORAS
            this.txtHoraDesde.Enabled = !fueElegido;
            this.txtHoraHasta.Enabled = !fueElegido;
            this.mevHoraDesde.Enabled = !fueElegido;
            this.mevHoraHasta.Enabled = !fueElegido;
            this.cvHoras.Enabled = !fueElegido;
            this.txtHoraDesde.Text = "";
            this.txtHoraHasta.Text = "";
            //MOMENTO
            this.ddlMomentoDia.Enabled = fueElegido;
            this.ddlMomentoDia.SelectedValue = "0";

            
        }

        protected void rbPorHora_CheckedChanged(object sender, EventArgs e)
        {
            GestionRbPorHora();
            //TREEVIEW
            TreeNode node = this.tvCriteriosBusqueda.FindNode("Por Tiempo");
            if (node == null)
            {
                node = new TreeNode();
                node.Text = "Por Tiempo";
                node.Expanded = true;
                this.tvCriteriosBusqueda.Nodes.Add(node);
            }
            int indiceNode = tvCriteriosBusqueda.Nodes.IndexOf(node);
            this.tvCriteriosBusqueda.Nodes[indiceNode].ChildNodes.Clear();
            TreeNode subNode = new TreeNode();
            if (this.rbPorFecha.Checked)
                subNode.Text = "Por Fecha";
            else if (this.rbPorHora.Checked)
                subNode.Text = "Por Hora";
            else if (this.rbMomentoDia.Checked)
                subNode.Text = "Por Mom. del Día";
            tvCriteriosBusqueda.Nodes[indiceNode].ChildNodes.Add(subNode);
            this.upTree.Update();
        }

        private void GestionRbPorHora()
        {
            bool fueElegido = this.rbPorHora.Checked;
            //FECHAS
            this.txtFechaDesde.Enabled = !fueElegido;
            this.txtFechaHasta.Enabled = !fueElegido;
            this.mevFechaDesde.Enabled = !fueElegido;
            this.mevFechaHasta.Enabled = !fueElegido;
            this.btnCalendarDesde.Enabled = !fueElegido;
            this.btnCalendarHasta.Enabled = !fueElegido;

            this.cvFechas.Enabled = !fueElegido;
            this.txtFechaDesde.Text = "";
            this.txtFechaHasta.Text = "";
            //HORAS
            this.txtHoraDesde.Enabled = fueElegido;
            this.txtHoraHasta.Enabled = fueElegido;
            this.mevHoraDesde.Enabled = fueElegido;
            this.mevHoraHasta.Enabled = fueElegido;
            this.cvHoras.Enabled = fueElegido;
            this.txtHoraDesde.Text = "";
            this.txtHoraHasta.Text = "";
            //MOMENTO
            this.ddlMomentoDia.Enabled = !fueElegido;
            this.ddlMomentoDia.SelectedValue = "0";

           
        }

        protected void rbPorFecha_CheckedChanged(object sender, EventArgs e)
        {
            GestionRbPorFecha();
            //TREEVIEW
            TreeNode node = this.tvCriteriosBusqueda.FindNode("Por Tiempo");
            if (node == null)
            {
                node = new TreeNode();
                node.Text = "Por Tiempo";
                node.Expanded = true;
                this.tvCriteriosBusqueda.Nodes.Add(node);
            }
            int indiceNode = tvCriteriosBusqueda.Nodes.IndexOf(node);
            this.tvCriteriosBusqueda.Nodes[indiceNode].ChildNodes.Clear();
            TreeNode subNode = new TreeNode();
            if (this.rbPorFecha.Checked)
                subNode.Text = "Por Fecha";
            else if (this.rbPorHora.Checked)
                subNode.Text = "Por Hora";
            else if (this.rbMomentoDia.Checked)
                subNode.Text = "Por Mom. del Día";
            tvCriteriosBusqueda.Nodes[indiceNode].ChildNodes.Add(subNode);
            this.upTree.Update();

        }

        private void GestionRbPorFecha()
        {
            bool fueElegido = this.rbPorFecha.Checked;
            //FECHAS
            this.txtFechaDesde.Enabled = fueElegido;
            this.txtFechaHasta.Enabled = fueElegido;
            this.mevFechaDesde.Enabled = fueElegido;
            this.mevFechaHasta.Enabled = fueElegido;
            this.btnCalendarDesde.Enabled = fueElegido;
            this.btnCalendarHasta.Enabled = fueElegido;
            this.cvFechas.Enabled = fueElegido;
            this.txtFechaDesde.Text = "";
            this.txtFechaHasta.Text = "";
            //HORAS
            this.txtHoraDesde.Enabled = !fueElegido;
            this.txtHoraHasta.Enabled = !fueElegido;
            this.mevHoraDesde.Enabled = !fueElegido;
            this.mevHoraHasta.Enabled = !fueElegido;
            this.cvHoras.Enabled = !fueElegido;
            this.txtHoraDesde.Text = "";
            this.txtHoraHasta.Text = "";
            //MOMENTO
            this.ddlMomentoDia.Enabled = !fueElegido;
            this.ddlMomentoDia.SelectedValue = "0";

          
        }

        protected void chkBuscarPorTiempo_CheckedChanged(object sender, EventArgs e)
        {
            bool fueElegido = this.chkBuscarPorTiempo.Checked;
            if (!fueElegido)
            {
                this.txtFechaDesde.Text = "";
                this.txtFechaHasta.Text = "";
                this.txtHoraDesde.Text = "";
                this.txtHoraHasta.Text = "";
                this.ddlMomentoDia.SelectedValue = "0";
            }
            //FECHAS
            this.rbPorFecha.Enabled = fueElegido;
            this.rbPorFecha.Checked = false;
            this.txtFechaDesde.Enabled = false;
            this.txtFechaHasta.Enabled = false;
            this.mevFechaDesde.Enabled = false;
            this.mevFechaHasta.Enabled = false;
            this.btnCalendarDesde.Enabled = false;
            this.btnCalendarHasta.Enabled = false;

            this.cvFechas.Enabled = false;
            //HORAS
            this.rbPorHora.Checked = false;
            this.rbPorHora.Enabled = fueElegido;
            this.txtHoraDesde.Enabled = false;
            this.txtHoraHasta.Enabled = false;
            this.mevHoraDesde.Enabled = false;
            this.mevHoraHasta.Enabled = false;
            this.cvHoras.Enabled = false;
            //MOMENTO
            this.rbMomentoDia.Checked = false;
            this.rbMomentoDia.Enabled = fueElegido;
            this.ddlMomentoDia.Enabled = false;

            //TREEVIEW
            TreeNode tn;
            tn = this.tvCriteriosBusqueda.FindNode("Por Tiempo");
            if (tn != null && !fueElegido)
            {
                this.tvCriteriosBusqueda.Nodes.Remove(tn);
                this.upTree.Update();
            }

        }

        protected void gvResultadosGeneral_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(this.gvResultadosGeneral.SelectedValue.ToString());
            Delitos delito = DelitosManager.GetItem(id, true);
            Caratula myCaratula = new Caratula();
            MPBA.SIAC.Web.WebServiceIPP.WebServiceMesaVirtualNN wsIPP = new MPBA.SIAC.Web.WebServiceIPP.WebServiceMesaVirtualNN();
            try
            {

                string depto = System.Configuration.ConfigurationManager.AppSettings["dptos_SIMP6"].ToString();
                string ippSimp;

                if (delito.idCausa.Substring(0, 2).Contains(depto))
                {
                    ippSimp = wsIPP.ConsultaCaratula(delito.idCausa, "00");
                }
                else
                {
                    ippSimp = wsIPP.ConsultaCaratula(delito.idCausa, "NULL");

                }
                wsIPP.Dispose();
                XmlTextReader reader = new XmlTextReader(new System.IO.StringReader(ippSimp));
                while (reader.Read())
                {
                    if (reader.NodeType != XmlNodeType.Element)
                        continue;
                    switch (reader.Name)
                    {
                        case "Causa":
                            while (reader.MoveToNextAttribute())
                            {
                                switch (reader.Name)
                                {
                                    case "NumeroIpp":
                                        string aa = reader.Value;
                                        break;
                                    case "NroEnJMenores":
                                        myCaratula.nroEnJMenores = reader.Value;
                                        break;
                                    case "JuzgadoMenores":
                                        myCaratula.juzgadoMenores = reader.Value;
                                        break;
                                    case "TitularJuzgadoMenores":
                                        myCaratula.titularJuzgadoMenores = reader.Value;
                                        break;
                                    case "ID":
                                        myCaratula.id = Convert.ToInt64(reader.Value);
                                        break;
                                    case "UFI":
                                        myCaratula.UFI = reader.Value;
                                        break;
                                    case "ResponsableUFI":
                                        myCaratula.responsableUFI = reader.Value;
                                        break;
                                    case "TitularUFI":
                                        myCaratula.titularUFI = reader.Value;
                                        break;
                                    case "UFD":
                                        myCaratula.UFD = reader.Value;
                                        break;
                                    case "TitularUFD":
                                        myCaratula.titularUFD = reader.Value;
                                        break;
                                    case "JuzgadoGarantia":
                                        myCaratula.juzgadoGarantia = reader.Value;
                                        break;
                                    case "TitularJG":
                                        myCaratula.titularJG = reader.Value;
                                        break;
                                    case "SedePolicial":
                                        myCaratula.sedePolicial = reader.Value;
                                        break;
                                    case "Departamento":
                                        myCaratula.departamento = reader.Value;
                                        break;
                                    case "FiscaliaJuicio":
                                        myCaratula.fiscaliaJuicio = reader.Value;
                                        break;
                                    case "DefensoriaJuicio":
                                        myCaratula.defensoriaJuicio = reader.Value;
                                        break;
                                    case "FechaInicioIPP":
                                        myCaratula.fechaInicioIPP = reader.Value;
                                        break;
                                }
                            }
                            break;
                        case "personas":
                            while (reader.MoveToNextAttribute())
                            {
                                string nombre = reader.Name;
                                string aa = reader.Value;
                            }
                            break;
                        case "Denunciante":
                            if (reader.HasAttributes)
                            {
                                while (reader.MoveToNextAttribute())
                                {
                                    string nombre = reader.Name;
                                    string aa = reader.Value;

                                }
                            }
                            break;
                        case "Victima":
                            if (reader.HasAttributes)
                            {
                                while (reader.MoveToNextAttribute())
                                {
                                    string nombre = reader.Name;
                                    string aa = reader.Value;
                                }
                            }
                            break;
                        case "Imputado":
                            while (reader.MoveToNextAttribute())
                            {
                                string nombre = reader.Name;
                                string aa = reader.Value;
                            }
                            break;
                        case "Delitos":
                            reader.ReadToDescendant("Delito");
                            if (reader.HasAttributes)
                            {
                                while (reader.MoveToNextAttribute())
                                {
                                    {
                                        string nombre = reader.Name;
                                        string aa = reader.Value;
                                    }
                                }
                            }
                            break;
                        case "Delito":
                            while (reader.MoveToNextAttribute())
                            {
                                string nombre = reader.Name;
                                string aa = reader.Value;
                            }
                            break;

                    }

                }
            }
            catch { System.Web.Services.Protocols.SoapException ex; }
            this.txtUFI.Text = myCaratula.UFI;
            this.txtTitular.Text = myCaratula.titularUFI;
            this.txtResponsable.Text = myCaratula.responsableUFI;
            this.txtDepartamento.Text = myCaratula.departamento;
            this.txtDomCalle.Text = delito.idOtraCalle;
            this.txtDomNro.Text = delito.NroH;
            this.txtDomPiso.Text = delito.PisoH;
            this.txtDomDepto.Text = delito.DeptoH;
            this.txtDomLocalidad.Text = LocalidadManager.GetItem(delito.idLocalidad).localidad;
            this.txtDomPartido.Text = PartidoManager.GetItem(delito.idPartido).partido;
            this.gvPrueba.DataSource = delito.rastross;
            //this.gvPrueba.DataBind();
            //this.gvPrueba.Visible = true;
            //this.gvPrueba.Style.Remove("display");
            this.gvVehiculos.DataSource = delito.vehiculoss;
            this.gvBienesSustraidos.DataSource = delito.bienesSustraidoss;
            this.gvAutores.DataSource = delito.autoress;
            this.pnlAuxiliar.DataBind();
            //this.pnlLugar.Visible = false;
            //this.pnlComisariasH.Visible = false;
            //this.pnlAuxiliar.Style.Remove("display");
            //this.pnlAuxiliar.Visible = true;
            this.hfExtender_ModalPopupExtender.Show();
        }

        protected void gvResultadosGeneral_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Visible = false;//escondo iddelito


            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (TableCell c in e.Row.Cells)
                {
                    TableCell celda = c;
                    if (((DataControlFieldCell)c).ContainingField.ToString().Trim().ToUpper() == "IDDELITO")
                    {
                        c.Visible = false;
                        return;
                    }
                    if (((DataControlFieldCell)c).ContainingField.ToString().Trim().ToUpper() == "IPP")
                        return;
                    int i = 0;
                    if (int.TryParse(c.Text, out i) && Convert.ToInt32(c.Text) > 0)
                    {

                        c.CssClass = "CeldaBold";
                        c.DataBind();
                    }
                }
            }
            //foreach (TableCell celda in e.Row.Cells)
            //{
            //    celda.Width = 30;
            //    celda.DataBind();
            //}
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {

            this.pnlAuxiliar.Style.Add("display", "none");
            this.hfExtender_ModalPopupExtender.Hide();
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session["miDelito"] = null;
            Session["Resultados"] = null;
            Session["miBusqueda"] = null;
            Session["SeniasD"]= null;
            Session["TatuajesD"]=null;
            Session["CantidadResultados"] = null;
            Session["moduloActual"] = null;//no resalta el menu
            Response.Redirect("~/Home.aspx");
        }

        private DataTable GenerarTabla(BusquedaRobosDelitosSexuales criterio, bool blSoloDelitosConRastros)
        {
            DelitosList dl =null;
            switch ((int)TipoAutor)
            {
                case 3:
                    dl = DelitosManager.GetList(criterio, false, true, DelitosManager.TipoAutores.Todos);
                    break;
               case 2:
                    dl = DelitosManager.GetList(criterio, false, true, DelitosManager.TipoAutores.Conocidos);
                    break;
                case 1:
                    dl = DelitosManager.GetList(criterio, false, true, DelitosManager.TipoAutores.Desconocidos);
                    break;
            }


            System.Data.DataTable dt = new System.Data.DataTable("delitos");
            System.Data.DataColumn dc;

            NNClaseRastroList crl = NNClaseRastroManager.GetList();
           

            //creo la columna con el iddelito
            dc = new DataColumn("idDelito");
            dt.Columns.Add(dc);
            
            
            //creo la columna con el nro de IPP
            dc = new DataColumn("IPP");
            dt.Columns.Add(dc);
            //creo la columna Hay victimas que pueden reconocer autores
            dc = new DataColumn("Hay vict. que pueden rec.autores");
            dt.Columns.Add(dc);
            
           
            dc = new DataColumn("Autor");
            dt.Columns.Add(dc);

           
            //creo las columnas = una por cada tipo de rastro
            for (int h = 0; h <= crl.Count - 1; h++)
            {
                string desc = crl[h].descripcion.Trim();
                int idRastro = crl[h].id;
                dc = new System.Data.DataColumn(desc);
                dt.Columns.Add(dc);

            }

            
            //recorro DELITOS
            for (int i = 0; i <= dl.Count - 1; i++)
            {
                if (blSoloDelitosConRastros)
                {
                    if (dl[i].rastross.Count == 0) //solo se muestran delitos que tienen pruebas
                        continue;
                }
                System.Data.DataRow row = dt.NewRow();
              

                

                ////////////////////////////////////////////////////

                //recorro la cant de cada rastro del respectivo delito

                RastrosList rl = dl[i].rastross;
                for (int j = 0; j <= rl.Count - 1; j++)
                {
                    NNClaseRastro cr = crl.Find(delegate(NNClaseRastro clasRas) { return clasRas.id == rl[j].idClaseRastro; });
                    //recorro todas las columnas para cada fila
                    for (int k = 0; k <= dt.Columns.Count - 1; k++)
                    {
                        if (k == 0) //lleno columna con iddelito
                        {
                            row[k] = dl[i].id;
                            continue;
                        }
                        if (k == 1) //lleno columna con idcausa
                        {
                            row[k] = dl[i].idCausa.Trim();
                            continue;
                        }
                        if (k == 2) //lleno columna Hay victimas que pueden reconocer autores
                        {
                            row[k] = NNClaseBooleanManager.GetItem(dl[i].idVicTestRecRueda).Descripcion.Trim();
                            continue;
                        }
                        if (k == 3) //lleno columna Autores Ignorados Aprehendidos
                        {
                             var arrValues =  Enum.GetValues(typeof(DelitosManager.TipoAutores));

                            row[3] =  arrValues.GetValue(dl[i].idTipoAutor - 1).ToString();
                             continue; 
                        }
                        string colName = dt.Columns[k].ColumnName.Trim();
                        if (cr.descripcion.Trim() == colName)
                        {
                            row[colName] = rl[j].CantidadPruebas;
                        }
                        else if (row[colName].ToString() == "")
                        {
                            row[k] = "0";
                        }
                    }
                }
                if (rl.Count == 0)//solo debe pasar por acá si blSoloDelitosConRastro = False,
                //es decir va a mostrar todos los delitos
                //si no ya salio al principio cuando evaluo blSoloDelitosConRastro = True
                //y el count de rastros == 0
                {
                    for (int k = 0; k <= dt.Columns.Count - 1; k++)
                    {
                        switch (k)
                        {
                            case 0:
                                row[k] = dl[i].id;
                                break;
                            case 1:
                                row[k] = dl[i].idCausa.Trim();
                                break;
                            case 2:
                                  row[k] = NNClaseBooleanManager.GetItem(dl[i].idVicTestRecRueda).Descripcion.Trim();
                                break;
                            case 3:
                               //  row[k] = (dl[i].idTipoAutor.ToString() == DelitosManager.TipoAutores.Conocidos.ToString()) ? "Conocido" : "Ignorado";
                                
                                  var arrValues =  Enum.GetValues(typeof(DelitosManager.TipoAutores));
                                  row[3] =  arrValues.GetValue(dl[i].idTipoAutor- 1).ToString();
                                  break;
                                
                            default:
                                row[k] = 0;
                                break;
                        }

                    }
                }
            
               dt.Rows.Add(row);
            }
            return dt;
        }


        private void GenerarTablaAutores(BusquedaRobosDelitosSexuales criterio, bool blSoloDelitosConRastros)
        {
            DelitosList dl = null;
            switch ((int) TipoAutor)
            {
                case 3:
                    dl = DelitosManager.GetList(criterio, false, true, DelitosManager.TipoAutores.Todos);
                    break;
                case 2:
                    dl = DelitosManager.GetList(criterio, false, true, DelitosManager.TipoAutores.Conocidos);
                    break;
                case 1:
                    dl = DelitosManager.GetList(criterio, false, true, DelitosManager.TipoAutores.Desconocidos);
                    break;
            }
            Session["ResultadosAutores"] = dl;
          
        
            return;
        }

        private DataTable GenerarTablaMapaDelDelito(BusquedaRobosDelitosSexuales criterio)
        {
            DelitosList dl = null;
            switch ((int)TipoAutor)
            {
                case 3:
                    dl = DelitosManager.GetList(criterio, false, true, DelitosManager.TipoAutores.Todos);
                    break;
                case 2:
                    dl = DelitosManager.GetList(criterio, false, true, DelitosManager.TipoAutores.Conocidos);
                    break;
                case  1:
                    dl = DelitosManager.GetList(criterio, false, true, DelitosManager.TipoAutores.Desconocidos);
                    break;
            }


            System.Data.DataTable dt = new System.Data.DataTable("delitos");
            System.Data.DataColumn dc;

           


            //creo la columna con el iddelito
            dc = new DataColumn("idDelito");
            dt.Columns.Add(dc);


            //creo la columna con el nro de IPP
            dc = new DataColumn("IPP");
            dt.Columns.Add(dc);
           

            // Agrego al DataTable la direccion para el Mapa del Delito
            dc = new DataColumn("Calle");
            dt.Columns.Add(dc);

            dc = new DataColumn("Nro");
            dt.Columns.Add(dc);

            dc = new DataColumn("Piso");
            dt.Columns.Add(dc);

            dc = new DataColumn("Dto");
            dt.Columns.Add(dc);

            dc = new DataColumn("Localidad");
            dt.Columns.Add(dc);
            dc = new DataColumn("Partido");
            dt.Columns.Add(dc);

            dc = new DataColumn("Autor");
            dt.Columns.Add(dc);

            // Agrego a los delitos el Modus Operandi
            //idClaseModusOperandis
            dc = new DataColumn("Modus Operandi");
            dt.Columns.Add(dc);

          


            //recorro DELITOS
            for (int i = 0; i <= dl.Count - 1; i++)
            {
               
                System.Data.DataRow row = dt.NewRow();



                //recorro la cant de cada rastro del respectivo delito

               
                    for (int k = 0; k <= dt.Columns.Count - 1; k++)
                    {
                        switch (k)
                        {
                            case 0:
                                row[k] = dl[i].id;
                                break;
                            case 1:
                                row[k] = dl[i].idCausa.Trim();
                                break;
                            default:
                                row[k] = 0;
                                break;
                        }

                    }
               
                // Completo el domicilio para el Mapa del Delito
                if (dl[i].idOtraCalle != null)
                {
                    row[2] = dl[i].idOtraCalle.Trim();
                    row[3] = dl[i].NroH;
                    row[4] = dl[i].PisoH;
                    row[5] = dl[i].DeptoH;
                }
                row[6] = LocalidadManager.GetItem(dl[i].idLocalidad).localidad;
                row[7] = PartidoManager.GetItem(dl[i].idPartido).partido;

                row[8] = (dl[i].idTipoAutor.ToString() == FuncionesComunes.TipoAutores.Conocidos.ToString()) ? "Conocido" : "Ignorado";
                row[9] = dl[i].idClaseModusOperandis;
                dt.Rows.Add(row);
            }
            return dt;
        }

        protected void chkPorModusOperandis_CheckedChanged(object sender, EventArgs e)
        {
            bool fueElegido = this.chkPorModusOperandis.Checked;
            if (!fueElegido)
                LimpiarControlesMO();
            HabilitarControlesMO(fueElegido);
            //TREEVIEW
            ManipularTreeView("Por Modus Op.", fueElegido);

        }

        private void HabilitarControlesMO(bool habilitar)
        {
            this.chkPorModusOperandis.Checked = habilitar;
            this.ddlModusOperandis.Enabled = habilitar;
            this.ddlModoArriboHuida.Enabled = habilitar;
            this.ddlHuboVictimas.Enabled = habilitar;
            this.txtIngresaronPor.Enabled = habilitar;

        }

        private void HabilitarControlesArribo(bool habilitar)
        {
            this.chkPorDetalleModoArriboHuida.Checked = habilitar;
            this.txtParaje.Enabled = habilitar;
            this.ddlMarcaMO.Enabled = habilitar;
            this.ddlColorMO.Enabled = habilitar;
            this.ddlModeloMO.Enabled = habilitar;
            this.ddlVidriosVehiculo.Enabled = habilitar;
            this.txtPatente.Enabled = habilitar;
            this.ddlClaseVidrio.Enabled = habilitar;

        }

        protected void chkPorDetalleModoArriboHuida_CheckedChanged(object sender, EventArgs e)
        {
            bool fueElegido = this.chkPorDetalleModoArriboHuida.Checked;
            if (!fueElegido)
            {
                this.txtPatente.Text = "";
                this.ddlMarcaMO.SelectedValue = "0";
                this.ddlColorMO.SelectedValue = "0";
                this.ddlModeloMO.SelectedValue = "0";
                this.ddlClaseVidrio.SelectedValue = "0";
            }

            HabilitarControlesArribo(fueElegido);

            //TREEVIEW
            ManipularTreeView("Por Vehiculo A-H", fueElegido);
        }

        private void ManipularTreeView(string nodo, bool fueElegidoCheck)
        {
            //TREEVIEW
            TreeNode tn;
            tn = this.tvCriteriosBusqueda.FindNode(@nodo);
            if (tn != null && !fueElegidoCheck)
            {
                this.tvCriteriosBusqueda.Nodes.Remove(tn);
                this.upTree.Update();
                return;
            }
            tn = new TreeNode(nodo);
            this.tvCriteriosBusqueda.Nodes.Add(tn);
            this.upTree.Update();
        }

        protected void chkPorAutor_CheckedChanged(object sender, EventArgs e)
        {
            bool fueElegido = this.chkPorAutor.Checked;
            if (!fueElegido)
            {
                LimpiarControlesAutor();
            }
            HabilitarControlesAutor(fueElegido);

            //TREEVIEW
            TreeNode tn;
            tn = this.tvCriteriosBusqueda.FindNode("Por Autor");
            if (tn != null && fueElegido == false)
            {
                this.tvCriteriosBusqueda.Nodes.Remove(tn);
                this.upTree.Update();
                return;
            }
            tn = new TreeNode("Por Autor");
            this.tvCriteriosBusqueda.Nodes.Add(tn);
            this.upTree.Update();

        }

        private void LimpiarControlesAutor()
        {
            this.ddlCantidadAutores.SelectedValue = "0";
            this.txtNroAutor.Text = "";
            this.txtCon.Visible = false;
            this.lblCon.Visible = false;
            this.ddlEdadAproximada.SelectedValue = "0";
            this.ddlSexo.SelectedValue = "0";
            this.ddlCejaDimension.SelectedValue = "0";
            this.ddlestatura.SelectedValue = "0";
            this.ddlFormaBoca.SelectedValue = "0";
            this.ddlFormaCara.SelectedValue = "0";
            this.ddlFormaLabioInferior.SelectedValue = "0";
            this.ddlFormaLabioSuperior.SelectedValue = "0";
            this.ddlFormaMenton.SelectedValue = "0";
            this.ddlFormaNariz.SelectedValue = "0";
            this.ddlFormaOreja.SelectedValue = "0";
            this.ddlRobustez.SelectedValue = "0";
            this.ddlTipoCabello.SelectedValue = "0";
            this.ddlTipoCalvicie.SelectedValue = "0";
            this.ddlTipoCeja.SelectedValue = "0";
            this.ddlColorPiel.SelectedValue = "0";
            this.ddlColorOjos.SelectedValue = "0";
            this.ddlColorCabello.SelectedValue = "0";
            this.ddlClaseRostro.SelectedValue = "0";
            this.txtCon.Text = "";
            //this.ddlClaseLUgarDelCuerpo.SelectedValue = "0";
            this.gvSenasPartD.DataSource = "";
            this.gvSenasPartD.DataBind();
            this.gvTatuajesD.DataSource = "";
            this.gvTatuajesD.DataBind();
            //this.ddlTipoTatuaje.SelectedValue = "0";
            this.txtNombreAutor.Text = "";
            this.txtApellidoAutor.Text = "";
            this.txtApodoAutor.Text = "";
            this.txtDniAutor.Text = "";
            this.chkAp.Enabled = false;
           this.chkAp.Checked = false;
            this.chkIg.Enabled = false;
            this.chkIg.Checked = false;
            SeniasD = null;
            SeniasD = new SeniasParticularesList();
            TatuajesD = null;
            TatuajesD = new TatuajesPersonaList();
        }

        private void HabilitarControlesAutor(bool habilitar)
        {
            this.ddlCantidadAutores.Enabled = habilitar;
            this.chkAp.Enabled = habilitar;
            this.chkIg.Enabled = habilitar;

            this.txtNroAutor.Enabled = habilitar;
            this.ddlEdadAproximada.Enabled = habilitar;
            this.ddlSexo.Enabled = habilitar;
            this.ddlCejaDimension.Enabled = habilitar;
            this.ddlestatura.Enabled = habilitar;
            this.ddlFormaBoca.Enabled = habilitar;
            this.ddlFormaCara.Enabled = habilitar;
            this.ddlFormaLabioInferior.Enabled = habilitar;
            this.ddlFormaLabioSuperior.Enabled = habilitar;
            this.ddlFormaMenton.Enabled = habilitar;
            this.ddlFormaNariz.Enabled = habilitar;
            this.ddlFormaOreja.Enabled = habilitar;
            this.ddlRobustez.Enabled = habilitar;
            this.ddlTipoCabello.Enabled = habilitar;
            this.ddlTipoCalvicie.Enabled = habilitar;
            this.ddlTipoCeja.Enabled = habilitar;
            this.ddlColorPiel.Enabled = habilitar;
            this.ddlColorOjos.Enabled = habilitar;
            this.ddlColorCabello.Enabled = habilitar;
            this.ddlClaseRostro.Enabled = habilitar;
            this.txtCon.Enabled = habilitar;
            //this.ddlSeniaParticular.Enabled = habilitar;
            this.gvSenasPartD.Enabled = habilitar;
            this.gvTatuajesD.Enabled = habilitar;
            //this.ddlClaseLUgarDelCuerpo.Enabled = habilitar;
            //this.ddlLugarSenia.Enabled = habilitar;
           // this.ddlTipoTatuaje.Enabled = habilitar;
            //this.txtOtroTatuaje.Enabled = habilitar;
            //this.txtOtraCaracteristica.Enabled = habilitar;
            this.chkPorAutor.Checked = habilitar;
             this.chkIg.Checked = habilitar;
            this.chkAp.Checked = habilitar;

            this.txtDniAutor.Enabled = habilitar;
            this.txtNombreAutor.Enabled = habilitar;
            this.txtApellidoAutor.Enabled = habilitar;
            this.txtApodoAutor.Enabled = habilitar;
        }

        protected void chkPorBienSustraido_CheckedChanged(object sender, EventArgs e)
        {
            bool fueElegido = this.chkPorBienSustraido.Checked;
            if (!fueElegido)
                LimpiarControlesBS();
            HabilitarControlesBS(fueElegido);
            this.ddlClaseBienSustraido.SelectedValue = "0";
            if (fueElegido)
            {
                this.ddlClaseBienSustraido.Enabled = true;
                this.txtMontoTotalEstimado.Enabled = true;
            }


            //TREEVIEW
            TreeNode tn;
            tn = this.tvCriteriosBusqueda.FindNode("Por Bien Sust.");
            if (tn != null && fueElegido == false)
            {
                this.tvCriteriosBusqueda.Nodes.Remove(tn);
                this.upTree.Update();
                return;
            }
            tn = new TreeNode("Por Bien Sust.");
            tn.Expanded = true;
            this.tvCriteriosBusqueda.Nodes.Add(tn);
            this.upTree.Update();
        }

        private void LimpiarControlesBS()
        {
            this.ddlMarcaBS.SelectedValue = "0";
            this.ddlModeloBS.SelectedValue = "0";
            this.txtAnioAutoSustraido.Text = "";
            this.txtValor.Text = "";
            this.txtPatenteBS.Text = "";
            this.ddlColorBS.SelectedValue = "0";
            this.ddlVidriosVehiculo.SelectedValue = "0";
            this.txtNroMotor.Text = "";
            this.txtNroChasis.Text = "";
            this.ddlTieneGNC.SelectedValue = "0";
            this.ddlClaseGanado.SelectedValue = "0";
            this.txtCantidadAnimalSustraido.Text = "";
            this.txtMarcaAnimalSustraido.Text = "";
            this.txtMarcaOtroBienSustraido.Text = "";
            this.txtNroSerieOtroBien.Text = "";
            this.txtCantidadOtroBien.Text = "";
            this.txtMontoTotalEstimado.Text = "";
            //this.ddlClaseBienSustraido.SelectedValue = "0";
        }

        private void HabilitarControlesBS(bool habilitar)
        {
            this.ddlMarcaBS.Enabled = false;
            this.ddlModeloBS.Enabled = false;
            this.txtAnioAutoSustraido.Enabled = false;
            this.txtValor.Enabled = false;
            this.txtPatenteBS.Enabled = false;
            this.ddlColorBS.Enabled = false;
            this.ddlVidriosVehiculo.Enabled = false;
            this.txtNroMotor.Enabled = false;
            this.txtNroChasis.Enabled = false;
            this.ddlTieneGNC.Enabled = false;
            this.ddlClaseGanado.Enabled = false;
            this.txtCantidadAnimalSustraido.Enabled = false;
            this.txtMarcaAnimalSustraido.Enabled = false;
            this.txtMarcaOtroBienSustraido.Enabled = false;
            this.txtNroSerieOtroBien.Enabled = false;
            this.txtCantidadOtroBien.Enabled = false;
            this.txtMontoTotalEstimado.Enabled = false;
            this.ddlClaseBienSustraido.Enabled = habilitar;
            this.txtMontoTotalEstimado.Enabled = habilitar;
            this.chkPorBienSustraido.Checked = habilitar;
            if (this.chkPorBienSustraido.Checked)
                this.ddlClaseBienSustraido.SelectedValue = "0";

        }

        protected void ddlClaseBienSustraido_SelectedIndexChanged(object sender, EventArgs e)
        {
            //HabilitarControlesBS(false);
            TreeNode node;
            TreeNode subNode;
            int indiceNode;
            LimpiarControlesBS();
            string indiceClaseBS = this.ddlClaseBienSustraido.SelectedValue;
            switch (this.ddlClaseBienSustraido.SelectedItem.ToString().Trim().ToUpper())
            {
                case "ANIMALES":
                    {
                        HabilitarControlesBS(false);
                        this.ddlClaseBienSustraido.SelectedValue = indiceClaseBS;
                        this.ddlClaseGanado.Enabled = true;
                        this.txtCantidadAnimalSustraido.Enabled = true;
                        this.txtMarcaAnimalSustraido.Enabled = true;
                        this.txtMontoTotalEstimado.Enabled = true;
                        this.ddlClaseBienSustraido.Enabled = true;
                        //TREEVIEW
                        node = this.tvCriteriosBusqueda.FindNode("Por Bien Sust.");
                        indiceNode = tvCriteriosBusqueda.Nodes.IndexOf(node);
                        this.tvCriteriosBusqueda.Nodes[indiceNode].ChildNodes.Clear();
                        subNode = new TreeNode("Por Animales");
                        tvCriteriosBusqueda.Nodes[indiceNode].ChildNodes.Add(subNode);
                        this.upTree.Update();

                        break;
                    }
                case "VEHÍCULOS":
                    {
                        HabilitarControlesBS(false);
                        this.ddlClaseBienSustraido.SelectedValue = indiceClaseBS;
                        this.ddlClaseBienSustraido.Enabled = true;
                        this.ddlMarcaBS.Enabled = true;
                        this.txtPatenteBS.Enabled = true;
                        this.txtValor.Enabled = true;
                        this.ddlTieneGNC.Enabled = true;
                        this.ddlModeloBS.Enabled = true;
                        this.ddlColorBS.Enabled = true;
                        this.txtNroMotor.Enabled = true;
                        this.txtAnioAutoSustraido.Enabled = true;
                        this.ddlVidriosVehiculo.Enabled = true;
                        this.txtNroChasis.Enabled = true;
                        this.ddlTieneGNC.Enabled = true;
                        this.txtMontoTotalEstimado.Enabled = true;
                        //TREEVIEW
                        node = this.tvCriteriosBusqueda.FindNode("Por Bien Sust.");
                        indiceNode = tvCriteriosBusqueda.Nodes.IndexOf(node);
                        this.tvCriteriosBusqueda.Nodes[indiceNode].ChildNodes.Clear();
                        subNode = new TreeNode("Por Vehículos");
                        tvCriteriosBusqueda.Nodes[indiceNode].ChildNodes.Add(subNode);
                        this.upTree.Update();

                        break;
                    }
                case "INDETERMINADA":
                    {
                        HabilitarControlesBS(false);
                        this.ddlClaseBienSustraido.SelectedValue = indiceClaseBS;
                        this.ddlClaseBienSustraido.Enabled = true;
                        this.txtMontoTotalEstimado.Enabled = true;
                        //TREEVIEW
                        node = this.tvCriteriosBusqueda.FindNode("Por Bien Sust.");
                        indiceNode = tvCriteriosBusqueda.Nodes.IndexOf(node);
                        this.tvCriteriosBusqueda.Nodes[indiceNode].ChildNodes.Clear();
                        break;
                    }
                default:
                    {
                        HabilitarControlesBS(false);
                        this.ddlClaseBienSustraido.SelectedValue = indiceClaseBS;
                        this.txtMarcaOtroBienSustraido.Enabled = true;
                        this.txtNroSerieOtroBien.Enabled = true;
                        this.txtCantidadOtroBien.Enabled = true;
                        this.ddlClaseBienSustraido.Enabled = true;
                        this.txtMontoTotalEstimado.Enabled = true;
                        //TREEVIEW
                        node = this.tvCriteriosBusqueda.FindNode("Por Bien Sust.");
                        indiceNode = tvCriteriosBusqueda.Nodes.IndexOf(node);
                        this.tvCriteriosBusqueda.Nodes[indiceNode].ChildNodes.Clear();
                        subNode = new TreeNode("Por Otros Bienes");
                        tvCriteriosBusqueda.Nodes[indiceNode].ChildNodes.Add(subNode);
                        this.upTree.Update();
                        break;
                    }

            }
            this.chkPorBienSustraido.Checked = true;
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            //this.pnlLugar.Style.Remove("display");
            //this.pnlComisariasH.Style.Remove("display");
            this.pnlResultados.Visible = false;
            this.btnMapaDelito.Visible = true;
            this.label_visualiza.Visible = true;
            this.btnMapaDelitoSimbologia.Visible = true;
            /******/
            this.btnAutores.Visible = true;

            this.pnlAuxiliar.Visible = false;
            //this.pnlPrincipal.Visible = true;
            this.pnlAuxiliar.Style.Add("display", "none");
            this.pnlComisariasH.Style.Add("display", "none");
            this.pnlLugar.Style.Add("display", "none");
            this.pnlResultados.Style.Add("display", "none");
            this.pnlPrincipal.Controls.Remove(this.pnlResultados);
            this.tcBusquedaAutores.Visible = true;
            this.btnLimpiar.Visible = true;
            //this.pnlBusquedasGuardadas.Visible = true;
            this.btnBuscar.Visible = true;
            this.btnBuscar.Text = "IPP según Rastros";
            this.btnVolver.Visible = false;
            this.hfAbrirLugar_ModalPopupExtender.Enabled = true;
            this.hfAbrirComisaria_ModalPopupExtender.Enabled = true;
            this.cartelResultadoBusqueda.Visible = false;
            //this.cartelPrincipal.InnerText = "BUSQUEDA MANUAL - AUTORES IGNORADOS";
          //  ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Mensaje", @"<script language='javascript'>window.location = window.location.href+'?eraseCache=true'; </script>");

        }

        protected void btnBuscarLocalidadL_Click(object sender, ImageClickEventArgs e)
        {
            this.hfAbrirLugar_ModalPopupExtender.Enabled = true;
            this.pnlLugar.Visible = true;
            this.hfAbrirLugar_ModalPopupExtender.Show();
        }

        protected void btnCancelarLugar_Click(object sender, EventArgs e)
        {
            this.pnlLugar.Style.Add("display", "none");
        }

        protected void btnTraerLugarTraslado_Click(object sender, EventArgs e)
        {
            LocalidadList localidades = LocalidadManager.GetList(this.txtLugar.Text);

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

        protected void gvLugar_SelectedIndexChanged(object sender, EventArgs e)
        {
            //localidades.FindAll(delegate(Localidad loc) { return loc.id.ToString() == this.gvLugar.SelectedValue.ToString(); }); 
            for (int i = 0; i < Localidades.Count; i++)
            {
                if (Localidades[i].id == Convert.ToInt32(this.gvLugar.SelectedValue))
                    return;
            }
            Localidad localidad = new Localidad();
            localidad.id = Convert.ToInt32(this.gvLugar.SelectedValue);
            localidad.localidad = this.gvLugar.SelectedRow.Cells[2].Text.Trim();
            Localidades.Add(localidad);
            this.gvLocalidades.DataSource = "";
            this.gvLocalidades.DataSource = Localidades;
            this.gvLocalidades.DataBind();
            this.pnlLugar.Style.Add("display", "none");
            this.hfAbrirLugar_ModalPopupExtender.Hide();
        }

        protected void btnTraerComisariaH_Click(object sender, ImageClickEventArgs e)
        {
            this.hfAbrirComisaria_ModalPopupExtender.Enabled = true;
            this.pnlComisariasH.Visible = true;
            this.hfAbrirComisaria_ModalPopupExtender.Show();
        }

        protected void gvComisariasH_SelectedIndexChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < Comisarias.Count; i++)
            {
                if (Comisarias[i].id == Convert.ToInt32(this.gvComisariasH.SelectedValue))
                    return;
            }
            Comisaria comisaria = new Comisaria();
            comisaria.id = Convert.ToInt32(this.gvComisariasH.SelectedValue);
            comisaria.comisaria = this.gvComisariasH.SelectedRow.Cells[2].Text.Trim();
            Comisarias.Add(comisaria);
            this.gvComisarias.DataSource = "";
            this.gvComisarias.DataSource = Comisarias;
            this.gvComisarias.DataBind();
            this.pnlComisariasH.Style.Add("display", "none");
            this.hfAbrirComisaria_ModalPopupExtender.Hide();
        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComisariaList cl = ComisariaManager.GetList(Convert.ToInt32(this.ddlDepartamento.SelectedValue));
            this.gvComisariasH.DataSource = cl;
            this.gvComisariasH.DataBind();
        }

        protected void btnCancelarComisariaL_Click(object sender, EventArgs e)
        {
            this.pnlComisariasH.Style.Add("display", "none");
        }

        protected void gvBienesSustraidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dvBSAnimal.Visible = false;
            this.dvBSOtro.Visible = false;
            this.dvBSVehiculo.Visible = false;
            int id = Convert.ToInt32(this.gvBienesSustraidos.SelectedValue.ToString());
            string bien = ((Label)this.gvBienesSustraidos.SelectedRow.Cells[4].FindControl("lblTipoBS")).Text.Trim();
            switch (bien.Trim().ToUpper())
            {
                case "ANIMALES":
                    BienesSustraidosAnimal animal = BienesSustraidosAnimalManager.GetItemByBienSustraido(id);
                    if (animal == null)
                        return;
                    BienesSustraidosAnimalList al = new BienesSustraidosAnimalList();
                    al.Add(animal);
                    this.dvBSAnimal.DataSource = al;
                    this.dvBSAnimal.DataBind();
                    this.dvBSAnimal.Visible = true;

                    break;
                case "VEHÍCULOS":
                    Vehiculos autos = VehiculosManager.GetItemByBienSustraido(id);
                    if (autos == null)
                        return;
                    VehiculosList vl = new VehiculosList();
                    vl.Add(autos);
                    this.dvBSVehiculo.DataSource = vl;
                    this.dvBSVehiculo.DataBind();
                    this.dvBSVehiculo.Visible = true;
                    break;
                //case "INDETERMINADO":
                //    BienesSustraidosOtro otros = BienesSustraidosOtroManager.GetItemByBienSustraido(id);
                //    BienesSustraidosOtroList ol = new BienesSustraidosOtroList();
                //    ol.Add(otros);
                //    this.gvDetalleBS.DataSource = ol;
                //    this.gvDetalleBS.DataBind();
                //    break;
                default:
                    BienesSustraidosOtro otros = BienesSustraidosOtroManager.GetItemByBienSustraido(id);
                    if (otros == null)
                        return;
                    BienesSustraidosOtroList ol = new BienesSustraidosOtroList();
                    ol.Add(otros);
                    this.dvBSOtro.DataSource = ol;
                    this.dvBSOtro.DataBind();
                    this.dvBSOtro.Visible = true;
                    break;
            }

        }

        protected void ddlClaseRostro_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esRostroCubierto = (this.ddlClaseRostro.SelectedItem.Text.Trim().ToUpper() == "CUBIERTO");
            this.lblCon.Visible = esRostroCubierto;
            this.txtCon.Visible = esRostroCubierto;
            if (!esRostroCubierto)
                this.txtCon.Text = "";
        }

        protected void gvLocalidades_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Localidades.RemoveAt(e.RowIndex);
            this.gvLocalidades.DataSource = "";
            this.gvLocalidades.DataSource = Localidades;
            this.gvLocalidades.DataBind();
        }

        protected void btnElegirDeptoJud_Click(object sender, ImageClickEventArgs e)
        {
            this.hfAbrirLugar_ModalPopupExtender.Enabled = true;
            this.pnlLugar.Visible = true;
            this.hfAbrirLugar_ModalPopupExtender.Show();
        }

        protected void btnBuscarDeptoJud_Click(object sender, ImageClickEventArgs e)
        {
            this.hfAbrirDeptoJud_ModalPopupExtender.Enabled = true;
            this.pnlDeptoJud.Visible = true;
            this.hfAbrirDeptoJud_ModalPopupExtender.Show();
        }


        protected void gvDeptoJud_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Departamentos.RemoveAt(e.RowIndex);
            this.gvDeptoJud.DataSource = "";
            this.gvDeptoJud.DataSource = Departamentos;
            this.gvDeptoJud.DataBind();
        }

        protected void btnAceptarDeptoJud_Click(object sender, EventArgs e)
        {
            Departamentos.Clear();
            foreach (ListItem dj in this.cblDeptoJud.Items)
            {
                if (dj.Selected)
                {
                    Departamento depto = new Departamento();
                    depto.Id = Convert.ToInt32(dj.Value);
                    depto.departamento = dj.Text.Trim();
                    Departamentos.Add(depto);
                }
            }
            this.gvDeptoJud.DataSource = "";
            this.gvDeptoJud.DataSource = Departamentos;
            this.gvDeptoJud.DataBind();
            this.pnlDeptoJud.Style.Add("display", "none");
            this.hfAbrirLugar_ModalPopupExtender.Hide();
        }

        protected void btnBuscarPartido_Click(object sender, ImageClickEventArgs e)
        {
            this.hfAbrirPartido_ModalPopupExtender.Enabled = true;
            this.pnlPartido.Visible = true;
            this.hfAbrirPartido_ModalPopupExtender.Show();
        }

        protected void btnTraerPartido_Click(object sender, EventArgs e)
        {
            PartidoList partidos = PartidoManager.GetList(this.txtPartido.Text);

            if (partidos.Count > 500) //demasiados registros
            {
                this.lblDemasiadosResultados.Visible = true;
                this.lblDemasiadosResultados.Text = "Demasiados resultados, acote el criterio.";
                return;
            }
            if (partidos.Count == 0)
            {
                this.lblDemasiadosResultados.Visible = true;
                this.lblDemasiadosResultados.Text = "No se encontraron resultados";
                return;
            }
            this.lblDemasiadosResultados.Visible = false;
            this.gvPartidos.DataSource = partidos;
            this.gvPartidos.DataBind();
        }

        protected void gvPartidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Partidos.Count; i++)
            {
                if (Partidos[i].id == Convert.ToInt32(this.gvPartidos.SelectedValue))
                    return;
            }
            Partido partido = new Partido();
            partido.id = Convert.ToInt32(this.gvPartidos.SelectedValue);
            partido.partido = this.gvPartidos.SelectedRow.Cells[2].Text.Trim();
            Partidos.Add(partido);
            this.gvPartido.DataSource = "";
            this.gvPartido.DataSource = Partidos;
            this.gvPartido.DataBind();
            this.pnlPartido.Style.Add("display", "none");
            this.hfAbrirPartido_ModalPopupExtender.Hide();
        }

        protected void btnCerrarPartido_Click(object sender, EventArgs e)
        {
            this.pnlPartido.Style.Add("display", "none");
        }

        protected void gvPartido_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Partidos.RemoveAt(e.RowIndex);
            this.gvPartido.DataSource = "";
            this.gvPartido.DataSource = Partidos;
            this.gvPartido.DataBind();
        }

        protected void btnGuardarBusqueda_Click(object sender, EventArgs e)
        {
            this.tvCriteriosBusqueda.ExpandAll();
            this.upTree.Update();
            int cantBusquedas=10;//cantidad maxima de busquedas que se pueden guardar
            if (this.gvMisBusquedas.Rows.Count >= cantBusquedas)
            {
                ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "updatealert", @"<script language='javascript'>setTimeout(""alert('No se permite guardar mas de " + cantBusquedas.ToString() + @" búsquedas. Elimine alguna.')"",1000); </script>");
                return;
            }
            this.txtDescripcionBusqueda.Text = "";
            this.rfvDescripcionBusqueda.Enabled = true;
            this.hfDescripcionBusqueda_ModalPopupExtender.Show();

        }

        

        protected void lnkBorrarBusqueda_Click(object sender, EventArgs e)
        {

        }

        protected void btnOkDescripcionBusqueda_Click(object sender, EventArgs e)
        {

            if (this.IsValid)
            {
                //GuardarBusquedaFavorita();
                BusquedaRobosDelitosSexuales miBusqueda;
                bool seleccion;
                bool seleccionFecha;
                bool seleccionDomicilio;
                int seleccionAutor;
                LlenarBusqueda(out miBusqueda, out seleccion, out seleccionFecha, out seleccionAutor, out seleccionDomicilio);
                miBusqueda.DescripcionBusqueda = this.txtDescripcionBusqueda.Text.Trim();
                if (!seleccionFecha)
                {
                    ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Mensaje", @"<script language='javascript'>setTimeout(""alert('Debe seleccionar un rango de fechas que filtren la búsqueda de Delitos')"",1000); </script>");
                    return;
                }
               if (!seleccion)
                {
                    ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Mensaje", @"<script language='javascript'>setTimeout(""alert('Debe definir condiciones que filtren la búsqueda de Delitos')"",1000); </script>");
                    return;
                }
               if (!seleccionDomicilio)
               {
                   ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Mensaje", @"<script language='javascript'>setTimeout(""alert('El Domicilio seleccionado está incompleto. Como mínimo debe especificar Localidad y Calle')"",1000); </script>");
                   return;
               }
                BusquedaRobosDelitosSexualesManager.Save(miBusqueda);
                LlenarGridViewMisBusquedas();

                this.rfvDescripcionBusqueda.Enabled = false;

            }
            else
            {
                this.rfvDescripcionBusqueda.ErrorMessage = "error";

            }

        }

        protected void btnCancelarDescripcionBusqueda_Click(object sender, EventArgs e)
        {
            this.rfvDescripcionBusqueda.Enabled = false;
            this.hfDescripcionBusqueda_ModalPopupExtender.Hide();
        }

        protected void btnVerMisBusquedas_Click(object sender, EventArgs e)
        {
            this.pnlBusquedasGuardadas.Visible = true;
        }

      

        protected void gvMisBusquedas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(this.gvMisBusquedas.SelectedDataKey["id"]);
            BusquedaRobosDelitosSexuales miBusqueda = BusquedaRobosDelitosSexualesManager.GetItem(id);
            SeteoGeneral();
            this.tvCriteriosBusqueda.Nodes.Clear();
            LlenarControlesConMiBusqueda(miBusqueda);
        }

        private void LlenarControlesConMiBusqueda(BusquedaRobosDelitosSexuales miBusqueda)
        {

            TreeNode tn = null;
            ///////////////////////
            //TIEMPO Y TERRITORIO//
            ///////////////////////
            //IPP

            if (miBusqueda.IdCausa !=null && miBusqueda.IdCausa!= "")
            {
                this.chkPorIpp.Checked = true;
                //TreeView
                tn = this.tvCriteriosBusqueda.FindNode("Por IPP");
                if (tn != null)
                    tn.ChildNodes.Clear();
                tn = new TreeNode("Por IPP");
                this.tvCriteriosBusqueda.Nodes.Add(tn);
                string ipp = miBusqueda.IdCausa == null ? "" : miBusqueda.IdCausa.Trim();
                this.txtIpp.Text = ipp;
                if (tn != null & ipp != "")
                    tn.ChildNodes.Add(new TreeNode("IPP: " + ipp));
            }

            //FECHA
            bool buscoPorTiempo = false;
            if (miBusqueda.FechaDesde != null || miBusqueda.FechaHasta != null)
            {
                //this.chkBuscarPorTiempo.Checked = true;
                //chkBuscarPorTiempo_CheckedChanged(this.chkBuscarPorTiempo, null);
                this.rbPorFecha.Checked = true;
                GestionRbPorFecha();
                //rbPorFecha_CheckedChanged(this.rbPorFecha, null);
                //treeview
                tn = this.tvCriteriosBusqueda.FindNode("Por Tiempo/Por Fecha");
                if (tn != null)
                    tn.ChildNodes.Clear();
                tn = new TreeNode("Por Tiempo/Por Fecha");
                this.tvCriteriosBusqueda.Nodes.Add(tn);
                

                if (miBusqueda.FechaDesde != null)
                {
                   
                    this.txtFechaDesde.Text = miBusqueda.FechaDesde.ToString();
                    {
                        tn.ChildNodes.Add(new TreeNode("Desde: " + this.txtFechaDesde.Text.Trim().Substring(0,10) ));
                        buscoPorTiempo = true;        
                    }
                }
                if (miBusqueda.FechaHasta != null)
                {
                    this.txtFechaHasta.Text = miBusqueda.FechaHasta.ToString();
                    if (tn != null)
                    {
                        tn.ChildNodes.Add(new TreeNode("Hasta: " + this.txtFechaHasta.Text.Trim().Substring(0, 10)));
                        buscoPorTiempo = true;
                    }
                }
            }

            if (miBusqueda.IdClaseMomentoDelDia > 0)
            {
                this.rbMomentoDia.Checked = true;
                GestionRbPorMomentoDelDia();
                this.chkBuscarPorTiempo.Checked = true;
                tn = this.tvCriteriosBusqueda.FindNode("Por Tiempo/Por Mom. del Día");
                if (tn != null)
                    tn.ChildNodes.Clear();
                tn = new TreeNode("Por Tiempo/Por Mom. del Día");
                this.tvCriteriosBusqueda.Nodes.Add(tn);
                this.ddlMomentoDia.SelectedValue = miBusqueda.IdClaseMomentoDelDia.ToString();
                if (tn != null)
                {
                    tn.ChildNodes.Add(new TreeNode("Momento del Día: " + this.ddlMomentoDia.SelectedItem.ToString()));
                    buscoPorTiempo = true;
                }
            }

            //HORA
            if ((miBusqueda.HoraDesde != null && miBusqueda.HoraDesde != "") || (miBusqueda.HoraHasta != null && miBusqueda.HoraHasta != ""))
            {

                //this.chkBuscarPorTiempo.Checked = true;
                this.rbPorHora.Checked = true;
                
                GestionRbPorHora();
                tvCriteriosBusqueda.ExpandAll();
                tn = this.tvCriteriosBusqueda.FindNode("Por Tiempo/Por Hora");
                if (tn != null)
                    tn.ChildNodes.Clear();
                tn = new TreeNode("Por Tiempo/Por Hora");
                this.tvCriteriosBusqueda.Nodes.Add(tn);
                string horaDesde = miBusqueda.HoraDesde != null ? miBusqueda.HoraDesde : "";
                this.txtHoraDesde.Text = horaDesde;
                if (tn != null && horaDesde != "")
                {
                    tn.ChildNodes.Add(new TreeNode("Desde: " + horaDesde));
                    buscoPorTiempo = true;
                }
                string horaHasta = miBusqueda.HoraHasta != null ? miBusqueda.HoraHasta : "";
                this.txtHoraHasta.Text = horaHasta;
                if (tn != null && horaHasta != "")
                {
                    tn.ChildNodes.Add(new TreeNode("Hasta: " + horaHasta));
                    buscoPorTiempo = true;
                }
            }
            this.chkBuscarPorTiempo.Checked = buscoPorTiempo;
            this.rbPorHora.Enabled = buscoPorTiempo;
            this.rbPorFecha.Enabled = buscoPorTiempo;
            this.rbMomentoDia.Enabled = buscoPorTiempo;
            

            //TERRITORIO

            bool buscoPorTerritorio = false;

            tn = this.tvCriteriosBusqueda.FindNode("Por Territorio");
            if (tn != null)
                tn.ChildNodes.Clear();
            tn = new TreeNode("Por Territorio");
            this.tvCriteriosBusqueda.Nodes.Add(tn);
            string otraCalle = miBusqueda.IdOtraCalle;
            this.txtOtraCalle.Text = otraCalle;
            if (tn != null && otraCalle != null && otraCalle != "")
            {
                tn.ChildNodes.Add(new TreeNode("Calle: " + otraCalle));
                buscoPorTerritorio = true;
            }

            string nroH = miBusqueda.NroH;
            this.txtNro.Text = nroH;
            if (tn != null && nroH !=null && nroH != "")
            {
                tn.ChildNodes.Add(new TreeNode("Nro: " + nroH));
                buscoPorTerritorio = true;
            }
            string pisoH = miBusqueda.PisoH;
            this.txtPiso.Text = pisoH;
            if (tn != null && pisoH!=null && pisoH != "")
            {
                tn.ChildNodes.Add(new TreeNode("Piso: " + pisoH));
                buscoPorTerritorio = true;
            }
            string deptoH = miBusqueda.DeptoH;
            this.txtDepto.Text = deptoH;
            if (tn != null && deptoH !=null && deptoH != "")
            {
                tn.ChildNodes.Add(new TreeNode("Depto: " + deptoH));
                buscoPorTerritorio = true;
            }
            string parajeBarrioH = miBusqueda.ParajeBarrioH;
            this.txtParaje.Text = parajeBarrioH;
            if (tn != null && parajeBarrioH!=null && parajeBarrioH != "")
            {
                tn.ChildNodes.Add(new TreeNode("Paraje: " + parajeBarrioH));
                buscoPorTerritorio = true;
            }
            string otraEntreCalle2 = miBusqueda.IdOtraEntreCalle2;
            this.txtOtraCalle2.Text = otraEntreCalle2;
            if (tn != null && otraEntreCalle2!=null && otraEntreCalle2 != "")
            {
                tn.ChildNodes.Add(new TreeNode("Entre: " + otraEntreCalle2));
                buscoPorTerritorio = true;
            }
            string otraEntreCalle = miBusqueda.IdOtraEntreCalle;
            this.txtOtraCalle1.Text = otraEntreCalle;
            if (tn != null && otraEntreCalle != null && otraEntreCalle != "")
            {
                tn.ChildNodes.Add(new TreeNode("Y Entre: " + otraEntreCalle));
                buscoPorTerritorio = true;
            }

            //Caso en el que se ingresen varios departamentos a buscar
            if (miBusqueda.IdDepartamento != null && miBusqueda.IdDepartamento.Trim() != "")
            {
                System.Collections.ArrayList al = new System.Collections.ArrayList();
                string[] idDepartamentos = miBusqueda.IdDepartamento.Split(',');
                string nombreDepartamentos = null;
                DepartamentoList dl = new DepartamentoList();
                for (int i = 0; i < idDepartamentos.Length; i++)
                {
                    int id = Convert.ToInt32(idDepartamentos[i]);
                    Departamento departamento = DepartamentoManager.GetItem(id);
                    if (departamento != null)
                        dl.Add(departamento);
                    nombreDepartamentos += departamento.departamento.Trim();
                    if (i < idDepartamentos.Length - 1)
                        nombreDepartamentos += ",<br />";
                }
                if (tn != null && nombreDepartamentos != null && nombreDepartamentos != "")
                {
                    tn.ChildNodes.Add(new TreeNode("Departamento: <br />" + nombreDepartamentos));
                    this.gvDeptoJud.DataSource = dl;
                    this.gvDeptoJud.DataBind();
                    Departamentos = dl;
                    buscoPorTerritorio = true;
                }
            }

            //Caso en el que se ingresen varias localidades a buscar
             if (miBusqueda.IdLocalidad !=null && miBusqueda.IdLocalidad.Trim()!="")
            {
                System.Collections.ArrayList al = new System.Collections.ArrayList();
                string[] idLocalidades = miBusqueda.IdLocalidad.Split(',');
                string nombreLocalidades = null;
                LocalidadList ll = new LocalidadList();
                for (int i = 0; i < idLocalidades.Length; i++)
                {
                    int id = Convert.ToInt32(idLocalidades[i]);
                    Localidad localidad=LocalidadManager.GetItem(id);
                    if (localidad!=null)
                        ll.Add(localidad);
                    nombreLocalidades += localidad.localidad.Trim();
                    if (i < idLocalidades.Length - 1)
                        nombreLocalidades += ",<br />";
                }
                if (tn != null && nombreLocalidades != null && nombreLocalidades != "")
                {
                    tn.ChildNodes.Add(new TreeNode("Localidad: <br />" + nombreLocalidades));
                    this.gvLocalidades.DataSource = ll;
                    this.gvLocalidades.DataBind();
                    Localidades = ll;
                    buscoPorTerritorio = true;
                }
            }

            //Caso en el que se ingresen varios partidos a buscar
            if (miBusqueda.IdPartido!=null && miBusqueda.IdPartido.Trim()!="")
            {
                System.Collections.ArrayList al = new System.Collections.ArrayList();
                string[] idPartidos = miBusqueda.IdPartido.Split(',');
                string nombrePartidos = null;
                PartidoList pl = new PartidoList();
                for (int i = 0; i < idPartidos.Length; i++)
                {
                    int id = Convert.ToInt32(idPartidos[i]);
                    Partido partido=PartidoManager.GetItem(id);
                    if (partido!=null)
                        pl.Add(partido);
                    nombrePartidos+=partido.partido.Trim();
                    if (i<idPartidos.Length-1)
                        nombrePartidos+=",<br />";
                }
                if (tn != null && nombrePartidos!=null && nombrePartidos!="")
                {
                    tn.ChildNodes.Add(new TreeNode("Partido: <br />" + nombrePartidos));
                    this.gvPartido.DataSource = pl;
                    this.gvPartido.DataBind();
                    Partidos = pl;
                    buscoPorTerritorio = true;
                }
            }

            //Caso en el que se ingresen varias comisarias a buscar
            if (miBusqueda.IdComisariaH != null && miBusqueda.IdComisariaH.Trim() != "")
            {
                System.Collections.ArrayList al = new System.Collections.ArrayList();
                string[] idComisarias = miBusqueda.IdComisariaH.Split(',');
                string nombreComisarias = null;
                ComisariaList cl = new ComisariaList();
                for (int i = 0; i < idComisarias.Length; i++)
                {
                    int id = Convert.ToInt32(idComisarias[i]);
                    Comisaria comisaria = ComisariaManager.GetItem(id);
                    if (Comisarias != null)
                        cl.Add(comisaria);
                    nombreComisarias += comisaria.comisaria.Trim();
                    if (i < idComisarias.Length - 1)
                        nombreComisarias += ",<br />";
                }
                if (tn != null && nombreComisarias != null && nombreComisarias != "")
                {
                    tn.ChildNodes.Add(new TreeNode("Comisaria: <br />" + nombreComisarias));
                    this.gvComisarias.DataSource = cl;
                    this.gvComisarias.DataBind();
                    Comisarias = cl;
                    buscoPorTerritorio = true;
                }
            }

            if (!buscoPorTerritorio)
            {
                tn = this.tvCriteriosBusqueda.FindNode("Por Territorio");
                if (tn != null)
                {
                    tn.ChildNodes.Clear();
                    this.tvCriteriosBusqueda.Nodes.Remove(tn);
                }
            }
            this.chkPorTerritorio.Checked = buscoPorTerritorio;
            HabilitarControlesTerritorio(buscoPorTerritorio);


            //LUGAR Y RUBRO
            bool buscoPorLugar = false;

            tn = this.tvCriteriosBusqueda.FindNode("Por Lugar y Rubro");
            if (tn != null)
                tn.ChildNodes.Clear();
            tn = new TreeNode("Por Lugar y Rubro");
            this.tvCriteriosBusqueda.Nodes.Add(tn);
            int? idLugar = miBusqueda.IdClaseLugar;
            if (idLugar != null && idLugar > 0)
            {
                this.ddlLugar.SelectedValue = idLugar.ToString();
                if (tn != null)
                {
                    tn.ChildNodes.Add(new TreeNode("Lugar: " + this.ddlLugar.SelectedItem.ToString()));
                    buscoPorLugar = true;
                }
            }
            int? idRubro = miBusqueda.IdClaseRubro;
            if (idRubro != null && idRubro > 0)
            {
                this.ddlRubro.SelectedValue = idRubro.ToString();
                if (tn != null)
                {
                    tn.ChildNodes.Add(new TreeNode("Rubro: " + this.ddlRubro.SelectedItem.ToString()));
                    buscoPorLugar = true;
                }
            }
            string nomRef = miBusqueda.NomReferenciaLugarRubro;
            this.txtNomRef.Text = nomRef;
            if (tn != null && nomRef!=null && nomRef != "")
            {
                tn.ChildNodes.Add(new TreeNode("Nom. de Referencia: " + nomRef));
                buscoPorLugar = true;
            }
            this.chkPorLugar.Checked = buscoPorLugar;
            if (!buscoPorLugar)
            {
                tn = this.tvCriteriosBusqueda.FindNode("Por Lugar y Rubro");
                if (tn != null)
                {
                    tn.ChildNodes.Clear();
                    this.tvCriteriosBusqueda.Nodes.Remove(tn);
                }
            }

            //////////////////
            //MODUS OPERANDI//
            //////////////////
            bool buscoPorMO = false;

            //TreeNode tn;
            tn = this.tvCriteriosBusqueda.FindNode("Por Modus Op.");
            if (tn != null)
                tn.ChildNodes.Clear();
            tn = new TreeNode("Por Modus Op.");
            this.tvCriteriosBusqueda.Nodes.Add(tn);
            int? idMO = miBusqueda.IdClaseModusOperandi;
            if (idMO != null && idMO > 0)
            {
                this.ddlModusOperandis.SelectedValue = idMO.ToString();
                if (tn != null)
                {
                    tn.ChildNodes.Add(new TreeNode("Modus Operandi: " + this.ddlModusOperandis.SelectedItem.ToString()));
                    buscoPorMO = true;
                }
            }
            int? idModoAH = miBusqueda.IdClaseModoArriboHuida;
            if (idModoAH != null && idModoAH > 0)
            {
                this.ddlModoArriboHuida.SelectedValue = idModoAH.ToString();
                if (tn != null)
                {
                    tn.ChildNodes.Add(new TreeNode("Modo Arribo/Huída: " + this.ddlModoArriboHuida.SelectedItem.ToString()));
                    buscoPorMO = true;
                }
            }
            string ingresaronPor = miBusqueda.IngresaronPor == null ? "" : miBusqueda.IngresaronPor.Trim();
            this.txtIngresaronPor.Text = ingresaronPor;
            if (tn != null && ingresaronPor != "")
            {
                tn.ChildNodes.Add(new TreeNode("Ingresaron por: " + ingresaronPor));
                buscoPorMO = true;
            }
            int? huboVictimas = miBusqueda.VictimasEnElLugar;
            if (huboVictimas != null && huboVictimas > 0)
            {
                this.ddlHuboVictimas.SelectedValue = huboVictimas.ToString();
                if (tn != null)
                {
                    tn.ChildNodes.Add(new TreeNode("Hubo Víctimas: " + this.ddlHuboVictimas.SelectedItem.ToString()));
                    buscoPorMO = true;
                }
            }
            if (!buscoPorMO)
            {
                tn = this.tvCriteriosBusqueda.FindNode("Por Modus Op.");
                if (tn != null)
                {
                    tn.ChildNodes.Clear();
                    this.tvCriteriosBusqueda.Nodes.Remove(tn);
                }
            }
            this.chkPorModusOperandis.Checked = buscoPorMO;
            HabilitarControlesMO(buscoPorMO);

            /////////////////////
            //MODO ARRIBO-HUIDA//
            /////////////////////
            bool buscoModoAH = false;
            tn = this.tvCriteriosBusqueda.FindNode("Por Vehiculo A-H");
            if (tn != null)
                tn.ChildNodes.Clear();
            tn = new TreeNode("Por Vehiculo A-H");
            this.tvCriteriosBusqueda.Nodes.Add(tn);
            Vehiculos criterioVehiculo = new Vehiculos();
            string dominioMO = miBusqueda.DominioMO;
            this.txtPatente.Text = dominioMO;
            if (tn != null && dominioMO!=null && dominioMO != "")
            {
                tn.ChildNodes.Add(new TreeNode("Dominio: " + dominioMO));
                buscoModoAH = true;
            }
            string idMarcaVMO = miBusqueda.IdMarcaVehiculoMO==null?"":miBusqueda.IdMarcaVehiculoMO.Trim();
            if (idMarcaVMO != "")
            {
                this.ddlMarcaMO.SelectedValue = idMarcaVMO.ToString();
                if (tn != null)
                {
                    tn.ChildNodes.Add(new TreeNode("Marca: " + this.ddlMarcaMO.SelectedItem.ToString()));
                    buscoModoAH = true;
                }
            }
            string idModeloVMO = miBusqueda.IdModeloVehiculoMO == null ? "" : miBusqueda.IdModeloVehiculoMO.Trim();
            if (idModeloVMO != "")
            {
                this.ddlModeloMO.SelectedValue = idModeloVMO;
                if (tn != null)
                {
                    tn.ChildNodes.Add(new TreeNode("Modelo: " + this.ddlModeloMO.SelectedItem.ToString()));
                    buscoModoAH = true;
                }
            }
            string idColorVMO = miBusqueda.IdColorVehiculoMO == null ? "" : miBusqueda.IdColorVehiculoMO.Trim();
            if (idColorVMO != "")
            {
                this.ddlColorMO.SelectedValue = idColorVMO;
                if (tn != null)
                {
                    tn.ChildNodes.Add(new TreeNode("Color: " + this.ddlColorMO.SelectedItem.ToString()));
                    buscoModoAH = true;
                }
            }
            int? idVidrioVMO = miBusqueda.IdClaseVidrioVehiculoMO;
            if (idVidrioVMO != null && idVidrioVMO > 0)
            {
                this.ddlClaseVidrio.SelectedValue = idVidrioVMO.ToString();
                if (tn != null)
                {
                    tn.ChildNodes.Add(new TreeNode("Vidrios: " + this.ddlClaseVidrio.SelectedItem.ToString()));
                    buscoModoAH = true;
                }
            }
            if (!buscoModoAH)
            {
                tn = this.tvCriteriosBusqueda.FindNode("Por Vehiculo A-H");
                if (tn != null)
                {
                    tn.ChildNodes.Clear();
                    this.tvCriteriosBusqueda.Nodes.Remove(tn);
                }
            }
            this.chkPorDetalleModoArriboHuida.Checked = buscoModoAH;
            HabilitarControlesArribo(buscoModoAH);

            ///////////////
            //AUTOR      //
            ///////////////
            bool buscoPorAutor = false;

            //    TreeNode tn;
            tn = this.tvCriteriosBusqueda.FindNode("Por Autor");
            if (tn != null)
                tn.ChildNodes.Clear();
            tn = new TreeNode("Por Autor");
            this.tvCriteriosBusqueda.Nodes.Add(tn);
            int? cantAutores = miBusqueda.IdClaseCantidadAutores;
            if (cantAutores != null && cantAutores > 0)
            {
                this.ddlCantidadAutores.SelectedValue = cantAutores.ToString();
                if (tn != null)
                {
                    tn.ChildNodes.Add(new TreeNode("Cant. Autores: " + this.ddlCantidadAutores.SelectedItem.ToString()));
                    buscoPorAutor = true;
                }
            }
            if (miBusqueda.Nro != null && miBusqueda.Nro != "")
            {
                this.txtNroAutor.Text = miBusqueda.Nro.Trim();
                if (tn != null)
                {
                    tn.ChildNodes.Add(new TreeNode("Nro. Autor: " + this.txtNroAutor.Text.Trim()));
                    buscoPorAutor = true;
                }
            }
            if (miBusqueda.CubiertoCon != null && miBusqueda.CubiertoCon != "")
            {
                this.txtCon.Text = miBusqueda.CubiertoCon.Trim();

                if (tn != null)
                {
                    tn.ChildNodes.Add(new TreeNode("Cubierto con: " + miBusqueda.CubiertoCon.Trim()));
                    buscoPorAutor = true;
                }
            }
            int? edadAprox = miBusqueda.IdClaseEdadAproximada;
            if (edadAprox != null && edadAprox > 0)
            {

                this.ddlEdadAproximada.SelectedValue = edadAprox.ToString();
                if (tn != null)
                {
                    tn.ChildNodes.Add(new TreeNode("Edad Aprox.: " + this.ddlEdadAproximada.SelectedItem.ToString()));
                    buscoPorAutor = true;
                }
            }
            int? sexo = miBusqueda.IdClaseSexo;
            if (sexo != null && sexo > 0)
            {
                this.ddlSexo.SelectedValue = sexo.ToString();
                if (tn != null)
                {
                    tn.ChildNodes.Add(new TreeNode("Sexo: " + this.ddlSexo.SelectedItem.ToString()));
                    buscoPorAutor = true;
                }
            }
            int? rostro = miBusqueda.IdClaseRostro;
            if (rostro != null && rostro > 0)
            {
                this.ddlClaseRostro.SelectedValue = rostro.ToString();
                if (tn != null)
                {
                    tn.ChildNodes.Add(new TreeNode("Rostro: " + this.ddlClaseRostro.SelectedItem.ToString()));
                    buscoPorAutor = true;
                }
            }
            if (miBusqueda.idClaseEstaturaL != null && miBusqueda.idClaseEstaturaL.Trim() != "")
            {
            string[] idEstaturas = miBusqueda.idClaseEstaturaL.Split(',');
            string estatura = idEstaturas[0];
            if (estatura != null && estatura != "")
            {
                this.ddlestatura.SelectedValue = estatura;
                if (tn != null)
                {
                    tn.ChildNodes.Add(new TreeNode("Estatura: " + this.ddlestatura.SelectedItem.ToString()));
                    buscoPorAutor = true;
                }
            }
               
            }
            if (miBusqueda.idClaseRobustezL != null && miBusqueda.idClaseRobustezL.Trim() != "")
            {
                string[] idRobustez = miBusqueda.idClaseRobustezL.Split(',');
                string robustez = idRobustez[0];
                if (robustez != null && robustez != "")
                {
                    this.ddlRobustez.SelectedValue = robustez;
                    if (tn != null)
                    {
                        tn.ChildNodes.Add(new TreeNode("Robustez: " + this.ddlRobustez.SelectedItem.ToString()));
                        buscoPorAutor = true;
                    }
                }
            }
            if (miBusqueda.idClaseColorOjosL != null && miBusqueda.idClaseColorOjosL.Trim() != "")
            {
                string[] idColorOjos = miBusqueda.idClaseColorOjosL.Split(',');
                string colorOjos = idColorOjos[0];
                if (colorOjos != null && colorOjos != "")
                {
                    this.ddlColorOjos.SelectedValue = colorOjos;
                    if (tn != null)
                    {
                        tn.ChildNodes.Add(new TreeNode("Color Ojos: " + this.ddlColorOjos.SelectedItem.ToString()));
                        buscoPorAutor = true;
                    }
                }
            }
            if (miBusqueda.idClaseColorPielL != null && miBusqueda.idClaseColorPielL.Trim() != "")
            {
                string[] idColorPiel = miBusqueda.idClaseColorPielL.Split(',');
                string colorPiel = idColorPiel[0];
                if (colorPiel != null && colorPiel != "")
                {
                    this.ddlColorPiel.SelectedValue = colorPiel;
                    if (tn != null)
                    {
                        tn.ChildNodes.Add(new TreeNode("Color Piel: " + this.ddlColorPiel.SelectedItem.ToString()));
                        buscoPorAutor = true;
                    }
                }
            }
            if (miBusqueda.idClaseColorCabelloL != null && miBusqueda.idClaseColorCabelloL.Trim() != "")
            {
                string[] idColorCabello = miBusqueda.idClaseColorCabelloL.Split(',');
                string colorCabello = idColorCabello[0];
                if (colorCabello != null && colorCabello != "")
                {
                    this.ddlColorCabello.SelectedValue = colorCabello;
                    if (tn != null)
                    {
                        tn.ChildNodes.Add(new TreeNode("Color Cabello: " + this.ddlColorCabello.SelectedItem.ToString()));
                        buscoPorAutor = true;
                    }
                }
            }
            if (miBusqueda.idClaseTipoCabelloL != null && miBusqueda.idClaseTipoCabelloL.Trim() != "")
            {
                string[] idTipoCabello = miBusqueda.idClaseTipoCabelloL.Split(',');
                string tipoCabello = idTipoCabello[0];
                if (tipoCabello != null && tipoCabello != "")
                {
                    this.ddlTipoCabello.SelectedValue = tipoCabello;
                    if (tn != null)
                    {
                        tn.ChildNodes.Add(new TreeNode("Tipo Cabello: " + this.ddlTipoCabello.SelectedItem.ToString()));
                        buscoPorAutor = true;
                    }
                }
            }
            if (miBusqueda.idClaseFormaCaraL != null && miBusqueda.idClaseFormaCaraL.Trim() != "")
            {
                string[] idFormaCara = miBusqueda.idClaseFormaCaraL.Split(',');
                string formaCara = idFormaCara[0];
                if (formaCara != null && formaCara != "")
                {
                    this.ddlFormaCara.SelectedValue = formaCara;
                    if (tn != null)
                    {
                        tn.ChildNodes.Add(new TreeNode("Forma Cara: " + this.ddlFormaCara.SelectedItem.ToString()));
                        buscoPorAutor = true;
                    }
                }
            }
            if (miBusqueda.idFormaMentonL != null && miBusqueda.idFormaMentonL.Trim() != "")
            {
                string[] idFormaMenton = miBusqueda.idFormaMentonL.Split(',');
                string formaMenton = idFormaMenton[0];
                if (formaMenton != null && formaMenton != "")
                {
                    this.ddlFormaMenton.SelectedValue = formaMenton;
                    if (tn != null)
                    {
                        tn.ChildNodes.Add(new TreeNode("Forma Menton: " + this.ddlFormaMenton.SelectedItem.ToString()));
                        buscoPorAutor = true;
                    }
                }
            }
            if (miBusqueda.idFormaNarizL != null && miBusqueda.idFormaNarizL.Trim() != "")
            {
                string[] idFormaNariz = miBusqueda.idFormaNarizL.Split(',');
                string formaNariz = idFormaNariz[0];
                if (formaNariz != null && formaNariz != "")
                {
                    this.ddlFormaNariz.SelectedValue = formaNariz;
                    if (tn != null)
                    {
                        tn.ChildNodes.Add(new TreeNode("Forma Nariz: " + this.ddlFormaNariz.SelectedItem.ToString()));
                        buscoPorAutor = true;
                    }
                }
            }
            if (miBusqueda.idFormaBocaL != null && miBusqueda.idFormaBocaL.Trim() != "")
            {
                string[] idFormaBoca = miBusqueda.idFormaBocaL.Split(',');
                string formaBoca = idFormaBoca[0];
                if (formaBoca != null && formaBoca != "")
                {
                    this.ddlFormaBoca.SelectedValue = formaBoca;
                    if (tn != null)
                    {
                        tn.ChildNodes.Add(new TreeNode("Forma Boca: " + this.ddlFormaBoca.SelectedItem.ToString()));
                        buscoPorAutor = true;
                    }
                }
            }
            if (miBusqueda.idFormaLabioInferiorL != null && miBusqueda.idFormaLabioInferiorL.Trim() != "")
            {
                string[] idFormaLabioInf = miBusqueda.idFormaLabioInferiorL.Split(',');
                string formaLabioInf = idFormaLabioInf[0];
                if (formaLabioInf != null && formaLabioInf != "")
                {
                    this.ddlFormaLabioInferior.SelectedValue = formaLabioInf;
                    if (tn != null)
                    {
                        tn.ChildNodes.Add(new TreeNode("Forma Labio Inf: " + this.ddlFormaLabioInferior.SelectedItem.ToString()));
                        buscoPorAutor = true;
                    }
                }
            }
            if (miBusqueda.idFormaLabioSuperiorL != null && miBusqueda.idFormaLabioSuperiorL.Trim() != "")
            {
                string[] idFormaLabioSup = miBusqueda.idFormaLabioSuperiorL.Split(',');
                string formaLabioSup = idFormaLabioSup[0];
                if (formaLabioSup != null && formaLabioSup != "")
                {
                    this.ddlFormaLabioSuperior.SelectedValue = formaLabioSup;
                    if (tn != null)
                    {
                        tn.ChildNodes.Add(new TreeNode("Forma Labio Sup: " + this.ddlFormaLabioSuperior.SelectedItem.ToString()));
                        buscoPorAutor = true;
                    }
                }
            }
            if (miBusqueda.idFormaOrejaL != null && miBusqueda.idFormaOrejaL.Trim() != "")
            {
                string[] idFormaOreja = miBusqueda.idFormaOrejaL.Split(',');
                string formaOreja = idFormaOreja[0];
                if (formaOreja != null && formaOreja != "")
                {
                    this.ddlFormaOreja.SelectedValue = formaOreja;
                    if (tn != null)
                    {
                        tn.ChildNodes.Add(new TreeNode("Forma Oreja: " + this.ddlFormaOreja.SelectedItem.ToString()));
                        buscoPorAutor = true;
                    }
                }
            }
            if (miBusqueda.idClaseCalvicieL != null && miBusqueda.idClaseCalvicieL.Trim() != "")
            {
                string[] idTipoCalvicie = miBusqueda.idClaseCalvicieL.Split(',');
                string TipoCalvicie = idTipoCalvicie[0];
                if (TipoCalvicie != null && TipoCalvicie != "")
                {
                    this.ddlTipoCalvicie.SelectedValue = TipoCalvicie;
                    if (tn != null)
                    {
                        tn.ChildNodes.Add(new TreeNode("Tipo Calvicie: " + this.ddlTipoCalvicie.SelectedItem.ToString()));
                        buscoPorAutor = true;
                    }
                }
            }
            if (miBusqueda.idDimensionCejaL != null && miBusqueda.idDimensionCejaL.Trim() != "")
            {
                string[] idCejaDimension = miBusqueda.idDimensionCejaL.Split(',');
                string CejaDimension = idCejaDimension[0];
                if (CejaDimension != null && CejaDimension != "")
                {
                    this.ddlCejaDimension.SelectedValue = CejaDimension;
                    if (tn != null)
                    {
                        tn.ChildNodes.Add(new TreeNode("Ceja Dimensión: " + this.ddlCejaDimension.SelectedItem.ToString()));
                        buscoPorAutor = true;
                    }
                }
            }
            if (miBusqueda.idTipoCejaL != null && miBusqueda.idTipoCejaL.Trim() != "")
            {
                string[] idCejaForma = miBusqueda.idTipoCejaL.Split(',');
                string CejaForma = idCejaForma[0];
                if (CejaForma != null && CejaForma != "")
                {
                    this.ddlTipoCeja.SelectedValue = CejaForma;
                    if (tn != null)
                    {
                        tn.ChildNodes.Add(new TreeNode("Tipo Ceja: " + this.ddlTipoCeja.SelectedItem.ToString()));
                        buscoPorAutor = true;
                    }
                }
            }
            //Caso en el que se ingresen varias señas a buscar
            if (miBusqueda.IdClaseSeniaParticularL != null && miBusqueda.IdClaseSeniaParticularL.Trim() != "")
            {
                string[] idSeniasLugares = miBusqueda.IdClaseSeniaParticularL.Split(',');
                string nombreSenias = null;
                SeniasParticularesList spl = new SeniasParticularesList();
                ClaseSeniaParticular seniaParticular = new ClaseSeniaParticular();
                ClaseUbicacionSeniaPart ubSeniaParticular = new ClaseUbicacionSeniaPart();
                for (int i = 0; i < idSeniasLugares.Length; i++)
                {
                    string[] idSeniaLugar = idSeniasLugares[i].Split('-');
                    SeniasParticulares sp = new SeniasParticulares();
                    sp.idSeniaParticular = Convert.ToInt32(idSeniaLugar[0]);
                    sp.idUbicacionSeniaParticular = Convert.ToInt32(idSeniaLugar[1]);
                    seniaParticular = ClaseSeniaParticularManager.GetItem(sp.idSeniaParticular);
                    ubSeniaParticular = ClaseUbicacionSeniaPartManager.GetItem(sp.idUbicacionSeniaParticular);
                    spl.Add(sp);
                    nombreSenias += seniaParticular.Descripcion.Trim() + "-" + ubSeniaParticular.Descripcion;
                    if (i < idSeniasLugares.Length - 1)
                        nombreSenias += ",<br />";
                }
                if (tn != null && nombreSenias != null && nombreSenias != "")
                {
                    tn.ChildNodes.Add(new TreeNode("Seña Part.: <br />" + nombreSenias));
                    this.gvSenasPartD.DataSource = spl;
                    this.gvSenasPartD.DataBind();
                    buscoPorAutor = true;
                }
            }
            //Caso en el que se ingresen varios tatuajes a buscar
            if (miBusqueda.IdClaseTatuajeL != null && miBusqueda.IdClaseTatuajeL.Trim() != "")
            {
                string[] idTatuajesLugares = miBusqueda.IdClaseTatuajeL.Split(',');
                string nombreTatuajes = null;
                TatuajesPersonaList tpl = new TatuajesPersonaList();
                ClaseTatuaje tatuaje = new ClaseTatuaje();
                ClaseUbicacionSeniaPart ubTatuaje = new ClaseUbicacionSeniaPart();
                for (int i = 0; i < idTatuajesLugares.Length; i++)
                {
                    string[] idTatuajeLugar = idTatuajesLugares[i].Split('-');
                    TatuajesPersona tp = new TatuajesPersona();
                    tp.idTatuaje = Convert.ToInt32(idTatuajeLugar[0]);
                    tp.idUbicacionTatuaje = Convert.ToInt32(idTatuajeLugar[1]);
                    tatuaje = ClaseTatuajeManager.GetItem(tp.idTatuaje);
                    ubTatuaje = ClaseUbicacionSeniaPartManager.GetItem(tp.idUbicacionTatuaje);
                    tpl.Add(tp);
                    nombreTatuajes += tatuaje.descripcion.Trim() + "-" + ubTatuaje.Descripcion;
                    if (i < idTatuajesLugares.Length - 1)
                        nombreTatuajes += ",<br />";
                }
                if (tn != null && nombreTatuajes != null && nombreTatuajes != "")
                {
                    tn.ChildNodes.Add(new TreeNode("Tatuaje: <br />" + nombreTatuajes));
                    this.gvTatuajesD.DataSource = tpl;
                    this.gvTatuajesD.DataBind();
                    buscoPorAutor = true;
                }
            }

            if (TipoAutor == FuncionesGenerales.TipoAutores.Conocidos)
            {
                string nombreAutor = miBusqueda.NombreAutor == null ? "" : miBusqueda.NombreAutor.Trim();
                this.txtNombreAutor.Text = nombreAutor;
                if (tn != null && nombreAutor != "")
                {
                    tn.ChildNodes.Add(new TreeNode("Nombre Autor: " + nombreAutor));
                    buscoPorAutor = true;
                }
                string apellidoAutor = miBusqueda.ApellidoAutor == null ? "" : miBusqueda.ApellidoAutor.Trim();
                this.txtApellidoAutor.Text = apellidoAutor;
                if (tn != null && apellidoAutor != "")
                {
                    tn.ChildNodes.Add(new TreeNode("Apellido Autor: " + apellidoAutor));
                    buscoPorAutor = true;
                }

                string apodoAutor = miBusqueda.ApodoAutor == null ? "" : miBusqueda.ApodoAutor.Trim();
                this.txtApodoAutor.Text = apodoAutor;
                if (tn != null && apodoAutor != "")
                {
                    tn.ChildNodes.Add(new TreeNode("Apodo Autor: " + apodoAutor));
                    buscoPorAutor = true;
                }
                int? dniAutor = miBusqueda.DocNroAutor;
                if (dniAutor != null && dniAutor > 0)
                {
                    this.txtDniAutor.Text = dniAutor.ToString();
                    if (tn != null)
                    {
                        tn.ChildNodes.Add(new TreeNode("Doc. Nro. Autor: " + dniAutor.ToString()));
                        buscoPorAutor = true;
                    }
                }
            }
            if (!buscoPorAutor)
            {
                tn = this.tvCriteriosBusqueda.FindNode("Por Autor");
                if (tn != null)
                {
                    tn.ChildNodes.Clear();
                    this.tvCriteriosBusqueda.Nodes.Remove(tn);
                }
            }
            this.chkPorAutor.Checked = buscoPorAutor;
            HabilitarControlesAutor(buscoPorAutor);

            //////////////////
            //BIEN SUSTRAIDO//
            //////////////////
            bool buscoPorBS = false;

            tn = this.tvCriteriosBusqueda.FindNode("Por Bien Sust.");
            if (tn != null)
                tn.ChildNodes.Clear();
            if (this.tpBienesSustraidos.Visible)
            {
                tn = new TreeNode("Por Bien Sust.");
                this.tvCriteriosBusqueda.Nodes.Add(tn);
                double montoEstimado = Convert.ToDouble(miBusqueda.MontoTotalEstimadoBienSustraido);



                if (tn != null && montoEstimado > 0)
                {
                    this.txtMontoTotalEstimado.Text = montoEstimado.ToString();
                    tn.ChildNodes.Add(new TreeNode("Monto Total: " + this.txtMontoTotalEstimado.Text.Trim()));
                    buscoPorBS = true;
                }
                int? claseBS = miBusqueda.IdClaseBienSustraido;
                if (claseBS != null && claseBS > 0)
                {
                    this.ddlClaseBienSustraido.SelectedValue = claseBS.ToString();
                    if (tn != null)
                    {
                        tn.ChildNodes.Add(new TreeNode("Bien: " + this.ddlClaseBienSustraido.SelectedItem.ToString()));
                        buscoPorBS = true;
                    }



                    switch (this.ddlClaseBienSustraido.SelectedItem.Text.Trim().ToUpper())
                    {
                        case "ANIMALES":
                            //Animal Sustraido
                            int? claseGanado = miBusqueda.IdClaseGanado;
                            if (claseGanado != null && claseGanado > 0)
                            {
                                this.ddlClaseGanado.SelectedValue = claseGanado.ToString();
                                if (tn != null)
                                    tn.ChildNodes.Add(new TreeNode("Ganado: " + this.ddlClaseGanado.SelectedItem.ToString()));
                            }
                            int? cantAnimalSust = miBusqueda.CantidadGanado;
                            if (cantAnimalSust != null && cantAnimalSust > 0)
                            {
                                this.txtCantidadAnimalSustraido.Text = cantAnimalSust.ToString();
                                if (tn != null)
                                    tn.ChildNodes.Add(new TreeNode("Cant.Gan.: " + this.txtCantidadAnimalSustraido.Text.Trim()));
                            }
                            string marcaGanado = miBusqueda.MarcaGanado == null ? "" : miBusqueda.MarcaGanado.Trim();
                            this.txtMarcaAnimalSustraido.Text = marcaGanado;
                            if (tn != null && marcaGanado != "")
                                tn.ChildNodes.Add(new TreeNode("Marca Gan.: " + marcaGanado));
                            break;

                        case "VEHÍCULOS":
                            //Vehiculo
                            string dominioBS = miBusqueda.DominioBS == null ? "" : miBusqueda.DominioBS.Trim();
                            this.txtPatenteBS.Text = dominioBS;
                            if (tn != null && dominioBS != "")
                                tn.ChildNodes.Add(new TreeNode("Patente: " + dominioBS));
                            int idMarcaVBS;
                            Int32.TryParse(miBusqueda.IdMarcaVehiculoBS, out idMarcaVBS);
                            if (idMarcaVBS > 0)
                            {
                                this.ddlMarcaBS.SelectedValue = idMarcaVBS.ToString();
                                if (tn != null)
                                    tn.ChildNodes.Add(new TreeNode("Marca V.: " + this.ddlMarcaBS.SelectedItem.Text.Trim()));
                            }
                            int idModeloVBS;
                            Int32.TryParse(miBusqueda.IdModeloVehiculoBS, out idModeloVBS);
                            if (idModeloVBS > 0)
                            {
                                this.ddlModeloBS.SelectedValue = idModeloVBS.ToString();
                                if (tn != null)
                                    tn.ChildNodes.Add(new TreeNode("Modelo V.: " + this.ddlModeloBS.SelectedItem.Text.Trim()));
                            }
                            int idColorVBS;
                            Int32.TryParse(miBusqueda.IdColorVehiculoBS, out idColorVBS);
                            if (idColorVBS > 0)
                            {
                                this.ddlColorBS.SelectedValue = idColorVBS.ToString();
                                if (tn != null)
                                    tn.ChildNodes.Add(new TreeNode("Color V.: " + this.ddlColorBS.SelectedItem.Text.Trim()));
                            }
                            int? tieneGNCBS = miBusqueda.GNCBS;
                            if (tieneGNCBS != null && tieneGNCBS > 0)
                            {
                                this.ddlTieneGNC.SelectedValue = tieneGNCBS.ToString();
                                if (tn != null)
                                    tn.ChildNodes.Add(new TreeNode("Tiene GNC: " + this.ddlTieneGNC.SelectedItem.Text.Trim()));
                            }
                            string numeroMotorBS = miBusqueda.NumeroMotorBS == null ? "" : miBusqueda.NumeroMotorBS.Trim();
                            this.txtNroMotor.Text = numeroMotorBS;
                            if (tn != null && numeroMotorBS != "")
                                tn.ChildNodes.Add(new TreeNode("Motor: " + numeroMotorBS));
                            string anioBS = miBusqueda.AnioBS == null ? "" : miBusqueda.AnioBS.Trim();
                            this.txtAnioAutoSustraido.Text = anioBS;
                            if (tn != null && anioBS != "")
                                tn.ChildNodes.Add(new TreeNode("Año V.: " + anioBS));
                            int? vidriosV = miBusqueda.IdClaseVidrioVehiculoBS;
                            if (vidriosV != null && vidriosV > 0)
                            {
                                this.ddlVidriosVehiculo.SelectedValue = vidriosV.ToString();
                                if (tn != null)
                                    tn.ChildNodes.Add(new TreeNode("Vidrios V.: " + this.ddlVidriosVehiculo.SelectedItem.Text.Trim()));
                            }
                            string numeroChasisBS = miBusqueda.NumeroChasisBS == null ? "" : miBusqueda.NumeroChasisBS.Trim();
                            this.txtNroChasis.Text = numeroChasisBS;
                            if (tn != null && numeroChasisBS != "")
                                tn.ChildNodes.Add(new TreeNode("Chasis: " + numeroChasisBS));
                            break;
                        default:
                            //Otro Bien Sustraido
                            string marcaBienSustraidoOtro = miBusqueda.MarcaBienSustraidoOtro == null ? "" : miBusqueda.MarcaBienSustraidoOtro.Trim();
                            this.txtMarcaOtroBienSustraido.Text = marcaBienSustraidoOtro;
                            if (tn != null && marcaBienSustraidoOtro != "")
                                tn.ChildNodes.Add(new TreeNode("Marca Otro: " + marcaBienSustraidoOtro));
                            string nroSerieBienSustraidoOtro = miBusqueda.NroSerieBienSustraidoOtro == null ? "" : miBusqueda.NroSerieBienSustraidoOtro.Trim();
                            this.txtNroSerieOtroBien.Text = nroSerieBienSustraidoOtro;
                            if (tn != null && nroSerieBienSustraidoOtro != "")
                                tn.ChildNodes.Add(new TreeNode("Serie Otro: " + nroSerieBienSustraidoOtro));
                            int? cantOtroBien = miBusqueda.CantidadBienSustraidoOtro;
                            if (cantOtroBien != null && cantOtroBien > 0)
                            {
                                this.txtCantidadOtroBien.Text = cantOtroBien.ToString();
                                if (tn != null)
                                    tn.ChildNodes.Add(new TreeNode("Cant.Otro: " + this.txtCantidadOtroBien.Text.Trim()));
                            }
                            break;
                    }
                }
                if (!buscoPorBS)
                {
                    tn = this.tvCriteriosBusqueda.FindNode("Por Bien Sust.");
                    if (tn != null)
                    {
                        tn.ChildNodes.Clear();
                        this.tvCriteriosBusqueda.Nodes.Remove(tn);
                    }
                }
                this.chkPorBienSustraido.Checked = buscoPorBS;
                HabilitarControlesBS(buscoPorBS);
                tvCriteriosBusqueda.ExpandAll();
                this.upTree.Update();
            }
        }

     

        protected void gvMisBusquedas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idMiBusqueda = Convert.ToInt32(this.gvMisBusquedas.DataKeys[e.RowIndex].Value);
            BusquedaRobosDelitosSexuales miBusqueda = BusquedaRobosDelitosSexualesManager.GetItem(idMiBusqueda);
            BusquedaRobosDelitosSexualesManager.Delete(miBusqueda);
            LlenarGridViewMisBusquedas();
        }

        protected void gvComisarias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Comisarias.RemoveAt(e.RowIndex);
            this.gvComisarias.DataSource = "";
            this.gvComisarias.DataSource = Comisarias;
            this.gvComisarias.DataBind();
        }


        protected void Page_Disposed (object sender, EventArgs e)
        {
            Session.Remove("Resultados");
        }

       


    }

    
}

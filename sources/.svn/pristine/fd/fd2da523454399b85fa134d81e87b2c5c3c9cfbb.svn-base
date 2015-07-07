using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPBA.AutoresIgnorados.Bll;
using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.SIAC.Bll;
using MPBA.SIAC.BusinessEntities;
using System.Xml;

namespace MPBA.AutoresIgnorados.Web
{
    public partial class CargaVictimas : System.Web.UI.Page
    {
        //**************************************************
        //*EXPLICACION VARIABLE "TIPO" EN QUERYSTRING      *
        //*PRIMER DIGITO TIPO AUTOR, 2DO DIGITO TIPO DELITO*
        //*"11" = NN y ROBOS Y HURTOS                      *
        //*"12" = NN y DELITOS SEXUALES                    *
        //*"21" = APREHENDIDOS y ROBOS Y HURTOS            *
        //*"22" = APREHENDIDOS y DELITOS SEXUALES          *
        //**************************************************
        //*STATUS=1  vengo de pantallas anteriores         *
        //**************************************************
        //*C=1 es solo consulta                            *
        //**************************************************

        //bool esNN;//si es nn o aprehendidos
        #region "Eventos"
        protected void Page_Load(object sender, EventArgs e)
        {

            //esNN = Convert.ToBoolean(Session["esNN"]);
            if (!Page.IsPostBack)
            {
                bool esNN = Convert.ToBoolean(Request.QueryString["tipo"].ToString().Substring(0, 1) == "1");
                Session["esNN"] = esNN;
                bool esConsulta = Request.QueryString["c"].ToString() == "1" ? true : false;
                if (esConsulta)
                    this.pnlVictimasGral.Enabled = false;
                //resalta en el menu, el modulo en el que estoy actualmente
                string moduloActual = Request.QueryString["tipo"].ToString().Substring(1, 1);
                switch (moduloActual)
                {
                    case "1":
                        Session["moduloActual"] = "RH";
                        break;
                    case "2":
                        Session["moduloActual"] = "DS";
                        break;
                }
                this.btnPasarAAutorCon.Visible = esNN;
                switch (esNN)
                {
                    case false://autores aprehendidos
                        this.imgCartelVictimas.ImageUrl = "~/App_Images/cartelVictimasConocidos.png";
                        this.cartelPrincipal.InnerText = "AUTORES APREHENDIDOS";
                        //this.pnlAutor.Visible = true;
                        break;
                    case true://autores desconocidos
                        this.imgCartelVictimas.ImageUrl = "~/App_Images/cartelVictimas.png";
                        this.cartelPrincipal.InnerText = "AUTORES IGNORADOS";

                        //this.pnlAutor.Visible = false;
                        break;
                    default:
                        return;

                }


                Delitos miDelito = (Delitos)Session["miDelito"];

                int status = Convert.ToInt32(Request.QueryString["status"]);

                
                if (status == 1)//no vengo de pantallas anteriores trabajando con el mismo delito
                {
                    miDelito = null;
                }

                
                if (miDelito != null)
                {
                   
                    IndicarStatus();
                    HabilitarControles(true);
                    LimpiarControles();
                    LlenarControles();
                    BuscarDelitoEnWebService(miDelito.idCausa);
                    this.btnBuscarIpp.Text = "Busca Otro";
                    this.txtIpp.Enabled = false;

                }
                else
                {
                    Session["miDelito"] = miDelito;
                    HabilitarControles(false);
                    LimpiarControles();
                    this.txtIpp.Focus();
                }

            }
        }

        protected void btnCerrar_Command(object sender, CommandEventArgs e)
        {
            Session["miDelito"] = null;
            Response.Redirect("~/Home.aspx");
        }



        protected void rblFecha_SelectedIndexChanged(object sender, EventArgs e)
        {
            int valor = Convert.ToInt16(this.rblFecha.SelectedValue);
            SeleccionarFecha(valor);
        }

        protected void rblHora_SelectedIndexChanged(object sender, EventArgs e)
        {
            int valor = Convert.ToInt16(this.rblHora.SelectedValue);
            SeleccionarHora(valor);
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
         //   ScriptManager.RegisterStartupScript(upBotones, upBotones.GetType(), "Alerta", "Confirm('Mensaje: L');", true);
          //  string Script = "confirm('Are you sure you want to Delete ?');";
            //ScriptManager.RegisterClientScriptBlock(upBotones, upBotones.GetType(), "DeleteMessage", Script, true);
           // ScriptManager.RegisterStartupScript(upBotones, upBotones.GetType(), "alerta", Script, true);

            
          

           

            Validar();
            if (!this.IsValid)
            {
                this.ValidationSummary1.DataBind();
                return;
            }
            GuardarDelito();
            //Session["esNN"] = esNN;
            MPBA.SIAC.Web.MasterPage myMaster = (MPBA.SIAC.Web.MasterPage)this.Master;
            Telerik.Web.UI.RadMenuItem radItem = myMaster.radMenuPrincipal.FindItemByText("Delitos Sexuales");
            bool esConsulta = Request.QueryString["c"].ToString() == "1" ? true : false;
            if (esConsulta)
                Response.Redirect("CargaModusOperandi.aspx?c=1");
            else
            {
                if (ValidarDireccion() == 1)
                {
                    ScriptManager.RegisterStartupScript(btnSiguiente, this.GetType(), "Mensaje", "confirmContinuar();", true);
                    return;
                }
                Response.Redirect("CargaModusOperandi.aspx?c=0");
            }
        }

        protected void btnBuscarIpp_Click(object sender, EventArgs e)
        {


            if (this.btnBuscarIpp.Text == "Busca Otro")
            {
                this.txtIpp.Enabled = true;
                HabilitarControles(false);
                LimpiarControles();
                this.btnBuscarIpp.Text = "Buscar";
                this.txtIpp.Text = "";
                this.txtIpp.Focus();
                return;
            }
            if (this.txtIpp.Text.Trim().Length != 12)
            {
                string msg = "Cantidad incorrecta de dígitos. (Deberían ser 12).";
                ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('" + msg + "');", true);
                return;
            }
            if (BuscarIpp(this.txtIpp.Text.Trim()) == true)
            {
                LimpiarControles();
                LlenarControles();
                IndicarStatus();
                HabilitarControles(true);
                this.txtIpp.Enabled = false;
                this.btnBuscarIpp.Text = "Busca Otro";
            }
            else
            {
                this.txtIpp.Focus();
            }
            string tipo = Request.QueryString["tipo"].Substring(1, 1);
            if (tipo == "2")//delitos sexuales
            {
                this.rblFecha.Items[1].Enabled = false;
                this.rblHora.Items[1].Enabled = false;
            }
        }


        protected void btnTraerLugarHecho_Click(object sender, EventArgs e)
        {
            LocalidadList localidades = LocalidadManager.GetList(this.txtLugar.Text);

            if (localidades.Count > 500) //demasiados registros
            {
                this.lblDemasiadosResultados.Style.Add("color", "Red");
                this.lblDemasiadosResultados.Visible = true;
                this.lblDemasiadosResultados.Text = "Demasiados resultados, acote el criterio.";
                return;
            }
            if (localidades.Count == 0) //demasiados registros
            {
                this.lblDemasiadosResultados.Style.Add("color", "Red");
                this.lblDemasiadosResultados.Visible = true;
                this.lblDemasiadosResultados.Text = "No se encontraron resultados.";
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
            Delitos miDelito = (Delitos)Session["miDelito"];
            miDelito.idLocalidad = Convert.ToInt32(this.gvLugar.SelectedValue);
            this.lblLocalidadH.Text = this.gvLugar.SelectedRow.Cells[2].Text.Trim();
            this.lblPartidoH.Text = ((Label)this.gvLugar.SelectedRow.Cells[3].FindControl("lblPartidoGrid")).Text.Trim();
            miDelito.idPartido = LocalidadManager.GetItem(Convert.ToInt32(this.gvLugar.SelectedValue)).Partido;
            this.pnlLugar.Style.Add("display", "none");
            this.btnBuscarLocalidadH_ModalPopupExtender.Hide();
        }

        protected void gvComisariasH_SelectedIndexChanged(object sender, EventArgs e)
        {
            Delitos miDelito = (Delitos)Session["miDelito"];
            this.lblComisariaH.Text = this.gvComisariasH.SelectedRow.Cells[2].Text.Trim();
            miDelito.idComisariaH = Convert.ToInt32(this.gvComisariasH.SelectedValue);
            this.pnlComisariasH.Style.Add("display", "none");
            this.btnTraerComisariaH_ModalPopupExtender.Hide();
        }

        protected void btnTraerComisariaL_Click(object sender, EventArgs e)
        {
            this.pnlComisariasH.Style.Remove("display");
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


        #endregion

        #region "Metodos
        private void IndicarStatus()
        {
            Delitos miDelito = (Delitos)Session["miDelito"];
            if (miDelito == null)
            {
                miDelito = new Delitos();
                miDelito.id = -1;
            }

            if (miDelito.id == -1)
            {
                miDelito.id = -1;
                this.lblCondicionCarga.Text = "NUEVO";
                this.lblCondicionCarga.Style.Add("color", "Blue");

            }
            else if (miDelito != null && miDelito.id != -1)
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

            //this.txtHoraDesde.Visible = false;
            //this.txtHoraHasta.Visible = false;
            //this.txtFechaDesde.Visible = false;
            //this.txtFechaHasta.Visible = false;

            this.pnlFechaDesdeHasta.Visible = false;
            this.pnlHoraDesdeHasta.Visible = false;
            this.txtFechaDesde.Text = "";
            this.txtFechaHasta.Text = "";
            this.txtHoraDesde.Text = "";
            this.txtHoraHasta.Text = "";
            this.lblPartidoH.Text = "";
            this.lblLocalidadH.Text = "";
            this.txtBarrio.Text = "";
            this.txtCalle.Text = "";
            this.txtEntreCalle.Text = "";
            this.txtYEntreCalle.Text = "";
            this.txtNro.Text = "";
            this.txtPiso.Text = "";
            this.txtDepto.Text = "";
            this.lblComisariaH.Text = "";
            this.txtNomRef.Text = "";
            this.lblDemasiadosResultados.Visible = false;
            this.rblFecha.SelectedValue = "0";//indeterminada
            this.rblHora.SelectedValue = "0";//indeterminada
            this.pnlLugar.Style.Add("display", "none");
            this.pnlComisariasH.Style.Add("display", "none");

        }

        private void GuardarDelito()
        {
            Delitos miDelito = (Delitos)Session["miDelito"];

            if (miDelito == null)
            {
                miDelito = new Delitos();
                miDelito.id = -1;
            }
            miDelito.idCausa = this.txtIpp.Text.Trim();
            //Fechas
            miDelito.idClaseFecha = Convert.ToInt16(this.rblFecha.SelectedValue);
            DateTime fechaDesde;
            if (DateTime.TryParse(this.txtFechaDesde.Text.Trim(), out fechaDesde))
                miDelito.FechaDesde = fechaDesde;
            else
                miDelito.FechaDesde = null;
            DateTime fechaHasta;
            if (DateTime.TryParse(this.txtFechaHasta.Text.Trim(), out fechaHasta))
                miDelito.FechaHasta = fechaHasta;
            else
                miDelito.FechaHasta = null;
            //Horas
            int tipoHora = Convert.ToInt16(this.rblHora.SelectedValue);
            miDelito.idClaseHora = tipoHora;
            switch (tipoHora)
            {
                case 1://hora entre y entre
                    miDelito.HoraDesde = this.txtHoraDesde.Text.Trim();
                    miDelito.HoraHasta = this.txtHoraHasta.Text.Trim();
                    break;
                case 2://momento del dia
                    miDelito.idClaseMomentoDelDia = Convert.ToInt16(this.ddlMomentoDelDia.SelectedValue);
                    break;
                default:
                    miDelito.HoraDesde = "";
                    miDelito.HoraHasta = "";
                    miDelito.idClaseHora = 0;
                    break;
            }

         
        


    
            
            
            //Localidad y Partido los carga cuando actualiza el llamado
            miDelito.idOtraCalle = this.txtCalle.Text.Trim();
            miDelito.idOtraEntreCalle = this.txtEntreCalle.Text.Trim();
            miDelito.idOtraEntreCalle2 = this.txtYEntreCalle.Text.Trim();
            miDelito.NroH = this.txtNro.Text.Trim();
            miDelito.PisoH = this.txtPiso.Text.Trim();
            miDelito.DeptoH = this.txtDepto.Text.Trim();
            //MIRAR*************
            //miDelito.LugarTrasladoVictima = this.txtLugarTraslado.Text.Trim();
            //**************
            miDelito.idClaseLugar = Convert.ToInt16(this.ddlLugar.SelectedValue);
            miDelito.idClaseRubro = Convert.ToInt16(this.ddlRubro.SelectedValue);
            miDelito.ParajeBarrioH = this.txtBarrio.Text.Trim();
            miDelito.NomRefLugarRubro = this.txtNomRef.Text.Trim();
            miDelito.idTipoAutor = Convert.ToBoolean(Session["esNN"]) == true ? 1 : 2;
            Session["miDelito"] = miDelito;
        }

        private void LlenarControles()
        {
            Delitos miDelito = (Delitos)Session["miDelito"];

            if (miDelito == null || miDelito.idCausa == null || miDelito.idCausa == "")
                return;
            this.txtIpp.Text = miDelito.idCausa;
            if (miDelito.NomRefLugarRubro != null)
                this.txtNomRef.Text = miDelito.NomRefLugarRubro.Trim();
            //Fechas
            int idClaseFecha = miDelito.idClaseFecha;
            this.rblFecha.SelectedValue = idClaseFecha.ToString();
            SeleccionarFecha(idClaseFecha);
            if (miDelito.FechaDesde.HasValue)
            {
                this.txtFechaDesde.Text = Convert.ToDateTime(miDelito.FechaDesde).ToString("dd/MM/yyyy");
            }
            if (miDelito.FechaHasta.HasValue)
            {
                this.txtFechaHasta.Text = Convert.ToDateTime(miDelito.FechaHasta).ToString("dd/MM/yyyy");
            }


            //Horas
            int idClaseHora = miDelito.idClaseHora;
            this.rblHora.SelectedValue = idClaseHora.ToString();
            SeleccionarHora(idClaseHora);
            this.txtHoraDesde.Text = miDelito.HoraDesde;
            if (miDelito.HoraHasta != null && miDelito.HoraHasta.Trim() != "")
                this.txtHoraHasta.Text = miDelito.HoraHasta;
            if (miDelito.idClaseMomentoDelDia > 1)
                this.ddlMomentoDelDia.SelectedValue = miDelito.idClaseMomentoDelDia.ToString();
            else
                this.ddlMomentoDelDia.SelectedValue = "1";
            if (miDelito.NroH != null)
                this.txtNro.Text = miDelito.NroH;
            if (miDelito.PisoH != null)
                this.txtPiso.Text = miDelito.PisoH;
            if (miDelito.DeptoH != null)
                this.txtDepto.Text = miDelito.DeptoH;
            this.ddlLugar.SelectedValue = miDelito.idClaseLugar.ToString();
            ddlRubro.DataBind();
            if (miDelito.idClaseRubro > 1)
                this.ddlRubro.SelectedValue = miDelito.idClaseRubro.ToString();
            else
                this.ddlRubro.SelectedValue = "0";
            if (miDelito.ParajeBarrioH != null)
                this.txtBarrio.Text = miDelito.ParajeBarrioH;

            //Lugar Hecho
            this.lblLocalidadH.Text = LocalidadManager.GetItem(miDelito.idLocalidad).localidad;
            this.lblPartidoH.Text = PartidoManager.GetItem(miDelito.idPartido).partido;
            if (miDelito.idOtraCalle != null)
                this.txtCalle.Text = miDelito.idOtraCalle.Trim();
            else
                this.txtCalle.Text = "";
            if (miDelito.idOtraEntreCalle != null)
                this.txtEntreCalle.Text = miDelito.idOtraEntreCalle.Trim();
            else
                this.txtEntreCalle.Text = "";
            if (miDelito.idOtraEntreCalle2 != null)
                this.txtYEntreCalle.Text = miDelito.idOtraEntreCalle2.Trim();
            else
                this.txtYEntreCalle.Text = "";
            this.lblComisariaH.Text = ComisariaManager.GetItem(miDelito.idComisariaH).comisaria;
            if (miDelito.NomRefLugarRubro != null)
                this.txtNomRef.Text = miDelito.NomRefLugarRubro;
            //-----------


        }


       
        private int ValidarDireccion()
        {

         /*
          Valida direcciones de google
          *           
          **/
            int resul = 0;


            if (this.txtCalle.Text.Trim() == "" || this.txtNro.Text.Trim() == "" || this.lblLocalidadH.Text.Trim() == "" || this.lblLocalidadH.Text.Trim() == "" || this.lblPartidoH.Text.Trim() == "No Especifica" || this.lblPartidoH.Text.Trim() == "" || this.lblLocalidadH.Text.Trim() == "No Especifica")
             resul= 1;            
  /*       else
             {
                GoogleMarker goo = new GoogleMarker();
                goo.domicilio = this.txtCalle.Text.Trim() + this.txtNro.Text.Trim() + "," + this.lblLocalidadH.Text.Trim() + "," + this.lblPartidoH.Text.Trim();
                int resultado;
                Boolean validar = GoogleRepositorio.ValidaDireccionGoggle(goo, out resultado);
                if (Convert.ToBoolean(validar) == false)
                    resul= 1;
              }
*/            
            return resul;
        }
        private void Validar()
        {
            //Controla Rango fechas
            string fechaDesde = this.txtFechaDesde.Text.Trim();
            string fechaHasta = this.txtFechaHasta.Text.Trim();
            if (this.rblFecha.SelectedValue == "1" && fechaDesde != "" && fechaHasta != "")
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
            if (this.rblHora.SelectedValue == "1" && horaDesde != "" && horaHasta != "")
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

        /// <summary>
        /// Selecciona el tipo de fecha
        /// </summary>
        /// <param name="valor">opcion a elegir</param>
        private void SeleccionarFecha(int valor)
        {
            switch (valor)
            {
                default:
                case 0://fecha indeterminada
                    this.txtFechaHasta.Visible = false;
                    this.btnCalendarHasta.Visible = false;
                    this.lblFechaHasta.Visible = false;
                    this.pnlFechaDesdeHasta.Visible = false;
                    this.mevFechaDesde.Enabled = false;
                    this.mevFechaHasta.Enabled = false;
                    this.cvFechas.Enabled = false;
                    break;
                case 1://fecha entre y entre
                    this.lblFechaDesde.Text = "Desde";
                    this.txtFechaHasta.Visible = true;
                    this.btnCalendarHasta.Visible = true;
                    this.lblFechaHasta.Visible = true;
                    this.pnlFechaDesdeHasta.Visible = true;
                    this.mevFechaDesde.Enabled = true;
                    this.mevFechaHasta.Enabled = true;
                    this.cvFechas.Enabled = true;
                    //this.txtFechaDesde.Focus();
                    break;
                case 2://fecha determinada
                    this.lblFechaDesde.Text = "Fecha";
                    this.txtFechaHasta.Visible = false;
                    this.btnCalendarHasta.Visible = false;
                    this.lblFechaHasta.Visible = false;
                    this.pnlFechaDesdeHasta.Visible = true;
                    this.mevFechaDesde.Enabled = true;
                    this.mevFechaHasta.Enabled = false;
                    this.cvFechas.Enabled = false;
                    //this.txtFechaDesde.Focus();
                    break;
            }
        }

        /// <summary>
        /// Selecciona el tipo de hora del delito
        /// </summary>
        /// <param name="valor">opcion a elegir</param>
        private void SeleccionarHora(int valor)
        {
            switch (valor)
            {
                default:
                case 0: //hora indeterminada
                    this.mevHoraDesde.Enabled = false;
                    this.mevHoraHasta.Enabled = false;
                    this.pnlHoraDesdeHasta.Visible = false;
                    break;
                case 1: //hora entre y entre
                    this.lblHoraDesde.Text = "Desde";
                    this.txtHoraHasta.Visible = true;
                    this.lblHoraHasta.Visible = true;
                    this.ddlMomentoDelDia.Visible = false;
                    this.txtHoraDesde.Visible = true;
                    this.mevHoraDesde.Enabled = true;
                    this.mevHoraHasta.Enabled = true;
                    this.pnlHoraDesdeHasta.Visible = true;
                    //this.txtHoraDesde.Focus();
                    break;
                case 2: //momento del dia
                    this.lblHoraDesde.Text = "";
                    this.txtHoraHasta.Visible = false;
                    this.lblHoraHasta.Visible = false;
                    this.ddlMomentoDelDia.Width = 200;
                    this.ddlMomentoDelDia.Visible = true;
                    this.txtHoraDesde.Visible = false;
                    this.mevHoraDesde.Enabled = false;
                    this.mevHoraHasta.Enabled = false;
                    this.pnlHoraDesdeHasta.Visible = true;
                    //this.ddlMomentoDelDia.Focus();
                    break;
            }
        }

        /// <summary>
        /// Busca la ipp ingresada, devuelve false si la ipp no pertenece al tipo de NN actual
        /// </summary>
        /// <param name="ipp">Ipp a buscar</param>
        private bool BuscarIpp(string ipp)
        {
            Delitos miDelito;
            miDelito = DelitosManager.GetItemByIdCausa(ipp, true);
            int idClaseDelito = Convert.ToInt32(Request.QueryString["tipo"].Substring(1, 1));
            //*****CONTROLA SI ES DELITO SEXUAL O ROBOS Y HURTOS
            if (miDelito != null && miDelito.Baja == false &&  idClaseDelito != miDelito.idClaseDelito)
            {
                string msg = "La IPP pertenece a " + NNClaseTipoDelitoManager.GetItem(miDelito.idClaseDelito).descripcion.Trim() + ".";
                ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('" + msg + "');", true);
                miDelito = null;
                return false;
            }
            int tipoAutorPagina = Convert.ToBoolean(Session["esNN"]) == true ? 1 : 2;
            if (miDelito != null && tipoAutorPagina != miDelito.idTipoAutor)
            {
                string autor = "";
                switch (miDelito.idTipoAutor)
                {
                    case 1:
                        autor = "Autores Ignorados";
                        break;
                    case 2:
                        autor = "Autores Aprehendidos";
                        break;
                }
                string msg = "La IPP pertenece a " + autor + ".";
                //ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "updatealert", @"<script language='javascript'>setTimeout(""alert(" + msg + @")"",1); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('" + msg + "');", true);
                miDelito = null;
                return false;
            }
            if (miDelito != null && miDelito.Baja == true && idClaseDelito == miDelito.idClaseDelito)
            {
                string msg = "La IPP se encuentra dada de baja.";
                ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('" + msg + "');", true);
                miDelito = null;
                return false;
            }
            bool esConsulta = Request.QueryString["c"].ToString() == "1" ? true : false;
            if (esConsulta && miDelito == null)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Error: Número de causa inexistente.');", true);
                return false;
            }

            if (miDelito == null)
            {
                miDelito = new Delitos();
                miDelito.idClaseDelito = idClaseDelito;
                miDelito.id = -1;
            }
            Session["miDelito"] = miDelito;

            BuscarDelitoEnWebService(ipp);
            this.btnSiguiente.Enabled = true;
            return true;
        }

        private void BuscarDelitoEnWebService(string ipp)
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
                System.Data.DataTable tblVictimas = new System.Data.DataTable();
                tblVictimas.Columns.Add("tipo");
                tblVictimas.Columns.Add("Apellido");
                tblVictimas.Columns.Add("Nombre");
                //tblVictimas.Columns.Add("Id");
                this.gvVictimas.DataSource = tblVictimas;
                //tblVictimas.Rows.Clear();
                ////////////////////////////////////
                //Defino tabla para grilla de Delitos
                System.Data.DataTable tblDelitos = new System.Data.DataTable();
                tblDelitos.Columns.Add("Descripcion");
                this.gvDelitos.DataSource = tblDelitos;
                //tblDelitos.Rows.Clear();
                ///////////////////////////////
                while (reader.Read())
                {
                    if (reader.NodeType != XmlNodeType.Element)
                        continue;
                    switch (reader.Name)
                    {
                        case "Causa":
                            while (reader.MoveToNextAttribute())
                            {
                                string nombre = reader.Name;
                                string aa = reader.Value;
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
                                System.Data.DataRow rowDenunciante = tblVictimas.NewRow();
                                rowDenunciante["tipo"] = "D";
                                while (reader.MoveToNextAttribute())
                                {
                                    switch (reader.Name)
                                    {
                                        case "Nombre":
                                            rowDenunciante["Nombre"] = reader.Value;
                                            break;
                                        case "Apellido":
                                            rowDenunciante["Apellido"] = reader.Value;
                                            break;
                                        //case "ID":
                                        //    rowDenunciante["Id"] = reader.Value;
                                        //    break;
                                    }

                                }
                                tblVictimas.Rows.Add(rowDenunciante);
                            }
                            break;
                        case "Victima":
                            if (reader.HasAttributes)
                            {
                                System.Data.DataRow rowVictima = tblVictimas.NewRow();
                                rowVictima["tipo"] = "V";
                                while (reader.MoveToNextAttribute())
                                {
                                    switch (reader.Name)
                                    {
                                        case "Nombre":
                                            rowVictima["Nombre"] = reader.Value;
                                            break;
                                        case "Apellido":
                                            rowVictima["Apellido"] = reader.Value;
                                            break;
                                        //case "ID":
                                        //    rowVictima["Id"] = reader.Value;
                                        //    break;
                                    }
                                }
                                tblVictimas.Rows.Add(rowVictima);
                            }
                            break;

                        case "Imputado":
                            while (reader.MoveToNextAttribute())
                            {
                                string nombre = reader.Name.ToLower();
                                string valor = reader.Value;
                                switch (nombre)
                                {
                                    case "apellido":
                                        //this.txtApellidoAutor.Text = valor;
                                        break;
                                    case "nombre":
                                        //this.txtNombreAutor.Text = valor;
                                        break;
                                    case "dni":
                                        //this.txtDniAutor.Text = valor;
                                        break;
                                }

                            }
                            break;
                        case "Delitos":
                            reader.ReadToDescendant("Delito");
                            if (reader.HasAttributes)
                            {
                                System.Data.DataRow rowDelito = tblDelitos.NewRow();
                                while (reader.MoveToNextAttribute())
                                {
                                    switch (reader.Name)
                                    {
                                        case "Descripcion":
                                            rowDelito["Descripcion"] = reader.Value;
                                            break;
                                    }
                                    tblDelitos.Rows.Add(rowDelito);
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

            catch(Exception e)
            {
                System.Web.Services.Protocols.SoapException ex; 
            }
            
            // this.pnlVictimasGral.Enabled = true;
            this.gvVictimas.DataBind();
            this.gvDelitos.DataBind();

        }

        private void HabilitarControles(bool habilitar)
        {
            Delitos miDelito = (Delitos)Session["miDelito"];
            bool esAdministrador = (Session["idGrupo"].ToString() == "1" || Session["idGrupo"].ToString() == "7");
            this.btnPasarAAutorCon.Enabled = habilitar &&  miDelito!=null && miDelito.id>-1;
            this.rblFecha.Enabled = habilitar;
            this.rblHora.Enabled = habilitar;
            this.txtBarrio.Enabled = habilitar;
            this.txtCalle.Enabled = habilitar;
            this.txtDepto.Enabled = habilitar;
            this.txtEntreCalle.Enabled = habilitar;
            this.txtFechaDesde.Enabled = habilitar;
            this.txtFechaHasta.Enabled = habilitar;
            this.txtHoraDesde.Enabled = habilitar;
            this.txtHoraHasta.Enabled = habilitar;
            this.txtLugar.Enabled = habilitar;
            this.txtNomRef.Enabled = habilitar;
            this.txtYEntreCalle.Enabled = habilitar;
            this.txtNro.Enabled = habilitar;
            this.txtPiso.Enabled = habilitar;
            this.ddlDepartamento.Enabled = habilitar;
            this.ddlLugar.Enabled = habilitar;
            this.ddlMomentoDelDia.Enabled = habilitar;
            this.ddlRubro.Enabled = habilitar;
            this.btnBuscarLocalidadH.Enabled = habilitar;
            this.btnCancelarComisariaH.Enabled = habilitar;
            this.btnCancelarComisariaH.Enabled = habilitar;
            this.btnSiguiente.Enabled = habilitar;
            this.btnTraerComisariaH.Enabled = habilitar;

        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            this.rfvIpp.IsValid = true;
            Session["miDelito"] = null;
            Session["moduloActual"] = null;
            Response.Redirect("~/Home.aspx");
        }

        protected void btnBuscarLocalidadH_Click(object sender, ImageClickEventArgs e)
        {
            this.pnlLugar.Style.Remove("display");
        }

        protected void btnTraerComisariaH_Click(object sender, ImageClickEventArgs e)
        {
            this.pnlComisariasH.Style.Remove("display");
        }

        #endregion

        protected void rblFecha_DataBound(object sender, EventArgs e)
        {
            string tipo = Request.QueryString["tipo"].Substring(1, 1);
            if (tipo == "2")
            {
                this.rblFecha.Items[1].Enabled = false;
            }
        }

        protected void rblHora_DataBound(object sender, EventArgs e)
        {
            string tipo = Request.QueryString["tipo"].Substring(1, 1);
            if (tipo == "2")
            {
                this.rblHora.Items[1].Enabled = false;
            }
        }

        protected void btnPasarAAutorCon_Click(object sender, EventArgs e)
        {
            
            
            Delitos miDelito = (Delitos)Session["miDelito"];
            miDelito.idTipoAutor = 2;
            if (DelitosManager.Save(miDelito) > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Modificación Exitosa.');", true);
                Session["miDelito"] = null;
                HabilitarControles(false);
                LimpiarControles();
                this.txtIpp.Enabled = true;
                this.txtIpp.Text = "";
                IndicarStatus();
                this.btnBuscarIpp.Text = "Buscar";
                this.txtIpp.Focus();
            }

        }

      

   
    }
}
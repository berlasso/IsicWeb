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


namespace MPBA.AutoresIgnorados.Web
{
    public partial class CargaBienesSustraidos : System.Web.UI.Page
    {
        //private static Delitos miDelito;
        //private static BienesSustraidos miBienSustraido;//lo uso para editar o dar de alta
        //private static BienesSustraidosAnimal miBienSustraidoAnimal;
        //private static BienesSustraidosOtro miBienSustraidoOtro;
        //private static Vehiculos miVehiculo;
        bool esNN;//si estoy en NN o en aprehendidos

        #region "Eventos"
        protected void Page_Load(object sender, EventArgs e)
        {
            esNN = Convert.ToBoolean(Session["esNN"]);
            if (!Page.IsPostBack)
            {
                
                switch (esNN)
                {
                    case false://autores aprehendidos
                        this.imgCartelVictimas.ImageUrl = "~/App_Images/cartelBSConocidos.png";
                        this.cartelPrincipal.InnerText = "AUTORES APREHENDIDOS";
                        //this.btnSiguiente.Width =Convert.ToUInt16(this.btnSiguiente.Width.Value * 1.25);
                        //this.btnSiguiente.Height = Convert.ToUInt16(this.btnSiguiente.Height.Value * 1.25);
                        //this.btnSiguiente.Font.Bold = true;
                        //this.btnSiguiente.Text = "Guardar";
                        this.btnSiguiente.Visible = false;
                        this.btnGuardarDelito.Visible = true;
                        //this.pnlAutor.Visible = true;
                        break;
                    case true://autores desconocidos
                        this.imgCartelVictimas.ImageUrl = "~/App_Images/cartelBsSust.png";
                        this.cartelPrincipal.InnerText = "AUTORES IGNORADOS";
                        //this.pnlAutor.Visible = false;
                        this.btnSiguiente.Visible = true;
                        this.btnGuardarDelito.Visible = false;
                        break;
                    default:
                        return;

                }
                bool esConsulta = Request.QueryString["c"].ToString() == "1" ? true : false;
                if (esConsulta)
                {
                    this.pnlBienesSustraidos.Enabled = false;
                    this.btnGuardarDelito.Enabled = false;
                }
                this.pnlGuardoBien.Style.Add("display", "none");
                LimpiarControles();
                LlenarControles();
                IndicarStatus();
            }
        }

        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            //Server.Transfer("CargaAutores.aspx");
            //GuardarDelito();
                bool esConsulta = Request.QueryString["c"].ToString() == "1" ? true : false;
                if (esConsulta)
                    Response.Redirect("CargaAutores.aspx?c=1");
                else
                    Response.Redirect("CargaAutores.aspx?c=0");
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            GuardarDelito();
            bool esConsulta = Request.QueryString["c"].ToString() == "1" ? true : false;
            
            if (esNN && esConsulta==false)
                Response.Redirect("CargaPrueba.aspx?c=0");
            else if (esNN && esConsulta)
                Response.Redirect("CargaPrueba.aspx?c=1");
        }

        protected void btnCancelarBien_Click(object sender, EventArgs e)
        {
            //this.Panel2.Style.Add("display", "none");
            //this.hfGestionBS_ModalPopupExtender.Hide();
            this.pnlBienSustraido.Style.Remove("display");
            Session["miBienSustraido"] = null;
            this.ddlBienSustraido.Enabled = true;
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session["miDelito"] = null;
            Session["moduloActual"] = null;
            Response.Redirect("~/Home.aspx");
        }

        protected void btnOkBien_Click(object sender, EventArgs e)
        {
            GuardarBien();
            this.gvBienesSustraidos.DataSource = "";
            Delitos miDelito = (Delitos)Session["miDelito"];
            this.gvBienesSustraidos.DataSource = miDelito.bienesSustraidoss.FindAll(delegate(BienesSustraidos BS) { return BS.Baja == false; }); 
            this.gvBienesSustraidos.DataBind();
            this.pnlBienSustraido.Style.Add("display", "none");
            this.hfGestionBS_ModalPopupExtender.Hide();
            Session["miBienSustraido"] = null;
            this.ddlBienSustraido.Enabled = true;
        }

        protected void gvBienesSustraidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Delitos miDelito = (Delitos)Session["miDelito"];
            List<BienesSustraidos> bienes = miDelito.bienesSustraidoss.FindAll(delegate(BienesSustraidos BS) { return BS.Baja == false; });
            Session["miBienSustraido"] = bienes[this.gvBienesSustraidos.SelectedIndex];
            BienesSustraidos miBienSustraido = (BienesSustraidos)Session["miBienSustraido"];
            NNClaseBienSustraido tipoBien = NNClaseBienSustraidoManager.GetItem(miBienSustraido.idClaseBienSustraido);
            switch (tipoBien.tipo.Trim().ToUpper())
            {
                case "ANIMAL": //Animales
                    Session["miBienSustraidoAnimal"]= miBienSustraido.bienesSustraidosAnimals[0];
                    break;
                case "VEHICULO": //Vehículos
                    Session["miVehiculo"] = miBienSustraido.vehiculoss.Find(delegate(Vehiculos Veh) { return Veh.idClaseVinculoVehiculo == 2; });
                    break;
                case "ARMA": //Vehículos
                    Session["miBienSustraidoArma"] = miBienSustraido.bienSustraidoArmas[0];
                    break;
                case "TELEFONO":
                    Session["miBienSustraidoTelefono"] = miBienSustraido.bienSustraidoTelefonos[0];
                    break;
                case "DINERO":
                    Session["miBienSustraidoDinero"] = miBienSustraido.bienSustraidoDineros[0];
                    break;
                case "CHEQUE":
                    Session["miBienSustraidoCheque"] = miBienSustraido.bienSustraidoCheques[0];
                    break;
                default:
                    Session["miBienSustraidoOtro"] = miBienSustraido.bienesSustraidosOtros[0];
                    break;
            }
            LimpiarControlesPanelBien();
            LlenarControlesPanelBien();
            this.pnlBienSustraido.DataBind();
            //ddlBienSustraido.Enabled = true;
            this.hfGestionBS_ModalPopupExtender.Show();
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
            this.txtMontoEstimadoBienes.Text = "";
            this.pnlBienSustraido.Style.Add("display", "none");
        }

        private void LlenarControles()
        {
            Delitos miDelito = (Delitos)Session["miDelito"];
            this.txtMontoEstimadoBienes.Text = Convert.ToString(miDelito.MontoTotalEstimadoBienSustraido);
            BienesSustraidosList bs = miDelito.bienesSustraidoss;
            //for (int i = 0; i <= bs.Count - 1; i++)
            //{
            //    bs[i]=BienesSustraidosManager.GetItem(bs[i].id, true);
            //}
            this.gvBienesSustraidos.DataSource = bs.FindAll(delegate(BienesSustraidos BS) { return BS.Baja == false; });
            this.gvBienesSustraidos.DataBind();
            Session["miBienSustraido"]= null;
        }

        private void GuardarBien()
        {
            NNClaseBienSustraido ClaseBien = NNClaseBienSustraidoManager.GetItem(Convert.ToInt32(this.ddlBienSustraido.SelectedValue));
            BienesSustraidos miBienSustraido = (BienesSustraidos)Session["miBienSustraido"];
            BienesSustraidosAnimal miBienSustraidoAnimal = (BienesSustraidosAnimal)Session["miBienSustraidoAnimal"];
            BienesSustraidosOtro miBienSustraidoOtro = (BienesSustraidosOtro)Session["miBienSustraidoOtro"];
            Vehiculos miVehiculo = (Vehiculos)Session["miVehiculo"];
            BienSustraidoArma miBienSustraidoArma = (BienSustraidoArma)Session["miBienSustraidoArma"];
            BienSustraidoCheque miBienSustraidoCheque = (BienSustraidoCheque)Session["miBienSustraidoCheque"];
            BienSustraidoDinero miBienSustraidoDinero = (BienSustraidoDinero)Session["miBienSustraidoDinero"];
            BienSustraidoTelefono miBienSustraidoTelefono = (BienSustraidoTelefono)Session["miBienSustraidoTelefono"];
            bool esNuevoBien = (miBienSustraido == null);//si es nulo estoy dando de alta
            if (esNuevoBien)
            {
                miBienSustraido = new BienesSustraidos();
                miBienSustraido.id = -1;
                switch (ClaseBien.tipo.Trim().ToUpper())
                {
                    case "VEHICULO":
                        miVehiculo = new Vehiculos();
                        miVehiculo.id = -1;
                        break;
                    case "ANIMAL":
                        miBienSustraidoAnimal = new BienesSustraidosAnimal();
                        miBienSustraidoAnimal.id = -1;
                        break;
                    case "ARMA":
                        miBienSustraidoArma = new BienSustraidoArma();
                        miBienSustraidoArma.id = -1;
                        break;
                    case "DINERO":
                        miBienSustraidoDinero = new BienSustraidoDinero();
                        miBienSustraidoDinero.id = -1;
                        break;
                    case "CHEQUE":
                        miBienSustraidoCheque = new BienSustraidoCheque();
                        miBienSustraidoCheque.id = -1;
                        break;
                    case "TELEFONO":
                        miBienSustraidoTelefono = new BienSustraidoTelefono();
                        miBienSustraidoTelefono.id = -1;
                        break;
                    default:
                        miBienSustraidoOtro = new BienesSustraidosOtro();
                        miBienSustraidoOtro.id = -1;
                        break;
                }

            }
            miBienSustraido.idClaseBienSustraido = Convert.ToInt16(this.ddlBienSustraido.SelectedValue);
            Delitos miDelito = (Delitos)Session["miDelito"];
            miBienSustraido.idCausa = miDelito.idCausa;
            miBienSustraido.FechaUltimaModificacion = DateTime.Now;
            miBienSustraido.idUsuarioUltimaModificacion = Session["miUsuario"].ToString();
                switch (ClaseBien.tipo.Trim().ToUpper())
                {
                    case "VEHICULO":
                        if (miVehiculo != null)
                        {
                            miVehiculo.idCausa = miDelito.idCausa;
                            miVehiculo.idClaseVinculoVehiculo = 2;
                            miVehiculo.idMarcaVehiculo = Convert.ToInt16(this.ddlmarcaVehiculo.SelectedValue);
                            miVehiculo.idModeloVehiculo = Convert.ToInt16(this.ddlModeloVehiculo.SelectedValue);
                            miVehiculo.Dominio = this.txtDominio.Text.Trim();
                            miVehiculo.NumeroChasis = this.txtNroChasis.Text.Trim();
                            miVehiculo.NumeroMotor = this.txtNroMotor.Text.Trim();
                            miVehiculo.idColorVehiculo = Convert.ToInt16(this.ddlColorVehiculo.SelectedValue);
                            miVehiculo.anio = this.txtAnio.Text.Trim();
                            miVehiculo.GNC = Convert.ToInt16(this.ddlTieneGNC.SelectedValue);
                            miVehiculo.IdentificacionGNC = this.txtIdentificacionGNC.Text.Trim();
                            miVehiculo.idClaseVidrioVehiculo = Convert.ToInt16(this.ddlClaseVidrio.SelectedValue);
                            miVehiculo.FechaUltimaModificacion = DateTime.Now;
                            miVehiculo.idUsuarioUltimaModificacion = Session["miUsuario"].ToString();
                            miVehiculo.Baja = false;
                            miBienSustraido.vehiculoss.Add(miVehiculo);
                        }
                        break;
                    case "ANIMAL":
                        if (miBienSustraidoAnimal != null)
                        {
                            miBienSustraidoAnimal.idClaseGanado = Convert.ToInt16(this.ddlTipoGanado.SelectedValue);
                            miBienSustraidoAnimal.Marca = this.txtMarcaGanado.Text.Trim();
                            if (this.txtCantidadGanado.Text.Trim() != "")
                            {
                                miBienSustraidoAnimal.Cantidad = Convert.ToInt32(this.txtCantidadGanado.Text.Trim());
                            }
                            miBienSustraidoAnimal.FechaUltimaModificacion = DateTime.Now;
                            miBienSustraidoAnimal.idUsuarioUltimaModificacion = Session["miUsuario"].ToString();
                            miBienSustraidoAnimal.Baja = false;
                            miBienSustraido.bienesSustraidosAnimals.Add(miBienSustraidoAnimal);
                        }
                       
                    break;
                    case "NUMERABLE":
                    if (miBienSustraidoOtro != null)
                    {
                        miBienSustraidoOtro.Marca = Convert.ToString(this.txtMarca.Text);
                        miBienSustraidoOtro.NroSerie = this.txtNroSerie.Text.ToString().Trim();
                        if (txtCantidad.Text.Trim() != "")
                        {
                            miBienSustraidoOtro.Cantidad = Convert.ToInt32(this.txtCantidad.Text);
                        }
                        miBienSustraidoOtro.FechaUltimaModificacion = DateTime.Now;
                        miBienSustraidoOtro.idUsuarioUltimaModificacion = Session["miUsuario"].ToString();
                        miBienSustraidoOtro.Baja = false;
                        miBienSustraido.bienesSustraidosOtros.Add(miBienSustraidoOtro);
                    }
                    break;
                    case "DINERO":
                    if (miBienSustraidoDinero != null)
                    {
                        miBienSustraidoDinero.idTipoMoneda = Convert.ToInt16(this.ddlMoneda.SelectedValue);
                        miBienSustraidoDinero.descripcionMoneda = Convert.ToString(this.txtTipoMonedaExtranjera.Text);
                        float monto = 0;
                        float.TryParse(this.txtMontoSustraido.Text.Trim(), out monto);
                        miBienSustraidoDinero.monto = monto;
                        miBienSustraidoDinero.FechaUltimaModificacion = DateTime.Now;
                        miBienSustraidoDinero.idUsuarioUltimaModificacion = Session["miUsuario"].ToString();
                        miBienSustraidoDinero.Baja = false;
                        miBienSustraido.bienSustraidoDineros.Add(miBienSustraidoDinero);
                    }
                          break;
                    case "CHEQUE":
                          {
                              miBienSustraidoCheque.Banco = Convert.ToString(this.txtBanco.Text);
                              miBienSustraidoCheque.descripcionMoneda = Convert.ToString(this.txtTipoMonedaExtranjeraCh.Text);
                              miBienSustraidoCheque.idTipoMoneda = Convert.ToInt16(this.ddlMonedaChequeSustraido.SelectedValue);
                              float monto = 0;
                              float.TryParse(this.txtMontoChequeSustraido.Text.Trim(), out monto);
                              miBienSustraidoCheque.monto = monto;
                              miBienSustraidoCheque.NroSerie = Convert.ToString(this.txtNroSerieCheque.Text);
                              miBienSustraidoCheque.FechaUltimaModificacion = DateTime.Now;
                              miBienSustraidoCheque.idUsuarioUltimaModificacion = Session["miUsuario"].ToString();
                              miBienSustraidoCheque.Baja = false;
                              miBienSustraido.bienSustraidoCheques.Add(miBienSustraidoCheque);
                          }
                          break;
                    case "ARMA":
                          {
                              miBienSustraidoArma.clase_tipo = Convert.ToInt16(this.ddlTipoArmaFuego.SelectedValue);
                              miBienSustraidoArma.diametro_calibre = Convert.ToInt16(this.ddlDiametro.SelectedValue);
                              miBienSustraidoArma.Marca = Convert.ToString(this.txtMarcaArma.Text);
                              miBienSustraidoArma.NroSerie = Convert.ToString(this.txtNroSerieArma.Text);
                              miBienSustraidoArma.FechaUltimaModificacion = DateTime.Now;
                              miBienSustraidoArma.idUsuarioUltimaModificacion = Session["miUsuario"].ToString();
                              miBienSustraidoArma.Baja = false;
                              miBienSustraido.bienSustraidoArmas.Add(miBienSustraidoArma);
                          }
                          break;
                    
                    case "TELEFONO":
                          {
                              miBienSustraidoTelefono.IMEI = this.txtIMEI.Text.Trim();
                              miBienSustraidoTelefono.Marca = this.txtMarcatel.Text.Trim();
                              miBienSustraidoTelefono.Nro = this.txtNroTel.Text.Trim();
                              miBienSustraidoTelefono.NroSerie = this.txtNroSerieTel.Text.Trim();
                              miBienSustraidoTelefono.FechaUltimaModificacion = DateTime.Now;
                              miBienSustraidoTelefono.idUsuarioUltimaModificacion = Session["miUsuario"].ToString();
                              miBienSustraidoTelefono.Baja = false;
                              miBienSustraido.bienSustraidoTelefonos.Add(miBienSustraidoTelefono);
                          }
                          break;
                    default:
                    if (miBienSustraidoOtro != null)
                    {
                        //aunque no tenga datos de nro de serie cantidad y marca se graba en BienesSustraidosOtros
                        miBienSustraidoOtro.Marca = null;
                        miBienSustraidoOtro.NroSerie = null;
                        miBienSustraidoOtro.Cantidad = 0;
                        miBienSustraidoOtro.FechaUltimaModificacion = DateTime.Now;
                        miBienSustraidoOtro.idUsuarioUltimaModificacion = Session["miUsuario"].ToString();
                        miBienSustraido.bienesSustraidosOtros.Add(miBienSustraidoOtro);
                    }
                    break;
                }
            if (esNuevoBien)
            {
             
             miDelito.bienesSustraidoss.Add(miBienSustraido);
             Session["miBienSustraido"] = null;

            }
        }

        /// <summary>
        /// Para Carga o editar datos del bien: Llena los controles del panel de datos del bien
        /// </summary>
        private void LlenarControlesPanelBien()
        {
            BienesSustraidos miBienSustraido = (BienesSustraidos)Session["miBienSustraido"];
            BienesSustraidosAnimal miBienSustraidoAnimal = (BienesSustraidosAnimal)Session["miBienSustraidoAnimal"];
            BienesSustraidosOtro miBienSustraidoOtro = (BienesSustraidosOtro)Session["miBienSustraidoOtro"];
            Vehiculos miVehiculo = (Vehiculos)Session["miVehiculo"];
            BienSustraidoArma miBienSustraidoArma = (BienSustraidoArma)Session["miBienSustraidoArma"];
            BienSustraidoCheque miBienSustraidoCheque = (BienSustraidoCheque)Session["MiBienSustraidoCheque"];
            BienSustraidoDinero miBienSustraidoDinero = (BienSustraidoDinero)Session["MiBienSustraidoDinero"];
            BienSustraidoTelefono miBienSustraidoTelefono = (BienSustraidoTelefono)Session["MiBienSustraidoTelefono"];
            this.ddlBienSustraido.SelectedValue = miBienSustraido.idClaseBienSustraido.ToString();
            NNClaseBienSustraido claseBien = NNClaseBienSustraidoManager.GetItem(miBienSustraido.idClaseBienSustraido);
            switch (claseBien.tipo.Trim().ToUpper())
            {
                case "VEHICULO":
                    if (miVehiculo != null)
                    {
                        this.ddlBienSustraido.Enabled = false;
                        this.ddlmarcaVehiculo.SelectedValue = miVehiculo.idMarcaVehiculo.ToString();
                        this.ddlModeloVehiculo.DataBind();
                        this.ddlModeloVehiculo.SelectedValue = miVehiculo.idModeloVehiculo.ToString();
                        if (miVehiculo.Dominio != null)
                        {
                            this.txtDominio.Text = miVehiculo.Dominio.ToString().Trim();
                        }
                        else
                        {
                            this.txtDominio.Text = "";
                        }
                        if (miVehiculo.NumeroChasis != null)
                        {
                            this.txtNroChasis.Text = miVehiculo.NumeroChasis.ToString().Trim();
                        }
                        else
                        {
                            this.txtNroChasis.Text = "";
                        }
                        if (miVehiculo.NumeroMotor != null)
                        {
                            this.txtNroMotor.Text = miVehiculo.NumeroMotor.ToString().Trim();
                        }
                        else
                        {
                            this.txtNroMotor.Text = "";
                        }

                        this.ddlColorVehiculo.SelectedValue = miVehiculo.idColorVehiculo.ToString();
                        if (miVehiculo.anio != null)
                        {
                            this.txtAnio.Text = miVehiculo.anio.ToString().Trim();
                        }
                        else
                        {
                            this.txtAnio.Text = "";
                        }
                        this.ddlTieneGNC.SelectedValue = miVehiculo.GNC.ToString();
                        if (miVehiculo.IdentificacionGNC!= null)
                        {
                            this.txtIdentificacionGNC.Text = miVehiculo.IdentificacionGNC.ToString().Trim();
                        }
                        else
                        {
                            this.txtIdentificacionGNC.Text = "";
                        }
                        this.ddlClaseVidrio.SelectedValue = miVehiculo.idClaseVidrioVehiculo.ToString();
                    }
                    break;
                case "ANIMAL":
                    this.ddlBienSustraido.Enabled = false;
                    this.ddlTipoGanado.SelectedValue = miBienSustraidoAnimal.idClaseGanado.ToString();
                    if (miBienSustraidoAnimal.Marca != null)
                    {
                        this.txtMarcaGanado.Text = miBienSustraidoAnimal.Marca.ToString().Trim();
                    }
                    else
                    {
                        this.txtMarcaGanado.Text = "";
                    }
                    this.txtCantidadGanado.Text = miBienSustraidoAnimal.Cantidad.ToString().Trim();
                    break;
                case "NUMERABLE":
                    if (miBienSustraidoOtro != null)
                    {
                        this.ddlBienSustraido.Enabled = false;
                        this.txtCantidad.Text = miBienSustraidoOtro.Cantidad.ToString().Trim();
                        if (miBienSustraidoOtro.Marca != null)
                        {
                            this.txtMarca.Text = miBienSustraidoOtro.Marca.Trim();
                        }
                        else
                        {
                            this.txtMarca.Text = "";
                        }
                        if (miBienSustraidoOtro.NroSerie != null)
                        {
                            this.txtNroSerie.Text = miBienSustraidoOtro.NroSerie.Trim();
                        }
                        else
                        {
                            this.txtNroSerie.Text = "";
                        }
                    }
                    break;
                case "CHEQUE":
                    if (miBienSustraidoCheque != null)
                    {
                        this.ddlBienSustraido.Enabled = false;
                        if (miBienSustraidoCheque.monto != null)
                            this.txtMontoChequeSustraido.Text = miBienSustraidoCheque.monto.ToString();
                        else
                            this.txtMontoChequeSustraido.Text = "";
                        if (miBienSustraidoCheque.idTipoMoneda != null)
                            this.ddlMonedaChequeSustraido.SelectedValue = miBienSustraidoCheque.idTipoMoneda.ToString();
                        else
                            this.ddlMonedaChequeSustraido.SelectedValue = "0";
                        if (miBienSustraidoCheque.descripcionMoneda != null)
                            this.txtTipoMonedaExtranjeraCh.Text = miBienSustraidoCheque.descripcionMoneda.ToString();
                        else
                            this.txtTipoMonedaExtranjeraCh.Text = "";
                        if (miBienSustraidoCheque.Banco != null)
                            this.txtBanco.Text = miBienSustraidoCheque.Banco.ToString();
                        else
                            this.txtBanco.Text = "";
                        if (miBienSustraidoCheque.NroSerie != null)
                            this.txtNroSerieCheque.Text = miBienSustraidoCheque.NroSerie.ToString();
                        else
                            this.txtNroSerieCheque.Text = "";

                    }
                    break;
                case "DINERO":
                    if (miBienSustraidoDinero != null)
                    {
                        this.ddlBienSustraido.Enabled = false;
                        if (miBienSustraidoDinero.monto != null)
                            this.txtMontoSustraido.Text = miBienSustraidoDinero.monto.ToString();
                        else
                            this.txtMontoSustraido.Text = "";
                        if (miBienSustraidoDinero.idTipoMoneda != null)
                            this.ddlMoneda.SelectedValue = miBienSustraidoDinero.idTipoMoneda.ToString();
                        else
                            this.ddlMoneda.SelectedValue = "0";
                        if (miBienSustraidoDinero.descripcionMoneda != null)
                            this.txtTipoMonedaExtranjera.Text = miBienSustraidoDinero.descripcionMoneda.ToString();
                        else
                            this.txtTipoMonedaExtranjera.Text = "";
                    }
                    break;
                case "TELEFONO":
                    if (miBienSustraidoTelefono != null)
                    {
                       
                        this.ddlBienSustraido.Enabled = false;
                        if (miBienSustraidoTelefono.Nro != null)
                            this.txtNroTel.Text = miBienSustraidoTelefono.Nro.ToString();
                        else
                            this.txtNroTel.Text = "";
                        if (miBienSustraidoTelefono.Marca != null)
                            this.txtMarcatel.Text = miBienSustraidoTelefono.Marca.ToString();
                        else
                            this.txtMarcatel.Text = "";
                        if (miBienSustraidoTelefono.NroSerie != null)
                            this.txtNroSerieTel.Text = miBienSustraidoTelefono.NroSerie.ToString();
                        else
                            this.txtNroSerieTel.Text = "";
                        if (miBienSustraidoTelefono.IMEI != null)
                            this.txtIMEI.Text = miBienSustraidoTelefono.IMEI.ToString();
                        else
                            this.txtIMEI.Text = "";
                    
                    }
                    break;
                case "ARMA":
                    if (miBienSustraidoArma != null)
                    {
                        
                        this.ddlBienSustraido.Enabled = false;
                        if (miBienSustraidoArma.Marca != null)
                            this.txtMarcaArma.Text = miBienSustraidoArma.Marca.ToString();
                        else
                            this.txtMarcaArma.Text = "";
                        if (miBienSustraidoArma.NroSerie != null)
                            this.txtNroSerieArma.Text = miBienSustraidoArma.NroSerie.ToString();
                        else
                            this.txtNroSerieArma.Text = "";
                        if (miBienSustraidoArma.clase_tipo != null)
                            this.ddlTipoArmaFuego.SelectedValue = miBienSustraidoArma.clase_tipo.ToString();
                        else
                            this.ddlTipoArmaFuego.SelectedValue = "0";
                        if (miBienSustraidoArma.diametro_calibre != null)
                            this.ddlDiametro.SelectedValue = miBienSustraidoArma.diametro_calibre.ToString();
                        else
                            this.ddlDiametro.SelectedValue = "0";
                    }
                    
                    break;

                    default:
                        this.ddlBienSustraido.Enabled = false;
                        break;
            }

            ActualizarPanel(claseBien.tipo.Trim().ToUpper());
        }

        protected void gvBienesSustraidos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Delitos miDelito = (Delitos)Session["miDelito"];
            e.Cancel = true;
            List<BienesSustraidos> bienes = miDelito.bienesSustraidoss.FindAll(delegate(BienesSustraidos BS) { return BS.Baja == false; });
            BienesSustraidos bien = bienes[e.RowIndex];
            BienesSustraidosAnimal miBienSustraidoAnimal = (BienesSustraidosAnimal)Session["miBienSustraidoAnimal"];
            BienesSustraidosOtro miBienSustraidoOtro = (BienesSustraidosOtro)Session["miBienSustraidoOtro"];
            Vehiculos miVehiculo = (Vehiculos)Session["miVehiculo"];
            if (bien.id == -1)
            {
                for (int i = 0; i < miDelito.bienesSustraidoss.Count; i++)
                {
                    if (bien.Equals(miDelito.bienesSustraidoss[i]))
                    {
                        BienesSustraidos bi = miDelito.bienesSustraidoss[i];
                        miDelito.bienesSustraidoss.Remove(bi);
                    }
                }
            }
            else
            {
                bien.Baja = true;
            
                switch (bien.idClaseBienSustraido)
                {
                    case 1: //Animales
                        miBienSustraidoAnimal = BienesSustraidosAnimalManager.GetItemByBienSustraido(bien.id);
                        if (miBienSustraidoAnimal != null)
                        {
                            miBienSustraidoAnimal.Baja = true;
                            bien.bienesSustraidosAnimals.Add(miBienSustraidoAnimal);
                        }
                        break;
                    case 34: //Vehículos
                        miVehiculo = VehiculosManager.GetItemByBienSustraido(bien.id);
                        if (miVehiculo != null)
                        {
                            miVehiculo.Baja = true;
                            bien.vehiculoss.Add(miVehiculo);
                        }
                        break;
                    case 3: //Arma
                        BienSustraidoArma miArma = BienSustraidoArmaManager.GetItemByBienSustraido(bien.id);
                        if (miArma != null)
                        {
                            miArma.Baja = true;
                            bien.bienSustraidoArmas.Add(miArma);
                        }
                        break;
                    case 10: //Celular
                        BienSustraidoTelefono miTelefono = BienSustraidoTelefonoManager.GetItemByBienSustraido(bien.id);
                        if (miTelefono != null)
                        {
                            miTelefono.Baja = true;
                            bien.bienSustraidoTelefonos.Add(miTelefono);
                        }
                        break;
                    case 12: //Cheque
                        BienSustraidoCheque miCheque = BienSustraidoChequeManager.GetItemByBienSustraido(bien.id);
                        if (miCheque != null)
                        {
                            miCheque.Baja = true;
                            bien.bienSustraidoCheques.Add(miCheque);
                        }
                        break;
                    case 13: //Dinero
                        BienSustraidoDinero miDinero = BienSustraidoDineroManager.GetItemByBienSustraido(bien.id);
                        if (miDinero != null)
                        {
                            miDinero.Baja = true;
                            bien.bienSustraidoDineros.Add(miDinero);
                        }
                        break;
                    default:
                        miBienSustraidoOtro = BienesSustraidosOtroManager.GetItemByBienSustraido(bien.id);
                        if (miBienSustraidoOtro != null)
                        {
                            miBienSustraidoOtro.Baja = true;
                            bien.bienesSustraidosOtros.Add(miBienSustraidoOtro);
                        }
                        break;
                }
            }
            this.gvBienesSustraidos.DataSource = null;
            this.gvBienesSustraidos.DataSource = miDelito.bienesSustraidoss.FindAll(delegate(BienesSustraidos BS) { return BS.Baja == false; });
            this.gvBienesSustraidos.DataBind();
        }

        private void GuardarDelito()
        {
            float monto = 0;
            float.TryParse(this.txtMontoEstimadoBienes.Text.Trim(), out monto);
            Delitos miDelito = (Delitos)Session["miDelito"];
            miDelito.MontoTotalEstimadoBienSustraido = monto;
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

        protected void btnNuevo_Click(object sender, EventArgs e)
        {

            LimpiarControlesPanelBien();
            ddlBienSustraido.Enabled = true;
            ddlBienSustraido.SelectedValue = Convert.ToString(0);
            ActualizarPanel("INDETERMINADA");
            Session["miBienSustraido"] = null;
            this.pnlBienSustraido.DataBind();
            this.hfGestionBS_ModalPopupExtender.Show();
        }
        private void LimpiarControlesPanelBien()
        {
            this.ddlBienSustraido.SelectedValue = Convert.ToString(0);
            this.txtMarca.Text = "";
            this.txtCantidad.Text = "";
            this.txtNroSerie.Text = "";
            this.ddlTipoGanado.SelectedValue = Convert.ToString(0);
            this.txtCantidadGanado.Text = "";
            this.txtMarcaGanado.Text = "";
            this.ddlmarcaVehiculo.SelectedValue = Convert.ToString(0);
            this.ddlModeloVehiculo.SelectedValue = Convert.ToString(0);
            this.txtNroChasis.Text = "";
            this.txtNroMotor.Text = "";
            this.txtNroSerie.Text = "";
            this.txtDominio.Text = "";
            this.ddlColorVehiculo.SelectedValue = Convert.ToString(0); 
            this.txtAnio.Text = "";
            this.ddlTieneGNC.SelectedValue = Convert.ToString(0); 
            this.txtIdentificacionGNC.Text = "";
            this.ddlClaseVidrio.SelectedValue = Convert.ToString(0); 
            this.txtMontoChequeSustraido.Text = "";
            this.ddlMonedaChequeSustraido.SelectedValue = "0";
            this.txtTipoMonedaExtranjeraCh.Text = "";
            this.txtBanco.Text = "";
            this.txtNroSerieCheque.Text = "";
            this.txtMontoSustraido.Text = "";
            this.ddlMoneda.SelectedValue = "0";
            this.txtTipoMonedaExtranjera.Text = "";
            this.txtNroTel.Text = "";
            this.txtMarcatel.Text = "";
            this.txtNroSerieTel.Text = "";
            this.txtIMEI.Text = "";
            this.txtMarcaArma.Text = "";
            this.txtNroSerieArma.Text = "";
            this.ddlTipoArmaFuego.SelectedValue = "0";
            this.ddlDiametro.SelectedValue = "0";
                    
        }

        protected void ddlBienSustraido_SelectedIndexChanged(object sender, EventArgs e)
        {
            NNClaseBienSustraido claseBien = NNClaseBienSustraidoManager.GetItem(Convert.ToInt32(this.ddlBienSustraido.SelectedValue));
            ActualizarPanel(claseBien.tipo.Trim().ToUpper());

        }
        protected void ActualizarPanel(string strTipoBien)
        {
            switch (strTipoBien)
            {
                case "VEHICULO":
                    pnlVehiculo.Visible = true;
                    pnlBienAnimal.Visible = false;
                    pnlOtroBien.Visible = false;
                    pnlArma.Visible = false;
                    pnlCheque.Visible = false;
                    pnlDinero.Visible = false;
                    pnlTelefono.Visible = false;
                    break;
                case "ANIMAL":
                    pnlVehiculo.Visible = false;
                    pnlBienAnimal.Visible = true;
                    pnlOtroBien.Visible = false;
                    pnlArma.Visible = false;
                    pnlCheque.Visible = false;
                    pnlDinero.Visible = false;
                    pnlTelefono.Visible = false;
                    break;
                case "NUMERABLE":
                    pnlVehiculo.Visible = false;
                    pnlBienAnimal.Visible = false;
                    pnlOtroBien.Visible = true;
                    pnlArma.Visible = false;
                    pnlCheque.Visible = false;
                    pnlDinero.Visible = false;
                    pnlTelefono.Visible = false;
                    break;
                case "CHEQUE":
                    pnlVehiculo.Visible = false;
                    pnlBienAnimal.Visible = false;
                    pnlOtroBien.Visible = false;
                    pnlArma.Visible = false;
                    pnlCheque.Visible = true;
                    pnlDinero.Visible = false;
                    pnlTelefono.Visible = false;
                    break;
                case "DINERO":
                    pnlVehiculo.Visible = false;
                    pnlBienAnimal.Visible = false;
                    pnlOtroBien.Visible = false;
                    pnlArma.Visible = false;
                    pnlCheque.Visible = false;
                    pnlDinero.Visible = true;
                    pnlTelefono.Visible = false;
                    break;
                case "ARMA":
                    pnlVehiculo.Visible = false;
                    pnlBienAnimal.Visible = false;
                    pnlOtroBien.Visible = false;
                    pnlArma.Visible = true;
                    pnlCheque.Visible = false;
                    pnlDinero.Visible = false;
                    pnlTelefono.Visible = false;
                    break;
                case "TELEFONO":
                    pnlVehiculo.Visible = false;
                    pnlBienAnimal.Visible = false;
                    pnlOtroBien.Visible = false;
                    pnlArma.Visible = false;
                    pnlCheque.Visible = false;
                    pnlDinero.Visible = false;
                    pnlTelefono.Visible = true;
                    break;
                default:
                    pnlVehiculo.Visible = false;
                    pnlBienAnimal.Visible = false;
                    pnlOtroBien.Visible = false;
                    pnlArma.Visible = false;
                    pnlCheque.Visible = false;
                    pnlDinero.Visible = false;
                    pnlTelefono.Visible = false;
                    break;
            }
        }

    

        protected void gvBienesSustraidos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gvVehiculo = (GridView)e.Row.Cells[1].FindControl("gvBSVehiculos");
                GridView gvAnimal = (GridView)e.Row.Cells[1].FindControl("gvBSAnimales");
                GridView gvOtro = (GridView)e.Row.Cells[1].FindControl("gvBSOtros");
                GridView gvTelefono = (GridView)e.Row.Cells[1].FindControl("gvBSTelefono");
                GridView gvArma = (GridView)e.Row.Cells[1].FindControl("gvBSArma");
                GridView gvDinero = (GridView)e.Row.Cells[1].FindControl("gvBSDinero");
                GridView gvCheque = (GridView)e.Row.Cells[1].FindControl("gvBSCheque");
                BienesSustraidos bs = (BienesSustraidos)e.Row.DataItem;
                NNClaseBienSustraido claseBien = NNClaseBienSustraidoManager.GetItem(bs.idClaseBienSustraido);
                if (bs.vehiculoss.Count>0)
                {
                    VehiculosList vl = new VehiculosList();
                    vl.Add(bs.vehiculoss[0]);
                    gvVehiculo.DataSource = "";
                    gvAnimal.DataSource = "";
                    gvOtro.DataSource = "";
                    gvTelefono.DataSource = "";
                    gvArma.DataSource = "";
                    gvDinero.DataSource = "";
                    gvCheque.DataSource = "";
                    gvVehiculo.DataSource = vl;
                    gvVehiculo.DataBind();
                    gvAnimal.DataBind();
                    gvOtro.DataBind();
                    gvVehiculo.DataBind();
                    gvTelefono.DataBind();
                    gvArma.DataBind();
                    gvDinero.DataBind();
                    gvCheque.DataBind();
                    return;
                }
                if (bs.bienesSustraidosAnimals.Count>0)
                {
                    BienesSustraidosAnimalList al = new BienesSustraidosAnimalList();
                    al.Add(bs.bienesSustraidosAnimals[0]);
                    gvAnimal.DataSource = "";
                    gvVehiculo.DataSource = "";
                    gvOtro.DataSource = "";
                    gvTelefono.DataSource = "";
                    gvArma.DataSource = "";
                    gvDinero.DataSource = "";
                    gvCheque.DataSource = "";
                    gvAnimal.DataSource = al;
                    gvAnimal.DataBind();
                    gvOtro.DataBind();
                    gvVehiculo.DataBind();
                    gvTelefono.DataBind();
                    gvArma.DataBind();
                    gvDinero.DataBind();
                    gvCheque.DataBind();
                    return;
                }
                if (bs.bienesSustraidosOtros.Count>0 & claseBien.tipo.Trim().ToUpper() == "NUMERABLE")
                {
                    BienesSustraidosOtroList ol = new BienesSustraidosOtroList();
                    ol.Add(bs.bienesSustraidosOtros[0]);
                    gvOtro.DataSource = "";
                    gvVehiculo.DataSource = "";
                    gvAnimal.DataSource = "";
                    gvTelefono.DataSource = "";
                    gvArma.DataSource = "";
                    gvDinero.DataSource = "";
                    gvCheque.DataSource = "";
                    gvOtro.DataSource = ol;
                    gvOtro.DataBind();
                    gvAnimal.DataBind();
                    gvVehiculo.DataBind();
                    gvTelefono.DataBind();
                    gvArma.DataBind();
                    gvDinero.DataBind();
                    gvCheque.DataBind();
                    return;
                }
                if (bs.bienSustraidoTelefonos.Count > 0)
                {
                    BienSustraidoTelefonoList tl = new BienSustraidoTelefonoList();
                    tl.Add(bs.bienSustraidoTelefonos[0]);
                    gvVehiculo.DataSource = "";
                    gvAnimal.DataSource = "";
                    gvOtro.DataSource = "";
                    gvTelefono.DataSource = "";
                    gvArma.DataSource = "";
                    gvDinero.DataSource = "";
                    gvCheque.DataSource = "";
                    gvTelefono.DataSource = tl;
                    gvVehiculo.DataBind();
                    gvAnimal.DataBind();
                    gvOtro.DataBind();
                    gvTelefono.DataBind();
                    gvArma.DataBind();
                    gvDinero.DataBind();
                    gvCheque.DataBind();
                    return;
                }
                if (bs.bienSustraidoDineros.Count > 0)
                {
                    BienSustraidoDineroList dl = new BienSustraidoDineroList();
                    dl.Add(bs.bienSustraidoDineros[0]);
                    gvVehiculo.DataSource = "";
                    gvAnimal.DataSource = "";
                    gvOtro.DataSource = "";
                    gvTelefono.DataSource = "";
                    gvArma.DataSource = "";
                    gvDinero.DataSource = "";
                    gvCheque.DataSource = "";
                    gvDinero.DataSource = dl;
                    gvVehiculo.DataBind();
                    gvAnimal.DataBind();
                    gvOtro.DataBind();
                    gvTelefono.DataBind();
                    gvArma.DataBind();
                    gvDinero.DataBind();
                    gvCheque.DataBind();
                    return;
                    
                }
                if (bs.bienSustraidoCheques.Count > 0)
                {
                    BienSustraidoChequeList chl = new BienSustraidoChequeList();
                    chl.Add(bs.bienSustraidoCheques[0]);
                    gvVehiculo.DataSource = "";
                    gvAnimal.DataSource = "";
                    gvOtro.DataSource = "";
                    gvTelefono.DataSource = "";
                    gvArma.DataSource = "";
                    gvDinero.DataSource = "";
                    gvCheque.DataSource = "";
                    gvCheque.DataSource = chl;
                    gvVehiculo.DataBind();
                    gvAnimal.DataBind();
                    gvOtro.DataBind();
                    gvTelefono.DataBind();
                    gvArma.DataBind();
                    gvDinero.DataBind();
                    gvCheque.DataBind();
                    return;
                  
                }
                if (bs.bienSustraidoArmas.Count > 0)
                {
                    BienSustraidoArmaList al = new BienSustraidoArmaList();
                    al.Add(bs.bienSustraidoArmas[0]);
                    gvVehiculo.DataSource = "";
                    gvAnimal.DataSource = "";
                    gvOtro.DataSource = "";
                    gvTelefono.DataSource = "";
                    gvArma.DataSource = "";
                    gvDinero.DataSource = "";
                    gvCheque.DataSource = "";
                    gvArma.DataSource = al;
                    gvVehiculo.DataBind();
                    gvAnimal.DataBind();
                    gvOtro.DataBind();
                    gvTelefono.DataBind();
                    gvArma.DataBind();
                    gvDinero.DataBind();
                    gvCheque.DataBind();
                    return;
                   
                }

            }
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
                this.pnlGuardoBien.Style.Remove("display");
                this.btnGuardarDelito_ModalPopupExtender.Show();
            }
        }

        protected void btnAceptarCartelExito_Click(object sender, EventArgs e)
        {
            string tipo = ((Delitos)Session["miDelito"]).idClaseDelito.ToString();
            Session["miDelito"] = null;
            string esConsulta = Request.QueryString["c"].ToString();
            Response.Redirect("CargaVictimas.aspx?tipo=2" + tipo + "&status=1" + "&c=" + esConsulta);
        }

      

     

     

      

    }
}

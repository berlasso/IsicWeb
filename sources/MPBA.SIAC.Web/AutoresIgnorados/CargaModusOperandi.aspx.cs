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
    public partial class CargaModusOperandi : System.Web.UI.Page
    {
        //private static Delitos miDelito;
        //private static Vehiculos miVehiculo;
        //private static ModeloVehiculoList modelos;
        bool esNN;//si es nn o aprehendidos
        #region "Eventos"

        protected void Page_Load(object sender, EventArgs e)
        {
            esNN = Convert.ToBoolean(Session["esNN"]);
            if (!Page.IsPostBack)
            {

                switch (esNN)
                {
                    case false://autores aprehendidos
                        this.imgCartelVictimas.ImageUrl = "~/App_Images/cartelMOConocidos.png";
                        this.cartelPrincipal.InnerText = "AUTORES APREHENDIDOS";
                        //this.pnlAutor.Visible = true;
                        break;
                    case true://autores desconocidos
                        this.imgCartelVictimas.ImageUrl = "~/App_Images/cartelMO.png";
                        this.cartelPrincipal.InnerText = "AUTORES IGNORADOS";
                        //this.pnlAutor.Visible = false;
                        break;
                    default:
                        return;

                }

             bool esConsulta = Request.QueryString["c"].ToString() == "1" ? true : false;
             if (esConsulta)
                 this.pnlModusOperandi.Enabled = false; 
                Delitos miDelito = (Delitos)Session["miDelito"];
                if (miDelito != null && miDelito.idClaseDelito != null)
                {
                    if (miDelito.idClaseDelito == 2)//si es delitos sexuales
                    {
                        ddlClasificacion.Visible = false;
                        lblClasificacion.Visible = false;
                        this.lblHuboVictimas.Visible = false;
                        this.ddlHuboVictimas.Visible = false;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Error", "alert('No se pudo traer el delito.');", true);
                    return;
                }
                //miDelito = new Delitos();
                LimpiarControles();
                LlenarControles();
                IndicarStatus();

            }
        }
           
           protected void gvComisariasL_SelectedIndexChanged(object sender, EventArgs e)
        {
            Delitos miDelito = (Delitos)Session["miDelito"];
            this.lblComisariaL.Text = this.gvComisariasL.SelectedRow.Cells[2].Text.Trim();
            miDelito.idComisariaL = Convert.ToInt32(this.gvComisariasL.SelectedValue);
            this.pnlComisariasL.Style.Add("display", "none");
            this.btnTraerComisariaL_ModalPopupExtender.Hide();
        }

   

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComisariaList cl = ComisariaManager.GetList(Convert.ToInt32(this.ddlDepartamento.SelectedValue));
            this.gvComisariasL.DataSource = cl;
            this.gvComisariasL.DataBind();
        }
   

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            GuardarDelito();
            bool esConsulta = Request.QueryString["c"].ToString() == "1" ? true : false;
            if (esConsulta)
                Response.Redirect("CargaAutores.aspx?c=1");
            else
                Response.Redirect("CargaAutores.aspx?c=0");
        }

        protected void ddlFueronTrasladadas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Delitos miDelito = (Delitos)Session["miDelito"];
            bool fueronTrasladadas = this.ddlFueronTrasladadas.SelectedItem.ToString().Trim().ToUpper() == "SI";
            if (fueronTrasladadas)
            {
                this.gvLugarTraslado.DataSource = miDelito.lugaresDeTrasladoDeVictimass.FindAll(delegate(LugaresDeTrasladoDeVictimas LTV) { return LTV.Baja == false; });
                this.gvLugarTraslado.DataBind();
                this.btnNuevoLugarTraslado.Enabled = true;
                this.pnlLugarLiberacion.Enabled = true;
            }
            else
            {
                miDelito.lugaresDeTrasladoDeVictimass.RemoveRange(0, miDelito.lugaresDeTrasladoDeVictimass.Count);
                this.gvLugarTraslado.DataBind();
                this.btnNuevoLugarTraslado.Enabled = false;
                LugaresDeTrasladoDeVictimas lt = new LugaresDeTrasladoDeVictimas();
                this.pnlLugarLiberacion.Enabled = false;
            }
        }

     
        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            Delitos miDelito = (Delitos)Session["miDelito"];
            string tipo = (esNN == true) ? "1" : "2";
            tipo += miDelito.idClaseDelito.ToString();
            bool esConsulta = Request.QueryString["c"].ToString() == "1" ? true : false;
            if (esConsulta)
                Response.Redirect("CargaVictimas.aspx?c=1&tipo=" + tipo + "&c=" + Request.QueryString["c"].ToString());
            else
                Response.Redirect("CargaVictimas.aspx?c=0&tipo=" + tipo + "&c=" + Request.QueryString["c"].ToString());
        }

        protected void gvLugarTraslado_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Delitos miDelito = (Delitos)Session["miDelito"];
            //miDelito.lugaresDeTrasladoDeVictimass.RemoveAt(e.RowIndex);
            miDelito.lugaresDeTrasladoDeVictimass[e.RowIndex].Baja = true;
            this.gvLugarTraslado.DataSource = null;
            this.gvLugarTraslado.DataSource = miDelito.lugaresDeTrasladoDeVictimass.FindAll(delegate(LugaresDeTrasladoDeVictimas LTV) { return LTV.Baja == false; });
            this.gvLugarTraslado.DataBind();

        }

        protected void btnAceptarVehiculo_Click(object sender, EventArgs e)
        {
            Delitos miDelito = (Delitos)Session["miDelito"];
            this.pnlLugar.Style.Add("display", "none");
            GuardarVehiculo();
            this.gvVehiculos.DataSource = null;
            //this.gvVehiculos.DataSource = miDelito.vehiculoss.FindAll(delegate(Vehiculos v) { return v.Baja == false; });
            List<Vehiculos> autos = miDelito.vehiculoss.FindAll(delegate(Vehiculos v) { return v.Baja == false & v.idClaseVinculoVehiculo == 1; }).ToList<Vehiculos>();
            this.gvVehiculos.DataSource = autos;
            this.gvVehiculos.DataBind();
            if (gvVehiculos.Rows.Count > 0)
            {
                ddlArribo.Enabled = false;
            }
        }

        private void GuardarVehiculo()
        {
            Delitos miDelito = (Delitos)Session["miDelito"];
            Vehiculos miVehiculo = (Vehiculos)Session["miVehiculo"];
            bool esNuevoVehiculo = (miVehiculo == null);//si es nulo estoy dando de alta
            if (esNuevoVehiculo)
            {
                miVehiculo = new Vehiculos();
                miVehiculo.id = -1;
            }
            miVehiculo.idCausa = miDelito.idCausa;
            miVehiculo.idMarcaVehiculo = Convert.ToInt32(this.ddlMarcaVehiculo.SelectedValue);
            miVehiculo.idModeloVehiculo = Convert.ToInt32(this.ddlModeloVehiculo.SelectedValue);
            miVehiculo.idColorVehiculo = Convert.ToInt32(this.ddlColorVehiculo.SelectedValue);
            miVehiculo.idClaseVidrioVehiculo = Convert.ToInt32(this.ddlVidrios.SelectedValue);
            miVehiculo.Dominio = this.txtDominio.Text.Trim();
            miVehiculo.anio = this.txtAnio.Text.Trim();
            miVehiculo.idDelito = miDelito.id;
            miVehiculo.NumeroChasis = this.txtChasis.Text.Trim();
            miVehiculo.NumeroMotor = this.txtMotor.Text.Trim();
            miVehiculo.idClaseVinculoVehiculo = 1;
            miVehiculo.FechaUltimaModificacion = DateTime.Now;
            miVehiculo.idUsuarioUltimaModificacion = Session["miUsuario"].ToString();
            if (esNuevoVehiculo)
            {
                miDelito.vehiculoss.Add(miVehiculo);
            }
            miVehiculo = null;
        }

        protected void btnCancelarComisariaL_Click(object sender, EventArgs e)
        {
            this.pnlComisariasL.Style.Add("display", "none");
        }


        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session["miDelito"] = null;
            Session["moduloActual"] = null;
            Response.Redirect("~/Home.aspx");
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
            Delitos miDelito = (Delitos)Session["miDelito"];
            if (this.btnTraerLugar.CommandArgument == "traslado")
            {
                LugaresDeTrasladoDeVictimas lugar = new LugaresDeTrasladoDeVictimas();
                lugar.id = -1;
                lugar.idCausa = miDelito.idCausa;
                lugar.idLocalidad = Convert.ToInt32(this.gvLugar.SelectedValue);
                //lugar.idLocalidad = Convert.ToInt32(this.ddlLugarTraslado.SelectedValue);
                miDelito.lugaresDeTrasladoDeVictimass.Add(lugar);
                this.gvLugarTraslado.DataSource = miDelito.lugaresDeTrasladoDeVictimass.FindAll(delegate(LugaresDeTrasladoDeVictimas LTV) { return LTV.Baja == false; });
                this.gvLugarTraslado.DataBind();
                this.pnlLugar.Style.Add("display", "none");
                this.hfAbrirLugar_ModalPopupExtender.Hide();
            }
            else if (this.btnTraerLugar.CommandArgument=="liberacion")
            {
                miDelito.idLocalidadL=Convert.ToInt32(this.gvLugar.SelectedValue);
                this.lblLocalidadL.Text=this.gvLugar.SelectedRow.Cells[2].Text.Trim();
                this.lblPartidoL.Text = ((Label)this.gvLugar.SelectedRow.Cells[3].FindControl("lblPartidoGrid")).Text.Trim();
                miDelito.idPartidoL = LocalidadManager.GetItem(Convert.ToInt32(this.gvLugar.SelectedValue)).Partido;
                this.pnlLugar.Style.Add("display", "none");
                this.hfAbrirLugar_ModalPopupExtender.Hide();
            }
        }

        protected void btnBuscarPartido_Click(object sender, EventArgs e)
        {
            this.btnTraerLugar.CommandArgument="liberacion";
            this.pnlLugar.Style.Remove("display");
            this.hfAbrirLugar_ModalPopupExtender.Show();
        }


        #endregion

        #region "Metodos"
        private void LimpiarControles()
        {
            Delitos miDelito = (Delitos)Session["miDelito"];
            if (miDelito.idClaseDelito == 1)
            {
                this.ddlClasificacion.SelectedValue = "0";
            }
            this.ddlArribo.SelectedValue = "0";
            this.ddlTipoArma.SelectedValue = "0";
            this.ddlHuboVictimas.SelectedValue = "0";
            this.ddlHuboAgresion.SelectedValue = "0";
            this.ddlTipoAgresion.SelectedValue = "0";
            this.ddlFueronTrasladadas.SelectedValue = "0";
            this.lblLocalidadL.Text = "";
            this.lblPartidoL.Text = "";
            this.txtParaje.Text = "";
            this.lblComisariaL.Text = "";
            this.txtExpresionDelito.Text="";
            this.lblDemasiadosResultados.Visible = false;
            this.ddlUtilizaronArmas.SelectedValue = "0";
            this.ddlArmaUtilizada.SelectedValue = "0";
            this.ddlTipoArma.SelectedValue = "0";
            this.pnlLugar.Style.Add("display", "none");
            this.pnlComisariasL.Style.Add("display", "none");
            this.btnNuevoLugarTraslado.Enabled = false;
        }

        private void LlenarControles()
        {
            Delitos miDelito = (Delitos)Session["miDelito"];
            if (miDelito == null || miDelito.idCausa == null || miDelito.idCausa == "")
                return;
            if (miDelito.idClaseModusOperandis>0)
                this.ddlClasificacion.SelectedValue = miDelito.idClaseModusOperandis.ToString();
            if (miDelito.idClaseModoArriboHuida>0)
                this.ddlArribo.SelectedValue = miDelito.idClaseModoArriboHuida.ToString();
            
            this.ddlHuboVictimas.SelectedValue = Convert.ToString(miDelito.VictimasEnElLugar);
            this.ddlHuboAgresion.SelectedValue = Convert.ToString(miDelito.HuboAgresionFisicaAVictima);
            this.ddlTipoAgresion.Enabled = miDelito.HuboAgresionFisicaAVictima == 1;
            this.lblTipoAgresion.Enabled = miDelito.HuboAgresionFisicaAVictima == 1;
            this.ddlTipoAgresion.SelectedValue = Convert.ToString(miDelito.idClaseAgresion);
            this.txtIngresaronPor.Text = miDelito.IngresaronPor==null?"":miDelito.IngresaronPor.Trim();
            //***************
            //Lugares traslado
            string fueronTrasladadas=miDelito.VictimaTrasladadaAOtroLugar.ToString();
            if (fueronTrasladadas == "1")//SI
            {
                this.ddlFueronTrasladadas.SelectedValue = fueronTrasladadas;
                this.btnNuevoLugarTraslado.Enabled = true;
                this.gvLugarTraslado.DataSource = miDelito.lugaresDeTrasladoDeVictimass.FindAll(delegate(LugaresDeTrasladoDeVictimas LTV) { return LTV.Baja == false; });
                this.pnlLugarLiberacion.Enabled = true;
            }
            else
            {
                this.ddlFueronTrasladadas.SelectedValue = "0";//indet
                this.btnNuevoLugarTraslado.Enabled = false;
                this.gvLugarTraslado.DataSource = "";
                this.pnlLugarLiberacion.Enabled = false;
            }
                this.gvLugarTraslado.DataBind();
            //---------
            //Lugar Liberacion
            this.lblLocalidadL.Text = LocalidadManager.GetItem(miDelito.idLocalidadL).localidad;
            this.lblPartidoL.Text = PartidoManager.GetItem(miDelito.idPartidoL).partido;
           if (miDelito.ParajeBarrioL != null)
                this.txtParaje.Text = miDelito.ParajeBarrioL.Trim();
            else
                this.txtParaje.Text = "";
            this.lblComisariaL.Text = ComisariaManager.GetItem(miDelito.idComisariaL).comisaria;
            //-----------
            this.ddlUtilizaronArmas.SelectedValue=Convert.ToString(miDelito.UsoDeArmas);
            if (miDelito.ExprReiteradaDuranteHecho != null)
                this.txtExpresionDelito.Text = miDelito.ExprReiteradaDuranteHecho;
            else
                this.txtExpresionDelito.Text = "";
            //CAMBIAR***************8
            bool usoArma = (miDelito.UsoDeArmas == 1);
            this.lblTipoArma.Enabled = usoArma;
            this.ddlTipoArma.Enabled = usoArma;
            this.ddlArmaUtilizada.Enabled = usoArma;
            this.lblArmaUtilizada.Enabled = usoArma;
            if (usoArma)
            {
                this.ddlArmaUtilizada.SelectedValue = Convert.ToString(miDelito.idClaseArma);

                this.ddlArmaUtilizada.DataBind();
                //this.ddlTipoArma.DataBind();
                //this.ddlTipoArma.SelectedValue = Convert.ToString(miDelito.idClaseSubtipoArma);
                //if (miDelito.idClaseSubtipoArma >1)
                this.ddlTipoArma.SelectedValue = miDelito.idClaseSubtipoArma.ToString();
                //else
                //    this.ddlTipoArma.SelectedValue = "0";
                this.ddlTipoArma.DataBind();
            }
            NNClaseModoArriboHuida modoArribo = NNClaseModoArriboHuidaManager.GetItem(Convert.ToInt32(miDelito.idClaseModoArriboHuida));
            if (modoArribo.esVehiculo)
            {
                pnlVehiculo.Visible = true;
            }
            else
            {
                pnlVehiculo.Visible = false;
            }
            //*************
            //Vehiculos = miDelito.vehiculoss.FindAll(delegate(Vehiculos v) { return v.Baja == false & v.idClaseVinculoVehiculo == 1; });
            this.gvVehiculos.DataSource = miDelito.vehiculoss.FindAll(delegate(Vehiculos v) { return v.Baja == false & v.idClaseVinculoVehiculo == 1; });
            this.gvVehiculos.DataBind();
            if (gvVehiculos.Rows.Count > 0)
            {
                ddlArribo.Enabled = false;
            }
            
        }

        private void IndicarStatus()
        {
            Delitos miDelito = (Delitos)Session["miDelito"];
            if (miDelito == null || miDelito.id == -1)
            {
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

        private void GuardarDelito()
        {
            Delitos miDelito = (Delitos)Session["miDelito"];
            if (miDelito.idClaseDelito == 1)
            {
                miDelito.idClaseModusOperandis = Convert.ToInt32(this.ddlClasificacion.SelectedValue);
            }
            else
                miDelito.idClaseModusOperandis = 0;
            miDelito.idClaseModoArriboHuida = Convert.ToInt32(this.ddlArribo.SelectedValue);

            if (miDelito.idClaseDelito == 2)//delitos sexuales
                miDelito.VictimasEnElLugar = 0;
            else
                miDelito.VictimasEnElLugar = Convert.ToInt16(this.ddlHuboVictimas.SelectedValue);
            miDelito.HuboAgresionFisicaAVictima = Convert.ToInt32(this.ddlHuboAgresion.SelectedValue);
            miDelito.idClaseAgresion = Convert.ToInt16(this.ddlTipoAgresion.SelectedValue);
            miDelito.VictimaTrasladadaAOtroLugar = Convert.ToInt16(this.ddlFueronTrasladadas.SelectedValue);
            //Lugar Liberacion
            //PartidoL, LocalidadL, ComisariaL ya guardados al cerrar el modal de eleccion
            miDelito.ParajeBarrioL = this.txtParaje.Text.Trim();
            miDelito.IngresaronPor = this.txtIngresaronPor.Text.Trim();
            //-----------
            miDelito.UsoDeArmas = Convert.ToInt16(this.ddlUtilizaronArmas.SelectedValue);
            miDelito.ExprReiteradaDuranteHecho = this.txtExpresionDelito.Text.Trim();
            miDelito.idClaseArma = Convert.ToInt32(this.ddlArmaUtilizada.SelectedValue);
            miDelito.idClaseSubtipoArma = Convert.ToInt32(this.ddlTipoArma.SelectedValue);
            Session["miDelito"] = miDelito;
        }
        #endregion


        
        protected void btnTraerComisariaL_Click(object sender, ImageClickEventArgs e)
        {
            this.pnlComisariasL.Style.Remove("display");
        }

        protected void btnBuscarLocalidadL_Click(object sender, ImageClickEventArgs e)
        {
            this.btnTraerLugar.CommandArgument = "liberacion";//paso liberacion o traslado para saber que localidad busco
            this.hfAbrirLugar_ModalPopupExtender.Show();
        }

        

        protected void btnNuevoLugar_Click(object sender, EventArgs e)
        {
            this.btnTraerLugar.CommandArgument = "traslado";//paso liberacion o traslado para saber que localidad busco
            this.hfAbrirLugar_ModalPopupExtender.Show();
        }

        protected void btnNuevoVehiculo_Click(object sender, EventArgs e)
        {
            Session["miVehiculo"]= null;
            LimpiarControlesPanelVehiculos();
            this.hfVehiculosExtender.Show();
        }

        protected void gvVehiculos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Delitos miDelito = (Delitos)Session["miDelito"];
            e.Cancel = true;
            List<Vehiculos> autos = miDelito.vehiculoss.FindAll(delegate(Vehiculos v) { return v.Baja == false & v.idClaseVinculoVehiculo == 1; }).ToList<Vehiculos>();
            Vehiculos auto = autos[e.RowIndex];
            
    
            if (auto.id == -1)
            {
                for (int i = 0; i < miDelito.vehiculoss.Count; i++)
                {
                    if (auto.Equals(miDelito.vehiculoss[i]))
                    {
                        Vehiculos veh = miDelito.vehiculoss[i];
                        miDelito.vehiculoss.Remove(veh);
                    }
                }
        
                
            }
            else
            {
                auto.Baja = true;
            
                
            }
            this.gvVehiculos.DataSource = "";

            autos = miDelito.vehiculoss.FindAll(delegate(Vehiculos v) { return v.Baja == false & v.idClaseVinculoVehiculo == 1; }).ToList<Vehiculos>();
            this.gvVehiculos.DataSource = autos;
            this.gvVehiculos.DataBind();
            if (gvVehiculos.Rows.Count == 0)
            {
                ddlArribo.Enabled = true;

            }
        }

        protected void gvVehiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Delitos miDelito = (Delitos)Session["miDelito"];
            List<Vehiculos> autos = miDelito.vehiculoss.FindAll(delegate(Vehiculos v) { return v.Baja == false & v.idClaseVinculoVehiculo == 1; }).ToList<Vehiculos>();
            Session["miVehiculo"] = autos[this.gvVehiculos.SelectedIndex];
            LimpiarControlesPanelVehiculos();
            LlenarControlesPanelVehiculos();
            this.hfVehiculosExtender.Show();
        }

        private void LlenarControlesPanelVehiculos()
        {
            Vehiculos miVehiculo = (Vehiculos)Session["miVehiculo"];
            this.ddlMarcaVehiculo.SelectedValue = miVehiculo.idMarcaVehiculo.ToString();
            this.ddlVidrios.SelectedValue = miVehiculo.idClaseVidrioVehiculo.ToString();
            this.ddlColorVehiculo.SelectedValue = miVehiculo.idColorVehiculo.ToString();
            this.txtAnio.Text = miVehiculo.anio;
            this.txtDominio.Text = miVehiculo.Dominio;
            this.txtChasis.Text = miVehiculo.NumeroChasis;
            this.txtMotor.Text = miVehiculo.NumeroMotor;
            ModeloVehiculoList modelos= ModeloVehiculoManager.GetListByidMarcaVehiculo(miVehiculo.idMarcaVehiculo);
            this.ddlModeloVehiculo.DataSource = modelos;
            this.ddlModeloVehiculo.DataBind();
            this.ddlModeloVehiculo.SelectedValue = miVehiculo.idModeloVehiculo.ToString();
            
           
        }

        private void LimpiarControlesPanelVehiculos()
        {
            this.ddlMarcaVehiculo.SelectedValue = "0";
            ModeloVehiculoList modelos= ModeloVehiculoManager.GetListByidMarcaVehiculo(Convert.ToInt32(this.ddlMarcaVehiculo.SelectedValue));
            this.ddlModeloVehiculo.DataSource = modelos;
            this.ddlModeloVehiculo.DataBind();
            this.txtDominio.Text = "";
            this.ddlColorVehiculo.SelectedValue = "0";
            this.ddlVidrios.SelectedValue = "0";
            this.txtChasis.Text = "";
            this.txtMotor.Text.Trim();
            this.txtAnio.Text.Trim();
        }

        protected void btnCancelarLugar_Click(object sender, EventArgs e)
        {
            this.pnlLugar.Style.Add("display", "none");
        }

     

        protected void ddlMarcaVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModeloVehiculoList modelos = ModeloVehiculoManager.GetListByidMarcaVehiculo(Convert.ToInt32(this.ddlMarcaVehiculo.SelectedValue));
            this.ddlModeloVehiculo.DataSource = modelos;
            this.ddlModeloVehiculo.DataBind();
        }

        protected void ddlUtilizaronArmas_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool habilitar = this.ddlUtilizaronArmas.SelectedItem.ToString().Trim().ToUpper() == "SI";
            if (!habilitar)
                this.ddlArmaUtilizada.SelectedValue = "0";
            this.ddlArmaUtilizada.Enabled = habilitar;
            this.lblArmaUtilizada.Enabled = habilitar;
            this.ddlTipoArma.Enabled = habilitar;
            this.lblTipoArma.Enabled = habilitar;


        }

        protected void btnBuscarPartido_Click1(object sender, ImageClickEventArgs e)
        {
            this.hfAbrirPartido_ModalPopupExtender.Show();
            this.txtPartido.Focus();
        }

        protected void btnTraerPartido_Click(object sender, EventArgs e)
        {
            PartidoList partidos = PartidoManager.GetList(this.txtPartido.Text.Trim());

            if (partidos.Count > 500) //demasiados registros
            {
                this.lblDemasiadosPartidos.Visible = true;
                this.lblDemasiadosPartidos.Text = "Demasiados resultados, acote el criterio.";
                return;
            }
            if (partidos.Count == 0)
            {
                this.lblDemasiadosPartidos.Visible = true;
                this.lblDemasiadosPartidos.Text = "No se encontraron resultados";
                return;
            }
            this.lblDemasiadosPartidos.Visible = false;
            this.gvPartidos.DataSource = partidos;
            this.gvPartidos.DataBind();
        }

        protected void btnCancelarPartido_Click(object sender, EventArgs e)
        {
            this.pnlPartido.Style.Add("display", "none");
        }

        protected void gvPartidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Delitos miDelito = (Delitos)Session["miDelito"];
            miDelito.idPartidoL = Convert.ToInt32(this.gvPartidos.SelectedValue);
            this.lblPartidoL.Text = this.gvPartidos.SelectedRow.Cells[1].Text.Trim();
            this.pnlPartido.Style.Add("display", "none");
            this.hfAbrirPartido_ModalPopupExtender.Hide();

        }

        protected void ddlArribo_SelectedIndexChanged(object sender, EventArgs e)
        {
            NNClaseModoArriboHuida modoArribo = NNClaseModoArriboHuidaManager.GetItem(Convert.ToInt32(ddlArribo.SelectedValue));
            if (modoArribo.esVehiculo)
            {
                pnlVehiculo.Visible = true;
            }
            else
            {
                pnlVehiculo.Visible = false;
            }

        }

        protected void ddlHuboAgresion_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool habilitar = this.ddlHuboAgresion.SelectedItem.ToString().Trim().ToUpper() == "SI";
            if (!habilitar)
                this.ddlTipoAgresion.SelectedValue = "0";
            this.ddlTipoAgresion.Enabled = habilitar;
            this.lblTipoAgresion.Enabled = habilitar;
         
        }


    }
}

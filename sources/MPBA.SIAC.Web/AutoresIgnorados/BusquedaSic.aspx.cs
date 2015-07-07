using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPBA.AutoresIgnorados.Bll;
using MPBA.AutoresIgnorados.BusinessEntities;
using System.Data;
using MPBA.SIAC.Web;
using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Bll;
using MPBA.SIAC.Web.WebServiceSIC;

namespace MPBA.AutoresIgnorados.Web
{
    public partial class BusquedaSic : System.Web.UI.Page
    {
        FuncionesGenerales.TipoAutores TipoAutor;
        protected void Page_Load(object sender, EventArgs e)
        {
            TipoAutor = (FuncionesGenerales.TipoAutores)(Convert.ToInt32(Request.QueryString["tipo"].ToString().Substring(0, 1)));
            if (!Page.IsPostBack)
            {
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

                LimpiarControles();

             
              
            }
        }


        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session["moduloActual"] = null;
            Response.Redirect("~/Home.aspx");
        }

       

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void LimpiarControles()
        {
            this.txtApellidoAutor.Text = "";
            this.txtDniAutor.Text = "";
            this.txtNombreAutor.Text = "";
            this.lblLimiteResultadosSic.Visible = false;
            this.gvDelitosSIC.DataSource = "";
            this.gvDelitosSIC.DataBind();
            this.upResultadosSic.Update();
        }

      

        private void BuscarDatosSic()
        {
            string clave = Session["ClaveSIC"] == null ? "" : Session["ClaveSIC"].ToString();
            string usuario = Session["UserSIC"] == null ? "" : Session["UserSIC"].ToString();
            if (clave == "" || usuario == "")
            {
               
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Consulta SIC", "alert('Debe loggearse al SIC.');", true);
             
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
            if (TipoAutor == FuncionesGenerales.TipoAutores.Conocidos)
            {
                fltNombreSic = this.txtNombreAutor.Text.Trim();
                fltApellidoSic = this.txtApellidoAutor.Text.Trim();
                fltDocNroSic = this.txtDniAutor.Text.Trim();
            }
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
            fltLocalidad = this.txtLocalidadSic.Text.Trim();
            string codUsuarioSic = Session["codUsuarioSic"] == null ? "" : Session["codUsuarioSic"].ToString();
            if (codUsuarioSic == "")
                throw new Exception("error en codUsuario del webservice");
            string fltTatuaje = "";
            fltTatuaje = this.txtTatuajeSic.Text.Trim();
            string fltEdadAprox = this.ddlEdadSic.SelectedValue.ToString();
            string fltIPP = "";
            int cantMaxMostrar = 10;
            string fltFisGralSic = DepartamentoManager.GetItem(Convert.ToInt32(this.ddlFisGral.SelectedValue)).IdCorte.ToString("00");
            MyFiltroObject filtroSic = new MyFiltroObject();
            filtroSic.codUsuario = codUsuarioSic;
            filtroSic.apellido = fltApellidoSic;
            filtroSic.nombre = fltNombreSic;
            filtroSic.docNro=fltDocNroSic;
            filtroSic.domicilio=fltDomicilio;
            filtroSic.edadAprox=fltEdadAprox;
            filtroSic.fisGral=fltFisGralSic=="00"?"":fltFisGralSic;
            filtroSic.IPP=fltIPP;
            filtroSic.localidad=fltLocalidad;
            filtroSic.tatuaje=fltTatuaje;
            filtroSic.sexo=fltSexo;
            filtroSic.cantResultados = "10";
            filtroSic.estatura = fltEstatura;
            filtroSic.robustez = fltRobustez;
            filtroSic.colorOjos = fltColorOjos;
            filtroSic.colorPiel = fltColorPiel;
            filtroSic.colorCabello = fltColorCabello;
            filtroSic.tipoCabello = fltTipoCabello;
            filtroSic.calvicie = fltCalvicie;
            filtroSic.formaCara = fltFormaCara;
            filtroSic.dimensionCeja = fltDimensionCeja;
            filtroSic.formaCeja = fltFormaCeja;
            filtroSic.formaMenton = fltFormaMenton;
            filtroSic.formaOreja = fltFormaOreja;
            filtroSic.formaNariz = fltFormaNariz;
            filtroSic.formaBoca = fltFormaBoca;
            filtroSic.labioInferior = fltLabioInf;
            filtroSic.labioSuperior = fltLabioSup;
            Services s = new Services();
            MyResultadoObject[] resultadosSic = new MyResultadoObject[Convert.ToInt32(filtroSic.cantResultados)];
            resultadosSic = s.ProcessMyFiltroObject(filtroSic);
            List<MyResultadoObject> listaDelitosSic=resultadosSic.ToList();
            this.lblLimiteResultadosSic.Text = "Solo se muestran los primeros " + cantMaxMostrar.ToString() + " resultados.";
            this.lblLimiteResultadosSic.Visible = (listaDelitosSic.Count >= cantMaxMostrar);
            this.gvDelitosSIC.DataSource = "";
            this.gvDelitosSIC.DataBind();
            if (listaDelitosSic.Count > 0)
            {
                this.gvDelitosSIC.DataSource = listaDelitosSic;
                this.gvDelitosSIC.DataBind();
            }
            else
            {
               ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "updatealert", @"<script language='javascript'>setTimeout(""alert('No se hallaron resultados')"",1000); </script>");
            }
            this.upResultadosSic.Update();
        }

        protected void btnBuscarDatos_Click(object sender, EventArgs e)
        {
            //if (Session["UserSic"] == null || Session["UserSic"].ToString().Trim() == "")
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "Consulta SIC", "alert('Debe loggearse al SIC.');", true);
            //    return;
            //}
            BuscarDatosSic();
        }

        protected void btnBuscarFotos_Click(object sender, EventArgs e)
        {
            if (Session["UserSic"] == null || Session["UserSic"].ToString().Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Consulta SIC", "alert('Debe loggearse al SIC.');", true);
                return;
            }
            buscarFotosSic();
        }

        private void buscarFotosSic()
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
            string urlFotosSic = "http://www.sic.mpba.gov.ar/cons1/frmBuscaXFoto.php?sid=siac&u=" + user + "&NroPagina=1&NroFila=0&NroFilaPrev=0&Sexo=" + fltSexo + "&IPP=" + fltIPP + "&EdadAprox=" + fltEdadAprox + "&Localidad=" + fltLocalidad + "&Tatuaje=" + fltTatuaje + "&Domicilio=" + fltDomicilio + "&FisGral=" + fltFisGralSic + "&Estatura=" + fltEstatura + "&Robustez=" + fltRobustez + "&ColorOjos=" + fltColorOjos + "&ColorPiel=" + fltColorPiel + "&ColorCabello=" + fltColorCabello + "&TipoCabello=" + fltTipoCabello + "&Calvicie=" + fltCalvicie + "&FormaCara=" + fltFormaCara + "&DimensionCeja=" + fltDimensionCeja + "&TipoCeja=" + fltFormaCeja + "&FormaMenton=" + fltFormaMenton + "&FormaOreja=" + fltFormaOreja + "&FormaNariz=" + fltFormaNariz + "&FormaBoca=" + fltFormaBoca + "&LabioInferior=" + fltLabioInf + "&LabioSuperior=" + fltLabioSup + "&t=" + t; 
            ScriptManager.RegisterStartupScript(this, typeof(string), "fotos", "window.open('" + urlFotosSic + "');", true);
            
            }

        protected void gvDelitosSIC_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[2] == null || e.Row.Cells[2].Text == "null")
                {
                    e.Row.Cells[2].Text = "";
                }
            }
        }

        protected void chkBuscaPorDatosSomaticos_CheckedChanged(object sender, EventArgs e)
        {
            this.divDatosSomaticos.Visible = this.chkBuscaPorDatosSomaticos.Checked;
            HabilitarCamposSomaticos(this.chkBuscaPorDatosSomaticos.Checked);
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
      }
}



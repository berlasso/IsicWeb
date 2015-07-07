using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPBA.ConfigurationCL.BusinessLogic;
using MPBA.ConfigurationCL.BusinessObject;
using MPBA.SIAC.Bll;
using MPBA.SIAC.BusinessEntities;
using MPBA.AutoresIgnorados.BusinessEntities;
using Telerik.Web.UI;
using System.Threading;
using System.Xml;
using System.Net;


//using Quartz;

namespace MPBA.SIAC.Web
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //RadMenuItem currentItem1 = RadMenu2.FindItem(delegate(RadMenuItem it) { return ("/siac/" + it.Attributes["NavigateUrl"].ToString()) == Request.Url.PathAndQuery || ("/" + it.Attributes["NavigateUrl"].ToString()) == Request.Url.PathAndQuery; });
            //mantiene coloreado el item donde estoy
            //if (currentItem1 != null)
            //    currentItem1.HighlightPath();
       
            if (!IsPostBack)
            {
                if (Session["miUsuario"] == null)
                    Response.Redirect("~/LoginSIAC.aspx");
                this.pnlLoginSic.Visible = HttpContext.Current.Request.Url.AbsoluteUri.Contains("AutoresIgnorados");
                Panel pnlWaitingOverlay = (Panel)this.upWaiting.FindControl("pnlWaitingOverlay");
                Panel pnlWaiting = (Panel)this.upWaiting.FindControl("pnlWaiting");
                Panel pnlWaitingOverlayLoginSic = (Panel)this.upWaitingLoginSic.FindControl("pnlWaitingOverlayLoginSic");
                Panel pnlWaitingLoginSic = (Panel)this.upWaitingLoginSic.FindControl("pnlWaitingLoginSic");
                pnlWaitingOverlay.CssClass = "overlay";
                pnlWaiting.CssClass = "loader";
                pnlWaitingOverlayLoginSic.CssClass = "overlay";
                pnlWaitingLoginSic.CssClass = "loader";
                this.pnlAccesoSic.Style.Add("display", "none");
                this.pnlConfigMail.Style.Add("display", "none");
                this.pnlSalir.Style.Add("display", "none");
                this.pnlServerSicOcupado.Style.Add("display", "none");
                Session["PathServer"] = Server.MapPath(".");
               
                this.LBLInfoUsuario.Text = Session["miUsuario"].ToString().Trim();
                String myConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[1].ConnectionString;
                ConnectionSring.conexion = myConnectionString;
                if (Session["miUsuario"] != null)
                {
                    string miusuario = Session["miUsuario"].ToString().Trim();
                    
                        MPBA.ConfigurationCL.BusinessObject.Usuarios xUsuario = MPBA.ConfigurationCL.BusinessLogic.UsuariosManager.GetItem(miusuario, true);
                        try
                        {
                            
                            PersonalPoderJudicial ppj = PersonalPoderJudicialManager.GetItem(xUsuario.IdPersonalPoderJudicial);
                            Persona per = PersonaManager.GetItem(ppj.idPersona);
                            PuntoGestion pg = PuntoGestionManager.GetItem(ppj.idPuntoGestion);
                            Session["idGrupo"] = xUsuario.IdGrupoUsuario;
                            if (per.EMail == null || per.EMail.Trim() == "")
                                this.btnConfigurarMailPB.ForeColor = System.Drawing.Color.Red;
                            else
                                this.btnConfigurarMailPB.ForeColor = System.Drawing.Color.Green;

                            Session["miUfi"] = ppj.idPuntoGestion;
                            if (Session["ClaveSIC"] != null && Session["ClaveSIC"].ToString() != "")
                            {
                                this.lblLoggeadoSic.ForeColor = System.Drawing.Color.Green;
                                this.lblLoggeadoSic.Text = "Loggeado al SIC";
                                this.btnLoginSic.Text = "Desloggear SIC";
                            }
                            else
                            {
                                this.lblLoggeadoSic.ForeColor = System.Drawing.Color.Red;
                                this.lblLoggeadoSic.Text = "Desloggeado del SIC";
                                this.btnLoginSic.Text = "Login SIC";
                            }
                            //this.LBLInfoUsuario.Text = xUsuario.NombreUsuario + ": " + per.Apellido + ", " + per.Nombre + " - " + JerarquiaPoderJudicialManager.GetItem(ppj.idJerarquia).Descripcion + " - " + pg.Descripcion + " - " + DepartamentoManager.GetItem(pg.idDepartamento).Descripcion;
                            this.LBLInfoUsuario.Text = per.Apellido + ", " + per.Nombre + " - " + pg.Descripcion + " - " + MPBA.SIAC.Bll.DepartamentoManager.GetItem(pg.idDepartamento).departamento;
                        }
                        catch
                        {
                            Session.Clear();
                            Session["SinPermiso"] = "SinPermiso";
                            Response.Redirect("LoginSIAC.aspx");
                        }
                        if (XmlDataSource1.Data.Equals(""))
                        {
                            
                            XmlDataSource1.Data = MenuManager.ArmarMenu(xUsuario, myConnectionString);
                          

                            //XmlDataSource1.Data = "<Menu Id='0' IdPadre='0' Descripcion='' Hint='' Url=''><SubMenu Id='1' IdPadre='0' Descripcion='Proceso' Hint='Procesos' Url=''></SubMenu></Menu>";
                            XmlDataSource1.XPath = "Menu/SubMenu";
                            
                            // si tiene permisos arma el menu, sino lo tira de la sesion.
                            if (!XmlDataSource1.Data.Equals(""))
                            {
                                RadMenu2.DataBind();
                                RadMenuItem currentItem = RadMenu2.FindItem(delegate(RadMenuItem it) { return ("/siac/" + it.Attributes["NavigateUrl"].ToString()) == Request.Url.PathAndQuery || ("/" + it.Attributes["NavigateUrl"].ToString()) == Request.Url.PathAndQuery; });
                                //mantiene coloreado el item donde estoy
                                if (currentItem != null)
                                    currentItem.HighlightPath();
                            }

                            else
                            {
                                Session.Clear();
                                Session["SinPermiso"] = "SinPermiso";
                                Response.Redirect("LoginSIAC.aspx");
                            }
                        
                        ResaltarMenu();
                    }
                    else
                    {
                        Session.Clear();
                        Session["SinPermiso"] = "SinPermiso";
                        Response.Redirect("LoginSIAC.aspx");

                        /*
                        iconoAplic.Href = "App_Images/" + site + "/icons/icono.ico";
                        Page.Title = Session["Title"].ToString();
                        */

                    }
                }
                else
                {
                    Session.Clear();
                    Session["SinPermiso"] = "SinPermiso";
                    Response.Redirect("LoginSIAC.aspx");

                    /*
                    iconoAplic.Href = "App_Images/" + site + "/icons/icono.ico";
                    Page.Title = Session["Title"].ToString();
                    */

                }

            }

        }

        private void ResaltarMenu()
        {
            if (this.RadMenu2.Items.Count > 0)
            {
                string moduloActual = Session["moduloActual"] != null ? Session["moduloActual"].ToString() : "";
                switch (moduloActual)
                {
                    case "BP":
                        this.RadMenu2.FindItemByText("Búsqueda de Personas").HighlightPath();
                        //this.RadMenu2.Items[0].HighlightPath();//busq personas
                        break;
                    case "RH":
                        this.RadMenu2.FindItemByText("Robos y Hurtos").HighlightPath();
                        //this.RadMenu2.Items[1].HighlightPath();//robos y hurtos
                        break;
                    case "DS":
                        this.RadMenu2.FindItemByText("Delitos Sexuales").HighlightPath();
                        //this.RadMenu2.Items[2].HighlightPath();//delitos sexuales
                        break;
                    case "U":
                        this.RadMenu2.FindItemByText("Usuarios").HighlightPath();
                        //this.RadMenu2.Items[3].HighlightPath();//usuarios
                        break;
                    case "E":
                        this.RadMenu2.FindItemByText("Estadisticas").HighlightPath();

                        break;
                    case "D":
                        this.RadMenu2.FindItemByText("Utilidades").HighlightPath();
                        break;
                    case "EST":
                        this.RadMenu2.FindItemByText("Estadisticas").HighlightPath();
                        break;
                   
                }
            }
          }

        public RadMenu radMenuPrincipal
        {
            get
            {
                return this.RadMenu2;
            }
        }

        protected void BTNSalir_Click(object sender, ImageClickEventArgs e)
        {
            Session.Clear();
            Response.Redirect("LoginSIAC.aspx");
        }

        protected void RadMenu2_ItemClick(object sender, Telerik.Web.UI.RadMenuEventArgs e)
        {

 

            if (e.Item.Attributes["NavigateUrl"] != null && e.Item.Attributes["NavigateUrl"]!="")
            {
     

                if (Request.Url.AbsolutePath != "/Home.aspx" && Request.Url.AbsolutePath != "/siac/Home.aspx")
                {
                    
                    this.btnOkSalir.Attributes["url"] = e.Item.Attributes["NavigateUrl"].ToString();
                    //this.lblMensajeSalir.Text = Request.Url.AbsolutePath;

                    this.pnlSalir.Style.Remove("display");
                    this.hfSalir_ModalPopupExtender.Show();
                }
                else
                {
                    Response.Redirect(@"~\" + e.Item.Attributes["NavigateUrl"].ToString());
                }


            }
            
        }

        protected void RadMenu2_ItemDataBound(object sender, RadMenuEventArgs e)
        {
            if (e.Item.NavigateUrl != null && e.Item.NavigateUrl.Trim() != "")
            {
                e.Item.Attributes["NavigateUrl"] = e.Item.NavigateUrl;
            }
            else
            {
                e.Item.Attributes["NavigateUrl"] = "";
            }
           
                e.Item.NavigateUrl = "";
        }
      

        public Button btnConfigurarMailPB
        {
            get
            {
                return this.btnConfigMailPB;
            }
        }

        protected void chkMandarMail_CheckedChanged(object sender, EventArgs e)
        {
            this.txtConfigMail.Enabled = this.chkMandarMail.Checked;
            if (this.chkMandarMail.Checked)
            {
                string miusuario = Session["miUsuario"].ToString().Trim();
                this.txtConfigMail.Text = miusuario + "@mpba.gov.ar";
            }
            else
            {
                this.txtConfigMail.Text = "";
            }
        }

        protected void btnOkConfigMail_Click(object sender, EventArgs e)
        {
            string miusuario = Session["miUsuario"].ToString();
            MPBA.ConfigurationCL.BusinessObject.Usuarios xUsuario = MPBA.ConfigurationCL.BusinessLogic.UsuariosManager.GetItem(miusuario, true);
            PersonalPoderJudicial ppj = PersonalPoderJudicialManager.GetItem(xUsuario.IdPersonalPoderJudicial);

            Persona per = PersonaManager.GetItem(ppj.idPersona);
            if (this.chkMandarMail.Checked)
            {
                if (regexMailValido.IsValid)
                {
                   
                    per.EMail = this.txtConfigMail.Text.Trim().ToLower();
                    PersonaManager.Save(per);
                    this.btnConfigurarMailPB.ForeColor = System.Drawing.Color.Green;
                }
            }
            else
            {
                per.EMail = "";
                PersonaManager.Save(per);
                this.btnConfigurarMailPB.ForeColor = System.Drawing.Color.Red;
            }
            this.pnlConfigMail.Style.Add("display", "none");
            this.hfConfigMailPB_ModalPopupExtender.Hide();
        }

        protected void btnConfigMailPB_Click(object sender, EventArgs e)
        {
            string miusuario = Session["miUsuario"].ToString();
            MPBA.ConfigurationCL.BusinessObject.Usuarios xUsuario = MPBA.ConfigurationCL.BusinessLogic.UsuariosManager.GetItem(miusuario, true);
            PersonalPoderJudicial ppj = PersonalPoderJudicialManager.GetItem(xUsuario.IdPersonalPoderJudicial);
            Persona per = PersonaManager.GetItem(ppj.idPersona);
            if (per.EMail != null && per.EMail.Trim() != "")
            {
                this.txtConfigMail.Text = per.EMail.Trim();
                this.chkMandarMail.Checked = true;
                this.txtConfigMail.Enabled = true;
            }
            else
            {
                this.chkMandarMail.Checked = false;
                this.txtConfigMail.Enabled = false;
            }
            this.pnlConfigMail.Style.Remove("display");
            this.hfConfigMailPB_ModalPopupExtender.Show();
        }

        protected void btnOkSalir_Click(object sender, EventArgs e)
        {

            Response.Redirect(@"~\" + this.btnOkSalir.Attributes["url"]);
            RadMenuItem currentItem = RadMenu2.FindItemByUrl(Request.Url.PathAndQuery);
            if (currentItem != null)
                currentItem.HighlightPath();
            
            
        }

      

        protected void btnOkAccesoSic_Click(object sender, EventArgs e)
        {
            if (LoginAlSic() == false)
            {
                this.lblClaveIncorrectaSic.Visible = true;
                //this.lblClaveIncorrectaSic.ForeColor = System.Drawing.Color.Green;
                //ActivarBotonesSic(false);
                //this.btnMostrarFotosSic.Enabled = false;
                return;
            }
            this.lblClaveIncorrectaSic.Visible = false;
            this.pnlAccesoSic.Style.Add("display", "none");
            this.hfGestionAccesoSic_ModalPopupExtender.Hide();
            //ActivarBotonesSic(Session["ClaveSIC"] != null);
            //this.btnMostrarFotosSic.Enabled = (Session["ClaveSIC"] != null);
            //LlenarControles();
            MPBA.AutoresIgnorados.Web.CargaAutores ca=null;
            if (this.FindControl("Main").Page.GetType().BaseType == typeof(MPBA.AutoresIgnorados.Web.CargaAutores))
                ca = (MPBA.AutoresIgnorados.Web.CargaAutores)this.FindControl("Main").Page;
            if (Session["ClaveSIC"] != null && Session["ClaveSIC"].ToString() != "")
            {
                this.lblLoggeadoSic.Text = "Loggeado al SIC";
                this.lblLoggeadoSic.ForeColor = System.Drawing.Color.Green;
                this.btnLoginSic.Text = "Desloggear SIC";
                if (ca!=null) //activa botones de la grilla de autores para consulta en el sic 
                    ca.ActivarBotonesSic(true);
                
            }
            else
            {
                this.lblLoggeadoSic.Text = "Desloggeado del SIC";
                this.lblLoggeadoSic.ForeColor = System.Drawing.Color.Red;
                this.btnLoginSic.Text = "Login SIC";
                if (ca!=null)
                  ca.ActivarBotonesSic(false);//desactiva botones de la grilla de autores para consulta en el sic 
              
            }
            this.txtUsuarioSic.Text = "";
            this.txtClaveSic.Text = "";
         
        }

      

        protected void btnCancelarAccesoSic_Click(object sender, EventArgs e)
        {
            this.pnlAccesoSic.Style.Add("display", "none");
            this.hfGestionAccesoSic_ModalPopupExtender.Hide();
        }

     /// <summary>
        /// Se loggea al SIC
        /// </summary>
       /// <returns>si pudo loggearse o no</returns>
        private bool LoginAlSic()
        {

            //*********************************
            //ARREGLAR*************************
            //string clave = FuncionesGenerales.Encriptar(this.txtClaveSic.Text.Trim());
            string clave = this.txtClaveSic.Text.Trim();
            string user = this.txtUsuarioSic.Text.Trim();
            WebServiceSIC.Services s=new WebServiceSIC.Services();
            string perfil = s.PerfilUsuario(user, clave);
            if (perfil != "")
            {
                Session["ClaveSIC"] = "ok";
                Session["UserSIC"] = "ok";
                return true;
            }
            else
            {
                Session["ClaveSIC"] = null;
                Session["UserSIC"] = null;
                return false;
            }
        }

        public void btnLoginSic_Click(object sender, EventArgs e)
        {
           
            if (this.btnLoginSic.Text == "Desloggear SIC")
            {
                Session["ClaveSIC"] = null;
                Session["UserSIC"] = null;
                this.lblLoggeadoSic.ForeColor = System.Drawing.Color.Red;
                this.lblLoggeadoSic.Text = "Desloggeado del SIC";
                this.btnLoginSic.Text = "Login SIC";
                MPBA.AutoresIgnorados.Web.CargaAutores ca = null;
                if (this.FindControl("Main").Page.GetType().BaseType == typeof(MPBA.AutoresIgnorados.Web.CargaAutores))//si estoy en cargaautores desactivo los botones de consulta en base SIC si me desloggeo
                {
                    ca = (MPBA.AutoresIgnorados.Web.CargaAutores)this.FindControl("Main").Page;
                    ca.ActivarBotonesSic(false);
                }


            }
            else
            {
                this.pnlAccesoSic.Style.Remove("display");
                this.hfGestionAccesoSic_ModalPopupExtender.Show();
                this.txtUsuarioSic.Focus();
            }
        }

        protected void btnOkServerSicOcupado_Click(object sender, EventArgs e)
        {
            this.hfServerSicOcupado_ModalPopupExtender.Hide();
            this.pnlServerSicOcupado.Style.Add("display", "none");
        }

      

    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Bll;
using AjaxControlToolkit;
using MPBA.ConfigurationCL;
using System.Threading;
using System.Xml;
using System.Net;
using MPBA.ConfigurationCL.BusinessLogic;
using MPBA.ConfigurationCL.BusinessObject;
using System.DirectoryServices;
using System.Collections;
using System.Data;
using System.IO;
using Quartz;
using Quartz.Impl;

namespace MPBA.SIAC.Web
{
    public partial class EditUsuarioAutorizado : System.Web.UI.Page
    {
        UsuarioAutorizado miUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.MsgBoxNoGrabo.Visible = false;
            if (!Page.IsPostBack)

            {
                
                this.divMailing.Visible = true;
                this.divResulApeMpba.Visible = false;
                this.chkMandarMail.Checked = true;
                ReadTextFileMail();
                String myConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[1].ConnectionString;
                ConnectionSring.conexion = myConnectionString;
                 string idUsuario =Request.QueryString["idUsuario"].ToString().Trim();

                 UsuarioAutorizado miUsuario;
                 if (idUsuario != "0")//el usuario ya existe en la base
                 {
                     
                     miUsuario = UsuariosAutorizadoManager.GetItem(idUsuario);
                     if (miUsuario != null)
                     {
                         Session["miUsuarioAutorizado"] = miUsuario;
                         HabilitarControles(true);
                         this.chkMandarMail.Checked = false;
                         this.btnAceptarUsuario.Enabled = true;
                         string origen = Request.QueryString["TipoVista"].ToString();
                         if (origen != null)
                         {
                             //HabilitarControles(true);
                             if (origen == "CON")
                             {
                                 HabilitarControles(false);

                             }
                             else
                             {
                                 HabilitarControles(true);

                             }
                         }
                         LimpiarControles();
                         LlenarControles();
                         this.lblNuevo.Visible = false;
                         this.lblModificando.Visible = true;
                     }

                 }
                 else//permito crear un usuario
                 {
                     miUsuario = new UsuarioAutorizado();
                     LimpiarControles();
                     HabilitarControles(true);
                     this.chkActivo.Checked = true;
                     this.lblNuevo.Visible = true;
                     this.lblModificando.Visible = false;
                     this.btnAceptarUsuario.Enabled = false;

                 }
                 Session["miUsuarioAutorizado"] = miUsuario;

                 this.txtDependencia.Focus();  
            }
        }

      

        protected void LimpiarControles()
        {
            this.txtNombre.Text = "";
            this.txtApellido.Text = "";
            this.lblPuntoGestionValor.Text = "";
            this.lblDepartamentoValor.Text = "";
            this.txtNombreUsuario.Text = "";
            this.ddlGrupo.SelectedValue = Convert.ToString(0);
            //this.chkEsREferente.Checked = false;
        }
        protected void HabilitarControles(bool habilitar)
        {
            this.txtNombre.ReadOnly = habilitar == false;
            this.txtApellido.ReadOnly = habilitar == false;
            this.txtNombreUsuario.ReadOnly = habilitar == false;
            this.ddlGrupo.Enabled = habilitar;
            //this.chkEsREferente.Enabled = habilitar;
        }
        protected void LlenarControles()
        {
            miUsuario = (UsuarioAutorizado)Session["miUsuarioAutorizado"];
            if (miUsuario.Nombre != null)
            {
                this.txtNombre.Text = miUsuario.Nombre.Trim();
                this.chkMandarMail.Checked = false;
            }
            else
            {
                this.txtNombre.Text = "";
                this.chkMandarMail.Checked = true;
            }
            if (miUsuario.Apellido != null)
                this.txtApellido.Text = miUsuario.Apellido.Trim();
            else
                this.txtApellido.Text = "";
            if (miUsuario.idPuntoGestion != null)
                this.lblPuntoGestionValor.Text = PuntoGestionManager.GetItem(miUsuario.idPuntoGestion).Descripcion;
            else
                this.lblPuntoGestionValor.Text = "";
            if (miUsuario.idDepartamento != null)
                this.lblDepartamentoValor.Text = DepartamentoManager.GetItem( miUsuario.idDepartamento).departamento;
            else
                this.lblDepartamentoValor.Text = "";
            if (miUsuario.NombreUsuario != null)
                this.txtNombreUsuario.Text = miUsuario.NombreUsuario.Trim();
            else
                this.txtNombreUsuario.Text = "";
            if (miUsuario.idGrupoUsuario != null)
                this.ddlGrupo.SelectedValue = miUsuario.idGrupoUsuario;
            if (miUsuario.activo != null)
                this.chkActivo.Checked = miUsuario.activo;
        }

        protected void btnBuscarPG_Click(object sender, ImageClickEventArgs e)
        {
            
            this.pnlPuntoGestion.Style.Remove("display");
           
            PuntoGestionList pgl = PuntoGestionManager.GetListDependenciasPJByidDepartamento((Convert.ToInt32(this.ddlDepartamento.SelectedValue)));
            this.gvPuntoGestion.DataSource = pgl;
            this.gvPuntoGestion.DataBind();
            this.btnBuscarPuntoGestion_ModalPopupExtender.Show();
        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            PuntoGestionList pgl = PuntoGestionManager.GetListDependenciasPJByidDepartamento((Convert.ToInt32(this.ddlDepartamento.SelectedValue)));
            this.gvPuntoGestion.DataSource = pgl;
            this.gvPuntoGestion.DataBind();
        
        }
        protected void btnCancelarPuntoGestion_Click(object sender, EventArgs e)
        {
            this.pnlPuntoGestion.Style.Add("display", "none");
        }
        protected void gvPuntoGestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            miUsuario = (UsuarioAutorizado)Session["miUsuarioAutorizado"];
            this.lblPuntoGestionValor.Text = this.gvPuntoGestion.SelectedRow.Cells[2].Text.Trim();
            miUsuario.idPuntoGestion = this.gvPuntoGestion.SelectedValue.ToString().Trim();
            miUsuario.idDepartamento = Convert.ToInt32(this.ddlDepartamento.SelectedValue);
            this.lblDepartamentoValor.Text = DepartamentoManager.GetItem(miUsuario.idDepartamento).departamento;
            Session["miUsuarioAutorizado"] = miUsuario;
            //this.pnlPuntoGestion.Style.Add("display", "none");
            this.btnBuscarPuntoGestion_ModalPopupExtender.Hide();
        }

        protected void btnAceptarUsuario_Click(object sender, EventArgs e)
        {
            string origen = Request.QueryString["TipoVista"].ToString();
            if (origen != "CON")
            {
                if (this.txtNombreUsuario.Text.ToString().Trim() == "")
                {
                    this.CVNombreUsuario.IsValid = false;
                    return;
                }
                UsuarioAutorizado uExistente = UsuariosAutorizadoManager.GetItem(this.txtNombreUsuario.Text.Trim());
                miUsuario = (UsuarioAutorizado)Session["miUsuarioAutorizado"];
                //if (uExistente !=null && uExistente.idUsuario!=null && miUsuario!=null && miUsuario.idUsuario!=null && uExistente.idUsuario.Trim()!=miUsuario.idUsuario.Trim())
                if (uExistente != null && uExistente.idUsuario != null) //si el nombre de usuario ya existe
                {
                    if (miUsuario != null && miUsuario.NombreUsuario != null && uExistente.idUsuario.Trim() != miUsuario.idUsuario.Trim())//cartel solo cuando estoy modificando el nombre de usuario
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Nombre de Usuario ya existente.');", true);
                        //this.MsgBoxNoGrabo.Text = "Nombre de Usuario ya existente";
                        //this.MsgBoxNoGrabo.Visible = true;
                        this.txtNombreUsuario.Focus();
                        this.txtNombreUsuario.Attributes.Add("onfocusin", "select();");
                        return;
                    }
                }

                if (GuardarUsuario())
                {
                    miUsuario = (UsuarioAutorizado)Session["miUsuarioAutorizado"];
                    //Session["miUsuarioAutorizado"] = null;
                    //int idDepartamento = Convert.ToInt32(Session["FiltroDeptoUsuarioAutorizado"]);
                    //Response.Redirect(("~/Usuarios.aspx?TipoVista=" + origen + "&idDepartamento=" + idDepartamento));
                    //miUsuario = null;
                    string msg = "Usuario guardado exitosamente.";
                    //this.MsgBoxNoGrabo.Visible = true;
                    this.lblNuevo.Visible = false;
                    this.lblModificando.Visible = true;
                    if (this.chkMandarMail.Checked)
                    {
                        string mailto = this.txtNombreUsuario.Text.Trim() + "@mpba.gov.ar";
                        MandarMail(mailto);
                        msg += "Se ha enviado el mail correctamente.";
                        
                    }
                    this.chkMandarMail.Checked = false;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('"+msg+"');", true);
                    //this.MsgBoxNoGrabo.Text = msg;
                    //this.MsgBoxNoGrabo.Visible = true;
                    
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Los datos no pudieron ser guardados');", true);
                    //this.MsgBoxNoGrabo.Text = "Los datos no pudieron ser guardados";
                    //this.MsgBoxNoGrabo.Visible = true;
                }
            }
            
        }
        protected bool GuardarUsuario()
        {

            miUsuario = (UsuarioAutorizado)Session["miUsuarioAutorizado"];
            miUsuario.Nombre = this.txtNombre.Text.Trim();
            if (miUsuario.idUsuario==null)
            {
                miUsuario.idUsuario = "-1";
            }
            miUsuario.Apellido = this.txtApellido.Text.Trim();
            miUsuario.NombreUsuario = this.txtNombreUsuario.Text.Trim();
            miUsuario.idGrupoUsuario = this.ddlGrupo.SelectedValue;
            miUsuario.activo = this.chkActivo.Checked;
            //miUsuario.activo = true;
            if (UsuariosAutorizadoManager.Save(miUsuario))
                return true;
            else
                return false;
        }
        protected void btnCancelarUsuario_Click(object sender, EventArgs e)
        {
            miUsuario = null;
            Session["miUsuarioAutorizado"] = null;
            string origen = Request.QueryString["TipoVista"].ToString();
            int idDepartamento = Convert.ToInt32(Session["FiltroDeptoUsuarioAutorizado"]);
            Response.Redirect(("~/Usuarios.aspx?TipoVista=" + origen + "&idDepartamento=" + idDepartamento));
            //Response.Redirect(("~/Usuarios.aspx"));/* + QueryStringModule.Encrypt("TipoVista=" + origen));*/
        }

     

        protected void btnBuscarDep_Click(object sender, EventArgs e)
        {
            PuntoGestionList pgl = PuntoGestionManager.GetListDependenciasPJByidDepartamento((Convert.ToInt32(this.ddlDepartamento.SelectedValue)));
            this.gvPuntoGestion.DataSource = pgl.FindAll(delegate(PuntoGestion pg) { return pg.Descripcion.Trim().ToUpper().Contains(this.txtDependencia.Text.Trim().ToUpper()) == true; }); ;

            //foreach (PuntoGestion pg in pgl)
            //{

            //}
            this.gvPuntoGestion.DataBind();
            this.txtDependencia.Focus();
        }

        protected void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            this.MsgBoxNoGrabo.Visible = false;
            this.divResulApeMpba.Visible = false;
            this.chkActivo.Checked = true;
           
            miUsuario = (UsuarioAutorizado)Session["miUsuarioAutorizado"];
            string idpunto = miUsuario.idPuntoGestion;
            int depto = miUsuario.idDepartamento;
            miUsuario = new UsuarioAutorizado();
            miUsuario.idPuntoGestion = idpunto;
            miUsuario.idDepartamento = depto;
            this.txtNombreUsuario.Text = "";
            this.txtApellido.Text = "";
            this.txtNombre.Text = "";
            this.chkMandarMail.Checked = true;
            Session["miUsuarioAutorizado"] = miUsuario;
            this.lblNuevo.Visible = true;
            this.lblModificando.Visible = false;
            this.txtNombreUsuario.ReadOnly = false;
            this.btnTraerUsuario.Text = "Traer";
            this.btnAceptarUsuario.Enabled = false;
            this.txtNombreUsuario.Focus();
        }

      

        void ReadTextFileMail()
      {
           string inputString;
         
           using (StreamReader streamReader = File.OpenText(Server.MapPath("~") + @"\textoMail.txt"))
           {
               this.txtTextoMail.Text = System.Web.HttpUtility.HtmlEncode(this.txtTextoMail.Text);
               inputString = streamReader.ReadLine();
               while (inputString != null)
               {
                   this.txtTextoMail.Text += inputString + "\n";
                   inputString = streamReader.ReadLine();
               }
           }
       }


        private void MandarMail(string mailto)
        {
            //ReadTextFileMail();
            string body = this.txtTextoMail.Text.Trim();
            string subject = this.txtAsuntoMail.Text.Trim();
            StdSchedulerFactory schedFact = new StdSchedulerFactory();
            IScheduler sched;
      

            sched = (IScheduler)Application["scheduler"];
            JobDetail mailParaMandar = new JobDetail(Guid.NewGuid().ToString(), null, typeof(MPBA.SIAC.Web.MailJob));
            mailParaMandar.JobDataMap["mailto"] = mailto;
            mailParaMandar.JobDataMap["subject"] = subject;
            mailParaMandar.JobDataMap["body"] = body;
            mailParaMandar.JobDataMap["from"] = "SIAC@mpba.gov.ar";
            //Trigger t = TriggerUtils.MakeImmediateTrigger(1, new TimeSpan(1, 1, 0));
            Trigger t = TriggerUtils.MakeImmediateTrigger(0, new TimeSpan(0, 0, 0));
            t.Name = Guid.NewGuid().ToString();
            DateTime tt = sched.ScheduleJob(mailParaMandar, t);//envia inmediatamente el mail
        }



      
        protected void btnTraerUsuario_Click(object sender, EventArgs e)
        {
            if (this.btnTraerUsuario.Text != "Traer")
            {
                this.lblNuevo.Visible = true;
                this.lblModificando.Visible = false;
                this.txtNombreUsuario.ReadOnly = false;
                this.btnTraerUsuario.Text = "Traer";
                return;
            }
            this.divResulApeMpba.Visible = false;
            UsuarioAutorizado uExistente = UsuariosAutorizadoManager.GetItem(this.txtNombreUsuario.Text.Trim());
            if (uExistente != null)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Nombre de Usuario ya existente.');", true);
                //this.MsgBoxNoGrabo.Text = "Nombre de Usuario ya existente";
                //this.MsgBoxNoGrabo.Visible = true;
                this.txtNombreUsuario.Focus();
                this.txtApellido.Text = uExistente.Apellido.Trim();
                this.txtNombre.Text = uExistente.Nombre.Trim();
                this.chkActivo.Checked = uExistente.activo;
                this.lblDepartamentoValor.Text = DepartamentoManager.GetItem(uExistente.idDepartamento).departamento.Trim();
                this.lblPuntoGestionValor.Text = PuntoGestionManager.GetItem(uExistente.idPuntoGestion).Descripcion.Trim();
                miUsuario = UsuariosAutorizadoManager.GetItem(uExistente.idUsuario);
                Session["miUsuarioAutorizado"] = miUsuario;
                this.ddlGrupo.SelectedValue = uExistente.idGrupoUsuario;
                this.lblNuevo.Visible = false;
                this.lblModificando.Visible = true;
                this.txtNombreUsuario.ReadOnly = true;
                this.btnTraerUsuario.Text = "Busca Otro";
                this.btnAceptarUsuario.Enabled = true;
                return;
            }
            string usuarioDominio = getCommonName(this.txtNombreUsuario.Text.Trim());
            if (usuarioDominio != "")
            {
                this.txtApellido.Text = usuarioDominio.Substring(usuarioDominio.LastIndexOf(' ') + 1);
                this.txtNombre.Text = usuarioDominio.Substring(0, usuarioDominio.LastIndexOf(' '));
                this.btnAceptarUsuario.Enabled = true;
                this.txtNombreUsuario.ReadOnly = true;
                this.btnTraerUsuario.Text = "Busca Otro";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('No se encontro al usuario en el dominio.');", true);
                    //this.MsgBoxNoGrabo.Text = "No se encontro al usuario en el dominio";
                    //this.MsgBoxNoGrabo.Visible = true;
                    this.txtNombreUsuario.Focus();
                    this.btnAceptarUsuario.Enabled = false;
                    return;
                
            }

        }

        public string getCommonName(string user)
        {
            string fullpath;

            DirectoryEntry objRoot = new DirectoryEntry("LDAP://rootDSE");
            DirectoryEntry objUsers = new DirectoryEntry("LDAP://" + (string)objRoot.Properties["defaultNamingContext"].Value);
   
            DirectorySearcher Filter1 = new DirectorySearcher(objUsers);
            
            Filter1.Filter = "(&(objectClass=user)(sAMAccountName=" + user + "))";
            SearchResultCollection FilterResult1 = Filter1.FindAll();
            int cant = FilterResult1.Count;
            fullpath = "";

            foreach (SearchResult iter in FilterResult1)
            {
                fullpath = (string)iter.GetDirectoryEntry().Properties["CN"].Value;
            }

            return fullpath;
        }

        protected void btnApellidoMpbaABuscar_Click(object sender, EventArgs e)
        {
         
            DirectoryEntry objRoot = new DirectoryEntry("LDAP://rootDSE");
            DirectoryEntry objUsers = new DirectoryEntry("LDAP://" + (string)objRoot.Properties["defaultNamingContext"].Value);
            DirectorySearcher Filter1 = new DirectorySearcher(objUsers);
   
                Filter1.Filter = "(&(objectClass=user)(CN=*"+this.txtApellido.Text.Trim()+"*))";

                SearchResultCollection FilterResult1 = Filter1.FindAll();
                int cant = FilterResult1.Count;
                string usuarios = "";
            
                //List<string> usuarios = new List<string>();
                if (cant > 0)
                {
                    usuarios = "";
                    //DataTable tbl = new DataTable();
                    //DataColumn col = new DataColumn("usuario");
                    //tbl.Columns.Add(col);
                    
                    foreach (SearchResult iter in FilterResult1)
                    {
                        //TableRow row = new TableRow();
                        usuarios += (string)iter.GetDirectoryEntry().Properties["sAMAccountName"].Value + "    ";
                        usuarios += (string)iter.GetDirectoryEntry().Properties["CN"].Value+ "    ";
                        usuarios += (string)iter.GetDirectoryEntry().Properties["physicalDeliveryOfficeName"].Value.ToString().Trim() + "    ";
                        try
                        {

                            //object[] memberOf = (object[])iter.GetDirectoryEntry().Properties["memberOf"].Value;
                            string member = "";
                            switch (iter.GetDirectoryEntry().Properties["memberOf"].Value.GetType().Name)
                            {
                                case "String":
                                    member = iter.GetDirectoryEntry().Properties["memberOf"].Value.ToString();
                                    break;
                                case "Object[]":
                                    object[] memberof = (object[])iter.GetDirectoryEntry().Properties["memberOf"].Value;
                                    member = memberof[0].ToString();
                                    break;
                            }
                            usuarios += member;
                            //usuarios += memberOf[0].ToString();
                        }
                        catch (NullReferenceException)
                        { }
                        usuarios += "\n";
                       // string vs = iter.GetDirectoryEntry().Properties["memberOf"].Value.ToString();
                        //usuarios += vs[0].ToString().Trim() + "\n";
                        //IDictionaryEnumerator d = iter.GetDirectoryEntry().Properties.GetEnumerator();
                        //while (d.MoveNext())
                        //{
                        //    string aa = d.ToString();
                        //}
                        //TableCell cell = new TableCell();
                        //cell.Text = usuario;
                        //row.Cells.Add(cell);
                        //tbl.Rows.Add(row);
                        //usuarios.Add(usuario);
                        
                    }

                    this.txtResultadosApellidosMpba.Text = usuarios;
               

                }

                this.divResulApeMpba.Visible = cant > 0;
        }

        protected void chkMandarMail_CheckedChanged(object sender, EventArgs e)
        {
            this.divMailing.Visible = this.chkMandarMail.Checked;
        }

       private void MandarMailTodos()
        {
            UsuarioAutorizadoList ual = UsuariosAutorizadoManager.GetList();
            foreach (UsuarioAutorizado ua in ual)
            {
                string idusuario=ua.idUsuario.Trim().ToLower();
                //if ( idusuario != "halonso" && idusuario != "jamorin" && idusuario != "gberlasso"  )
                //{
                    //if (idusuario == "gberlasso")
                    //{
                        string mailto = idusuario.Trim() + "@mpba.gov.ar";
                        MandarMail(mailto);
                 //   }
                //}
            }
        }

     

        protected void btnMandarMail_Click(object sender, EventArgs e)
        {
            if (this.txtNombreUsuario.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Nombre de usuario vacio.');", true);
                //this.MsgBoxNoGrabo.Text = "Nombre de usuario vacio.";
                //this.MsgBoxNoGrabo.Visible = true;
                return;
            }
            string mailto = this.txtNombreUsuario.Text.Trim() + "@mpba.gov.ar";
            MandarMail(mailto);
            ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Mail enviado correctamente.');", true);
            //this.MsgBoxNoGrabo.Text = "Mail enviado correctamente";
            //this.MsgBoxNoGrabo.Visible = true;
            //MandarMailTodos();
        }

    }
}
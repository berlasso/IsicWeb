using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPBA.SIAC.Bll;
using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Web
{
    public partial class Usuarios : System.Web.UI.Page
    {
         protected void Page_Load(object sender, EventArgs e)
        {
             if (!Page.IsPostBack)

            {
            //resalta en el menu, el modulo en el que estoy actualmente
            Session["moduloActual"] = "U";
            int idDepartamento;
                    //UsuarioAutorizadoList usuariosList = ( UsuariosAutorizadoManager.GetList());


                    //if (usuariosList != null)
                    //{
                        if (Request.QueryString["idDepartamento"].ToString().Trim() != null)
                        {
                            idDepartamento = Convert.ToInt32(Request.QueryString["idDepartamento"].ToString().Trim());
                            this.ddlDepartamento.SelectedValue = idDepartamento.ToString();
                            this.ddlDepartamento.DataBind();
                            this.gvUsuarios.DataSource = "";

                            if (idDepartamento != 0)
                            {
                                UsuarioAutorizadoList usuariosList = (UsuariosAutorizadoManager.GetList());
                                this.gvUsuarios.DataSource = usuariosList.FindAll(delegate(UsuarioAutorizado aut) { return aut.idDepartamento == idDepartamento; });

                                //else
                                //    this.gvUsuarios.DataSource = usuariosList.FindAll(delegate(UsuarioAutorizado aut) { return aut.activo == true; });

                                //this.gvUsuarios.DataSource = usuariosList;
                                this.gvUsuarios.DataBind();
                                string origen = Request.QueryString["TipoVista"];
                                if (origen != null)
                                {
                                    if (origen == "CON")
                                    {
                                        this.btnNuevo.Visible = false;
                                        this.gvUsuarios.Columns[1].Visible = false;
                                    }
                                    else
                                    {
                                        this.btnNuevo.Visible = true;
                                        this.gvUsuarios.Columns[1].Visible = true;
                                    }
                                }
                                //Session["usuariosAutorizados"] = usuariosList;
                            }
                        }
                        else
                        {
                            Session["moduloActual"] = null;
                            Response.Redirect("~/Home.aspx");
                        }


                   // }
            } 

        }
        protected void gvUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
 
        }
        protected void gvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlDepartamento.SelectedValue != null && this.ddlDepartamento.SelectedValue != "")
            {
                Session["FiltroDeptoUsuarioAutorizado"] = ddlDepartamento.SelectedValue;
                string origen = Request.QueryString["TipoVista"];
                Response.Redirect("~/EditUsuarioAutorizado.aspx?idUsuario=" + this.gvUsuarios.SelectedValue + "&TipoVista=" + origen);
            }
        }
        protected void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            Session["FiltroDeptoUsuarioAutorizado"] = ddlDepartamento.SelectedValue;
            string origen = Request.QueryString["TipoVista"];
            Response.Redirect("~/EditUsuarioAutorizado.aspx?idUsuario=0&TipoVista=" + origen);
        }
        protected void gvUsuarios_Sorting(object sender, GridViewSortEventArgs e)
        {

            if (gvUsuarios.DataSource != null)
            {

                List<UsuarioAutorizado> listUsuarios = gvUsuarios.DataSource as List<UsuarioAutorizado>;


                if (listUsuarios != null)
                {
                    PropertyComparer<UsuarioAutorizado> pc = new PropertyComparer<UsuarioAutorizado>(e.SortExpression, e.SortDirection);
                    listUsuarios.Sort(pc);
                    gvUsuarios.DataSource = listUsuarios;
                    gvUsuarios.DataBind();

                }
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session["moduloActual"] = null;
            Response.Redirect("~/Home.aspx");
        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idDepartamento = Convert.ToInt32(this.ddlDepartamento.SelectedValue);
            //UsuarioAutorizadoList usuariosList = (UsuarioAutorizadoList)Session["usuariosAutorizados"];
            UsuarioAutorizadoList usuariosList = (UsuariosAutorizadoManager.GetList());
            this.gvUsuarios.DataSource = "";
            this.gvUsuarios.DataSource = usuariosList;
            if (idDepartamento != 0)
                this.gvUsuarios.DataSource = usuariosList.FindAll(delegate(UsuarioAutorizado aut) { return aut.activo == true && aut.idDepartamento == idDepartamento; });
            else
                this.gvUsuarios.DataSource = usuariosList.FindAll(delegate(UsuarioAutorizado aut) { return aut.activo == true; });
          
            this.gvUsuarios.DataBind();
            //Session["usuariosAutorizados"] = usuariosList;

        }
        }
    }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPBA.PersonasBuscadas.Bll;
using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.SIAC.Bll;
using MPBA.SIAC.Web;


namespace MPBA.PersonasBuscadas.Web
{
    public partial class BusquedaHalladaBaja : System.Web.UI.Page
    {  
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //resalta en el menu, el modulo en el que estoy actualmente
                Session["moduloActual"] = "BP";
                Session["ippHallada"] = "";
                LimpiarControles();
                this.tcTipoJurisdiccion.Visible = true;
                tpPJ.Visible = true;
                 this.txtIppBuscadoH.Focus();
                txtCoincideIPP.Visible = false;
                LabelCoincidente.Visible = false;
                //SIAC.Web.MasterPage myMaster;
                //myMaster = (SIAC.Web.MasterPage)this.Master;
                //myMaster.btnConfigurarMailPB.Visible = true;
            }
        }

        protected void btnBuscarIppH_Click(object sender, EventArgs e)
        {
            LimpiarControles();

            string ipp = "";
            List<PersonasHalladas> myPersonas = null;
            if (this.tcTipoJurisdiccion.ActiveTab == this.tpPJ)
            {
                ipp = this.txtIppBuscadoH.Text.Trim();
                if (ipp.Length == 0)
                {
                    this.cvCausa.IsValid = false;
                    return;
                }

                myPersonas = PersonasHalladasManager.GetListByIPP(ipp).FindAll(delegate(PersonasHalladas ph) { return (ph.esExtJurisdiccion == null || ph.esExtJurisdiccion == false); });
            }
            else if (this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur)
            {
                ipp = this.txtCausa.Text.Trim();
                if (ipp.Length == 0)
                {
                    this.cvCausa.IsValid = false;
                    return;
                }

                myPersonas = PersonasHalladasManager.GetListByIPP(ipp).FindAll(delegate(PersonasHalladas ph) { return (ph.esExtJurisdiccion != null && ph.esExtJurisdiccion == true); });

            }
            Session["ippHallada"] = ipp ;
            bool esExtJur = this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur;
            if (myPersonas.Count > 0)
            {

                this.gvPersonasH.DataSource = myPersonas;
                this.gvPersonasH.DataBind();
                //this.gvPersonasD.Rows[0].BackColor = Color.FromName("#13507d");
                this.divPersonasH.Style.Remove("display");
                

            }
            else
            {
                
                this.gvPersonasH.DataSource = null;
                this.divPersonasH.Style.Add("display", "none");
                //BuscarIpp(-1, ipp, esExtJur);
                ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('No se encontró el número de causa indicado.');", true);
            }
            //if (this.gvPersonasD.Rows.Count > 0)
            //    this.gvPersonasD.SelectedIndex = 0;
             
            this.btnBorrarH.Enabled = true;
            SetearGvPersonas();
        }

     

        protected void ddlMotivoBaja_Change(object sender, EventArgs e)
        {
            // Hallazgo de Coincidencia con la IPP
            if (ddlMotivoBaja.SelectedItem.Value == "3")
            {   // Coincidencia con IPP 
                // Debo habilitar la ipp con la cual coincide
                LabelCoincidente.Visible = true;
                txtCoincideIPP.Visible = true;
            }
            else
            {
                LabelCoincidente.Visible = false;
                txtCoincideIPP.Visible = false;
            }
        }
        protected void tcTipoJurisdiccion_ActiveTabChanged(object sender, EventArgs e)
        {
            // this.pnlPersonadesaparecida.Enabled = false;
            if (this.tcTipoJurisdiccion.ActiveTab == this.tpPJ)
            {

                LimpiarControles();
                this.txtIppBuscadoH.Focus();
            }
            else if (this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur)
            {

                LimpiarControles();

                this.txtCausa.Focus();
            }


        }

        private void SetearGvPersonas()
        {

                       
                
            foreach (GridViewRow row in this.gvPersonasH.Rows)
            {
                //row.BackColor = System.Drawing.Color.Transparent;
                //row.ForeColor = System.Drawing.Color.Blue;
                int cantPersonasH = this.gvPersonasH.Rows.Count; 
                
                             
            }
            if (this.gvPersonasH.SelectedIndex == -1 && this.gvPersonasH.Rows.Count > 0)
                this.gvPersonasH.SelectedIndex = 0;
            foreach (GridViewRow gvr in this.gvPersonasH.Rows)
            {
                //gvr.BorderColor = System.Drawing.Color.White;
                //gvr.BorderStyle = BorderStyle.Solid;
                //gvr.BorderWidth = 2;

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
            


        }

        protected void btnBorrarH_Click(object sender, EventArgs e)
        { const string COINCIDE_IPP = "3";
          string body, subject, mailto;
            string ippCoincidente = "";
            string mensaje;
            PersonasDesaparecidasList personasDesaparecidasMatch= null;
           
            // Si el Motivo de Baja es Coincidencia en IPP debe definir la IPP DESAPARECIDA coincidente
            if (ddlMotivoBaja.SelectedItem.Value ==COINCIDE_IPP)
            {  
                ippCoincidente = this.txtCoincideIPP.Text.Trim();
                if (ippCoincidente.Length == 0)
                {
                    this.cvCausa.IsValid = false;
                    this.cvCausa.ErrorMessage = "Ingrese la IPP de la causa con la Persona desaparecida coincidente con la hallada";
                    return;
                }
                personasDesaparecidasMatch = PersonasDesaparecidasManager.GetListByIPP(ippCoincidente);
                if (personasDesaparecidasMatch.Count == 0)
                {
                    this.CustomCoincideIPP.IsValid = false;
                    this.CustomCoincideIPP.ErrorMessage = "El número no corresponde a una causa con Personas Desaparecidas!";
                    return;
                }
                        


            }
          

            IEnumerable<int> ids;
            List<int> items = new List<int>();
            bool algunaSeleccion = false;
            for (int i = 0; i < this.gvPersonasH.Rows.Count; i++)
            {
                bool selecciona = ((CheckBox)this.gvPersonasH.Rows[i].FindControl("personaSeleccionada")).Checked;
                if (selecciona )
                {
                    int id = Convert.ToInt32(this.gvPersonasH.DataKeys[i].Value);
                    // Con el id armo un IEnumerable de ids que se convierten en DataTables parametro
                    // del stored Procedure

                    items.Add(id);
                    algunaSeleccion = true;
                }
            }
            if (!algunaSeleccion)
            {
                mensaje = "<script type='text/javascript'>alert('{0}')</script>";
                mensaje = string.Format(mensaje, "Seleccione la Persona que debe dar de Baja");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alerta", mensaje, false);

                return;
            }
                   ids = items;

                   string resultado = PersonaManager.UpdateBaja(Convert.ToString(Session["ippHallada"]), ippCoincidente, Convert.ToInt16(ddlMotivoBaja.SelectedItem.Value), 2, Session["miUsuario"].ToString(), ids);
               
                  if (resultado == "OK")
                  {
                      if (COINCIDE_IPP == ddlMotivoBaja.SelectedItem.Value)
                      {
                          PersonasDesaparecidas perD = personasDesaparecidasMatch.First();
                          mailto = perD.UsuarioUltimaModificacion.Trim()+ "@mpba.gov.ar";
                          body = "El usuario : " + Session["miUsuario"] + " encuentra la Causa con Personas Halladas Nro:" + Session["ippHallada"] + " con coincidencias con la causa de Personas Desaparecidas Nro: " + ippCoincidente + ". Por favor comuniquese con el usuario de mail: " + Session["miUsuario"] + "@mpba.gov.ar a la brevedad, para saber si corresponde dar de baja la causa con Personas Desaparecidas.";
                          subject = "IPP Nro:" + Session["ippHallada"] + " de Personas Halladas coincidente con la causa:" + ippCoincidente;

                          if (FuncionesGenerales.Produccion())
                          {   // En Produccion le envia un mail al usuario  que cargo a la Persona Desaparecida
                             
                              if (perD.UsuarioUltimaModificacion != null)
                              {
                                 MPBA.SIAC.Web.FuncionesGenerales.EnvioMails(mailto, body, subject);
                              }
                          }

                          else
                          {
                              mailto = "msibretti@mpba.gov.ar";
                              MPBA.SIAC.Web.FuncionesGenerales.EnvioMails(mailto, body, subject);
                          }
                          
                        }
                      mensaje = "<script type='text/javascript'>alert('{0}')</script>";
                      mensaje = string.Format(mensaje, "Baja Lógica Exitosa.");
                   
                  }
                  else
                  {
                      mensaje = "<script type='text/javascript'>alert('{0}')</script>";
                      mensaje = string.Format(mensaje, "No se dio de Baja exitosamente. Comuníquese con el equipo de desarrollo del SIAC");
                     
                  }

                           
                  ScriptManager.RegisterStartupScript(this, typeof(Page), "Alerta", mensaje, false);

                  Session["moduloActual"] = "BP";
                  LimpiarControles();
                  Nuevo();

            }
        

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session["moduloActual"] = null;//no resalta menu
            Response.Redirect("~/Home.aspx");
        }



        private void Nuevo()
        {
            this.txtIppBuscadoH.Text = "";
            this.txtCausa.Text = "";
            ddlMotivoBaja.SelectedIndex = 1;
            LabelCoincidente.Visible = false;
            txtCoincideIPP.Visible = false;
            this.txtCoincideIPP.Text = "";
          
            tcTipoJurisdiccion.Visible = true;
            Session["ippHallada"] = "";
        }

        
        private void LimpiarControles()
        {
            this.divPersonasH.Style.Add("display", "none");
            this.btnBorrarH.Enabled = false;
        }

    }
}
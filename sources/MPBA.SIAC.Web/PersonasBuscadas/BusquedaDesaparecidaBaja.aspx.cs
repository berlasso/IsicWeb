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
    public partial class BusquedaDesaparecidaBaja : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //resalta en el menu, el modulo en el que estoy actualmente
                Session["moduloActual"] = "BP";
                LimpiarControles();
                this.txtIppBuscadoD.Focus();
                //SIAC.Web.MasterPage myMaster;
                //myMaster = (SIAC.Web.MasterPage)this.Master;
                //myMaster.btnConfigurarMailPB.Visible = true;
            }
        }

        protected void btnBuscarIppD_Click(object sender, EventArgs e)
        {
            LimpiarControles();

            string ipp = "";
            List<PersonasDesaparecidas> myPersonas = null;
            if (this.tcTipoJurisdiccion.ActiveTab == this.tpPJ)
            {
                ipp = this.txtIppBuscadoD.Text.Trim();
                if (ipp.Length == 0)
                {
                    this.cvIppD.IsValid = false;
                    return;
                    
                }

                myPersonas = PersonasDesaparecidasManager.GetListByIPP(ipp).FindAll(delegate(PersonasDesaparecidas pd) {return pd.esExtJurisdiccion == null || pd.esExtJurisdiccion == false; });
            }
            else if (this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur)
            {
                ipp = this.txtCausa.Text.Trim();
                if (ipp.Length == 0)
                {
                    this.cvCausa.IsValid = false;
                    return;
                }

                myPersonas = PersonasDesaparecidasManager.GetListByIPP(ipp).FindAll(delegate(PersonasDesaparecidas pd) { return pd.Baja == false && (pd.esExtJurisdiccion != null && pd.esExtJurisdiccion == true); });

            }
            Session["ippDesaparecida"] = ipp;
            bool esExtJur = this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur;
            if (myPersonas.Count > 0)
            {

                this.gvPersonasD.DataSource = myPersonas;
                this.gvPersonasD.DataBind();
                //this.gvPersonasD.Rows[0].BackColor = Color.FromName("#13507d");
                this.divPersonasD.Style.Remove("display");
                this.btnBorrarD.Enabled = true;

            }
            else
            {
                this.btnBorrarD.Enabled = false;
                this.gvPersonasD.DataSource = null;
                this.divPersonasD.Style.Add("display", "none");
                //BuscarIpp(-1, ipp, esExtJur);
                ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('No se encontró el número de causa indicado.');", true);
            }
            //if (this.gvPersonasD.Rows.Count > 0)
            //    this.gvPersonasD.SelectedIndex = 0;


            SetearGvPersonas();
        }


        protected void tcTipoJurisdiccion_ActiveTabChanged(object sender, EventArgs e)
        {
            // this.pnlPersonadesaparecida.Enabled = false;
            if (this.tcTipoJurisdiccion.ActiveTab == this.tpPJ)
            {

                LimpiarControles();
                this.txtIppBuscadoD.Focus();
            }
            else if (this.tcTipoJurisdiccion.ActiveTab == this.tpExtJur)
            {

                LimpiarControles();

                this.txtCausa.Focus();
            }


        }

        private void SetearGvPersonas()
        {
            foreach (GridViewRow row in this.gvPersonasD.Rows)
            {
                //row.BackColor = System.Drawing.Color.Transparent;
                //row.ForeColor = System.Drawing.Color.Blue;
                int cantPersonasD = this.gvPersonasD.Rows.Count;

            }
            if (this.gvPersonasD.SelectedIndex == -1 && this.gvPersonasD.Rows.Count > 0)
                this.gvPersonasD.SelectedIndex = 0;
            foreach (GridViewRow gvr in this.gvPersonasD.Rows)
            {
                //gvr.BorderColor = System.Drawing.Color.White;
                //gvr.BorderStyle = BorderStyle.Solid;
                //gvr.BorderWidth = 2;

                foreach (TableCell c in gvr.Cells)
                {
                    TableCell celda = c;
                    switch (((DataControlFieldCell)c).ContainingField.ToString().Trim().ToUpper())
                    {
                        case "FECHA DESAP.":
                            if (c.Text != null)
                            {
                                DateTime dtDesap;
                                if (DateTime.TryParse(c.Text, out dtDesap))
                                {
                                    //c.CssClass = "CeldaColor";
                                    c.Text = dtDesap.ToString("dd/MM/yyyy");
                                }
                                else
                                    c.Text = "";
                                //c.DataBind();
                            }
                            break;
                    }
                }


            }



        }

        protected void btnBorrarD_Click(object sender, EventArgs e)
        {
            const string COINCIDE_IPP = "3";
            string body, subject, mailto;
            string ippCoincidente = "";
            string mensaje;
            PersonasHalladasList personasHalladasMatch = null;

            // Si el Motivo de Baja es Coincidencia en IPP debe definir la IPP DESAPARECIDA coincidente
            if (ddlMotivoBaja.SelectedItem.Value == COINCIDE_IPP)
            {
                ippCoincidente = this.txtCoincideIPP.Text.Trim();
                if (ippCoincidente.Length == 0)
                {
                    this.cvCausa.IsValid = false;
                    this.cvCausa.ErrorMessage = "Ingrese la IPP de la causa con la Persona Hallada coincidente con la Desaparecida";
                    return;
                }
                personasHalladasMatch = PersonasHalladasManager.GetListByIPP(ippCoincidente);
                if (personasHalladasMatch.Count == 0)
                {
                    this.CustomCoincideIPP.IsValid = false;
                    this.CustomCoincideIPP.ErrorMessage = "El número no corresponde a una causa con Personas Halladas!";
                    return;
                }



            }


            IEnumerable<int> ids;
            List<int> items = new List<int>();
            bool algunaSeleccion = false;
            for (int i = 0; i < this.gvPersonasD.Rows.Count; i++)
            {
                bool selecciona = ((CheckBox)this.gvPersonasD.Rows[i].FindControl("personaSeleccionada")).Checked;
                if (selecciona)
                {
                    int id = Convert.ToInt32(this.gvPersonasD.DataKeys[i].Value);
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




            string resultado = PersonaManager.UpdateBaja(ippCoincidente, Convert.ToString(Session["ippDesaparecida"]), Convert.ToInt16(ddlMotivoBaja.SelectedItem.Value), 1, Session["miUsuario"].ToString(), ids);

            if (resultado == "OK")
            {
                // Envia mails si esta en Produccion
                if (COINCIDE_IPP == ddlMotivoBaja.SelectedItem.Value)
                {
                    PersonasHalladas perD = personasHalladasMatch.First();
                    mailto = perD.UsuarioUltimaModificacion.Trim() + "@mpba.gov.ar";

                    body = "El usuario : " + Session["miUsuario"] + " encuentra la Causa con Personas Desaparecidas Nro:" + Session["ippDesaparecida"] + " con personas coincidentes en la causa de Personas Halladas Nro: " + ippCoincidente + ". Por favor comuniquese con el usuario de mail: " + Session["miUsuario"] + "@mpba.gov.ar a la brevedad, para saber si corresponde dar de baja la causa con Personas Halladas .";
                    subject = "IPP Nro:" + Session["ippDesaparecida"] + " de Personas Desaparecidas coincidente con la causa:" + ippCoincidente;
                    if (FuncionesGenerales.Produccion())
                        // En Produccion le envia un mail al usuario  que cargo a la Persona Desaparecida

                        if (perD.UsuarioUltimaModificacion != null)
                        {
                            MPBA.SIAC.Web.FuncionesGenerales.EnvioMails(mailto, body, subject);
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

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session["moduloActual"] = null;//no resalta menu
            Response.Redirect("~/Home.aspx");
        }


        private void Nuevo()
        {
            this.txtIppBuscadoD.Text = "";
            this.txtCausa.Text = "";
            Session["ippDesaparecida"] = "";
            ddlMotivoBaja.SelectedIndex = 1;
            this.txtIppBuscadoD.Focus();
            LabelCoincidente.Visible = false;
            txtCoincideIPP.Visible = false;
            this.txtCoincideIPP.Text = "";
        }

        private void LimpiarControles()
        {
            this.divPersonasD.Style.Add("display", "none");
            this.btnBorrarD.Enabled = false;



        }


    }
}
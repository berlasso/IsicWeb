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
    public partial class Baja : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.rblTipoAutor.SelectedIndex = 0;
                string tipo = Request.QueryString["tipo"];
                switch (tipo)
                {
                    case "1":
                        //resalta en el menu, el modulo en el que estoy actualmente
                        Session["moduloActual"] = "RH";
                        this.cartelConsultando.InnerText = "BAJA DE ROBOS Y HURTOS";
                        break;
                    case "2":
                        //resalta en el menu, el modulo en el que estoy actualmente
                        Session["moduloActual"] = "DS";
                        this.cartelConsultando.InnerText = "BAJA DE DELITOS SEXUALES";
                        break;
                }
                
                LimpiarControles();
                this.txtIppBuscado.Focus();
             
            }
        }

        protected void btnBuscarIpp_Click(object sender, EventArgs e)
        {
            //LimpiarControles();
            bool ippEncontrada= BuscarIpp(this.txtIppBuscado.Text.Trim());
            this.btnBorrar.Enabled = ippEncontrada;
            if (!ippEncontrada)
                ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('No se encontro la IPP ingresada.');", true);
            //this.lblDelitoEncontrado.Visible = ippEncontrada;
            if (ippEncontrada)
            {
            BuscarDelitoEnWebService(this.txtIppBuscado.Text.Trim());
            }
            this.divBaja.Visible = ippEncontrada;
           
        }

        /// <summary>
        /// Busca la ipp ingresada, devuelve false si la ipp no pertenece al tipo de NN actual
        /// </summary>
        /// <param name="ipp">Ipp a buscar</param>
        private bool BuscarIpp(string ipp)
        {
            Delitos miDelito;
            miDelito = DelitosManager.GetItemByIdCausa(ipp, true);
            if (miDelito == null)
            {
                string msg = "IPP inexistente.";
                ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('" + msg + "');", true);
                return false;
            }
            int idClaseDelito = Convert.ToInt32(Request.QueryString["tipo"]);
            //*****CONTROLA SI ESTA DADO DE BAJA
            if (miDelito != null && miDelito.Baja == true)
            {
                string msg = "La IPP ya fue dada de Baja.";
                ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('" + msg + "');", true);
                miDelito = null;
                return false;
            }
            //*****CONTROLA SI ES DELITO SEXUAL O ROBOS Y HURTOS
            if (miDelito != null && idClaseDelito != miDelito.idClaseDelito)
            {
                string msg = "La IPP pertenece a " + NNClaseTipoDelitoManager.GetItem(miDelito.idClaseDelito).descripcion.Trim() + ".";
                ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('" + msg + "');", true);
                miDelito = null;
                return false;
            }
            int tipoAutorPagina = 0;
            switch (this.rblTipoAutor.SelectedIndex)
            {
                case 0:
                    tipoAutorPagina = 1;//ignorado
                    break;
                case 1:
                    tipoAutorPagina = 2;//aprehendido
                    break;
            }
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
           

            if (miDelito == null)
            {
                miDelito = new Delitos();
                miDelito.idClaseDelito = idClaseDelito;
                miDelito.id = -1;
            }
            Session["miDelito"] = miDelito;
           
           
            return true;
        }
       

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            if (this.txtMotivoBaja.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Debe indicar el motivo de la baja.');", true);
                return;
            }
            Delitos miDelito =(Delitos)Session["miDelito"];
            if (miDelito != null)
            {
                miDelito.motivoBaja = this.txtMotivoBaja.Text.Trim();
                miDelito.FechaBaja = DateTime.Now;
                miDelito.Baja = true;
                if (DelitosManager.Save(miDelito) > 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Alerta", "alert('Baja exitosa.');", true);
                    Session["miDelito"] = null;
                    LimpiarControles();
                }
            }

        

        }





       

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session["moduloActual"] = null;//no resalta menu
            Response.Redirect("~/Home.aspx");
        }


     

        private void LimpiarControles()
        {
            this.btnBorrar.Enabled = false;
            this.divBaja.Visible = false;
            this.txtMotivoBaja.Text = "";
            this.txtIppBuscado.Text = "";

        }

        protected void rblTipoAutor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.divBaja.Visible = false;
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

            catch { System.Web.Services.Protocols.SoapException ex; }
            // this.pnlVictimasGral.Enabled = true;
            this.gvVictimas.DataBind();
            this.gvDelitos.DataBind();

        }
     


    }
}
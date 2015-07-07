using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPBA.PersonasBuscadas.Bll;
using MPBA.PersonasBuscadas.BusinessEntities;

namespace MPBA.PersonasBuscadas.Web
{
    public partial class BusquedasFiscalia : System.Web.UI.Page
    {
        #region "Variables"

        static int CantDiasBusqActiva = 0;//Cantidad de dias tomados de los Parametros Grales. en que la busqueda se encuentra vigente
        
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["miUfi"] = "xx";
            //*********************
            if (!IsPostBack)
            {
                this.pnlBusquedasActivas.Style.Add("display", "none");
                this.pnlBusquedasViejas.Style.Add("display", "none");
                CantDiasBusqActiva = PBParametrosGeneralesManager.GetList()[0].CantMaxDiasBusquedaActiva;
                RefrescarEstadoBusquedasActivas();
            }
        }

        protected void btnBusquedasPendientes_Click(object sender, EventArgs e)
        {
           
            AbrirBusquedasPendientes();
        }
        /// <summary>
        /// Abre las busquedas que hay pendientes
        /// </summary>
        public void AbrirBusquedasPendientes()
        {
            this.gvBusqActivas.Visible = false;
            this.hfBusquedasActivas_ModalPopupExtender.Show();
        }

        protected void btnBusquedasViejas_Click(object sender, EventArgs e)
        {
            //ControlarDuracionBusquedasActivas();
        }
        protected void gvBusquedasViejas_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MPBA.PersonasBuscadas.BusinessEntities.Busqueda myBusquedaVieja = MPBA.PersonasBuscadas.Bll.BusquedaManager.GetItem(Convert.ToInt32(this.gvBusquedasViejas.SelectedDataKey.Value));//ID
            //this.gvBusquedasViejas.SelectedRow.Visible = false;
            //int cantFilas = 0;
            //foreach (GridViewRow row in this.gvBusquedasViejas.Rows)
            //{
            //    if (row.Visible == true)
            //        cantFilas++;
            //}
            //this.lblCantBusqViejas.Text = cantFilas.ToString();
            //if (ActualizarFechaBV == false)
            //{

            //    MPBA.PersonasBuscadas.Bll.BusquedaManager.Delete(myBusquedaVieja);
            //}
            //else
            //{
            //    myBusquedaVieja.FechaUltimaModificacion = DateTime.Today;
            //    //MPBA.PersonasBuscadas.Bll.BusquedaManager.Save(myBusquedaVieja);
            //}
            //if (cantFilas == 0)
            //{
            //    this.btnBusquedasViejas.Style.Remove("display");
            //    this.hfGestionBV_ModalPopupExtender.Hide();
            //}

        }
        protected void gvBusquedasViejas_RowEditing(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// Controla la duracion de las busquedas activas
        /// </summary>
        //public void ControlarDuracionBusquedasActivas()
        //{
        //    //********************
        //    //CONTROLAR
        //    //int cantDias = 15;
        //    //*********************
        //    List<MPBA.PersonasBuscadas.BusinessEntities.Busqueda> busquedasViejas = MPBA.PersonasBuscadas.Bll.BusquedaManager.GetList().FindAll(delegate(MPBA.PersonasBuscadas.BusinessEntities.Busqueda bs) { return bs.UFI.Trim() == Session["miUFI"].ToString().Trim() && bs.Baja == false && (DateTime.Today.Subtract((bs.FechaUltimaModificacion))).Days > CantDiasBusqActiva; });
        //    //MPBA.PersonasBuscadas.Web.MasterPage miMaster = (MPBA.PersonasBuscadas.Web.MasterPage)this.Master;
        //    if (busquedasViejas.Count > 0)
        //    {
        //        this.lblCantBusqViejas.Text = busquedasViejas.Count.ToString();
        //        this.gvBusquedasViejas.DataSource = busquedasViejas;
        //        this.gvBusquedasViejas.DataBind();
        //        this.gvBusquedasViejas.Visible = true;
        //        this.pnlBusquedasViejas.Visible = true;
        //        this.pnlBusquedasViejas.Style.Remove("display");
        //        this.hfGestionBV_ModalPopupExtender.Show();
        //    }
        //    else
        //        this.btnBusquedasViejas.Style.Add("display", "none");

        //}
        protected void btnCoincidenciasEncontradas_Click(object sender, EventArgs e)
        {

        }

        protected void btnBusDesap_Click(object sender, EventArgs e)
        {
            //retorna las búsquedas de la UFI que está consultando, que no han sido dados de baja y cuya vigencia en días no supera el máxio establecido por parámetro
            List<MPBA.PersonasBuscadas.BusinessEntities.Busqueda> busqDesap = MPBA.PersonasBuscadas.Bll.BusquedaManager.GetList().FindAll(delegate(MPBA.PersonasBuscadas.BusinessEntities.Busqueda bs) { return bs.UFI.Trim() == Session["miUFI"].ToString().Trim() && bs.Baja == false; }).FindAll(delegate(MPBA.PersonasBuscadas.BusinessEntities.Busqueda bs) { return bs.idOrigen == 1 && (DateTime.Today.Subtract((bs.FechaUltimaModificacion))).Days < CantDiasBusqActiva; });
            this.gvBusqActivas.DataSource = busqDesap;
            this.gvBusqActivas.DataBind();
            this.gvBusqActivas.Visible = true;
        }
        public void RefrescarEstadoBusquedasActivas()
        {
            int cantTotal = MPBA.PersonasBuscadas.Bll.BusquedaManager.GetList().FindAll(delegate(MPBA.PersonasBuscadas.BusinessEntities.Busqueda bs) { return bs.UFI.Trim() == Session["miUFI"].ToString().Trim() && bs.Baja == false && (DateTime.Today.Subtract((bs.FechaUltimaModificacion))).Days < CantDiasBusqActiva; }).Count<MPBA.PersonasBuscadas.BusinessEntities.Busqueda>();
            int cantDesap = MPBA.PersonasBuscadas.Bll.BusquedaManager.GetList().FindAll(delegate(MPBA.PersonasBuscadas.BusinessEntities.Busqueda bs) { return bs.UFI.Trim() == Session["miUFI"].ToString().Trim() && bs.Baja == false && bs.idOrigen == 1 && (DateTime.Today.Subtract((bs.FechaUltimaModificacion))).Days < CantDiasBusqActiva; }).Count<MPBA.PersonasBuscadas.BusinessEntities.Busqueda>();
            int cantHalladas = MPBA.PersonasBuscadas.Bll.BusquedaManager.GetList().FindAll(delegate(MPBA.PersonasBuscadas.BusinessEntities.Busqueda bs) { return bs.UFI.Trim() == Session["miUFI"].ToString().Trim() && bs.Baja == false && bs.idOrigen == 2 && (DateTime.Today.Subtract((bs.FechaUltimaModificacion))).Days < CantDiasBusqActiva; }).Count<MPBA.PersonasBuscadas.BusinessEntities.Busqueda>();
            //MPBA.PersonasBuscadas.Web.MasterPage miMaster = (MPBA.PersonasBuscadas.Web.MasterPage)this.Master;
            this.btnBusquedasPendientes.Text = cantTotal.ToString() + " Búsquedas Activas";
            this.lblDesapCant.Text = cantDesap.ToString();
            this.lblHalladasCant.Text = cantHalladas.ToString();
            this.btnDetalleBusHalladas.Visible = (cantHalladas > 0);
            this.btnBusDesap.Visible = (cantDesap > 0);
            if (cantTotal > 0)
            {
                this.btnBusquedasPendientes.Style.Remove("display");
            }
            else
            {
                this.btnBusquedasPendientes.Style.Add("display", "none");
                this.btnCoincidenciasEncontradas.Style.Add("display", "none");
            }
        }


        protected void btnDetalleBusHalladas_Click(object sender, EventArgs e)
        {
            List<MPBA.PersonasBuscadas.BusinessEntities.Busqueda> busqHalladas = MPBA.PersonasBuscadas.Bll.BusquedaManager.GetList().FindAll(delegate(MPBA.PersonasBuscadas.BusinessEntities.Busqueda bs) { return bs.UFI.Trim() == Session["miUFI"].ToString().Trim() && bs.Baja == false; }).FindAll(delegate(MPBA.PersonasBuscadas.BusinessEntities.Busqueda bs) { return bs.idOrigen == 2 && (DateTime.Today.Subtract((bs.FechaUltimaModificacion))).Days < CantDiasBusqActiva; });
            this.gvBusqActivas.DataSource = busqHalladas;
            this.gvBusqActivas.DataBind();
            this.gvBusqActivas.Visible = true;
        }

        protected void btnCerrarBA_Click(object sender, EventArgs e)
        {
            this.gvBusqActivas.Visible = false;
            this.pnlBusquedasActivas.Style.Add("display", "none");
            this.hfBusquedasActivas_ModalPopupExtender.Hide();
        }

        protected void gvBusqActivas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void gvBusqActivas_RowEditing(object sender, EventArgs e)
        {

        }
        protected void btnActualizarBV_Click(object sender, EventArgs e)
        {

        }
        protected void btnBorrarBV_Click(object sender, EventArgs e)
        {

        }
        protected void btnCerrarBV_Click(object sender, EventArgs e)
        {
            this.gvBusquedasViejas.Visible = false;
            this.pnlBusquedasViejas.Style.Add("display", "none");
            this.hfGestionBV_ModalPopupExtender.Hide();
        }
    }
}

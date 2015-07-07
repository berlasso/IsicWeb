using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPBA.SIAC.BusinessEntities;
using Subgurim.Controles;
using System.Data;

namespace MPBA.SIAC.Web
{
    public partial class VisualizaMapa : System.Web.UI.Page
    {
        List<GoogleMarker> marcadores = null;
        DataTable dtResultados =null ;

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.b_print.Attributes.Add("onclick", "javascript:printdiv('idPrintArea');");
           // string mi= VirtualPathUtility.ToAbsolute("~/App_Images/exito.png");
            if (!Page.IsPostBack)
            {
                
                string cantidadRegistros = (String)Session["CantidadResultados"];
                string simbolo = Request.QueryString["simbolos"].ToString();
                if (simbolo =="N") 
                {
                    this.legenda.Style.Add("display", "none");
                }
                int resultado = 0;
                int cantValida;
                cantValida = 0;
                marcadores = (List<GoogleMarker>)Session["MarcadoresGoogle"];
                dtResultados = (DataTable)Session["Resultados"];

                if (marcadores == null || marcadores.Count == 0)
                    return;
                // Hay que calcular la longitud y latitud de las direcciones que se pueda
                // Por defecto OK
                // Posibles valores de retorno
                // resultado = 0   ok
                // resultado =-1  Error con el acceso a la URL
                // resultado = 1;  La direccion no es valida

                marcadores = GoogleRepositorio.GetMarcadores(marcadores, out resultado);
                // Las direcciones invalidas se borrian


                // Recorro los marcadores 
                // Donde se ubicara el InfoWindow, texto html, si se abre el infowindow cuando se abre la aplicacion, si no , el evento que lo dispara

                GLatLng latlng = null;
                List<GLatLng> puntos = new List<GLatLng>();
                foreach (var g in marcadores)
                {
                    if (g.Latitude == 0)
                    { continue; }
                    latlng = new GLatLng(g.Latitude, g.Longitude);




                    GIcon icon = new GIcon();

                    // icon.image = "http://" + Request.Url.Host + ":" + Request.Url.Port + Page.ResolveUrl("/App_Images/auto.png");
                    if (simbolo == "N" || simbolo == null)
                    {
                        icon.image = ResolveClientUrl("~/App_Images/" + "googleMarker.png");
                        icon.iconSize = new GSize(12, 20);
                    }
                    else
                    {
                        icon.image = ResolveClientUrl("~/App_Images/" + g.imagen);
                        icon.iconSize = new GSize(32, 32);
                    }

                    //   icon.image = HttpRuntime.AppDomainAppPath + "\\App_Images\\clouds_amarilla.png";


                    //   icon.shadow = "http://labs.google.com/ridefinder/images/mm_20_shadow.png";

                    //  icon.shadowSize = new GSize(22, 20);
                    icon.iconAnchor = new GPoint(6, 27);
                    icon.infoWindowAnchor = new GPoint(5, 1);
                    GMarkerOptions mOpts = new GMarkerOptions();
                    mOpts.clickable = true;
                    mOpts.icon = icon;

                    GMarker marker = new GMarker(latlng, mOpts);
                    GInfoWindowOptions windowOptions = new GInfoWindowOptions();
                    GInfoWindow commonInfoWindow = new GInfoWindow(marker, g.InfoWindow);
                    GMap1.setCenter(latlng, 5, GMapType.GTypes.Normal);
                    GMap1.Add(commonInfoWindow);
                    GMap1.Add(marker);
                    cantValida++;

                }

                this.GMap1.Height = 700;
                GMap1.Width = 980;
                this.lblCantResultados.Text = "Direcciones Válidas: " + cantValida + " de un total de " + dtResultados.Rows.Count.ToString() + " registros.";
                // Hago centro en el promedio
                //GMap1.setCenter(new GLatLng((promedioLat / marcadores.Count), (promedioLong / marcadores.Count)), 5, GMapType.GTypes.Normal);

                GMap1.GZoom = 12;

                /*Control de zoom y movimiento dentro del mapa de Google*/
                GControl control = new GControl(GControl.preBuilt.LargeMapControl);
                GControl control2 = new GControl(GControl.preBuilt.MenuMapTypeControl, new GControlPosition(GControlPosition.position.Top_Right));

                GMap1.Add(control);
                GMap1.Add(control2);
                GMap1.Add(new GControl(GControl.preBuilt.GOverviewMapControl, new GControlPosition(GControlPosition.position.Bottom_Left)));
                Session["MarcadoresGoogle"] = marcadores;
                Session["Resultados"] = dtResultados;
            
            }
        }

        protected void btnOkay_Click(object sender, EventArgs e)
        {
            Session["MarcadoresGoogle"] =null;
            Session["Resultados"] = null;
            Session["CantidadResultados"] = null;
           // ClientScript.RegisterStartupScript(typeof(Page), "closePage", "<script type='text/JavaScript'>window.close();</script>");
            Response.Redirect("./AutoresIgnorados/BusquedaAutores.aspx?tipo=21&tipob=1&resultados=3");                      
        }
  

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
           

        }


        
    }
}
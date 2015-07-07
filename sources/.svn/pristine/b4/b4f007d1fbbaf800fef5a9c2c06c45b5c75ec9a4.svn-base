using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;
using System.Drawing;

namespace MPBA.SIAC.Web
{
    public partial class Manuales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Request.QueryString["manual"].ToString() == "SEP")
            //{

            //}
            Session["moduloActual"] = "D";
            cargarManuales();
            cargarVideos();
        }

        private void cargarVideos()
        {
            string AppPath = Request.PhysicalApplicationPath;
            string directory = AppPath + "manuales\\";
            string[] filePaths = Directory.GetFiles(@directory, "*.swf", SearchOption.AllDirectories);
            List<LinkToManualVideo> listaVideos = new List<LinkToManualVideo>();
            foreach (string filePath in filePaths)
            {
                LinkToManualVideo v = new LinkToManualVideo();
                v.Nombre = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                v.Nombre = v.Nombre.Remove(v.Nombre.LastIndexOf("."));
                v.Link = filePath.Substring(AppPath.Length);
                v.Link = v.Link.Replace("\\", "/");
                listaVideos.Add(v);
            }
            if (listaVideos.Count > 0)
            {
                GridViewVideos.DataSource = listaVideos;
                GridViewVideos.DataBind();
            }
            else
            {
                GridViewVideos.Visible = false;
            }
        }

        private void cargarManuales()
        {
            string AppPath = Request.PhysicalApplicationPath;
            string directory = AppPath + "manuales\\";
            string[] filePaths = Directory.GetFiles(@directory, "*.pdf", SearchOption.AllDirectories);
            List<LinkToManualVideo> listaVideos = new List<LinkToManualVideo>();
            foreach (string filePath in filePaths)
            {
                LinkToManualVideo v = new LinkToManualVideo();
                v.Nombre = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                v.Nombre = v.Nombre.Remove(v.Nombre.LastIndexOf("."));
                v.Link = filePath.Substring(AppPath.Length);
                v.Link = v.Link.Replace("\\", "/");
                listaVideos.Add(v);
            }
            if (listaVideos.Count > 0)
            {
                GridViewManuales.DataSource = listaVideos;
                GridViewManuales.DataBind();
            }
            else
            {
                GridViewManuales.Visible = false;
            }
        }

        private class LinkToManualVideo
        {
            public string Nombre { get; set; }
            public string Link { get; set; }
        }
    }
    
}
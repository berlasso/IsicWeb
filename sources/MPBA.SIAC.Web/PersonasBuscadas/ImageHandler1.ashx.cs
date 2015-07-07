using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPBA.PersonasBuscadas.Bll;
using MPBA.PersonasBuscadas.BusinessEntities;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Mail;
using System.Xml;
using System.Data;
using MPBA.SIAC.Bll;
using System.Windows.Forms;
using MPBA.SIAC.BusinessEntities;
using MPBA.PersonasBuscadas.Web;

namespace MPBA.SIAC.Web.PersonasBuscadas
{
    /// <summary>
    /// Summary description for ImageHandler1
    /// </summary>
    public class ImageHandler1 : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/jpeg";
            string t = context.Request.QueryString["t"];//tipo de foto
            string p = context.Request.QueryString["p"];//si es pers hallada o desap
            string esBI=context.Request.QueryString["bi"];//si es foto de pantalla principal o de coincidencias encontradas
            if (t == null)
                return;
            int tipoFoto=Convert.ToInt16(t);
            
             PBFotos f=null;
             switch (p)
             {
                 case "d":
                     if (esBI == "f")
                     {
                         BindingSource fotosGralesD = (BindingSource)context.Session["FotosGralesD"];
                         BindingSource fotosSeniasD = (BindingSource)context.Session["FotosSeniasD"];
                         switch (tipoFoto)
                         {
                             case (int)FuncionesGrales.TipoFoto.General:
                                 f = (PBFotos)fotosGralesD.Current;
                                 break;
                             case (int)FuncionesGrales.TipoFoto.SeniasParticulares:
                                 f = (PBFotos)fotosSeniasD.Current;
                                 break;
                         }
                     
                    
                     }

                     
                     break;
                 case "h":
                     if (esBI == "f")
                     {
                         BindingSource fotosGralesH = (BindingSource)context.Session["FotosGralesH"];
                         BindingSource fotosSeniasH = (BindingSource)context.Session["FotosSeniasH"];
                         BindingSource fotosHuellasH = (BindingSource)context.Session["FotosHuellasH"];
                         switch (tipoFoto)
                         {
                             case (int)FuncionesGrales.TipoFoto.General:
                                 f = (PBFotos)fotosGralesH.Current;
                                 break;
                             case (int)FuncionesGrales.TipoFoto.SeniasParticulares:
                                 f = (PBFotos)fotosSeniasH.Current;
                                 break;
                             case (int)FuncionesGrales.TipoFoto.Huellas:
                                 f = (PBFotos)fotosHuellasH.Current;
                                 break;
                         }
                     }
                     break;
                  
             }

             if ((p == "d" || p == "h") && esBI == "t")
             {
                 BindingSource fotosGralesBI = (BindingSource)context.Session["FotosGralesBI"];
                 BindingSource fotosSeniasBI = (BindingSource)context.Session["FotosSeniasBI"];
                 switch (tipoFoto)
                 {
                     case (int)FuncionesGrales.TipoFoto.General:
                         f = (PBFotos)fotosGralesBI.Current;
                         break;
                     case (int)FuncionesGrales.TipoFoto.SeniasParticulares:
                         f = (PBFotos)fotosSeniasBI.Current;
                         break;
                 }
             }

            if (f!=null)
                context.Response.BinaryWrite(f.Foto);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
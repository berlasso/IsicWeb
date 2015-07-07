using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using Quartz;
using System.Net.Mail;
using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Bll;
using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Bll;
using System.Collections;
using System.Net.Mime;
using System.Drawing;
using System.Drawing.Imaging;
using Quartz.Impl;
namespace MPBA.SIAC.Web.PersonasBuscadas
{
    public partial class MailTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            ISchedulerFactory schedFact;
            IScheduler sched;
            schedFact = new StdSchedulerFactory();
            sched = schedFact.GetScheduler();
            DateTime fechaMacheos = DateTime.Now.Add(new TimeSpan(0, 2, 0));
            Trigger trigger = TriggerUtils.MakeDailyTrigger(fechaMacheos.Hour, fechaMacheos.Minute);
            JobDetail jdBusquedaCoincidencias = new JobDetail(Guid.NewGuid().ToString(), null, typeof(MPBA.PersonasBuscadas.Web.BuscarCoincidenciasJob));
            jdBusquedaCoincidencias.JobDataMap["sched"] = sched;
            trigger.Name = Guid.NewGuid().ToString();
            sched.ScheduleJob(jdBusquedaCoincidencias, trigger);
        
            //BuscarCoincidencias(fechaMacheos);

        }
        private void BuscarCoincidencias(DateTime fecha)
        {
            ArrayList personasH = new ArrayList();
            ArrayList personasD = new ArrayList();
            //List<JobDetail> ListadoMailsParaMandar = new List<JobDetail>();
            BusquedaList ListadoBusquedas = BusquedaManager.GetListActivas();
            ListadoBusquedas.Sort((x, y) => string.Compare(x.UsuarioUltimaModificacion, y.UsuarioUltimaModificacion));
            foreach (Busqueda busqueda in ListadoBusquedas) //por cada busqueda en el listado total de busquedas
            {
                Busqueda b = new Busqueda();
                b = BusquedaManager.GetItem(busqueda.Id, true);//traigo todos los datos asociados a la busqueda
                b.FechaUltimaModificacion = fecha; //le cambio a la busqueda la fechaultimamodificacion para que me traiga personas cargadas desde la fecha indicada en adelante

                switch (b.idOrigen)
                {
                    case (int)MPBA.PersonasBuscadas.Web.FuncionesGrales.TipoBusqueda.PersonaDesaparecida:
                        PersonasHalladasListMail phl = new PersonasHalladasListMail(b);

                        if (phl.PersonasHalladasMismaBusqueda.Count() > 0)
                            personasH.Add(phl);
                        break;
                    case (int)MPBA.PersonasBuscadas.Web.FuncionesGrales.TipoBusqueda.PersonaHallada:
                        PersonasDesaparecidasListMail pdl = new PersonasDesaparecidasListMail(b);
                        if (pdl.PersonasDesaparecidasMismaBusqueda.Count() > 0)
                            personasD.Add(pdl);
                        break;
                }
            }
            if (personasD.Count > 0 || personasH.Count > 0)
                GestionMails(personasD, personasH);
        }

        /// <summary>
        /// Se manda el mail al usuario indicado
        /// </summary>
        /// <param name="usuario">usuario que va a recibir el mail</param>
        /// <param name="body">el contenido del mail</param>
        private void MandarMail(string usuario, string body, StringBuilder bodyhtml)
        {
            MailMessage Mail  = new MailMessage();
            String myConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[1].ConnectionString;
            MPBA.ConfigurationCL.BusinessObject.ConnectionSring.conexion = myConnectionString;
            //MPBA.ConfigurationCL.BusinessObject.Usuarios userMail = MPBA.ConfigurationCL.BusinessLogic.UsuariosManager.GetItem(usuario.Trim(), true);
            //if (userMail == null)
            //    return;
            //PersonalPoderJudicial ppj = PersonalPoderJudicialManager.GetItem(userMail.IdPersonalPoderJudicial);
            //Persona perMail = PersonaManager.GetItem(ppj.idPersona);
           
            //*******MODIFICADO PARA TESTEO: ****************
            //*******se cambia el mail para recibirlo nosotros y no quien cargo la ipp ****
            //if (perMail.EMail != null)
            //{

                //JobDetail mailParaMandar = new JobDetail(Guid.NewGuid().ToString(), null, typeof(MPBA.SIAC.Web.MailJob));
                //mailParaMandar.JobDataMap["mailto"] = perMail.EMail.Trim();
                //mailParaMandar.JobDataMap["mailto"] = "siac@mpba.gov.ar";
                //mailParaMandar.JobDataMap["subject"] = "SIAC: Coincidencias encontradas al " + DateTime.Today.ToString("dd/MM/yyyy");
                //mailParaMandar.JobDataMap["body"] = body;
                //mailParaMandar.JobDataMap["from"] = "personasbuscadas@mpba.gov.ar";
                Mail.To.Add("meveleens@mpba.gov.ar");
                Mail.From = new  MailAddress("SIAC@mpba.gov.ar");
                Mail.Subject = "SIAC: Coincidencias encontradas al " + DateTime.Today.ToString("dd/MM/yyyy");
                Mail.Body = body;


                AlternateView html = AlternateView.CreateAlternateViewFromString(bodyhtml.ToString(),null,"text/html");
                //LinkedResource img = new LinkedResource(" " + Server.MapPath("~/App_Images/logo_mail.jpg"), MediaTypeNames.Image.Jpeg);
                LinkedResource img = new LinkedResource(" " + HttpContext.Current.Server.MapPath("~/App_Images/logo_mail.jpg"), MediaTypeNames.Image.Jpeg);
                img.ContentId = "imagen"; // Lo incrustamos en la vista HTML...
                html.LinkedResources.Add(img);
                Mail.AlternateViews.Add(html);
                
                //Trigger t = TriggerUtils.MakeImmediateTrigger(1, new TimeSpan(1, 1, 0));
                //t.Name = Guid.NewGuid().ToString();
                //JobDetail mailHTMLParaMandar = new JobDetail(Guid.NewGuid().ToString(), null, typeof(MPBA.SIAC.Web.MailJob));
                ////mailParaMandar.JobDataMap["mailto"] = perMail.EMail.Trim();
                //mailHTMLParaMandar.JobDataMap["mailto"] = "siac@mpba.gov.ar";
                //mailHTMLParaMandar.JobDataMap["subject"] = "SIAC: Coincidencias encontradas al " + DateTime.Today.ToString("dd/MM/yyyy");
                //mailHTMLParaMandar.JobDataMap["BodyFormat"] = "MailFormat.Html";
                //mailHTMLParaMandar.JobDataMap["body"] = body;
                //mailHTMLParaMandar.JobDataMap["from"] = "personasbuscadas@mpba.gov.ar";
                //Trigger t1 = TriggerUtils.MakeImmediateTrigger(1, new TimeSpan(1, 1, 0));
                //t1.Name = Guid.NewGuid().ToString();
                //Sched.ScheduleJob(mailParaMandar, t);//envia inmediatamente el mail
                //Sched.ScheduleJob(mailHTMLParaMandar, t1);//envia inmediatamente el mail html
            //}
            //****************************************************
            //****************************************************
                          

                    SmtpClient sm = new SmtpClient();
                    sm.Host = "smtp.mpba.gov.ar";
                    sm.Send(Mail);

                




        }

        /// <summary>
        /// Arma los mensajes de cada mail y los envia
        /// </summary>
        /// <param name="personasD">las coincidencias de personas desap.</param>
        /// <param name="personasH">las coincidencias de personas halladas</param>
        private void GestionMails(ArrayList personasD, ArrayList personasH)
        {
            //Explicacion: recorro cada busqueda de pd, armo el mensaje con todas las busquedas de pd
            //para el mismo usuario, cuando se terminarion las busq xa ese usuario, me fijo si hay
            //busquedas de ph para este mismo usuario. Si las hay, continuo armando el mensaje y elimino
            //la busqueda de ph xa que solo me queden las de usuarios que no estan en busq de pd. Si no
            //hay busquedas de pd xa ese usuario, comienzo todo el proceso nuevamente para un nuevo usuario.
            //Si al finalizar, me quedaron busquedas en ph, armo los mensajes xa cada usuario en las busquedas de ph.
            string usuario = "";
            string mensaje = "";
            StringBuilder emailHtml = new StringBuilder(File.ReadAllText(Server.MapPath("~/App_UserControl/mail.html")));
            //emailHtml.Replace("[path]", Server.MapPath("~/App_Images/logo_mail.png)"));
            
            string tituloPd = "Personas Desaparecidas\n";
            tituloPd += "----------------------\n";
            string tituloPh = "Personas Halladas\n";
            tituloPh += "-----------------\n";
            string mensajeMail = "";
            if (personasD.Count > 0)
                mensajeMail = tituloPd;

            //PARTE 1: Armado de mensajes xa busquedas de pd y ph del mismo usuario
            for (int i = 0; i <= personasD.Count; i++)//recorro cada resultado de busqueda, que puede contener varios ipps
            {
                PersonasDesaparecidasListMail pdlm = null;
                string htmlDesaparecidas = "";
                if (i < personasD.Count)
                    pdlm = (PersonasDesaparecidasListMail)personasD[i];
                if (pdlm != null)//si no estoy en el ultimo registro
                {
                    
                    usuario = pdlm.UsuarioMail;
                    int cuenta = pdlm.PersonasDesaparecidasMismaBusqueda.Count;
                    for (int j = 0; j < cuenta; j++)//recorro c/u de las coincidencias para la busqueda i
                    {
                        if (mensaje == "")
                        {
                            mensaje = "DESTINATARIO DEL MAIL: " + usuario + ",\n";//esta línea es de testeo de quien debería ser el destinatario del mensaje mientras lo recibamos nosotros en SIAC
                            mensaje = tituloPh + mensaje;
                            emailHtml.Replace("[header hallada]", "Para la Búsqueda asociada a la IPP <B>" + pdlm.IppH.Trim() + "</B> relacionada con la persona hallada <B>" + pdlm.NombrePersonaHallada.Trim() + "</B> se encontraron las siguientes coincidencias en la base de personas desparecidas: ") ;

                        }
                        if (j == 0)//pongo el subtitulo(ipp que genero las coincidencias)
                        {
                            mensaje += "    Para IPP: " + pdlm.IppH.Trim() + ",\n";
                            mensaje += "    Personas Desaparecidas:\n";
                            mensaje += "    -----------------------\n";
                            //Pongo el encabezado de la Tabla
                            htmlDesaparecidas = "<TABLE WIDTH=100% CELLSPACING=0>";
                            htmlDesaparecidas += "<TR> <TD WIDTH=33% STYLE='border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P>IPP </P> </TD>	";	
                            htmlDesaparecidas += "<TD WIDTH=33% STYLE='border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P>Apellido </P> </TD> ";		
                            htmlDesaparecidas += "<TD WIDTH=33% STYLE='border: 1px solid #000000; padding: 0.1cm'> <P>Nombre</P> </TD>	</TR>";
                        }
                        if (pdlm.PersonasDesaparecidasMismaBusqueda[j].esExtJurisdiccion)
                        {
                            mensaje += "        IPP:    " + pdlm.PersonasDesaparecidasMismaBusqueda[j].Ipp + " (ext.Jur.) " + " Nombre: " + pdlm.PersonasDesaparecidasMismaBusqueda[j].Apellido + ", " + pdlm.PersonasDesaparecidasMismaBusqueda[j].Nombre + "\n";
                            htmlDesaparecidas += "<TABLE WIDTH=100% CELLSPACING=0>";
                            htmlDesaparecidas += "<TR> <TD WIDTH=33% STYLE='border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P>" + pdlm.PersonasDesaparecidasMismaBusqueda[j].Ipp + " (ext.Jur.) </P> </TD>	";	
                            htmlDesaparecidas += "<TD WIDTH=33% STYLE='border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P>" + pdlm.PersonasDesaparecidasMismaBusqueda[j].Apellido + "</P> </TD> ";		
                            htmlDesaparecidas += "<TD WIDTH=33% STYLE='border: 1px solid #000000; padding: 0.1cm'> <P>" + pdlm.PersonasDesaparecidasMismaBusqueda[j].Nombre + "</P> </TD>	</TR>";
                        }
                            else
                        {
                            mensaje += "        IPP:    " + pdlm.PersonasDesaparecidasMismaBusqueda[j].Ipp + " Nombre: " + pdlm.PersonasDesaparecidasMismaBusqueda[j].Apellido + ", " + pdlm.PersonasDesaparecidasMismaBusqueda[j].Nombre + "\n";
                            htmlDesaparecidas += "<TABLE WIDTH=100% CELLSPACING=0>";
                            htmlDesaparecidas += "<TR> <TD WIDTH=33% STYLE='border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P>" + pdlm.PersonasDesaparecidasMismaBusqueda[j].Ipp + " </P> </TD>	";	
                            htmlDesaparecidas += "<TD WIDTH=33% STYLE='border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P>" + pdlm.PersonasDesaparecidasMismaBusqueda[j].Apellido + "</P> </TD> ";		
                            htmlDesaparecidas += "<TD WIDTH=33% STYLE='border: 1px solid #000000; padding: 0.1cm'> <P>" + pdlm.PersonasDesaparecidasMismaBusqueda[j].Nombre + "</P> </TD>	</TR>";
                        }
                        if (j == cuenta - 1)
                        {
                            mensaje += "\n";
                            htmlDesaparecidas += "</TABLE>";
                            emailHtml.Replace("[Detalle Desaparecidas]",htmlDesaparecidas);

                        }
                    }
                }
                else
                {
                    if (htmlDesaparecidas == "")
                    {
                        emailHtml.Replace("[header hallada]", "");
                        emailHtml.Replace("[Detalle Desaparecidas]", "");
                    }
                }

                if ((i < personasD.Count - 1 && usuario != ((PersonasDesaparecidasListMail)personasD[i + 1]).UsuarioMail)//si cambia el usuario para los resultados de la siguiente busqueda
                    || (i == personasD.Count - 1 && usuario == ((PersonasDesaparecidasListMail)personasD[i]).UsuarioMail))//o termine con pd y me pueden quedar ph para el mismo usuario
                {
                    string mensajeH = ""; 
                    string htmlHalladas = "";

                    for (int k = personasH.Count - 1; k >= 0; k--)//recorro las busquedas de halladas xa ver si esta el mismo usuario que desap xa mandar todo en el mismo mail
                    {
                        string u = "";
                        PersonasHalladasListMail phlm = (PersonasHalladasListMail)personasH[k];
                        u = phlm.UsuarioMail;
                        if (u == usuario)
                        {
                            if (htmlHalladas == "")
                                emailHtml.Replace("[header desaparecida]", "Para la Búsqueda asociada a la IPP <B>" + phlm.IppD.Trim() + "</B> relacionada con la persona desaparecida <B>" + phlm.NombrePersonaDesaparecida.Trim() + "</B> se encontraron nuevas coincidencias en la base de personas halladas: ");
                            int cuenta = phlm.PersonasHalladasMismaBusqueda.Count;
                            for (int j = 0; j < cuenta; j++)
                            {
                                if (j == 0)
                                {
                                    mensajeH += "   Para IPP: " + phlm.IppD.Trim() + ",\n";//    --------------------\n";
                                    mensajeH += "   Personas Halladas:\n";
                                    mensajeH += "   -----------------------\n";
                                    if (htmlHalladas != "")
                                        htmlHalladas += "Para la Búsqueda asociada a la IPP <B>" + phlm.IppD.Trim() + "</B> relacionada con la persona desaparecida <B>" + phlm.NombrePersonaDesaparecida.Trim() + "</B> se encontraron nuevas coincidencias en la base de personas halladas: ";
                                    //Pongo el encabezado de la Tabla
                                    htmlHalladas += "<TABLE WIDTH=100% CELLSPACING=0>";
                                    htmlHalladas += "<TR> <TD WIDTH=33% STYLE='border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P>IPP </P> </TD>	";	
                                    htmlHalladas += "<TD WIDTH=33% STYLE='border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P>Apellido </P> </TD> ";		
                                    htmlHalladas += "<TD WIDTH=33% STYLE='border: 1px solid #000000; padding: 0.1cm'> <P>Nombre</P> </TD>	</TR>";
                                }
                                if (phlm.PersonasHalladasMismaBusqueda[i].esExtJurisdiccion)
                                {
                                    mensajeH += "        IPP:    " + phlm.PersonasHalladasMismaBusqueda[j].Ipp + " (ext. Jur.) " + " Nombre: " + phlm.PersonasHalladasMismaBusqueda[j].Apellido + ", " + phlm.PersonasHalladasMismaBusqueda[j].Nombre + "\n";
                                    htmlHalladas += "<TABLE WIDTH=100% CELLSPACING=0>";
                                    htmlHalladas += "<TR> <TD WIDTH=33% STYLE='border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P>" + phlm.PersonasHalladasMismaBusqueda[j].Ipp + " (ext.Jur.) </P> </TD>	";	
                                    htmlHalladas += "<TD WIDTH=33% STYLE='border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P>" + phlm.PersonasHalladasMismaBusqueda[j].Apellido + "</P> </TD> ";		
                                    htmlHalladas += "<TD WIDTH=33% STYLE='border: 1px solid #000000; padding: 0.1cm'> <P>" + phlm.PersonasHalladasMismaBusqueda[j].Nombre + "</P> </TD>	</TR>";
                                }
                                else
                                {
                                    mensajeH += "        IPP:    " + phlm.PersonasHalladasMismaBusqueda[j].Ipp + " Nombre: " + phlm.PersonasHalladasMismaBusqueda[j].Apellido + ", " + phlm.PersonasHalladasMismaBusqueda[j].Nombre + "\n";
                                    htmlHalladas += "<TABLE WIDTH=100% CELLSPACING=0>";
                                    htmlHalladas += "<TR> <TD WIDTH=33% STYLE='border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P>" + phlm.PersonasHalladasMismaBusqueda[j].Ipp + " </P> </TD>	";	
                                    htmlHalladas += "<TD WIDTH=33% STYLE='border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P>" + phlm.PersonasHalladasMismaBusqueda[j].Apellido + "</P> </TD> ";		
                                    htmlHalladas += "<TD WIDTH=33% STYLE='border: 1px solid #000000; padding: 0.1cm'> <P>" + phlm.PersonasHalladasMismaBusqueda[j].Nombre + "</P> </TD>	</TR>";
                        
                                }
                                if (j == cuenta - 1)
                                {
                                    mensajeH += "\n";
                                    htmlHalladas += "</TABLE>";
                                    //emailHtml.Replace("[Detalle Halladas]",htmlHalladas);
                                }
                            }
                            personasH.RemoveAt(k);
                        }
                        //if (htmlHalladas != "")
                        //{
                        //    emailHtml.Replace("[header desaparecida]", "Para la Búsqueda asociada a la IPP <B>" + phlm.IppD.Trim() + "</B> relacionada con la persona desaparecida <B>" + phlm.NombrePersonaDesaparecida.Trim() + "</B> se encontraron las siguientes coincidencias en la base de personas halladas: ") ;
                        //}
                        //else
                        //{
                        //    emailHtml.Replace("[header desaparecida]","");
                        //    emailHtml.Replace("[Detalle Halladas]","");
                        //}
                    }
                    if (htmlHalladas == "")
                        {
                            emailHtml.Replace("[header desaparecida]","");
                            emailHtml.Replace("[Detalle Halladas]","");
                        }
                    else
                        emailHtml.Replace("[Detalle Halladas]", htmlHalladas);
                    if (mensajeH != "")
                    {
                        mensajeH = "\n" + tituloPd + mensajeH;
                        mensaje += mensajeH;
                    }
                    
                    if (mensaje!="")

                    {
                         MandarMail(usuario, mensaje, emailHtml);
                        //MandarMail(usuario, mensaje, mensaje);
                        mensaje = "";
                        emailHtml = new StringBuilder(File.ReadAllText(Server.MapPath("~/App_UserControl/mail.html")));
                    }
                }
                else
                {
                    if (personasH.Count == 0)
                    {
                    emailHtml.Replace("[header desaparecida]", "");
                    emailHtml.Replace("[Detalle Halladas]", "");
                    }
                }
            }

            //PARTE 2:cuando no hay busqueda desap, solo halladas
            mensaje = "";
            usuario = "";
            mensajeMail = "";
            //emailHtml = new StringBuilder(File.ReadAllText(Server.MapPath("~/App_UserControl/mail.html")));
            string htmlHalladas1 = "";
            for (int i = 0; i <= personasH.Count; i++)
            {
                PersonasHalladasListMail resultadosXBusquedaH = null;
                if (i < personasH.Count)
                    resultadosXBusquedaH = (PersonasHalladasListMail)personasH[i];
                if (resultadosXBusquedaH == null || resultadosXBusquedaH.UsuarioMail != usuario)
                {
                    if (mensaje != "")
                    {
                        mensaje = "DESTINATARIO DEL MAIL: " + usuario + ",\n";//esta línea es de testeo de quien debería ser el destinatario del mensaje mientras lo recibamos nosotros en SIAC
                        mensaje = tituloPd + mensaje;
                        htmlHalladas1 += "</TABLE>";
                        emailHtml.Replace("[Detalle Halladas]", htmlHalladas1);
                        //enviar mail (caso hay ph  y no hay pd)
                        
                        MandarMail(usuario, mensaje, emailHtml);
                        mensaje = "";
                        emailHtml.Replace("[header desaparecida]", "");
                        emailHtml.Replace("[Detalle Halladas]", "");
                        emailHtml = new StringBuilder(File.ReadAllText(Server.MapPath("~/App_UserControl/mail.html")));
                    }
                    if (resultadosXBusquedaH != null)//si no estoy en el ultimo
                    {
                        usuario = resultadosXBusquedaH.UsuarioMail;
                        for (int j = 0; j < resultadosXBusquedaH.PersonasHalladasMismaBusqueda.Count; j++)
                        {
                            if (j == 0)
                            {
                                mensaje += "    Para IPP: " + resultadosXBusquedaH.IppD.Trim() + ",\n";
                                mensaje += "    Personas Halladas:\n";
                                mensaje += "    -----------------------\n";
                                emailHtml.Replace("[header hallada]", "");
                                emailHtml.Replace("[Detalle Desaparecidas]", "");
                                emailHtml.Replace("[header desaparecida]", "Para la Búsqueda asociada a la IPP <B>" + resultadosXBusquedaH.IppD.Trim() + "</B> relacionada con la persona desaparecida <B>" + resultadosXBusquedaH.NombrePersonaDesaparecida.Trim() + "</B> se encontraron las siguientes coincidencias en la base de personas halladas: ");
                                htmlHalladas1 = "<TABLE WIDTH=100% CELLSPACING=0>";
                                htmlHalladas1 += "<TR> <TD  ALIGN=CENTER  WIDTH=33% STYLE='background: #cfe7e5; border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P > IPP </P> </TD>	";
                                htmlHalladas1 += "<TD  ALIGN=CENTER  WIDTH=33% STYLE='background: #cfe7e5; border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P  >Apellido </P> </TD> ";
                                htmlHalladas1 += "<TD  ALIGN=CENTER  WIDTH=33% STYLE=' background: #cfe7e5; border: 1px solid #000000; padding: 0.1cm'> <P  >Nombre</P> </TD>	</TR>";
                                
                            }
                            if (resultadosXBusquedaH.PersonasHalladasMismaBusqueda[j].esExtJurisdiccion)
                            {
                                mensaje += "        IPP:    " + resultadosXBusquedaH.PersonasHalladasMismaBusqueda[j].Ipp + " (ext.Jur.) " + " Nombre: " + resultadosXBusquedaH.PersonasHalladasMismaBusqueda[j].Apellido + ", " + resultadosXBusquedaH.PersonasHalladasMismaBusqueda[j].Nombre + "\n";
                                //htmlHalladas1 += "<TABLE WIDTH=100% CELLSPACING=0>";
                                htmlHalladas1 += "<TR> <TD WIDTH=33% STYLE='border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P>" + resultadosXBusquedaH.PersonasHalladasMismaBusqueda[j].Ipp + " (ext.Jur.) </P> </TD>	";
                                htmlHalladas1 += "<TD WIDTH=33% STYLE='border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P>" + resultadosXBusquedaH.PersonasHalladasMismaBusqueda[j].Apellido + "</P> </TD> ";
                                htmlHalladas1 += "<TD WIDTH=33% STYLE='border: 1px solid #000000; padding: 0.1cm'> <P>" + resultadosXBusquedaH.PersonasHalladasMismaBusqueda[j].Nombre + "</P> </TD>	</TR>";
                            }
                            else
                            {
                                mensaje += "        IPP:    " + resultadosXBusquedaH.PersonasHalladasMismaBusqueda[j].Ipp + " Nombre: " + resultadosXBusquedaH.PersonasHalladasMismaBusqueda[j].Apellido + ", " + resultadosXBusquedaH.PersonasHalladasMismaBusqueda[j].Nombre + "\n";
                                //htmlHalladas1 += "<TABLE WIDTH=100% CELLSPACING=0>";
                                htmlHalladas1 += "<TR> <TD WIDTH=33% STYLE='border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P>" + resultadosXBusquedaH.PersonasHalladasMismaBusqueda[j].Ipp + " </P> </TD>	";
                                htmlHalladas1 += "<TD WIDTH=33% STYLE='border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P>" + resultadosXBusquedaH.PersonasHalladasMismaBusqueda[j].Apellido + "</P> </TD> ";
                                htmlHalladas1 += "<TD WIDTH=33% STYLE='border: 1px solid #000000; padding: 0.1cm'> <P>" + resultadosXBusquedaH.PersonasHalladasMismaBusqueda[j].Nombre + "</P> </TD>	</TR>";

                            }
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < resultadosXBusquedaH.PersonasHalladasMismaBusqueda.Count; j++)
                    {
                        if (j == 0)
                        {
                            mensaje += "\n    IPP:    " + resultadosXBusquedaH.IppD.Trim() + "\n    --------------------\n";
                            mensaje += "    Personas Halladas:\n";
                            htmlHalladas1 += "</TABLE></BR>" + "Para la Búsqueda asociada a la IPP <B>" + resultadosXBusquedaH.IppD.Trim() + "</B> relacionada con la persona desaparecida <B>" + resultadosXBusquedaH.NombrePersonaDesaparecida.Trim() + "</B> se encontraron las siguientes coincidencias en la base de personas halladas: ";
                            htmlHalladas1 += "<TABLE WIDTH=100% CELLSPACING=0>";
                            htmlHalladas1 += "<TR> <TD ALIGN=CENTER  WIDTH=33% STYLE='background: #cfe7e5; border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P> IPP </P> </TD>	";
                            htmlHalladas1 += "<TD  ALIGN=CENTER  WIDTH=33% STYLE='background: #cfe7e5; border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P> Apellido </P> </TD> ";
                            htmlHalladas1 += "<TD  ALIGN=CENTER  WIDTH=33% STYLE='background: #cfe7e5; border: 1px solid #000000; padding: 0.1cm'> <P> Nombre </P> </TD>	</TR>";
                        }
                        mensaje += "        IPP:    " + resultadosXBusquedaH.PersonasHalladasMismaBusqueda[j].Ipp + " Nombre: " + resultadosXBusquedaH.PersonasHalladasMismaBusqueda[j].Apellido + ", " + resultadosXBusquedaH.PersonasHalladasMismaBusqueda[j].Nombre + "\n";
                        if (resultadosXBusquedaH.PersonasHalladasMismaBusqueda[j].esExtJurisdiccion)
                        {
                            mensaje += "        IPP:    " + resultadosXBusquedaH.PersonasHalladasMismaBusqueda[j].Ipp + " (ext.Jur.) " + " Nombre: " + resultadosXBusquedaH.PersonasHalladasMismaBusqueda[j].Apellido + ", " + resultadosXBusquedaH.PersonasHalladasMismaBusqueda[j].Nombre + "\n";
                            //htmlHalladas1 += "<TABLE WIDTH=100% CELLSPACING=0>";
                            htmlHalladas1 += "<TR> <TD WIDTH=33% STYLE='border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P>" + resultadosXBusquedaH.PersonasHalladasMismaBusqueda[j].Ipp + " (ext.Jur.) </P> </TD>	";
                            htmlHalladas1 += "<TD WIDTH=33% STYLE='border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P>" + resultadosXBusquedaH.PersonasHalladasMismaBusqueda[j].Apellido + "</P> </TD> ";
                            htmlHalladas1 += "<TD WIDTH=33% STYLE='border: 1px solid #000000; padding: 0.1cm'> <P>" + resultadosXBusquedaH.PersonasHalladasMismaBusqueda[j].Nombre + "</P> </TD>	</TR>";
                        }
                        else
                        {
                            mensaje += "        IPP:    " + resultadosXBusquedaH.PersonasHalladasMismaBusqueda[j].Ipp + " Nombre: " + resultadosXBusquedaH.PersonasHalladasMismaBusqueda[j].Apellido + ", " + resultadosXBusquedaH.PersonasHalladasMismaBusqueda[j].Nombre + "\n";
                            //htmlHalladas1 += "<TABLE WIDTH=100% CELLSPACING=0>";
                            htmlHalladas1 += "<TR> <TD WIDTH=33% STYLE='border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P>" + resultadosXBusquedaH.PersonasHalladasMismaBusqueda[j].Ipp + " </P> </TD>	";
                            htmlHalladas1 += "<TD WIDTH=33% STYLE='border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P>" + resultadosXBusquedaH.PersonasHalladasMismaBusqueda[j].Apellido + "</P> </TD> ";
                            htmlHalladas1 += "<TD WIDTH=33% STYLE='border: 1px solid #000000; padding: 0.1cm'> <P>" + resultadosXBusquedaH.PersonasHalladasMismaBusqueda[j].Nombre + "</P> </TD>	</TR>";

                        }
                    }
                }
            }
        }
        public class PersonasHalladasListMail
        {
            private string _ippD = "";
            private string _usuario = "";
            private string _nombrePersonaDesaparecida = "";
            private PersonasHalladasList phl;
            public PersonasHalladasListMail(Busqueda b)
            {

                PersonasDesaparecidas pd;
                phl = PersonasHalladasManager.GetList(b);
                if (phl.Count > 0)
                {
                    pd = TraerIppDesap(b);
                    _ippD = pd.Ipp;
                    _usuario = b.UsuarioUltimaModificacion;
                    _nombrePersonaDesaparecida = pd.Apellido + ", " + pd.Nombre;
                    phl.Sort((x, y) => string.Compare(x.Ipp, y.Ipp));
                }
            }


            public string IppD
            {
                set
                {
                    _ippD = value;
                }
                get
                {
                    return _ippD;
                }
            }

            public string UsuarioMail
            {
                get
                {
                    return _usuario;
                }
            }

            public string NombrePersonaDesaparecida
            {
                get
                {
                    return _nombrePersonaDesaparecida;
                }
            }

            private PersonasDesaparecidas TraerIppDesap(Busqueda b)
            {
                return PersonasDesaparecidasManager.GetItemByIdBusqueda(Convert.ToInt32(b.Id));
            }

            public PersonasHalladasList PersonasHalladasMismaBusqueda
            {

                get
                {
                    return phl;
                }
            }
        }
        /// <summary>
        /// Personas desaparecidas que coincidieron con el criterio de busqueda ingresado en la persona Hallada
        /// </summary>
        public class PersonasDesaparecidasListMail
        {
            private string _ippH = "";
            private string _usuario = "";
            private string _nombrePersonaHallada = "";
            private PersonasDesaparecidasList pdl;

            public PersonasDesaparecidasListMail(Busqueda b)
            {
                PersonasHalladas ph;
                pdl = PersonasDesaparecidasManager.GetList(b);
                if (pdl.Count > 0)
                {
                    pdl.Sort((x, y) => string.Compare(x.Ipp, y.Ipp));
                    ph = TraerIppHallada(b);
                    _ippH = ph.Ipp;
                    _usuario = b.UsuarioUltimaModificacion;
                    _nombrePersonaHallada = ph.Apellido + ", " + ph.Nombre;
                }
            }

            public string IppH
            {
                set
                {
                    _ippH = value;
                }
                get
                {
                    return _ippH;
                }
            }

            public string UsuarioMail
            {
                get
                {
                    return _usuario;
                }
            }
            public string NombrePersonaHallada
            {
                get
                {
                    return _nombrePersonaHallada;
                }
            }

            private PersonasHalladas TraerIppHallada(Busqueda b)
            {
                return PersonasHalladasManager.GetItemByIdBusqueda(Convert.ToInt32(b.Id));
            }

            public PersonasDesaparecidasList PersonasDesaparecidasMismaBusqueda
            {
                get
                {
                    return pdl;
                }
            }
        }
    }
    }

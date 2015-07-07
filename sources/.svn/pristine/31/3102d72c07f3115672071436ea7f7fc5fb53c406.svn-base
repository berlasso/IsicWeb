using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using Quartz;
using System.Net.Mail;
using MPBA.PersonasBuscadas.Bll;
using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.SIAC.Bll;
using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Web;
using System.Collections;
using System.Net.Mime;
using System.Drawing;
using System.Drawing.Imaging;
using log4net;

namespace MPBA.PersonasBuscadas.Web
{
    public class BuscarCoincidenciasJob : IJob
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        IScheduler Sched;
        public BuscarCoincidenciasJob()
        {
        }

        public void Execute(JobExecutionContext context)
        {

            JobDataMap dataMap = context.JobDetail.JobDataMap;
            Sched = (IScheduler)dataMap["sched"];
            DateTime fechaMacheos = DateTime.Now.Subtract(new TimeSpan(24, 0, 0));//desde ayer
            log.Info("BuscarCoincidenciasJob, metodo Execute., antes de invocar a Buscar Coincidencias");
            //DateTime f = new DateTime(2012, 5, 1).Subtract(new TimeSpan(24, 0, 0));//desde ayer;
            BuscarCoincidencias(fechaMacheos);
        }

        /// <summary>
        /// Busca coincidencias entre Halladas y Desaparecidas para la fecha indicada
        /// </summary>
        /// <param name="fecha">Fecha para buscar macheos</param>
        private void BuscarCoincidencias(DateTime fecha)
        {
            ArrayList personasHalladasXBusqueda = new ArrayList();//guarda collecciones de phs que se encontraron para cada busqueda
            ArrayList personasDesapXBusqueda = new ArrayList();//guarda collecciones de pds que se encontraron para cada busqueda
            List<JobDetail> ListadoMailsParaMandar = new List<JobDetail>();
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
                            personasHalladasXBusqueda.Add(phl);
                        break;
                    case (int)MPBA.PersonasBuscadas.Web.FuncionesGrales.TipoBusqueda.PersonaHallada:
                        PersonasDesaparecidasListMail pdl = new PersonasDesaparecidasListMail(b);
                        if (pdl.PersonasDesaparecidasMismaBusqueda.Count() > 0)
                            personasDesapXBusqueda.Add(pdl);
                        break;
                }
            }
            if (personasDesapXBusqueda.Count > 0 || personasHalladasXBusqueda.Count > 0)
            {
                log.Info("Encontro Coincidencias con Personas Desap." + Convert.ToString(personasDesapXBusqueda.Count) + " ** Coincidencias con Personas Halladas " + Convert.ToString(personasHalladasXBusqueda.Count));
                GestionMails(personasDesapXBusqueda, personasHalladasXBusqueda);
            }
            else
            {
                log.Info("No Encontro Coincidencias con Personas Desaparecidas ni Halladas");
            }
        }

        /// <summary>
        /// Se manda el mail al usuario indicado
        /// </summary>
        /// <param name="usuario">usuario que va a recibir el mail</param>
        /// <param name="body">el contenido del mail</param>
        private void MandarMail(string usuario, string body,StringBuilder bodyhtml)
        {
            MPBA.ConfigurationCL.BusinessObject.Usuarios userMail = null;
            if (usuario.Trim().LastIndexOf("@") > 1)
            {
                usuario = usuario.Trim().Substring(0, usuario.Trim().LastIndexOf("@"));
                String myConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[1].ConnectionString;
                MPBA.ConfigurationCL.BusinessObject.ConnectionSring.conexion = myConnectionString;
                userMail = MPBA.ConfigurationCL.BusinessLogic.UsuariosManager.GetItem(usuario, true);
            }
            if (userMail == null)
                return;
            PersonalPoderJudicial ppj = PersonalPoderJudicialManager.GetItem(userMail.IdPersonalPoderJudicial);
            Persona perMail = PersonaManager.GetItem(ppj.idPersona);

            //*******MODIFICADO PARA TESTEO: ****************
            //*******se cambia el mail para recibirlo nosotros y no quien cargo la ipp ****
            //if (perMail.EMail != null)
            //{




            JobDetail mailParaMandar = new JobDetail(Guid.NewGuid().ToString(), null, typeof(MPBA.SIAC.Web.MailJob));
            mailParaMandar.JobDataMap["mailto"] = userMail.NombreUsuario.Trim() +"@mpba.gov.ar";
            //mailParaMandar.JobDataMap["mailto"] = "gberlasso@mpba.gov.ar";
            mailParaMandar.JobDataMap["subject"] = "SIAC: Coincidencias encontradas al " + DateTime.Today.ToString("dd/MM/yyyy");
            mailParaMandar.JobDataMap["body"] = body;
            mailParaMandar.JobDataMap["from"] = "siac@mpba.gov.ar";
            mailParaMandar.JobDataMap["alternateViews"] = bodyhtml.ToString();
            Trigger t = TriggerUtils.MakeImmediateTrigger(0, new TimeSpan(0, 0, 0));
            t.Name = Guid.NewGuid().ToString();
            Sched.ScheduleJob(mailParaMandar, t);//envia inmediatamente el mail

            //}
            //****************************************************
            //****************************************************
        }

        /// <summary>
        /// Arma los mensajes de cada mail y los envia
        /// </summary>
        /// <param name="personasD">las coincidencias de personas desap.</param>
        /// <param name="personasH">las coincidencias de personas halladas</param>
        private void GestionMails(ArrayList personasDesapXBusqueda, ArrayList personasHalladasXBusqueda)
        {
            log.Info("Ingresa al Envio de Mails, funcion MPBA.PersonasBuscadas.GestionMails");
            string usuario = "";
            string mensaje = "";
            StringBuilder emailHtml = null;
            UTF8Encoding coding = new UTF8Encoding();
            if (File.Exists(HttpRuntime.AppDomainAppPath + "\\App_UserControl\\mail.html"))
            {
                //string mail = File.ReadAllText(HttpRuntime.AppDomainAppPath + "\\App_UserControl\\mail.html");
                emailHtml = new StringBuilder(File.ReadAllText(HttpRuntime.AppDomainAppPath + "\\App_UserControl\\mail.html"));
            }
            //StringBuilder emailHtml = new StringBuilder(File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_UserControl/mail.html")));
            string tituloPd = "Personas Desaparecidas\n";
            tituloPd += "----------------------\n";
            string tituloPh = "Personas Halladas\n";
            tituloPh += "-----------------\n";
            string mensajeMail = "";
            if (personasDesapXBusqueda.Count > 0)
                mensajeMail = tituloPd;
            PersonasBuscadasMailList mails = new PersonasBuscadasMailList();
            //PARTE 1: Armado de mensajes xa busquedas de pd y ph del mismo usuario
            for (int i = 0; i < personasDesapXBusqueda.Count; i++)//recorro cada resultado de busqueda, que puede contener varias ipps
            {
                PersonasDesaparecidasListMail pdlm = ((PersonasDesaparecidasListMail)personasDesapXBusqueda[i]);
                List<PersonasDesaparecidas> pdMismaBusqueda = pdlm.PersonasDesaparecidasMismaBusqueda;
                MailsAsociadosPersonasBuscadasList mailsAsocPH = new MailsAsociadosPersonasBuscadasList();
                PersonasHalladas phMaestra = PersonasHalladasManager.GetItem(pdlm.IdPersonaHalladaMaestra, false);//ph hallada cuya busqueda genero la lista de pds
                if (phMaestra == null || phMaestra.Baja == true)
                    continue;
                //Recorro todos los mails asociados a la ph
                foreach (MailsAsociadosPersonasBuscadas m in pdlm.MailsAsociadosPHMaestra)
                { 
                    int contMail = 0;
                    do
                    {
                        if (mails.Count == 0)
                        {
                            PersonasBuscadasMail pbm = new PersonasBuscadasMail(m.id);
                            pbm.AgregarPDMismaBusqueda(pdlm);
                            //en mails guardo todos los mails a los que se va a notificar de nuevas phs y pds
                            mails.Add(pbm);

                        }
                        else
                        {
                            bool mailExistente = false;
                            foreach (PersonasBuscadasMail mail in mails)
                            {
                                string mailUnico = MailsAsociadosPersonasBuscadasManager.GetItem(mail.IdMailAsociado).Mail.Trim();
                                string mailActual = MailsAsociadosPersonasBuscadasManager.GetItem(m.id).Mail.Trim();
                                if (mailUnico == mailActual)
                                {
                                    mailExistente = true;
                                    mail.AgregarPDMismaBusqueda(pdlm);

                                    break;

                                }
                            }
                            if (!mailExistente)
                            {
                                PersonasBuscadasMail pbm = new PersonasBuscadasMail(m.id);
                                //pbm.AgregarPersonaHallada(phMaestra);
                                pbm.AgregarPDMismaBusqueda(pdlm);
                                mails.Add(pbm);
                            }
                            break;
                        }
                        contMail++;
                    } while (contMail < mails.Count);

                }

            }

            for (int k = 0; k < personasHalladasXBusqueda.Count; k++)//recorro cada resultado de busqueda, que puede contener varias ipps
            {
                PersonasHalladasListMail phlm = ((PersonasHalladasListMail)personasHalladasXBusqueda[k]);
                List<PersonasHalladas> phMismaBusqueda = phlm.PersonasHalladasMismaBusqueda;
                PersonasDesaparecidas pdMaestra = PersonasDesaparecidasManager.GetItem(phlm.IdPersonaDesaparecidaMaestra, false);//pd cuya busqueda genero la lista de phs
                int cantTotalUsuarioMial = mails.Count;
                //Recorro todos los mails asociados a la pd
                foreach (MailsAsociadosPersonasBuscadas m in phlm.MailsAsociadosPDMaestra)
                {
                    int contMail = 0;
                    
                    do
                    {
                        contMail++;
                        if (mails.Count == 0)
                        {
                            PersonasBuscadasMail pbm = new PersonasBuscadasMail(m.id);
                            pbm.AgregarPHMismaBusqueda(phlm);
                            //en mails guardo todos los mails a los que se va a notificar de nuevas phs y pds
                            mails.Add(pbm);

                        }
                        else
                        {
                            bool mailExistente = false;
                            foreach (PersonasBuscadasMail mail in mails)
                            {
                                string mailUnico = MailsAsociadosPersonasBuscadasManager.GetItem(mail.IdMailAsociado).Mail.Trim();
                                string mailActual = MailsAsociadosPersonasBuscadasManager.GetItem(m.id).Mail.Trim();
                                if (mailUnico == mailActual)
                                {
                                    mailExistente = true;
                                    mail.AgregarPHMismaBusqueda(phlm);

                                    break;

                                }
                            }
                            if (!mailExistente)
                            {
                                PersonasBuscadasMail pbm = new PersonasBuscadasMail(m.id);
                                pbm.AgregarPHMismaBusqueda(phlm);
                                mails.Add(pbm);
                            }
                            
                                break;
                        }
                        
                    } while (contMail < cantTotalUsuarioMial);

                }
            }
            if (mails.Count > 0)
            {
                for (int cont = 0; cont < mails.Count; cont++)
                {
                    mensaje = "";
                    string htmlDesaparecidas = "";
                    string htmlHalladas = "";
                    usuario = MailsAsociadosPersonasBuscadasManager.GetItem(mails[cont].IdMailAsociado).Mail;
                    ArrayList persHalladasMismaBusqueda = mails[cont].PersonasHalladasMismaBusqueda;
                    if (persHalladasMismaBusqueda.Count==0)
                            emailHtml.Replace("[header desaparecida]", " ");
                    for (int ii = 0; ii < persHalladasMismaBusqueda.Count; ii++)
                    {
                        if (persHalladasMismaBusqueda.Count > 0)
                        {
                            PersonasHalladasListMail phlm = (PersonasHalladasListMail)persHalladasMismaBusqueda[ii];
                            for (int contpb = 0; contpb <= phlm.PersonasHalladasMismaBusqueda.Count; contpb++)
                            {
                     

                                 tituloPd = "Personas Desaparecidas\n";
                                tituloPd += "----------------------\n";
                                 tituloPh = "Personas Halladas\n";
                                tituloPh += "-----------------\n";
                                 mensajeMail = "";

                              if (contpb<phlm.PersonasHalladasMismaBusqueda.Count)
                              {
                                  PersonasHalladas ph = phlm.PersonasHalladasMismaBusqueda[contpb];
                                  PersonasDesaparecidas pdmaestra = PersonasDesaparecidasManager.GetItem(phlm.IdPersonaDesapMaestra);
                                  string phNombre, phApellido, pdNombreMaestra, pdApellidoMaestra;
                                  if (ph.Nombre == null)
                                      phNombre = "";
                                  else
                                      phNombre = ph.Nombre.Trim();
                                  
                                  if (pdmaestra.Nombre == null)
                                      pdNombreMaestra = "";
                                  else
                                      pdNombreMaestra = pdmaestra.Nombre.Trim();
                                  if (pdmaestra.Apellido == null)
                                      pdApellidoMaestra = "";
                                  else
                                      pdApellidoMaestra = pdmaestra.Apellido.Trim();

                                  if (ph.Apellido == null)
                                      phApellido = "";
                                  else
                                      phApellido = ph.Apellido.Trim();

                                        if (mensaje=="")
                                        {
                                            mensaje = tituloPd;
                                            mensaje += "DESTINATARIO DEL MAIL: " + usuario + ",\n";//esta línea es de testeo de quien debería ser el destinatario del mensaje mientras lo recibamos nosotros en SIAC
                                            emailHtml.Replace("[header desaparecida]", "<br />Para la Busqueda asociada a la IPP <B>" + pdmaestra.Ipp.Trim() + "</B> relacionada con la persona desaparecida <B>" + pdApellidoMaestra + ", " + pdNombreMaestra + "</B> se encontraron nuevas coincidencias en la base de personas halladas: \n");

                                        }
                                        if (contpb == 0)//pongo el subtitulo(ipp que genero las coincidencias)
                                        {
                                            mensaje += "    Para IPP: " + pdmaestra.Ipp.Trim() + "-" + pdApellidoMaestra + ", " + pdNombreMaestra + "\n";
                                            mensaje += "    Personas Halladas:\n";
                                            mensaje += "    -----------------------\n";
                                            if (htmlHalladas != "")
                                            {
                                                htmlHalladas += "<br />Para la Busqueda asociada a la IPP <B>" + pdmaestra.Ipp.Trim() + "</B> relacionada con la persona desaparecida <B>" + pdApellidoMaestra + ", " + pdNombreMaestra + "</B> se encontraron nuevas coincidencias en la base de personas halladas: \n";
                                            }
                                            //Pongo el encabezado de la Tabla
                                            htmlHalladas += "<TABLE WIDTH=100% CELLSPACING=0>";
                                            htmlHalladas += "<TR  bgcolor='LightBlue'> <TD WIDTH=33% STYLE='border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P>IPP </P> </TD>	";
                                            htmlHalladas += "<TD WIDTH=33% STYLE='border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P>Apellido </P> </TD> ";
                                            htmlHalladas += "<TD WIDTH=33% STYLE='border: 1px solid #000000; padding: 0.1cm'> <P>Nombre</P> </TD>	</TR>";
                                        }
                                        if (ph.esExtJurisdiccion)
                                        {
                                            mensaje += "        IPP:    " + ph.Ipp + " (ext.Jur.) " + " Nombre: " + phApellido + ", " + phNombre + "\n";
                                            htmlHalladas += "<TABLE WIDTH=100% CELLSPACING=0>";
                                            htmlHalladas += "<TR> <TD WIDTH=33% STYLE='border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P>" + ph.Ipp + " (ext.Jur.) </P> </TD>	";
                                            htmlHalladas += "<TD WIDTH=33% STYLE='border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P>" + phApellido + "</P> </TD> ";
                                            htmlHalladas += "<TD WIDTH=33% STYLE='border: 1px solid #000000; padding: 0.1cm'> <P>" + phNombre + "</P> </TD>	</TR>";
                                        }
                                        else
                                        {
                                            mensaje += "        IPP:    " + ph.Ipp.Trim() + " Nombre: " + phApellido + ", " + phNombre + "\n";
                                            htmlHalladas += "<TABLE WIDTH=100% CELLSPACING=0>";
                                            htmlHalladas += "<TR> <TD WIDTH=33% STYLE='border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P>" + ph.Ipp.Trim() + " </P> </TD>	";
                                            htmlHalladas += "<TD WIDTH=33% STYLE='border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P>" + phApellido + "</P> </TD> ";
                                            htmlHalladas += "<TD WIDTH=33% STYLE='border: 1px solid #000000; padding: 0.1cm'> <P>" + phNombre + "</P> </TD>	</TR>";
                                        }
                                        if (contpb == phlm.PersonasHalladasMismaBusqueda.Count - 1)
                                        {
                                            mensaje += "\n";
                                            htmlHalladas += "</TABLE>";
                                            //emailHtml.Replace("[Detalle Desaparecidas]", htmlDesaparecidas);

                                        }
                                    }
                                

                               
                                    if (htmlHalladas == "")
                                    {
                                        emailHtml.Replace("[header hallada]", "");
                                        emailHtml.Replace("[Detalle Desaparecidas]", "");
                                    }
                                
                            }
                            

                        }
                    }

                    ArrayList persDesapMismaBusqueda = mails[cont].PersonasDesapMismaBusqueda;
                    if (persDesapMismaBusqueda.Count==0)
                        emailHtml.Replace("[header hallada]", " ");
                    for (int ii = 0; ii < persDesapMismaBusqueda.Count; ii++)
                    {
                        if (persDesapMismaBusqueda.Count > 0)
                        {
                            PersonasDesaparecidasListMail pdlm = (PersonasDesaparecidasListMail)persDesapMismaBusqueda[ii];
                            for (int contpb = 0; contpb < pdlm.PersonasDesaparecidasMismaBusqueda.Count; contpb++)
                            {
     

                             if (contpb<pdlm.PersonasDesaparecidasMismaBusqueda.Count)
                              {
                                  PersonasDesaparecidas pd = pdlm.PersonasDesaparecidasMismaBusqueda[contpb];
                                  PersonasHalladas phmaestra = PersonasHalladasManager.GetItem(pdlm.IdPersonaHalladaMaestra);
                                  string pdNombre, pdApellido, phMaestraApellido,phMaestraNombre;
                                  if (pd.Nombre == null)
                                      pdNombre = "";
                                  else
                                      pdNombre = pd.Nombre.Trim();
                                  if (pd.Apellido == null)
                                      pdApellido = "";
                                  else
                                      pdApellido = pd.Apellido.Trim();
                                  if (phmaestra.Nombre == null)
                                      phMaestraNombre = "";
                                  else
                                      phMaestraNombre = phmaestra.Nombre.Trim();
                                  if (phmaestra.Apellido == null)
                                      phMaestraApellido = "";
                                  else
                                      phMaestraApellido = phmaestra.Apellido.Trim();
                                        if (mensaje=="")
                                        {
                                            mensaje = tituloPh;
                                            mensaje += "DESTINATARIO DEL MAIL: " + usuario + ",\n";//esta línea es de testeo de quien debería ser el destinatario del mensaje mientras lo recibamos nosotros en SIAC
                                            

                                        }
                                        emailHtml.Replace("[header hallada]", "<br />Para la Busqueda asociada a la IPP <B>" + phmaestra.Ipp.Trim() + "</B> relacionada con la persona hallada <B>" + phMaestraApellido + ", " + phMaestraNombre + "</B> se encontraron nuevas coincidencias en la base de personas desaparecidas: \n");
                                       
                                        if (contpb == 0)//pongo el subtitulo(ipp que genero las coincidencias)
                                        {
                                            
                                            mensaje += "    Para IPP: " + phmaestra.Ipp.Trim() + "-" + phMaestraApellido + ", " + phMaestraNombre + "\n";
                                            mensaje += "    Personas Desaparecidas:\n";
                                            mensaje += "    -----------------------\n";
                                            if (htmlDesaparecidas != "")
                                            {
                                                htmlDesaparecidas += "<br /> Para la Busqueda asociada a la IPP <B>" + phmaestra.Ipp.Trim() + "</B> relacionada con la persona hallada <B>" + phMaestraApellido + ", " + phMaestraNombre + "</B> se encontraron nuevas coincidencias en la base de personas desaparecidas: \n";
                                            }
                                            //Pongo el encabezado de la Tabla
                                            htmlDesaparecidas += "<TABLE WIDTH=100% CELLSPACING=0>";
                                            htmlDesaparecidas += "<TR bgcolor='LightBlue'> <TD WIDTH=33% STYLE='border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P>IPP </P> </TD>	";
                                            htmlDesaparecidas += "<TD WIDTH=33% STYLE='border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P>Apellido </P> </TD> ";
                                            htmlDesaparecidas += "<TD WIDTH=33% STYLE='border: 1px solid #000000; padding: 0.1cm'> <P>Nombre</P> </TD>	</TR>";
                                        }
                                        if (pd.esExtJurisdiccion)
                                        {
                                            mensaje += "        IPP:    " + pd.Ipp.Trim() + " (ext.Jur.) " + " Nombre: " + pdApellido + ", " + pdNombre + "\n";
                                            htmlDesaparecidas += "<TABLE WIDTH=100% CELLSPACING=0>";
                                            htmlDesaparecidas += "<TR> <TD WIDTH=33% STYLE='border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P>" + pd.Ipp.Trim() + " (ext.Jur.) </P> </TD>	";
                                            htmlDesaparecidas += "<TD WIDTH=33% STYLE='border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P>" + pdApellido + "</P> </TD> ";
                                            htmlDesaparecidas += "<TD WIDTH=33% STYLE='border: 1px solid #000000; padding: 0.1cm'> <P>" + pdNombre + "</P> </TD>	</TR>";
                                        }
                                        else
                                        {
                                            mensaje += "        IPP:    " + pd.Ipp.Trim() + " Nombre: " + pdApellido + ", " + pdNombre + "\n";
                                            htmlDesaparecidas += "<TABLE WIDTH=100% CELLSPACING=0>";
                                            htmlDesaparecidas += "<TR> <TD WIDTH=33% STYLE='border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P>" + pd.Ipp.Trim() + " </P> </TD>	";
                                            htmlDesaparecidas += "<TD WIDTH=33% STYLE='border-top: 1px solid #000000; border-bottom: 1px solid #000000; border-left: 1px solid #000000; border-right: none; padding-top: 0.1cm; padding-bottom: 0.1cm; padding-left: 0.1cm; padding-right: 0cm'> <P>" + pdApellido + "</P> </TD> ";
                                            htmlDesaparecidas += "<TD WIDTH=33% STYLE='border: 1px solid #000000; padding: 0.1cm'> <P>" + pdNombre + "</P> </TD>	</TR>";
                                        }
                                        if (contpb == pdlm.PersonasDesaparecidasMismaBusqueda.Count - 1)
                                        {
                                            mensaje += "\n";
                                            htmlDesaparecidas += "</TABLE>";
                                            //emailHtml.Replace("[Detalle Desaparecidas]", htmlDesaparecidas);

                                        }
                                    }
                                

                              
                                    if (htmlDesaparecidas.Trim() == "")
                                    {
                                        emailHtml.Replace("[header desaparecida]", "");
                                        emailHtml.Replace("[Detalle Halladas]", "");
                                    }
                                
                            
                            }

                        }
                    }

                    if (mensaje != "")
                    {
                        
                        ////StringBuilder emailHtml = new StringBuilder();
                        ////mensaje = usuario;
                        ////if (usuario == "gberlasso@mpba.gov.ar")
                        ////mensaje = usuario + "\n" + mensaje;
                        ////    MandarMail(usuario, mensaje);
                        ////mensaje = "";
                        //emailHtml = new StringBuilder(File.ReadAllText(HttpRuntime.AppDomainAppPath + "\\App_UserControl\\mail.html"));
                        ////emailHtml = new StringBuilder(File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_UserControl/mail.html")));

                        //emailHtml.Replace("[Detalle Halladas]", htmlHalladas);
                        //htmlHalladas = "";
                        //MandarMail(usuario, mensaje, emailHtml);
                        //mensaje = "";
                        ////emailHtml = new StringBuilder(File.ReadAllText(HttpRuntime.AppDomainAppPath + "\\App_UserControl\\mail.html"));
                        emailHtml.Replace("[Detalle Desaparecidas]", htmlDesaparecidas);
                        htmlDesaparecidas = "";
                        emailHtml.Replace("[Detalle Halladas]", htmlHalladas);
                        htmlHalladas = "";
                        //emailHtml = emailHtml.Insert(0, usuario);

                        MandarMail(usuario, mensaje, emailHtml);
                        mensaje = "";
                        emailHtml = new StringBuilder(File.ReadAllText(HttpRuntime.AppDomainAppPath + "\\App_UserControl\\mail.html"));

                    }
                }
            }

        }

        public class PersonasHalladasListMail
        {
            private string _ippD = "";
            //private int _idD = 0;
            //private string _usuario = "";
            MailsAsociadosPersonasBuscadasList _usuariosMail = new MailsAsociadosPersonasBuscadasList();
            private string _nombrePersonaDesaparecida = "";
            private List<PersonasHalladas> phl;
            PersonasDesaparecidas pd;
            private MailsAsociadosPersonasBuscadasList mailsAsociadosPDMaestra = new MailsAsociadosPersonasBuscadasList();
            public int IdPersonaDesaparecidaMaestra;
            int IDPD;
            public PersonasHalladasListMail()
            {
            }
            public PersonasHalladasListMail(Busqueda b)
            {


                phl = PersonasHalladasManager.GetList(b).FindAll(delegate(PersonasHalladas p) { return p.Baja == false; });
                if (phl.Count > 0)
                {
                    pd = TraerPersonaDesap(b);

                    if (pd == null)
                        return;
                    IdPersonaDesaparecidaMaestra = pd.Id;
                    mailsAsociadosPDMaestra = MailsAsociadosPersonasBuscadasManager.GetListByPersonaBuscada(IdPersonaDesaparecidaMaestra, 1);
                    IDPD = pd.Id; ;
                    _ippD = pd.Ipp;
                    _nombrePersonaDesaparecida = pd.Apellido + ", " + pd.Nombre;
                    phl.Sort((x, y) => string.Compare(x.Ipp, y.Ipp));
                }
            }

            public MailsAsociadosPersonasBuscadasList MailsAsociadosPDMaestra
            {
                get
                {
                    return mailsAsociadosPDMaestra;
                }
            }

            public int IdPersonaDesapMaestra //la pd cuya busqueda origina la lista de pds
            {
                get
                {
                    return IDPD;
                }
            }


            public string NombrePersonaDesaparecida
            {
                get
                {
                    return _nombrePersonaDesaparecida;
                }
            }

            private PersonasDesaparecidas TraerPersonaDesap(Busqueda b)
            {
                return PersonasDesaparecidasManager.GetItemByIdBusqueda(Convert.ToInt32(b.Id));
            }



            public List<PersonasHalladas> PersonasHalladasMismaBusqueda
            {

                get
                {
                    return phl;
                }
            }
        }

        /// <summary>
        /// Tiene todas las personas desaparecidas y halladas que se enviaran a un mismo mail
        /// </summary>
        public class PersonasBuscadasMail
        {
            private int _idMailAsociado = 0;
            //PersonasDesaparecidasList _personasDesaparecidas;
            //private ArrayList _personasDesaparecidas = new ArrayList();
            private ArrayList _phMismaBusqueda = new ArrayList();
            private ArrayList _pdMismaBusqueda = new ArrayList();
            //private PersonasHalladasListMail _phMismaBusqueda;// = new PersonasHalladasListMail();
            //private PersonasDesaparecidasListMail _pdMismaBusqueda;// = new PersonasDesaparecidasListMail();
            //private ArrayList _personasHalladas = new ArrayList();
            public PersonasBuscadasMail(int idMailAsociado)
            {
                _idMailAsociado = idMailAsociado;
            }

            public int IdMailAsociado
            {
                get
                {
                    return _idMailAsociado;
                }
            }

            public void AgregarPHMismaBusqueda(PersonasHalladasListMail pbml)
            {
                _phMismaBusqueda.Add(pbml);
            }

            public ArrayList PersonasHalladasMismaBusqueda
            {

                get
                {
                    return _phMismaBusqueda;
                }
            }

            public void AgregarPDMismaBusqueda(PersonasDesaparecidasListMail pbml)
            {
                _pdMismaBusqueda.Add(pbml);
            }

            public ArrayList PersonasDesapMismaBusqueda
            {

                get
                {
                    return _pdMismaBusqueda;
                }

            }


            //public void AgregarPersonaDesaparecida(PersonasDesaparecidas pd)
            //{
            //    _personasDesaparecidas.Add(pd);
            //}

            //public ArrayList personasDesaparecidas
            //{
            //    get
            //    {
            //        return _personasDesaparecidas;
            //    }
            //}

            //public void AgregarPersonaHallada(PersonasHalladas ph)
            //{
            //    _personasHalladas.Add(ph);
            //}

            //public ArrayList personasHalladas
            //{
            //    get
            //    {
            //        return _personasHalladas;
            //    }
            //}

        }


        /// <summary>
        /// Personas desaparecidas que coincidieron con el criterio de busqueda ingresado en la persona Hallada
        /// </summary>
        public class PersonasDesaparecidasListMail
        {
            private string _ippH = "";
            //private int _idH = 0;
            MailsAsociadosPersonasBuscadasList _usuariosMail = new MailsAsociadosPersonasBuscadasList();
            //private string _usuario = "";
            private string _nombrePersonaHallada = "";
            private List<PersonasDesaparecidas> pdl;
            int IDPH;
            public int IdPersonaHalladaMaestra;
            private MailsAsociadosPersonasBuscadasList mailsAsociadosPHMaestra = new MailsAsociadosPersonasBuscadasList();
            public PersonasDesaparecidasListMail()
            {
            }
            public PersonasDesaparecidasListMail(Busqueda b)
            {

                PersonasHalladas ph;
                pdl = PersonasDesaparecidasManager.GetList(b).FindAll(delegate(PersonasDesaparecidas p) { return p.Baja == false; }); ;

                if (pdl.Count > 0)
                {
                    pdl.Sort((x, y) => string.Compare(x.Ipp, y.Ipp));
                    ph = TraerPersonaHallada(b);
                    if (ph == null)
                        return;
                    IdPersonaHalladaMaestra = ph.Id;
                    mailsAsociadosPHMaestra = MailsAsociadosPersonasBuscadasManager.GetListByPersonaBuscada(IdPersonaHalladaMaestra, 2);
                    IDPH = ph.Id;
                    _ippH = ph.Ipp;
                    //_idH = ph.Id;
                    // _usuario = b.UsuarioUltimaModificacion;
                    //  _usuariosMail=MailsAsociadosPersonasBuscadasManager.GetListByPersonaBuscada(b.personasDesaparecidass[0].Id,1);
                    _nombrePersonaHallada = ph.Apellido + ", " + ph.Nombre;
                }
            }

            public MailsAsociadosPersonasBuscadasList MailsAsociadosPHMaestra
            {
                get
                {
                    return mailsAsociadosPHMaestra;
                }
            }


            public MailsAsociadosPersonasBuscadasList UsuariosMail
            {
                get
                {
                    return _usuariosMail;
                }
            }
            public string NombrePersonaHallada
            {
                get
                {
                    return _nombrePersonaHallada;
                }
            }

            private PersonasHalladas TraerPersonaHallada(Busqueda b)
            {
                return PersonasHalladasManager.GetItemByIdBusqueda(Convert.ToInt32(b.Id));
            }

            public List<PersonasDesaparecidas> PersonasDesaparecidasMismaBusqueda
            {
                get
                {
                    return pdl;
                }
            }
        }

        public partial class PersonasBuscadasMailList : List<PersonasBuscadasMail>
        {
            public PersonasBuscadasMailList()
            {
            }
        }



    }

}


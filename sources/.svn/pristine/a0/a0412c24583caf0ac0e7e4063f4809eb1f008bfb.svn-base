using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MPBA.ConfigurationCL;
using System.Threading;

using MPBA.ConfigurationCL.BusinessLogic;
using MPBA.ConfigurationCL.BusinessObject;
using System.DirectoryServices;
using System.Collections;
using System.Data;
using System.IO;
using System.Xml;
using System.Net;
using Quartz;
using Quartz.Impl;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Bll;

using AjaxControlToolkit;
using System.Windows.Forms;


namespace MPBA.SIAC.Web
{
    public partial class FuncionesGenerales
    {

        public static bool Produccion()
        {// Funcion que devuelve true si esta en Produccion
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/SIAC");
            System.Configuration.ConnectionStringSettings connString;
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["PersonasBuscadasConnectionString"];
            string conexion = connString.ConnectionString;
            string cc = conexion.Substring(conexion.IndexOf("Data Source="), 12);

            return ((conexion.Substring(12, 10) != "gardeltest" && conexion.Substring(12, 10) != "gardeldesa"));
            

        }


        /*Funcion general para enviar mails*/
        public static void EnvioMails(string mailto, string body, string subject)
        {
            /*-------------------------MENSAJE DE CORREO----------------------*/

            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            mmsg.To.Add(mailto);

            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

            //Asunto
            mmsg.Subject = subject;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            mmsg.Bcc.Add("siac@mpba.gov.ar"); //Opcional

            //Cuerpo del Mensaje
            mmsg.Body = body;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = false; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje
            mmsg.From = new System.Net.Mail.MailAddress("siac@mpba.gov.ar");


            /*-------------------------CLIENTE DE CORREO----------------------*/

            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.Credentials =
                new System.Net.NetworkCredential("siac@mpba.gov.ar","");
            //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail
            /*
            cliente.Port = 587;
            cliente.EnableSsl = true;
            */    
            cliente.Host = "smtp.mpba.gov.ar"; //Para Gmail "smtp.gmail.com";


            /*-------------------------ENVIO DE CORREO----------------------*/

            try
            {
                //Enviamos el mensaje      
                cliente.Send(mmsg);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                //Aquí gestionamos los errores al intentar enviar el correo
            }


            //ReadTextFileMail();
            /*
             StdSchedulerFactory schedFact = new Quartz.Impl.StdSchedulerFactory();
             IScheduler sched;
             sched = (IScheduler) Application["scheduler"];
             JobDetail mailParaMandar = new JobDetail(Guid.NewGuid().ToString(), null, typeof(MPBA.SIAC.Web.MailJob));
             mailParaMandar.JobDataMap["mailto"] = mailto;
             mailParaMandar.JobDataMap["subject"] = subject;
             mailParaMandar.JobDataMap["body"] = body;
             mailParaMandar.JobDataMap["from"] = "SIAC@mpba.gov.ar";
             Trigger t = TriggerUtils.MakeImmediateTrigger(1, new TimeSpan(1, 1, 0));
             t.Name = Guid.NewGuid().ToString();
             DateTime tt = sched.ScheduleJob(mailParaMandar, t);//envia inmediatamente el mail*/
        }

        ///// <summary>
        ///// Encripta el password para acceder a la base del SIC
        ///// </summary>
        ///// <param name="pass"></param>
        ///// <returns></returns>
        //public static string Encriptar(string pass)
        //{
        //    int j = 0;
        //    string aux = "";
        //    string qwerty = "qwertyuiop";
        //    int valor = 0;
        //    string c = "";
        //    for (int i = 0; i < pass.Length; i++)
        //    {
        //        if (j == qwerty.Length)
        //        {
        //            j = 0;
        //        }
        //        valor = (int)(Convert.ToChar(qwerty.Substring(j, 1)) ^ Convert.ToChar(pass.Substring(i, 1)));
        //        j++;

        //        switch (valor)
        //        {
        //            case 0:
        //                c = Convert.ToString((char)255) + "0";
        //                break;
        //            case 255:
        //                c = Convert.ToString((char)255) + " ";
        //                break;
        //            default:
        //                c = Convert.ToString((char)valor);
        //                break;
        //        }
        //        aux += c;
        //    }
        //    return aux;
        //}





        /*Funcion general para enviar las huellas por mails */
        public static void EnvioHuellaMails(string mailto, string body, string subject)
        //public static void EnvioHuellaMails(string mailto, string body, string subject, byte[] img)
        {
            /*-------------------------MENSAJE DE CORREO----------------------*/

            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            mmsg.To.Add(mailto);

            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

            //Asunto
            mmsg.Subject = subject;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            mmsg.Bcc.Add("policiajudicial@mpba.gov.ar"); //Opcional

            //Cuerpo del Mensaje
            mmsg.Body = body;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = false; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje
            mmsg.From = new System.Net.Mail.MailAddress("siac@mpba.gov.ar");
             
            //Attachment data = new Attachment(System.Text.Encoding.UTF8.GetString(img));
            //mmsg.Attachments.Add(data);

            /*-------------------------CLIENTE DE CORREO----------------------*/
            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.Credentials =
                new System.Net.NetworkCredential("siac@mpba.gov.ar", "");
            cliente.Host = "smtp.mpba.gov.ar"; //Para Gmail "smtp.gmail.com";
            /*-------------------------ENVIO DE CORREO----------------------*/
            try
            {
                //Enviamos el mensaje      
                cliente.Send(mmsg);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                //Aquí gestionamos los errores al intentar enviar el correo
            }
        }




        /*El tipo de Persona es 3 : Ignorado 4 : Aprehendido */
        public enum TipoPersonas
        {
            PersonaDesaparecida = 1,
            PersonaHallada = 2,
            AutorIgnorado = 3,
            AutorAprehendido = 4
        }

        public enum NombreMes
        {
            Enero = 1,
            Febrero =2,
            Marzo=3,
            Abril=4,
            Mayo=5,
            Junio=6,
            Julio=7,
            Agosto=8,
            Septiembre=9,
            Octubre=10,
            Noviembre=11,
            Diciembre=12
        }

    }
}
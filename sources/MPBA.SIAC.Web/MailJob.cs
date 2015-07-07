using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using System.Net.Mail;
using System.Text;
using System.Net.Mime;

namespace MPBA.SIAC.Web
{
    public class MailJob : IJob
    {
        public MailJob()
        {
        }

        public void Execute(JobExecutionContext context)
        {
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            string mailto = dataMap.GetString("mailto");
            string subject = dataMap.GetString("subject");
            string body = dataMap.GetString("body");
            string from = dataMap.GetString("from");

            string bodyhtml = dataMap.GetString("alternateViews");


            if (bodyhtml != null && bodyhtml.Trim() != "")
            {
                AlternateView html = AlternateView.CreateAlternateViewFromString(bodyhtml, null, "text/html");
                LinkedResource img = new LinkedResource(" " + HttpRuntime.AppDomainAppPath + "\\App_Images\\logo_mail.jpg", MediaTypeNames.Image.Jpeg);
                img.ContentId = "imagen"; // Lo incrustamos en la vista HTML...
                html.LinkedResources.Add(img);

                SendMail(mailto, body, subject, from, html);
            }
            else
            {
                SendMail(mailto, body, subject, from);
            }
        }


        // SendMail SIN HTML, solo version Texto apto para enviar solo informacion al usuario
        public void SendMail(string mailto, string mensaje, string subject, string from)
        {
            MailMessage message = new MailMessage();
            message.To.Add(mailto);
            message.From = new MailAddress(from);
            message.Subject = subject;
            message.Body = mensaje;
            message.IsBodyHtml = false;
            //message.CC.Add("siac@mpba.gov.ar");
            SmtpClient mailClient = new SmtpClient("smtp.mpba.gov.ar");
            try
            {
                mailClient.Send(message);
            }
            catch (SmtpFailedRecipientException) { };

        }

        public void SendMail(string mailto, string mensaje, string subject, string from, AlternateView html)
        {
            MailMessage message = new MailMessage();
            message.To.Add(mailto);
            message.From = new MailAddress(from);
            message.Subject = subject;
            message.Body = mensaje;
            message.IsBodyHtml = true;
            message.CC.Add("siac@mpba.gov.ar");
            message.AlternateViews.Add(html);
            SmtpClient mailClient = new SmtpClient("smtp.mpba.gov.ar");
            try
            {
                mailClient.Send(message);
            }
            catch (SmtpFailedRecipientException){};

        }
    }
}
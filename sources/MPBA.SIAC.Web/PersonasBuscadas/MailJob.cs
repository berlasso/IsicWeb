using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using System.Net.Mail;

namespace MPBA.PersonasBuscadas.Web
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
            SendMail(mailto, body, subject,true);
        }


        public void SendMail(string mailto,string mensaje, string subject, bool testMail)
        {
            MailMessage message = new MailMessage();
            message.To.Add(mailto);
            message.From = new MailAddress("personasbuscadas@mpba.gov.ar");
            if (!testMail)
            {
                message.Subject = "ddddd";
                message.Body = mensaje;
            }
            else
            {
                message.Subject = subject;
                message.Body = mensaje;
            }
            SmtpClient mailClient = new SmtpClient("smtp.mpba.gov.ar");
            try
            {
                mailClient.Send(message);
            }
            catch (SmtpFailedRecipientException){};

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class EmailHelper
    {
        public static void SendEmail(string senderName, string toEmail, string subject, string body)
        {
            var mail = new MailMessage();
            mail.From = new MailAddress("usuario.correo.temporal77@outlook.com", senderName);//ahora Gmail ya no permite enviar desde aplicaciones de terceros :(
            mail.To.Add(toEmail);
            mail.Subject = subject;
            mail.IsBodyHtml = true;
            mail.Body = body;

            var smtpServer = new SmtpClient("smtp.office365.com");
            smtpServer.Port = 587;
            smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpServer.UseDefaultCredentials = false;
            smtpServer.Credentials = new NetworkCredential("CORREO@outlook.com", "PASSWORD");//Cambiar por tus credenciales reales
            smtpServer.EnableSsl = true;
            smtpServer.Send(mail);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace GestPharmaWebASP.Services
{
    public class ForgotPassword
    {
        public ForgotPassword()
        {

        }

        public bool SendEmail(string email)
        {
            try
            {
                string to, from, pass, messageBody;
                MailMessage message = new MailMessage();
                to = email;
                from = "temetangcindy@gmail.com";
                //pass = "anael@1@2";
                string htmlHeader = "<a href = 'http://localhost:49908/Acount/resetPassword?Email=" + email + "'> click ici <a>";
                messageBody = ("click ici pour recuperer ton mot de passe   :" + htmlHeader);
                message.To.Add(to);
                message.From = new MailAddress(from);
                message.Body = "From : " + "<br>Message: " + messageBody;
                message.Subject = "recuperation de mots de passe";
                message.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("localhost");
                //smtp.EnableSsl = true;
                smtp.Port = 56915;
                //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //smtp.Credentials = new System.Net.NetworkCredential(from, pass);
                smtp.Timeout = 6000;
                smtp.Send(message);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
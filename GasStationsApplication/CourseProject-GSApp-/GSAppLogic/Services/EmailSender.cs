using GSAppLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace GSAppLogic.Services
{
    public class EmailSender
    {
        private UserDTO user;
        public readonly MailAddress from = new MailAddress("alfredq6@gmail.com", "Server");


        public EmailSender(UserDTO _user)
        {
            user = _user;
        }

        public EmailSender() { }

        public string SendCodeToEmail(string emailAdress, int code)
        {
            try
            {
                MailAddress to = new MailAddress(emailAdress);
                MailMessage message = new MailMessage(from, to)
                {
                    Subject = $"Письмо с кодом",
                    Body = $"<h2>Ваш код: {code.ToString()}</h2>",
                    IsBodyHtml = true
                };
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Timeout = 10000,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential($"{/*server email*/}", $"{/*server email's password*/}"),
                    EnableSsl = true
                };
                client.Send(message);
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message + "\nСлабое интернет-соединение";
            }
        }

        public string SendPasswordToEmail()
        {
            try
            {
                MailAddress to = new MailAddress(user.Email);
                MailMessage message = new MailMessage(from, to)
                {
                    Subject = $"Письмо с паролем",
                    Body = $"<h2>Ваш пароль: {user.Password}</h2>",
                    IsBodyHtml = true
                };
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Timeout = 10000,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential($"{/*server email*/}", $"{/*server email's password*/}"),
                    EnableSsl = true
                };
                client.Send(message);
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message + "\nСкорей всего была введена неверная почта";
            }
        }
    }
}

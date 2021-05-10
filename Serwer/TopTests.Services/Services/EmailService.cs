using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using TopTests.Services.Interfaces;
using TopTests.Services.Models.Users;

namespace TopTests.Services.Services
{
    public class EmailService : IEmailService
    {
        /// <summary>
        /// Send email with link to set password
        /// </summary>
        /// <param name="createUserDto"></param>
        /// <returns>return true if email send correct</returns>
        [Obsolete]
        public bool EmailAfterRegistration(RegisterUserDto registerUserDto)
        {
            string subject = "Top Tests Services";
            string data = registerUserDto.Name;
            string htmlBody = @"
                        <html lang=""en"">    
                         <body style='width:720px'>  
                           <h2>Dear " + registerUserDto.Name + @",</h2> <p style='font-family: Arial,sans-serif'>You have been registered in the online test service.
                             <br>
                             Please confirm registration and follow this link </p>                         
                              <div style='text-align:center'><a href='http://localhost:3000/confirm/" + registerUserDto.CodeOfVerification + @"' style='font-size:30px'>Change Password</a></div>
                              <p style='font-family: Arial,sans-serif'>We appreciate that you are with us and using service<br>Have a nice day,<br>Testex Education Platform</p>
                            <img src=""cid:WinLogo"" />
                                    </body>
                                         </html>";
            string messageBody = string.Format(htmlBody, data);
            AlternateView alternateViewHtml = AlternateView.CreateAlternateViewFromString(htmlBody, Encoding.UTF8, MediaTypeNames.Text.Html);
            MailMessage mailMessage = new MailMessage("kucherbogdan2000@gmail.com", registerUserDto.Email, subject, messageBody);
            mailMessage.AlternateViews.Add(alternateViewHtml);
            using (SmtpClient smpt = new SmtpClient("smtp.gmail.com", 587))
            {
                smpt.EnableSsl = true;
                smpt.DeliveryMethod = SmtpDeliveryMethod.Network;
                smpt.UseDefaultCredentials = false;
                smpt.Credentials = new NetworkCredential("kucherbogdan2000@gmail.com", "basket2009");
                MailMessage message = new MailMessage();
                message.To.Add(registerUserDto.Email);
                message.From = new MailAddress("kucherbogdan2000@gmail.com");
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                message.Subject = "Top Tests";
                message.Body = "Something";
                smpt.Send(mailMessage);
            }
            return true;
        }
        [Obsolete]
        public bool ResetPassword(string code,string email)
        {
            string subject = "Top Tests Services. Re";
            string data="hey";
            string htmlBody = @"
                        <html lang=""en"">    
                         <body style='width:720px'>  
                           <p style='font-family: Arial,sans-serif'>We heard that you lost your Account password. Sorry about that!
                               But don’t worry! You can use the following link to reset your password.
                             <br></p>                         
                              <div style='text-align:center'><a href='http://localhost:3000/forgotPassword/" + code + @"' style='font-size:30px'>Change Password</a></div>
                              <p style='font-family: Arial,sans-serif'>We appreciate that you are with us and using service<br>Have a nice day,<br>Testex Education Platform</p>
                            <img src=""cid:WinLogo"" />
                                    </body>
                                         </html>";
            string messageBody = string.Format(htmlBody, data);
            AlternateView alternateViewHtml = AlternateView.CreateAlternateViewFromString(htmlBody, Encoding.UTF8, MediaTypeNames.Text.Html);
            MailMessage mailMessage = new MailMessage("kucherbogdan2000@gmail.com", email, subject, messageBody);
            mailMessage.AlternateViews.Add(alternateViewHtml);
            using (SmtpClient smpt = new SmtpClient("smtp.gmail.com", 587))
            {
                smpt.EnableSsl = true;
                smpt.DeliveryMethod = SmtpDeliveryMethod.Network;
                smpt.UseDefaultCredentials = false;
                smpt.Credentials = new NetworkCredential("kucherbogdan2000@gmail.com", "basket2009");
                MailMessage message = new MailMessage();
                message.To.Add(email);
                message.From = new MailAddress("kucherbogdan2000@gmail.com");
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                message.Subject = "Top Tests";
                message.Body = "Something";
                smpt.Send(mailMessage);
            }
            return true;
        }
    }
}

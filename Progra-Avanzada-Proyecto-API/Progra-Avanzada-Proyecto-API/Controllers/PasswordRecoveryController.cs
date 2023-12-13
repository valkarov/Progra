using System;
using System.Linq;
using System.Web.Http;
using System.Net.Mail;
using System.Net;

namespace Progra_Avanzada_Proyecto_API.Controllers
{
    public class PasswordRecoveryController : ApiController
    {
        private ProyectoPrograContext db = new ProyectoPrograContext();

        // POST: api/PasswordRecovery
        [HttpPost]
        [Route("api/PasswordRecovery")]
        public IHttpActionResult RequestPasswordRecovery([FromBody] string email)
        {
            var user = db.Usuarios.FirstOrDefault(u => u.NombreUsuario == email);
            if (user == null)
            {
                return NotFound();
            }

            var recoveryCode = new Random().Next(100000, 999999).ToString();
            var expiryTime = DateTime.Now.AddHours(1);

         
            var recoveryRecord = new PasswordRecovery { Email = email, RecoveryCode = recoveryCode, ExpiryDateTime = expiryTime, IsUsed = false };
            db.PasswordRecoveries.Add(recoveryRecord);
            db.SaveChanges();

            SendRecoveryEmail(email, recoveryCode); // Enviar correo

            return Ok("Email enviado.");
        }

        private void SendRecoveryEmail(string email, string recoveryCode)
        {
            using (SmtpClient client = new SmtpClient("smtp.office365.com", 587))
            {
                client.Credentials = new NetworkCredential("xxxxxxxxx", "xxxxxxxx"); // Cambiar por las credenciales reales
                client.EnableSsl = true;

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("xxxxxxxxx"),
                    To = { new MailAddress("xxxxxxxxx") },
                    Subject = "Recuperación de contraseña",
                    Body = $"Su código de recuperación es: {recoveryCode}",
                    IsBodyHtml = true
                };
                mailMessage.To.Add(email);

                client.Send(mailMessage);
            }
        }
    }
}

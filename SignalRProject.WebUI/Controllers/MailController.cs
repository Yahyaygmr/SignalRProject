using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRProject.WebUI.Dtos.MailDtos;

namespace SignalRProject.WebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CreateMailDto dto)
        {
            MimeMessage mimeMessage = new();

            MailboxAddress mailBoxAdressFrom = new MailboxAddress("SignalR Restoran Rezervasyon", "pprojetestleri@gmail.com");
            mimeMessage.From.Add(mailBoxAdressFrom);

            MailboxAddress mailBoxAddressTo = new MailboxAddress("User", dto.Reciever);
            mimeMessage.To.Add(mailBoxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = dto.Content;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = dto.Subject;

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.ServerCertificateValidationCallback = (s, c, h, e) => true;
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("pprojetestleri@gmail.com", "");

            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);

            TempData["ErrorMessage"] = "Mesaj Gönderildi.";

            return View();
        }
    }
}

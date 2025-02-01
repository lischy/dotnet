

using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;

public class SendMailerController : Controller
{
    public ActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public ViewResult Index(mvc.Models.MailEntity _mailEntity)
    {
        if (ModelState.IsValid)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(_mailEntity.To);
            mail.From = new MailAddress(_mailEntity.From);
            mail.Subject = _mailEntity.Subject;
            string Body = _mailEntity.Body;
            mail.Body = Body;


            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("username", "password");
            smtp.EnableSsl = true;
            smtp.Send(mail);

            return View("Index", _mailEntity);
        } else{
            return View();
        }
    }
}
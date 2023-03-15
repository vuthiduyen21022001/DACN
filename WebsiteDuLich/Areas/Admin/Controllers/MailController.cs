using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebsiteDuLich.Models;

namespace WebsiteDuLich.Areas.Admin.Controllers
{
    public class MailController : Controller
    {
        public ActionResult SendMail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMail(EmailModel model)
        {
            using (MailMessage mm = new MailMessage(model.Email, model.To))
            {
                mm.Subject = model.Subject;
                mm.Body = model.Body;


                if (model.Attchment.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(model.Attchment.FileName);
                    mm.Attachments.Add(new Attachment(model.Attchment.InputStream, fileName));
                }
                mm.IsBodyHtml = false;
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential cred = new NetworkCredential(model.Email, "rwzidmpxznqjjhfp");
                    //" /*model.Password*/);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = cred;
                    smtp.Port = 587;
                    smtp.Send(mm);


                    ViewBag.message = "Email sent ";

                }
                return View();
            }
        }
    }
}
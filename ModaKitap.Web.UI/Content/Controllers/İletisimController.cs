using ModaKitap.Model.Core;
using ModaKitap.Model.Core.Entity;
using ModaKitap.Web.UI.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ModaKitap.Web.UI.Controllers
{
   

    public class İletisimController : FRControllerBase
    {

        // GET: İletisim
        private MailMessage mail;
        private SmtpClient smp;
        [Route("~/iletisim")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("~/iletisim")]
        [HttpPost]
        public ActionResult Index(string name, string email, string subject, string mesaj)
        {
            try
            {
                TempData["mesaj"] = "Sayın : " + name + " mesajınız başarıyla alındı. Sizinle en yakın zamanda iletişime geçeceğiz.";
                string subject2 = "İletişim : " + name;
                string body = "<b>Adı Soyadı : </b>" + name +
                    "<br><b>E-Posta : </b>" + email +
                    "<br><b>Mesaj : </b>" + mesaj;
                mail = new MailMessage(); //yeni bir mail nesnesi Oluşturuldu.
                mail.IsBodyHtml = true; //mail içeriğinde html etiketleri kullanılsın mı?
                mail.To.Add("ilkimafife@gmail.com"); //Kime mail gönderilecek.
                mail.To.Add("modakitap12@gmail.com"); //Kime mail gönderilecek.
                                                       //mail kimden geliyor, hangi ifade görünsün?
                mail.From = new MailAddress("modakitap12@gmail.com", "www.modakitap.com", System.Text.Encoding.UTF8);
                mail.Subject = subject2;//mailin konusu
                                        //mailin içeriği.. Bu alan isteğe göre genişletilip daraltılabilir.
                mail.Body = body;
                mail.IsBodyHtml = true;

                smp = new SmtpClient();
                //mailin gönderileceği adres ve şifresi
                smp.Credentials = new NetworkCredential("modakitap12@gmail.com", "x14s257w");
                smp.Port = 587;
                smp.Host = "smtp.gmail.com";//gmail üzerinden gönderiliyor.
                smp.EnableSsl = true;
                smp.Send(mail);//mail isimli mail gönderiliyor.
            }
            catch (Exception)
            {
                TempData["mesaj"] = "HATA ! : Bilgileri doğru ve eksiksiz girdiğinizden emin olun !";
                throw;
            }
            return View();
        }

    }

    }


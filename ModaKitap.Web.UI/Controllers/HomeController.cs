using ModaKitap.Model.Core;
using ModaKitap.Model.Core.Entity;
using ModaKitap.Web.UI.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ModaKitap.Web.UI.Controllers
{
    public class HomeController : FRControllerBase
    {
        ModaKitapDB db = new ModaKitapDB();

        // GET: Home
        [Route("~/")]
        public ActionResult Index()
        {
            ViewBag.IsLogin = this.IsLogin;
            var data = db.Kitaplars.OrderByDescending(x => x.OlusumTarihi).Take(12).ToList();
            return View(data);
        }



        [Route("~/kategori")]
        public PartialViewResult KategoriMenu()
        {
           
            var menu = db.Kategoris.Where(x => x.UstID == 0).ToList();
            return PartialView(menu);
        }

        

        [Route("~/yayınevi")]
        public PartialViewResult YayınEviMenu()
        {

            var yayınevi = db.YayınEvis.Where(x => x.UstID == 0).ToList();
            return PartialView(yayınevi);
        }



        [Route("~/uyegiris")]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Route("~/uyegiris")]
        public ActionResult Login(string Mail, string Sifre)
        {
            var users = db.Users.Where(x => x.Mail == Mail
                  && x.Sifre == Sifre && x.Aktif_Değil == true && x.Adminmi == false).ToList();
            if (users.Count == 1)
            {
                Session["LoginUserID"] = users.FirstOrDefault().ID;
                Session["LoginUser"] = users.FirstOrDefault();
                return Redirect("/");
            }
            else
            {
                ViewBag.Error = "Hatalı mail adresi yada şifre !";
                return View();
            }

        }


        [Route("~/LogOut")]
        public ActionResult LogOut()
        {
            Session.Clear();

            return RedirectToAction("Index","Home");
        }



        [Route("~/UyeOl")]
        public ActionResult Uyeol()
        {
            return View();
        }

        [HttpPost]
        [Route("~/UyeOl")]
        public ActionResult Uyeol(User entity)
        {
            try
            {
                entity.OlusumTarihi = DateTime.Now;
                entity.OlusturanKullanıcıID = 1;
                entity.Aktif_Değil = true;
                entity.Adminmi = false;
                db.Users.Add(entity);
                db.SaveChanges();

                return Redirect("/");
            }
            catch    (Exception ex)
            {
                return View(ex);

            }
        }







    }
    }

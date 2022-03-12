using ModaKitap.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModaKitap.Web.UI.Areas.Admin.Controllers
{
    public class AdminLoginController : Controller
    {
        ModaKitapDB db = new ModaKitapDB();
        // GET: Admin/AdminLogin

            
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
       
        public ActionResult Index(string Maik, string Sifre)
        {
           
            var data = db.Users.Where(x => x.Mail== Maik && x.Sifre== Sifre & x.Aktif_Değil == true & x.Adminmi==true).ToList();
            if (data.Count == 1)
            {
                Session["LoginAdminUser"] = data.FirstOrDefault();
                return Redirect("/Admin/Default/");
            }
            else
            {
                return View();
            }

        }


        public ActionResult LogOut()
        {
            Session.Clear();

            return RedirectToAction("AdminLogin", "Index");
        }

    }

}
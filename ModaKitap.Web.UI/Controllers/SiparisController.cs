using ModaKitap.Model.Core;
using ModaKitap.Model.Core.Entity;
using ModaKitap.Web.UI.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ModaKitap.Web.UI.Controllers
{
    public class SiparisController : FRControllerBase
    {
        ModaKitapDB db = new ModaKitapDB();
        // GET: Siparis
        [Route("SatınAl")]
        public ActionResult AdresList()
        {
            var data = db.UserAdress.Where(x => x.UserID == LoginUserID).ToList();

            return View(data);
        }

        public ActionResult CreateUserAdress()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreateUserAdress(UserAdres entity)
        {
            entity.OlusumTarihi = DateTime.Now;
            entity.OlusturanKullanıcıID = LoginUserID;
            entity.Aktif_Degil = true;
            entity.UserID = LoginUserID;

            db.UserAdress.Add(entity);
            db.SaveChanges();
            return RedirectToAction("AdresList");
        }

        public ActionResult CreateOrder(int id)
        {
         
            var sepet = db.Sepets.Include("Kitaplar").Where(x => x.UserID == LoginUserID).ToList();
            Siparis siparis = new Siparis();
            siparis.OlusumTarihi = DateTime.Now;
            siparis.OlusturanKullanıcıID = LoginUserID;
            siparis.DurumID = 2;
            siparis.Toplam = sepet.Sum(x => x.Kitaplar.Fiyat);
            siparis.İndirimToplamı = sepet.Sum(x => x.Kitaplar.İndirim);
            siparis.ToplamTutar = siparis.Toplam + siparis.ToplamKDV;
            siparis.UserAdresID = id;
            siparis.UserID = LoginUserID;
            siparis.SiparisDetays = new List<SiparisDetay>();
            siparis.SiparisNo = Guid.NewGuid().ToString();
            foreach (var item in sepet)
            {
                siparis.SiparisDetays.Add(new SiparisDetay
                {
                    
                    OlusumTarihi = DateTime.Now,
                    OlusturanKullanıcıID = LoginUserID,
                    KitapID = item.KitaplarID,
                    Adet = item.Adet

                });
                db.Sepets.Remove(item);
            }

            db.Siparis.Add(siparis);

            db.SaveChanges();
            return RedirectToAction("Detail", new { id = siparis.ID });
        }

        [Route("Siparis")]
        public ActionResult Detail(int id)
        {

            var data = db.Siparis.Include("SiparisDetays")
                .Include("SiparisDetays.Kitaplar")
                .Include("OdemeSecenekleris")
                .Include("Durum")
                .Include("UserAdres")
                .Where(x => x.ID == id).FirstOrDefault();
            return View(data);
        }

        [Route("Siparislerim")]
        public ActionResult Index()
        {
            var data = db.Siparis.Include("Durum").Where(x => x.UserID == LoginUserID).ToList();
            return View(data);
        }

        public ActionResult Pay(int id)
        {
            var siparis = db.Siparis.Where(x => x.ID == id).FirstOrDefault();
            siparis.DurumID = 5;
            db.SaveChanges();
            return RedirectToAction("Detail", new { id = siparis.ID });
        }


        public ActionResult SiparisDetay()
        {

            var data = db.Sepets.Include("Kitaplar").Where(x => x.UserID == LoginUserID).ToList();

            return View(data);


        }



    }
}
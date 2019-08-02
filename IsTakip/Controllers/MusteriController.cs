using IsTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IsTakip.Controllers
{
    public class MusteriController : Controller
    {
        IsTakipDB db = new IsTakipDB();
        // GET: Musteri
        public ActionResult Index()
        {
            string MusteriNo = Session["KullaniciNo"].ToString();
            int AktifMusteriId = db.Musterilers.FirstOrDefault(x => x.SirketNo == MusteriNo).id;
            var Isteklerim = db.MusteriIsteklers.Where(x => x.MusteriId == AktifMusteriId).ToList();
            ViewBag.IstekTipleri = db.IsTakipIstekTipis.ToList();
            return View(Isteklerim);
        }

        [HttpPost]
        public ActionResult IstekEkle(MusteriIstekler MI)
        {
            string MusteriNo = Session["KullaniciNo"].ToString();
            int AktifMusteriId = db.Musterilers.FirstOrDefault(x => x.SirketNo == MusteriNo).id;
            MI.MusteriId = AktifMusteriId;
            //MI.Goruldu = false;
            MI.IstekTarihi = DateTime.Now;
            db.MusteriIsteklers.Add(MI);
            db.SaveChanges();
            return RedirectToAction("Index", "Musteri");
        }

        public ActionResult IstekDetay(int id)
        {
            string AktifKullanici="";
            string KullaniciNo = Session["KullaniciNo"].ToString();
            bool AktifKullaniciMi = db.Kullanicilars.Any(x => x.KullaniciNo == KullaniciNo);
            if(AktifKullaniciMi)
            {
                AktifKullanici = db.Kullanicilars.FirstOrDefault(x => x.KullaniciNo == KullaniciNo).KullaniciAdi;
            }
            var Istek = db.MusteriIsteklers.FirstOrDefault(x => x.id == id);
            if (!String.IsNullOrEmpty(AktifKullanici))
            {
                Istek.Goruldu = true;
                db.SaveChanges();
            }
            ViewBag.Yorumlar = db.IsTakipYorums.Where(x => x.IstekId == id).ToList();
            return View(Istek);
        }

        [HttpPost]
        public void YorumYap(string yorum, int IstekId)
        { 
            string AktifNo = Session["KullaniciNo"].ToString();
            bool MusteriMi = db.Musterilers.Any(x => x.SirketNo == AktifNo);
            if (MusteriMi == true)
            {
                string AktifMusteri = db.Musterilers.FirstOrDefault(x => x.SirketNo == AktifNo).SirketAdi;
                if (yorum != null)
                {
                    IsTakipYorum ITY = new IsTakipYorum();
                    ITY.Icerik = yorum;
                    ITY.YorumTarihi = DateTime.Now;
                    ITY.IstekId = IstekId;
                    ITY.YorumYapan = AktifMusteri;
                    db.IsTakipYorums.Add(ITY);
                    db.SaveChanges();
                }
            }
            bool KullaniciMi = db.Kullanicilars.Any(x => x.KullaniciNo == AktifNo);
            if (KullaniciMi == true)
            {
                string KullaniciAdi = db.Kullanicilars.FirstOrDefault(x => x.KullaniciNo == AktifNo).KullaniciAdi;
                if (yorum != null)
                {
                    IsTakipYorum ITY = new IsTakipYorum();
                    ITY.Icerik = yorum;
                    ITY.YorumTarihi = DateTime.Now;
                    ITY.IstekId = IstekId;
                    ITY.YorumYapan = KullaniciAdi;
                    db.IsTakipYorums.Add(ITY);
                    db.SaveChanges();
                }
            }
        }
    }
}
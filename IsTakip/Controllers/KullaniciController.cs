using IsTakip.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IsTakip.Controllers
{
    public class KullaniciController : Controller
    {
        IsTakipDB db = new IsTakipDB();
        // GET: Kullanici
        public ActionResult Index()
        {
            string KullaniciNo = Session["KullaniciNo"].ToString();
            int AktifKullaniciId = db.Kullanicilars.FirstOrDefault(x => x.KullaniciNo == KullaniciNo).id;
            var VerdigimIsler = db.IsTakipMasters.Where(x => x.IsiVerenId == AktifKullaniciId && x.Kapandi == false).ToList();
            ViewBag.Kategoriler = db.IsTakipKategoris.ToList();
            ViewBag.Oncelik = db.IsTakipOnceliks.ToList();
            ViewBag.Kullanicilar = db.Kullanicilars.ToList();
            ViewBag.Gruplar = db.IsTakipGruplars.ToList();
            return View(VerdigimIsler);
        }

        public ActionResult VerdigimYapılanlar(int id)
        {
            var Yapilanlar = db.IsTakipDetays.Where(
            x => x.Masterid == id).OrderBy(x => x.Tarih).OrderBy(x => x.id).ToList();
            return View(Yapilanlar);
        }

        public ActionResult IsEkle(IsTakipMaster master, List<string> Sorumlular)
        {
            string KullaniciNo = Session["KullaniciNo"].ToString();
            int AktifKullaniciId = db.Kullanicilars.FirstOrDefault(x => x.KullaniciNo == KullaniciNo).id;
            master.IsiVerenId = AktifKullaniciId;
            string sorumlular = "";
            foreach (string item in Sorumlular)
            {
                sorumlular = sorumlular + ", " + item;
            }
            sorumlular = sorumlular.Substring(2).Trim();
            master.Sorumlular = sorumlular;
            master.Termin = master.Termin.Date;
            master.KayitTarih = DateTime.Now;
            master.TamamlanmaYuzdesi = 0;
            master.Kapandi = false;
            db.IsTakipMasters.Add(master);
            db.SaveChanges();

            foreach (string srmlu in Sorumlular)
            {
                IsTakipSorumlular ITS = new IsTakipSorumlular();
                ITS.Masterid = master.id;
                ITS.Sorumlu = db.Kullanicilars.FirstOrDefault(x => x.KullaniciNo == srmlu).id;
                ITS.DurumuId = 1;
                db.IsTakipSorumlulars.Add(ITS);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Kullanici");
        }



        public ActionResult YapacagimIs()
        {
            string KullaniciNo = Session["KullaniciNo"].ToString();
            int AktifKullaniciId = db.Kullanicilars.FirstOrDefault(x => x.KullaniciNo == KullaniciNo).id;
            var YapacagimIs = db.IsTakipMasters.Where(x => x.Kapandi == false
            && true == (db.IsTakipSorumlulars.Where(y => y.Masterid == x.id && y.Sorumlu == AktifKullaniciId).Any()) 
            && false == db.IsTakipDetays.Where(z => z.Masterid == x.id && z.Sorumlu == AktifKullaniciId && z.Durumid == 3).Any())
            .OrderBy(x => x.KayitTarih).OrderBy(x => x.id).ToList();
            return View(YapacagimIs);
        }

        public ActionResult IsYaptiklarim(int id)
        {
            string KullaniciNo = Session["KullaniciNo"].ToString();
            int AktifKullaniciId = db.Kullanicilars.FirstOrDefault(x => x.KullaniciNo == KullaniciNo).id;
            var YapilanIs = db.IsTakipDetays.Where(x => x.Masterid == id && x.Sorumlu == AktifKullaniciId).ToList();
            ViewBag.Durumlar = db.IsTakipDurumus.ToList();
            ViewBag.Masterid = id;
            return View(YapilanIs);
        }

        [HttpPost]
        public ActionResult YapilanEkle(int id, IsTakipDetay ITD, int TamamlanmaYuzdesi)
        {
            string KullaniciNo = Session["KullaniciNo"].ToString();
            int AktifKullaniciId = db.Kullanicilars.FirstOrDefault(x => x.KullaniciNo == KullaniciNo).id;
            int MasterTamamlanmaYuzdesi = db.IsTakipMasters.FirstOrDefault(x => x.id == id).TamamlanmaYuzdesi;
            if (TamamlanmaYuzdesi >= MasterTamamlanmaYuzdesi)
            {
                ITD.KayitTarihi = DateTime.Now;
                ITD.Tarih = DateTime.Now.Date;
                ITD.Masterid = id;
                ITD.Sorumlu = AktifKullaniciId;
                IsTakipMaster IsTakipM = db.IsTakipMasters.FirstOrDefault(x => x.id == id);
                IsTakipM.TamamlanmaYuzdesi = TamamlanmaYuzdesi;
                db.SaveChanges();
                IsTakipSorumlular ITS = db.IsTakipSorumlulars.FirstOrDefault(x => x.Masterid == id && x.Sorumlu == AktifKullaniciId);
                ITS.DurumuId = ITD.Durumid;
                db.SaveChanges();
                db.IsTakipDetays.Add(ITD);
                db.SaveChanges();
                var IsBittiMi = db.IsTakipSorumlulars.Where(x => x.Masterid == id && false == db.IsTakipDetays.Where
                (y => y.Masterid == x.Masterid && y.Sorumlu == x.Sorumlu && y.Durumid == 3).Any()).ToList();
                if (IsBittiMi.Count == 0)
                {
                    IsTakipMaster ITM = db.IsTakipMasters.FirstOrDefault(x => x.id == id);
                    ITM.Kapandi = true;
                    db.SaveChanges();
                }
                return RedirectToAction("IsYaptiklarim", "Kullanici", new { id = id });
            }
            TempData["AlertMessage"] = "İsin Tamamlanma Yuzdesi Bir Onceki Degerden Dusuk Olamaz.";
            return RedirectToAction("IsYaptiklarim", "Kullanici", new { id = id });

        }


        public ActionResult BitmisIslerim()
        {
            string KullaniciNo = Session["KullaniciNo"].ToString();
            int AktifKullaniciId = db.Kullanicilars.FirstOrDefault(x => x.KullaniciNo == KullaniciNo).id;
            var BitmisIsler = db.IsTakipMasters.Where(x => x.IsiVerenId == AktifKullaniciId && x.Kapandi == true).ToList();
            return View(BitmisIsler);
        }


        public ActionResult IzlenenIsler()
        {
            string KullaniciNo = Session["KullaniciNo"].ToString();
            int AktifKullaniciId = db.Kullanicilars.FirstOrDefault(x => x.KullaniciNo == KullaniciNo).id;
            var Izlediklerim = db.IsTakipMasters.Where(x => x.Kapandi == false
            && true == db.IsTakipSorumlulars.Where(y => y.Masterid == x.id 
            && true == db.IsTakipIzlemes.Where(z => z.Izleyen == AktifKullaniciId && z.Izlenen == y.Sorumlu).Any()).Any()).ToList();
            return View(Izlediklerim);
        }

        [HttpPost]
        public ActionResult IzlenenIsler(DateTime Aralik1, DateTime Aralik2, int Durumu)
        {
            string KullaniciNo = Session["KullaniciNo"].ToString();
            int AktifKullaniciId = db.Kullanicilars.FirstOrDefault(x => x.KullaniciNo == KullaniciNo).id;
            if (Durumu == 0)
            {
               var Izlediklerim = db.IsTakipMasters.Where(x => x.Kapandi == false 
               && true == db.IsTakipSorumlulars.Where(y => y.Masterid == x.id 
               && true == db.IsTakipIzlemes.Where(z => z.Izleyen == AktifKullaniciId && z.Izlenen == y.Sorumlu).Any()).Any()).ToList();
               return View(Izlediklerim);
            }
            else
            {
                var Izlediklerim = db.IsTakipMasters.Where(x => x.Kapandi == true 
                && Aralik1 <= x.KayitTarih && x.KayitTarih <= Aralik2 
                && true == db.IsTakipSorumlulars.Where(y => y.Masterid == x.id && true == db.IsTakipIzlemes.Where(
                z => z.Izleyen == AktifKullaniciId && z.Izlenen == y.Sorumlu).Any()).Any()).ToList();
                return View(Izlediklerim);
            }
        }

        public ActionResult MusteriIstekleri()
        {
            var MusteriIstekleri = db.MusteriIsteklers.ToList();
            return View(MusteriIstekleri);
        }

        public ActionResult KullaniciGiris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KullaniciGiris(string KullaniciNo, string Sifre)
        {
            var kullanici = db.Kullanicilars.FirstOrDefault(x => x.KullaniciNo == KullaniciNo && x.Sifre == Sifre);
            var musteri = db.Musterilers.FirstOrDefault(x => x.SirketNo == KullaniciNo && x.SirketSifre == Sifre);
            if (kullanici != null)
            {
                Session["KullaniciNo"] = kullanici.KullaniciNo;
                Session["Rol"] = kullanici.IsTakipRoller.RolAdi;
                Session["KullaniciAdi"] = kullanici.KullaniciAdi;
                return RedirectToAction("Index", "Kullanici");
            }
            else if (musteri != null)
            {
                Session["KullaniciNo"] = musteri.SirketNo;
                Session["Rol"] = "Müşteri";
                Session["KullaniciAdi"] = musteri.SirketAdi;
                return RedirectToAction("Index", "Musteri");
            }
            else
            {
                ViewBag.Mesaj = "Girilen Bilgilere Ait Bir Kayıt Bulunamadı";
                return View();
            }
        }
        public ActionResult KullaniciCikis()
        {
            Session["KullanıcıNo"] = null;
            Session["Rol"] = null;
            Session["KullaniciAdi"] = null;
            return RedirectToAction("KullaniciGiris", "Kullanici");
        }

    }
}
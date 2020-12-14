using CoreDepartman2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDepartman2.Controllers
{
    public class PersonelController : Controller
    {
        Context c = new Context();

        [Authorize]     // Kullanıcı Personeller sayfasına tıkladığında Giriş Yap sayfası karşısına çıkacak.
        public IActionResult Index()
        {
            var deger = c.Personels.Include(personel=>personel.Birim).ToList();
            return View(deger);
        }

        [HttpGet]
        public IActionResult YeniPersonel()
        {
            List<SelectListItem> degerler = (from birim in c.Birims.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = birim.Ad,
                                                 Value = birim.Id.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public IActionResult YeniPersonel(Personel p)
        {
            var per = c.Birims.Where(birim => birim.Id == p.Birim.Id).FirstOrDefault();
            p.Birim = per;
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult PersonelSil(int id)
        {
            var index = c.Personels.Find(id);
            c.Personels.Remove(index);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult PersonelGetir(int id)
        {
            var personel = c.Personels.Find(id);
            return View("PersonelGetir", personel);
        }

        public IActionResult PersonelGuncelle(Personel p)
        {
            var personel = c.Personels.Find(p.Id);
            // Personel güncellerken burada hata veriyor 
            personel.Ad = p.Ad;
            personel.Soyad = p.Soyad;
            personel.Sehir = p.Sehir;
            personel.BirimId = p.BirimId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

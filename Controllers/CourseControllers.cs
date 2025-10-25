using BtkAkademi.Models;
using BtkAkademi.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BtkAkademi.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;

        // 🔹 Veritabanı bağlantısını almak için dependency injection
        public CourseController(AppDbContext context)
        {
            _context = context;
        }

        // 🔹 Ana sayfa
        public IActionResult Index()
        {
            return View();
        }

        // 🔹 GET: Başvuru formunu görüntüle
        public IActionResult Apply()
        {
            return View();
        }

        // 🔹 POST: Form gönderilince çalışır
        [HttpPost]
        public IActionResult Apply(Candidate model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.ApplyAt = DateTime.Now;
                    _context.Candidates.Add(model);
                    _context.SaveChanges();

                    ModelState.Clear();
                    return View("ApplyResult", model);
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "Kayıt işlemi sırasında bir hata oluştu: " + ex.Message;
                }
            }
            return View(model);
        }

        // 🔹 Tüm başvuruları listeleme (tek List metodu)
        public IActionResult List(string search)
        {
            var candidates = from c in _context.Candidates select c;

            if (!string.IsNullOrEmpty(search))
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                candidates = candidates.Where(c =>
                    c.FirstName.Contains(search) ||
                    c.LastName.Contains(search) ||
                    c.Email.Contains(search) ||
                    c.Course.Contains(search));
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }

            return View(candidates.ToList());
        }

        // 🔹 Başvuru detaylarını göster
        public IActionResult Details(int id)
        {
            var candidate = _context.Candidates.FirstOrDefault(c => c.Id == id);
            if (candidate == null)
            {
                TempData["Message"] = "Kayıt bulunamadı.";
                return RedirectToAction("List");
            }

            return View(candidate);
        }

        // 🔹 GET: Düzenleme formunu göster
        public IActionResult Edit(int id)
        {
            var candidate = _context.Candidates.FirstOrDefault(c => c.Id == id);
            if (candidate == null)
            {
                TempData["Message"] = "Düzenlenecek kayıt bulunamadı.";
                return RedirectToAction("List");
            }
            return View(candidate);
        }

        // 🔹 POST: Düzenleme formundan gelen veriyi kaydet
        [HttpPost]
        public IActionResult Edit(Candidate model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingCandidate = _context.Candidates.FirstOrDefault(c => c.Id == model.Id);
                    if (existingCandidate == null)
                    {
                        TempData["Message"] = "Kayıt bulunamadı.";
                        return RedirectToAction("List");
                    }

                    existingCandidate.FirstName = model.FirstName;
                    existingCandidate.LastName = model.LastName;
                    existingCandidate.Email = model.Email;
                    existingCandidate.Age = model.Age;
                    existingCandidate.Course = model.Course;

                    _context.SaveChanges();
                    TempData["Message"] = "Kayıt başarıyla güncellendi.";

                    return RedirectToAction("List");
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "Güncelleme sırasında hata oluştu: " + ex.Message;
                }
            }
            return View(model);
        }

        // 🔹 Başvuru silme işlemi
        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var candidate = _context.Candidates.FirstOrDefault(c => c.Id == id);
                if (candidate == null)
                {
                    TempData["Message"] = "Silinmek istenen kayıt bulunamadı.";
                    return RedirectToAction("List");
                }

                _context.Candidates.Remove(candidate);
                _context.SaveChanges();

                TempData["Message"] = "Kayıt başarıyla silindi.";
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Silme sırasında hata oluştu: " + ex.Message;
            }

            return RedirectToAction("List");
        }
    }
}

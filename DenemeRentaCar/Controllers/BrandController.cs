using DenemeRentaCar.Entities;
using DenemeRentaCar.Models;
using Microsoft.AspNetCore.Mvc;

namespace DenemeRentaCar.Controllers
{
    public class BrandController : Controller
    {
        public IActionResult BrandList()
        {
            DatabaseContext db = new DatabaseContext();
            List<Brand> brands = new List<Brand>();
            brands = db.Brands.ToList();
            return View(brands);
        }

        public IActionResult BrandCreate()
        {

            return View();
        }

        [HttpPost]
        public IActionResult BrandCreate(BrandNewModel model)
        {
            DatabaseContext db = new DatabaseContext();
            Brand brand = new Brand();
            if (db.Brands.Any(x => x.Name == model.Name))
            {
                ModelState.AddModelError("Name", "Daha önce tanımlanan marka");
            }

            if (ModelState.IsValid)
            {
                brand.Name = model.Name;
                brand.Description = model.Description;

                db.Brands.Add(brand);
                db.SaveChanges();
                return RedirectToAction("BrandList");
            }
            return View(model);

        }

        public IActionResult BrandEdit(int brandId)
        {
            DatabaseContext db = new DatabaseContext();
            Brand brand = db.Brands.Find(brandId);
            BrandEditModel brandEdit = new BrandEditModel();
            brandEdit.Name = brand.Name;
            brandEdit.Description = brand.Description;
            return View(brandEdit);
        }

        [HttpPost]
        public IActionResult BrandEdit(int brandId, BrandEditModel model)
        {
            DatabaseContext db = new DatabaseContext();
            Brand brand = db.Brands.Find(brandId);
            brand.Name = model.Name;
            brand.Description = model.Description;

            db.SaveChanges();
            return RedirectToAction("BrandList");
        }

        public IActionResult BrandDelete(int brandId)
        {
            DatabaseContext db = new DatabaseContext();
            Brand brand = db.Brands.Find(brandId);
            db.Brands.Remove(brand);
            db.SaveChanges();
            return RedirectToAction("BrandList");
        }
    }
}

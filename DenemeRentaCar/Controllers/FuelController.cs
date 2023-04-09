using DenemeRentaCar.Entities;
using DenemeRentaCar.Models;
using Microsoft.AspNetCore.Mvc;

namespace DenemeRentaCar.Controllers
{
    public class FuelController : Controller
    {
        public IActionResult FuelList()
        {
            DatabaseContext db = new DatabaseContext();
            List<Fuel> fuels = new List<Fuel>();
            fuels = db.Fuels.ToList();
            return View(fuels);
        }

        public IActionResult FuelCreate()
        {

            return View();
        }

        [HttpPost]
        public IActionResult FuelCreate(FuelNewModel model)
        {

            DatabaseContext db = new DatabaseContext();
            Fuel fuel = new Fuel();
            if (db.Fuels.Any(x => x.Name == model.Name))
            {
                ModelState.AddModelError("Name", "Daha önce tanımlanan yakıt");
            }

            if (ModelState.IsValid)
            {
                fuel.Name = model.Name;

                db.Fuels.Add(fuel);
                db.SaveChanges();
                return RedirectToAction("FuelList");
            }
            return View(model);
        }

        public IActionResult FuelEdit(int fuelId)
        {
            DatabaseContext db = new DatabaseContext();
            Fuel fuel = db.Fuels.Find(fuelId);
            FuelEditModel fuelEdit = new FuelEditModel();
            fuelEdit.Name = fuelEdit.Name;

            return View(fuelEdit);
        }

        [HttpPost]
        public IActionResult FuelEdit(int fuelId, FuelEditModel model)
        {
            DatabaseContext db = new DatabaseContext();
            Fuel fuel = db.Fuels.Find(fuelId);
            fuel.Name = model.Name;

            db.SaveChanges();
            return RedirectToAction("FuelList");
        }

        public IActionResult FuelDelete(int fuelId)
        {
            DatabaseContext db = new DatabaseContext();
            Fuel fuel = db.Fuels.Find(fuelId);
            db.Fuels.Remove(fuel);
            db.SaveChanges();
            return RedirectToAction("FuelList");
        }
    }
}

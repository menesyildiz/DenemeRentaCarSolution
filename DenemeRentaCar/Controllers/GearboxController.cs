using DenemeRentaCar.Entities;
using DenemeRentaCar.Models;
using Microsoft.AspNetCore.Mvc;

namespace DenemeRentaCar.Controllers
{
    public class GearboxController : Controller
    {
        public IActionResult GearboxList()
        {
            DatabaseContext db = new DatabaseContext();
            List<Gearbox> gearboxes = new List<Gearbox>();
            gearboxes = db.GearBoxes.ToList();
            return View(gearboxes);
        }

        public IActionResult GearboxCreate()
        {

            return View();
        }

        [HttpPost]
        public IActionResult GearboxCreate(GearboxNewModel model)
        {

            DatabaseContext db = new DatabaseContext();
            Gearbox gearbox = new Gearbox();
            if (db.GearBoxes.Any(x => x.Type == model.Type))
            {
                ModelState.AddModelError("Type", "Daha önce tanımlanan vites tipi");
            }

            if (ModelState.IsValid)
            {
                gearbox.Type = model.Type;

                db.GearBoxes.Add(gearbox);
                db.SaveChanges();
                return RedirectToAction("GearboxList");
            }
            return View(model);
        }

        public IActionResult GearboxEdit(int gearboxId)
        {
            DatabaseContext db = new DatabaseContext();
            Gearbox gearbox = db.GearBoxes.Find(gearboxId);
            GearboxEditModel gearboxEdit = new GearboxEditModel();
            gearboxEdit.Type = gearbox.Type;

            return View(gearboxEdit);
        }

        [HttpPost]
        public IActionResult GearboxEdit(int gearboxId, GearboxEditModel model)
        {
            DatabaseContext db = new DatabaseContext();
            Gearbox gearbox = db.GearBoxes.Find(gearboxId);
            gearbox.Type = model.Type;

            db.SaveChanges();
            return RedirectToAction("GearboxList");
        }

        public IActionResult GearboxDelete(int gearboxId)
        {
            DatabaseContext db = new DatabaseContext();
            Gearbox gearbox = db.GearBoxes.Find(gearboxId);
            db.GearBoxes.Remove(gearbox);
            db.SaveChanges();
            return RedirectToAction("GearboxList");
        }

    }
}

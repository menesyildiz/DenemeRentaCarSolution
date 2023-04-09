using DenemeRentaCar.Entities;
using DenemeRentaCar.Models;
using Microsoft.AspNetCore.Mvc;

namespace DenemeRentaCar.Controllers
{
    public class ColourController : Controller
    {
        public IActionResult ColourList()
        {
            DatabaseContext db = new DatabaseContext();
            List<Colour> colours = new List<Colour>();
            colours = db.Colours.ToList();
            return View(colours);
        }

        public IActionResult ColourCreate()
        {

            return View();
        }

        [HttpPost]
        public IActionResult ColourCreate(ColourNewModel model)
        {

            DatabaseContext db = new DatabaseContext();
            Colour colour = new Colour();
            if (db.Colours.Any(x => x.Name == model.Name))
            {
                ModelState.AddModelError("Name", "Daha önce tanımlanan renk");
            }

            if (ModelState.IsValid)
            {
                colour.Name = model.Name;

                db.Colours.Add(colour);
                db.SaveChanges();
                return RedirectToAction("ColourList");
            }
            return View(model);
        }

        public IActionResult ColourEdit(int colourId)
        {
            DatabaseContext db = new DatabaseContext();
            Colour colour = db.Colours.Find(colourId);
            ColourEditModel colourEdit = new ColourEditModel();
            colourEdit.Name = colour.Name;

            return View(colourEdit);
        }

        [HttpPost]
        public IActionResult ColourEdit(int colourId, ColourEditModel model)
        {
            DatabaseContext db = new DatabaseContext();
            Colour colour = db.Colours.Find(colourId);
            colour.Name = model.Name;

            db.SaveChanges();
            return RedirectToAction("ColourList");
        }

        public IActionResult ColourDelete(int colourId)
        {
            DatabaseContext db = new DatabaseContext();
            Colour colour = db.Colours.Find(colourId);
            db.Colours.Remove(colour);
            db.SaveChanges();
            return RedirectToAction("ColourList");
        }
    }
}

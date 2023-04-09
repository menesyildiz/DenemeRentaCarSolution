using DenemeRentaCar.Entities;
using DenemeRentaCar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DenemeRentaCar.Controllers
{
    public class CarController : Controller
    {
        public IActionResult CarList()
        {
            DatabaseContext db = new DatabaseContext();
            List<Car> cars = db.Cars.Include(x => x.Brand)
                                    .Include(x => x.Gearbox)
                                    .Include(x => x.Fuel)
                                    .Include(x => x.Colour)
                                    .ToList();
            return View(cars);
        }

        public IActionResult CarCreate()
        {
            DatabaseContext db = new DatabaseContext();
            List<Brand> brands = db.Brands.ToList();
            SelectList blist = new SelectList(brands, "Id", "Name");

            List<Gearbox> gearboxes = db.GearBoxes.ToList();
            SelectList glist = new SelectList(gearboxes, "Id", "Type");

            List<Fuel> fuels = db.Fuels.ToList();
            SelectList flist = new SelectList(fuels, "Id", "Name");

            List<Colour> colours = db.Colours.ToList();
            SelectList clist = new SelectList(colours, "Id", "Name");

            CarNewModel car = new CarNewModel();
            car.Brands = blist;
            car.Gearboxes = glist;
            car.Fuels = flist;
            car.Colours = clist;

            return View(car);
        }

        [HttpPost]
        public IActionResult CarCreate(CarNewModel model)
        {
            DatabaseContext db = new DatabaseContext();
            Car car = new Car();

            if (db.Cars.Any(x=>x.Plate==model.Plate))
            {
                ModelState.AddModelError("Plate", "Daha önce tanımlanan plaka");
            }

            if (ModelState.IsValid)
            {
                car.Plate = model.Plate;
                car.Name = model.Name;
                car.Category = model.Category;
                car.Year = model.Year;
                car.Price = model.Price;
                car.Passengers = model.Passengers;
                car.HasDriver = model.HasDriver;
                car.Rented = false;
                car.BrandId = model.BrandId;
                car.GearboxId = model.GearboxId;
                car.FuelId = model.FuelId;
                car.ColourId = model.ColourId;

                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("CarList");
            }

            List<Brand> brands = db.Brands.ToList();
            SelectList blist = new SelectList(brands, "Id", "Name");
            model.Brands = blist;

            List<Gearbox> gearboxes = db.GearBoxes.ToList();
            SelectList glist = new SelectList(gearboxes, "Id", "Type");
            model.Gearboxes = glist;

            List<Fuel> fuels = db.Fuels.ToList();
            SelectList flist = new SelectList(fuels, "Id", "Name");
            model.Fuels = flist;

            List<Colour> colours = db.Colours.ToList();
            SelectList clist = new SelectList(colours, "Id", "Name");
            model.Colours = clist;

            return View(model);
        }

        public IActionResult CarEdit(int carId)
        {
            DatabaseContext db = new DatabaseContext();
            Car car = db.Cars.Find(carId);

            List<Brand> brands = db.Brands.ToList();
            SelectList blist = new SelectList(brands, "Id", "Name");

            List<Colour> colours = db.Colours.ToList();
            SelectList clist = new SelectList(colours, "Id", "Name");

            List<Fuel> fuels = db.Fuels.ToList();
            SelectList flist = new SelectList(fuels, "Id", "Name");

            List<Gearbox> gearboxes = db.GearBoxes.ToList();
            SelectList glist = new SelectList(gearboxes, "Id", "Type");

            CarEditModel carEdit = new CarEditModel();
            carEdit.Brands = blist;
            carEdit.Colours = clist;
            carEdit.Fuels = flist;
            carEdit.Gearboxes = glist;
            carEdit.Plate = car.Plate;
            carEdit.Category = car.Category;
            carEdit.Name = car.Name;
            carEdit.Passengers = car.Passengers;
            carEdit.HasDriver = car.HasDriver;
            carEdit.Price = car.Price;
            carEdit.Year = car.Year;
            carEdit.BrandId = car.BrandId;
            carEdit.ColourId = car.ColourId;
            carEdit.FuelId = car.FuelId;
            carEdit.GearboxId = car.GearboxId;

            return View(carEdit);
        }

        [HttpPost]
        public IActionResult CarEdit(int carId, CarEditModel model)
        {
            DatabaseContext db = new DatabaseContext();
            Car car = db.Cars.Find(carId);

            List<Brand> brands = db.Brands.ToList();
            SelectList blist = new SelectList(brands, "Id", "Name");

            List<Colour> colours = db.Colours.ToList();
            SelectList clist = new SelectList(colours, "Id", "Name");

            List<Fuel> fuels = db.Fuels.ToList();
            SelectList flist = new SelectList(fuels, "Id", "Name");

            List<Gearbox> gearboxes = db.GearBoxes.ToList();
            SelectList glist = new SelectList(gearboxes, "Id", "Type");

            model.Brands = blist;
            model.Colours = clist;
            model.Fuels = flist;
            model.Gearboxes = glist;
            car.Plate = model.Plate;
            car.Category = model.Category;
            car.Name = model.Name;
            car.Passengers = model.Passengers;
            car.HasDriver = model.HasDriver;
            car.Year = model.Year;
            car.Price = model.Price;
            car.BrandId = model.BrandId;
            car.ColourId = model.ColourId;
            car.FuelId = model.FuelId;
            car.GearboxId = model.GearboxId;

            db.SaveChanges();
            return RedirectToAction("CarList");
        }

        public IActionResult CarDelete(int carId)
        {
            DatabaseContext db = new DatabaseContext();
            Car car = db.Cars.Find(carId);
            db.Cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("CarList");

        }


    }
}

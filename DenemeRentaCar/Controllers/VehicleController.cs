using DenemeRentaCar.Entities;
using DenemeRentaCar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DenemeRentaCar.Controllers
{
    public class VehicleController : Controller
    {
        public IActionResult VehicleList()
        {
            DatabaseContext db = new DatabaseContext();
            List<Car> vcars = db.Cars.Include(x => x.Brand)
                                     .Include(x => x.Gearbox)
                                     .Include(x => x.Fuel)
                                     .Include(x => x.Colour)
                                     
                                     .Where(x => x.Category == "Binek").ToList();
            
          

            return View(vcars);
        }

        public IActionResult VehicleRent(int carId)
        {
            DatabaseContext db = new DatabaseContext();
            Car car = db.Cars.Find(carId);

            List<Car> vcars = db.Cars.Include(x => x.Brand)
                                     .Include(x => x.Gearbox)
                                     .Include(x => x.Fuel)
                                     .Include(x => x.Colour)
                                     .Where(x => x.Category == "Binek").ToList();

            List<Customer> customers = db.Customers.ToList();
            SelectList customerlist = new SelectList(customers, "Id", "TC");


            RentModel vrent = new RentModel();
            vrent.Car = car;
            vrent.Customers = customerlist;

            return View(vrent);
        }

        [HttpPost]
        public IActionResult VehicleRent(int carId, RentModel model)
        {
            DatabaseContext db = new DatabaseContext();
            Car car = db.Cars.Find(carId);
            Renter renter = new Renter();
            List<Car> vcars = db.Cars.Include(x => x.Brand)
                                     .Include(x => x.Gearbox)
                                     .Include(x => x.Fuel)
                                     .Include(x => x.Colour)
                                     .Where(x => x.Category == "Binek").ToList();

            List<Customer> customers = db.Customers.ToList();
            SelectList customerlist = new SelectList(customers, "Id", "TC");
            model.Customers = customerlist;

            renter.RentDate = DateTime.Now;
            renter.DeliveryDate = model.DeliveryDate;
            renter.Plate = model.Car.Plate;
            
            car.Rented = true;
            car.DeliveryDate = DateTime.Now;

            db.SaveChanges();
            return RedirectToAction("VehicleList");
        }


    }
}

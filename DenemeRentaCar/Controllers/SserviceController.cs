using DenemeRentaCar.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DenemeRentaCar.Controllers
{
    public class SserviceController : Controller
    {
        public IActionResult SserviceList()
        {
            DatabaseContext db = new DatabaseContext();
            List<Car> Scar = db.Cars.Include(x=>x.Brand)
                                    .Include(x => x.Gearbox)
                                    .Include(x => x.Fuel)
                                    .Include(x => x.Colour)
                                    .Where(x=>x.HasDriver=="Evet").ToList();

            return View(Scar);
        }
    }
}

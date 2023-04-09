using DenemeRentaCar.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DenemeRentaCar.Controllers
{
    public class SUVController : Controller
    {
        public IActionResult SUVList()
        {
            DatabaseContext db = new DatabaseContext();
            List<Car> SUVcar = db.Cars.Include(x => x.Brand)
                                      .Include(x => x.Gearbox)
                                      .Include(x => x.Fuel)
                                      .Include(x => x.Colour)
                                      .Where(x => x.Category=="SUV").ToList();

            return View(SUVcar);
        }
    }
}

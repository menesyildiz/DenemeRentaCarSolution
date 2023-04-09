using DenemeRentaCar.Entities;
using DenemeRentaCar.Models;
using Microsoft.AspNetCore.Mvc;

namespace DenemeRentaCar.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult CustomerList()
        {
            DatabaseContext db = new DatabaseContext();
            List<Customer> customers = new List<Customer>();
            customers = db.Customers.ToList();
            return View(customers);
        }

        public IActionResult CustomerCreate()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CustomerCreate(CustomerNewModel model)
        {
            DatabaseContext db = new DatabaseContext();
            Customer customer = new Customer();
            if (db.Customers.Any(x => x.TC == model.TC))
            {
                ModelState.AddModelError("TC", "Daha önce tanımlanan müşteri");
            }

            if (ModelState.IsValid)
            {
                customer.TC = model.TC;
                customer.Name = model.Name;
                customer.Surname = model.Surname;

                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("CustomerList");
            }
            return View(model);

        }

        public IActionResult CustomerEdit(int customerId)
        {
            DatabaseContext db = new DatabaseContext();
            Customer customer = db.Customers.Find(customerId);
            CustomerEditModel customerEdit = new CustomerEditModel();
            customerEdit.TC = customer.TC;
            customerEdit.Name = customer.Name;
            customerEdit.Surname = customer.Surname;
            return View(customerEdit);
        }

        [HttpPost]
        public IActionResult CustomerEdit(int customerId, CustomerEditModel model)
        {
            DatabaseContext db = new DatabaseContext();
            Customer customer = db.Customers.Find(customerId);
            customer.TC=model.TC;
            customer.Name = model.Name;
            customer.Surname = model.Surname;

            db.SaveChanges();
            return RedirectToAction("CustomerList");
        }

        public IActionResult CustomerDelete(int customerId)
        {
            DatabaseContext db = new DatabaseContext();
            Customer customer = db.Customers.Find(customerId);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("CustomerList");
        }
    }
}

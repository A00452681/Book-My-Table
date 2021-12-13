using Book_My_Table.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Book_My_Table.BusinessLogic;
using System.Data;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Book_My_Table.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Booking()
        {
            CustomerReg ctx = new CustomerReg();
            List<Restaurant> restaurantlist = ctx.Restaurant.Where(res => res.Address.Contains("A-10, Spring Road")).ToList<Restaurant>();
            ViewBag.Restaurant = new SelectList(restaurantlist, "RestaurantId", "RestaurantName");
            return View();
        }

        [HttpGet]
        public IActionResult GetNames(string text)
        {
            List<Restaurant> restaurantlist = new List<Restaurant>();
            CustomerReg ctx = new CustomerReg();
            if (!string.IsNullOrEmpty(text))
            {
                restaurantlist = ctx.Restaurant.Where(res => res.Address.Contains(text)).ToList<Restaurant>();
            }

            List<object> listObj = new List<object>();
            foreach (Restaurant rest in restaurantlist)
            {
                listObj.Add(new
                {
                    id = rest.RestaurantId,
                    name = rest.RestaurantName
                });
            }
            return Json(listObj, new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpPost]        
        [ValidateAntiForgeryToken]
        public IActionResult Book(Booking bookingModel)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = BookingDataProcessor.CreateBooking(bookingModel.BookingId,
                    bookingModel.CustomerId,
                    bookingModel.RestaurantId,
                    bookingModel.BookingDate,
                    bookingModel.BookingTime,
                    bookingModel.MealId
                    );
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

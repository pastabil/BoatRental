using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BoatRental.Models;

namespace BoatRental.Controllers
{
    public class BookNowController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookNowController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookNow
        public async Task<IActionResult> Index()
        {
            return View(await _context.Booking.ToListAsync());
        }

        // GET: BookNow/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookNow/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,PhoneNumber,Calendar,Destination,TripLength,Food,Drinks,TourGuide,Payment,Price")] BookNowDatabase bookNowDatabase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookNowDatabase);
                await _context.SaveChangesAsync();
                ViewBag.Message = "Dear "+bookNowDatabase.FirstName+"! Your reservation is completed";
                return View();
                //return RedirectToAction(nameof(Create));
            }
            return View(bookNowDatabase);
        }
    }
}
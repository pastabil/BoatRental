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
    public class AdminBookNowController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminBookNowController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AdminBookNow
        public async Task<IActionResult> Index()
        {
            return View(await _context.Booking.ToListAsync());
        }

        // GET: AdminBookNow/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookNowDatabase = await _context.Booking
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookNowDatabase == null)
            {
                return NotFound();
            }

            return View(bookNowDatabase);
        }

        // GET: AdminBookNow/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminBookNow/Create
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
                return RedirectToAction(nameof(Index));
            }
            return View(bookNowDatabase);
        }

        // GET: AdminBookNow/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookNowDatabase = await _context.Booking.FindAsync(id);
            if (bookNowDatabase == null)
            {
                return NotFound();
            }
            return View(bookNowDatabase);
        }

        // POST: AdminBookNow/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,PhoneNumber,Calendar,Destination,TripLength,Food,Drinks,TourGuide,Payment,Price")] BookNowDatabase bookNowDatabase)
        {
            if (id != bookNowDatabase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookNowDatabase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookNowDatabaseExists(bookNowDatabase.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bookNowDatabase);
        }

        // GET: AdminBookNow/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookNowDatabase = await _context.Booking
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookNowDatabase == null)
            {
                return NotFound();
            }

            return View(bookNowDatabase);
        }

        // POST: AdminBookNow/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookNowDatabase = await _context.Booking.FindAsync(id);
            _context.Booking.Remove(bookNowDatabase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookNowDatabaseExists(int id)
        {
            return _context.Booking.Any(e => e.Id == id);
        }
    }
}

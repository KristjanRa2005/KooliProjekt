using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Data;

namespace KooliProjekt.Controllers
{
    public class ReservationcsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationcsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reservationcs
        public async Task<IActionResult> Index()
        {
              return View(await _context.Reservationcs.ToListAsync());
        }

        // GET: Reservationcs/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.Reservationcs == null)
            {
                return NotFound();
            }

            var reservationcs = await _context.Reservationcs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reservationcs == null)
            {
                return NotFound();
            }

            return View(reservationcs);
        }

        // GET: Reservationcs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reservationcs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,AutoID,bron_len_min,KM")] Reservationcs reservationcs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservationcs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservationcs);
        }

        // GET: Reservationcs/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.Reservationcs == null)
            {
                return NotFound();
            }

            var reservationcs = await _context.Reservationcs.FindAsync(id);
            if (reservationcs == null)
            {
                return NotFound();
            }
            return View(reservationcs);
        }

        // POST: Reservationcs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,AutoID,bron_len_min,KM")] Reservationcs reservationcs)
        {
            if (id != reservationcs.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservationcs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationcsExists(reservationcs.ID))
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
            return View(reservationcs);
        }

        // GET: Reservationcs/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.Reservationcs == null)
            {
                return NotFound();
            }

            var reservationcs = await _context.Reservationcs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reservationcs == null)
            {
                return NotFound();
            }

            return View(reservationcs);
        }

        // POST: Reservationcs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reservationcs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Reservationcs'  is null.");
            }
            var reservationcs = await _context.Reservationcs.FindAsync(id);
            if (reservationcs != null)
            {
                _context.Reservationcs.Remove(reservationcs);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationcsExists(int id)
        {
          return _context.Reservationcs.Any(e => e.ID == id);
        }
    }
}

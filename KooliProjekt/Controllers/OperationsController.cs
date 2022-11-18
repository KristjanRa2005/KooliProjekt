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
    public class OperationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OperationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Operations
        public async Task<IActionResult> Index()
        {
              return View(await _context.Operations.ToListAsync());
        }

        // GET: Operations/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.Operations == null)
            {
                return NotFound();
            }

            var operations = await _context.Operations
                .FirstOrDefaultAsync(m => m.ID == id);
            if (operations == null)
            {
                return NotFound();
            }

            return View(operations);
        }

        // GET: Operations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Operations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CarID,opType,Package")] Operations operations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(operations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(operations);
        }

        // GET: Operations/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.Operations == null)
            {
                return NotFound();
            }

            var operations = await _context.Operations.FindAsync(id);
            if (operations == null)
            {
                return NotFound();
            }
            return View(operations);
        }

        // POST: Operations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CarID,opType,Package")] Operations operations)
        {
            if (id != operations.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(operations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OperationsExists(operations.ID))
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
            return View(operations);
        }

        // GET: Operations/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.Operations == null)
            {
                return NotFound();
            }

            var operations = await _context.Operations
                .FirstOrDefaultAsync(m => m.ID == id);
            if (operations == null)
            {
                return NotFound();
            }

            return View(operations);
        }

        // POST: Operations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Operations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Operations'  is null.");
            }
            var operations = await _context.Operations.FindAsync(id);
            if (operations != null)
            {
                _context.Operations.Remove(operations);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OperationsExists(int id)
        {
          return _context.Operations.Any(e => e.ID == id);
        }
    }
}

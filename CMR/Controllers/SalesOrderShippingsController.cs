using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CMR.Data;
using CMR.Models;

namespace CMR.Controllers
{
    public class SalesOrderShippingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesOrderShippingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SalesOrderShippings
        public async Task<IActionResult> Index()
        {
            return View(await _context.SalesOrderShipping.ToListAsync());
        }

        // GET: SalesOrderShippings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOrderShipping = await _context.SalesOrderShipping
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesOrderShipping == null)
            {
                return NotFound();
            }

            return View(salesOrderShipping);
        }

        // GET: SalesOrderShippings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalesOrderShippings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Line1,Line2,City,State,PostalCode,Country")] SalesOrderShipping salesOrderShipping)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesOrderShipping);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesOrderShipping);
        }

        // GET: SalesOrderShippings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOrderShipping = await _context.SalesOrderShipping.FindAsync(id);
            if (salesOrderShipping == null)
            {
                return NotFound();
            }
            return View(salesOrderShipping);
        }

        // POST: SalesOrderShippings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Line1,Line2,City,State,PostalCode,Country")] SalesOrderShipping salesOrderShipping)
        {
            if (id != salesOrderShipping.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesOrderShipping);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesOrderShippingExists(salesOrderShipping.Id))
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
            return View(salesOrderShipping);
        }

        // GET: SalesOrderShippings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOrderShipping = await _context.SalesOrderShipping
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesOrderShipping == null)
            {
                return NotFound();
            }

            return View(salesOrderShipping);
        }

        // POST: SalesOrderShippings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesOrderShipping = await _context.SalesOrderShipping.FindAsync(id);
            _context.SalesOrderShipping.Remove(salesOrderShipping);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesOrderShippingExists(int id)
        {
            return _context.SalesOrderShipping.Any(e => e.Id == id);
        }
    }
}

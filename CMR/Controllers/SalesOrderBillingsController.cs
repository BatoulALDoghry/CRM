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
    public class SalesOrderBillingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesOrderBillingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SalesOrderBillings
        public async Task<IActionResult> Index()
        {
            return View(await _context.SalesOrderBilling.ToListAsync());
        }

        // GET: SalesOrderBillings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOrderBilling = await _context.SalesOrderBilling
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesOrderBilling == null)
            {
                return NotFound();
            }

            return View(salesOrderBilling);
        }

        // GET: SalesOrderBillings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalesOrderBillings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Line1,Line2,City,State,PostalCode,Country")] SalesOrderBilling salesOrderBilling)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesOrderBilling);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesOrderBilling);
        }

        // GET: SalesOrderBillings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOrderBilling = await _context.SalesOrderBilling.FindAsync(id);
            if (salesOrderBilling == null)
            {
                return NotFound();
            }
            return View(salesOrderBilling);
        }

        // POST: SalesOrderBillings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Line1,Line2,City,State,PostalCode,Country")] SalesOrderBilling salesOrderBilling)
        {
            if (id != salesOrderBilling.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesOrderBilling);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesOrderBillingExists(salesOrderBilling.Id))
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
            return View(salesOrderBilling);
        }

        // GET: SalesOrderBillings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOrderBilling = await _context.SalesOrderBilling
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesOrderBilling == null)
            {
                return NotFound();
            }

            return View(salesOrderBilling);
        }

        // POST: SalesOrderBillings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesOrderBilling = await _context.SalesOrderBilling.FindAsync(id);
            _context.SalesOrderBilling.Remove(salesOrderBilling);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesOrderBillingExists(int id)
        {
            return _context.SalesOrderBilling.Any(e => e.Id == id);
        }
    }
}

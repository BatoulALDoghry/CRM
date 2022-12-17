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
    public class SalesOrderDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesOrderDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SalesOrderDetails
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SalesOrderDetails.Include(s => s.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SalesOrderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOrderDetails = await _context.SalesOrderDetails
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesOrderDetails == null)
            {
                return NotFound();
            }

            return View(salesOrderDetails);
        }

        // GET: SalesOrderDetails/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id");
            return View();
        }

        // POST: SalesOrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LineNumber,LinePrice,LineOrderdQty,TaxAmount,Total,ProductId")] SalesOrderDetails salesOrderDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesOrderDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", salesOrderDetails.ProductId);
            return View(salesOrderDetails);
        }

        // GET: SalesOrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOrderDetails = await _context.SalesOrderDetails.FindAsync(id);
            if (salesOrderDetails == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", salesOrderDetails.ProductId);
            return View(salesOrderDetails);
        }

        // POST: SalesOrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LineNumber,LinePrice,LineOrderdQty,TaxAmount,Total,ProductId")] SalesOrderDetails salesOrderDetails)
        {
            if (id != salesOrderDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesOrderDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesOrderDetailsExists(salesOrderDetails.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", salesOrderDetails.ProductId);
            return View(salesOrderDetails);
        }

        // GET: SalesOrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOrderDetails = await _context.SalesOrderDetails
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesOrderDetails == null)
            {
                return NotFound();
            }

            return View(salesOrderDetails);
        }

        // POST: SalesOrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesOrderDetails = await _context.SalesOrderDetails.FindAsync(id);
            _context.SalesOrderDetails.Remove(salesOrderDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesOrderDetailsExists(int id)
        {
            return _context.SalesOrderDetails.Any(e => e.Id == id);
        }
    }
}

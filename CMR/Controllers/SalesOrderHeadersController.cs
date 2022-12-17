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
    public class SalesOrderHeadersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesOrderHeadersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SalesOrderHeaders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SalesOrderHeader.Include(s => s.Customer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SalesOrderHeaders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOrderHeader = await _context.SalesOrderHeader
                .Include(s => s.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesOrderHeader == null)
            {
                return NotFound();
            }

            return View(salesOrderHeader);
        }

        // GET: SalesOrderHeaders/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id");
            return View();
        }

        // POST: SalesOrderHeaders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Status,Date,Tax,SubTotal,GrandTotal,CustomerId")] SalesOrderHeader salesOrderHeader)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesOrderHeader);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id", salesOrderHeader.CustomerId);
            return View(salesOrderHeader);
        }

        // GET: SalesOrderHeaders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOrderHeader = await _context.SalesOrderHeader.FindAsync(id);
            if (salesOrderHeader == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id", salesOrderHeader.CustomerId);
            return View(salesOrderHeader);
        }

        // POST: SalesOrderHeaders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Status,Date,Tax,SubTotal,GrandTotal,CustomerId")] SalesOrderHeader salesOrderHeader)
        {
            if (id != salesOrderHeader.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesOrderHeader);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesOrderHeaderExists(salesOrderHeader.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id", salesOrderHeader.CustomerId);
            return View(salesOrderHeader);
        }

        // GET: SalesOrderHeaders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOrderHeader = await _context.SalesOrderHeader
                .Include(s => s.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesOrderHeader == null)
            {
                return NotFound();
            }

            return View(salesOrderHeader);
        }

        // POST: SalesOrderHeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesOrderHeader = await _context.SalesOrderHeader.FindAsync(id);
            _context.SalesOrderHeader.Remove(salesOrderHeader);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesOrderHeaderExists(int id)
        {
            return _context.SalesOrderHeader.Any(e => e.Id == id);
        }
    }
}

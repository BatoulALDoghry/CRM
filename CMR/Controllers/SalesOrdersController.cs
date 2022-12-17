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
    public class SalesOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SalesOrders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SalesOrder.Include(s => s.Customer).Include(s => s.Product).Include(s => s.Sales_Order_Details).Include(s => s.Sales_Order_Header);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SalesOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOrder = await _context.SalesOrder
                .Include(s => s.Customer)
                .Include(s => s.Product)
                .Include(s => s.Sales_Order_Details)
                .Include(s => s.Sales_Order_Header)
                .FirstOrDefaultAsync(m => m.SalesOrderHeaderId == id);
            if (salesOrder == null)
            {
                return NotFound();
            }

            return View(salesOrder);
        }

        // GET: SalesOrders/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id");
            ViewData["SalesOrderDetailsId"] = new SelectList(_context.SalesOrderDetails, "Id", "Id");
            ViewData["SalesOrderHeaderId"] = new SelectList(_context.SalesOrderHeader, "Id", "Id");
            return View();
        }

        // POST: SalesOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SalesOrderHeaderId,CustomerId,SalesOrderDetailsId,ProductId")] SalesOrder salesOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id", salesOrder.CustomerId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", salesOrder.ProductId);
            ViewData["SalesOrderDetailsId"] = new SelectList(_context.SalesOrderDetails, "Id", "Id", salesOrder.SalesOrderDetailsId);
            ViewData["SalesOrderHeaderId"] = new SelectList(_context.SalesOrderHeader, "Id", "Id", salesOrder.SalesOrderHeaderId);
            return View(salesOrder);
        }

        // GET: SalesOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOrder = await _context.SalesOrder.FindAsync(id);
            if (salesOrder == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id", salesOrder.CustomerId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", salesOrder.ProductId);
            ViewData["SalesOrderDetailsId"] = new SelectList(_context.SalesOrderDetails, "Id", "Id", salesOrder.SalesOrderDetailsId);
            ViewData["SalesOrderHeaderId"] = new SelectList(_context.SalesOrderHeader, "Id", "Id", salesOrder.SalesOrderHeaderId);
            return View(salesOrder);
        }

        // POST: SalesOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,SalesOrderHeaderId,CustomerId,SalesOrderDetailsId,ProductId")] SalesOrder salesOrder)
        {
            if (id != salesOrder.SalesOrderHeaderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesOrderExists(salesOrder.SalesOrderHeaderId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id", salesOrder.CustomerId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", salesOrder.ProductId);
            ViewData["SalesOrderDetailsId"] = new SelectList(_context.SalesOrderDetails, "Id", "Id", salesOrder.SalesOrderDetailsId);
            ViewData["SalesOrderHeaderId"] = new SelectList(_context.SalesOrderHeader, "Id", "Id", salesOrder.SalesOrderHeaderId);
            return View(salesOrder);
        }

        // GET: SalesOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOrder = await _context.SalesOrder
                .Include(s => s.Customer)
                .Include(s => s.Product)
                .Include(s => s.Sales_Order_Details)
                .Include(s => s.Sales_Order_Header)
                .FirstOrDefaultAsync(m => m.SalesOrderHeaderId == id);
            if (salesOrder == null)
            {
                return NotFound();
            }

            return View(salesOrder);
        }

        // POST: SalesOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var salesOrder = await _context.SalesOrder.FindAsync(id);
            _context.SalesOrder.Remove(salesOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesOrderExists(int? id)
        {
            return _context.SalesOrder.Any(e => e.SalesOrderHeaderId == id);
        }
    }
}

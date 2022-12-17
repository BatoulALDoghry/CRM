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
    public class CustomerAddressesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerAddressesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CustomerAddresses
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomerAddress_1.ToListAsync());
        }

        // GET: CustomerAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerAddress = await _context.CustomerAddress_1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerAddress == null)
            {
                return NotFound();
            }

            return View(customerAddress);
        }

        // GET: CustomerAddresses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerAddresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Line1,Line2,City,State,PostalCode,Country,shipping_address_flag,billing_address_flag")] CustomerAddress customerAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerAddress);
        }

        // GET: CustomerAddresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerAddress = await _context.CustomerAddress_1.FindAsync(id);
            if (customerAddress == null)
            {
                return NotFound();
            }
            return View(customerAddress);
        }

        // POST: CustomerAddresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Line1,Line2,City,State,PostalCode,Country,shipping_address_flag,billing_address_flag")] CustomerAddress customerAddress)
        {
            if (id != customerAddress.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerAddressExists(customerAddress.Id))
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
            return View(customerAddress);
        }

        // GET: CustomerAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerAddress = await _context.CustomerAddress_1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerAddress == null)
            {
                return NotFound();
            }

            return View(customerAddress);
        }

        // POST: CustomerAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerAddress = await _context.CustomerAddress_1.FindAsync(id);
            _context.CustomerAddress_1.Remove(customerAddress);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerAddressExists(int id)
        {
            return _context.CustomerAddress_1.Any(e => e.Id == id);
        }
    }
}

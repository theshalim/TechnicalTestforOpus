using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechnicalTest.Data;
using TechnicalTest.Models;

namespace TechnicalTest.Controllers
{
    public class SalesMastersController : Controller
    {
        private readonly DataContext _context;

        public SalesMastersController(DataContext context)
        {
            _context = context;
        }

        // GET: SalesMasters
        public async Task<IActionResult> Index()
        {
            return View(await _context.SalesMasters.ToListAsync());
        }

        // GET: SalesMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesMaster = await _context.SalesMasters
                .FirstOrDefaultAsync(m => m.SalesMasterId == id);
            if (salesMaster == null)
            {
                return NotFound();
            }

            return View(salesMaster);
        }

        // GET: SalesMasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalesMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalesMasterId,Date,TotalQuantity,TotalPrice")] SalesMaster salesMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesMaster);
        }

        // GET: SalesMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesMaster = await _context.SalesMasters.FindAsync(id);
            if (salesMaster == null)
            {
                return NotFound();
            }
            return View(salesMaster);
        }

        // POST: SalesMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalesMasterId,Date,TotalQuantity,TotalPrice")] SalesMaster salesMaster)
        {
            if (id != salesMaster.SalesMasterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesMasterExists(salesMaster.SalesMasterId))
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
            return View(salesMaster);
        }

        // GET: SalesMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesMaster = await _context.SalesMasters
                .FirstOrDefaultAsync(m => m.SalesMasterId == id);
            if (salesMaster == null)
            {
                return NotFound();
            }

            return View(salesMaster);
        }

        // POST: SalesMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesMaster = await _context.SalesMasters.FindAsync(id);
            _context.SalesMasters.Remove(salesMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesMasterExists(int id)
        {
            return _context.SalesMasters.Any(e => e.SalesMasterId == id);
        }
    }
}

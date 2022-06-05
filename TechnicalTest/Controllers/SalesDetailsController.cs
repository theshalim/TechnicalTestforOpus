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
    public class SalesDetailsController : Controller
    {
        private readonly DataContext _context;

        public SalesDetailsController(DataContext context)
        {
            _context = context;
        }

        // GET: SalesDetails
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.SalesDetails.Include(s => s.ProductS).Include(s => s.SalesMasters);
            return View(await dataContext.ToListAsync());
        }

        // GET: SalesDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesDetail = await _context.SalesDetails
                .Include(s => s.ProductS)
                .Include(s => s.SalesMasters)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesDetail == null)
            {
                return NotFound();
            }

            return View(salesDetail);
        }

        // GET: SalesDetails/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductCode");
            ViewData["SalesMasterId"] = new SelectList(_context.SalesMasters, "SalesMasterId", "SalesMasterId");
            return View();
        }

        // POST: SalesDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SalesMasterId,ProductId,Quantity,TotalPrice")] SalesDetail salesDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductCode", salesDetail.ProductId);
            ViewData["SalesMasterId"] = new SelectList(_context.SalesMasters, "SalesMasterId", "SalesMasterId", salesDetail.SalesMasterId);
            return View(salesDetail);
        }

        // GET: SalesDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesDetail = await _context.SalesDetails.FindAsync(id);
            if (salesDetail == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductCode", salesDetail.ProductId);
            ViewData["SalesMasterId"] = new SelectList(_context.SalesMasters, "SalesMasterId", "SalesMasterId", salesDetail.SalesMasterId);
            return View(salesDetail);
        }

        // POST: SalesDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SalesMasterId,ProductId,Quantity,TotalPrice")] SalesDetail salesDetail)
        {
            if (id != salesDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesDetailExists(salesDetail.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductCode", salesDetail.ProductId);
            ViewData["SalesMasterId"] = new SelectList(_context.SalesMasters, "SalesMasterId", "SalesMasterId", salesDetail.SalesMasterId);
            return View(salesDetail);
        }

        // GET: SalesDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesDetail = await _context.SalesDetails
                .Include(s => s.ProductS)
                .Include(s => s.SalesMasters)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesDetail == null)
            {
                return NotFound();
            }

            return View(salesDetail);
        }

        // POST: SalesDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesDetail = await _context.SalesDetails.FindAsync(id);
            _context.SalesDetails.Remove(salesDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesDetailExists(int id)
        {
            return _context.SalesDetails.Any(e => e.Id == id);
        }
    }
}

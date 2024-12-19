using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebHoaqua.Models;
using X.PagedList;

namespace WebHoaqua.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminDetailImportBillsController : Controller
    {
        private readonly FruitShopContext _context;

        public AdminDetailImportBillsController(FruitShopContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminDetailImportBills
        public async Task<IActionResult> Index(int page = 1)
        {
            page = page < 1 ? 1 : page;
            var pageSize = 5;

            var fruitShopContext = _context.DetailImportBills.Include(d => d.Import).Include(d => d.Product);
            return View(await fruitShopContext.ToPagedListAsync(page, pageSize));
        }

        // GET: Admin/AdminDetailImportBills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DetailImportBills == null)
            {
                return NotFound();
            }

            var detailImportBill = await _context.DetailImportBills
                .Include(d => d.Import)
                .Include(d => d.Product)
                .FirstOrDefaultAsync(m => m.ImportId == id);
            if (detailImportBill == null)
            {
                return NotFound();
            }

            return View(detailImportBill);
        }

        // GET: Admin/AdminDetailImportBills/Create
        public IActionResult Create()
        {
            ViewData["ImportId"] = new SelectList(_context.ImportBills, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId");
            return View();
        }

        // POST: Admin/AdminDetailImportBills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImportId,ProductId,Quantity,PriceAitem,TotalPrice")] DetailImportBill detailImportBill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detailImportBill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ImportId"] = new SelectList(_context.ImportBills, "Id", "Id", detailImportBill.ImportId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", detailImportBill.ProductId);
            return View(detailImportBill);
        }

        // GET: Admin/AdminDetailImportBills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DetailImportBills == null)
            {
                return NotFound();
            }

            var detailImportBill = await _context.DetailImportBills.FindAsync(id);
            if (detailImportBill == null)
            {
                return NotFound();
            }
            ViewData["ImportId"] = new SelectList(_context.ImportBills, "Id", "Id", detailImportBill.ImportId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", detailImportBill.ProductId);
            return View(detailImportBill);
        }

        // POST: Admin/AdminDetailImportBills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImportId,ProductId,Quantity,PriceAitem,TotalPrice")] DetailImportBill detailImportBill)
        {
            if (id != detailImportBill.ImportId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detailImportBill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetailImportBillExists(detailImportBill.ImportId))
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
            ViewData["ImportId"] = new SelectList(_context.ImportBills, "Id", "Id", detailImportBill.ImportId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", detailImportBill.ProductId);
            return View(detailImportBill);
        }

        // GET: Admin/AdminDetailImportBills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DetailImportBills == null)
            {
                return NotFound();
            }

            var detailImportBill = await _context.DetailImportBills
                .Include(d => d.Import)
                .Include(d => d.Product)
                .FirstOrDefaultAsync(m => m.ImportId == id);
            if (detailImportBill == null)
            {
                return NotFound();
            }

            return View(detailImportBill);
        }

        // POST: Admin/AdminDetailImportBills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DetailImportBills == null)
            {
                return Problem("Entity set 'FruitShopContext.DetailImportBills'  is null.");
            }
            var detailImportBill = await _context.DetailImportBills.FindAsync(id);
            if (detailImportBill != null)
            {
                _context.DetailImportBills.Remove(detailImportBill);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetailImportBillExists(int id)
        {
          return (_context.DetailImportBills?.Any(e => e.ImportId == id)).GetValueOrDefault();
        }
    }
}

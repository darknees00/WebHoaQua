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
    public class AdminDetailExportBillsController : Controller
    {
        private readonly FruitShopContext _context;

        public AdminDetailExportBillsController(FruitShopContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminDetailExportBills
        public async Task<IActionResult> Index(int page = 1, string? name = null)
        {
            page = page < 1 ? 1 : page;
            var pageSize = 5;
            var fruitShopContext = _context.DetailExportBills.Include(d => d.Export).Include(d => d.Product).AsQueryable();
            if (!string.IsNullOrWhiteSpace(name))
                fruitShopContext = fruitShopContext.Where(x => x.Quantity == int.Parse(name));


            return View(fruitShopContext.ToPagedList(page, pageSize));
        }

        // GET: Admin/AdminDetailExportBills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DetailExportBills == null)
            {
                return NotFound();
            }

            var detailExportBill = await _context.DetailExportBills
                .Include(d => d.Export)
                .Include(d => d.Product)
                .FirstOrDefaultAsync(m => m.ExportId == id);
            if (detailExportBill == null)
            {
                return NotFound();
            }

            return View(detailExportBill);
        }

        // GET: Admin/AdminDetailExportBills/Create
        public IActionResult Create()
        {
            ViewData["ExportId"] = new SelectList(_context.ExportBills, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId");
            return View();
        }

        // POST: Admin/AdminDetailExportBills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExportId,ProductId,Quantity,TotalPrice,Discount")] DetailExportBill detailExportBill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detailExportBill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExportId"] = new SelectList(_context.ExportBills, "Id", "Id", detailExportBill.ExportId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", detailExportBill.ProductId);
            return View(detailExportBill);
        }

        // GET: Admin/AdminDetailExportBills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DetailExportBills == null)
            {
                return NotFound();
            }

            var detailExportBill = await _context.DetailExportBills.FindAsync(id);
            if (detailExportBill == null)
            {
                return NotFound();
            }
            ViewData["ExportId"] = new SelectList(_context.ExportBills, "Id", "Id", detailExportBill.ExportId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", detailExportBill.ProductId);
            return View(detailExportBill);
        }

        // POST: Admin/AdminDetailExportBills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExportId,ProductId,Quantity,TotalPrice,Discount")] DetailExportBill detailExportBill)
        {
            if (id != detailExportBill.ExportId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detailExportBill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetailExportBillExists(detailExportBill.ExportId))
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
            ViewData["ExportId"] = new SelectList(_context.ExportBills, "Id", "Id", detailExportBill.ExportId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", detailExportBill.ProductId);
            return View(detailExportBill);
        }

        // GET: Admin/AdminDetailExportBills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DetailExportBills == null)
            {
                return NotFound();
            }

            var detailExportBill = await _context.DetailExportBills
                .Include(d => d.Export)
                .Include(d => d.Product)
                .FirstOrDefaultAsync(m => m.ExportId == id);
            if (detailExportBill == null)
            {
                return NotFound();
            }

            return View(detailExportBill);
        }

        // POST: Admin/AdminDetailExportBills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DetailExportBills == null)
            {
                return Problem("Entity set 'FruitShopContext.DetailExportBills'  is null.");
            }
            var detailExportBill = await _context.DetailExportBills.FindAsync(id);
            if (detailExportBill != null)
            {
                _context.DetailExportBills.Remove(detailExportBill);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetailExportBillExists(int id)
        {
          return (_context.DetailExportBills?.Any(e => e.ExportId == id)).GetValueOrDefault();
        }
    }
}

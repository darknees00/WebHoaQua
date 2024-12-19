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
    public class AdminImportBillsController : Controller
    {
        private readonly FruitShopContext _context;

        public AdminImportBillsController(FruitShopContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminImportBills
        public async Task<IActionResult> Index(int page = 1, string name = "")
        {
            page = page < 1 ? 1 : page;
            var pageSize = 5;


            var fruitShopContext = _context.ImportBills.Include(i => i.Staff).Include(i => i.Suplier).AsQueryable();

            if (!string.IsNullOrEmpty(name))
                fruitShopContext = fruitShopContext.Where(x => x.SuplierId == Convert.ToInt32(name));


            return View(await fruitShopContext.ToPagedListAsync(page, pageSize));
        }

        // GET: Admin/AdminImportBills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ImportBills == null)
            {
                return NotFound();
            }

            var importBill = await _context.ImportBills
                .Include(i => i.Staff)
                .Include(i => i.Suplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (importBill == null)
            {
                return NotFound();
            }

            return View(importBill);
        }

        // GET: Admin/AdminImportBills/Create
        public IActionResult Create()
        {
            ViewData["StaffId"] = new SelectList(_context.Accounts, "Username", "Username");
            ViewData["SuplierId"] = new SelectList(_context.Supliers, "SuplierId", "SuplierId");
            return View();
        }

        // POST: Admin/AdminImportBills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ImportDate,StaffId,SuplierId,TotalPrice")] ImportBill importBill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(importBill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StaffId"] = new SelectList(_context.Accounts, "Username", "Username", importBill.StaffId);
            ViewData["SuplierId"] = new SelectList(_context.Supliers, "SuplierId", "SuplierId", importBill.SuplierId);
            return View(importBill);
        }

        // GET: Admin/AdminImportBills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ImportBills == null)
            {
                return NotFound();
            }

            var importBill = await _context.ImportBills.FindAsync(id);
            if (importBill == null)
            {
                return NotFound();
            }
            ViewData["StaffId"] = new SelectList(_context.Accounts, "Username", "Username", importBill.StaffId);
            ViewData["SuplierId"] = new SelectList(_context.Supliers, "SuplierId", "SuplierId", importBill.SuplierId);
            return View(importBill);
        }

        // POST: Admin/AdminImportBills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImportDate,StaffId,SuplierId,TotalPrice")] ImportBill importBill)
        {
            if (id != importBill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(importBill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImportBillExists(importBill.Id))
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
            ViewData["StaffId"] = new SelectList(_context.Accounts, "Username", "Username", importBill.StaffId);
            ViewData["SuplierId"] = new SelectList(_context.Supliers, "SuplierId", "SuplierId", importBill.SuplierId);
            return View(importBill);
        }

        // GET: Admin/AdminImportBills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ImportBills == null)
            {
                return NotFound();
            }

            var importBill = await _context.ImportBills
                .Include(i => i.Staff)
                .Include(i => i.Suplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (importBill == null)
            {
                return NotFound();
            }

            return View(importBill);
        }

        // POST: Admin/AdminImportBills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ImportBills == null)
            {
                return Problem("Entity set 'FruitShopContext.ImportBills'  is null.");
            }
            var importBill = await _context.ImportBills.FindAsync(id);
            if (importBill != null)
            {
                _context.ImportBills.Remove(importBill);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImportBillExists(int id)
        {
          return (_context.ImportBills?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

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
    public class AdminExportBillsController : Controller
    {
        private readonly FruitShopContext _context;

        public AdminExportBillsController(FruitShopContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminExportBills
        public async Task<IActionResult> Index(int page = 1, string? name = null)
        {
            page = page < 1 ? 1 : page;
            var pageSize = 5;


            var fruitShopContext = _context.ExportBills.Include(e => e.Customer).Include(e => e.Staff).AsQueryable();

            if (!string.IsNullOrEmpty(name))
                fruitShopContext = fruitShopContext.Where(x => x.Note.Contains(name));

            return View(fruitShopContext.ToPagedList(page, pageSize));
        }

        // GET: Admin/AdminExportBills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ExportBills == null)
            {
                return NotFound();
            }

            var exportBill = await _context.ExportBills
                .Include(e => e.Customer)
                .Include(e => e.Staff)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exportBill == null)
            {
                return NotFound();
            }

            return View(exportBill);
        }

        // GET: Admin/AdminExportBills/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
            ViewData["StaffId"] = new SelectList(_context.Accounts, "Username", "Username");
            return View();
        }

        // POST: Admin/AdminExportBills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ExportDate,StaffId,CustomerId,TotalPrice,Note")] ExportBill exportBill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exportBill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", exportBill.CustomerId);
            ViewData["StaffId"] = new SelectList(_context.Accounts, "Username", "Username", exportBill.StaffId);
            return View(exportBill);
        }

        // GET: Admin/AdminExportBills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ExportBills == null)
            {
                return NotFound();
            }

            var exportBill = await _context.ExportBills.FindAsync(id);
            if (exportBill == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", exportBill.CustomerId);
            ViewData["StaffId"] = new SelectList(_context.Accounts, "Username", "Username", exportBill.StaffId);
            return View(exportBill);
        }

        // POST: Admin/AdminExportBills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ExportDate,StaffId,CustomerId,TotalPrice,Note")] ExportBill exportBill)
        {
            if (id != exportBill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exportBill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExportBillExists(exportBill.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", exportBill.CustomerId);
            ViewData["StaffId"] = new SelectList(_context.Accounts, "Username", "Username", exportBill.StaffId);
            return View(exportBill);
        }

        // GET: Admin/AdminExportBills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ExportBills == null)
            {
                return NotFound();
            }

            var exportBill = await _context.ExportBills
                .Include(e => e.Customer)
                .Include(e => e.Staff)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exportBill == null)
            {
                return NotFound();
            }

            return View(exportBill);
        }

        // POST: Admin/AdminExportBills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ExportBills == null)
            {
                return Problem("Entity set 'FruitShopContext.ExportBills'  is null.");
            }
            var exportBill = await _context.ExportBills.FindAsync(id);
            if (exportBill != null)
            {
                _context.ExportBills.Remove(exportBill);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExportBillExists(int id)
        {
          return (_context.ExportBills?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

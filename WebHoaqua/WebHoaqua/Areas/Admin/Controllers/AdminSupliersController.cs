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
    public class AdminSupliersController : Controller
    {
        private readonly FruitShopContext _context;

        public AdminSupliersController(FruitShopContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminSupliers
        public async Task<IActionResult> Index(int page = 1, string? name = null)
        {
            page = page < 1 ? 1 : page;
            var pageSize = 5;

            var data = _context.Supliers.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                data = data.Where(x => x.SuplierName.Contains(name) || x.Phone.Contains(name) || x.Address.Contains(name));
              return _context.Supliers != null ? 
                          View(data.ToPagedListAsync(page, pageSize)) :
                          Problem("Entity set 'FruitShopContext.Supliers'  is null.");
        }

        // GET: Admin/AdminSupliers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Supliers == null)
            {
                return NotFound();
            }

            var suplier = await _context.Supliers
                .FirstOrDefaultAsync(m => m.SuplierId == id);
            if (suplier == null)
            {
                return NotFound();
            }

            return View(suplier);
        }

        // GET: Admin/AdminSupliers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminSupliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SuplierId,SuplierName,Address,Phone")] Suplier suplier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(suplier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(suplier);
        }

        // GET: Admin/AdminSupliers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Supliers == null)
            {
                return NotFound();
            }

            var suplier = await _context.Supliers.FindAsync(id);
            if (suplier == null)
            {
                return NotFound();
            }
            return View(suplier);
        }

        // POST: Admin/AdminSupliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SuplierId,SuplierName,Address,Phone")] Suplier suplier)
        {
            if (id != suplier.SuplierId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suplier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuplierExists(suplier.SuplierId))
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
            return View(suplier);
        }

        // GET: Admin/AdminSupliers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Supliers == null)
            {
                return NotFound();
            }

            var suplier = await _context.Supliers
                .FirstOrDefaultAsync(m => m.SuplierId == id);
            if (suplier == null)
            {
                return NotFound();
            }

            return View(suplier);
        }

        // POST: Admin/AdminSupliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Supliers == null)
            {
                return Problem("Entity set 'FruitShopContext.Supliers'  is null.");
            }
            var suplier = await _context.Supliers.FindAsync(id);
            if (suplier != null)
            {
                _context.Supliers.Remove(suplier);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuplierExists(int id)
        {
          return (_context.Supliers?.Any(e => e.SuplierId == id)).GetValueOrDefault();
        }
    }
}

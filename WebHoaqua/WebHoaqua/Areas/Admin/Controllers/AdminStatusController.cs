using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebHoaqua.Models;
using X.PagedList;

namespace WebHoaqua.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminStatusController : Controller
    {
        private readonly FruitShopContext _context;

        public AdminStatusController(FruitShopContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminStatus
        public async Task<IActionResult> Index(int page = 1, string name = "")
        {
            page = page < 1 ? 1 : page;
            var pageSize = 5;

            var data = await _context.Statuses.ToPagedListAsync(page, pageSize);

            if (!string.IsNullOrEmpty(name))
                data = await data.Where(x => x.StatusName.Contains(name)).ToPagedListAsync(page, pageSize);


              return _context.Statuses != null ? 
                          View(data) :
                          Problem("Entity set 'FruitShopContext.Statuses'  is null.");
        }

        // GET: Admin/AdminStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Statuses == null)
            {
                return NotFound();
            }

            var status = await _context.Statuses
                .FirstOrDefaultAsync(m => m.StatusId == id);
            if (status == null)
            {
                return NotFound();
            }

            return View(status);
        }

        // GET: Admin/AdminStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StatusId,StatusName")] Status status)
        {
            if (ModelState.IsValid)
            {
                _context.Add(status);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(status);
        }

        // GET: Admin/AdminStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Statuses == null)
            {
                return NotFound();
            }

            var status = await _context.Statuses.FindAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            return View(status);
        }

        // POST: Admin/AdminStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StatusId,StatusName")] Status status)
        {
            if (id != status.StatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(status);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusExists(status.StatusId))
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
            return View(status);
        }

        // GET: Admin/AdminStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Statuses == null)
            {
                return NotFound();
            }

            var status = await _context.Statuses
                .FirstOrDefaultAsync(m => m.StatusId == id);
            if (status == null)
            {
                return NotFound();
            }

            return View(status);
        }

        // POST: Admin/AdminStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Statuses == null)
            {
                return Problem("Entity set 'FruitShopContext.Statuses'  is null.");
            }
            var status = await _context.Statuses.FindAsync(id);
            if (status != null)
            {
                _context.Statuses.Remove(status);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusExists(int id)
        {
          return (_context.Statuses?.Any(e => e.StatusId == id)).GetValueOrDefault();
        }
    }
}

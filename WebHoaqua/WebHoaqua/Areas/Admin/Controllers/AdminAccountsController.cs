using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebHoaqua.Models;
using X.PagedList;

namespace WebHoaqua.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminAccountsController : Controller
    {
        private readonly FruitShopContext _context;

        public AdminAccountsController(FruitShopContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminAccounts
        public async Task<IActionResult> Index(int page = 1, string? name = "")
        {
            page = page < 1 ? 1 : page;
            var pageSize = 5;

            var data = await _context.Accounts.ToPagedListAsync(page, pageSize);
            if(!string.IsNullOrEmpty(name))
                data = await data.Where(x => x.Username.Contains(name)).ToPagedListAsync(page, pageSize);

            return View(data);
              //return _context.Accounts != null ? 
              //            View(await _context.Accounts.ToPagedListAsync(page, pageSize)) :
              //            Problem("Entity set 'FruitShopContext.Accounts'  is null.");
        }

        public static string CalculateMD5Hash(string input)
        {
            // Chuyển đổi chuỗi thành mảng byte
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            // Tạo đối tượng MD5
            using (MD5 md5 = MD5.Create())
            {
                // Mã hóa mảng byte thành mảng byte chứa mã băm MD5
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Chuyển đổi mảng byte thành chuỗi hexa
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2")); // "x2" để chuyển byte thành chuỗi hexa
                }

                return sb.ToString();
            }
        }

        // GET: Admin/AdminAccounts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .FirstOrDefaultAsync(m => m.Username == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Admin/AdminAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Username,Password,Type,Email")] Account account)
        {
            if (ModelState.IsValid)
            {
                account.Password = CalculateMD5Hash(account.Password);
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Admin/AdminAccounts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: Admin/AdminAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Username,Password,Type,Email")] Account account)
        {
            if (id != account.Username)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.Username))
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
            return View(account);
        }

        // GET: Admin/AdminAccounts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .FirstOrDefaultAsync(m => m.Username == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Admin/AdminAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Accounts == null)
            {
                return Problem("Entity set 'FruitShopContext.Accounts'  is null.");
            }
            var account = await _context.Accounts.FindAsync(id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(string id)
        {
          return (_context.Accounts?.Any(e => e.Username == id)).GetValueOrDefault();
        }
    }
}

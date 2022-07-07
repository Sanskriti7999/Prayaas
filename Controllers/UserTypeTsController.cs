using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prayaas_Website.Models;

namespace Prayaas_Website.Controllers
{
    public class UserTypeTsController : Controller
    {
        private readonly PrayaasDbContext _context;

        public UserTypeTsController(PrayaasDbContext context)
        {
            _context = context;
        }

        // GET: UserTypeTs
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserTypes.ToListAsync());
        }

        // GET: UserTypeTs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTypeT = await _context.UserTypes
                .FirstOrDefaultAsync(m => m.UserTypeID == id);
            if (userTypeT == null)
            {
                return NotFound();
            }

            return View(userTypeT);
        }

        // GET: UserTypeTs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserTypeTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserTypeID,UserType")] UserTypeT userTypeT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userTypeT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userTypeT);
        }

        // GET: UserTypeTs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTypeT = await _context.UserTypes.FindAsync(id);
            if (userTypeT == null)
            {
                return NotFound();
            }
            return View(userTypeT);
        }

        // POST: UserTypeTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserTypeID,UserType")] UserTypeT userTypeT)
        {
            if (id != userTypeT.UserTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userTypeT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserTypeTExists(userTypeT.UserTypeID))
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
            return View(userTypeT);
        }

        // GET: UserTypeTs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTypeT = await _context.UserTypes
                .FirstOrDefaultAsync(m => m.UserTypeID == id);
            if (userTypeT == null)
            {
                return NotFound();
            }

            return View(userTypeT);
        }

        // POST: UserTypeTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userTypeT = await _context.UserTypes.FindAsync(id);
            _context.UserTypes.Remove(userTypeT);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserTypeTExists(int id)
        {
            return _context.UserTypes.Any(e => e.UserTypeID == id);
        }
    }
}

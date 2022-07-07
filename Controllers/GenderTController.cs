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
    public class GenderTController : Controller
    {
        private readonly PrayaasDbContext _context;

        public GenderTController(PrayaasDbContext context)
        {
            _context = context;
        }

        // GET: GenderT
        public async Task<IActionResult> Index()
        {
            return View(await _context.Genders.ToListAsync());
        }

        // GET: GenderT/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genderT = await _context.Genders
                .FirstOrDefaultAsync(m => m.GenderID == id);
            if (genderT == null)
            {
                return NotFound();
            }

            return View(genderT);
        }

        // GET: GenderT/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GenderT/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GenderID,Gender")] GenderT genderT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genderT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(genderT);
        }

        // GET: GenderT/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genderT = await _context.Genders.FindAsync(id);
            if (genderT == null)
            {
                return NotFound();
            }
            return View(genderT);
        }

        // POST: GenderT/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GenderID,Gender")] GenderT genderT)
        {
            if (id != genderT.GenderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genderT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenderTExists(genderT.GenderID))
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
            return View(genderT);
        }

        // GET: GenderT/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genderT = await _context.Genders
                .FirstOrDefaultAsync(m => m.GenderID == id);
            if (genderT == null)
            {
                return NotFound();
            }

            return View(genderT);
        }

        // POST: GenderT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genderT = await _context.Genders.FindAsync(id);
            _context.Genders.Remove(genderT);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenderTExists(int id)
        {
            return _context.Genders.Any(e => e.GenderID == id);
        }
    }
}

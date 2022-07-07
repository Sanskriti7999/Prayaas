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
    public class CityController : Controller
    {
        private readonly PrayaasDbContext _context;

        public CityController(PrayaasDbContext context)
        {
            _context = context;
        }

        // GET: City
        public async Task<IActionResult> Index()
        {
            return View(await _context.Citys.ToListAsync());
        }

        // GET: City/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cityT = await _context.Citys
                .FirstOrDefaultAsync(m => m.CityID == id);
            if (cityT == null)
            {
                return NotFound();
            }

            return View(cityT);
        }

        // GET: City/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: City/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CityID,City")] CityT cityT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cityT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cityT);
        }

        // GET: City/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cityT = await _context.Citys.FindAsync(id);
            if (cityT == null)
            {
                return NotFound();
            }
            return View(cityT);
        }

        // POST: City/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CityID,City")] CityT cityT)
        {
            if (id != cityT.CityID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cityT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityTExists(cityT.CityID))
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
            return View(cityT);
        }

        // GET: City/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cityT = await _context.Citys
                .FirstOrDefaultAsync(m => m.CityID == id);
            if (cityT == null)
            {
                return NotFound();
            }

            return View(cityT);
        }

        // POST: City/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cityT = await _context.Citys.FindAsync(id);
            _context.Citys.Remove(cityT);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CityTExists(int id)
        {
            return _context.Citys.Any(e => e.CityID == id);
        }
    }
}

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
    public class RequestTypeController : Controller
    {
        private readonly PrayaasDbContext _context;

        public RequestTypeController(PrayaasDbContext context)
        {
            _context = context;
        }

        // GET: RequestType
        public async Task<IActionResult> Index()
        {
            return View(await _context.RequestTypes.ToListAsync());
        }

        // GET: RequestType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestTypeT = await _context.RequestTypes
                .FirstOrDefaultAsync(m => m.RequestTypeID == id);
            if (requestTypeT == null)
            {
                return NotFound();
            }

            return View(requestTypeT);
        }

        // GET: RequestType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RequestType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestTypeID,RequestType")] RequestTypeT requestTypeT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requestTypeT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(requestTypeT);
        }

        // GET: RequestType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestTypeT = await _context.RequestTypes.FindAsync(id);
            if (requestTypeT == null)
            {
                return NotFound();
            }
            return View(requestTypeT);
        }

        // POST: RequestType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestTypeID,RequestType")] RequestTypeT requestTypeT)
        {
            if (id != requestTypeT.RequestTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requestTypeT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestTypeTExists(requestTypeT.RequestTypeID))
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
            return View(requestTypeT);
        }

        // GET: RequestType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestTypeT = await _context.RequestTypes
                .FirstOrDefaultAsync(m => m.RequestTypeID == id);
            if (requestTypeT == null)
            {
                return NotFound();
            }

            return View(requestTypeT);
        }

        // POST: RequestType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requestTypeT = await _context.RequestTypes.FindAsync(id);
            _context.RequestTypes.Remove(requestTypeT);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestTypeTExists(int id)
        {
            return _context.RequestTypes.Any(e => e.RequestTypeID == id);
        }
    }
}

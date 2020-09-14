using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NETCore_MVC_Water_Company.Web.Data;
using NETCore_MVC_Water_Company.Web.Data.Entities;

namespace NETCore_MVC_Water_Company.Web.Controllers
{
    public class WaterMetersController : Controller
    {
        private readonly DataContext _context;

        public WaterMetersController(DataContext context)
        {
            _context = context;
        }

        // GET: WaterMeters
        public async Task<IActionResult> Index()
        {
            return View(await _context.WaterMeters.ToListAsync());
        }

        // GET: WaterMeters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterMeter = await _context.WaterMeters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (waterMeter == null)
            {
                return NotFound();
            }

            return View(waterMeter);
        }

        // GET: WaterMeters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WaterMeters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Address,TotalConsumption,MeterState,ZipCode")] WaterMeter waterMeter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(waterMeter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(waterMeter);
        }

        // GET: WaterMeters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterMeter = await _context.WaterMeters.FindAsync(id);
            if (waterMeter == null)
            {
                return NotFound();
            }
            return View(waterMeter);
        }

        // POST: WaterMeters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Address,TotalConsumption,MeterState,ZipCode")] WaterMeter waterMeter)
        {
            if (id != waterMeter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(waterMeter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WaterMeterExists(waterMeter.Id))
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
            return View(waterMeter);
        }

        // GET: WaterMeters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterMeter = await _context.WaterMeters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (waterMeter == null)
            {
                return NotFound();
            }

            return View(waterMeter);
        }

        // POST: WaterMeters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var waterMeter = await _context.WaterMeters.FindAsync(id);
            _context.WaterMeters.Remove(waterMeter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WaterMeterExists(int id)
        {
            return _context.WaterMeters.Any(e => e.Id == id);
        }
    }
}

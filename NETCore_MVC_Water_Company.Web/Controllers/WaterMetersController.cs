using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NETCore_MVC_Water_Company.Web.Data;
using NETCore_MVC_Water_Company.Web.Data.Entities;
using NETCore_MVC_Water_Company.Web.Data.Repositories.Interfaces;
using NETCore_MVC_Water_Company.Web.Models;

namespace NETCore_MVC_Water_Company.Web.Controllers
{
    [Authorize]
    public class WaterMetersController : Controller
    {
        readonly DataContext _context;
        readonly IWaterMeterRepository _waterMeterRepository;
        readonly IBillRepository _billRepository;

        public WaterMetersController(
            DataContext context,
            IWaterMeterRepository waterMeterRepository,
            IBillRepository billRepository)
        {
            _context = context;
            _waterMeterRepository = waterMeterRepository;
            _billRepository = billRepository;
        }

        // GET: WaterMeters
        public IActionResult Index()
        {
            return View(_waterMeterRepository.GetWaterMetersWithBills());
        }

        // GET: WaterMeters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterMeter = await _waterMeterRepository
                .GetWaterMeterWithBillsAsync(id.Value);

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
                .FirstOrDefaultAsync(w => w.Id == id);
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
            //var waterMeter = await _context.WaterMeters.FindAsync(id);
            //await _waterMeterRepository.DeleteWaterMeterWithBills(waterMeter);
            //await _context.WaterMeters.Remove();
            var waterMeter = await _context.WaterMeters.FindAsync(id);
            _context.WaterMeters.Remove(waterMeter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WaterMeterExists(int id)
        {
            return _context.WaterMeters.Any(e => e.Id == id);
        }


        public async Task<IActionResult> CreateBill(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterMeter = await _waterMeterRepository.GetByIdAsync(id.Value);

            if (waterMeter == null)
            {
                return NotFound();
            }

            var model = new BillViewModel { WaterMeterId = waterMeter.Id };

            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreateBill(BillViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _billRepository.InsertBillAsync(model);

                return RedirectToAction($"Details/{model.WaterMeterId}");
            }

            //TODO: don't know if returning the bill in the view will work
            return View(model);
        }

        public async Task<IActionResult> DeleteBill(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.Bills
                .FirstOrDefaultAsync(b => b.Id == id);

            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        [HttpPost, ActionName("DeleteBill")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBillConfirmed(int id)
        {
            var bill = await _context.Bills.FindAsync(id);
            _context.Bills.Remove(bill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditBill(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.Bills.FindAsync(id);

            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBill(Bill bill)
        {
            if (ModelState.IsValid)
            {
                var waterMeterId = await _billRepository.UpdateBillAsync(bill);

                if(waterMeterId != 0)
                {
                    return RedirectToAction($"Details/{waterMeterId}");
                }
            }

            return View(bill);
        }

        private bool BillExists(int id)
        {
            return _context.Bills.Any(e => e.Id == id);
        }
    }
}

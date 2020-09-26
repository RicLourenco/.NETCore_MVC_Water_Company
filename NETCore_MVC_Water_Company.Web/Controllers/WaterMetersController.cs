﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NETCore_MVC_Water_Company.Web.Data;
using NETCore_MVC_Water_Company.Web.Data.Entities;
using NETCore_MVC_Water_Company.Web.Data.Repositories.Interfaces;
using NETCore_MVC_Water_Company.Web.Helpers.Interfaces;
using NETCore_MVC_Water_Company.Web.Models;
using Syncfusion.EJ2.TreeMap;

namespace NETCore_MVC_Water_Company.Web.Controllers
{
    [Authorize]
    public class WaterMetersController : Controller
    {
        readonly DataContext _context;
        readonly IWaterMeterRepository _waterMeterRepository;
        readonly IBillRepository _billRepository;
        readonly IStepRepository _stepRepository;
        readonly IUserHelper _userHelper;
        readonly ICityRepository _cityRepository;

        public WaterMetersController(
            DataContext context,
            IWaterMeterRepository waterMeterRepository,
            IBillRepository billRepository,
            IStepRepository stepRepository,
            ICityRepository cityRepository,
            IUserHelper userHelper)
        {
            _context = context;
            _waterMeterRepository = waterMeterRepository;
            _billRepository = billRepository;
            _stepRepository = stepRepository;
            _userHelper = userHelper;
            _cityRepository = cityRepository;
        }

        // GET: WaterMeters
        public async Task<IActionResult> Index()
        {
            var model = await _waterMeterRepository.GetWaterMetersAsync(User.Identity.Name);
            return View(model);
        }

        // GET: WaterMeters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterMeter = await _waterMeterRepository
                .GetWaterMeterWithBillsAsync(id.Value, User.Identity.Name);

            if (waterMeter == null)
            {
                return NotFound();
            }

            List<ChartData> chartData = new List<ChartData>();

            List<Bill> list = waterMeter.Bills.OrderByDescending(b => b.MonthYear).Take(12).ToList();

            for (int i = 0; i < list.Count; i++)
            {
                chartData.Add(new ChartData { xValue = list[i].MonthYear.ToString("MM-yyyy"), yValue = Convert.ToDouble(list[i].Consumption) });
            }

            waterMeter.ChartData = chartData;

            return View(waterMeter);
        }

        [Authorize(Roles = "Admin,Employee")]
        // GET: WaterMeters/Create
        public IActionResult Create(string id)
        {
            if(string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            WaterMeterViewModel model = new WaterMeterViewModel
            {
                Cities = _cityRepository.GetComboCities(),
                UserId = id
            };

            return View(model);
        }

        // POST: WaterMeters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,Employee")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WaterMeterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userHelper.GetUserByIdAsync(model.UserId);

                var city = await _cityRepository.GetByIdAsync(model.CityId);

                var waterMeter = new WaterMeter
                {
                    Address = model.Address,
                    CityId = model.CityId,
                    MeterState = model.MeterState,
                    TotalConsumption = 0,
                    ZipCode = model.ZipCode,
                    CreationDate = DateTime.UtcNow,
                    User = user
                };

                await _waterMeterRepository.CreateAsync(waterMeter);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }



        // GET: WaterMeters/Edit/5
        [Authorize(Roles = "Admin,Employee")]
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

            var model = new WaterMeterViewModel
            {
                MeterId = waterMeter.Id,
                Address = waterMeter.Address,
                TotalConsumption = waterMeter.TotalConsumption,
                MeterState = waterMeter.MeterState,
                CityId = waterMeter.CityId,
                ZipCode = waterMeter.ZipCode,
                Cities = _cityRepository.GetComboCities(),
                CreationDate = waterMeter.CreationDate
            };

            return View(model);
        }

        // POST: WaterMeters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,Employee")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WaterMeterViewModel model)
        {
            if (id != model.MeterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var waterMeter = new WaterMeter
                    {
                        Id = model.MeterId,
                        Address = model.Address,
                        TotalConsumption = model.TotalConsumption,
                        MeterState = model.MeterState,
                        CityId = model.CityId,
                        ZipCode = model.ZipCode,
                        CreationDate = model.CreationDate
                    };

                    _context.Update(waterMeter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WaterMeterExists(model.MeterId))
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
            return View(model);
        }

        // GET: WaterMeters/Delete/5
        [Authorize(Roles = "Admin,Employee")]
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
        [Authorize(Roles = "Admin,Employee")]
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


        [Authorize(Roles = "Admin,Employee")]
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

        [Authorize(Roles = "Admin,Employee")]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreateBill(BillViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.FinalValue = _stepRepository.CalculateFinalPrice(model.Consumption);
                await _billRepository.InsertBillAsync(model);

                return RedirectToAction($"Details/{model.WaterMeterId}");
            }

            return View(model);
        }

        [Authorize(Roles = "Admin,Employee")]
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

        [Authorize(Roles = "Admin,Employee")]
        [HttpPost, ActionName("DeleteBill")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBillConfirmed(int id)
        {
            //var bill = await _context.Bills.FindAsync(id);
            //_context.Bills.Remove(bill);
            //await _context.SaveChangesAsync();

            await _billRepository.DeleteBillAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin,Employee")]
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

        [Authorize(Roles = "Admin,Employee")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBill(Bill bill)
        {
            if (ModelState.IsValid)
            {
                bill.FinalValue = _stepRepository.CalculateFinalPrice(bill.Consumption);

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

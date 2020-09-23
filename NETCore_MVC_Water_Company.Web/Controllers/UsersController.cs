using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NETCore_MVC_Water_Company.Web.Data;
using NETCore_MVC_Water_Company.Web.Data.Entities;
using NETCore_MVC_Water_Company.Web.Helpers.Interfaces;

namespace NETCore_MVC_Water_Company.Web.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    public class UsersController : Controller
    {
        readonly DataContext _context;
        readonly IUserHelper _userHelper;

        public UsersController(
            DataContext context,
            IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        // GET: Cities
        public IActionResult Index()
        {
            return View(_context.Users.ToList());
        }

        //TODO: user userhelper if there's time
        // GET: Cities/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.Include(u => u.WaterMeters).FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        //// GET: Cities/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var city = await _context.Cities.FindAsync(id);

        //    if (city == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(city);
        //}

        //// POST: Cities/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] City city)
        //{
        //    if (id != city.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(city);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CityExists(city.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(city);
        //}

        //// GET: Cities/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var city = await _context.Cities
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (city == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(city);
        //}

        //// POST: Cities/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var city = await _context.Cities.FindAsync(id);
        //    _context.Cities.Remove(city);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
    }
}

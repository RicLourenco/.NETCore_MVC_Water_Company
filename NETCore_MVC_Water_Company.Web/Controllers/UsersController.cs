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
using NETCore_MVC_Water_Company.Web.Data.Repositories.Interfaces;
using NETCore_MVC_Water_Company.Web.Helpers.Classes;
using NETCore_MVC_Water_Company.Web.Helpers.Interfaces;
using NETCore_MVC_Water_Company.Web.Models;

namespace NETCore_MVC_Water_Company.Web.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    public class UsersController : Controller
    {
        readonly DataContext _context;
        readonly IUserHelper _userHelper;
        readonly IDocumentRepository _documentRepository;

        public UsersController(
            DataContext context,
            IUserHelper userHelper,
            IDocumentRepository documentRepository)
        {
            _context = context;
            _userHelper = userHelper;
            _documentRepository = documentRepository;
        }


        // GET: Cities
        public IActionResult Index()
        {
            return View(_context.Users.ToList());
        }


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

        [Authorize(Roles = "Admin")]
        // GET: Cities/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userHelper.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var model = new ChangeUserRoleViewModel
            {
                UserId = user.Id,
                Roles = _userHelper.GetComboRoles(),
                IBAN = user.IBAN
            };

            return View(model);
        }


        [Authorize(Roles = "Admin")]
        //// POST: Cities/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ChangeUserRoleViewModel model)
        {

            if (model == null )
            {
                return NotFound();
            }

            var user = await _userHelper.GetUserByIdAsync(model.UserId);

            user.IBAN = model.IBAN;

            if (ModelState.IsValid)
            {
                await _userHelper.UpdateUserAsync(user);

                await _userHelper.ChangeUserRoleAsync(user, model.RoleName);

                //if (!await _userHelper.IsUserInRoleAsync(user, model.RoleName))
                //{
                //    await _userHelper.AddUserToRoleAsync(user, model.RoleName);
                //}

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        // GET: Cities/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
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

        [Authorize(Roles = "Admin")]
        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

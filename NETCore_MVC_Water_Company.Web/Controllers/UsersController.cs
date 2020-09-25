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

        [Authorize(Roles = "Admin,Employee")]
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

            var model = new ChangeUserViewModel
            {
                Id = user.Id,
                FirstNames = user.FirstNames,
                LastNames = user.LastNames,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                DocumentId = user.DocumentId,
                DocumentNumber = user.DocumentNumber,
                Documents = _documentRepository.GetComboDocuments(),
                TIN = user.TIN,
                IBAN = user.IBAN
            };

            return View(model);
        }

        //TODO: fix stamp error when updating
        [Authorize(Roles = "Admin,Employee")]
        //// POST: Cities/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, ChangeUserViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = new User
                    {
                        FirstNames = model.FirstNames,
                        LastNames = model.LastNames,
                        Address = model.Address,
                        PhoneNumber = model.PhoneNumber,
                        DocumentId = model.DocumentId,
                        DocumentNumber = model.DocumentNumber,
                        TIN = model.TIN,
                        IBAN = model.IBAN
                    };

                    await _userHelper.UpdateUserAsync(user);

                    //_context.Update(user);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    var userExists = await _userHelper.GetUserByIdAsync(model.Id);

                    if (model == null)
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

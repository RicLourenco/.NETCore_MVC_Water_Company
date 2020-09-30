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
using NETCore_MVC_Water_Company.Web.Data.Repositories.Classes;
using NETCore_MVC_Water_Company.Web.Data.Repositories.Interfaces;

namespace NETCore_MVC_Water_Company.Web.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    public class StepsController : Controller
    {
        readonly DataContext _context;
        readonly IStepRepository _stepRepository;

        public StepsController(
            DataContext context,
            IStepRepository stepRepository)
        {
            _context = context;
            _stepRepository = stepRepository;
        }

        /// <summary>
        /// Steps index get action
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(_stepRepository.GetStepsOrdered());
        }

        /// <summary>
        /// Steps details get action
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var step = await _context.Steps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (step == null)
            {
                return NotFound();
            }

            return View(step);
        }

        /// <summary>
        /// Steps details get action
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Employee")]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Steps create post action
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Create([Bind("Id,MinimumConsumption,Price")] Step step)
        {
            if (ModelState.IsValid)
            {
                await _stepRepository.InsertStepAsync(step);
                return RedirectToAction(nameof(Index));
            }
            return View(step);
        }

        /// <summary>
        /// Steps edit get action
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var step = await _context.Steps.FindAsync(id);
            if (step == null)
            {
                return NotFound();
            }
            return View(step);
        }

        /// <summary>
        /// Steps edit post action
        /// </summary>
        /// <param name="id"></param>
        /// <param name="step"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MinimumConsumption,Price")] Step step)
        {
            if (id != step.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _stepRepository.UpdateStepAsync(step);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StepExists(step.Id))
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
            return View(step);
        }

        /// <summary>
        /// Steps delete get action
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var step = await _context.Steps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (step == null)
            {
                return NotFound();
            }

            return View(step);
        }

        /// <summary>
        /// Steps delete post action
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var step = await _context.Steps.FindAsync(id);
            await _stepRepository.DeleteStepAsync(step);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StepExists(int id)
        {
            return _context.Steps.Any(e => e.Id == id);
        }
    }
}

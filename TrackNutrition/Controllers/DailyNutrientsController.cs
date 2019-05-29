using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using TrackNutrition.Services;
using TrackNutrition.Models;

namespace TrackNutrition.Controllers 
{
    // Details the macro and micro nutrients needed for each day and keeps track
    // of the quantity taken and the energy values
    [Authorize]
    public class DailyNutrientsController : Controller
    {
        private readonly IDailyNutrientItemService _dailyNutrientItemService;
        private readonly UserManager<ApplicationUser> _userManager;

        public DailyNutrientsController(IDailyNutrientItemService dailyNutrientItemService,
            UserManager<ApplicationUser> userManager)
        {
            _dailyNutrientItemService = dailyNutrientItemService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();

            var nutrients = await _dailyNutrientItemService.GetAllDailyNutrientsAsync(currentUser);

            var model = new DailyNutrientViewModel()
            {
                DailyNutrients = nutrients
            };

            return View(model);
        }

        
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNutrients(DailyNutrientItem newEntry)
        {
            if(!ModelState.IsValid) 
            {
                return RedirectToAction("Index");
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();

            var successful = await _dailyNutrientItemService.AddNutrientAsync(newEntry, currentUser);
            if (!successful) 
            {
                return BadRequest("Could not add nutrients");
            }
            return RedirectToAction("Index");
        }


        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEntry(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();

            var successful = await _dailyNutrientItemService.DeleteEntryAsync(id, currentUser);
            if (!successful)
            {
                return BadRequest("Could not delete entry");
            }

            return RedirectToAction("Index");
        }
    }
}

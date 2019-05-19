using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrackNutrition.Services;
using TrackNutrition.Models;

namespace TrackNutrition.Controllers 
{
    // Details the macro and micro nutrients needed for each day and keeps track
    // of the quantity taken and the energy values
    public class DailyNutrientsController : Controller
    {
        private readonly IDailyNutrientItemService _dailyNutrientItemService;

        public DailyNutrientsController(IDailyNutrientItemService dailyNutrientItemService)
        {
            _dailyNutrientItemService = dailyNutrientItemService;
        }
        public async Task<IActionResult> Index()
        {
            var nutrients = await _dailyNutrientItemService.GetAllDailyNutrientsAsync();

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
            var successful = await _dailyNutrientItemService.AddNutrientAsync(newEntry);
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
            var successful = await _dailyNutrientItemService.DeleteEntryAsync(id);
            if (!successful)
            {
                return BadRequest("Could not delete entry");
            }

            return RedirectToAction("Index");
        }
    }
}
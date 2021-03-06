using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackNutrition.Data;
using TrackNutrition.Models;
using Microsoft.EntityFrameworkCore;

namespace TrackNutrition.Services 
{
    public class DailyNutrientItemService: IDailyNutrientItemService
    {
        private readonly ApplicationDbContext _context;

        public DailyNutrientItemService(ApplicationDbContext context) => _context = context;

        public async Task<DailyNutrientItem[]> GetAllDailyNutrientsAsync(ApplicationUser user)
        {
            return await _context.Nutrients
                .Where(x => x.UserId == user.Id) 
                .ToArrayAsync();
        }

        public async Task<bool> AddNutrientAsync(
            DailyNutrientItem newEntry, ApplicationUser user)
        {
            newEntry.Id = Guid.NewGuid();
            newEntry.CreateDate = DateTime.Now.AddMinutes(-60);
            newEntry.UserId = user.Id;

            _context.Nutrients.Add(newEntry);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }


        public async Task<bool> DeleteEntryAsync(
            Guid id, ApplicationUser user)
        {
            var nutrientsEntry = await _context.Nutrients
                .Where(x => x.Id == id && x.UserId == user.Id)
                .SingleOrDefaultAsync();
            if (nutrientsEntry == null) return false;
            _context.Nutrients.Remove(nutrientsEntry);
            var saveResult = await _context.SaveChangesAsync();
            
            return saveResult == 1;
        }
    }
}
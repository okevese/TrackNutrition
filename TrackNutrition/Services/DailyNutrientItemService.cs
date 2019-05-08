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

        public async Task<DailyNutrientItem[]> GetAllDailyNutrientsAsync()
        {
            return await _context.Nutrients
                .ToArrayAsync();
        }
    }
}
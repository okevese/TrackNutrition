using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackNutrition.Models;

namespace TrackNutrition.Services
{
    public interface IDailyNutrientItemService
    {
        Task<DailyNutrientItem[]> GetAllDailyNutrientsAsync(ApplicationUser user);
        Task<bool> AddNutrientAsync(DailyNutrientItem newEntry);
        Task<bool> DeleteEntryAsync(Guid id);
    }
}
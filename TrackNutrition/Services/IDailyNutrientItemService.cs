using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackNutrition.Models;

namespace TrackNutrition.Services
{
    public interface IDailyNutrientItemService
    {
        Task<DailyNutrientItem[]> GetAllDailyNutrientsAsync(ApplicationUser user);
        Task<bool> AddNutrientAsync(DailyNutrientItem newEntry, ApplicationUser user);
        Task<bool> DeleteEntryAsync(Guid id, ApplicationUser user);
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackNutrition.Models;

namespace TrackNutrition.Services
{
    public class FakeDailyNutrientItemService : IDailyNutrientItemService
    {
        public Task<DailyNutrientItem[]> GetAllDailyNutrientsAsync()
        {
            var nutrient1 = new DailyNutrientItem
            {
                Proteins = "Black beans",
                ProteinQuantity = 6,
                Fruits = "Apples",
                FruitQuantity = 1,
                Oils = "Sesame oil",
                OilQuantity = 6,
                Dairy = "Soymilk",
                DairyQuantity = 3,
                Grains = "Pasta",
                GrainQuantity = 4,
                Vegetables = "Lettuce",
                VegetableQuantity = 3,
                Calories = 2200,
                Comment = "Broccoli soup for the weekend dinner",
                CreateDate = new DateTime(2019, 5, 6)
            };

            var nutrient2 = new DailyNutrientItem
            {
                Proteins = "Sardines",
                ProteinQuantity = 6,
                Fruits = "Avocado",
                FruitQuantity = 1,
                Oils = "Cottonseed oil",
                OilQuantity = 6,
                Dairy = "Youghurt",
                DairyQuantity = 3,
                Grains = "Brown rice",
                GrainQuantity = 5,
                Vegetables = "Cabbage",
                VegetableQuantity = 2,
                Calories = 2100,
                Comment = "Reaserch on foods with sodium",
                CreateDate = DateTime.Today          
            };

            return Task.FromResult(new[] { nutrient1, nutrient2 });
        }
    }
}
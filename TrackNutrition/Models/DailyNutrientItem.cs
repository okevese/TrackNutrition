using System;
using System.ComponentModel.DataAnnotations;

namespace TrackNutrition.Models 
{
    public class DailyNutrientItem
    {
        public Guid Id { get; set; }
        public string Proteins { get; set; }
        public int ProteinQuantity { get; set; }
        public string Fruits { get; set; }
        public int FruitQuantity { get; set; }
        public string Oils { get; set; }
        public int OilQuantity { get; set; }
        public string Dairy { get; set; }
        public int DairyQuantity { get; set; }
        public string Grains { get; set; }
        public int GrainQuantity { get; set; }
        public string Vegetables { get; set; }
        public int VegetableQuantity { get; set; }
        public int Calories { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }
        public string Comment { get; set; }
        public string UserId { get; set; }
    }
}
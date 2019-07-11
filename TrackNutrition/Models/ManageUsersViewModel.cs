using System.Collections.Generic;
using TrackNutrition.Models;

namespace TrackNutrition.Models
{
    public class ManageUsersViewModel
    {
        public ApplicationUser[] Administrators { get; set; }
        public ApplicationUser[] Everyone { get; set; }
    }
}
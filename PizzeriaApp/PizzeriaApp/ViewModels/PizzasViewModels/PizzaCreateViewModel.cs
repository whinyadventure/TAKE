using Microsoft.AspNetCore.Mvc.Rendering;
using PizzeriaApp.ViewModels.IngredientsViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzeriaApp.ViewModels.PizzasViewModels
{
    public class PizzaCreateViewModel
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Crust Type")]
        public string DoughType { get; set; }
        [Required]
        [Display(Name = "Price small")]
        public float SmallPrice { get; set; }
        [Required]
        [Display(Name = "Price medium")]
        public float MediumPrice { get; set; }
        [Required]
        [Display(Name = "Price large")]
        public float LargePrice { get; set; }
        public List<SelectListItem> Ingredients { get; set; }
        [Display(Name = "Ingredients")]
        public string[] SelectedIngredients { get; set; } = new string[] { };
    }
}

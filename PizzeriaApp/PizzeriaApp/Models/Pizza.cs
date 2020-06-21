using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzeriaApp.Models
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Crust type")]
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

        [Display(Name = "Ingredients")]
        public List<PizzaIngredient> PizzaIngredients { get; set; } = new List<PizzaIngredient>();
    }
}

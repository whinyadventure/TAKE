using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzeriaApp.Models
{
    public class PizzaIngredient
    {
        public int PizzaId { get; set; }
        public int IngredientId { get; set; }
        public Pizza Pizza { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}

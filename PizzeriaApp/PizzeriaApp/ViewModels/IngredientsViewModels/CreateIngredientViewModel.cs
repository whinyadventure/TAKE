using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzeriaApp.ViewModels.IngredientsViewModels
{
    public class CreateIngredientViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}

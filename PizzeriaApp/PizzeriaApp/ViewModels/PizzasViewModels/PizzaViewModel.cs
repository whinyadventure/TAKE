using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzeriaApp.ViewModels.PizzasViewModels
{
    public class PizzaViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DoughType { get; set; }
        public float SmallPrice { get; set; }
        public float MediumPrice { get; set; }
        public float LargePrice { get; set; }
    }
}

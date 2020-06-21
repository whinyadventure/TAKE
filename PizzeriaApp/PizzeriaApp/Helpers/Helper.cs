using AutoMapper;
using PizzeriaApp.Models;
using PizzeriaApp.ViewModels.IngredientsViewModels;
using PizzeriaApp.ViewModels.PizzasViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzeriaApp.Helpers
{
    public class Helper : Profile
    {
        public Helper()
        {
            CreateMap<Ingredient, IngredientViewModel>().ReverseMap();
            CreateMap<CreateIngredientViewModel, Ingredient>();
            CreateMap<Pizza, PizzaViewModel>().ReverseMap();
        }
    }
}

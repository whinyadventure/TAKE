using PizzeriaApp.Data;
using PizzeriaApp.Interfaces;
using PizzeriaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzeriaApp.Repositories
{
    public class UnitOfWorkRepo : IUnitOfWork
    {
        private readonly PizzeriaAppContext _context;
        private IPizza _pizzaRepo;
        private IIngredient _ingredientRepo;

        public UnitOfWorkRepo(PizzeriaAppContext context)
        {
            _context = context;
        }

        public IPizza Pizza
        {
            get
            {
                return _pizzaRepo = _pizzaRepo ?? new PizzaRepo(_context);
            }
        }

        public IIngredient Ingredient
        {
            get
            {
                return _ingredientRepo = _ingredientRepo ?? new IngredientRepo(_context);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

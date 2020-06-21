using PizzeriaApp.Data;
using PizzeriaApp.Interfaces;
using PizzeriaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzeriaApp.Repositories
{
    public class IngredientRepo : IIngredient
    {
        private readonly PizzeriaAppContext _context;

        public IngredientRepo(PizzeriaAppContext context)
        {
            _context = context;
        }

        public void Delete(Ingredient ingredient)
        {
            _context.Ingredients.Remove(ingredient);
        }

        public List<Ingredient> GetAll()
        {
            return _context.Ingredients.ToList();
        }

        public Ingredient GetById(int Id)
        {
            return _context.Ingredients.FirstOrDefault(x => x.Id == Id);
        }

        public void Insert(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
        }

        public void Update(Ingredient ingredient)
        {
            _context.Ingredients.Update(ingredient);
        }
    }
}

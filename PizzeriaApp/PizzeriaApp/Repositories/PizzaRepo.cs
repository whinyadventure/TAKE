using Microsoft.EntityFrameworkCore;
using PizzeriaApp.Data;
using PizzeriaApp.Interfaces;
using PizzeriaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzeriaApp.Repositories
{
    public class PizzaRepo : IPizza
    {
        private readonly PizzeriaAppContext _context;

        public PizzaRepo(PizzeriaAppContext context)
        {
            _context = context;
        }

        public void Delete(Pizza pizza)
        {
            _context.Pizzas.Remove(pizza);
        }

        public List<Pizza> GetAll()
        {
            return _context.Pizzas.ToList();
        }

        public Pizza GetById(int Id)
        {
            return _context.Pizzas.Include("PizzaIngredients.Ingredient").FirstOrDefault(x => x.Id == Id);
        }

        public void Insert(Pizza pizza)
        {
            _context.Pizzas.Add(pizza);
        }

        public void Update(Pizza pizza)
        {
            _context.Pizzas.Update(pizza);
        }
    }
}

using PizzeriaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzeriaApp.Interfaces
{
    public interface IIngredient
    {
        List<Ingredient> GetAll();
        Ingredient GetById(int Id);
        void Insert(Ingredient ingredient);
        void Update(Ingredient ingredient);
        void Delete(Ingredient ingredient);
    }
}

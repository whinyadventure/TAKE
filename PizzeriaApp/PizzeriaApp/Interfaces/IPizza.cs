using PizzeriaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzeriaApp.Interfaces
{
    public interface IPizza
    {
        List<Pizza> GetAll();
        Pizza GetById(int Id);
        void Insert(Pizza pizza);
        void Update(Pizza pizza);
        void Delete(Pizza pizza);
    }
}

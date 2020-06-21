using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzeriaApp.Interfaces
{
    public interface IUnitOfWork
    {
        IPizza Pizza { get; }
        IIngredient Ingredient { get; }
        void Save();
    }
}

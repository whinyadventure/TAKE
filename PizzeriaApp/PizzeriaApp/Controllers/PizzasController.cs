using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PizzeriaApp.Data;
using PizzeriaApp.Interfaces;
using PizzeriaApp.Models;
using PizzeriaApp.ViewModels.IngredientsViewModels;
using PizzeriaApp.ViewModels.PizzasViewModels;

namespace PizzeriaApp.Controllers
{
    public class PizzasController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private readonly PizzeriaAppContext _context;

        public PizzasController(IUnitOfWork unitOfWork, IMapper mapper, PizzeriaAppContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        /* // GET: PizzasController
         public ActionResult Index()
         {
             var model = _unitOfWork.Pizza.GetAll();
             var vm = _mapper.Map<List<PizzaViewModel>>(model);
             return View(vm);
         }*/

        public async Task<IActionResult> Index(string searchString)
        {
            var pizzas = from m in _context.Pizzas
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                pizzas = pizzas.Where(s => s.Name.Contains(searchString));
            }

            return View(await pizzas.ToListAsync());
        }

        // GET: PizzasController/Details/5
        public ActionResult Details(int id)
        {
            var model = _unitOfWork.Pizza.GetById(id);
            
            return View(model);
        }

        // GET: PizzasController/Create
        public ActionResult Create()
        {
            var ingredientsFromRepo = _unitOfWork.Ingredient.GetAll();
            var selectList = new List<SelectListItem>();
            
            foreach(var item in ingredientsFromRepo)
            {
                selectList.Add(new SelectListItem(item.Name, item.Id.ToString()));
            }

            var vm = new PizzaCreateViewModel()
            {
                Ingredients = selectList
            };

            return View(vm);
        }

        // POST: PizzasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PizzaCreateViewModel vm)
        {
            try
            {
                Pizza pizza = new Pizza()
                {
                    Name = vm.Name,
                    DoughType = vm.DoughType,
                    SmallPrice = vm.SmallPrice,
                    MediumPrice = vm.MediumPrice,
                    LargePrice = vm.LargePrice
                };


                foreach (var item in vm.SelectedIngredients)
                {
                    pizza.PizzaIngredients.Add(new PizzaIngredient()
                    {
                        Ingredient = _unitOfWork.Ingredient.GetById(Int32.Parse(item))
                    });
                }

                _unitOfWork.Pizza.Insert(pizza);
                _unitOfWork.Save();
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PizzasController/Edit/5
        public ActionResult Edit(int id)
        {
            var pizza = _unitOfWork.Pizza.GetById(id);
            var ingredients = _unitOfWork.Ingredient.GetAll();

            List<Ingredient> selectedIngredients = new List<Ingredient>();

            foreach(var item in pizza.PizzaIngredients)
            {
                selectedIngredients.Add(new Ingredient()
                {
                    Id = item.Ingredient.Id,
                    Name = item.Ingredient.Name
                });
            }

            var selectList = new List<SelectListItem>();

            foreach(var item in ingredients)
            {
                if (selectedIngredients.Select(x => x.Name).Contains(item.Name))
                {
                    selectList.Add(new SelectListItem(item.Name, item.Id.ToString(), true));
                }
                else
                {
                    selectList.Add(new SelectListItem(item.Name, item.Id.ToString(), false));
                }
            }

            var vm = new PizzaEditViewModel()
            {
                Id = pizza.Id,
                Name = pizza.Name,
                DoughType = pizza.DoughType,
                SmallPrice = pizza.SmallPrice,
                MediumPrice = pizza.MediumPrice,
                LargePrice = pizza.LargePrice,
                Ingredients = selectList
            };

            return View(vm);
        }

        // POST: PizzasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PizzaEditViewModel vm)
        {
            try
            {
                var pizza = _unitOfWork.Pizza.GetById(vm.Id);
                pizza.Name = vm.Name;
                pizza.DoughType = vm.DoughType;
                pizza.SmallPrice = vm.SmallPrice;
                pizza.MediumPrice = vm.MediumPrice;
                pizza.LargePrice = vm.LargePrice;

                var selectedIngredients = vm.SelectedIngredients;

                var existingIngredients = pizza.PizzaIngredients.Select(x => x.Ingredient.Id.ToString()).ToList();
                var toAdd = selectedIngredients.Except(existingIngredients).ToList();
                var toRemove = existingIngredients.Except(selectedIngredients).ToList();

                pizza.PizzaIngredients = pizza.PizzaIngredients.Where(x => !toRemove.Contains(x.Ingredient.Id.ToString())).ToList();

                foreach(var item in toAdd)
                {
                    pizza.PizzaIngredients.Add(new PizzaIngredient()
                    {
                        Ingredient = _unitOfWork.Ingredient.GetById(Int32.Parse(item))
                    });
                }

                _unitOfWork.Save();
                return RedirectToAction("Index", "Pizzas");
            }
            catch
            {
                return View();
            }
        }

        // GET: PizzasController/Delete/5
        public ActionResult Delete(int id)
        {
            var pizza = _unitOfWork.Pizza.GetById(id);
            var vm = _mapper.Map<PizzaViewModel>(pizza);

            return View(vm);
        }

        // POST: PizzasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PizzaViewModel vm)
        {
            try
            {
                var pizza = _mapper.Map<Pizza>(vm);
                _unitOfWork.Pizza.Delete(pizza);
                _unitOfWork.Save();

                return RedirectToAction("Index", "Pizzas");
            }
            catch
            {
                return View();
            }
        }
    }
}

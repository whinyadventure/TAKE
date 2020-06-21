using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzeriaApp.Data;
using PizzeriaApp.Interfaces;
using PizzeriaApp.Models;
using PizzeriaApp.ViewModels.IngredientsViewModels;

namespace PizzeriaApp.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public IngredientsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: IngredientsController
        public ActionResult Index()
        {
            var model = _unitOfWork.Ingredient.GetAll();
            var vm = _mapper.Map<List<IngredientViewModel>>(model);
            return View(vm);
        }


        // GET: IngredientsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IngredientsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateIngredientViewModel vm)
        {
            try
            {
                var model = _mapper.Map<Ingredient>(vm);
                _unitOfWork.Ingredient.Insert(model);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Ingredients");
            }
            catch
            {
                return View();
            }
        }

        // GET: IngredientsController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _unitOfWork.Ingredient.GetById(id);
            var vm = _mapper.Map<IngredientViewModel>(model);
            return View(vm);
        }

        // POST: IngredientsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IngredientViewModel vm)
        {
            try
            {
                var model = _mapper.Map<Ingredient>(vm);
                _unitOfWork.Ingredient.Update(model);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Ingredients");
            }
            catch
            {
                return View();
            }
        }

        // GET: IngredientsController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _unitOfWork.Ingredient.GetById(id);
            var vm = _mapper.Map<IngredientViewModel>(model);

            return View(vm);
        }

        // POST: IngredientsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(IngredientViewModel vm)
        {
            try
            {
                var model = _mapper.Map<Ingredient>(vm);

                _unitOfWork.Ingredient.Delete(model);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Ingredients");
            }
            catch
            {
                return View();
            }
        }
    }
}

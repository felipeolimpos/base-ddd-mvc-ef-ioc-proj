using AutoMapper;
using POS.Domain.Interfaces.Services;
using POS.Infra.Cross.DTO;
using POS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace POS.Web.Controllers
{
    public class CategoriesController : EntityBaseController<ICategoryService, CategoryDTO, CategoryViewModel>
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public CategoriesController(ICategoryService categoryService, IProductService productService) : base(categoryService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        // GET: product/1
        public ActionResult Index(int id)
        {
            var category = _categoryService.GetById(id);
            var mappedCategory = Mapper.Map<CategoryViewModel>(category);

            var products = _productService.GetActiveByCategory(id);
            var mappedProducts = Mapper.Map<List<ProductViewModel>>(products);
            mappedCategory.Products = mappedProducts;

            return View(mappedCategory);
        }


        // POST: entity/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override ActionResult Create(CategoryViewModel entity)
        {
            if (ModelState.IsValid)
            {
                var mappedEntity = Mapper.Map<CategoryDTO>(entity);
                mappedEntity.CreatedAt = DateTime.Now;
                _categoryService.Add(mappedEntity);

                UpdateCategoriesCache();
            }

            return RedirectToAction("List");
        }


        // POST: entity/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override ActionResult Edit(CategoryViewModel entity)
        {
            if (ModelState.IsValid)
            {
                var mappedEntity = Mapper.Map<CategoryDTO>(entity);
                mappedEntity.CreatedAt = DateTime.Now;
                _categoryService.Update(mappedEntity);
                UpdateCategoriesCache();
            }

            return RedirectToAction("List");
        }

        // POST: entity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public override ActionResult DeleteConfirmed(int id)
        {
            _categoryService.Remove(id);
            UpdateCategoriesCache();
            return RedirectToAction("List");
        }
    }
}

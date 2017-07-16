using AutoMapper;
using POS.Domain.Interfaces.Services;
using POS.Infra.Cross.DTO;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace POS.Web.Controllers
{
    public abstract class EntityBaseController<TService, TEntityDTO, TEntityViewModel> : BaseController
        where TService : IBaseService<TEntityDTO>
        where TEntityDTO : IEntityDTO
        where TEntityViewModel : class
    {
        private readonly TService _service;

        public EntityBaseController(TService service)
        {
            _service = service;
        }

        // GET: entity
        public ActionResult List()
        {
            var allEntities = _service.GetAll();
            var mappedEntities = Mapper.Map<IEnumerable<TEntityViewModel>>(allEntities);

            return View(mappedEntities);
        }

        // GET: entity/Details/5
        public ActionResult Details(int id)
        {
            var entity = _service.GetById(id);
            var mappedEntity = Mapper.Map<TEntityViewModel>(entity);

            return View(mappedEntity);
        }

        // GET: entity/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: entity/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(TEntityViewModel entity)
        {
            if (ModelState.IsValid)
            {
                var mappedEntity = Mapper.Map<TEntityDTO>(entity);
                mappedEntity.CreatedAt = DateTime.Now;
                _service.Add(mappedEntity);
            }

            return RedirectToAction("List");
        }

        // GET: entity/Edit/5
        public ActionResult Edit(int id)
        {
            var entity = _service.GetById(id);
            var mappedEntity = Mapper.Map<TEntityViewModel>(entity);

            return View(mappedEntity);
        }

        // POST: entity/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(TEntityViewModel entity)
        {
            if (ModelState.IsValid)
            {
                var mappedEntity = Mapper.Map<TEntityDTO>(entity);
                mappedEntity.CreatedAt = DateTime.Now;
                _service.Update(mappedEntity);
            }

            return RedirectToAction("List");
        }

        // GET: entity/Delete/5
        public ActionResult Delete(int id)
        {
            var entity = _service.GetById(id);
            var mappedEntity = Mapper.Map<TEntityViewModel>(entity);

            return View(mappedEntity);
        }

        // POST: entity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(int id)
        {
            _service.Remove(id);
            return RedirectToAction("List");
        }
    }
}

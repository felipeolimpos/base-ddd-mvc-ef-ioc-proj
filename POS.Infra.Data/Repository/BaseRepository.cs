using AutoMapper;
using POS.Domain.Interfaces.Repositories;
using POS.Infra.Cross.DTO;
using POS.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace POS.Infra.Data.Repository
{
    public abstract class BaseRepository<TEntity, TEntityDTO> : IDisposable, IBaseRepository<TEntity, TEntityDTO> 
        where TEntity : class 
        where TEntityDTO : IEntityDTO
    {
        protected POSContext Db = new POSContext();
        public void Add(TEntityDTO entity)
        {
            var mappedEntity = Mapper.Map<TEntity>(entity);
            Db.Set<TEntity>().Add(mappedEntity);
            Db.SaveChanges();
        }

        public TEntityDTO GetById(int id)
        {
            var entity = Db.Set<TEntity>().Find(id);
            var mappedEntity = Mapper.Map<TEntityDTO>(entity);
            return mappedEntity;
        }
        
        protected IQueryable<TEntity> All()
        {
            var entities = Db.Set<TEntity>().AsQueryable();
            return entities;
        }

        public IEnumerable<TEntityDTO> GetAll()
        {
            var entities = Db.Set<TEntity>().ToList();
            var mappedEntities = Mapper.Map<List<TEntityDTO>>(entities);
            return mappedEntities;
        }

        public void Update(TEntityDTO entity)
        {
            var mappedEntity = Mapper.Map<TEntity>(entity);
            Db.Entry(mappedEntity).State = EntityState.Modified;
            Db.SaveChanges();
        }
        public void Remove(int id)
        {
            var entity = Db.Set<TEntity>().Find(id);
            var mappedEntity = Mapper.Map<TEntity>(entity);
            Db.Set<TEntity>().Remove(mappedEntity);
            Db.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}

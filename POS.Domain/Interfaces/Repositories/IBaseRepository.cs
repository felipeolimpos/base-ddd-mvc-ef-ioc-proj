using POS.Domain.Entities;
using POS.Infra.Cross.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity, TEntityDTO> : IDisposable
        where TEntity : class
        where TEntityDTO : IEntityDTO
    {
        void Add(TEntityDTO entity);
        TEntityDTO GetById(int id);
        IEnumerable<TEntityDTO> GetAll();
        void Update(TEntityDTO entity);
        void Remove(int id);
    }
}

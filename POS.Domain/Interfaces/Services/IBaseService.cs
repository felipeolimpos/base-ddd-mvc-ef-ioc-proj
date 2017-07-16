using POS.Infra.Cross.DTO;
using System.Collections.Generic;

namespace POS.Domain.Interfaces.Services
{
    public interface IBaseService<TEntityDTO> where TEntityDTO : IEntityDTO
    {
        void Add(TEntityDTO entity);
        TEntityDTO GetById(int id);
        IEnumerable<TEntityDTO> GetAll();
        void Update(TEntityDTO entity);
        void Remove(int id);
        void Dispose();
    }
}

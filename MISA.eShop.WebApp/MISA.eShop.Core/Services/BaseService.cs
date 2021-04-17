using MISA.eShop.Core.Interfaces.Repository;
using MISA.eShop.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.eShop.Core.Services
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity>
    {
        IBaseRepository<MISAEntity> _baseRepository;
        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public MISAEntity GetById(Guid entityId)
        {
            var entity = _baseRepository.GetById(entityId);
            return entity;
        }

        public IEnumerable<MISAEntity> GetEntities()
        {
            var entities = _baseRepository.GetEntities();
            return entities;
        }

    }
}

using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity>
    {
<<<<<<< HEAD
        public BaseService(IBaseRepository<CustomerGroup> baseRepository)
        {
        }

        public int Delete(Guid entityId)
        {
            throw new NotImplementedException();
=======
        IBaseRepository<MISAEntity> _baseRepository;
        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public IEnumerable<MISAEntity> GetEntities()
        {
            var entities = _baseRepository.GetEntities();
            return entities;
>>>>>>> c919336b1b85fad91ce6c3cf456f2becd1f90c80
        }

        public MISAEntity GetById()
        {
            throw new NotImplementedException();
        }

<<<<<<< HEAD
        public IReadOnlyList<MISAEntity> GetEntities()
        {
            throw new NotImplementedException();
        }

        public int Insert(MISAEntity entity)
        {
            throw new NotImplementedException();
        }

        public int Update(MISAEntity entity, Guid entityId)
=======
        public int Insert(MISAEntity entity)
        {
            //Validate nghiệp vụ

            //Thực hiện thêm mới
            _baseRepository.Insert(entity);
            throw new NotImplementedException();
        }

        public int Update(MISAEntity entity, Guid entityId)
        {
            throw new NotImplementedException();
        }
        public int Delete(Guid entityId)
>>>>>>> c919336b1b85fad91ce6c3cf456f2becd1f90c80
        {
            throw new NotImplementedException();
        }
    }
}

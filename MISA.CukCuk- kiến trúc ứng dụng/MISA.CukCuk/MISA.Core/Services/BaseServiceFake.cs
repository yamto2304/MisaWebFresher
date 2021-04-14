using MISA.Core.Entities;
using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Services
{
    public class BaseServiceFake<MISAEntity> : IBaseService<MISAEntity>
    {
        IUnitOfWork _unitOfWork;
        public BaseServiceFake(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<MISAEntity> GetEntities()
        {
            //var entities = _unitOfWork.Customer.GetEntities();
            //return entities;
            return null;
        }
        public MISAEntity GetById(Guid entityId)
        {
            throw new NotImplementedException();
        }

       

        public int Insert(MISAEntity entity)
        {
            Validate();
            throw new NotImplementedException();
        }

        public int Update(MISAEntity entity, Guid entityId)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public virtual void Validate()
        {

        }

    }
}

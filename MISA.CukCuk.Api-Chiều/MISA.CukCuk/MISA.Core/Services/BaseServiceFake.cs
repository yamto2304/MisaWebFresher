using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var entities = _unitOfWork.Customer.GetEntities();
            return (IEnumerable<MISAEntity>)entities;
        }

        public MISAEntity GetById()
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

        /// <summary>
        /// Virtual để lớp con có thể sửa nếu cần
        /// Hàm validate
        /// </summary>
        public virtual void Validate()
        {

        }
    }
}

using MISA.eShop.Core.Interfaces.Repository;
using MISA.eShop.Core.Interfaces.Service;
using System;
using System.Collections.Generic;

namespace MISA.eShop.Core.Services
{
    /// <summary>
    /// Class thực thi công việc cho Interface IBaseService
    /// </summary>
    /// <typeparam name="MISAEntity">Đối tượng truyền vào</typeparam>
    /// CreatedBy: Tuanhd(18/4/2021)
    public class BaseService<MISAEntity> : IBaseService<MISAEntity>
    {
        //Khởi tạo "lính" thực thi :))
        IBaseRepository<MISAEntity> _baseRepository;

        //Vào BaseService nhận việc :))
        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        /// <summary>
        /// Lấy dữ liệu theo Id
        /// </summary>
        /// <param name="entityId">Id của đối tượng cần lấy ra</param>
        /// <returns>Đối tượng có Id thỏa mãn</returns>
        /// CreatedBy: Tuanhd(18/4/2021)
        public MISAEntity GetById(Guid entityId)
        {
            var entity = _baseRepository.GetById(entityId);
            return entity;
        }

        /// <summary>
        /// Lấy toàn bộ dữ liệu mà "kho" có
        /// </summary>
        /// <returns>{{Y như tên gọi}}</returns>
        public IEnumerable<MISAEntity> GetEntities()
        {
            var entities = _baseRepository.GetEntities();
            return entities;
        }

    }
}

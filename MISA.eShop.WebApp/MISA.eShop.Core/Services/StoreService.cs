using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MISA.eShop.Core.Entities;
using MISA.eShop.Core.Exceptions;
using MISA.eShop.Core.Interfaces.Repository;
using MISA.eShop.Core.Interfaces.Service;

namespace MISA.eShop.Core.Services
{
    public class StoreService : BaseService<Store>, IStoreService
    {
        IStoreRepository _storeRepository;
        public StoreService(IStoreRepository storeRepository) : base(storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public int Delete(Guid storeId)
        {
            var store = _storeRepository.GetById(storeId);
            if (store != null)
            {
                var res = _storeRepository.Delete(storeId);
                return res;
            }
            else
            {
                throw new ValidateExceptions("Cửa hàng không tồn tại!");
            }

        }

        public Store GetByStoreCode(string storeCode)
        {
            var res = _storeRepository.GetByStoreCode(storeCode);
            return res;
        }

        public int GetCountStore()
        {
            var res = _storeRepository.GetCountStore();
            return res;
        }

        public IEnumerable<Store> GetIndexOffset(int position, int offset)
        {
            var res = _storeRepository.GetIndexOffset(position, offset);
            return res;
        }

        public IEnumerable<Store> GetStoreFilter(string storeCode, string storeName, string address, string phoneNumber, int? status)
        {
            var res = _storeRepository.GetStoreFilter(storeCode, storeName, address, phoneNumber, status);
            return res;
        }

        public int Insert(Store entity)
        {
            ValidateStore(entity);
            var store = _storeRepository.GetByStoreCode(entity.StoreCode);
            if (store == null)
            {

                var res = _storeRepository.Insert(entity);
                return res;
            }
            else
            {
                throw new ValidateExceptions("Mã cửa hàng bị trùng!");
            }

        }

        public int Update(Store entity, Guid storeId)
        {
            if (storeId == null || storeId == Guid.Empty)
            {
                throw new ValidateExceptions("ID cửa hàng không được phép trống!");
            }
            ValidateStore(entity);
            var store = _storeRepository.GetByStoreCode(entity.StoreCode);
            if (store == null || store.StoreId == storeId)
            {

                var res = _storeRepository.Update(entity, storeId);
                return res;
            }
            else
            {
                throw new ValidateExceptions("Mã cửa hàng bị trùng!");
            }

        }

        public bool ValidateStore(Store store)
        {
            if (string.IsNullOrEmpty(store.StoreCode))
            {
                return false;
                throw new ValidateExceptions("Mã cửa hàng không được để trống!");

            }
            if (string.IsNullOrEmpty(store.StoreName))
            {
                return false;
                throw new ValidateExceptions("Tên cửa hàng không được để trống!");

            }
            if (string.IsNullOrEmpty(store.Address))
            {
                return false;
                throw new ValidateExceptions("Địa chỉ cửa hàng không được để trống!");

            }
            if (!Regex.Match(store.PhoneNumber, @"^(\+[0-9]{9})$").Success)
            {
                return false;
                throw new ValidateExceptions("Số điện thoại của cửa hàng không đúng");
            }
            return true;
        }
    }
}

using MISA.eShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.eShop.Core.Interfaces.Service
{
    public interface IStoreService : IBaseService<Store>
    {
        int Delete(Guid storeId);
        int GetCountStore();
        IEnumerable<Store> GetIndexOffset(int position, int offset);
        Store GetByStoreCode(string storeCode);
        IEnumerable<Store> GetStoreFilter(string storeCode, string storeName, string address, string phoneNumber, int? status);
        int Insert(Store entity);
        int Update(Store entity, Guid storeId);
        bool ValidateStore(Store store);
    }
}

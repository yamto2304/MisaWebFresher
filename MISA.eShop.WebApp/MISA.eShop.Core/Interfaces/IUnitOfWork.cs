using MISA.eShop.Core.Interfaces.Repository;

namespace MISA.eShop.Core.Interfaces
{
    /// <summary>
    /// Interface UnitOfWork - quản lí chung công việc
    /// </summary>
    /// CreatedBy: Tuanhd(18/4/2021)
    public interface IUnitOfWork
    {
        public ICountryRepository CountryRepository { get; }
        public IDistrictRepository DistrictRepository { get; }
        public IProvinceRepository ProvinceRepository { get; }
        public IStoreRepository StoreRepository { get; }
        public IWardRepository WardRepository { get; }
    }
}

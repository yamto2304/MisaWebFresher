using MISA.eShop.Core.Entities;

using MISA.eShop.Core.Interfaces.Repository;

namespace MISA.eShop.Infrastructure.Repository
{
    /// <summary>
    /// Class lấy dữ liệu từ bảng Country
    /// </summary>
    /// CreatedBy: Tuanhd(18/4/2021)
    public class CountryRepository : BaseRepository<Country> , ICountryRepository
    {
    }
}

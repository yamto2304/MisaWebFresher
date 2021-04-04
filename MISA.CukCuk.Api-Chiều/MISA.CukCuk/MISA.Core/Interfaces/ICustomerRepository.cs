using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
<<<<<<< HEAD
        string CheckCustomerCode(Guid customerId);
=======
        string GetCustomerCodeById(Guid customerId);
>>>>>>> c919336b1b85fad91ce6c3cf456f2becd1f90c80
    }
}

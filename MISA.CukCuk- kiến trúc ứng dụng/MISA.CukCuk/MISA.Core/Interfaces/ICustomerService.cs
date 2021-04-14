﻿using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interfaces
{
    public interface ICustomerService: IBaseService<Customer>
    {
        IEnumerable<Customer> GetAllCustomer();
    }
}

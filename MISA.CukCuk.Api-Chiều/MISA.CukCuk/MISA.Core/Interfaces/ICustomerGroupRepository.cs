﻿using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces
{
    public interface ICustomerGroupRepository : IBaseRepository<CustomerGroup>
    {
        //bool CheckCustomerGroupName(string name);
    }
}

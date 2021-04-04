﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces
{
    public interface IUniOfWork
    {
        ICustomerRepository Customer { get; }
        ICustomerGroupRepository CustomerGroup { get; }
    }
}

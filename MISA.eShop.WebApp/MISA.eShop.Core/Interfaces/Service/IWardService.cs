﻿using MISA.eShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.eShop.Core.Interfaces.Service
{
    public interface IWardService : IBaseService<Ward>
    {
        IEnumerable<Ward> GetWardWithDistrict(Guid entityId);
    }
}

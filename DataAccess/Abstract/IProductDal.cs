﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    //Interfacein kendisi internal ama operasyonları defaul public

    public interface IProductDal : IEntityRepository<Product>
    {

    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    //Interfacein kendisi internal ama operasyonları default public

    public interface IProductDal : IEntityRepository<Product>
    {

    }
}
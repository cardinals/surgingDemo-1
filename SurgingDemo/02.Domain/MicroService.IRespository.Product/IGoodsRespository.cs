﻿using MicroService.Core;
using MicroService.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.IRespository.Product
{
    public interface IGoodsRespository : IRespositoryBase<Entity.Product.Goods>, IDependency
    {

    }
}

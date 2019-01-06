using MicroService.Core;
using MicroService.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.IRespository.Order
{
   public interface IRoleRespository: IRespositoryBase<MicroService.Entitiy.Order.Role>, IDependency
    {

    }
}

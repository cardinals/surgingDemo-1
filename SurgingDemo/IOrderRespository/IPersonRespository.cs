using MicroService.Core;
using MicroService.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.IRespository.Order
{
    public interface IPersonRespository : IRespositoryBase<MicroService.Entity.Order.Person>, IDependency
    {

    }
}

using MicroService.Core;
using MicroService.Data;
using MicroService.Entity.Order;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.IRespository.Order
{
    public interface IOrderRespository : IRespositoryBase<MicroService.Entity.Order.OrderInfo>, IDependency
    {
       
    }
}

using MicroService.IRespository.Order;
using MicroService.EntityFramwork;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.Respository.Order
{
    public class OrderRespository : RespositoryBase<MicroService.Entity.Order.OrderInfo>, IOrderRespository
    {




        public OrderRespository(IUnitOfWorkDbContext dbDbContext) : base(dbDbContext)
        {

        }
    }
}

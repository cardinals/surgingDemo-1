
using MicroService.IRespository.Order;
using MicroService.EntityFramwork;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.Respository.Order
{
    public class OrderDetailRespository : RespositoryBase<MicroService.Entity.Order.OrderDetail>, IOrderDetailRespository
    {
        public OrderDetailRespository(IUnitOfWorkDbContext dbDbContext) : base(dbDbContext)
        {
        }
    }
}

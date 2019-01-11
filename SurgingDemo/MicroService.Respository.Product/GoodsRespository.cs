
using MicroService.IRespository.Product;
using MicroService.EntityFramwork;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.Respository.Order
{
    public class GoodsRespository : RespositoryBase<MicroService.Entity.Product.Goods>, IGoodsRespository
    {
        public GoodsRespository(IUnitOfWorkDbContext dbDbContext) : base(dbDbContext)
        {
        }
    }
}

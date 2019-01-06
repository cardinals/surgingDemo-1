
using MicroService.IRespository.Order;
using MicroService.EntityFramwork;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.Respository.Order
{
    public class RoleRespository : RespositoryBase<MicroService.Entitiy.Order.Role>, IRoleRespository
    {
        public RoleRespository(IUnitOfWorkDbContext dbDbContext) : base(dbDbContext)
        {
        }
    }
}

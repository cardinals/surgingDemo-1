using MicroService.IRespository.Org;
using MicroService.EntityFramwork;
using System;
using System.Collections.Generic;
using System.Text;
using MicroService.Entity.Org;

namespace MicroService.Respository.Order
{
    public class UserRespository : RespositoryBase<User>, IUserRespository
    {
        public UserRespository(IUnitOfWorkDbContext dbDbContext) : base(dbDbContext)
        {

        }
    }
}

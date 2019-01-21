
using MicroService.IRespository.Org;
using MicroService.EntityFramwork;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.Respository.Org
{
    public class RoleRespository : RespositoryBase<MicroService.Entity.Org.Role>, IRoleRespository
    {
        public RoleRespository(IUnitOfWorkDbContext dbDbContext) : base(dbDbContext)
        {
        }
    }
}

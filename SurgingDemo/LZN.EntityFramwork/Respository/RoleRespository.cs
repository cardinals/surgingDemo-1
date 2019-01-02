using LZN.Core.IRespository;
using LZN.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LZN.EntityFramwork.Respository
{
    public class RoleRespository : RespositoryBase<Role>, IRoleRespository
    {
        public RoleRespository(IUnitOfWorkDbContext dbDbContext) : base(dbDbContext)
        {
        }
    }
}

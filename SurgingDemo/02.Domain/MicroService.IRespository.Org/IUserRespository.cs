using MicroService.Core;
using MicroService.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.IRespository.Org
{
    public interface IUserRespository : IRespositoryBase<MicroService.Entity.Org.User>, IDependency
    {

    }
}

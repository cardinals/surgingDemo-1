using MicroService.IModules.Org;
using Surging.Core.CPlatform.Ioc;
using Surging.Core.ProxyGenerator;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.Modules.Org
{
    [ModuleName("Org")]
    public class OrgService : ProxyServiceBase, IOrgService
    {
        public int Number(int x, int y)
        {
            return x + y;
        }
    }
}

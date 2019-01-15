using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.IModules.Org
{
    [ServiceBundle("api/{Service}")]
    public interface IOrgService: IServiceKey
    {

        int Number(int x, int y);
    }
}

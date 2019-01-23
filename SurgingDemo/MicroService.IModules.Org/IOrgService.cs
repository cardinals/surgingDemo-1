using MicroService.Data.Validation;
using MicroService.IApplication.Org.Dto;
using Surging.Core.CPlatform.Filters.Implementation;
using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.IModules.Org
{
    [ServiceBundle("api/{Service}")]
    public interface IOrgService: IServiceKey
    {

        Task<string> Number(int x, int y);

        [Authorization(AuthType = AuthorizationType.JWT)]
        Task<JsonResponse> Add(UserRequestDto userRequestDto);
    }
}

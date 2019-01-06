using MicroService.Data.Validation;
using MicroService.IApplication.Order.Dto;
using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.IModules.Order
{
    [ServiceBundle("api/{Service}")]
    public interface IOrderService: IServiceKey
    {
        Task<string> Say();

        Task<JsonResponse> Add(PersonRequestDto personRequestDto);
        Task<string> AddAndGetId(PersonRequestDto personRequestDto);

        Task<IEnumerable<PersonQueryDto>> GetAll();
    }
}

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
        Task<string> Say(OrderInfoQueryDto orderInfoQueryDto);

        Task<JsonResponse> Add(OrderInfoRequestDto personRequestDto);
        Task<string> AddAndGetId(OrderInfoRequestDto personRequestDto);

        Task<IEnumerable<OrderInfoQueryDto>> GetAll();
    }
}

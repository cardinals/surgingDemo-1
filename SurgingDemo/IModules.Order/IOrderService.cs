using MicroService.Data.Common;
using MicroService.Data.Validation;
using MicroService.IApplication.Order.Dto;
using Surging.Core.CPlatform.Filters.Implementation;
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

        [Authorization(AuthType = AuthorizationType.JWT)]
        Task<JsonResponse> Create(OrderInfoRequestDto orderInfoRequestDto);

        [Authorization(AuthType = AuthorizationType.JWT)]
        Task<JsonResponse> BatchCreate(IList<OrderInfoRequestDto> orderInfoRequestDtos);

        [Authorization(AuthType = AuthorizationType.JWT)]
        Task<IEnumerable<OrderInfoQueryDto>> GetPageList(OrderInfoPageRequestDto orderInfoPageRequestDto);

        [Authorization(AuthType = AuthorizationType.JWT)]
        Task<OrderInfoQueryDto> GetForModify(EntityQueryRequest entityQueryRequest);

        [Authorization(AuthType = AuthorizationType.JWT)]
        Task<JsonResponse> Modify(OrderInfoRequestDto orderInfoRequestDto);

        [Authorization(AuthType = AuthorizationType.JWT)]
        Task<JsonResponse> Remove(params string[] ids);
    }
}

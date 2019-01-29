
using MicroService.Data;
using MicroService.Data.Common;
using MicroService.Data.Validation;
using MicroService.IApplication.Order.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.IApplication.Order
{
    
    public interface IOrderAppService : IDependency
    {
        Task<JsonResponse> CreateAsync(OrderInfoRequestDto orderInfoRequestDto);

        Task<JsonResponse> BatchCreateAsync(IList<OrderInfoRequestDto> orderInfoRequestDtos);
     
        Task<IEnumerable<OrderInfoQueryDto>> GetPageListAsync(OrderInfoPageRequestDto orderInfoPageRequestDto);

        Task<OrderInfoQueryDto> GetForModifyAsync(EntityQueryRequest entityQueryRequest);

        Task<JsonResponse> ModifyAsync(OrderInfoRequestDto orderInfoRequestDto);

        Task<JsonResponse> RemoveAsync(params string[] ids);
    }
}

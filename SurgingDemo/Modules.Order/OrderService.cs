
using MicroService.Data.Common;
using MicroService.Data.Extensions;
using MicroService.Data.Validation;
using MicroService.IApplication.Order;
using MicroService.IApplication.Order.Dto;
using MicroService.IModules.Order;
using Surging.Core.CPlatform.Ioc;
using Surging.Core.ProxyGenerator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.Modules.Order
{
    [ModuleName("Order")]
   public class OrderService: ProxyServiceBase, IOrderService
    {
        private readonly IOrderAppService _orderAppService;
        public OrderService(IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService;
        }
        public async Task<JsonResponse> Create(OrderInfoRequestDto orderInfoRequestDto)
        {
            orderInfoRequestDto.ToLoginUser();
            return await _orderAppService.CreateAsync(orderInfoRequestDto);
        }
        public async Task<JsonResponse> BatchCreate(IList<OrderInfoRequestDto> orderInfoRequestDtos)
        {
            return await _orderAppService.BatchCreateAsync(orderInfoRequestDtos);
        }


        public async Task<OrderInfoQueryDto> GetForModify(EntityQueryRequest entityQueryRequest)
        {
            return await _orderAppService.GetForModifyAsync(entityQueryRequest);
        }

        public async Task<IEnumerable<OrderInfoQueryDto>> GetPageList(OrderInfoPageRequestDto orderInfoPageRequestDto)
        {
            return await _orderAppService.GetPageListAsync(orderInfoPageRequestDto);
        }

        public async Task<JsonResponse> Modify(OrderInfoRequestDto orderInfoRequestDto)
        {
            return await _orderAppService.ModifyAsync(orderInfoRequestDto);
        }

        public async Task<JsonResponse> Remove(params string[] ids)
        {
            return await _orderAppService.RemoveAsync(ids);
        }
    }
}

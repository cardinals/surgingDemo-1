
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
       public async Task<string> Say(OrderInfoQueryDto orderInfoQueryDto)
        {
            return await Task.FromResult("hello world"+ orderInfoQueryDto.OrderNumber);
        }
        public async Task<JsonResponse> Add(OrderInfoRequestDto personRequestDto)
        {
           return await _orderAppService.Create(personRequestDto);
        }

       public async Task<string> AddAndGetId(OrderInfoRequestDto personRequestDto)
        {
           return await _orderAppService.InsertAndGetId(personRequestDto);
        }

        public async Task<IEnumerable<OrderInfoQueryDto>> GetAll()
        {
            return await _orderAppService.GetAll();
        }
    }
}

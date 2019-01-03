using IModules.Order;
using IOrderApplication;
using IOrderApplication.Dto;
using Surging.Core.CPlatform.Ioc;
using Surging.Core.ProxyGenerator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Order
{
    [ModuleName("Order")]
   public class OrderService: ProxyServiceBase, IOrderService
    {
        private readonly IOrderAppService _orderAppService;
        public OrderService(IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService;
        }
       public async Task<string> Say()
        {
            return await Task.FromResult("hello world");
        }
        public async Task<int> Add(PersonRequestDto personRequestDto)
        {
           return await _orderAppService.Create(personRequestDto);
        }

    

        public async Task<IEnumerable<PersonQueryDto>> GetAll()
        {
            return await _orderAppService.GetAll();
        }
    }
}

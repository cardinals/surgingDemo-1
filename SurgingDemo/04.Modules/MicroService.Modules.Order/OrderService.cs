
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
using System.Linq;
using System.Data;
using Surging.Core.CPlatform.Utilities;
using Newtonsoft.Json;

namespace MicroService.Modules.Order
{
    [ModuleName("Order")]
   public class OrderService: ProxyServiceBase, IOrderService
    {
        private readonly IOrderAppService _orderAppService;
        private readonly IOrderDetailAppService _orderDetailAppService;
        public OrderService(IOrderAppService orderAppService, IOrderDetailAppService orderDetailAppService)
        {
            _orderAppService = orderAppService;
            _orderDetailAppService = orderDetailAppService;
        }
        public async Task<JsonResponse> Create(OrderInfoRequestDto orderInfoRequestDto)
        {
            orderInfoRequestDto.ToLoginUser();
            List<GoodsQueryDto> goodsQuerys = await GetGoodsAsync(orderInfoRequestDto);

            List<OrderDetailRequestDto> orderDetailRequestDtos = new List<OrderDetailRequestDto>();
            orderInfoRequestDto.Id = Guid.NewGuid().ToString();
            foreach (var item in goodsQuerys)
            {
                var good = orderInfoRequestDto.GoodsRequests.Where(g => g.GoodsId == item.Id).SingleOrDefault();
                orderDetailRequestDtos.Add(new OrderDetailRequestDto()
                {
                    Id = Guid.NewGuid().ToString(),
                    GoodsId = item.Id,
                    OrderId = orderInfoRequestDto.Id,
                    Count = good.Count,
                    Price = item.Price,
                    Money = good.Count * item.Price
                });
            }
            orderInfoRequestDto.OrderNumber = DateTime.Now.ToString();
            orderInfoRequestDto.TotalMoney = orderDetailRequestDtos.Select(d => d.Money).Sum();
            orderInfoRequestDto.ExpireTime = DateTime.Now.AddDays(14);

            var resJson = await new ApplicationEnginee().TryTransactionAsync(async () =>
            {
                await _orderAppService.CreateAsync(orderInfoRequestDto);
                await _orderDetailAppService.BatchCreateAsync(orderDetailRequestDtos);
            });
            return resJson;


        }

        private static async Task<List<GoodsQueryDto>> GetGoodsAsync(OrderInfoRequestDto orderInfoRequestDto)
        {
            var serviceProxyProvider = ServiceLocator.GetService<IServiceProxyProvider>();
            Dictionary<string, object> model = new Dictionary<string, object>();
            model.Add("entityQueryRequest", JsonConvert.SerializeObject(new
            {
                Ids = orderInfoRequestDto.GoodsRequests.Select(g => g.GoodsId).ToList(),
            }));
            string path = "api/Goods/GetGoodsByIds";
            string serviceKey = "Goods";

            var goodsProxy = await serviceProxyProvider.Invoke<object>(model, path, serviceKey);
            List<GoodsQueryDto> goodsQuerys = JsonConvert.DeserializeObject<List<GoodsQueryDto>>(goodsProxy.ToString());
            return goodsQuerys;
        }

        public async Task<JsonResponse> BatchCreate(OrderInfoBatchRequestDto orderInfoBatchRequestDto)
        {
            return await _orderAppService.BatchCreateAsync(orderInfoBatchRequestDto.OrderInfoRequestList);
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

        public async Task<JsonResponse> Remove(EntityRequest entityRequest)
        {
          
            return await _orderAppService.RemoveAsync(entityRequest.Ids.ToArray());
        }

        public async Task<DataTable> GetList()
        {
            return await _orderAppService.GetList();
        }
    }
}

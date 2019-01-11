using System;
using System.Collections.Generic;
using System.Text;
using MicroService.IModules.Product;
using Surging.Core.CPlatform.Ioc;
using Surging.Core.ProxyGenerator;
using MicroService.IApplication.Product;
using MicroService.IApplication.Product.Dto;
using MicroService.Data.Validation;
using System.Threading.Tasks;

namespace MicroService.Modules.Product
{
    [ModuleName("Goods")]
   public class GoodsService: ProxyServiceBase,IGoodsService
    {
        private readonly IGoodsAppService _goodsAppService;
        public GoodsService(IGoodsAppService goodsAppService)
        {
            _goodsAppService = goodsAppService;
        }
        public async Task<JsonResponse> Add( GoodsRequestDto goodsRequestDto)
        {
            return await _goodsAppService.Create(goodsRequestDto);
        }

    }
}

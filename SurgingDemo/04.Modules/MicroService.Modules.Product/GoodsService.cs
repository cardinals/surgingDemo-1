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
using System.Data;
using MicroService.Data.Common;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
        public async Task<DataTable> GetList()
        {
            return  await _goodsAppService.GetList();
        }

        public async Task<PageData> GetPageList(GoodsoPageRequestDto goodsoPageRequestDto)
        {
             return await _goodsAppService.GetPageListAsync(goodsoPageRequestDto);
            //PageData pageData = new PageData();
            //using (TestDbContext db = new TestDbContext())
            //{
            //    var data = await db.Goods.Where(g => g.IsDelete == false).ToListAsync();
            //    pageData.Data = data;
            //    return pageData;
            //}
        }
        public async Task<GoodsQueryDto> GetForModify(EntityQueryRequest entityQueryRequest)
        {
            return await _goodsAppService.GetForModifyAsync(entityQueryRequest);
        }

       public async Task<IEnumerable<GoodsQueryDto>> GetGoodsByIds(EntityQueryRequest entityQueryRequest)
        {
            return await _goodsAppService.GetGoodsByIds(entityQueryRequest);
        }
    }
}

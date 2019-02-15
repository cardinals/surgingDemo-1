
using MicroService.Core;
using MicroService.Data;
using MicroService.Data.Common;
using MicroService.Data.Validation;
using MicroService.IApplication.Product.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.IApplication.Product
{
    
    public interface IGoodsAppService : IDependency
    {
        Task<JsonResponse> Create(GoodsRequestDto goodsRequestDto);
        Task <PageData> GetPageListAsync(GoodsoPageRequestDto goodsoPageRequestDto);
        Task<GoodsQueryDto> GetForModifyAsync(EntityQueryRequest entityQueryRequest);

        Task<IEnumerable<GoodsQueryDto>> GetGoodsByIds(EntityQueryRequest entityQueryRequest);
        Task<DataTable> GetList();
    }
}

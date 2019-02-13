using MicroService.Data.Validation;
using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MicroService.IApplication.Product.Dto;
using System.Data;
using Surging.Core.CPlatform.Filters.Implementation;
using MicroService.Data.Common;

namespace MicroService.IModules.Product
{
    [ServiceBundle("api/{Service}")]
    public interface IGoodsService: IServiceKey
    {
        Task<JsonResponse> Add( GoodsRequestDto goodsRequestDto);

        [Authorization(AuthType = AuthorizationType.JWT)]
        Task<PageData> GetPageList(GoodsoPageRequestDto goodsoPageRequestDto);


        Task<DataTable> GetList();
    }
}

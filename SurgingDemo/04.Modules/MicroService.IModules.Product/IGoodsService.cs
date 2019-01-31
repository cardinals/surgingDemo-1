using MicroService.Data.Validation;
using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MicroService.IApplication.Product.Dto;
using System.Data;

namespace MicroService.IModules.Product
{
    [ServiceBundle("api/{Service}")]
    public interface IGoodsService: IServiceKey
    {
        Task<JsonResponse> Add( GoodsRequestDto goodsRequestDto);
        Task<DataTable> GetList();
    }
}

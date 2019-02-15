using MicroService.Core;
using MicroService.Data.Validation;
using MicroService.IApplication.Order.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.IApplication.Order
{
    public interface IOrderDetailAppService: IDependency
    {

        Task<JsonResponse> BatchCreateAsync(IList<OrderDetailRequestDto> orderInfoRequestDtos);
    }
}

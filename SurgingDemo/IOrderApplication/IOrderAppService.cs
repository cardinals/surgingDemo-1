
using MicroService.Data;
using MicroService.Data.Validation;
using MicroService.IApplication.Order.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.IApplication.Order
{
    
    public interface IOrderAppService : IDependency
    {
        Task<JsonResponse> Create(OrderInfoRequestDto personRequestDto);

        Task<string> InsertAndGetId(OrderInfoRequestDto personRequestDto);

        Task<IEnumerable<OrderInfoQueryDto>> GetAll();

        Task<JsonResponse> Modify(OrderInfoRequestDto personRequestDto);

        Task<JsonResponse> Remove(params string[] ids);
    }
}

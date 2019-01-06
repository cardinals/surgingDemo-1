
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
        Task<JsonResponse> Create(PersonRequestDto personRequestDto);

        Task<string> InsertAndGetId(PersonRequestDto personRequestDto);

        Task<IEnumerable<PersonQueryDto>> GetAll();


        Task<int> Modify(PersonRequestDto personRequestDto);
    }
}

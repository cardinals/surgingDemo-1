
using MicroService.Core;
using MicroService.Data.Common;
using MicroService.Data.Validation;
using MicroService.IApplication.Org.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.IApplication.Org
{
    
    public interface IUserAppService : IDependency
    {
        Task<JsonResponse> CreateAsync(UserRequestDto personRequestDto);

        Task<string> InsertAndGetId(UserRequestDto personRequestDto);

        Task<LoginUser> Login(UserRequestDto userRequestDto);

        Task<IEnumerable<UserQueryDto>> GetAll();


        Task<int> Modify(UserRequestDto personRequestDto);
    }
}

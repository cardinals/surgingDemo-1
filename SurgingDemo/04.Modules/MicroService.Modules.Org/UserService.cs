using MicroService.Data.Common;
using MicroService.Data.Validation;
using MicroService.IApplication.Org;
using MicroService.IApplication.Org.Dto;
using MicroService.IModules.Org;
using Surging.Core.CPlatform.Ioc;
using Surging.Core.ProxyGenerator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.Modules.Org
{
    [ModuleName("User")]
    public class UserService : ProxyServiceBase, IUserService
    {
        public IUserAppService _userAppService;
        public UserService(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public async Task<LoginUser> Authentication(UserRequestDto userRequestDto)
        {
            return await _userAppService.Login(userRequestDto);
        }

        public async Task<JsonResponse> Register(UserRequestDto userRequestDto)
        {
            userRequestDto.PhoneCode = "1111111";
            userRequestDto.RoleId = "9e056c68-1939-11e9-a939-00163e14af03";
            return await _userAppService.CreateAsync(userRequestDto);
        }
    }
   
}

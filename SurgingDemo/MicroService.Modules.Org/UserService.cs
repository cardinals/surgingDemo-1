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

        public async Task<UserQueryDto> Authentication(UserRequestDto userRequestDto)
        {
            return await _userAppService.Login(userRequestDto);
        }
    }
   
}

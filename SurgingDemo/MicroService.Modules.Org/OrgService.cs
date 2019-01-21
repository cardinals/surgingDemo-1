using MicroService.IModules.Org;
using Surging.Core.CPlatform.Ioc;
using Surging.Core.ProxyGenerator;
using System;
using System.Collections.Generic;
using System.Text;
using MicroService.IApplication.Org;
using MicroService.Data.Validation;
using MicroService.IApplication.Org.Dto;
using System.Threading.Tasks;
using Surging.Core.CPlatform.Filters.Implementation;

namespace MicroService.Modules.Org
{
    [ModuleName("Org")]
    public class OrgService : ProxyServiceBase, IOrgService
    {
        public IUserAppService _userAppService;
        public OrgService(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
       
        public async Task<JsonResponse> Add(UserRequestDto userRequestDto)
        {
            return await _userAppService.Create(userRequestDto);
        }

        public int Number(int x, int y)
        {
            return x + y;
        }
    }
}

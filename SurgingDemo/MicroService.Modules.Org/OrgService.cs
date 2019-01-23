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
using Surging.Core.CPlatform.Utilities;
using Newtonsoft.Json;

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

        public async Task<string> Number(int x, int y)
        {
            var serviceProxyProvider = ServiceLocator.GetService<IServiceProxyProvider>();

            Dictionary<string, object> model = new Dictionary<string, object>();
            model.Add("orderInfoQueryDto", JsonConvert.SerializeObject(new
            {
                OrderNumber = "2019090012",
                TotalMoney = 18,
                UserId = 1
            }));
            string path = "api/Order/Say";
            string serviceKey = "Order";

            var userProxy = await serviceProxyProvider.Invoke<object>(model, path, serviceKey);
            var s =  userProxy;
            return (x + y).ToString()+s.ToString();
        }
    }
}

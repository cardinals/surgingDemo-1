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
using Surging.Core.KestrelHttpServer.Internal;
using System.IO;
using Surging.Core.KestrelHttpServer;

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
            return await _userAppService.CreateAsync(userRequestDto);
        }

        public async Task<bool> UploadFile(HttpFormCollection form)
        {
            var files = form.Files;
            foreach (var file in files)
            {
                using (var stream = new FileStream(Path.Combine(AppContext.BaseDirectory, file.FileName), FileMode.OpenOrCreate))
                {
                    await stream.WriteAsync(file.File, 0, (int)file.Length);
                }
            }
            return true;
        }

        public async Task<IActionResult> DownFile(string fileName, string contentType)
        {
            string uploadPath = Path.Combine(AppContext.BaseDirectory, fileName);
            if (File.Exists(uploadPath))
            {
                using (var stream = new FileStream(uploadPath, FileMode.Open))
                {
                    var bytes = new Byte[stream.Length];
                    await stream.ReadAsync(bytes, 0, bytes.Length);
                    stream.Dispose();
                    return new FileContentResult(bytes, contentType, fileName);
                }
            }
            else
            {
                throw new FileNotFoundException(fileName);
            }
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

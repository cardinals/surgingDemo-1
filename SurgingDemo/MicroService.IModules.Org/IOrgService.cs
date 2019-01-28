using MicroService.Data.Validation;
using MicroService.IApplication.Org.Dto;
using Surging.Core.CPlatform.Filters.Implementation;
using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using Surging.Core.KestrelHttpServer;
using Surging.Core.KestrelHttpServer.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.IModules.Org
{
    [ServiceBundle("api/{Service}")]
    public interface IOrgService: IServiceKey
    {
          /// <summary>
        /// 测试上传文件
        /// </summary>
        /// <param name="form">HttpFormCollection 类型参数</param>
        /// <returns></returns>
        Task<bool> UploadFile(HttpFormCollection form);

        /// <summary>
        /// 测试下载文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="contentType">Content-Type</param>
        /// <returns></returns>
        Task<IActionResult> DownFile(string fileName, string contentType);

        Task<string> Number(int x, int y);

        [Authorization(AuthType = AuthorizationType.JWT)]
        Task<JsonResponse> Add(UserRequestDto userRequestDto);
    }
}

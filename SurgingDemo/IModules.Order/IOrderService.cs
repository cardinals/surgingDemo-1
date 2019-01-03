using IOrderApplication.Dto;
using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IModules.Order
{
    [ServiceBundle("api/{Service}")]
    public interface IOrderService: IServiceKey
    {
        Task<string> Say();

        Task<int> Add(PersonRequestDto personRequestDto);

        Task<IEnumerable<PersonQueryDto>> GetAll();
    }
}

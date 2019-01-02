using IOrderApplication.Dto.Person;
using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IOrderApplication
{
    [ServiceBundle("api/{Service}")]
    public interface IOrderService: IServiceKey
    {
        Task<int> Test(int a);


        Task<int> AddPerson(PersonRequestDto personRequestDto);


         Task<IEnumerable<PersonRequestDto>> GetAll();

        Task<int> ModifyPerson(PersonRequestDto personRequestDto);
    }
}

using IOrderApplication.Dto;
using LZN.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IOrderApplication
{
    
    public interface IOrderAppService : IDependency
    {
        Task<int> Create(PersonRequestDto personRequestDto);


        Task<IEnumerable<PersonQueryDto>> GetAll();


        Task<int> Modify(PersonRequestDto personRequestDto);
    }
}

using AutoMapper;
using IOrderApplication;
using IOrderApplication.Dto.Person;
using LZN.Core.Data;
using LZN.Core.IRespository;
using LZN.Core.Model;
using Microsoft.EntityFrameworkCore;
using Surging.Core.CPlatform.Ioc;
using Surging.Core.ProxyGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LZN.Data.Ext;
namespace OrderApplication
{
    [ModuleName("Order")]
    public class OrderService : ProxyServiceBase, IOrderService
    {
        public IPersonRespository _personRespository;
        private readonly IMapper _mapper;
        public IUnitOfWork _unitOfWork;

        public OrderService(IPersonRespository personRespository, IUnitOfWork unitOfWork,
          IMapper mapper)
        {
            _personRespository = personRespository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> AddPerson(PersonRequestDto personRequestDto)
        {
            personRequestDto.Id = Guid.NewGuid().ToString();
            var person = _mapper.Map<PersonRequestDto, Person>(personRequestDto);
            await _personRespository.Add(person);
            return  await _unitOfWork.SaveChangesAsync();
        }

        public async Task<int> Test(int a)
        {
            return await Task.FromResult<int>(a + 1);
        }

        public async Task<IEnumerable<PersonRequestDto>> GetAll()
        {
            var list = await _personRespository.Entities();

            return list.MapToList<Person, PersonRequestDto>();

        }

        public async Task<int> ModifyPerson(PersonRequestDto personRequestDto)
        {
            return await Task.FromResult<int>(222);
        }
    }
}

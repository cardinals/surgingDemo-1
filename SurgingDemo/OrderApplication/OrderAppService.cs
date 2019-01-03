using AutoMapper;

using LZN.Core.Data;
using LZN.Core.IRespository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LZN.Data.Ext;
using LZN.Core.Model;
using IOrderApplication;
using IOrderApplication.Dto;

namespace OrderApplication
{
  
    public class OrderAppService : IOrderAppService
    {
        public IPersonRespository _personRespository;
        private readonly IMapper _mapper;
        public IUnitOfWork _unitOfWork;

        public OrderAppService(IPersonRespository personRespository, IUnitOfWork unitOfWork,
          IMapper mapper)
        {
            _personRespository = personRespository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> Create(PersonRequestDto personRequestDto)
        {
            personRequestDto.Id = Guid.NewGuid().ToString();
            var person = _mapper.Map<PersonRequestDto, Person>(personRequestDto);
            await _personRespository.Add(person);
            return await _unitOfWork.SaveChangesAsync();


        }

        public async Task<int> Test(int a)
        {
            return await Task.FromResult<int>(a + 1);
        }

        public async Task<IEnumerable<PersonQueryDto>> GetAll()
        {
            var list = await _personRespository.Entities().ToListAsync();

            return list.MapToList<Person, PersonQueryDto>();

        }

        public async Task<int> Modify(PersonRequestDto personRequestDto)
        {
            personRequestDto.Id = Guid.NewGuid().ToString();
            var person = _mapper.Map<PersonRequestDto, Person>(personRequestDto);
            await _personRespository.Add(person);
            return await _unitOfWork.SaveChangesAsync();
        }

    }
}

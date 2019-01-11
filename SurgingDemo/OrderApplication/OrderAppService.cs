using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroService.Data.Ext;
using MicroService.IApplication.Order;
using MicroService.IRespository.Order;
using MicroService.Entity.Order;
using MicroService.IApplication.Order.Dto;
using MicroService.Core.Data;
using MicroService.Data.Validation;
using MicroService.Application.Order.Validators;
using MicroService.Data.Extensions;
namespace MicroService.Application.Order
{
  
    public class OrderAppService : ApplicationEnginee, IOrderAppService
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

        private async Task DoValidationAsync(Person person, string validatorType)
        {
            var personValidator = new PersonValidator();
            var validatorReresult = await personValidator.DoValidateAsync(person, validatorType);
            if (!validatorReresult.IsValid)
            {
                throw new DomainException(validatorReresult);
            }
        }
        public async Task<JsonResponse> Create(PersonRequestDto personRequestDto)
        {
            personRequestDto.Id = Guid.NewGuid().ToString();
            var resJson = await TryTransactionAsync(async () =>
              {
                  var person = _mapper.Map<PersonRequestDto, Person>(personRequestDto);
                  await DoValidationAsync(person, ValidatorTypeConstants.Create);
                  await _personRespository.InsertAsync(person);

                  await _unitOfWork.SaveChangesAsync();
              });
            return resJson;
        }
        public async Task<string> InsertAndGetId(PersonRequestDto personRequestDto)
        {
            personRequestDto.Id = Guid.NewGuid().ToString();
            var person = _mapper.Map<PersonRequestDto, Person>(personRequestDto);
            await _personRespository.InsertAsync(person);
            var res= await _personRespository.InsertAndGetIdAsync(person);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }
        public async Task<int> Test(int a)
        {
            return await Task.FromResult<int>(a + 1);
        }

        public async Task<IEnumerable<PersonQueryDto>> GetAll()
        {
            var list = await _personRespository.GetAll().ToListAsync();

            return list.MapToList<Person, PersonQueryDto>();

        }

        public async Task<int> Modify(PersonRequestDto personRequestDto)
        {
            return await Task.FromResult<int>(121);
        }

    }
}

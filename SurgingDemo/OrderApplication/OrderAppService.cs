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
        public IOrderRespository _orderRespository;
        private readonly IMapper _mapper;
        public IUnitOfWork _unitOfWork;

        public OrderAppService(IOrderRespository orderRespository, IUnitOfWork unitOfWork,
          IMapper mapper)
        {
            _orderRespository = orderRespository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        private async Task DoValidationAsync(OrderInfo orderInfo, string validatorType)
        {
            var orderInfoValidator = new OrderInfoValidator();
            var validatorReresult = await orderInfoValidator.DoValidateAsync(orderInfo, validatorType);
            if (!validatorReresult.IsValid)
            {
                throw new DomainException(validatorReresult);
            }
        }
        public async Task<JsonResponse> Create(OrderInfoRequestDto personRequestDto)
        {
            personRequestDto.Id = Guid.NewGuid().ToString();
            var resJson = await TryTransactionAsync(async () =>
              {
                  var orderInfo = _mapper.Map<OrderInfoRequestDto, OrderInfo>(personRequestDto);
                  await DoValidationAsync(orderInfo, ValidatorTypeConstants.Create);
                  await _orderRespository.InsertAsync(orderInfo);

                  await _unitOfWork.SaveChangesAsync();
              });
            return resJson;
        }
        public async Task<string> InsertAndGetId(OrderInfoRequestDto personRequestDto)
        {
            personRequestDto.Id = Guid.NewGuid().ToString();
            var orderInfo = _mapper.Map<OrderInfoRequestDto, OrderInfo>(personRequestDto);
            await _orderRespository.InsertAsync(orderInfo);
            var res= await _orderRespository.InsertAndGetIdAsync(orderInfo);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }
        public async Task<int> Test(int a)
        {
            return await Task.FromResult<int>(a + 1);
        }

        public async Task<IEnumerable<OrderInfoQueryDto>> GetAll()
        {
            var list = await _orderRespository.GetAll().ToListAsync();

            return list.MapToList<OrderInfo, OrderInfoQueryDto>();

        }

        public async Task<JsonResponse> Modify(OrderInfoRequestDto personRequestDto)
        {
            var person = _mapper.Map<OrderInfoRequestDto, OrderInfo>(personRequestDto);
            var resJson = await TryTransactionAsync(async () =>
            {
                var orderInfo = _mapper.Map<OrderInfoRequestDto, OrderInfo>(personRequestDto);
                await DoValidationAsync(orderInfo, ValidatorTypeConstants.Create);
                await _orderRespository.UpdateAsync(orderInfo);
                await _unitOfWork.SaveChangesAsync();
            });
            return resJson;
        }

        public async Task<JsonResponse> Remove(params string[] ids)
        {
            var resJson = await TryTransactionAsync(async () =>
            {
                await _orderRespository.UpdateAsync(ids,  async (e)=> {

                    await Task.Run(() =>
                   {
                       e.IsDelete = -1;
                   });
                });
                await _unitOfWork.SaveChangesAsync();
            });
           return resJson;
        }

        
    }
}

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
using MicroService.Data.Common;
using System.Data;
using System.Data.Common;

namespace MicroService.Application.Order
{
  
    public class OrderDetailAppService : ApplicationEnginee, IOrderDetailAppService
    {
        public IOrderDetailRespository _orderDetailRespository;
        private readonly IMapper _mapper;
        public IUnitOfWork _unitOfWork;

        public OrderDetailAppService(IOrderDetailRespository orderDetailRespository, IUnitOfWork unitOfWork,
          IMapper mapper)
        {
            _orderDetailRespository = orderDetailRespository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        /// <summary>
        ///异步验证
        /// </summary>
        private async Task DoValidationAsync(OrderDetail OrderDetail, string validatorType)
        {
            var OrderDetailValidator = new OrderDetailValidator();
            var validatorReresult = await OrderDetailValidator.DoValidateAsync(OrderDetail, validatorType);
            if (!validatorReresult.IsValid)
            {
                throw new DomainException(validatorReresult);
            }
        }

        /// <summary>
        ///异步验证
        /// </summary>
        private async Task DoValidationAsync(IEnumerable<OrderDetail> OrderDetails, string validatorType)
        {
            var OrderDetailValidator = new OrderDetailValidator();
            var domainException = new DomainException();
            foreach (var OrderDetail in OrderDetails)
            {
                var validatorReresult = await OrderDetailValidator.DoValidateAsync(OrderDetail, validatorType);
                if (!validatorReresult.IsValid)
                {
                    domainException.AddErrors(validatorReresult);
                }

            }

            if (domainException.ValidationErrors.ErrorItems.Any()) throw domainException;
        }
        public async Task<JsonResponse> CreateAsync(OrderDetailRequestDto OrderDetailRequestDto)
        {
         
            var resJson = await TryTransactionAsync(async () =>
              {
                  var OrderDetail = _mapper.Map<OrderDetailRequestDto, OrderDetail>(OrderDetailRequestDto);
                  await DoValidationAsync(OrderDetail, ValidatorTypeConstants.Create);
                  await _orderDetailRespository.InsertAsync(OrderDetail);

                  await _unitOfWork.SaveChangesAsync();
              });
            return resJson;
        }

        public async Task<JsonResponse> BatchCreateAsync(IList<OrderDetailRequestDto> OrderDetailRequestDtos)
        {
            var resJson = await TryTransactionAsync(async () =>
            {
                var entities = OrderDetailRequestDtos.MapToList<OrderDetailRequestDto, OrderDetail>();
                await DoValidationAsync(entities, ValidatorTypeConstants.Create);
                await _orderDetailRespository.BatchInsertAsync(entities);

                await _unitOfWork.SaveChangesAsync();
            });
            return resJson;
        }

   
    }
}

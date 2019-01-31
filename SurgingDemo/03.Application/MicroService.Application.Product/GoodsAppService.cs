using AutoMapper;
using MicroService.Application.Product.Validators;
using MicroService.Core.Data;
using MicroService.Data.Validation;
using MicroService.Entity.Product;
using MicroService.IApplication.Product;
using MicroService.IApplication.Product.Dto;
using MicroService.IRespository.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MicroService.Data.Extensions;
using System.Data;
using System.Data.Common;
using System.Reflection.Metadata;

namespace MicroService.Application.Product
{
    public class GoodsAppService : ApplicationEnginee, IGoodsAppService
    {

        public IGoodsRespository _personRespository;
        private readonly IMapper _mapper;
        public IUnitOfWork _unitOfWork;

        public GoodsAppService(IGoodsRespository personRespository, IUnitOfWork unitOfWork,
          IMapper mapper)
        {
            _personRespository = personRespository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        private async Task DoValidationAsync(Goods  goods, string validatorType)
        {
            var personValidator = new GoodsValidator();
            var validatorReresult = await personValidator.DoValidateAsync(goods, validatorType);
            if (!validatorReresult.IsValid)
            {
                throw new DomainException(validatorReresult);
            }
        }
        public async Task<JsonResponse> Create(GoodsRequestDto goodsRequestDto)
        {
            goodsRequestDto.Id = Guid.NewGuid().ToString();
            var resJson = await TryTransactionAsync(async () =>
            {
                var person = _mapper.Map<GoodsRequestDto, Goods>(goodsRequestDto);
                await DoValidationAsync(person, ValidatorTypeConstants.Create);
                await _personRespository.InsertAsync(person);

                await _unitOfWork.SaveChangesAsync();
            });
            return resJson;
        }
        public async Task<DataTable> GetList()
        {
            var dic = new Dictionary<string, object>() { };
            dic.Add("@price", 100);
            return await _personRespository.SqlQueryDataTable("select * from Goods where Price>@price",
             dic);
        }
    }
}

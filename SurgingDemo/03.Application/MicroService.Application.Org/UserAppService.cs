using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroService.Data.Ext;
using MicroService.IApplication.Org;
using MicroService.IRespository.Org;
using MicroService.Entity.Org;
using MicroService.IApplication.Org.Dto;
using MicroService.Core.Data;
using MicroService.Data.Validation;
using MicroService.Application.Org.Validators;
using MicroService.Data.Extensions;
using MicroService.Core;
using MicroService.Data.Common;

namespace MicroService.Application.Order
{
  
    public class UserAppService : ApplicationEnginee, IUserAppService
    {
        public IUserRespository _userRespository;
        private readonly IMapper _mapper;
        public IUnitOfWork _unitOfWork;

        public UserAppService(IUserRespository userRespository, IUnitOfWork unitOfWork,
          IMapper mapper)
        {
            _userRespository = userRespository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        private async Task DoValidationAsync(User person, string validatorType)
        {
            var personValidator = new UserValidator();
            var validatorReresult = await personValidator.DoValidateAsync(person, validatorType);
            if (!validatorReresult.IsValid)
            {
                throw new DomainException(validatorReresult);
            }
        }
        public async Task<JsonResponse> CreateAsync(UserRequestDto personRequestDto)
        {
            personRequestDto.Id = Guid.NewGuid().ToString();
            var resJson = await TryTransactionAsync(async () =>
              {
                  var person = _mapper.Map<UserRequestDto, User>(personRequestDto);
                  await DoValidationAsync(person, ValidatorTypeConstants.Create);
                  await _userRespository.InsertAsync(person);

                  await _unitOfWork.SaveChangesAsync();
              });
            return resJson;
        }
        public async Task<string> InsertAndGetId(UserRequestDto userRequestDto)
        {
            userRequestDto.Id = Guid.NewGuid().ToString();
            var person = _mapper.Map<UserRequestDto, User>(userRequestDto);
            await _userRespository.InsertAsync(person);
            var res= await _userRespository.InsertAndGetIdAsync(person);
            await _unitOfWork.SaveChangesAsync();
            return res;
        }
        public async Task<int> Test(int a)
        {
            return await Task.FromResult<int>(a + 1);
        }

        public async Task<IEnumerable<UserQueryDto>> GetAll()
        {
            var list = await _userRespository.GetAll().ToListAsync();

            return list.MapToList<User, UserQueryDto>();

        }

        public async Task<int> Modify(UserRequestDto personRequestDto)
        {
            return await Task.FromResult<int>(121);
        }

        public async Task<LoginUser> Login(UserRequestDto userRequestDto)
        {
          var result=  await _userRespository.GetAllListAsync(u => u.Name == userRequestDto.Name &&
             u.Password == userRequestDto.Password);
           var user= result.SingleOrDefault();

            if (user == null)
            {
                return await Task.FromResult<LoginUser>(null);
            }
            return await Task.FromResult(new LoginUser() { Id=user.Id, UserId=user.Id, Name=user.Name, RoleId=user.RoleId,
             PhoneCode=user.PhoneCode});

        }
    }
}

using FluentValidation;
using MicroService.Data.Validation;
using MicroService.Entity.Org;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.Application.Org.Validators
{
  public  class UserValidator: AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleSet(ValidatorTypeConstants.Create, () =>
            {
                BaseValidator();
            });
            RuleSet(ValidatorTypeConstants.Modify, () =>
            {
                BaseValidator();
            });

        }

        void BaseValidator()
        {
            RuleFor(per => per.Id).NotEmpty().WithMessage("Id不能为空");
            RuleFor(per => per.RoleId).NotEmpty().WithMessage("RoleId不能为空");

        }
    }

   
}

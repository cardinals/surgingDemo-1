using FluentValidation;
using MicroService.Data.Validation;
using MicroService.Entitiy.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.Application.Order.Validators
{
  public  class PersonValidator: AbstractValidator<Person>
    {
        public PersonValidator()
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

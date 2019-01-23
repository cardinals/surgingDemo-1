using FluentValidation;
using MicroService.Data.Validation;
using MicroService.Entity.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.Application.Order.Validators
{
  public  class OrderInfoValidator : AbstractValidator<OrderInfo>
    {
        public OrderInfoValidator()
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
            RuleFor(per => per.OrderNumber).NotEmpty().WithMessage("RoleId不能为空");

        }
    }

   
}

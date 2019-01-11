using FluentValidation;
using MicroService.Data.Validation;
using MicroService.Entity.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.Application.Product.Validators
{
  public  class GoodsValidator: AbstractValidator<Goods>
    {
        public GoodsValidator()
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

        }
    }

   
}

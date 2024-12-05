using FluentValidation;
using MyBlogNight.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogNight.BusinessLayer.ValidattionRules.CategoryValidationRules
{
    public class CreateCategoryValidator:AbstractValidator<Category>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("The CategoryName field is required.!!!");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Please enter minimum 3 character");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Category Name Can Be Max 20 Character");
        }
    }
}

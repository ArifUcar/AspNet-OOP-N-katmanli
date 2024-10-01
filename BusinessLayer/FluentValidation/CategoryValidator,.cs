using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class CategoryValidator_ : AbstractValidator<Category>
    {
        public CategoryValidator_()
        {
            RuleFor(x=>x.CategoryName).NotEmpty().WithMessage("Kategori alanı boş geçilemez");
        }
    }
}

using Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori Adı Boş Bırakılamaz.");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Kategori Adı 2 Karakterden az olmamalıdır.");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Kategori Adı 100 Karakteri Geçmemelidir.");
        }
    }
}

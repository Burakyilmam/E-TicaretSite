using Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x=>x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Bırakılamaz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola Boş Bırakılamaz.");
            RuleFor(x => x.UserName).MaximumLength(100).WithMessage("Kullanıcı Adı 100 Karakteri Geçmemelidir.");
            RuleFor(x => x.Password).MaximumLength(100).WithMessage("Parola 100 Karakteri Geçmemelidir.");
        }
    }
}

using DataTransferObject.DataTransferObjects.UserDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.UserValidationRule
{
    public class UserRegisterValidator : AbstractValidator<UserRegisterDto>
    {
        public UserRegisterValidator()
        {
         RuleFor(x => x.Name).NotEmpty().WithMessage("Ad Alanı Boş Bırakılamaz.");
         RuleFor(x => x.Name).MaximumLength(50).WithMessage("En Fazla 50 Karakter Olmalıdır.");
         RuleFor(x => x.Name).MinimumLength(3).WithMessage("En az 3 Karakter Olmalıdır.");
         RuleFor(x => x.SurName).NotEmpty().WithMessage("Soyad Alanı Boş Bırakılamaz.");
         RuleFor(x => x.Email).NotEmpty().WithMessage("Email Alanı Boş Bırakılamaz.");
         RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen Geçerli Bir Mail Adresi Giriniz.");
         RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Alanı Boş Bırakılamaz.");
         RuleFor(x => x.Password).NotEmpty().WithMessage("Parola Alanı Boş Bırakılamaz.");
         RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Parola Tekrar Alanı Boş Bırakılamaz");
         RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Parolalar Uyuşmuyor.");

        }
    }
}

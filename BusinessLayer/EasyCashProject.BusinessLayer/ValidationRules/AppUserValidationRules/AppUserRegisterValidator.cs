using EasyCashProject.DtoLayer.Dtos.AppUserDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.BusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator:AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Boş Geçilemez!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail Boş Geçilemez!");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre Boş Geçilemez!");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre Tekrarı Boş Geçilemez!");
            RuleFor(x => x.ConfirmPassword).Equal(y=>y.Password).WithMessage("Şifreler Eşleşmiyor");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli Bir mail adresi giriniz!");
        }
    }
}

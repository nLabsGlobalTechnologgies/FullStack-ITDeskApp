using FluentValidation;
using ITDeskServer.WebAPI.DTOs;

namespace ITDeskServer.WebAPI.Validators
{
    public sealed class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            // Kullanıcı adı veya e-posta alanı boş olmamalı ve null olmamalıdır.
            RuleFor(p => p.UserNameOrEmail).NotEmpty().WithMessage("Geçerli bir kullanıcı adı ya da mail adresi girin");
            RuleFor(p => p.UserNameOrEmail).NotNull().WithMessage("Geçerli bir kullanıcı adı ya da mail adresi girin");
            // Kullanıcı adı veya e-posta alanı en az 3 karakter içermelidir.
            RuleFor(p => p.UserNameOrEmail).MinimumLength(3).WithMessage("Kullanıcı adı|mail adresi alanı en az 3 karakter olmalıdır");

            // Şifre alanı boş olmamalı ve null olmamalıdır.
            RuleFor(p => p.Password).NotEmpty().WithMessage("Geçerli bir şifre girin");
            RuleFor(p => p.Password).NotNull().WithMessage("Geçerli bir şifre girin");

            // Şifre en az bir büyük harf içermelidir.
            RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Şifreniz en az 1 adet büyük harf içermelidir");

            // Şifre en az bir küçük harf içermelidir.
            RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Şifreniz en az 1 adet küçük harf içermelidir");

            // Şifre en az bir rakam içermelidir.
            RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Şifreniz en az 1 adet rakam içermelidir");

            // Şifre en az bir özel karakter içermelidir.
            RuleFor(p => p.Password).Matches("[^a-zA-Z0-9]").WithMessage("Şifreniz en az 1 adet özel karakter içermelidir");
        }
    }
}

using FluentValidation;
using ITDeskServer.WebAPI.DTOs;

namespace ITDeskServer.WebAPI.Validators
{
    public sealed class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            // İsim alanı boş olmamalı ve null olmamalıdır.
            RuleFor(p => p.Name).NotEmpty().WithMessage("Geçerli bir isim girin!");
            RuleFor(p => p.Name).NotNull().WithMessage("Geçerli bir isim girin!");
            // İsim alanı en az 3 karakter içermelidir.
            RuleFor(p => p.Name).MinimumLength(3).WithMessage("İsim alanı min 3 karakter olmalıdır!");

            // Soyisim alanı boş olmamalı ve null olmamalıdır.
            RuleFor(p => p.LastName).NotEmpty().WithMessage("Geçerli bir soyisim girin!");
            RuleFor(p => p.LastName).NotNull().WithMessage("Geçerli bir soyisim girin!");
            // Soyisim alanı en az 3 karakter içermelidir.
            RuleFor(p => p.LastName).MinimumLength(3).WithMessage("Soyisim alanı min 3 karakter olmalıdır!");

            // Kullanıcı adı alanı boş olmamalı ve null olmamalıdır.
            RuleFor(p => p.UserName).NotEmpty().WithMessage("Geçerli bir kullanıcı adı girin!");
            RuleFor(p => p.UserName).NotNull().WithMessage("Geçerli bir kullanıcı adı girin!");
            // Kullanıcı adı alanı en az 3 karakter içermelidir.
            RuleFor(p => p.UserName).MinimumLength(3).WithMessage("Kullanıcı adı alanı min 3 karakter olmalıdır!");

            // E-posta alanı boş olmamalı, null olmamalı ve geçerli bir e-posta formatında olmalıdır.
            RuleFor(p => p.Email).NotEmpty().WithMessage("Geçerli bir email girin!");
            RuleFor(p => p.Email).NotNull().WithMessage("Geçerli bir email girin!");
            RuleFor(p => p.Email).EmailAddress().WithMessage("Geçerli bir email girin!");
            // E-posta alanı en az 3 karakter içermelidir.
            RuleFor(p => p.Email).MinimumLength(3).WithMessage("Email alanı min 3 karakter olmalıdır!");

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

using ITDeskServer.WebAPI.Context;
using ITDeskServer.WebAPI.DTOs;
using ITDeskServer.WebAPI.Models;
using ITDeskServer.WebAPI.Validators;

namespace ITDeskServer.WebAPI.Services
{
    public sealed class AuthService
    {
        private readonly AppDbContext _context;
        private readonly JwtProvider _jwtProvider;

        // AuthService sınıfını yapılandırmak için JwtProvider ve AppDbContext bağımlılıkları enjekte edilir.
        public AuthService(JwtProvider jwtProvider, AppDbContext context)
        {
            _jwtProvider = jwtProvider;
            _context = context;
        }

        // Yeni bir kullanıcı kaydı oluşturur.
        public void Register(RegisterDto request)
        {
            #region Validation Check
            CheckValidation(request);
            #endregion

            #region UserName Or Email Exists Control
            CheckUserNameOrEmailIsExists(request);
            #endregion

            #region Create Password
            byte[] passwordSalt, passwordHash;
            PasswordService.CreatePassword(request.Password, out passwordSalt, out passwordHash);
            #endregion

            #region Create User Object
            User user = CreateUser(request, passwordSalt, passwordHash);
            #endregion

            #region Save Object To Database
            CreatingUserToDatabase(user);
            #endregion
        }

        // Kullanıcının giriş yapmasını sağlar ve bir JWT oluşturup döndürür.
        public string Login(LoginDto request)
        {
            #region Check Validation
            CheckValidation(request);
            #endregion

            // UserName Or Email Control One Control Mechanisma
            User? user = _context.Users.SingleOrDefault(p => p.UserName == request.UserNameOrEmail || p.Email == request.UserNameOrEmail);
            if (user is null)
            {
                throw new ArgumentException("Kullanıcı bulunamadı!");
            }

            var checkPasswordIsTrue = PasswordService.CheckPassword(user, request.Password);
            if (!checkPasswordIsTrue)
            {
                throw new ArgumentException("Şifre yanlış!");
            }
            return _jwtProvider.CreateToken(user, request.RememberMe);
        }

        // Verilen kullanıcı bilgileri ile yeni bir User nesnesi oluşturur.
        private User CreateUser(RegisterDto request, byte[] passwordSalt, byte[] passwordHash)
        {
            return new()
            {
                Name = request.Name,
                LastName = request.LastName,
                UserName = request.UserName,
                Email = request.Email,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash
            };
        }

        // Yeni bir kullanıcıyı veritabanına ekler.
        private void CreatingUserToDatabase(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        // Kullanıcı adı veya e-posta adresinin daha önce kullanılıp kullanılmadığını kontrol eder.
        private void CheckUserNameOrEmailIsExists(RegisterDto request)
        {
            var CheckUserNameIsExists = _context.Users.Any(p => p.UserName == request.UserName);
            if (CheckUserNameIsExists)
            {
                throw new ArgumentException("Kullanıcı adı daha önce kullanılmış!");
            }
            var CheckEmailIsExists = _context.Users.Any(p => p.Email == request.Email);
            if (CheckEmailIsExists)
            {
                throw new ArgumentException("Email daha önce kullanılmış!");
            }
        }

        // FluentValidation ile gelen verilerin doğruluğunu kontrol eder.
        private void CheckValidation<T>(T request) where T : class
        {
            string validatorName = typeof(T).FullName + "Validator";
            Type? validatorType = Type.GetType(validatorName);

            if (validatorType == null)
            {
                throw new ArgumentException("Validator class not found for " + typeof(T).FullName);
            }
            var validatorInstance = Activator.CreateInstance(validatorType);
            var validateMethod = validatorType.GetMethod("Validate");

            if (validateMethod == null)
            {
                throw new ArgumentException("Validate method not found for " + validatorName);
            }

            var result = validateMethod.Invoke(validatorInstance, new object[] { request });
            if (result is FluentValidation.Results.ValidationResult validationResult && !validationResult.IsValid)
            {
                throw new ArgumentException(validationResult.Errors[0].ErrorMessage);
            }
        }

        // RegisterDto tipindeki verilerin doğruluğunu kontrol eder.
        private void CheckValidation(RegisterDto request)
        {
            var validator = new RegisterDtoValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                throw new ArgumentException(result.Errors[0].ErrorMessage);
            }
        }

        // LoginDto tipindeki verilerin doğruluğunu kontrol eder.
        private void CheckValidation(LoginDto request)
        {
            var validator = new LoginDtoValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                throw new ArgumentException(result.Errors[0].ErrorMessage);
            }
        }
    }
}

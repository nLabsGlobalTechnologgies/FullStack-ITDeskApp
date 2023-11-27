using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ITDeskServer.WebAPI.Options
{
    // JwtSetupOptions sınıfı, JwtBearerOptions sınıfını yapılandırmak için kullanılır.
    public sealed class JwtSetupOptions : IPostConfigureOptions<JwtBearerOptions>
    {
        private readonly Jwt _jwt;

        // JwtSetupOptions sınıfını yapılandırmak için Jwt seçeneklerini enjekte eder.
        public JwtSetupOptions(IOptions<Jwt> jwt)
        {
            _jwt = jwt.Value;
        }

        // IPostConfigureOptions arayüzünün yöntemini uygular ve JwtBearerOptions nesnesini yapılandırır.
        public void PostConfigure(string? name, JwtBearerOptions options)
        {
            // JWT token doğrulama parametrelerini belirler.

            // Issuer (imzalayan) alanını doğrula.
            options.TokenValidationParameters.ValidateIssuer = true;

            // Audience (hedef) alanını doğrula.
            options.TokenValidationParameters.ValidateAudience = true;

            // IssuerSigningKey (imza anahtarı) alanını doğrula.
            options.TokenValidationParameters.ValidateIssuerSigningKey = true;

            // Token'ın geçerlilik süresini doğrula.
            options.TokenValidationParameters.ValidateLifetime = true;

            // Geçerli Issuer (imzalayan) değerini belirler.
            options.TokenValidationParameters.ValidIssuer = _jwt.Issuer;

            // Geçerli Audience (hedef) değerini belirler.
            options.TokenValidationParameters.ValidAudience = _jwt.Audience;

            // Token'ı imzalamak ve doğrulamak için kullanılacak gizli anahtarı belirler.
            options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.SecretKey));
        }
    }
}

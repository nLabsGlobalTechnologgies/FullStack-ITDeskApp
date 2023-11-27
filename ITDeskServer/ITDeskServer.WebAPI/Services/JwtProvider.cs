using ITDeskServer.WebAPI.Models;
using ITDeskServer.WebAPI.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ITDeskServer.WebAPI.Services
{
    public sealed class JwtProvider
    {
        private readonly Jwt _jwt;

        // JwtProvider sınıfını yapılandırmak için Jwt seçeneklerini alır.
        public JwtProvider(IOptions<Jwt> jwt)
        {
            _jwt = jwt.Value;
        }

        // Verilen kullanıcı bilgileri ve "rememberMe" parametresiyle bir JWT oluşturur.
        public string CreateToken(User user, bool rememberMe)
        {
            // JWT içinde yer alacak id, kullanıcı adı ve e-posta gibi talepleri içeren bir liste oluşturulur.
            List<Claim> claims = new()
            {
                new Claim("UserId", user.Id.ToString()),         // Örneğin, kullanıcı ID'si
                new Claim("UserName", user.Name.ToString()),     // Örneğin, kullanıcı adı
                new Claim(ClaimTypes.Email, user.Email)          // Örneğin, e-posta adresi
            };

            // Token'ın geçerlilik süresi belirlenir; "rememberMe" true ise 1 ay, false ise 1 gün.
            DateTime expires = rememberMe ? DateTime.Now.AddMonths(1) : DateTime.Now.AddDays(1);

            // SecretKey, SymmetricSecurityKey tipine dönüştürülür ve bu anahtar ile bir SigningCredentials oluşturulur.
            string secretKey = _jwt.SecretKey;
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha512);

            // JWT token'ı oluşturulur, içeriği belirlenen issuer, audience, talepler ve diğer bilgilerle doldurulur.
            JwtSecurityToken securityToken = new(
                issuer: _jwt.Issuer,          // Uygulamanın sahibi (issuer)
                audience: _jwt.Audience,      // Uygulamayı kullanacak kişi (audience)
                claims: claims,               // JWT içinde yer alacak talepler (claims)
                notBefore: DateTime.Now,      // Token'ın ne zaman geçerli olmaya başlayacağı
                expires: expires,             // Token'ın ne zaman geçerli olmayacağı
                signingCredentials: credentials
            );

            // JWT token'ını yazma işlemi gerçekleştirilir ve elde edilen token döndürülür.
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            string token = handler.WriteToken(securityToken);
            return token;
        }
    }
}

using ITDeskServer.WebAPI.Models;
using System.Security.Cryptography;
using System.Text;

namespace ITDeskServer.WebAPI.Services
{
    public static class PasswordService
    {
        // Şifre oluşturmak için kullanılır. Verilen şifre üzerinden bir tuz (salt) oluşturulur
        // ve bu tuz ile birlikte şifrenin karma (hash) değeri hesaplanır.
        public static void CreatePassword(string password, out byte[] passwordSalt, out byte[] passwordHash)
        {
            // HMACSHA512 kullanılır, bu da SHA-512 algoritması temel alınarak özel bir anahtar kullanarak
            // mesaj doğrulama kodu (HMAC) üretir.
            using (var hmac = new HMACSHA512())
            {
                // Oluşturulan HMACSHA512'nin anahtarı tuz olarak kullanılır.
                passwordSalt = hmac.Key;
                // Şifre, UTF-8 karakter kodlaması kullanılarak byte dizisine çevrilir ve ardından HMACSHA512
                // kullanılarak karma (hash) değeri hesaplanır.
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        // Kullanıcının şifresini kontrol etmek için kullanılır. Kullanıcının kaydedilmiş tuzunu kullanarak
        // verilen şifrenin doğruluğunu kontrol eder.
        public static bool CheckPassword(User user, string password)
        {
            // Kullanıcının kaydedilmiş tuzunu kullanarak yeni bir HMACSHA512 örneği oluşturulur.
            using (var hmac = new HMACSHA512(user.PasswordSalt))
            {
                // Verilen şifrenin HMACSHA512 ile hesaplanan karma (hash) değeri alınır.
                var newPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                // Hesaplanan yeni şifre ile kaydedilmiş şifre arasında karşılaştırma yapılır.
                // Her iki şifre de aynı olmalıdır, aksi takdirde şifre doğrulanmaz.
                for (int i = 0; i < user.PasswordHash.Length; i++)
                {
                    if (newPassword[i] != user.PasswordHash[i])
                    {
                        return false;
                    }
                }
                // Tüm karşılaştırmalar başarılıysa şifre doğrulanmıştır.
                return true;
            }
        }
    }
}

namespace ITDeskServer.WebAPI.DTOs
{
    // RegisterDto, kullanıcı kaydı için kullanılan veri transfer nesnesini temsil eden bir kayıt (record) türüdür.
    public sealed record RegisterDto(
        string Name, // Kullanıcının ismi
        string LastName, // Kullanıcının soyismi
        string UserName, // Kullanıcı adı
        string Email, // Kullanıcının e-posta adresi
        string Password, // Kullanıcı şifresi
        bool RememberMe // "Beni Hatırla" seçeneği
    );
}

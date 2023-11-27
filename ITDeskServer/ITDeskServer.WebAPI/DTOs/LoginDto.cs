namespace ITDeskServer.WebAPI.DTOs
{
    // LoginDto, kullanıcı girişi için kullanılan veri transfer nesnesini temsil eden bir kayıt (record) türüdür.
    public sealed record LoginDto(
        string UserNameOrEmail, // Kullanıcı adı veya e-posta adresi
        string Password, // Kullanıcı şifresi
        bool RememberMe // "Beni Hatırla" seçeneği
    );
}

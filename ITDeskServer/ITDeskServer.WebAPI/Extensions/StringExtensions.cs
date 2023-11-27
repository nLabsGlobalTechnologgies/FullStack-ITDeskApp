namespace ITDeskServer.WebAPI.Extensions
{
    // StringExtensions sınıfı, string türü üzerinde genişletilmiş yöntemleri içerir.
    public static class StringExtensions
    {
        // Bir dize değerinin null, boş veya yalnızca boşluklardan oluşup oluşmadığını kontrol eden genişletilmiş yöntem.
        public static bool IsNullEmptyOrWhiteSpace(this string value)
        {
            // Dize değeri null ise veya yalnızca boşluklardan oluşuyorsa true, aksi takdirde false döndürür.
            return value == null || string.IsNullOrWhiteSpace(value);
        }
    }
}

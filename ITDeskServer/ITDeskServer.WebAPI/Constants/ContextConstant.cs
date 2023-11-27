namespace ITDeskServer.WebAPI.Constants
{
    // ContextConstant sınıfı, uygulamanın veritabanına bağlanmak için kullanılan bağlantı dizesini içerir.
    public static class ContextConstant
    {
        // Bağlantı dizesi, uygulamanın veritabanına bağlanmak için kullanılır.
        public static string ConnectionString = "Data Source=SERVER;Initial Catalog=IEAITDeskDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
    }
}

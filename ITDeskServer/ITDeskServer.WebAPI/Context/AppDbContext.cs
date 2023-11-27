using ITDeskServer.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ITDeskServer.WebAPI.Context
{
    // AppDbContext sınıfı, Entity Framework Core'u kullanarak veritabanı işlemlerini gerçekleştirmek için kullanılan veritabanı bağlamını temsil eder.
    public sealed class AppDbContext : DbContext
    {
        // AppDbContext sınıfını oluşturan yapıcı metod.
        public AppDbContext(DbContextOptions options) : base(options)
        {
            // DbContextOptions nesnesi, veritabanı bağlamının yapılandırma seçeneklerini içerir.
        }

        // Kullanıcıları temsil eden DbSet özelliği.
        public DbSet<User> Users { get; set; }

        // Biletleri temsil eden DbSet özelliği.
        public DbSet<Ticket> Tickets { get; set; }

        // Kullanıcı bilet ilişkilerini temsil eden DbSet özelliği.
        public DbSet<UserTicket> UserTickets { get; set; }
    }
}

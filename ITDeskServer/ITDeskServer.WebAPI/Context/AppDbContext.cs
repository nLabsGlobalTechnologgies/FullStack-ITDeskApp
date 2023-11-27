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

        // Kullanıcılar veritabanı tablosunu temsil eden DbSet.
        public DbSet<User> Users { get; set; }

        // Kullanıcı rolleri veritabanı tablosunu temsil eden DbSet.
        public DbSet<Role> Roles { get; set; }

        // Kullanıcı rolleri ve izinleri veritabanı tablosunu temsil eden DbSet.
        public DbSet<UserRolePermission> UserRolePermissions { get; set; }

        // Destek talepleri veritabanı tablosunu temsil eden DbSet.
        public DbSet<Ticket> Tickets { get; set; }

        // Destek taleplerine atanmış personelleri tutan veritabanı tablosunu temsil eden DbSet.
        public DbSet<TicketPersonnel> TicketPersonnels { get; set; }

        // Destek taleplerini destekleyenleri tutan veritabanı tablosunu temsil eden DbSet.
        public DbSet<TicketResponse> TicketResponses { get; set; }

    }
}

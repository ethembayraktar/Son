
using Microsoft.EntityFrameworkCore;
using Son.Models; // Modelinizin bulunduğu namespace'i burada kullanın

namespace Son.Models
{
    public class SonDbContext : DbContext
    {
        // DbContext için constructor oluşturun
        public SonDbContext(DbContextOptions<SonDbContext> options)
            : base(options)
        {
        }

        // 'Greetings' tablosunu temsil eden DbSet özelliğini ekleyin
        public DbSet<Greeting> Greetings { get; set; }

        // Gerekirse, burada veritabanı şemasını daha da detaylandırmak için 
        // OnModelCreating metodunu override edebilirsiniz.
        // Örnek:
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     // Model yapılandırmaları
        // }
        
    }
}
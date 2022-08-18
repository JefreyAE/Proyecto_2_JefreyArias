using API_Proyecto_2.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Proyecto_2.DataContext
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Dispatcher> Dispatchers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}

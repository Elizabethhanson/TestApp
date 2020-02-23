using Microsoft.EntityFrameworkCore;
using Npgsql;
using TestAppService.Models;

namespace TestAppService.Services
{
    public class DataContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DataContext()
        {

        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = $"host=localhost;port=5432;database=TestDatabase;user id=accessuser;password=testpassword";
                var builder = new NpgsqlConnectionStringBuilder(connectionString);
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasKey(x => x.BookId);
        }
    }
}

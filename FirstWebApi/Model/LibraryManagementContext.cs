using Microsoft.EntityFrameworkCore;

namespace FirstWebApi.Model
{
    public class LibraryManagementContext : DbContext
    {
        public LibraryManagementContext() : base()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=LibraryManagement;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<Book> Books { get; set; }

    }
}

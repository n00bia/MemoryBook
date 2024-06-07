using MemoryBook.Models;
using Microsoft.EntityFrameworkCore;

namespace MemoryBook.Data
{
    public class MemoryBookContext : DbContext
    {
        public MemoryBookContext(DbContextOptions<MemoryBookContext> options, IConfiguration configuration)
            :base(options)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        public DbSet<QueryModel> Queries { get; set; }
        public DbSet<TagModel> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("Default")); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            var query = modelBuilder.Entity<QueryModel>();

            query.ToTable("query");
            query.HasKey(x => x.Id);
            query.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            query.Property(x => x.Body).HasColumnName("body").HasColumnType("text");

        }
    }

}

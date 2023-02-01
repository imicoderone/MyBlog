using Microsoft.EntityFrameworkCore;
using MyBlog.Application.Abstractions;
using MyBlog.Domain.Entities;
using MyBlog.Infrastructure.Persistence.EntityTypeConfigurations;

namespace MyBlog.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PostEntityTypeConfiguration());
        }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using GigHub.Models;

namespace GigHub.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Genre>().HasData(
               new Genre { Id=1,Name="Jazz"} ,
               new Genre { Id=2,Name="Blues"},
               new Genre { Id=3,Name="Rock"},
               new Genre { Id=4,Name="Country"}
                );
            base.OnModelCreating(builder);
        }
    }
    


}
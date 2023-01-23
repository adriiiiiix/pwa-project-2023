using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PWA.Api.Data.Models;

namespace PWA.Api.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) { }

        public DbSet<Cladire> Cladiri { get; set; }

        public DbSet<Imagine> Imagini { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            string userGuid = Guid.NewGuid().ToString(), roleGuid = Guid.NewGuid().ToString();
            var hasher = new PasswordHasher<AppUser>();

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = roleGuid,
                Name = "Admin",
                NormalizedName = "admin"
            },
            new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "User",
                NormalizedName = "user"
            });

            builder.Entity<AppUser>().HasData(new AppUser
            {
                Id = userGuid,
                UserName = "admin@adminEmail.com",
                NormalizedUserName = "ADMIN@ADMINEMAIL.COM",
                Email = "admin@adminEmail.com",
                NormalizedEmail = "ADMIN@ADMINEMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Password1!"),
                SecurityStamp = String.Empty,
                FirstName = "Admin",
                LastName = "Admin"
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleGuid,
                UserId = userGuid,
            });
        }
    }
}

using System;
using app.domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace app.repository
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
            
        }

        public DbSet<AppUser> appUsers { get; set; }
        public DbSet<Accounts> accounts { get; set; }
        public DbSet<Admin> admin { get; set; }
        public DbSet<Cards> cards { get; set; }
        public DbSet<Destination> destination { get; set; }
        public DbSet<Issue> issue { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            string ADMIN_ID = "02174cf0–9412–4cfe - afbf - 59f706d72cf6"; //Guid
            //create user
            var appUser = new AppUser
            {
                Id = ADMIN_ID,
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                FirstName = "admin",
                LastName = "admin",
                UserName = "admin",
                Role = "Admin",
                NormalizedUserName = "ADMIN",
                NormalizedEmail = "ADMIN@GMAIL.COM"
            };
            //set user password / turns a string password into a hash password
            PasswordHasher<AppUser> ph = new PasswordHasher<AppUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "password");
            //seed user
            builder.Entity<AppUser>().HasData(appUser);
        }
    }
}

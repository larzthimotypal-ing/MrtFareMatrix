using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using app.domain;


using Microsoft.EntityFrameworkCore;

namespace app.repository
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
            
        }

        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Cards> Cards { get; set; }
        public DbSet<Destination> Destination { get; set; }
        public DbSet<Issue> Issue { get; set; }
        
    }
}

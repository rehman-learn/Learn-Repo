using System;
using TaskManagementDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskManagementDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserTask> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

using Backend_Task03.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Backend_Task03.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}

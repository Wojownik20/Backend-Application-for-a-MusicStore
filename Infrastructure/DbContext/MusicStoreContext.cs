using Microsoft.EntityFrameworkCore;
using LeverX.Domain.Models;

namespace LeverX.Infrastructure.DbContext
{
    public class MusicStoreContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public MusicStoreContext(DbContextOptions<MusicStoreContext> options) : base(options)
        {
        }
    }
}
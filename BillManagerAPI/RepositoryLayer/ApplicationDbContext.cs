using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure one-to-many relationship between User and ElectricityBill

            var user = modelBuilder.Entity<User>();
            var electricityBill = modelBuilder.Entity<ElectricityBill>();

            user.HasKey(a => a.UserId);
            electricityBill.HasKey(a => a.BillId);

            user
                .HasMany(c => c.ElectricityBills)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            electricityBill
                .Property(e => e.PricePerUnit)
                .HasColumnType("decimal(18, 2)");

            electricityBill
                .Property(e => e.AfterDueDateCharges)
                .HasColumnType("decimal(18, 2)");

        }

        public DbSet<User> Users { get; set; }
        public DbSet<ElectricityBill> ElectricityBills { get; set; }
    }
}

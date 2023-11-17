using BoulderLock.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderLock.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<PassStorEntity> Passes { get; set; }
        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>()
                .HasOne(u => u.User)
                .WithMany(a => a.UserAccounts)
                .HasForeignKey(u => u.userId);

            modelBuilder.Entity<UserAccount>()
                .HasOne(u => u.Account)
                .WithMany(a => a.UserAccounts)
                .HasForeignKey(u => u.accountId);

            modelBuilder.Entity<PassStorEntity>()
                .HasOne(n => n.Owner)
                .WithMany(p => p.Passes)
                .HasForeignKey(n => n.userId);
        }
    }    
}

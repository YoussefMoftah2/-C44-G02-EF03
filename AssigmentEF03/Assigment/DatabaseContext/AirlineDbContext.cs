using Assigment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;


namespace testAss.DatabaseContext
{
    public class AirlineDbContext : DbContext
    {
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<AirCraft> AirCrafts { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Route> Routes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Airline)
                .WithMany(a => a.Employees)
                .HasForeignKey(e => e.AirlineId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Airline)
                .WithMany(a => a.Transactions)
                .HasForeignKey(t => t.AirlineId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AirCraft>()
                .HasOne(ac => ac.Airline)
                .WithMany(a => a.AirCrafts)
                .HasForeignKey(ac => ac.AirlineId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Crew>()
                .HasOne(c => c.AirCraft)
                .WithOne(ac => ac.Crew)
                .HasForeignKey<Crew>(c => c.AirCraftId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Route>()
                .HasOne(r => r.AirCraft)
                .WithMany(ac => ac.Routes)
                .HasForeignKey(r => r.AirCraftId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=AirlineDB;Trusted_Connection=True;");
        }
    }
}
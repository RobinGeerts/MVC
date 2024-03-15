using HondenRescue.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Emit;

namespace HondenRescue.Data
{
    public class HRContext : DbContext
    {
        public HRContext(DbContextOptions<HRContext> options) : base(options) { }

        public DbSet<Hond> Honden{ get; set;} = null!;
        public DbSet<Eigenaar> Eigenaren { get; set; } = null!;
        public DbSet<HondEigenaar> HondEigenaren { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hond>().ToTable("Hond");
            modelBuilder.Entity<Eigenaar>().ToTable("Eigenaar");
            modelBuilder.Entity<HondEigenaar>().ToTable("HondEigenaar");

            /////// Many to many /////////
            modelBuilder.Entity<HondEigenaar>()
                .HasOne(p => p.Eigenaar)
                .WithMany(x => x.HondEigenaren)
                .HasForeignKey(y => y.EigenaarId)
                .IsRequired();

            modelBuilder.Entity<HondEigenaar>()
               .HasOne(p => p.Hond)
               .WithMany(x => x.HondEigenaren)
               .HasForeignKey(y => y.HondId)
               .IsRequired();

        }
    }
}
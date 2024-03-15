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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hond>().ToTable("Hond");
        }
    }
}
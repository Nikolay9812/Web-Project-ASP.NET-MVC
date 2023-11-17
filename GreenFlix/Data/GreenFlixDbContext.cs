using GreenFlix.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenFlix.Data
{
    public class GreenFlixDbContext : IdentityDbContext<User>
    {
        public GreenFlixDbContext(DbContextOptions<GreenFlixDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; init; }

        public DbSet<Category> Categories { get; init; }

        public DbSet<Provaider> Provaiders { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Movie>()
                .HasOne(m => m.Category)
                .WithMany(m => m.Movies)
                .HasForeignKey(m => m.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Movie>()
                .HasOne(m => m.Provaider)
                .WithMany(m => m.Movies)
                .HasForeignKey(m => m.ProvaiderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Provaider>()
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<Provaider>(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}

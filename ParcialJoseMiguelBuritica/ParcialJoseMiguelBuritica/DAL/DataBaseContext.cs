﻿using Microsoft.EntityFrameworkCore;
using ParcialJoseMiguelBuritica.DAL.Entities;

namespace ParcialJoseMiguelBuritica.DAL
{
    public class DataBaseContext : DbContext 
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ticket>().HasIndex(t => t.Id).IsUnique();

        }
    }
}

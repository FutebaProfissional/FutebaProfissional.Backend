using FutebaProfissional.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace FutebaProfissional.Repositories.Context
{
    public class FutebaDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public FutebaDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Group> Groups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = FutebaDBTest; Trusted_Connection = True");

            //optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //foreach (var property in modelBuilder.Model.GetEntityTypes()
            //    .SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(string)))
            //{
            //    if (property.GetMaxLength() == null) property.SetMaxLength(255);
            //}

            //foreach (var property in modelBuilder.Model.GetEntityTypes()
            //    .SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(decimal)))
            //{
            //    if (property.GetColumnType() == null) property.SetColumnType("decimal(18, 4)");
            //}

            // modelBuilder.ApplyConfiguration(new ClienteConfig());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FutebaDbContext).Assembly);

            modelBuilder.Entity<Group>().HasData(new Group { Id = Guid.NewGuid(), Name = "Test Group" });
            
        }

        internal string GetConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }
    }
}

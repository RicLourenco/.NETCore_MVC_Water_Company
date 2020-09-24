namespace NETCore_MVC_Water_Company.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using NETCore_MVC_Water_Company.Web.Data.Entities;
    using Org.BouncyCastle.Asn1.Mozilla;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Bill> Bills { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Document> Documents { get; set; }

        public DbSet<Step> Steps { get; set; }

        public DbSet<WaterMeter> WaterMeters { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            //Disables cascade deleting
            var cascadeFKs = modelbuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach(var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Cascade;
            }

            modelbuilder.Entity<User>()
                .HasIndex(u => new { u.DocumentNumber, u.TIN , u.IBAN})
                .IsUnique();

            modelbuilder.Entity<WaterMeter>()
                .HasIndex(w => new { w.Address, w.ZipCode })
                .IsUnique();

            modelbuilder.Entity<Step>()
                .HasIndex(s => s.MinimumConsumption)
                .IsUnique();

            //Enable cascade deleting on the waterMeter => bills
            modelbuilder.Entity<WaterMeter>()
                .HasMany(w => w.Bills)
                .WithOne(b => b.WaterMeter)
                .HasForeignKey(b => b.WaterMeterId)
                .OnDelete(DeleteBehavior.Cascade);

            //Enable cascade deleting on user => watermeters
            modelbuilder.Entity<User>()
                .HasMany(u => u.WaterMeters)
                .WithOne(w => w.User)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelbuilder);
        }
    }
}

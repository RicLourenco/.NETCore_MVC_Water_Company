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

        //TODO: create necessary dbsets after finishing entities
        public DbSet<Bill> Bills { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Step> Steps { get; set; }

        public DbSet<WaterMeter> WaterMeters { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            /*
            modelbuilder.Entity<Document>()
                .HasIndex(d => d.DocumentNumber)
                .IsUnique();
            */

            ///Disables cascade deleting
            var cascadeFKs = modelbuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach(var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelbuilder);
        }
    }
}

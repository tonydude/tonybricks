using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bricks.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;



namespace Bricks.DAL
{
    public class AgencyContext : DbContext
    {
        public AgencyContext() : base ("DefaultConnection")
        {
        }
        

        public DbSet<User> Users { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Bid> Bids { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Danger code here.  
            modelBuilder.Entity<User>()
                                .HasMany(u => u.Properties)
                                .WithRequired()
                                .HasForeignKey(p => p.UserID)
                                .WillCascadeOnDelete(false);

             base.OnModelCreating(modelBuilder);
            
        }
    }
}


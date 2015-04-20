using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SearchVenues.Models
{
    public class VenueHireContext : DbContext
    {
        public VenueHireContext()
            : base("VenueHire")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<VenueHireContext, SearchVenues.Migrations.Configuration>("VenueHire"));
        }
        public DbSet<Models.State> State { get; set; }
        public DbSet<Models.City> City { get; set; }
        public DbSet<Models.CateringPackages> CateringPackages { get; set; }
        public DbSet<Models.Supplier> Supplier { get; set; }
        public DbSet<Models.SupplierSlots> SupplierSlots { get; set; }
        public DbSet<Models.SupplierBookings> SupplierBookings { get; set; }
        public DbSet<Models.Area> Area { get; set; }
        public DbSet<Models.Address> Address { get; set; }
        public DbSet<Models.SuplierReviews> SupplierReviews { get; set; }
        public DbSet<Models.Facilities> Facilities { get; set; }
        public DbSet<Models.VenueFacilities> VenueFacilities { get; set; }
        public DbSet<Models.Venue> Venue { get; set; }
        public DbSet<Models.VenueReviews> VenueReviews { get; set; }
        public DbSet<Models.Reviews> Reviews { get; set; }
        public DbSet<Models.Bookings> Bookings { get; set; }
        public DbSet<Models.VenuePackages> VenuePackages { get; set; }
        public DbSet<Models.VenuePhotos> VenuePhotos { get; set; }
        public DbSet<Models.Customer> Customer { get; set; }
        public DbSet<Models.BookingInvoice> BookingInvoice { get; set; }
        public DbSet<Models.PackageIncludedFacilities> PackageIncludedFacilities { get; set; }
        public DbSet<Models.VenueEventType> VenueEventType { get; set; }
        public DbSet<Models.VenueSlots> VenueSlots { get; set; }
        public DbSet<Models.VenueBookings> VenueBookings { get; set; }
        public DbSet<Models.EventType> EventType { get; set; }
        public DbSet<Models.InvoicePayments> InvoicePayments { get; set; }
        public DbSet<Models.InvoiceItems> InvoiceItems { get; set; }
        public DbSet<Models.SupplierType> SupplierType { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
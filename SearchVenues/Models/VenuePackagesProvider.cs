using SearchVenues.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace SearchVenues.Models
{
    public class VenuePackagesProvider : IVenuePackagesProvider
    {
        VenueHireContext context = new VenueHireContext();
        public VenuePackagesProvider()
        {
            this.context = new VenueHireContext();
        }
        public IQueryable<VenuePackages> All
        {
            get { return context.VenuePackages; }
        }
        public IQueryable<VenuePackages> AllIncluding(params Expression<Func<VenuePackages, object>>[] includeProperties)
        {
            IQueryable<VenuePackages> query = context.VenuePackages;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public VenuePackages Find(int id)
        {
            return context.VenuePackages.Find(id);
        }
        public void InsertOrUpdate(VenuePackages VenuePackages)
        {
            if (VenuePackages.VenuePackageID == default(int))
            {
                // New entity
                context.VenuePackages.Add(VenuePackages);
                context.SaveChanges();
            }
            else
            {
                // Existing entity
                context.Entry(VenuePackages).State = EntityState.Modified;
            }
        }
        public void Delete(int id)
        {
            var Venue = context.VenuePackages.Find(id);
            context.VenuePackages.Remove(Venue);
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
    public interface IVenuePackagesProvider : IDisposable
    {
        IQueryable<VenuePackages> All { get; }
        IQueryable<VenuePackages> AllIncluding(params Expression<Func<VenuePackages, object>>[] includeProperties);
        VenuePackages Find(int id);
        void InsertOrUpdate(VenuePackages VenuePackages);
        void Delete(int id);
        void Save();
    }
}
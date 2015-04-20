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
    public class PackageIncludedFacilitiesProvider : IPackageIncludedFacilitiesProvider
    {
        VenueHireContext context = new VenueHireContext();
        public PackageIncludedFacilitiesProvider()
        {
            this.context = new VenueHireContext();
        }
        public IQueryable<PackageIncludedFacilities> All
        {
            get { return context.PackageIncludedFacilities; }
        }
        public IQueryable<PackageIncludedFacilities> AllIncluding(params Expression<Func<PackageIncludedFacilities, object>>[] includeProperties)
        {
            IQueryable<PackageIncludedFacilities> query = context.PackageIncludedFacilities;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public PackageIncludedFacilities Find(int id)
        {
            return context.PackageIncludedFacilities.Find(id);
        }
        public void InsertOrUpdate(PackageIncludedFacilities PackageIncludedFacilities)
        {
            if (PackageIncludedFacilities.PackageIncludedFacilitiesID == default(int))
            {
                // New entity
                context.PackageIncludedFacilities.Add(PackageIncludedFacilities);
                context.SaveChanges();
            }
            else
            {
                // Existing entity
                context.Entry(PackageIncludedFacilities).State = EntityState.Modified;
            }
        }
        public void Delete(int id)
        {
            var PackageIncludedFacilities = context.PackageIncludedFacilities.Find(id);
            context.PackageIncludedFacilities.Remove(PackageIncludedFacilities);
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
    public interface IPackageIncludedFacilitiesProvider : IDisposable
    {
        IQueryable<PackageIncludedFacilities> All { get; }
        IQueryable<PackageIncludedFacilities> AllIncluding(params Expression<Func<PackageIncludedFacilities, object>>[] includeProperties);
        PackageIncludedFacilities Find(int id);
        void InsertOrUpdate(PackageIncludedFacilities PackageIncludedFacilities);
        void Delete(int id);
        void Save();
    }
}
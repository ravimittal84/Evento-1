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
    public class VenueFacilitiesProvider : IVenueFacilitiesProvider
    {
        VenueHireContext context = new VenueHireContext();
        public VenueFacilitiesProvider()
        {
            this.context = new VenueHireContext();
        }
        public IQueryable<VenueFacilities> All
        {
            get { return context.VenueFacilities; }
        }
        public IQueryable<VenueFacilities> AllIncluding(params Expression<Func<VenueFacilities, object>>[] includeProperties)
        {
            IQueryable<VenueFacilities> query = context.VenueFacilities;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public VenueFacilities Find(int id)
        {
            return context.VenueFacilities.Find(id);
        }
        public void InsertOrUpdate(VenueFacilities VenueFacilities)
        {
            if (VenueFacilities.VenueFacilityID == default(int))
            {
                // New entity
                context.VenueFacilities.Add(VenueFacilities);
                context.SaveChanges();
            }
            else
            {
                // Existing entity
                context.Entry(VenueFacilities).State = EntityState.Modified;
            }
        }
        public void Delete(int id)
        {
            var Venue = context.VenueFacilities.Find(id);
            context.VenueFacilities.Remove(Venue);
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
    public interface IVenueFacilitiesProvider : IDisposable
    {
        IQueryable<VenueFacilities> All { get; }
        IQueryable<VenueFacilities> AllIncluding(params Expression<Func<VenueFacilities, object>>[] includeProperties);
        VenueFacilities Find(int id);
        void InsertOrUpdate(VenueFacilities VenueFacilities);
        void Delete(int id);
        void Save();
    }
}
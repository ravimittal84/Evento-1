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
    public class VenueEventTypeProvider : IVenueEventTypeProvider
    {
        VenueHireContext context = new VenueHireContext();
        public VenueEventTypeProvider()
        {
            this.context = new VenueHireContext();
        }
        public IQueryable<VenueEventType> All
        {
            get { return context.VenueEventType; }
        }
        public IQueryable<VenueEventType> AllIncluding(params Expression<Func<VenueEventType, object>>[] includeProperties)
        {
            IQueryable<VenueEventType> query = context.VenueEventType;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public VenueEventType Find(int id)
        {
            return context.VenueEventType.Find(id);
        }
        public void InsertOrUpdate(VenueEventType VenueEventType)
        {
            if (VenueEventType.VenueEventTypeID == default(int))
            {
                // New entity
                context.VenueEventType.Add(VenueEventType);
                context.SaveChanges();
            }
            else
            {
                // Existing entity
                context.Entry(VenueEventType).State = EntityState.Modified;
            }
        }
        public void Delete(int id)
        {
            var Venue = context.VenueEventType.Find(id);
            context.VenueEventType.Remove(Venue);
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
    public interface IVenueEventTypeProvider : IDisposable
    {
        IQueryable<VenueEventType> All { get; }
        IQueryable<VenueEventType> AllIncluding(params Expression<Func<VenueEventType, object>>[] includeProperties);
        VenueEventType Find(int id);
        void InsertOrUpdate(VenueEventType VenueEventType);
        void Delete(int id);
        void Save();
    }
}
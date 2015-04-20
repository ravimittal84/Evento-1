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
    public class VenueProvider : IVenueProvider
    {
        VenueHireContext context = new VenueHireContext();
        public VenueProvider()
        {
            this.context = new VenueHireContext();
        }
        public IQueryable<Venue> All
        {
            get { return context.Venue; }
        }
        public IQueryable<Venue> AllIncluding(params Expression<Func<Venue, object>>[] includeProperties)
        {
            IQueryable<Venue> query = context.Venue;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public Venue Find(int id)
        {
            return context.Venue.Find(id);
        }
        public void InsertOrUpdate(Venue Venue)
        {
            if (Venue.VenueID == default(int))
            {
                // New entity
                context.Venue.Add(Venue);
                context.SaveChanges();
            }
            else
            {
                // Existing entity
                context.Entry(Venue).State = EntityState.Modified;
            }
        }
        public void Delete(int id)
        {
            var Venue = context.Venue.Find(id);
            context.Venue.Remove(Venue);
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
    public interface IVenueProvider : IDisposable
    {
        IQueryable<Venue> All { get; }
        IQueryable<Venue> AllIncluding(params Expression<Func<Venue, object>>[] includeProperties);
        Venue Find(int id);
        void InsertOrUpdate(Venue Venue);
        void Delete(int id);
        void Save();
    }
}
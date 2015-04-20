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
    public class VenueBookingsProvider : IVenueBookingsProvider
    {
        VenueHireContext context = new VenueHireContext();
        public VenueBookingsProvider()
        {
            this.context = new VenueHireContext();
        }
        public IQueryable<VenueBookings> All
        {
            get { return context.VenueBookings; }
        }
        public IQueryable<VenueBookings> AllIncluding(params Expression<Func<VenueBookings, object>>[] includeProperties)
        {
            IQueryable<VenueBookings> query = context.VenueBookings;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public VenueBookings Find(int id)
        {
            return context.VenueBookings.Find(id);
        }
        public void InsertOrUpdate(VenueBookings VenueBookings)
        {
            if (VenueBookings.VenueBookingID == default(int))
            {
                // New entity
                context.VenueBookings.Add(VenueBookings);
                context.SaveChanges();
            }
            else
            {
                // Existing entity
                context.Entry(VenueBookings).State = EntityState.Modified;
            }
        }
        public void Delete(int id)
        {
            var Venue = context.VenueBookings.Find(id);
            context.VenueBookings.Remove(Venue);
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
    public interface IVenueBookingsProvider : IDisposable
    {
        IQueryable<VenueBookings> All { get; }
        IQueryable<VenueBookings> AllIncluding(params Expression<Func<VenueBookings, object>>[] includeProperties);
        VenueBookings Find(int id);
        void InsertOrUpdate(VenueBookings VenueBookings);
        void Delete(int id);
        void Save();
    }
}
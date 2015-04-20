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
    public class BookingsProvider : IBookingsProvider
    {
        VenueHireContext context = new VenueHireContext();
        public BookingsProvider()
        {
            this.context = new VenueHireContext();
        }
        public IQueryable<Bookings> All
        {
            get { return context.Bookings; }
        }
        public IQueryable<Bookings> AllIncluding(params Expression<Func<Bookings, object>>[] includeProperties)
        {
            IQueryable<Bookings> query = context.Bookings;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public Bookings Find(int id)
        {
            return context.Bookings.Find(id);
        }
        public void InsertOrUpdate(Bookings Bookings)
        {
            if (Bookings.BookingsID == default(int))
            {
                // New entity
                context.Bookings.Add(Bookings);
                context.SaveChanges();
            }
            else
            {
                // Existing entity
                context.Entry(Bookings).State = EntityState.Modified;
            }
        }
        public void Delete(int id)
        {
            var Bookings = context.Bookings.Find(id);
            context.Bookings.Remove(Bookings);
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
    public interface IBookingsProvider : IDisposable
    {
        IQueryable<Bookings> All { get; }
        IQueryable<Bookings> AllIncluding(params Expression<Func<Bookings, object>>[] includeProperties);
        Bookings Find(int id);
        void InsertOrUpdate(Bookings Bookings);
        void Delete(int id);
        void Save();
    }
}
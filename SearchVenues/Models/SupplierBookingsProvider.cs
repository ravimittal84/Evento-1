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
    public class SupplierBookingsProvider : ISupplierBookingsProvider
    {
        VenueHireContext context = new VenueHireContext();
        public SupplierBookingsProvider()
        {
            this.context = new VenueHireContext();
        }
        public IQueryable<SupplierBookings> All
        {
            get { return context.SupplierBookings; }
        }
        public IQueryable<SupplierBookings> AllIncluding(params Expression<Func<SupplierBookings, object>>[] includeProperties)
        {
            IQueryable<SupplierBookings> query = context.SupplierBookings;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public SupplierBookings Find(int id)
        {
            return context.SupplierBookings.Find(id);
        }
        public void InsertOrUpdate(SupplierBookings SupplierBookings)
        {
            if (SupplierBookings.SupplierBookingsID == default(int))
            {
                // New entity
                context.SupplierBookings.Add(SupplierBookings);
                context.SaveChanges();
            }
            else
            {
                // Existing entity
                context.Entry(SupplierBookings).State = EntityState.Modified;
            }
        }
        public void Delete(int id)
        {
            var SupplierBookings = context.SupplierBookings.Find(id);
            context.SupplierBookings.Remove(SupplierBookings);
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
    public interface ISupplierBookingsProvider : IDisposable
    {
        IQueryable<SupplierBookings> All { get; }
        IQueryable<SupplierBookings> AllIncluding(params Expression<Func<SupplierBookings, object>>[] includeProperties);
        SupplierBookings Find(int id);
        void InsertOrUpdate(SupplierBookings SupplierBookings);
        void Delete(int id);
        void Save();
    }

}
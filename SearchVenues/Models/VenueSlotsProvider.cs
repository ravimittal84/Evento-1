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
    public class VenueSlotsProvider : IVenueSlotsProvider
    {
        VenueHireContext context = new VenueHireContext();
        public VenueSlotsProvider()
        {
            this.context = new VenueHireContext();
        }
        public IQueryable<VenueSlots> All
        {
            get { return context.VenueSlots; }
        }
        public IQueryable<VenueSlots> AllIncluding(params Expression<Func<VenueSlots, object>>[] includeProperties)
        {
            IQueryable<VenueSlots> query = context.VenueSlots;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public VenueSlots Find(int id)
        {
            return context.VenueSlots.Find(id);
        }
        public void InsertOrUpdate(VenueSlots VenueSlots)
        {
            if (VenueSlots.VenueSlotID == default(int))
            {
                // New entity
                context.VenueSlots.Add(VenueSlots);
                context.SaveChanges();
            }
            else
            {
                // Existing entity
                context.Entry(VenueSlots).State = EntityState.Modified;
            }
        }
        public void Delete(int id)
        {
            var Venue = context.VenueSlots.Find(id);
            context.VenueSlots.Remove(Venue);
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
    public interface IVenueSlotsProvider : IDisposable
    {
        IQueryable<VenueSlots> All { get; }
        IQueryable<VenueSlots> AllIncluding(params Expression<Func<VenueSlots, object>>[] includeProperties);
        VenueSlots Find(int id);
        void InsertOrUpdate(VenueSlots VenueSlots);
        void Delete(int id);
        void Save();
    }
}
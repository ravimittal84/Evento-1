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
    public class SupplierSlotsProvider : ISupplierSlotsProvider
    {
        VenueHireContext context = new VenueHireContext();
        public SupplierSlotsProvider()
        {
            this.context = new VenueHireContext();
        }
        public IQueryable<SupplierSlots> All
        {
            get { return context.SupplierSlots; }
        }
        public IQueryable<SupplierSlots> AllIncluding(params Expression<Func<SupplierSlots, object>>[] includeProperties)
        {
            IQueryable<SupplierSlots> query = context.SupplierSlots;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public SupplierSlots Find(int id)
        {
            return context.SupplierSlots.Find(id);
        }
        public void InsertOrUpdate(SupplierSlots SupplierSlots)
        {
            if (SupplierSlots.SupplierSlotsID == default(int))
            {
                // New entity
                context.SupplierSlots.Add(SupplierSlots);
                context.SaveChanges();
            }
            else
            {
                // Existing entity
                context.Entry(SupplierSlots).State = EntityState.Modified;
            }
        }
        public void Delete(int id)
        {
            var SupplierSlots = context.SupplierSlots.Find(id);
            context.SupplierSlots.Remove(SupplierSlots);
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
    public interface ISupplierSlotsProvider : IDisposable
    {
        IQueryable<SupplierSlots> All { get; }
        IQueryable<SupplierSlots> AllIncluding(params Expression<Func<SupplierSlots, object>>[] includeProperties);
        SupplierSlots Find(int id);
        void InsertOrUpdate(SupplierSlots SupplierSlots);
        void Delete(int id);
        void Save();
    }
}
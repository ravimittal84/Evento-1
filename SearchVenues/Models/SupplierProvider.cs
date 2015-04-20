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
    public class SupplierProvider : ISuplierProvider
    {
        VenueHireContext context = new VenueHireContext();
        public SupplierProvider()
        {
            this.context = new VenueHireContext();
        }
        public IQueryable<Supplier> All
        {
            get { return context.Supplier; }
        }
        public IQueryable<Supplier> AllIncluding(params Expression<Func<Supplier, object>>[] includeProperties)
        {
            IQueryable<Supplier> query = context.Supplier;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public Supplier Find(int id)
        {
            return context.Supplier.Find(id);
        }
        public void InsertOrUpdate(Supplier Supplier)
        {
            if (Supplier.SupplierID == default(int))
            {
                // New entity
                context.Supplier.Add(Supplier);
                context.SaveChanges();
            }
            else
            {
                // Existing entity
                context.Entry(Supplier).State = EntityState.Modified;
            }
        }
        public void Delete(int id)
        {
            var Supplier = context.Supplier.Find(id);
            context.Supplier.Remove(Supplier);
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
    public interface ISuplierProvider : IDisposable
    {
        IQueryable<Supplier> All { get; }
        IQueryable<Supplier> AllIncluding(params Expression<Func<Supplier, object>>[] includeProperties);
        Supplier Find(int id);
        void InsertOrUpdate(Supplier Suplier);
        void Delete(int id);
        void Save();
    }
}
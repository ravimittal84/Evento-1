using SearchVenues.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace SearchVenues.Models
{
    public class SupplierTypeProvider : ISupplierTypeProvider
    {
        VenueHireContext context = new VenueHireContext();
        public SupplierTypeProvider()
        {
            this.context = new VenueHireContext();
        }
        public IQueryable<SupplierType> All
        {
            get { return context.SupplierType; }
        }
        public IQueryable<SupplierType> AllIncluding(params Expression<Func<SupplierType, object>>[] includeProperties)
        {
            IQueryable<SupplierType> query = context.SupplierType;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public SupplierType Find(int id)
        {
            return context.SupplierType.Find(id);
        }
        public void InsertOrUpdate(SupplierType SupplierType)
        {
            if (SupplierType.SupplierTypeID == default(int))
            {
                // New entity
                context.SupplierType.Add(SupplierType);
                context.SaveChanges();
            }
            else
            {
                // Existing entity
                context.Entry(SupplierType).State = EntityState.Modified;
            }
        }
        public void Delete(int id)
        {
            var SupplierType = context.SupplierType.Find(id);
            context.SupplierType.Remove(SupplierType);
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
    public interface ISupplierTypeProvider : IDisposable
    {
        IQueryable<SupplierType> All { get; }
        IQueryable<SupplierType> AllIncluding(params Expression<Func<SupplierType, object>>[] includeProperties);
        SupplierType Find(int id);
        void InsertOrUpdate(SupplierType Suplier);
        void Delete(int id);
        void Save();
    }
}
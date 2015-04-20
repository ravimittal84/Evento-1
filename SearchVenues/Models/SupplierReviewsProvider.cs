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
    public class SupplierReviewsProvider : ISupplierReviewsProvider
    {
        VenueHireContext context = new VenueHireContext();
        public SupplierReviewsProvider()
        {
            this.context = new VenueHireContext();
        }
        public IQueryable<SuplierReviews> All
        {
            get { return context.SupplierReviews; }
        }
        public IQueryable<SuplierReviews> AllIncluding(params Expression<Func<SuplierReviews, object>>[] includeProperties)
        {
            IQueryable<SuplierReviews> query = context.SupplierReviews;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public SuplierReviews Find(int id)
        {
            return context.SupplierReviews.Find(id);
        }
        public void InsertOrUpdate(SuplierReviews SupplierReviews)
        {
            if (SupplierReviews.SupplierReviewsID == default(int))
            {
                // New entity
                context.SupplierReviews.Add(SupplierReviews);
                context.SaveChanges();
            }
            else
            {
                // Existing entity
                context.Entry(SupplierReviews).State = EntityState.Modified;
            }
        }
        public void Delete(int id)
        {
            var SupplierReviews = context.SupplierReviews.Find(id);
            context.SupplierReviews.Remove(SupplierReviews);
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
    public interface ISupplierReviewsProvider : IDisposable
    {
        IQueryable<SuplierReviews> All { get; }
        IQueryable<SuplierReviews> AllIncluding(params Expression<Func<SuplierReviews, object>>[] includeProperties);
        SuplierReviews Find(int id);
        void InsertOrUpdate(SuplierReviews SupplierReviews);
        void Delete(int id);
        void Save();
    }
}
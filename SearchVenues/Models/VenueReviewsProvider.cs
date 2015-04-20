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
    public class VenueReviewsProvider : IVenueReviewsProvider
    {
        VenueHireContext context = new VenueHireContext();
        public VenueReviewsProvider()
        {
            this.context = new VenueHireContext();
        }
        public IQueryable<VenueReviews> All
        {
            get { return context.VenueReviews; }
        }
        public IQueryable<VenueReviews> AllIncluding(params Expression<Func<VenueReviews, object>>[] includeProperties)
        {
            IQueryable<VenueReviews> query = context.VenueReviews;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public VenueReviews Find(int id)
        {
            return context.VenueReviews.Find(id);
        }
        public void InsertOrUpdate(VenueReviews VenueReviews)
        {
            if (VenueReviews.VenueReviewID == default(int))
            {
                // New entity
                context.VenueReviews.Add(VenueReviews);
                context.SaveChanges();
            }
            else
            {
                // Existing entity
                context.Entry(VenueReviews).State = EntityState.Modified;
            }
        }
        public void Delete(int id)
        {
            var Venue = context.VenueReviews.Find(id);
            context.VenueReviews.Remove(Venue);
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
    public interface IVenueReviewsProvider : IDisposable
    {
        IQueryable<VenueReviews> All { get; }
        IQueryable<VenueReviews> AllIncluding(params Expression<Func<VenueReviews, object>>[] includeProperties);
        VenueReviews Find(int id);
        void InsertOrUpdate(VenueReviews VenueReviews);
        void Delete(int id);
        void Save();
    }
}
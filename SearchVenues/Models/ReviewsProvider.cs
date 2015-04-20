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
    public class ReviewsProvider : IReviewsProvider
    {
        VenueHireContext context = new VenueHireContext();
        public ReviewsProvider()
        {
            this.context = new VenueHireContext();
        }
        public IQueryable<Reviews> All
        {
            get { return context.Reviews; }
        }
        public IQueryable<Reviews> AllIncluding(params Expression<Func<Reviews, object>>[] includeProperties)
        {
            IQueryable<Reviews> query = context.Reviews;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public Reviews Find(int id)
        {
            return context.Reviews.Find(id);
        }
        public void InsertOrUpdate(Reviews Reviews)
        {
            if (Reviews.ReviewID == default(int))
            {
                // New entity
                context.Reviews.Add(Reviews);
                context.SaveChanges();
            }
            else
            {
                // Existing entity
                context.Entry(Reviews).State = EntityState.Modified;
            }
        }
        public void Delete(int id)
        {
            var Reviews = context.Reviews.Find(id);
            context.Reviews.Remove(Reviews);
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
    public interface IReviewsProvider : IDisposable
    {
        IQueryable<Reviews> All { get; }
        IQueryable<Reviews> AllIncluding(params Expression<Func<Reviews, object>>[] includeProperties);
        Reviews Find(int id);
        void InsertOrUpdate(Reviews Reviews);
        void Delete(int id);
        void Save();
    }
}
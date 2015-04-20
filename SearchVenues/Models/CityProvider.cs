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
    public class CityProvider : ICityProvider
    {
        VenueHireContext context = new VenueHireContext();
        public CityProvider()
        {
            this.context = new VenueHireContext();
        }
        public IQueryable<City> All
        {
            get { return context.City; }
        }
        public IQueryable<City> AllIncluding(params Expression<Func<City, object>>[] includeProperties)
        {
            IQueryable<City> query = context.City;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public City Find(int id)
        {
            return context.City.Find(id);
        }
        public void InsertOrUpdate(City City)
        {
            if (City.CityID == default(int))
            {
                // New entity
                context.City.Add(City);
                context.SaveChanges();
            }
            else
            {
                // Existing entity
                context.Entry(City).State = EntityState.Modified;
            }
        }
        public void Delete(int id)
        {
            var City = context.City.Find(id);
            context.City.Remove(City);
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
    public interface ICityProvider : IDisposable
    {
        IQueryable<City> All { get; }
        IQueryable<City> AllIncluding(params Expression<Func<City, object>>[] includeProperties);
        City Find(int id);
        void InsertOrUpdate(City City);
        void Delete(int id);
        void Save();
    }
}
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
    public class AreaProvider : IAreaProvider
    {
        VenueHireContext context = new VenueHireContext();
        public AreaProvider()
        {
            this.context = new VenueHireContext();
        }
        public IQueryable<Area> All
        {
            get { return context.Area; }
        }
        public IQueryable<Area> AllIncluding(params Expression<Func<Area, object>>[] includeProperties)
        {
            IQueryable<Area> query = context.Area;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public Area Find(int id)
        {
            return context.Area.Find(id);
        }
        public void InsertOrUpdate(Area Area)
        {
            if (Area.AreaID == default(int))
            {
                // New entity
                context.Area.Add(Area);
                context.SaveChanges();
            }
            else
            {
                // Existing entity
                context.Entry(Area).State = EntityState.Modified;
            }
        }
        public void Delete(int id)
        {
            var Area = context.Area.Find(id);
            context.Area.Remove(Area);
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
    public interface IAreaProvider : IDisposable
    {
        IQueryable<Area> All { get; }
        IQueryable<Area> AllIncluding(params Expression<Func<Area, object>>[] includeProperties);
        Area Find(int id);
        void InsertOrUpdate(Area Area);
        void Delete(int id);
        void Save();
    }
}
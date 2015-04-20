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
    public class EventTypeProvider : IEventTypeProvider
    {
        VenueHireContext context = new VenueHireContext();
        public EventTypeProvider()
        {
            this.context = new VenueHireContext();
        }
        public IQueryable<EventType> All
        {
            get { return context.EventType; }
        }
        public IQueryable<EventType> AllIncluding(params Expression<Func<EventType, object>>[] includeProperties)
        {
            IQueryable<EventType> query = context.EventType;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public EventType Find(int id)
        {
            return context.EventType.Find(id);
        }
        public void InsertOrUpdate(EventType EventType)
        {
            if (EventType.EventTypeID == default(int))
            {
                // New entity
                context.EventType.Add(EventType);
                context.SaveChanges();
            }
            else
            {
                // Existing entity
                context.Entry(EventType).State = EntityState.Modified;
            }
        }
        public void Delete(int id)
        {
            var EventType = context.EventType.Find(id);
            context.EventType.Remove(EventType);
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
    public interface IEventTypeProvider : IDisposable
    {
        IQueryable<EventType> All { get; }
        IQueryable<EventType> AllIncluding(params Expression<Func<EventType, object>>[] includeProperties);
        EventType Find(int id);
        void InsertOrUpdate(EventType EventType);
        void Delete(int id);
        void Save();
    }
}
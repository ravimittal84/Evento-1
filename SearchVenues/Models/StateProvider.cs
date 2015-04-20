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
    public class StateProvider : IStateProvider
    {
        VenueHireContext context = new VenueHireContext();
        public StateProvider()
        {
            this.context = new VenueHireContext();
        }
        public IQueryable<State> All
        {
            get { return context.State; }
        }
        public IQueryable<State> AllIncluding(params Expression<Func<State, object>>[] includeProperties)
        {
            IQueryable<State> query = context.State;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public State Find(int id)
        {
            return context.State.Find(id);
        }
        public void InsertOrUpdate(State State)
        {
            if (State.StateID == default(int))
            {
                // New entity
                context.State.Add(State);
                context.SaveChanges();
            }
            else
            {
                // Existing entity
                context.Entry(State).State = EntityState.Modified;
            }
        }
        public void Delete(int id)
        {
            var State = context.State.Find(id);
            context.State.Remove(State);
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
    public interface IStateProvider : IDisposable
    {
        IQueryable<State> All { get; }
        IQueryable<State> AllIncluding(params Expression<Func<State, object>>[] includeProperties);
        State Find(int id);
        void InsertOrUpdate(State State);
        void Delete(int id);
        void Save();
    }
}
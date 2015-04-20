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
    public class FacilitiesProvider : IFacilitiesProvider
    {
        VenueHireContext context = new VenueHireContext();
        public FacilitiesProvider()
        {
            this.context = new VenueHireContext();
        }
        public IQueryable<Facilities> All
        {
            get { return context.Facilities; }
        }
        public IQueryable<Facilities> AllIncluding(params Expression<Func<Facilities, object>>[] includeProperties)
        {
            IQueryable<Facilities> query = context.Facilities;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public Facilities Find(int id)
        {
            return context.Facilities.Find(id);
        }
        public void InsertOrUpdate(Facilities Facilities)
        {
            if (Facilities.FacilityID == default(int))
            {
                // New entity
                context.Facilities.Add(Facilities);
                context.SaveChanges();
            }
            else
            {
                // Existing entity
                context.Entry(Facilities).State = EntityState.Modified;
            }
        }
        public void Delete(int id)
        {
            var Facilities = context.Facilities.Find(id);
            context.Facilities.Remove(Facilities);
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
    public interface IFacilitiesProvider : IDisposable
    {
        IQueryable<Facilities> All { get; }
        IQueryable<Facilities> AllIncluding(params Expression<Func<Facilities, object>>[] includeProperties);
        Facilities Find(int id);
        void InsertOrUpdate(Facilities Facilities);
        void Delete(int id);
        void Save();
    }
}
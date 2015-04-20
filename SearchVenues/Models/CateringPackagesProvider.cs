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
    public class CateringPackagesProvider : ICateringPackagesProvider
    {
        VenueHireContext context = new VenueHireContext();
        public CateringPackagesProvider()
        {
            this.context = new VenueHireContext();
        }
        public IQueryable<CateringPackages> All
        {
            get { return context.CateringPackages; }
        }
        public IQueryable<CateringPackages> AllIncluding(params Expression<Func<CateringPackages, object>>[] includeProperties)
        {
            IQueryable<CateringPackages> query = context.CateringPackages;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public CateringPackages Find(int id)
        {
            return context.CateringPackages.Find(id);
        }
        public void InsertOrUpdate(CateringPackages CateringPackages)
        {
            if (CateringPackages.CateringPackagesID == default(int))
            {
                // New entity
                context.CateringPackages.Add(CateringPackages);
                context.SaveChanges();
            }
            else
            {
                // Existing entity
                context.Entry(CateringPackages).State = EntityState.Modified;
            }
        }
        public void Delete(int id)
        {
            var CateringPackages = context.CateringPackages.Find(id);
            context.CateringPackages.Remove(CateringPackages);
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
    public interface ICateringPackagesProvider : IDisposable
    {
        IQueryable<CateringPackages> All { get; }
        IQueryable<CateringPackages> AllIncluding(params Expression<Func<CateringPackages, object>>[] includeProperties);
        CateringPackages Find(int id);
        void InsertOrUpdate(CateringPackages CateringPackages);
        void Delete(int id);
        void Save();
    }
}
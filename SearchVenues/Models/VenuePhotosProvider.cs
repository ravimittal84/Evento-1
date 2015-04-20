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
    public class VenuePhotosProvider : IVenuePhotosProvider
    {
        VenueHireContext context = new VenueHireContext();
        public VenuePhotosProvider()
        {
            this.context = new VenueHireContext();
        }
        public IQueryable<VenuePhotos> All
        {
            get { return context.VenuePhotos; }
        }
        public IQueryable<VenuePhotos> AllIncluding(params Expression<Func<VenuePhotos, object>>[] includeProperties)
        {
            IQueryable<VenuePhotos> query = context.VenuePhotos;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public VenuePhotos Find(int id)
        {
            return context.VenuePhotos.Find(id);
        }
        public void InsertOrUpdate(VenuePhotos VenuePhotos)
        {
            if (VenuePhotos.VenuePhotoID == default(int))
            {
                // New entity
                context.VenuePhotos.Add(VenuePhotos);
                context.SaveChanges();
            }
            else
            {
                // Existing entity
                context.Entry(VenuePhotos).State = EntityState.Modified;
            }
        }
        public void Delete(int id)
        {
            var Venue = context.VenuePhotos.Find(id);
            context.VenuePhotos.Remove(Venue);
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
    public interface IVenuePhotosProvider : IDisposable
    {
        IQueryable<VenuePhotos> All { get; }
        IQueryable<VenuePhotos> AllIncluding(params Expression<Func<VenuePhotos, object>>[] includeProperties);
        VenuePhotos Find(int id);
        void InsertOrUpdate(VenuePhotos VenuePhotos);
        void Delete(int id);
        void Save();
    }
}
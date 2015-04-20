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
    public class AddressProvider : IAddressProvider
    {
        VenueHireContext context = new VenueHireContext();
        public AddressProvider()
        {
            this.context = new VenueHireContext();
        }
        public IQueryable<Address> All
        {
            get { return context.Address; }
        }
        public IQueryable<Address> AllIncluding(params Expression<Func<Address, object>>[] includeProperties)
        {
            IQueryable<Address> query = context.Address;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public Address Find(int id)
        {
            return context.Address.Find(id);
        }
        public void InsertOrUpdate(Address address)
        {
            if (address.AddressID == default(int))
            {
                // New entity
                context.Address.Add(address);
                context.SaveChanges();
            }
            else
            {
                // Existing entity
                context.Entry(address).State = EntityState.Modified;
            }
        }
        public void Delete(int id)
        {
            var address = context.Address.Find(id);
            context.Address.Remove(address);
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
    public interface IAddressProvider : IDisposable
    {
        IQueryable<Address> All { get; }
        IQueryable<Address> AllIncluding(params Expression<Func<Address, object>>[] includeProperties);
        Address Find(int id);
        void InsertOrUpdate(Address address);
        void Delete(int id);
        void Save();
    }
}
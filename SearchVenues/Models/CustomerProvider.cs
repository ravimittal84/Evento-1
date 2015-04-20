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
    public class CustomerProvider : ICustomerProvider
    {
        VenueHireContext context = new VenueHireContext();
        public CustomerProvider()
        {
            this.context = new VenueHireContext();
        }
        public IQueryable<Customer> All
        {
            get { return context.Customer; }
        }
        public IQueryable<Customer> AllIncluding(params Expression<Func<Customer, object>>[] includeProperties)
        {
            IQueryable<Customer> query = context.Customer;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public Customer Find(int id)
        {
            return context.Customer.Find(id);
        }
        public void InsertOrUpdate(Customer Customer)
        {
            if (Customer.CustomerID == default(int))
            {
                // New entity
                context.Customer.Add(Customer);
                context.SaveChanges();
            }
            else
            {
                // Existing entity
                context.Entry(Customer).State = EntityState.Modified;
            }
        }
        public void Delete(int id)
        {
            var Customer = context.Customer.Find(id);
            context.Customer.Remove(Customer);
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
    public interface ICustomerProvider : IDisposable
    {
        IQueryable<Customer> All { get; }
        IQueryable<Customer> AllIncluding(params Expression<Func<Customer, object>>[] includeProperties);
        Customer Find(int id);
        void InsertOrUpdate(Customer Customer);
        void Delete(int id);
        void Save();
    }
}
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
    public class InvoiceItemsProvider : IInvoiceItemsProvider
    {
        VenueHireContext context = new VenueHireContext();
        public InvoiceItemsProvider()
        {
            this.context = new VenueHireContext();
        }
        public IQueryable<InvoiceItems> All
        {
            get { return context.InvoiceItems; }
        }
        public IQueryable<InvoiceItems> AllIncluding(params Expression<Func<InvoiceItems, object>>[] includeProperties)
        {
            IQueryable<InvoiceItems> query = context.InvoiceItems;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public InvoiceItems Find(int id)
        {
            return context.InvoiceItems.Find(id);
        }
        public void InsertOrUpdate(InvoiceItems InvoiceItems)
        {
            if (InvoiceItems.InvoiceItemID == default(int))
            {
                // New entity
                context.InvoiceItems.Add(InvoiceItems);
                context.SaveChanges();
            }
            else
            {
                // Existing entity
                context.Entry(InvoiceItems).State = EntityState.Modified;
            }
        }
        public void Delete(int id)
        {
            var InvoiceItems = context.InvoiceItems.Find(id);
            context.InvoiceItems.Remove(InvoiceItems);
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
    public interface IInvoiceItemsProvider : IDisposable
    {
        IQueryable<InvoiceItems> All { get; }
        IQueryable<InvoiceItems> AllIncluding(params Expression<Func<InvoiceItems, object>>[] includeProperties);
        InvoiceItems Find(int id);
        void InsertOrUpdate(InvoiceItems InvoiceItems);
        void Delete(int id);
        void Save();
    }
}
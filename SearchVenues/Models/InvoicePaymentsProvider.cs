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
    public class InvoicePaymentsProvider : IInvoicePaymentsProvider 
    {
        VenueHireContext context = new VenueHireContext();
        public InvoicePaymentsProvider()
        {
            this.context = new VenueHireContext();
        }
        public IQueryable<InvoicePayments> All
        {
            get { return context.InvoicePayments; }
        }
        public IQueryable<InvoicePayments> AllIncluding(params Expression<Func<InvoicePayments, object>>[] includeProperties)
        {
            IQueryable<InvoicePayments> query = context.InvoicePayments;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public InvoicePayments Find(int id)
        {
            return context.InvoicePayments.Find(id);
        }
        public void InsertOrUpdate(InvoicePayments InvoicePayments)
        {
            if (InvoicePayments.InvoicePaymentID == default(int))
            {
                // New entity
                context.InvoicePayments.Add(InvoicePayments);
                context.SaveChanges();
            }
            else
            {
                // Existing entity
                context.Entry(InvoicePayments).State = EntityState.Modified;
            }
        }
        public void Delete(int id)
        {
            var InvoicePayments = context.InvoicePayments.Find(id);
            context.InvoicePayments.Remove(InvoicePayments);
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
    public interface IInvoicePaymentsProvider : IDisposable
    {
        IQueryable<InvoicePayments> All { get; }
        IQueryable<InvoicePayments> AllIncluding(params Expression<Func<InvoicePayments, object>>[] includeProperties);
        InvoicePayments Find(int id);
        void InsertOrUpdate(InvoicePayments InvoicePayments);
        void Delete(int id);
        void Save();
    }
}
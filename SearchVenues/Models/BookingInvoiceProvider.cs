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
    public class BookingInvoiceProvider : IBookingInvoiceProvider
    {
        VenueHireContext context = new VenueHireContext();
        public BookingInvoiceProvider()
        {
            this.context = new VenueHireContext();
        }
        public IQueryable<BookingInvoice> All
        {
            get { return context.BookingInvoice; }
        }
        public IQueryable<BookingInvoice> AllIncluding(params Expression<Func<BookingInvoice, object>>[] includeProperties)
        {
            IQueryable<BookingInvoice> query = context.BookingInvoice;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public BookingInvoice Find(int id)
        {
            return context.BookingInvoice.Find(id);
        }
        public void InsertOrUpdate(BookingInvoice BookingInvoice)
        {
            if (BookingInvoice.BookingInvoiceID == default(int))
            {
                // New entity
                context.BookingInvoice.Add(BookingInvoice);
                context.SaveChanges();
            }
            else
            {
                // Existing entity
                context.Entry(BookingInvoice).State = EntityState.Modified;
            }
        }
        public void Delete(int id)
        {
            var BookingInvoice = context.BookingInvoice.Find(id);
            context.BookingInvoice.Remove(BookingInvoice);
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
    public interface IBookingInvoiceProvider : IDisposable
    {
        IQueryable<BookingInvoice> All { get; }
        IQueryable<BookingInvoice> AllIncluding(params Expression<Func<BookingInvoice, object>>[] includeProperties);
        BookingInvoice Find(int id);
        void InsertOrUpdate(BookingInvoice BookingInvoice);
        void Delete(int id);
        void Save();
    }
}
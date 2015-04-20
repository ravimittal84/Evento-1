using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchVenues.Utilities
{
    public class VenueBrokerResponse
    {
        public VenueBrokerResult Result { get; set; }
        public string Message { get; set; }
        public string Notification { get; set; }
        public dynamic Data { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int StartIndex { get { return (CurrentPage > 0 ? CurrentPage - 1 : 0) * PageSize; } }
        public string SortDirection { get; set; }
        public string SortField { get; set; }

        public VenueBrokerResponse(VenueBrokerResult Result, string Message, object Data)
        {
            // TODO: Complete member initialization
            this.Result = Result;
            this.Message = Message;
            this.Data = Data;

        }
        public VenueBrokerResponse()
        {
        }

        public VenueBrokerResponse(VenueBrokerRequest request)
        {
            if (request == null) request = new VenueBrokerRequest();
            this.CurrentPage = request.CurrentPage;
            this.PageSize = request.PageSize;
            this.SortDirection = request.SortDirection;
            this.SortField = request.SortField;
            this.TotalItems = request.TotalItems;
        }
    }
    public enum VenueBrokerResult
    {
        PASSED,
        FAILED
    }
}
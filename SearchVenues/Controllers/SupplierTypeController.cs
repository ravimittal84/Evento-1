using SearchVenues.Models;
using SearchVenues.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SearchVenues.Controllers
{
    public class SupplierTypeController : ApiController
    {
        private readonly ISupplierTypeProvider supplierTypeProvider = new SupplierTypeProvider();
        public VenueBrokerResponse Get([FromUri]VenueBrokerRequest request)
        {
            VenueBrokerResponse response = new VenueBrokerResponse();
            var listOfSupplierType = supplierTypeProvider.All.ToList();
            response.Data = listOfSupplierType;
            response.Message = "Passed";
            response.Result = VenueBrokerResult.PASSED;
            return response;
        }
    }
}

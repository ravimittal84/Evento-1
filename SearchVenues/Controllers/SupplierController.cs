using SearchVenues.Models;
using SearchVenues.Models.Models;
using SearchVenues.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SearchVenues.Controllers
{
    public class SupplierController : ApiController
    {
        private readonly ISuplierProvider suplierProvider = new SupplierProvider();
        //   GET: /api/Supplier
        public VenueBrokerResponse Get([FromUri]VenueBrokerRequest request)
        {
            //Check whether the request contains a key "LocationID"
            bool IsContainsLocationID = false;
            VenueBrokerResponse response = new VenueBrokerResponse();
            if (request.SearchCriteria.ContainsKey("LocationID"))
            {
                IsContainsLocationID = true;
            }
            if (IsContainsLocationID)
            {
                int id = Convert.ToInt32(request.SearchCriteria["LocationID"]);
                if (id == 0)
                {
                    if (request.SearchCriteria.ContainsKey("SupplierTypeID") && Convert.ToInt32(request.SearchCriteria["SupplierTypeID"]) != 0)
                    {
                        int SupplierTypeID =Convert.ToInt32(request.SearchCriteria["SupplierTypeID"]);
                        List<Supplier> listOfSupplier = (from sup in suplierProvider.All.ToList()
                                                         where sup.SupplierTypeID == SupplierTypeID
                                                         select sup).ToList();
                        response.Data = listOfSupplier;
                        response.TotalItems = listOfSupplier.Count();
                        response.Message = "Passed";
                        response.Result = VenueBrokerResult.PASSED;
                    }
                    else
                    {
                        List<Supplier> listOfSupplier = (from sup in suplierProvider.All.ToList()
                                                         select sup).ToList();
                        response.Data = listOfSupplier;
                        response.TotalItems = listOfSupplier.Count();
                        response.Message = "Passed";
                        response.Result = VenueBrokerResult.PASSED;
                    }
                }
                else
                {
                    if (request.SearchCriteria.ContainsKey("SupplierTypeID") && Convert.ToInt32(request.SearchCriteria["SupplierTypeID"]) != 0)
                    {
                        int SupplierTypeID = Convert.ToInt32(request.SearchCriteria["SupplierTypeID"]);
                        List<Supplier> listOfSupplier = (from sup in suplierProvider.All.ToList()
                                                         where sup.SupplierTypeID == SupplierTypeID
                                                         && sup.Address.Area.CityID == id
                                                         select sup).ToList();
                        response.Data = listOfSupplier;
                        response.TotalItems = listOfSupplier.Count();
                        response.Message = "Passed";
                        response.Result = VenueBrokerResult.PASSED;
                    }
                    else
                    {
                        List<Supplier> listOfSupplier = (from sup in suplierProvider.All.ToList()
                                                         where sup.Address.Area.CityID == id
                                                         select sup).ToList();
                        response.Data = listOfSupplier;
                        response.TotalItems = listOfSupplier.Count();
                        response.Message = "Passed";
                        response.Result = VenueBrokerResult.PASSED;
                    }
                }
            }
            else
            {
                response.Message = "Unknown Request";
                response.Result = VenueBrokerResult.FAILED;
            }
            return response;
        }

        //  /api/Supplier/5
        public VenueBrokerResponse Get(int id)
        {
            VenueBrokerResponse response = new VenueBrokerResponse();
            var supplier = suplierProvider.Find(id);
            response.Result = VenueBrokerResult.PASSED;
            response.Message = "Passed";
            response.Data = supplier;
            return response;
        }
    }
}

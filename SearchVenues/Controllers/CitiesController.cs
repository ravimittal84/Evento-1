using SearchVenues.Models;
using SearchVenues.Models.Models;
using SearchVenues.Models.ViewModel;
using SearchVenues.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SearchVenues.Controllers
{
    public class CitiesController : ApiController
    {
        private readonly ICityProvider cityProvider;
        public CitiesController(ICityProvider cityProvider)
        {
            this.cityProvider = cityProvider;
        }
        public CitiesController()
        {
            this.cityProvider = new CityProvider();
        }
        public VenueBrokerResponse Get([FromUri]VenueBrokerRequest request)
        {
            VenueBrokerResponse response = new VenueBrokerResponse();
            //string SearchText = request.SearchCriteria["SearchText"];
            List<CityViewModel> listOfCities = (from b in cityProvider.All
                                       select new CityViewModel() { 
                                            display = b.CityName,
                                            value = b.CityID,
                                            state = b.State.StateName
                                       }).ToList();
            response.Data = listOfCities;
            response.Result = VenueBrokerResult.PASSED;
            response.Message = "Passed";
            return response;
        }
        public VenueBrokerResponse Get(int id)
        {
            VenueBrokerResponse response = new VenueBrokerResponse();
            var city = cityProvider.Find(id);
            response.Data = city;
            response.Result = VenueBrokerResult.PASSED;
            response.Message = "Passed";
            return response;
        }
    }
}

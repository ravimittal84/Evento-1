using SearchVenues.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SearchVenues.Models.Models;
using SearchVenues.Models;
namespace SearchVenues.Controllers
{
    public class FacilitiesController : ApiController
    {
        private readonly IFacilitiesProvider facilitiesProvider;
        private readonly IVenueFacilitiesProvider venueFacilityProvider;
        public FacilitiesController()
        {
            this.facilitiesProvider = new FacilitiesProvider();
            this.venueFacilityProvider = new VenueFacilitiesProvider();
        }
        public VenueBrokerResponse Get([FromUri]VenueBrokerRequest request)
        {
            VenueBrokerResponse response = new VenueBrokerResponse();
            bool ContainsVenueID = request.SearchCriteria.ContainsKey("VenueID");
            if (ContainsVenueID)
            {
                int VenueID = Convert.ToInt32(request.SearchCriteria["VenueID"]);
                List<Facilities> list = new List<Facilities>();
                list = (from facility in facilitiesProvider.All.ToList()
                        join venueFacilities in venueFacilityProvider.All.ToList() on facility.FacilityID equals venueFacilities.FacilityID
                        where venueFacilities.VenueID == VenueID
                        select facility).ToList();
                response.Data = list;
                response.Message = "Passed";
                response.Result = VenueBrokerResult.PASSED;
                return response;
            }
            else
            {
                List<Facilities> listFacilities = new List<Facilities>();
                listFacilities = (from facility in facilitiesProvider.All.ToList()
                                  select facility).ToList();
                response.Message = "Passed";
                response.Result = VenueBrokerResult.PASSED;
                response.Data = listFacilities;
                return response;
            }
        }
    }
}

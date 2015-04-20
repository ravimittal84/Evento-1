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
    public class VenuesController : ApiController
    {
        private readonly IVenueProvider venueProvider;
        private readonly ICityProvider cityProvider;
        private readonly IAreaProvider areaProvider;
        private readonly IAddressProvider addressProvider;
        private readonly IVenuePackagesProvider venuePackageProvider;
        private readonly IVenueFacilitiesProvider venueFacilityProvider;

        public VenuesController()
        {
            this.venueProvider = new VenueProvider();
            this.cityProvider = new CityProvider();
            this.areaProvider = new AreaProvider();
            this.addressProvider = new AddressProvider();
            this.venuePackageProvider = new VenuePackagesProvider();
            this.venueFacilityProvider = new VenueFacilitiesProvider();
        }
        // api/Venues/5
        public VenueBrokerResponse Get(int id)
        {
            Venue venue = (from ven in venueProvider.All
                           where ven.VenueID == id
                           select ven).SingleOrDefault();
            VenueBrokerResponse response = new VenueBrokerResponse();
            response.Message = "Passed";
            response.Result = VenueBrokerResult.PASSED;
            response.Data = venue;
            return response;
        }

        // api/Venues
        public VenueBrokerResponse Get([FromUri]VenueBrokerRequest request)
        {
            VenueBrokerResponse response = new VenueBrokerResponse();
            bool IsContainsFilter = request.SearchCriteria.ContainsKey("Capacity");
            if (Convert.ToInt32(request.SearchCriteria["LocationID"]) == 0)
            {
                if (!IsContainsFilter)
                {
                    List<Venue> venues = (from venue in venueProvider.All select venue).ToList();
                    response.Message = "Passed";
                    response.Data = venues;
                    response.Result = VenueBrokerResult.PASSED;
                }
                else
                {
                    int Capacity = Convert.ToInt32(request.SearchCriteria["Capacity"]);
                    decimal CostPerPerson = Convert.ToDecimal(request.SearchCriteria["Cost"]);
                    string facilities = request.SearchCriteria["VanueFacilities"];
                    string[] facilitiesArray = facilities.Split(',');
                    List<Venue> venues = new List<Venue>();
                    if (CostPerPerson != 0)
                    {
                        venues = (from venue in venueProvider.All.ToList()
                                  join venuPackages in venuePackageProvider.All.ToList() on venue.VenueID equals venuPackages.VenueID
                                  where venue.Capacity > Capacity && venuPackages.CostPerPerson <= CostPerPerson
                                  select venue).ToList();
                    }
                    else
                    {
                        venues = (from venue in venueProvider.All.ToList()
                                  join venuPackages in venuePackageProvider.All.ToList() on venue.VenueID equals venuPackages.VenueID
                                  where venue.Capacity > Capacity
                                  select venue).ToList();
                    }
                    for (int i = 0; i < facilitiesArray.Length; i++)
                    {
                        int fid = 0;
                        fid = Convert.ToInt32(facilitiesArray[i]);
                        venues = (from venue in venues
                                  join venueFacility in venueFacilityProvider.All on venue.VenueID equals venueFacility.VenueID
                                  where venueFacility.FacilityID == fid
                                  select venue).ToList();
                    }
                    response.Message = "Passed";
                    response.Data = venues;
                    response.Result = VenueBrokerResult.PASSED;
                }
            }
            else
            {
                if (!IsContainsFilter)
                {
                    int id = Convert.ToInt32(request.SearchCriteria["LocationID"]);
                    List<Venue> venues = (from venue in venueProvider.All.Where(p => p.Address.Area.City.CityID == id) select venue).ToList();
                    response.Message = "Passed";
                    response.Data = venues;
                    response.Result = VenueBrokerResult.PASSED;
                }
                else
                {
                    int Capacity = Convert.ToInt32(request.SearchCriteria["Capacity"]);
                    decimal CostPerPerson = Convert.ToDecimal(request.SearchCriteria["Cost"]);
                    int id = Convert.ToInt32(request.SearchCriteria["LocationID"]);
                    string facilities = request.SearchCriteria["VanueFacilities"];
                    string[] facilitiesArray = facilities.Split(',');
                    List<Venue> venues = new List<Venue>();
                    if (CostPerPerson != 0)
                    {
                        venues = (from venue in venueProvider.All.Where(p => p.Address.Area.City.CityID == id).ToList()
                                  join venuPackages in venuePackageProvider.All.ToList() on venue.VenueID equals venuPackages.VenueID
                                  where venue.Capacity > Capacity && venuPackages.CostPerPerson <= CostPerPerson
                                  select venue).ToList();
                    }
                    else
                    {
                        venues = (from venue in venueProvider.All.Where(p => p.Address.Area.City.CityID == id).ToList()
                                  join venuPackages in venuePackageProvider.All.ToList() on venue.VenueID equals venuPackages.VenueID
                                  where venue.Capacity > Capacity
                                  select venue).ToList();
                    }
                    for (int i = 0; i < facilitiesArray.Length; i++)
                    {
                        int fid = 0;
                        fid = Convert.ToInt32(facilitiesArray[i]);
                        venues = (from venue in venues
                                  join venueFacility in venueFacilityProvider.All on venue.VenueID equals venueFacility.VenueID
                                  where venueFacility.FacilityID == fid
                                  select venue).ToList();
                    }
                    response.Message = "Passed";
                    response.Data = venues;
                    response.Result = VenueBrokerResult.PASSED;
                }
            }
            return response;
        }
    }
}

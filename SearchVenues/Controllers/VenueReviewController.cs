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
    public class VenueReviewController : ApiController
    {
        private readonly IVenueReviewsProvider venueReviewsProvider = new VenueReviewsProvider();
        private readonly IReviewsProvider reviewsProvider = new ReviewsProvider();
        private readonly ICustomerProvider customerProvider = new CustomerProvider();
        private readonly IVenueProvider venueProvider = new VenueProvider();

        //  api/VenueReview
        public VenueBrokerResponse Get([FromUri]VenueBrokerRequest request)
        {
            VenueBrokerResponse response = new VenueBrokerResponse();
            int VenueID = Convert.ToInt32(request.SearchCriteria["VenueID"]);
            var listOfVenueReviews = venueReviewsProvider.All.Where(rev => rev.VenueID == VenueID).ToList();
            response.Message = "Passed";
            response.Result = VenueBrokerResult.PASSED;
            response.TotalItems = listOfVenueReviews.Count();
            response.Data = listOfVenueReviews;
            return response;
        }

        //    api/VenueReview
        public VenueBrokerResponse Post([FromBody]ReviewViewModel review)
        {
            Address addess = (from add in venueProvider.All
                              where add.VenueID == review.VenueID
                              select add.Address).SingleOrDefault();
            Customer customer = new Customer();
            customer.FirstName = review.FirstName;
            customer.LastName = review.LastName;
            customer.Email = review.Email;
            customer.MobileNumber = review.Contact;
            customer.CreatedAt = DateTime.Now;
            customer.UpdatedAt = DateTime.Now;
            customer.AddressID = null;
            customerProvider.InsertOrUpdate(customer);
            customerProvider.Save();

            Reviews reviews = new Reviews();
            reviews.ReviewText = review.ReviewText;
            reviews.CustomerID = customer.CustomerID;
            reviews.Helpful = "Yes";
            reviews.Unhelpful = "No";
            reviewsProvider.InsertOrUpdate(reviews);
            reviewsProvider.Save();

            VenueReviews venueReviews = new VenueReviews();
            venueReviews.ReviewID = reviews.ReviewID;
            venueReviews.VenueID = review.VenueID;
            venueReviewsProvider.InsertOrUpdate(venueReviews);
            venueReviewsProvider.Save();

            VenueBrokerResponse response = new VenueBrokerResponse();
            response.Message = "Review is posted successfully";
            response.Result = VenueBrokerResult.PASSED;
            response.Data = reviews;

            return response;
        }
    }
}

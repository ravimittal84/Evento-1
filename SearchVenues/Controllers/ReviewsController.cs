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
    public class ReviewsController : ApiController
    {
        private readonly ICustomerProvider customerProvider = new CustomerProvider();
        private readonly IReviewsProvider reviewProvider = new ReviewsProvider();
        private readonly IVenueProvider venueProvider = new VenueProvider();
        //    api/Review
        public VenueBrokerResponse Get([FromUri]VenueBrokerRequest request)
        {
            VenueBrokerResponse response = new VenueBrokerResponse();
            return response;
        }

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
            reviewProvider.InsertOrUpdate(reviews);
            reviewProvider.Save();

            VenueReviews venueReviews = new VenueReviews();
            venueReviews.ReviewID = reviews.ReviewID;
            venueReviews.VenueID = review.VenueID;


            VenueBrokerResponse response = new VenueBrokerResponse();
            response.Message = "Review is posted successfully";
            response.Result = VenueBrokerResult.PASSED;
            response.Data = reviews;

            return response;
        }
    }
}

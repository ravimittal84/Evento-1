using SearchVenues.Models;
using SearchVenues.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SearchVenues.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVenueProvider venueProvider;
        private readonly ICityProvider cityProvider;
        private readonly IAreaProvider areaProvider;
        private readonly IAddressProvider addressProvider;

        public HomeController()
        {
            this.venueProvider = new VenueProvider();
            this.cityProvider = new CityProvider();
            this.areaProvider = new AreaProvider();
            this.addressProvider = new AddressProvider();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ViewBag.BannerClass = "banner";
            ViewBag.SelectedMenuClass = "active";
            return View();
        }
        public ActionResult Venues(int? id)
        {
            ViewBag.BannerClass = "banner1";
            ViewBag.SelectedMenuClass = "active";
            ViewBag.Title = "Vanues";
            if (id.HasValue)
            {
                List<Venue> venues = (from venue in venueProvider.All.Where(p => p.Address.Area.City.CityID == id) select venue).ToList();
                return View(venues);
            }
            else
            {
                return View();
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Contact Us";
            return View();
        }
        public ActionResult Login()
        {
            ViewBag.Title = "Login";
            return View();
        }
        public ActionResult VenueInfo(int? id)
        {
            if (id.HasValue)
            {
                ViewBag.Title = "Venue Information";
                ViewBag.BannerClass = "banner1";
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Suppliers()
        {
            ViewBag.Title = "Suppliers";
            ViewBag.BannerClass = "banner1";
            return View();
        }
        public ActionResult SupplierInfo(int? id)
        {
            ViewBag.Title = "Supplier Information";
            ViewBag.BannerClass = "banner1";
            if (id.HasValue)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Suppliers");
            }
        }

        public ActionResult _Inquery()
        {
            return PartialView();
        }
    }
}

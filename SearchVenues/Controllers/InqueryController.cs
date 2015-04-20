using SearchVenues.Models.ViewModel;
using SearchVenues.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Mail;

namespace SearchVenues.Controllers
{
    public class InqueryController : ApiController
    {
        public VenueBrokerResponse Post([FromBody]InqueryViewModel Inquery)
        {
            VenueBrokerResponse response = new VenueBrokerResponse();
            try
            {
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com", // smtp server address here…
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new System.Net.NetworkCredential("rawatabhinav.rawat@gmail.com", "978425163301415137019"),
                    Timeout = 30000,
                    UseDefaultCredentials = false
                };
                MailMessage message = new MailMessage("rawatabhinav.rawat@gmail.com", "rawatabhinav.rawat@gmail.com", "Subject", "Body");
                smtp.Send(message);
            }
            
            catch (Exception ex)
            {

            }
            return response;
        }
    }
}

using ActionMailer.Net.Mvc;
using DomainModel;
using DomainModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EindopdrachtProg6.Controllers
{
    public class MailController : MailerBase
    {
        //
        // GET: /Mail/

        public ActionResult Index()
        {
            return View();
        }

        public EmailResult VerificationEmail(int id, Boeking boeking)
        {
            GuestRepository gr = new GuestRepository();
            Guest model = gr.GetById(id);

            To.Add(model.Email);
            From = "YA Hotels <AlhricLacle@gmail.com>";
            Subject = "Confirmation email " + "\r\n" +
                      "Name: " + model.Name + "\r\n" +
                      "LastName: " + model.LastName + "\r\n" +
                      "Email: " + model.Email + "\r\n" +
                      "Adress: " + model.Adress + "\r\n" +
                      "Country: " + model.Country + "\r\n" +
                      "PostalCode: " + model.PostalCode + "\r\n" +
                      "BankNr: " + boeking.BankNr + "\r\n" +
                      "BillingAdress: " + boeking.BillingAdress + "\r\n" +
                      "BillingCountry: " + boeking.BillingCountry + "\r\n" +
                      "Billing PostalCode: " + boeking.BillingPostalcode + "\r\n" +
                      "Check in date: " + boeking.CheckInDate + "\r\n" +
                      "Check out date: " + boeking.CheckOutDate + "\r\n" +
                      "TotalPrice: " + boeking.TotalPrice + "\r\n" +
                      "Valuta: " + boeking.Valuta + "\r\n";

            return Email("VerificationEmail", model);
        }


    }
}

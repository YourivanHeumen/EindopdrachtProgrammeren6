using DomainModel;
using DomainModel.Interfaces;
using DomainModel.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EindopdrachtProg6.Controllers
{
    public class BoekingController : Controller
    {
        private IBoekingRepository boekingRepository = new BoekingRepository();

        public ActionResult GetDate()
        {
            var lst = new List<DateTime>();
            lst.Add(new DateTime());
            lst.Add(new DateTime());
            return View(lst);
        }

        [HttpPost]
        public ActionResult GetDate(ICollection<DateTime> results)
        {
            try
            {
                return RedirectToAction("List", new { 
                StartDate = results.ElementAt(0),
                EndDate = results.ElementAt(1)
                });

            }
            catch
            {
                return RedirectToAction("Index", "Start");
            }
        }
        public ActionResult List(DateTime StartDate, DateTime EndDate)
        {
            return View(boekingRepository.GetInPeriod(StartDate, EndDate));
        }

        public ActionResult Create()
        {
            var guest = (Guest)TempData["Guest"];
            var boeking = new Boeking();
            boeking.CheckInGuestId = guest.GuestId;
            boeking.BillingAdress = guest.Adress;
            boeking.BillingPostalcode = guest.PostalCode;
            boeking.BillingCountry = guest.Country;
            boeking.RoomId = guest.ToBookRoomId.Value;
            return View(boeking);
        }

        
        public ActionResult Details(int id)
        {
            var boeking = boekingRepository.GetById(id);
            return View(boeking);
        }


        [HttpPost]
        public ActionResult Create(Boeking boeking)
        {
            if (boekingRepository.IsFree(boeking))
            {
                TempData["Boeking"] = boeking;
                return RedirectToAction("GetBookedRoom", "Room");
            }
            else
            {
                return RedirectToAction("NotFree");
            }

        }

        public ActionResult ShowPrice()
        {
            var b = (Boeking)TempData["b"];
            var room = (Room)TempData["r"];
            TimeSpan totalLength = b.CheckOutDate - b.CheckInDate;
            decimal totalprice;
            if (room.EndPeriodHigherPrice != null && room.StartPeriodHigherPrice != null)
            {
                if (b.CheckInDate > room.StartPeriodHigherPrice && b.CheckOutDate < room.EndPeriodHigherPrice)
                {
                    totalprice = totalLength.Days * room.Price;
                }
                else if(b.CheckInDate < room.StartPeriodHigherPrice && b.CheckOutDate > room.StartPeriodHigherPrice && b.CheckOutDate < room.EndPeriodHigherPrice)
                {
                    TimeSpan TimeInHigherPricePeriod = b.CheckOutDate - room.StartPeriodHigherPrice.Value;
                    TimeSpan TimeInLowerPricePeriod = totalLength - TimeInHigherPricePeriod;
                    totalprice = (TimeInHigherPricePeriod.Days * room.Price) + (TimeInLowerPricePeriod.Days * room.MinPrice);
                }
                else if (b.CheckInDate > room.StartPeriodHigherPrice && b.CheckInDate < room.EndPeriodHigherPrice && b.CheckOutDate > room.EndPeriodHigherPrice)
                {
                    TimeSpan TimeInHigherPricePeriod = room.EndPeriodHigherPrice.Value - b.CheckInDate;
                    TimeSpan TimeInLowerPricePeriod = totalLength - TimeInHigherPricePeriod;
                    totalprice = (TimeInHigherPricePeriod.Days * room.Price) + (TimeInLowerPricePeriod.Days * room.MinPrice);
                }
                else
                {
                    TimeSpan TimeInHigherPricePeriod = room.EndPeriodHigherPrice.Value - room.StartPeriodHigherPrice.Value;
                    TimeSpan TimeInLowerPricePeriod = totalLength = TimeInHigherPricePeriod;
                    totalprice = (TimeInHigherPricePeriod.Days * room.Price) + (TimeInLowerPricePeriod.Days * room.MinPrice);
                }
            }
            else
            {
                totalprice = totalLength.Days * room.MinPrice;
            }
            b.TotalPrice = totalprice;

            return View(b);
        }

        [HttpPost]
        public ActionResult ShowPrice(Boeking boeking)
        {
            boekingRepository.Add(boeking);
            return RedirectToAction("Index", "Start");
        }

        public ActionResult NotFree()
        {
            return View();
        }
    }
}

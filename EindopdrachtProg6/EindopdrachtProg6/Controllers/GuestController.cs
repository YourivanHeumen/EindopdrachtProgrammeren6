using DomainModel;
using DomainModel.Interfaces;
using DomainModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EindopdrachtProg6.Controllers
{
    public class GuestController : Controller
    {
        private IGuestRepository guestRepository = new GuestRepository();

        public ActionResult List()
        {
            IEnumerable<Guest> guests = guestRepository.GetAll();
            return View(guests);
        }

        public ActionResult Edit(int id)
        {
            var guest = guestRepository.GetById(id);
            if (guest == null)
            {
                return HttpNotFound();
            }
            return View(guest);
        }

       

        [HttpPost]
        public ActionResult Edit(Guest guest)
        {
            if (ModelState.IsValid)
            {
                guestRepository.Edit(guest);
                return RedirectToAction("List");
            }
            return View();
        }

        public ActionResult Create(int id)
        {
            var guest = new Guest();
            guest.ToBookRoomId = id;
            return View(guest);
        }
        

        [HttpPost]
        public ActionResult Create(Guest guest)
        {
            if (ModelState.IsValid)
            {
                var g = guest;
                TempData["Guest"] = g;
                guestRepository.Add(g);
                return RedirectToAction("Create", "Boeking");
            }
            return View();
        }

        public ActionResult AlreadyGuest(int roomId)
        {
            var guest = new Guest();
            guest.ToBookRoomId = roomId;
            return View(guest);
        }

        [HttpPost]
        public ActionResult AlreadyGuest(Guest guest)
        {
            if (ModelState.IsValid)
            {
                Guest dbGuest = guestRepository.CheckIfGuestExist(guest);
                if (dbGuest != null)
                {
                    dbGuest.ToBookRoomId = guest.ToBookRoomId.Value;
                    TempData["Guest"] = dbGuest;
                    return RedirectToAction("Create", "Boeking");
                }

                return View();
            }
            return View();
        }
    }
}

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
    public class RoomController : Controller
    {
        private IRoomRepository roomRepository = new RoomRepository();

        public ActionResult List()
        {
            IEnumerable<Room> rooms = roomRepository.GetAll();
            return View(rooms);
        }

        public ActionResult Create()
        {
            var room = new Room();
            return View(room);
        }

        [HttpPost]
        public ActionResult Create(Room room)
        {
            if (ModelState.IsValid)
            {
                roomRepository.Add(room);
                return RedirectToAction("List");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var room = roomRepository.GetById(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        [HttpPost]
        public ActionResult Edit(Room room)
        {
            if (ModelState.IsValid)
            {
                roomRepository.Edit(room);
                return RedirectToAction("List");
            }
            return View();
        }

        public ActionResult SetHigherPrice(int id)
        {
            var room = roomRepository.GetById(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        [HttpPost]
        public ActionResult SetHigherPrice(Room room)
        {
            if (ModelState.IsValid)
            {
                var oldRoom = roomRepository.GetById(room.RoomId);
                oldRoom.StartPeriodHigherPrice = room.StartPeriodHigherPrice;
                oldRoom.EndPeriodHigherPrice = room.EndPeriodHigherPrice;
                roomRepository.Edit(oldRoom);
                return RedirectToAction("List");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var room = roomRepository.GetById(id);
            return View(room);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                roomRepository.Delete(Convert.ToInt32(id));
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Detail(int id)
        {
            var room = roomRepository.GetById(id);
            return View(room);
        }

        public ActionResult RedirectToGuest(int id)
        {
            return RedirectToAction("AlreadyGuest", "Guest", new { roomId = id });
        }

        public ActionResult GetBookedRoom()
        {
            var boeking = (Boeking)TempData["Boeking"];
            var room = roomRepository.GetById(boeking.RoomId);
            TempData["r"] = room;
            TempData["b"] = boeking;
            return RedirectToAction("ShowPrice", "Boeking");
        }

    }
}

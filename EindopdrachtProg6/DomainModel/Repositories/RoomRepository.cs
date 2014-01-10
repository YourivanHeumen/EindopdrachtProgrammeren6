using DomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DomainModel.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private RoomContext context;

        public RoomRepository()
        {
            context = new RoomContext();
            Database.SetInitializer<RoomContext>(null);
        }

        public IEnumerable<Room> GetAll()
        {
            return context.Rooms.ToList();
        }

        public Room GetById(int id)
        {
            return context.Rooms.Where(p => p.RoomId == id).FirstOrDefault();
        }

        public void Add(Room room)
        {
            context.Rooms.Add(room);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var room = this.GetById(id);
            if (room == null)
            {
                return;
            }

            context.Rooms.Remove(room);
            context.SaveChanges();
        }

        public void Edit(Room room)
        {
            context.Entry(room).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
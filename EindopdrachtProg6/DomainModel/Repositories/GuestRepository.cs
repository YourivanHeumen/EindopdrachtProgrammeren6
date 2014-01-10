using DomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DomainModel.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private GuestContext context;

        public GuestRepository()
        {
            context = new GuestContext();
            Database.SetInitializer<GuestContext>(null);
        }

        public IEnumerable<Guest> GetAll()
        {
            return context.Guests.OrderBy(p => p.LastName);
        }

        public Guest GetById(int id)
        {
            return context.Guests.Where(p => p.GuestId == id).FirstOrDefault();
        }

        public void Add(Guest guest)
        {
            context.Guests.Add(guest);
            context.SaveChanges();
        }

        public void Edit(Guest guest)
        {
            context.Entry(guest).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var guest = this.GetById(id);
            if (guest == null)
            {
                return;
            }

            context.Guests.Remove(guest);
            context.SaveChanges();
        }

        public Guest CheckIfGuestExist(Guest guest)
        {
            return context.Guests.Where(o => o.Name == guest.Name && o.Suffix == guest.Suffix && o.LastName == guest.LastName && o.Email == guest.Email).FirstOrDefault();
        }
    }
}
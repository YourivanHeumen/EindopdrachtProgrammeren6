using DomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DomainModel.Repositories
{
    public class BoekingRepository : IBoekingRepository
    {
        private BoekingContext context;

        public BoekingRepository()
        {
            context = new BoekingContext();
            Database.SetInitializer<BoekingContext>(null);
        }

        public IEnumerable<Boeking> GetAll()
        {
            return context.Boekings.ToList();
        }

        public IEnumerable<Boeking> GetInPeriod(DateTime startDate, DateTime endDate)
        {
            return context.Boekings.Where(o => o.CheckInDate > startDate && o.CheckOutDate < endDate).ToList();
        }

        public Boeking GetById(int id)
        {
            return context.Boekings.Where(p => p.BoekingId == id).FirstOrDefault();
        }

        public void Add(Boeking boeking)
        {
            context.Boekings.Add(boeking);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var boeking = this.GetById(id);
            if (boeking == null)
            {
                return;
            }

            context.Boekings.Remove(boeking);
            context.SaveChanges();
        }

        public bool IsFree(Boeking b)
        {
            IEnumerable<Boeking> boekings = context.Boekings.Where(o => o.RoomId == b.RoomId && (o.CheckInDate < b.CheckOutDate && b.CheckInDate < o.CheckOutDate));

            if (!boekings.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
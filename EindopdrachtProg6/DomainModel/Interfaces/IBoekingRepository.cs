using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Interfaces
{
    public interface IBoekingRepository
    {
        IEnumerable<Boeking> GetAll();
        IEnumerable<Boeking> GetInPeriod(DateTime startDate, DateTime endDate);
        Boeking GetById(int id);
        void Add(Boeking boeking);
        void Delete(int id);
        bool IsFree(Boeking b);
    }
}

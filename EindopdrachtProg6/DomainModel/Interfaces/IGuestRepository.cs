using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Interfaces
{
    public interface IGuestRepository
    {
        IEnumerable<Guest> GetAll();
        Guest GetById(int id);
        void Add(Guest guest);
        void Delete(int id);
        void Edit(Guest guest);
        Guest CheckIfGuestExist(Guest guest);
    }
}

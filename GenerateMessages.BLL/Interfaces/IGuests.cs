using GenerateMessages.Models;
using System.Collections.Generic;

namespace GenerateMessages.BLL.Interfaces
{
    public interface IGuests
    {
        Guest GetSingleGuest(int id);
        List<Guest> GetAllGuests();
    }
}

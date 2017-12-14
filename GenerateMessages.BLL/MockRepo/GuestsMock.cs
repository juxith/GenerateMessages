using GenerateMessages.BLL.Interfaces;
using GenerateMessages.Models;
using System.Collections.Generic;
using System.Linq;

namespace GenerateMessages.BLL.MockRepo
{
    public class GuestsMock : IGuests
    {
        static List<Guest> _listOfGuests = new List<Guest>()
        {
             new Guest
             {
                 Id = 1,
                 FirstName = "Jane",
                 LastName = "Doe",
                 Reservation = new Reservation
                 {
                     RoomNumber = 101,
                     StartTimestamp = 1513785600,
                     EndTimestamp =  1513854000,
                 }
             },
             new Guest
             {
                 Id = 2,
                 FirstName = "John",
                 LastName = "Snow",
                 Reservation = new Reservation
                 {
                     RoomNumber = 330,
                     StartTimestamp = 1513785600,
                     EndTimestamp =  1513854000,
                 }
             },
             new Guest
             {
                 Id = 3,
                 FirstName = "Jack",
                 LastName = "Hill",
                    Reservation = new Reservation
                    {
                        RoomNumber = 101,
                        StartTimestamp = 1513785600,
                        EndTimestamp = 1513854000,
                    }
             },
        };

        public List<Guest> GetAllGuests()
        {
            return _listOfGuests;
        }

        public Guest GetSingleGuest(int id)
        {
            return _listOfGuests.SingleOrDefault(i => i.Id == id);
        }
    }
}

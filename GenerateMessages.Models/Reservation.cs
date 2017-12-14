using System;

namespace GenerateMessages.Models
{
    public class Reservation
    {
        public int RoomNumber { get; set; }
        public int StartTimestamp { get; set; }
        public int EndTimestamp { get; set; }
        public DateTime CheckIn { get => FromUnixTime(StartTimestamp); }
        public DateTime CheckOut { get => FromUnixTime(EndTimestamp); }
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        private DateTime FromUnixTime(long unixTime)
        {
            return epoch.AddSeconds(unixTime);
        }
    }
}

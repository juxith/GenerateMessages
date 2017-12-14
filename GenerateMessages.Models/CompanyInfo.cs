using System;

namespace GenerateMessages.Models
{
    public class CompanyInfo
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string City { get; set; }
        public string Timezone { get; set; }
        public TimeZoneInfo TimeZoneInfo { get => ConvertToTimeZoneInfo();}

        private TimeZoneInfo ConvertToTimeZoneInfo()
        {
            var str = Timezone;
            var split = str.Split('/');
            return TimeZoneInfo.FindSystemTimeZoneById(split[1] + " Standard Time");
        }
    }
}

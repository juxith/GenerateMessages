using System;

namespace GenerateMessages.Models
{
    public static class MessageGreeting
    {
        public static string GetGreeting(DateTime dateTime)
        {
            var greeting = string.Empty;
            TimeSpan timeNow = dateTime.TimeOfDay;

            if (timeNow > new TimeSpan(0, 0, 0) && timeNow < new TimeSpan(12, 0, 0))
            {
                greeting = "Good morning ";
            }
            else if (timeNow > new TimeSpan(12, 0, 0) && timeNow < new TimeSpan(17, 0, 0))
            {
                greeting = "Good afternoon ";
            }
            else
            {
                greeting = "Good evening ";
            }
            return greeting;
        }
    }
}

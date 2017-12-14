using GenerateMessages.BLL.Interfaces;
using GenerateMessages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateMessages.BLL.MockRepo
{
    public class TemplatesMock : ITemplates
    {
        static List<Template> _listOfTemplates = new List<Template>()
       {
                new Template
                {
                    Id = 1,
                    Name = "Welcome",
                    Message= "{Greeting} {FirstName}, and welcome to {Company}! Room {RoomNumber} is now ready for you. Enjoy your stay, and let us know if you need anything."
                },
                new Template
                {
                    Id = 2,
                    Name = "Check-Out",
                    Message = "{Greeting} {FirstName}, as a reminder your check-out time is {Check-Out}. If you'd like to extend or make changes to your stay, I'd be glad to assist you."
                },
                new Template
                {
                    Id = 3,
                    Name = "Follow-Up",
                    Message = "Thank you for staying with us at {Company}, We hope you enjoyed your stay and hope to see you again soon."
                }
        };

        public string GenerateMessage(Guest guest, CompanyInfo companyInfo, Template template)
        {
            var thisTemplate = new StringBuilder();
            thisTemplate.Append(template.Message);
            thisTemplate.Replace("{Greeting}", MessageGreeting.GetGreeting(DateTime.Now));
            thisTemplate.Replace("{FirstName}", guest.FirstName);
            thisTemplate.Replace("{LastName}", guest.LastName);
            thisTemplate.Replace("{RoomNumber}", guest.Reservation.RoomNumber.ToString());
            thisTemplate.Replace("{Check-In}", guest.Reservation.CheckIn.ToString());
            thisTemplate.Replace("{Check-Out}", guest.Reservation.CheckOut.ToString());
            thisTemplate.Replace("{Company}", companyInfo.Company);
            thisTemplate.Replace("{City}", companyInfo.City);
            thisTemplate.Replace("{Timezone}", companyInfo.TimeZoneInfo.ToString());
            return thisTemplate.ToString();
        }
        public List<Template> GetAllTemplates()
        {
            return _listOfTemplates;
        }

        public void AddNewTemplate(Template template)
        {
            template.Id = _listOfTemplates.Max(i => i.Id) + 1;
            _listOfTemplates.Add(template);
        }
        public Template GetSingleTemplate(int id)
        {
            return _listOfTemplates.SingleOrDefault(i => i.Id == id);
        }
    }
}

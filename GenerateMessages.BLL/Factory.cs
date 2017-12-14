using GenerateMessages.BLL.JsonRepo;
using GenerateMessages.BLL.MockRepo;
using System;
using System.Configuration;

namespace GenerateMessages.BLL
{
    public class Factory
    {
        public static Manager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Mock":
                    return new Manager(new GuestsMock(), new CompaniesMock(), new TemplatesMock());
                case "Json":
                    return new Manager(new GuestsJson(@"/JsonFiles/Guests.json"), new CompaniesJson("/JsonFiles/Companies.json"), new TemplatesJson("/JsonFiles/Templates.json"));
                default:
                    throw new Exception("Mode value in app config is not valid.");
            }
        }
    }
}

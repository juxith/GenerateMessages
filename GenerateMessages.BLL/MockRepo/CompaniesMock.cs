using GenerateMessages.BLL.Interfaces;
using GenerateMessages.Models;
using System.Collections.Generic;
using System.Linq;

namespace GenerateMessages.BLL.MockRepo
{
    public class CompaniesMock : ICompanies
    {
        static List<CompanyInfo> _listOfCompanies = new List<CompanyInfo>()
        {
            new CompanyInfo
            {
                Id = 1,
                Company = "Hardrock Hotel",
                City = "Los Angelas",
                Timezone = "US/Pacific"
            },
            new CompanyInfo
            {
               Id = 2,
               Company = "Grand Central Hotel",
               City = "Minneapolis",
               Timezone = "US/Central"
            },
            new CompanyInfo
            {
                Id = 3,
                Company = "SunnysIde Hotel",
                City = "Miami",
                Timezone = "US/Eastern"
            }
        };

        public List<CompanyInfo> GetAllCompanies()
        {
            return _listOfCompanies;
        }

        public CompanyInfo GetSingleCompany(int id)
        {
            return _listOfCompanies.SingleOrDefault(i => i.Id == id);
        }
    }
}

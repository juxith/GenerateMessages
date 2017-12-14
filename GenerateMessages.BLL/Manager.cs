using GenerateMessages.BLL.Interfaces;
using GenerateMessages.Models;
using System.Collections.Generic;

namespace GenerateMessages.BLL
{
    public class Manager
    {
        private IGuests _guests;
        private ICompanies _companies;
        private ITemplates _templates;

        public Manager(IGuests guests, ICompanies companies, ITemplates templates)
        {
            _guests = guests;
            _companies = companies;
            _templates = templates;
        }

        public List<Guest> LoadAllGuests()
        {
            return _guests.GetAllGuests();
        }

        public Guest LoadGuest(int id)
        {
            return _guests.GetSingleGuest(id);
        }

        public List<CompanyInfo> LoadAlCompanies()
        {
            return _companies.GetAllCompanies();
        }

        public CompanyInfo LoadCompany(int id)
        {
            return _companies.GetSingleCompany(id);
        }

        public List<Template> LoadAllTemplates()
        {
            return _templates.GetAllTemplates();
        }

        public Template LoadTemplate(int id)
        {
            return _templates.GetSingleTemplate(id);
        }

        public void CreateTemplate(Template template)
        {
            _templates.AddNewTemplate(template);
        }

        public string LoadMessage(Guest guest, CompanyInfo company, Template template)
        {
            return _templates.GenerateMessage(guest, company, template);
        }
    }
}

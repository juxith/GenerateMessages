using GenerateMessages.Models;
using System.Collections.Generic;

namespace GenerateMessages.BLL.Interfaces
{
    public interface ITemplates
    {
        Template GetSingleTemplate(int id);
        List<Template> GetAllTemplates();
        void AddNewTemplate(Template template);
        string GenerateMessage(Guest guest, CompanyInfo companyInfo, Template template);
    }
}

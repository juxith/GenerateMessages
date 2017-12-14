using GenerateMessages.Models;
using System.Collections.Generic;

namespace GenerateMessages.BLL.Interfaces
{
    public interface ICompanies
    {
        CompanyInfo GetSingleCompany(int id);
        List<CompanyInfo> GetAllCompanies();
    }
}

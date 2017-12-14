using GenerateMessages.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using GenerateMessages.Models;
using Newtonsoft.Json;
using System.IO;
using System.Web;

namespace GenerateMessages.BLL.JsonRepo
{
    public class CompaniesJson : ICompanies
    {
        private List<CompanyInfo> _listOfCompanies = new List<CompanyInfo>();
        private string _path;
        string fullPath;
        public CompaniesJson(string path)
        {
            _path = path;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var rootPath = HttpContext.Current.Server.MapPath("~");
                DirectoryInfo dir = new DirectoryInfo(rootPath);
                fullPath = dir.Parent.FullName + _path;

                using (StreamReader reader = new StreamReader(fullPath))
                {
                    string json = reader.ReadToEnd();
                    _listOfCompanies = JsonConvert.DeserializeObject<List<CompanyInfo>>(json);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to read file " + fullPath, ex);
            }
        }

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

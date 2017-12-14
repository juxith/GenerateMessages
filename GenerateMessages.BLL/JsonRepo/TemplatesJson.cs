using GenerateMessages.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GenerateMessages.Models;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web;

namespace GenerateMessages.BLL.JsonRepo
{
    public class TemplatesJson : ITemplates
    {
        private List<Template> _listOfTemplates = new List<Template>();
        private static string _path;
        string fullPath;
        public TemplatesJson(string path)
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
                    _listOfTemplates = JsonConvert.DeserializeObject<List<Template>>(json);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to read from file " + fullPath, ex);
            }
        }

        public void AddNewTemplate(Template template)
        {
            var nameExists =_listOfTemplates.Select(n => n.Name == template.Name);

            template.Id = _listOfTemplates.Max(i => i.Id) + 1;
            _listOfTemplates.Add(template);
            WriteToFile();
        }

        private void WriteToFile()
        {
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath))
                {
                    var json = JsonConvert.SerializeObject(_listOfTemplates.ToArray(), Formatting.Indented, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                    sw.Write(json);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to write to file " + fullPath, ex);
            }
        }

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

        public Template GetSingleTemplate(int id)
        {
            return _listOfTemplates.SingleOrDefault(i => i.Id == id);
        }
    }
}

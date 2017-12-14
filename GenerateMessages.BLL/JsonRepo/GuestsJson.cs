using GenerateMessages.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using GenerateMessages.Models;
using System.IO;
using Newtonsoft.Json;
using System.Web;

namespace GenerateMessages.BLL.JsonRepo
{
    public class GuestsJson : IGuests
    {
        private List<Guest> _listOfGuests = new List<Guest>();
        private static string _path;
        string fullPath;
        public GuestsJson(string path)
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
                    _listOfGuests = JsonConvert.DeserializeObject<List<Guest>>(json);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to read file " + fullPath, ex);
            }
        }

        public List<Guest> GetAllGuests()
        {
            return _listOfGuests;
        }

        public Guest GetSingleGuest(int id)
        {
            return _listOfGuests.SingleOrDefault(i => i.Id == id);
        }
    }
}

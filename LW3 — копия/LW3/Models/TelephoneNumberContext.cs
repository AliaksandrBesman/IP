using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace LW3.Models
{
    public class TelephoneNumberContext
    {

        private string path;
        private string json;
        private List<TelephoneNumber> telephoneNumberList;

        public TelephoneNumberContext()
        {
            path = AppDomain.CurrentDomain.BaseDirectory + @"\App_Data\PhoneBook.json";
            json = File.ReadAllText(path);
            telephoneNumberList = JsonConvert.DeserializeObject<List<TelephoneNumber>>(json) ?? new List<TelephoneNumber>();

        }

        public List<TelephoneNumber> getAll()
        {
            return telephoneNumberList;
        }
    }
}
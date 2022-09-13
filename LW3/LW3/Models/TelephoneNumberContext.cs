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

        public List<TelephoneNumber> GetAll()
        {
            return telephoneNumberList;
        }

        public TelephoneNumber Create(TelephoneNumber telephoneNumber)
        {
            telephoneNumberList.Sort((v1,v2)=> v1.Id.CompareTo(v2.Id));
            var lastRecord = telephoneNumberList.FindLast(r => true);
            if (lastRecord != null)
                telephoneNumber.Id = lastRecord.Id + 1;
            telephoneNumberList.Add(telephoneNumber);
            File.WriteAllText(path, JsonConvert.SerializeObject(telephoneNumberList));
            return telephoneNumber;

        }

        public TelephoneNumber Update(TelephoneNumber telephoneNumber)
        {
            var index = telephoneNumberList.FindIndex(r => r.Id == telephoneNumber.Id);
            telephoneNumberList[index] = telephoneNumber;
            File.WriteAllText(path, JsonConvert.SerializeObject(telephoneNumberList));
            return telephoneNumber;

        }

        public TelephoneNumber Delete(int id)
        {
            var telephoneNumber = telephoneNumberList.Find(r => r.Id == id);
            telephoneNumberList.Remove(telephoneNumber);
            File.WriteAllText(path, JsonConvert.SerializeObject(telephoneNumberList));
            return telephoneNumber;
        }

        public TelephoneNumber Find(int id)
        {
            return telephoneNumberList.Find(r => r.Id == id);
        }
    }
}
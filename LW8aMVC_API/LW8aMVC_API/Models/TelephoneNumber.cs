using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LW8aMVC_API.Models
{
    public class TelephoneNumber
    {
        // ID записи
        public int Id { get; set; }
        // ФИО 
        public string Name { get; set; }
        // Телефон
        public string PhoneNumber { get; set; }
    }
}

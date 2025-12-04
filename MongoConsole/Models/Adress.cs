using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoConsole.Models
{
    public class Adress
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }


        //public Adress(string street, string city, string, string state, string zip)
        //{
        //    Street = street;
        //    City = city;
        //    State = state;
        //    ZipCode = zip;
        //}
    }
}

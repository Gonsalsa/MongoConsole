using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoConsole.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Adress UserAdress { get; set; }
    }
}

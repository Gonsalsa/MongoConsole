using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoConsole.Models
{
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Adress UserAdress { get; set; }

        //public UserModel(string name, int age, Adress uAdress)
        //{
        //    Name = name;
        //    Age = age;
        //    UserAdress = uAdress;
        //}


    }
}

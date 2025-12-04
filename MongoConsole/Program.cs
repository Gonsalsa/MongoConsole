using MongoConsole.Data;
using MongoConsole.Models;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MongoConsole
{
    internal class Program
    {



        static async Task Main(string[] args)
        {

            await AddUser();
            await GetAllUsers();
        }

        static async Task<string> AddUser()
        {
            MongoCRUD service = new MongoCRUD("UserModel");

            UserModel user = new UserModel
            {
                Name = "Sebastian",
                Age = 23,
                UserAdress = new Adress
                {
                    Street = "Västergatan",
                    City = "Forsheda",
                    State = "Småland",
                    ZipCode = "33171"
                }
            };

            await service.AddUser("Users", user);
            return "User was created";
        }

        static async Task GetAllUsers()
        {
            MongoCRUD service = new MongoCRUD("UserModel");

            Console.WriteLine("all Users");
            var users = await service.GetAllUsers("Users");
            foreach(var user in users)
            {
                Console.WriteLine(user.Name);
            }
        }


    }
}

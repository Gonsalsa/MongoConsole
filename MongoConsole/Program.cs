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

            await FullExtermination("Users");
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

        static async Task <UserModel> GetById (string userId)
        {
            MongoCRUD service = new MongoCRUD("Usermodel");
            var findUser = await service.GetUserById("User", userId);
            return findUser;
        }

        static async Task <UserModel> UpdateUser(UserModel user)
        {
            MongoCRUD service = new MongoCRUD("UserModel");
            return await service.UpdateUser("User", user.Id, user);
        }

        static async Task<string> DeleteUser (UserModel user)
        {
            MongoCRUD service = new MongoCRUD("UserModel");
            var UserToDelete = await service.RemoveUser("User", user.Id);
            return UserToDelete;
        }
    
        static async Task<string> FullExtermination (string table)
        {
            MongoCRUD service = new MongoCRUD("UserModel");

            var Targets = await service.DeleteAll(table);

            return "All is gone";
        }
    }
}

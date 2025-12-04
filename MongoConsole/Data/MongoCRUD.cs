using MongoConsole.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MongoConsole.Data
{
    public class MongoCRUD
    {
        private IMongoDatabase db;

        public MongoCRUD(string database)
        {
            var client = new MongoClient();
            db = client.GetDatabase(database);
        }

        //Full CRUD

        //CREATE
        public async Task<UserModel> AddUser(string table, UserModel user)
        {
            var collection = db.GetCollection<UserModel>(table);
            await collection.InsertOneAsync(user);
            return user;
        }

        // READ
        public async Task<List<UserModel>> GetAllUsers(string table)
        {
            var collection = db.GetCollection<UserModel>(table);
            var users = await collection.AsQueryable().ToListAsync();
            return users;

        }

        public async Task<UserModel> GetUserById(string table, string id)
        {
            var collection = db.GetCollection<UserModel>(table);
            var user = await collection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return user;
        }

        // UPDATE

        public async Task<UserModel> UpdateUser(string table, string id, UserModel UpdatedUser)
        {
            var collection = db.GetCollection<UserModel>(table);

            UpdatedUser.Id = id;

            var result = await collection.ReplaceOneAsync(x => x.Id == id, UpdatedUser);

            if (result.MatchedCount == 0)
            {
                return null;
            }

            return UpdatedUser;
        }

        //DELETE

        public async Task<string> RemoveUser(string table, string id)
        {
            var collection = db.GetCollection<UserModel>(table);
            var user = await collection.DeleteOneAsync(x => x.Id == id);
            return "User was deleted";
        }
    }
}

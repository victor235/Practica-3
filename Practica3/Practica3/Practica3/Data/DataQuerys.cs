using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Practica3.Models;
using System.Threading.Tasks;

namespace Practica3.Data
{
    public class DataQuerys
    {
        readonly SQLiteAsyncConnection database;

        public DataQuerys(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);


            database.CreateTableAsync<UserModel>().Wait();
        }

        public Task<UserModel> GetUser(int id)
        {
            return database.Table<UserModel>().Where(i => i.UserID == id).FirstOrDefaultAsync();

        }

        public Task<List<UserModel>> GetUsers()
        {
            return database.Table<UserModel>().ToListAsync();
        }
        public Task<int> SaveUser(UserModel user)
        {
            if( user.UserID != 0)
            {
                return database.UpdateAsync(user);
            }
            else
            {
                return database.InsertAsync(user);
            }
        }

        public Task<int> DeleteUser(UserModel user)
        {
            return database.DeleteAsync(user);
        }

        public Task<List<UserModel>> GetUsersAndValidate(string email, string password)
        {
            return database.QueryAsync<UserModel>("SELECT * FROM UserModel WHERE Email = '" + email + "'AND Password = '" + password + "'" );
        }
    }
}

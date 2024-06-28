using SmartWorkout.DBAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkout.DBAccess.Repository
{
    public interface IUserRepository : IDisposable
    {
        public Task<User[]> GetUsers();
        public Task<User?> GetUserById(int id);
        public void AddUser(User user);
        public void DeleteUser(int userID);
        public void UpdateUser(User user);
        public void Save();
    }
}

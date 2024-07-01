using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartWorkout.DBAccess.Entities;
namespace SmartWorkout.DBAccess.Repository
{
    [Obsolete("Replaced by generic repo")]
    public class UserRepository : IUserRepository, IDisposable
    {
        private SmartWorkoutContext context;
        public UserRepository(SmartWorkoutContext context)
        {
            this.context = context; 
        }
        public async Task<User[]> GetUsers()
        {
            return await context.Users.ToArrayAsync<User>();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await context.Users.FindAsync(id);
        }

        public void DeleteUser(int userID)
        {
            User? user = context.Users.Find(userID);
            if(user!=null)
            {
                context.Users.Remove(user);
            }
        }
        public void UpdateUser(User user)
        {
            context.Entry(user).State=EntityState.Modified;
        }
        public void AddUser(User user)
        {
            context.Users.Add(user);
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using SmartWorkout.DBAccess.Entities;
namespace SmartWorkout.DBAccess.Repository
{
    //[Obsolete("Replaced by generic repo")]
    public class UserRepository : IGenericRepository<User>, IDisposable
    {
        private SmartWorkoutContext context;
        public UserRepository(SmartWorkoutContext context)
        {
            this.context = context;
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

        public Task<User[]> GetItemsAsync()
        {
            return context.Set<User>().ToArrayAsync<User>();
        }
        public User[] GetItems()
        {
            return context.Set<User>().ToArray<User>();
        }
        public async Task<User?> GetItemByIdAsync(int id)
        {
            return await context.Set<User>().FindAsync(id);
        }
        public User? GetItemById(int id)
        {
            return context.Set<User>().Find(id);
        }
        public void AddItem(User item)
        {
            context.Set<User>().Add(item);
        }

        public void DeleteItem(int id, int? comp = null)
        {
            User? item;
            if (comp == null)
            {
                item = context.Set<User>().Find(id);
            }
            else
            {
                item = context.Set<User>().Find(id, comp);
            }
            if (item != null)
            {
                context.Set<User>().Remove(item);
            }
        }

        public void UpdateItem(User item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public User? GetUserByEmail(String? email)
        {
            if (email is null) return null;
            return context.Set<User>().Where(x=>x.Email == email).FirstOrDefault();
        }
        public Task<User[]> GetUsersByTrainer(int id)
        {
            return context.Set<User>().Where(u=>u.TrainerId == id).ToArrayAsync<User>();
        }
    }
}
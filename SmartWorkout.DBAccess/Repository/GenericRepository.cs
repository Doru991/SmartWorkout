using Microsoft.EntityFrameworkCore;
using SmartWorkout.DBAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkout.DBAccess.Repository
{
    public class GenericRepository<T> : IGenericRepository<T>, IDisposable where T : class
    {
        private SmartWorkoutContext context;
    public GenericRepository(SmartWorkoutContext context)
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

        public Task<T[]> GetItems()
        {
            return context.Set<T>().ToArrayAsync<T>();
        }

        public Task<T?> GetItemById(int id)
        {
            throw new NotImplementedException();
        }

        public void AddItem(T item)
        {
            context.Set<T>().Add(item);
        }

        public void DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(T item)
        {
            throw new NotImplementedException();
        }
    }
}
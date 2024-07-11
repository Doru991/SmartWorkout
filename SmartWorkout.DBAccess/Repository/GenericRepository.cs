using Microsoft.EntityFrameworkCore;
using SmartWorkout.DBAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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

        public Task<T[]> GetItemsAsync()
        {
            return context.Set<T>().ToArrayAsync<T>();
        }
        public T[] GetItems()
        {
            return context.Set<T>().ToArray<T>();
        }
        public async Task<T?> GetItemByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }
        public T? GetItemById(int id)
        {
            return context.Set<T>().Find(id);
        }
        public void AddItem(T item)
        {
            context.Set<T>().Add(item);
        }

        public void DeleteItem(int id, int? comp = null)
        {
            T? item;
            if (comp == null)
            {
                item = context.Set<T>().Find(id);
            }
            else
            {
                item = context.Set<T>().Find(id, comp);
            }
            if (item != null)
            {
                context.Set<T>().Remove(item);
            }
        }

        public void UpdateItem(T item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
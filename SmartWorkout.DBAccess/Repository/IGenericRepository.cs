﻿using SmartWorkout.DBAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkout.DBAccess.Repository
{
    public interface IGenericRepository<T> : IDisposable where T : class
    {
        public Task<T[]> GetItemsAsync();
        public T[] GetItems();
        public Task<T?> GetItemByIdAsync(int id);
        public T? GetItemById(int id);
        public void AddItem(T item);
        public void DeleteItem(int id, int? comp = null);
        public void UpdateItem(T item);
        public void Save();
    }
}

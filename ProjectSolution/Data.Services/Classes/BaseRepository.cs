﻿using Data.Connection;
using Data.Models.Models;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Classes
{
    public class BaseRepository<T> : BaseContext, IBaseRepository<T> where T : BaseModel
    {
        public BaseRepository(AmazonDbContext context) : base(context)
        {
            this.DbSet = context.Set<T>();
        }

        protected DbSet<T> DbSet { get; set; }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
            {
                return DbSet.Where(filter);
            }

            return DbSet;
        }

        public T GetById(string id)
        {
            return DbSet.Find(id);
        }

        public void Insert(T entity)
        {
            DbSet.Add(entity);
        }

        public async Task InsertAndSaveAsync(T entity)
        {
            Insert(entity);

            await SaveChangesAsync();
        }

        public void Remove(string id)
        {
            var entity = GetById(id);

            if (entity == null)
                throw new ArgumentException();

            entity.IsDeleted = true;
        }

        public async Task RemoveAndSaveAsync(string id)
        {
            Remove(id);

            await SaveChangesAsync();
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentException();

            var itemFromDB = GetById(entity.Id);

            Context.Entry(itemFromDB).State = EntityState.Detached;
            Context.Entry(entity).State = EntityState.Modified;
        }

        public async Task UpdateAndSaveAsync(T entity)
        {
            Update(entity);

            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}


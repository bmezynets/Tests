﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TopTests.DAL.Interfaces;

namespace TopTests.DAL.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public ApplicationDbContext context;
        private readonly DbSet<T> entities;
        public RepositoryBase(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public void Create(T entity)
        {
            entities.Add(entity);
        }

        public void Delete(T entity)
        {
            entities.Remove(entity);
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            var result = await entities.ToListAsync();
            return result;
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await entities.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            entities.Update(entity);
        }
    }
    }

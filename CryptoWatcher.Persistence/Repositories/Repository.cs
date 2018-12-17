﻿using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CryptoWatcher.Persistence.Contexts;
using CryptoWatcher.Shared.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CryptoWatcher.Domain.Models;

namespace CryptoWatcher.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly DbSet<TEntity> _dbSet;

        public Repository(MainDbContext mainDbContext)
        {
            _dbSet = mainDbContext.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAll()
        {
            // Get all
            return await _dbSet.ToListAsync();
        }
        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression)
        {
            // Get all by expression
            return await _dbSet.Where(expression).ToListAsync();
        }
        public async Task<List<TEntity>> GetAllNewest()
        {
            // Get newest
            var query = from n in _dbSet
                group n by n.Id into g
                select g.OrderByDescending(t => t.CreationTime).FirstOrDefault();

            // REturn
            return await query.ToListAsync();
        }
        public async Task<TEntity> GetSingle(string id)
        {
            // Get by id
            return await _dbSet.FindAsync(id);
        }
        public async Task<TEntity> GetSingle(Expression<Func<TEntity, bool>> expression)
        {
            // Get single by expression
            return await _dbSet.FirstOrDefaultAsync(expression);
        }
        public void Add(TEntity entity)
        {
            // Add
            _dbSet.Add(entity);
        }
        public void AddRange(List<TEntity> entities)
        {
            // Return if no entities
            if (entities.Count == 0) return;

            // Add range
            _dbSet.AddRange(entities);
        }
        public void Update(TEntity entity)
        {
            
        }
        public void UpdateRange(List<TEntity> entities)
        {
           
        }
        public void Remove(TEntity entity)
        {
            // Remove
            _dbSet.Remove(entity);
        }
        public void RemoveRange(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Remove(entity);
            }
        }
    }
}

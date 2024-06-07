﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeSystem.DAL.Interfaces;
using CoffeeSystem.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace CoffeeSystem.DAL.Implementacion
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbcoffeeSystemContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(DbcoffeeSystemContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }       

        public async Task<TEntity> Obtener(Expression<Func<TEntity, bool>> filtro)
        {
            try
            {
                TEntity entidad = await _dbSet.FirstOrDefaultAsync(filtro);
                return entidad;
            }
            catch
            {
                throw;
            }                
            
        }

        public async Task<TEntity> Crear(TEntity entidad)
        {
            try
            {
                _dbSet.Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(TEntity entidad)
        {
            try
            {
                _dbContext.Update(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(TEntity entidad)
        {
            try
            {
                _dbContext.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IQueryable<TEntity>> Consultar(Expression<Func<TEntity, bool>> filtro = null)
        {
            IQueryable<TEntity> queryEntidad = filtro == null? _dbSet : _dbSet.Where(filtro);

            return queryEntidad;
        }
    }   
    
}

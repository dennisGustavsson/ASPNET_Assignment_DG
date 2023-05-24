﻿using EcomWebApp.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EcomWebApp.Helpers.Repos.ProductRepo
{
	public abstract class Repository<TEntity> where TEntity : class
	{
		private readonly DataContext _context;

		protected Repository(DataContext context)
		{
			_context = context;
		}

		public virtual async Task<TEntity> AddAsync(TEntity entity)
		{

				_context.Set<TEntity>().Add(entity);
				await _context.SaveChangesAsync();
				return entity;

		}


		public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
		{
			var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
			if (entity != null)
			{
				return entity;
			}
			return null!;
		}


        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			try
			{
				return await _context.Set<TEntity>().ToListAsync();
			} catch { return null!; }

		}

		public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
		{
			try
			{
			return await _context.Set<TEntity>().Where(expression).ToListAsync();
			} catch { return null!; }

		}

		public virtual async Task<TEntity> UpdateAsync(TEntity entity)
		{
			try
			{
				_context.Set<TEntity>().Update(entity);
				await _context.SaveChangesAsync();
				return entity;
			} catch { return null!; }

		}

		public virtual async Task<bool> DeleteAsync(TEntity entity)
		{
			try
			{
				_context.Set<TEntity>().Remove(entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch { }
			return false;
		}
	}
}

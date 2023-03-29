﻿using Application.Common.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
  public class GenericRepository<T>
    : IGenericRepository<T> where T : class
  {
    private readonly BookMeetsDbContext _context;

    public GenericRepository(BookMeetsDbContext context)
    {
      _context = context;
    }
    public async Task<T> AddAsync(T entity)
    {
      await _context.AddAsync(entity);
      await _context.SaveChangesAsync();
      return entity;
    }

    public async Task DeleteAsync(T entity)
    {
      _context.Set<T>().Remove(entity);
      await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
      var entity = await GetAsync(id);
      return entity != null;
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
      return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetAsync(int id)
    {
      return await _context.Set<T>().FindAsync(id);
    }

    public async Task UpdateAsync(T entity)
    {
      _context.Entry(entity).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }
  }
}

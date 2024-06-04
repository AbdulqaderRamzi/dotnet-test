﻿using System.Linq.Expressions;
using CRUDHistory.DataAccess.Data;
using CRUDHistory.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CRUDHistory.DataAccess.Repository;

public class Repository<T> : IRepository<T> where T : class {
    private readonly ApplicationDbContext _db;
    private DbSet<T> _dbSet;
    private static readonly char[] _splitor = [','];

    public Repository(ApplicationDbContext db){
        _db = db;
        _dbSet = _db.Set<T>();
    }

    public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null){
        IQueryable<T> query = filter is not null ? _dbSet.Where(filter) : _dbSet;
        if (!string.IsNullOrEmpty(includeProperties)){
            var properties = includeProperties.
                Split(_splitor, StringSplitOptions.RemoveEmptyEntries);
            foreach (var property in properties){
                query = query.Include(property);
            }
        }
        return query.ToList();
    }

    public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool isTracked = true){
        IQueryable<T> query;
        if (isTracked) query = _dbSet;
        else query = _dbSet.AsNoTracking();
        query = query.Where(filter);
        if (!string.IsNullOrEmpty(includeProperties)){
            var properties = includeProperties.
                Split(_splitor, StringSplitOptions.RemoveEmptyEntries);
            foreach (var property in properties){
                query = query.Include(property);
            }
        }
        return query.FirstOrDefault();
    }

    public void Add(T entity) => _dbSet.Add(entity);    

    public void Remove(T entity) => _dbSet.Remove(entity);

    public void RemoveRange(IEnumerable<T> entities) => _dbSet.RemoveRange(entities);
    
}
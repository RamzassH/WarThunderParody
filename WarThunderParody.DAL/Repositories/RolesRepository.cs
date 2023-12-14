﻿using WarThunderParody.DAL.Interfaces;

namespace WarThunderParody.DAL.Repositories;

public class RolesRepository : IBaseRepository<Role>
{
    private readonly WarThunderShopContext _db;
    public RolesRepository(WarThunderShopContext db)
    {
        _db = db;
    }
    public async Task<bool> Create(Role entity)
    {
        await _db.Roles.AddAsync(entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public IQueryable<Role> GetAll()
    {
        return _db.Roles;
    }

    public async Task<Role> Update(Role entity)
    { 
        _db.Roles.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(Role entity)
    { 
        _db.Roles.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }
}
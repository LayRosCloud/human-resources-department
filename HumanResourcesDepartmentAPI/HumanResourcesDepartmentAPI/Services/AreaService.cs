using HumanResourcesDepartmentAPI.Data;
using HumanResourcesDepartmentAPI.Models;
using HumanResourcesDepartmentAPI.Scripts.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesDepartmentAPI.Services;

public class AreaService: IService<AreaEntity, int>
{
    private readonly DatabaseHelper _databaseConnection;

    public AreaService()
    {
        _databaseConnection = new DatabaseHelper();
    }

    public async Task<AreaEntity> Create(AreaEntity item)
    {
        var response = _databaseConnection.areas.Add(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }

    public async Task<AreaEntity> Delete(int id)
    {
        var item = await Find(id);
        var response = _databaseConnection.areas.Remove(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }

    public async Task<AreaEntity> Find(int id)
    {
        var response = await _databaseConnection.areas.FirstOrDefaultAsync(x=>x.id == id);

        if(response == null)
        {
            throw new NotFoundException($"Объект с {id} не найден");
        }
        return response;
    }

    public async Task<List<AreaEntity>> FindAll()
    {
        var response = await _databaseConnection.areas.ToListAsync();
        return response;
    }

    public async Task<AreaEntity> Update(AreaEntity item)
    {
        var response = _databaseConnection.areas.Update(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }
}
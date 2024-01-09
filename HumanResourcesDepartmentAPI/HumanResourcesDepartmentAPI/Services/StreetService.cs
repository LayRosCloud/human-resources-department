using HumanResourcesDepartmentAPI.Data;
using HumanResourcesDepartmentAPI.Models;
using HumanResourcesDepartmentAPI.Scripts.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesDepartmentAPI.Services;

public class StreetService: IService<StreetEntity, int>
{
    private readonly DatabaseHelper _databaseConnection;

    public StreetService()
    {
        _databaseConnection = new DatabaseHelper();
    }

    public async Task<StreetEntity> Create(StreetEntity item)
    {
        var response = _databaseConnection.streets.Add(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }

    public async Task<StreetEntity> Delete(int id)
    {
        var item = await Find(id);
        var response = _databaseConnection.streets.Remove(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }

    public async Task<StreetEntity> Find(int id)
    {
        var response = await _databaseConnection.streets.FirstOrDefaultAsync(x=>x.id == id);

        if(response == null)
        {
            throw new NotFoundException($"Объект с {id} не найден");
        }
        return response;
    }

    public async Task<List<StreetEntity>> FindAll()
    {
        var response = await _databaseConnection.streets.ToListAsync();
        return response;
    }

    public async Task<StreetEntity> Update(StreetEntity item)
    {
        var response = _databaseConnection.streets.Update(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }
}
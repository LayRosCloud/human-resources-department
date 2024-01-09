using HumanResourcesDepartmentAPI.Data;
using HumanResourcesDepartmentAPI.Models;
using HumanResourcesDepartmentAPI.Scripts.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesDepartmentAPI.Services;

public class CityService: IService<CityEntity, int>
{
    private readonly DatabaseHelper _databaseConnection;

    public CityService()
    {
        _databaseConnection = new DatabaseHelper();
    }

    public async Task<CityEntity> Create(CityEntity item)
    {
        var response = _databaseConnection.cities.Add(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }

    public async Task<CityEntity> Delete(int id)
    {
        var item = await Find(id);
        var response = _databaseConnection.cities.Remove(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }

    public async Task<CityEntity> Find(int id)
    {
        var response = await _databaseConnection.cities.FirstOrDefaultAsync(x=>x.id == id);

        if(response == null)
        {
            throw new NotFoundException($"Объект с {id} не найден");
        }
        return response;
    }

    public async Task<List<CityEntity>> FindAll()
    {
        var response = await _databaseConnection.cities.ToListAsync();
        return response;
    }

    public async Task<CityEntity> Update(CityEntity item)
    {
        var response = _databaseConnection.cities.Update(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }
}
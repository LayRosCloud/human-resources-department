using HumanResourcesDepartmentAPI.Data;
using HumanResourcesDepartmentAPI.Models;
using HumanResourcesDepartmentAPI.Scripts.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesDepartmentAPI.Services;

public class CityStreetService: IService<CityStreetEntity, int>
{
    private readonly DatabaseHelper _databaseConnection;

    public CityStreetService()
    {
        _databaseConnection = new DatabaseHelper();
    }

    public async Task<CityStreetEntity> Create(CityStreetEntity item)
    {
        var response = _databaseConnection.cities_streets.Add(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }

    public async Task<CityStreetEntity> Delete(int id)
    {
        var item = await Find(id);
        var response = _databaseConnection.cities_streets.Remove(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }

    public async Task<CityStreetEntity> Find(int id)
    {
        var response = await _databaseConnection.cities_streets.FirstOrDefaultAsync(x=>x.id == id);

        if(response == null)
        {
            throw new NotFoundException($"Объект с {id} не найден");
        }
        return response;
    }

    public async Task<List<CityStreetEntity>> FindAll()
    {
        var response = await _databaseConnection.cities_streets.ToListAsync();
        return response;
    }

    public async Task<CityStreetEntity> Update(CityStreetEntity item)
    {
        var response = _databaseConnection.cities_streets.Update(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }
}
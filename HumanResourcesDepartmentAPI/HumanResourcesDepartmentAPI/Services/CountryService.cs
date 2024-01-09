using HumanResourcesDepartmentAPI.Data;
using HumanResourcesDepartmentAPI.Models;
using HumanResourcesDepartmentAPI.Scripts.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesDepartmentAPI.Services;

public class CountryService: IService<CountryEntity, int>
{
    private readonly DatabaseHelper _databaseConnection;

    public CountryService()
    {
        _databaseConnection = new DatabaseHelper();
    }

    public async Task<CountryEntity> Create(CountryEntity item)
    {
        var response = _databaseConnection.countries.Add(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }

    public async Task<CountryEntity> Delete(int id)
    {
        var item = await Find(id);
        var response = _databaseConnection.countries.Remove(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }

    public async Task<CountryEntity> Find(int id)
    {
        var response = await _databaseConnection.countries.FirstOrDefaultAsync(x=>x.id == id);

        if(response == null)
        {
            throw new NotFoundException($"Объект с {id} не найден");
        }
        return response;
    }

    public async Task<List<CountryEntity>> FindAll()
    {
        var response = await _databaseConnection.countries.ToListAsync();
        return response;
    }

    public async Task<CountryEntity> Update(CountryEntity item)
    {
        var response = _databaseConnection.countries.Update(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }
}
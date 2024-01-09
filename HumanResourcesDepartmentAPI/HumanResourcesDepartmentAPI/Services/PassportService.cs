using HumanResourcesDepartmentAPI.Data;
using HumanResourcesDepartmentAPI.Models;
using HumanResourcesDepartmentAPI.Scripts.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesDepartmentAPI.Services;

public class PassportService: IService<PassportEntity, int>
{
    private readonly DatabaseHelper _databaseConnection;

    public PassportService()
    {
        _databaseConnection = new DatabaseHelper();
    }

    public async Task<PassportEntity> Create(PassportEntity item)
    {
        var response = _databaseConnection.passports.Add(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }

    public async Task<PassportEntity> Delete(int id)
    {
        var item = await Find(id);
        var response = _databaseConnection.passports.Remove(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }

    public async Task<PassportEntity> Find(int id)
    {
        var response = await _databaseConnection.passports.FirstOrDefaultAsync(x=>x.id == id);

        if(response == null)
        {
            throw new NotFoundException($"Объект с {id} не найден");
        }
        return response;
    }

    public async Task<List<PassportEntity>> FindAll()
    {
        var response = await _databaseConnection.passports.ToListAsync();
        return response;
    }

    public async Task<PassportEntity> Update(PassportEntity item)
    {
        var response = _databaseConnection.passports.Update(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }
}
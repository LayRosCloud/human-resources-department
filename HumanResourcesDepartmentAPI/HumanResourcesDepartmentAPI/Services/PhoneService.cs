using HumanResourcesDepartmentAPI.Data;
using HumanResourcesDepartmentAPI.Models;
using HumanResourcesDepartmentAPI.Scripts.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesDepartmentAPI.Services;

public class PhoneService: IService<PhoneEntity, int>
{
    private readonly DatabaseHelper _databaseConnection;

    public PhoneService()
    {
        _databaseConnection = new DatabaseHelper();
    }

    public async Task<PhoneEntity> Create(PhoneEntity item)
    {
        var response = _databaseConnection.phones.Add(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }

    public async Task<PhoneEntity> Delete(int id)
    {
        var item = await Find(id);
        var response = _databaseConnection.phones.Remove(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }

    public async Task<PhoneEntity> Find(int id)
    {
        var response = await _databaseConnection.phones.FirstOrDefaultAsync(x=>x.id == id);

        if(response == null)
        {
            throw new NotFoundException($"Объект с {id} не найден");
        }
        return response;
    }

    public async Task<List<PhoneEntity>> FindAll()
    {
        var response = await _databaseConnection.phones.ToListAsync();
        return response;
    }

    public async Task<PhoneEntity> Update(PhoneEntity item)
    {
        var response = _databaseConnection.phones.Update(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }
}
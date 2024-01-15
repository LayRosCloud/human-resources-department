using HumanResourcesDepartmentAPI.Data;
using HumanResourcesDepartmentAPI.Models;
using HumanResourcesDepartmentAPI.Scripts.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesDepartmentAPI.Services;

public class AddressService: IService<AddressEntity, int>
{
    private readonly DatabaseHelper _databaseConnection;

    public AddressService()
    {
        _databaseConnection = new DatabaseHelper();
    }

    public async Task<AddressEntity> Create(AddressEntity item)
    {
        var response = _databaseConnection.addresses.Add(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }

    public async Task<AddressEntity> Delete(int id)
    {
        var item = await Find(id);
        var response = _databaseConnection.addresses.Remove(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }

    public async Task<AddressEntity> Find(int id)
    {
        var response = await _databaseConnection.addresses.FirstOrDefaultAsync(x=> x.id == id);

        if(response == null)
        {
            throw new NotFoundException($"Объект с {id} не найден");
        }
        return response;
    }

    public async Task<List<AddressEntity>> FindAll()
    {
        var response = await _databaseConnection.addresses.ToListAsync();
        return response;
    }

    public async Task<AddressEntity> Update(AddressEntity item)
    {
        var response = _databaseConnection.addresses.Update(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }
}
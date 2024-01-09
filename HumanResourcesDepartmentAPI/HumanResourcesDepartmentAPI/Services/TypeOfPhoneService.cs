using HumanResourcesDepartmentAPI.Data;
using HumanResourcesDepartmentAPI.Models;
using HumanResourcesDepartmentAPI.Scripts.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesDepartmentAPI.Services;

public class TypeOfPhoneService: IService<TypeOfPhoneEntity, int>
{
    private readonly DatabaseHelper _databaseConnection;

    public TypeOfPhoneService()
    {
        _databaseConnection = new DatabaseHelper();
    }

    public async Task<TypeOfPhoneEntity> Create(TypeOfPhoneEntity item)
    {
        var response = _databaseConnection.types_of_phone.Add(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }

    public async Task<TypeOfPhoneEntity> Delete(int id)
    {
        var item = await Find(id);
        var response = _databaseConnection.types_of_phone.Remove(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }

    public async Task<TypeOfPhoneEntity> Find(int id)
    {
        var response = await _databaseConnection.types_of_phone.FirstOrDefaultAsync(x=>x.id == id);

        if(response == null)
        {
            throw new NotFoundException($"Объект с {id} не найден");
        }
        return response;
    }

    public async Task<List<TypeOfPhoneEntity>> FindAll()
    {
        var response = await _databaseConnection.types_of_phone.ToListAsync();
        return response;
    }

    public async Task<TypeOfPhoneEntity> Update(TypeOfPhoneEntity item)
    {
        var response = _databaseConnection.types_of_phone.Update(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }
}
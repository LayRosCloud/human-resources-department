using HumanResourcesDepartmentAPI.Data;
using HumanResourcesDepartmentAPI.Models;
using HumanResourcesDepartmentAPI.Scripts.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesDepartmentAPI.Services;

public class TypeOfSessionService : IService<TypeOfSessionEntity, int>
{
    private readonly DatabaseHelper _databaseConnection;

    public TypeOfSessionService()
    {
        _databaseConnection = new DatabaseHelper();
    }

    public async Task<TypeOfSessionEntity> Create(TypeOfSessionEntity item)
    {
        var response = _databaseConnection.types_of_sessions.Add(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }

    public async Task<TypeOfSessionEntity> Delete(int id)
    {
        var item = await Find(id);
        var response = _databaseConnection.types_of_sessions.Remove(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }

    public async Task<TypeOfSessionEntity> Find(int id)
    {
        var response = await _databaseConnection.types_of_sessions.FirstOrDefaultAsync(x=>x.id == id);

        if(response == null)
        {
            throw new NotFoundException($"Объект с {id} не найден");
        }
        return response;
    }

    public async Task<List<TypeOfSessionEntity>> FindAll()
    {
        var response = await _databaseConnection.types_of_sessions.ToListAsync();
        return response;
    }

    public async Task<TypeOfSessionEntity> Update(TypeOfSessionEntity item)
    {
        var response = _databaseConnection.types_of_sessions.Update(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }
}
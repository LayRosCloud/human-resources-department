using HumanResourcesDepartmentAPI.Data;
using HumanResourcesDepartmentAPI.Models;
using HumanResourcesDepartmentAPI.Scripts.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesDepartmentAPI.Services;

public class SessionService: IService<SessionEntity, int>
{
    private readonly DatabaseHelper _databaseConnection;

    public SessionService()
    {
        _databaseConnection = new DatabaseHelper();
    }

    public async Task<SessionEntity> Create(SessionEntity item)
    {
        var response = _databaseConnection.sessions.Add(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }

    public async Task<SessionEntity> Delete(int id)
    {
        var item = await Find(id);
        var response = _databaseConnection.sessions.Remove(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }

    public async Task<SessionEntity> Find(int id)
    {
        var response = await _databaseConnection.sessions.FirstOrDefaultAsync(x=>x.id == id);

        if(response == null)
        {
            throw new NotFoundException($"Объект с {id} не найден");
        }
        return response;
    }

    public async Task<List<SessionEntity>> FindAll()
    {
        var response = await _databaseConnection.sessions.ToListAsync();
        return response;
    }

    public async Task<SessionEntity> Update(SessionEntity item)
    {
        var response = _databaseConnection.sessions.Update(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }
}
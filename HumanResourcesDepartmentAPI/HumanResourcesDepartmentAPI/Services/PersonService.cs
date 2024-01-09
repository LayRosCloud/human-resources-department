using HumanResourcesDepartmentAPI.Data;
using HumanResourcesDepartmentAPI.Models;
using HumanResourcesDepartmentAPI.Scripts.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesDepartmentAPI.Services;

public class PersonService: IService<PersonEntity, int>
{
    private readonly DatabaseHelper _databaseConnection;

    public PersonService()
    {
        _databaseConnection = new DatabaseHelper();
    }

    public async Task<PersonEntity> Create(PersonEntity item)
    {
        var response = _databaseConnection.people.Add(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }

    public async Task<PersonEntity> Delete(int id)
    {
        var item = await Find(id);
        var response = _databaseConnection.people.Remove(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }

    public async Task<PersonEntity> Find(int id)
    {
        var response = await _databaseConnection.people.FirstOrDefaultAsync(x=>x.id == id);

        if(response == null)
        {
            throw new NotFoundException($"Объект с {id} не найден");
        }
        return response;
    }

    public async Task<List<PersonEntity>> FindAll()
    {
        var response = await _databaseConnection.people.ToListAsync();
        return response;
    }

    public async Task<PersonEntity> Update(PersonEntity item)
    {
        var response = _databaseConnection.people.Update(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }
}
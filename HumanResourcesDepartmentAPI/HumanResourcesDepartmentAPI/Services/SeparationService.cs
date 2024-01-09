using HumanResourcesDepartmentAPI.Data;
using HumanResourcesDepartmentAPI.Models;
using HumanResourcesDepartmentAPI.Scripts.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesDepartmentAPI.Services;

public class SeparationService: IService<SeparationEntity, int>
{
    private readonly DatabaseHelper _databaseConnection;

    public SeparationService()
    {
        _databaseConnection = new DatabaseHelper();
    }

    public async Task<SeparationEntity> Create(SeparationEntity item)
    {
        var response = _databaseConnection.separations.Add(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }

    public async Task<SeparationEntity> Delete(int id)
    {
        var item = await Find(id);
        var response = _databaseConnection.separations.Remove(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }

    public async Task<SeparationEntity> Find(int id)
    {
        var response = await _databaseConnection.separations.FirstOrDefaultAsync(x=>x.id == id);

        if(response == null)
        {
            throw new NotFoundException($"Объект с {id} не найден");
        }
        return response;
    }

    public async Task<List<SeparationEntity>> FindAll()
    {
        var response = await _databaseConnection.separations.ToListAsync();
        return response;
    }

    public async Task<SeparationEntity> Update(SeparationEntity item)
    {
        var response = _databaseConnection.separations.Update(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }
}
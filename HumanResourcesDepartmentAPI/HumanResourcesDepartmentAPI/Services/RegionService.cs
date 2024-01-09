using HumanResourcesDepartmentAPI.Data;
using HumanResourcesDepartmentAPI.Models;
using HumanResourcesDepartmentAPI.Scripts.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesDepartmentAPI.Services;

public class RegionService: IService<RegionEntity, int>
{
    private readonly DatabaseHelper _databaseConnection;

    public RegionService()
    {
        _databaseConnection = new DatabaseHelper();
    }

    public async Task<RegionEntity> Create(RegionEntity item)
    {
        var response = _databaseConnection.regions.Add(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }

    public async Task<RegionEntity> Delete(int id)
    {
        var item = await Find(id);
        var response = _databaseConnection.regions.Remove(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }

    public async Task<RegionEntity> Find(int id)
    {
        var response = await _databaseConnection.regions.FirstOrDefaultAsync(x=>x.id == id);

        if(response == null)
        {
            throw new NotFoundException($"Объект с {id} не найден");
        }
        return response;
    }

    public async Task<List<RegionEntity>> FindAll()
    {
        var response = await _databaseConnection.regions.ToListAsync();
        return response;
    }

    public async Task<RegionEntity> Update(RegionEntity item)
    {
        var response = _databaseConnection.regions.Update(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }
}
using HumanResourcesDepartmentAPI.Data;
using HumanResourcesDepartmentAPI.Models;
using HumanResourcesDepartmentAPI.Scripts.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesDepartmentAPI.Services;

public class DisciplineBanService: IService<DisciplineBanEntity, int>
{
    private readonly DatabaseHelper _databaseConnection;

    public DisciplineBanService()
    {
        _databaseConnection = new DatabaseHelper();
    }

    public async Task<DisciplineBanEntity> Create(DisciplineBanEntity item)
    {
        var response = _databaseConnection.discipline_bans.Add(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }

    public async Task<DisciplineBanEntity> Delete(int id)
    {
        var item = await Find(id);
        var response = _databaseConnection.discipline_bans.Remove(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }

    public async Task<DisciplineBanEntity> Find(int id)
    {
        var response = await _databaseConnection.discipline_bans.FirstOrDefaultAsync(x=>x.id == id);

        if(response == null)
        {
            throw new NotFoundException($"Объект с {id} не найден");
        }
        return response;
    }

    public async Task<List<DisciplineBanEntity>> FindAll()
    {
        var response = await _databaseConnection.discipline_bans.ToListAsync();
        return response;
    }

    public async Task<DisciplineBanEntity> Update(DisciplineBanEntity item)
    {
        var response = _databaseConnection.discipline_bans.Update(item);
        await _databaseConnection.SaveChangesAsync();
        return response.Entity;
    }
}
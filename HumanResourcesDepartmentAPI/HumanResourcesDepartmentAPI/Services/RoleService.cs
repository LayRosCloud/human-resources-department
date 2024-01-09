using HumanResourcesDepartmentAPI.Models;
using HumanResourcesDepartmentAPI.Scripts.Exceptions;
using HumanResourcesDepartmentAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesDepartmentAPI.Services
{
    public class RoleService : IService<RoleEntity, int>
    {
        private readonly DatabaseHelper _databaseConnection;

        public RoleService()
        {
            _databaseConnection = new DatabaseHelper();
        }

        public async Task<RoleEntity> Create(RoleEntity item)
        {
            var response = _databaseConnection.roles.Add(item);
            await _databaseConnection.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<RoleEntity> Delete(int id)
        {
            var item = await Find(id);
            var response = _databaseConnection.roles.Remove(item);
            await _databaseConnection.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<RoleEntity> Find(int id)
        {
            var response = await _databaseConnection.roles.FirstOrDefaultAsync(x=>x.id == id);

            if(response == null)
            {
                throw new NotFoundException($"Объект с {id} не найден");
            }
            return response;
        }

        public async Task<List<RoleEntity>> FindAll()
        {
            var response = await _databaseConnection.roles.ToListAsync();
            return response;
        }

        public async Task<RoleEntity> Update(RoleEntity item)
        {
            var response = _databaseConnection.roles.Update(item);
            await _databaseConnection.SaveChangesAsync();
            return response.Entity;
        }
    }
}

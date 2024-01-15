using HumanResourcesDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesDesktop.Repositories
{
    internal class RoleRepository
    {
        private string endpoint = "addresses";

        public async Task<List<RoleEntity>> FindAll()
        {
            var client = new HttpClient();
            var list = await client.GetFromJsonAsync<List<RoleEntity>>(AppConnect.Host + endpoint);
            return list;
        }

        public async Task<RoleEntity> Find(int id)
        {
            var client = new HttpClient();
            var item = await client.GetFromJsonAsync<RoleEntity>(AppConnect.Host + endpoint + "/" + id);
            return item;
        }

        public async Task<RoleEntity> Create(RoleEntity item)
        {
            var client = new HttpClient();
            var response = await client.PostAsJsonAsync(AppConnect.Host + endpoint, item);
            return await response.Content.ReadFromJsonAsync<RoleEntity>();
        }

        public async Task<RoleEntity> Update(RoleEntity item)
        {
            var client = new HttpClient();
            var response = await client.PutAsJsonAsync(AppConnect.Host + endpoint, item);
            return await response.Content.ReadFromJsonAsync<RoleEntity>();
        }

        public async Task Delete(int id)
        {
            var client = new HttpClient();
            await client.DeleteAsync(AppConnect.Host + endpoint + "/" + id);
        }
    }
}

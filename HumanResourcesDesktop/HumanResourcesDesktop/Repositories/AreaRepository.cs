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
    internal class AreaRepository
    {
        private string endpoint = "areas";

        public async Task<List<AreaEntity>> FindAll()
        {
            var client = new HttpClient();
            var list = await client.GetFromJsonAsync<List<AreaEntity>>(AppConnect.Host + endpoint);
            return list;
        }

        public async Task<AreaEntity> Find(int id)
        {
            var client = new HttpClient();
            var item = await client.GetFromJsonAsync<AreaEntity>(AppConnect.Host + endpoint + "/" + id);
            return item;
        }

        public async Task<AreaEntity> Create(AreaEntity item)
        {
            var client = new HttpClient();
            var response = await client.PostAsJsonAsync(AppConnect.Host + endpoint, item);
            return await response.Content.ReadFromJsonAsync<AreaEntity>();
        }

        public async Task<AreaEntity> Update(AreaEntity item)
        {
            var client = new HttpClient();
            var response = await client.PutAsJsonAsync(AppConnect.Host + endpoint, item);
            return await response.Content.ReadFromJsonAsync<AreaEntity>();
        }

        public async Task Delete(int id)
        {
            var client = new HttpClient();
            await client.DeleteAsync(AppConnect.Host + endpoint + "/" + id);
        }
    }
}
